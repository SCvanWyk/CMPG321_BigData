import pandas as pd
import json
import os

def clean_payments_fact(headers_file, lines_file, output_fact_file, output_date_file):
    """
    headers_file: payment headers Excel
    lines_file: payment lines Excel
    output_fact_file: cleaned payments fact JSON
    output_date_file: date dimension JSON
    """

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
        "CUSTOMER_NUMBER": "customer_id",
        "DEPOSIT_REF": "payment_id"
    }
    line_rename = {
        "DEPOSIT_REF": "payment_id",
        "BANK_AMT": "bank_amt",
        "DISCOUNT": "discount",
        "TOT_PAYMENT": "total_payment",
        "DEPOSIT_DATE": "fin_date"   # fin_date is in lines, not headers
    }

    df_headers.rename(columns=header_rename, inplace=True)
    df_lines.rename(columns=line_rename, inplace=True)

    # Remove duplicates
    df_headers.drop_duplicates(inplace=True)
    df_lines.drop_duplicates(inplace=True)

    # ---------------------
    # Merge headers into lines on payment_id
    # ---------------------
    df = pd.merge(df_lines, df_headers, on="payment_id", how="left")

    # ---------------------
    # Keep only relevant fields
    # ---------------------
    cols = [
        "payment_id",
        "customer_id",
        "date_id",
        "fin_date",
        "bank_amt",
        "discount",
        "total_payment"
    ]

    # Add missing columns if not present
    for col in cols:
        if col not in df.columns:
            df[col] = None

    # Drop rows missing critical info
    df.dropna(subset=["payment_id", "customer_id"], inplace=True)

    # ---------------------
    # Create Date Dimension
    # ---------------------
    df["fin_date"] = pd.to_datetime(df["fin_date"], errors="coerce")
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
    df_fact = df[cols].copy()  # only fact fields

    # Convert datetime fields to string for JSON serialization
    if "fin_date" in df_fact.columns:
        df_fact["fin_date"] = df_fact["fin_date"].astype(str)

    with open(fact_path, "w") as f:
        json.dump(df_fact.to_dict(orient="records"), f, indent=4)

    with open(date_path, "w") as f:
        json.dump(date_records, f, indent=4)

    print(f"✅ Payments fact table saved: {output_fact_file}")
    print(f"✅ Payments date dimension saved: {output_date_file}")


if __name__ == "__main__":
    clean_payments_fact(
        headers_file="Payment Header.xlsx",
        lines_file="Payment Lines.xlsx",
        output_fact_file="clean_payments_fact.json",
        output_date_file="payments_date_dimension.json"
    )
