# =========================================
# Python script to clean Sales Headers and Lines,
# remove duplicates/junk data, create Date dimension,
# and merge into a single Sales Fact table for MongoDB.
# =========================================

import pandas as pd  # pandas for reading Excel and data manipulation
import json          # json for exporting MongoDB-ready JSON
import os            # os for working with file paths

# -----------------------------
# Function to clean and merge sales data
# -----------------------------
def clean_sales_fact(headers_file, lines_file, output_fact_file, output_date_file):
    """
    headers_file: Excel file containing sales headers (string)
    lines_file: Excel file containing sales lines (string)
    output_fact_file: output JSON file for merged fact table (string)
    output_date_file: output JSON file for date dimension (string)
    """

    # -----------------------------
    # 1️⃣ Define base directory of the script
    # -----------------------------
    # This ensures files are read relative to the script location
    base_dir = os.path.dirname(os.path.abspath(__file__))

    # Build full paths for input and output files
    headers_path = os.path.join(base_dir, headers_file)
    lines_path = os.path.join(base_dir, lines_file)
    fact_path = os.path.join(base_dir, output_fact_file)
    date_path = os.path.join(base_dir, output_date_file)

    # -----------------------------
    # 2️⃣ Load Excel files
    # -----------------------------
    df_headers = pd.read_excel(headers_path)  # Load headers
    df_lines = pd.read_excel(lines_path)      # Load lines

    # -----------------------------
    # 3️⃣ Remove duplicates and junk data
    # -----------------------------
    df_headers.drop_duplicates(inplace=True)      # Remove duplicate header rows
    df_lines.drop_duplicates(inplace=True)        # Remove duplicate line rows

    # Example junk data removal: remove lines with quantity 0 or negative
    df_lines = df_lines[df_lines['QUANTITY'] > 0]

    # Example header junk removal: remove rows with missing DOC_NUMBER
    df_headers = df_headers[df_headers['DOC_NUMBER'].notna()]

    # -----------------------------
    # 4️⃣ Convert TRANS_DATE to datetime
    # -----------------------------
    df_headers['TRANS_DATE'] = pd.to_datetime(df_headers['TRANS_DATE'], errors='coerce')
    df_headers = df_headers[df_headers['TRANS_DATE'].notna()]  # Remove rows where date could not be parsed

    # -----------------------------
    # 5️⃣ Create Date dimension
    # -----------------------------
    unique_dates = df_headers['TRANS_DATE'].drop_duplicates().sort_values().reset_index(drop=True)
    date_records = []
    for i, dt in enumerate(unique_dates, start=1):
        date_records.append({
            "date_id": i,
            "day": dt.day,
            "month": dt.month,
            "quarter": (dt.month-1)//3 + 1,
            "year": dt.year
        })

    # Save Date dimension JSON
    with open(date_path, "w") as f:
        json.dump(date_records, f, indent=4)

    # Map TRANS_DATE to date_id
    date_map = {dt: rec["date_id"] for dt, rec in zip(unique_dates, date_records)}
    df_headers['date_id'] = df_headers['TRANS_DATE'].map(date_map)

    # -----------------------------
    # 6️⃣ Rename columns to match fact table schema
    # -----------------------------
    df_headers = df_headers.rename(columns={
        "DOC_NUMBER": "doc_number",
        "TRANSTYPE_CODE": "transtype_id",
        "REP_CODE": "rep_id",
        "CUSTOMER_NUMBER": "customer_id",
        "FIN_PERIOD": "fin_date"
    })

    # Ensure fin_date is integer
    df_headers["fin_date"] = df_headers["fin_date"].astype(int)

    df_lines = df_lines.rename(columns={
        "DOC_NUMBER": "doc_number",
        "INVENTORY_CODE": "inventory_code",
        "QUANTITY": "quantity_sold",
        "UNIT_SELL_PRICE": "unit_selling_price",
        "TOTAL_LINE_PRICE": "total_line_price",
        "LAST_COST": "unit_last_cost"
    })

    # -----------------------------
    # 7️⃣ Merge header info into lines to get dimensions
    # -----------------------------
    df_fact = df_lines.merge(
        df_headers[['doc_number', 'rep_id', 'transtype_id', 'customer_id', 'date_id', 'fin_date']],
        on='doc_number',
        how='left'
    )

    # -----------------------------
    # 8️⃣ Keep only relevant columns for fact table
    # -----------------------------
    fact_columns = [
        "rep_id", "transtype_id", "customer_id", "date_id", "fin_date",
        "inventory_code", "quantity_sold", "unit_selling_price",
        "unit_last_cost", "total_line_price"
    ]
    df_fact = df_fact[fact_columns]

    # -----------------------------
    # 9️⃣ Remove any remaining rows with missing critical info
    # -----------------------------
    df_fact = df_fact.dropna(subset=["rep_id", "transtype_id", "customer_id", "date_id"])

    # -----------------------------
    # 🔟 Export to JSON for MongoDB batch insert
    # -----------------------------
    records = df_fact.to_dict(orient="records")
    with open(fact_path, "w") as f:
        json.dump(records, f, indent=4)

    print(f"✅ Sales fact table saved: {output_fact_file}")
    print(f"✅ Date dimension saved: {output_date_file}")


# -----------------------------
# 11️⃣ Run script
# -----------------------------
if __name__ == "__main__":
    # ⚠️ Change the filenames here if your Excel files are named differently
    clean_sales_fact(
        headers_file="Sales Header.xlsx",
        lines_file="Sales Line.xlsx",
        output_fact_file="sales_fact.json",
        output_date_file="date_dimension.json"
    )
