import pandas as pd
import json
import os


def clean_customer_data(
    customer_file: str,
    params_file: str,
    categories_file: str,
    regions_file: str,
    output_json_file: str = "customer_data.json"
):
    """
    Merges and cleans customer-related data from four Excel files,
    then exports the cleaned result to a JSON file.
    """
    try:
        # ---------------------
        # Load Excel files
        # ---------------------
        df_customer = pd.read_excel(customer_file)
        df_params = pd.read_excel(params_file)
        df_categories = pd.read_excel(categories_file)
        df_regions = pd.read_excel(regions_file)

        # ---------------------
        # Merge on keys
        # ---------------------
        df_merged = pd.merge(df_customer, df_params, on="CUSTOMER_NUMBER", how="left")
        df_merged = pd.merge(df_merged, df_categories, on="CCAT_CODE", how="left")
        df_merged = pd.merge(df_merged, df_regions, on="REGION_CODE", how="left")

        # ---------------------
        # Rename columns
        # ---------------------
        column_rename_map = {
            "CUSTOMER_NUMBER": "customer_id",
            "REP_CODE": "rep_id",
            "REGION_DESC": "region",
            "NORMAL_PAYTERMS": "normal_payterms",
            "DISCOUNT": "discount",
            "CCAT_DESC": "category",
            "PARAMETER": "parameter",
            "CREDIT_LIMIT": "credit_limit"
        }
        df_merged.rename(columns=column_rename_map, inplace=True)

        # ---------------------
        # Keep only needed columns (make a copy to avoid SettingWithCopyWarning)
        # ---------------------
        final_columns = list(column_rename_map.values())
        df_final = df_merged[final_columns].copy()

        # ---------------------
        # Cleaning process
        # ---------------------

        # 1. Drop duplicates based on customer_id
        df_final = df_final.drop_duplicates(subset=["customer_id"])

        # 2. Drop rows missing critical fields
        required_fields = ["customer_id", "rep_id", "region", "category"]
        df_final = df_final.dropna(subset=required_fields)

        # 3. Coerce numeric fields
        df_final["discount"] = pd.to_numeric(df_final["discount"], errors="coerce")
        df_final["credit_limit"] = pd.to_numeric(df_final["credit_limit"], errors="coerce")

        # Remove rows where discount or credit_limit is NaN
        df_final = df_final.dropna(subset=["discount", "credit_limit"])

        # 4. Remove negative values
        df_final = df_final[(df_final["discount"] >= 0) & (df_final["credit_limit"] >= 0)]

        # 5. Strip whitespace & normalize text fields
        text_fields = ["region", "category", "parameter", "normal_payterms"]
        for col in text_fields:
            if col in df_final.columns:
                df_final[col] = df_final[col].astype(str).str.strip().str.title()

        # ---------------------
        # Export cleaned JSON
        # ---------------------
        json_records = df_final.to_dict(orient="records")

        with open(output_json_file, "w", encoding="utf-8") as f:
            json.dump(json_records, f, indent=4, ensure_ascii=False)

        print(f"✅ Cleaned data saved to '{output_json_file}'")

    except FileNotFoundError as e:
        print(f"❌ File not found: {e.filename}")
    except Exception as e:
        print(f"❌ Unexpected error: {e}")


if __name__ == "__main__":
    clean_customer_data(
        customer_file="Customer.xlsx",
        params_file="Customer Account Parameters.xlsx",
        categories_file="Customer Categories.xlsx",
        regions_file="Customer Regions.xlsx",
        output_json_file="cleaned_customer_data.json"
    )
