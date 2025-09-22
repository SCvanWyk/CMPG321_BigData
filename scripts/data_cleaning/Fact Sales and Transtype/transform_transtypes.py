import pandas as pd
import json

def clean_transtype(input_file, output_file):
    # 1. Load Excel/CSV file
    df = pd.read_excel(input_file)  # use the input_file parameter
    
    # 2. Rename columns to match JSON schema
    df = df.rename(columns={
        "TRANSTYPE_CODE": "transtype_id",
        "TRANSTYPE_DESC": "transtype_desc"
    })
    
    # 3. Convert dataframe to list of dicts (JSON documents)
    records = df.to_dict(orient="records")
    
    # 4. Save JSON for MongoDB batch insert
    with open(output_file, "w") as f:
        json.dump(records, f, indent=4)

if __name__ == "__main__":
    clean_transtype("Trans Types.xlsx", "transtype.json")  # values passed here

