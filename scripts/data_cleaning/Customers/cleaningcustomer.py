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
    Merges customer-related data from four Excel files, cleans it,
    and exports the result to a JSON file.

    Args:
        customer_file (str): Path to the main Customer Excel file.
        params_file (str): Path to the Customer Account Parameters Excel file.
        categories_file (str): Path to the Customer Categories Excel file.
        regions_file (str): Path to the Customer Regions Excel file.
        output_json_file (str): Name of the output JSON file.
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
        # Merge Excel files based on primary keys
        # ---------------------
        # Start with the main customer dataframe and merge others
        df_merged = pd.merge(df_customer, df_params, on="CUSTOMER_NUMBER", how="left")
        df_merged = pd.merge(df_merged, df_categories, on="CCAT_CODE", how="left")
        df_merged = pd.merge(df_merged, df_regions, on="REGION_CODE", how="left")

        # ---------------------
        # Convert naming conventions
        # ---------------------
        # Define a mapping dictionary from old to new, snake_case names
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

        # Rename the columns
        df_merged.rename(columns=column_rename_map, inplace=True)

        # ---------------------
        # Remove redundant fields
        # ---------------------
        # Keep only the columns that are in our final, desired list
        final_columns = list(column_rename_map.values())
        df_final = df_merged[final_columns]

        # ---------------------
        # Export as a JSON file
        # ---------------------
        # Convert the DataFrame to a list of records (dictionaries) for JSON export
        json_records = df_final.to_dict(orient="records")

        # Write the list of dictionaries to a JSON file
        with open(output_json_file, "w") as f:
            json.dump(json_records, f, indent=4)

        print(f"✅ Successfully processed and saved data to '{output_json_file}'")

    except FileNotFoundError as e:
        print(f"Error: A required file was not found. Please check the file names and paths. Details: {e}")
    except Exception as e:
        print(f"An unexpected error occurred: {e}")

# The entry point of the script
if __name__ == "__main__":
    clean_customer_data(
        customer_file="Customer.xlsx",
        params_file="Customer Account Parameters.xlsx",
        categories_file="Customer Categories.xlsx",
        regions_file="Customer Regions.xlsx",
        output_json_file="cleaned_customer_data.json"
    )