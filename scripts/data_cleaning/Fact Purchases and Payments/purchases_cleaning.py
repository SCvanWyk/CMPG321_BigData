import pandas as pd
import json
import os

def clean_purchases_fact(headers_file, lines_file, output_fact_file, output_date_file):
    base_dir = os.path.dirname(os.path.abspath(__file__))
    headers_path = os.path.join(base_dir, headers_file)
    lines_path = os.path.join(base_dir, lines_file)
    fact_path = os.path.join(base_dir, output_fact_file)
    date_path = os.path.join(base_dir, output_date_file)

    # ---------------------
    # Load Excel files
    # ---------------------
    df_headers = pd.read_excel(headers_path)
    df_lines = pd.read_excel(lines_path)

    # ---------------------
    # Rename columns for consistency
    # ---------------------
    header_rename = {
        "SUPPLIER_CODE": "supplier_id",
        "PURCH_DOC_NO": "purchase_id",
        "PURCH_DATE": "fin_date"
    }
    line_rename = {
        "PURCH_DOC_NO": "purchase_id",
        "INVENTORY_CODE": "inventory_id",
        "QUANTITY": "quantity_purchased",
        "UNIT_COST_PRICE": "unit_cost_price"
    }

    df_headers.rename(columns=header_rename, inplace=True)
    df_lines.rename(columns=line_rename, inplace=True)

    # Remove duplicates
    df_headers.drop_duplicates(inplace=True)
    df_lines.drop_duplicates(inplace=True)

    # ---------------------
    # Merge headers into lines on purchase_id
    # ---------------------
    df = pd.merge(df_lines, df_headers, on="purchase_id", how="left")

    # ---------------------
    # Keep only relevant fields
    # ---------------------
    cols = [
        "purchase_id",
        "inventory_id",
        "supplier_id",
        "date_id",
        "fin_date",
        "unit_cost_price",
        "quantity_purchased",
        "total_cost"   # <-- renamed calculated field
    ]

    for col in cols:
        if col not in df.columns:
            df[col] = None

    # ---------------------
    # Data cleaning
    # ---------------------
    # Drop rows missing critical info
    df.dropna(subset=["inventory_id", "supplier_id", "purchase_id"], inplace=True)

    # Drop invalid values
    df = df[df["quantity_purchased"] > 0]
    df = df[df["unit_cost_price"] > 0]

    # Recalculate total_cost as unit_cost_price * quantity_purchased
    df["total_cost"] = df["unit_cost_price"] * df["quantity_purchased"]

    # Round numeric fields to 2 decimal places
    numeric_cols = ["unit_cost_price", "quantity_purchased", "total_cost"]
    df[numeric_cols] = df[numeric_cols].round(2)

    # ---------------------
    # Create Date Dimension
    # ---------------------
    df["fin_date"] = pd.to_datetime(df["fin_date"], errors='coerce')
    df = df[df["fin_date"].notna()]
    unique_dates = df["fin_date"].drop_duplicates().sort_values().reset_index(drop=True)

    date_records = []
    for i, dt in enumerate(unique_dates, start=1):
        date_records.append({
            "date_id": i,
            "day": dt.day,
            "month": dt.month,
            "quarter": (dt.month - 1) // 3 + 1,
            "year": dt.year
        })

    # Map fin_date to date_id
    date_map = {dt: rec["date_id"] for dt, rec in zip(unique_dates, date_records)}
    df["date_id"] = df["fin_date"].map(date_map)

    # ---------------------
    # Export JSON
    # ---------------------
    df_fact = df[cols].copy()
    df_fact["fin_date"] = df_fact["fin_date"].astype(str)

    with open(fact_path, "w") as f:
        json.dump(df_fact.to_dict(orient="records"), f, indent=4)

    with open(date_path, "w") as f:
        json.dump(date_records, f, indent=4)

    print(f"✅ Purchases fact table saved: {output_fact_file}")
    print(f"✅ Purchases date dimension saved: {output_date_file}")


if __name__ == "__main__":
    clean_purchases_fact(
        headers_file="Purchases Headers.xlsx",
        lines_file="Purchases Lines.xlsx",
        output_fact_file="clean_purchases_fact.json",
        output_date_file="purchase_date_dimension.json"
    )
