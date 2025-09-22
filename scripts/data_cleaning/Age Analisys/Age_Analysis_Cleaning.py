import pandas as pd

file_path = "Age Analysis.xlsx"
df = pd.read_excel(file_path, sheet_name="Age_Analysis")

#Recalculate TOTAL_DUE to show the actual accurate total debt. :D
aging_columns = [
    "AMT_CURRENT", "AMT_30_DAYS", "AMT_60_DAYS", "AMT_90_DAYS", "AMT_120_DAYS",
    "AMT_150_DAYS", "AMT_180_DAYS", "AMT_210_DAYS", "AMT_240_DAYS", "AMT_270_DAYS",
    "AMT_300_DAYS", "AMT_330_DAYS", "AMT_360_DAYS"
]
df["TOTAL_DUE"] = df[aging_columns].sum(axis=1)

#Convert FIN_PERIOD to YYYY-MM format to make the data easier to read and use. Teehee
df["FIN_PERIOD"] = pd.to_datetime(df["FIN_PERIOD"].astype(str), format="%Y%m").dt.strftime("%Y-%m")

#Remove empty rows. UwU
df = df[(df[aging_columns].sum(axis=1) != 0)]

#Remove duplicate records. OwO
df = df.drop_duplicates()

#Remove negative values across all amount columns. Kawaii~
amount_columns = ["TOTAL_DUE"] + aging_columns
df = df[(df[amount_columns] >= 0).all(axis=1)]

df.to_excel("Age_Analysis_Cleaned.xlsx", index=False)

print("Data cleaning complete. Cleaned file saved as Age_Analysis_Cleaned.xlsx")

#Fetch the cleaned Excel file to convert to JSON. :3
excel_file = "Age_Analysis_Cleaned.xlsx"
df = pd.read_excel(excel_file)

#Convert to JSON which you can clearly see from this script so this comment is lowkey useless, but cool beans I guess - UwU
json_file = "Age_Analysis_Cleaned.json"
df.to_json(json_file, orient="records", indent=4)

print(f"Age_Analysis_Cleaned converted to {json_file}")

#Also you better appreciate the cute accents I added at the end of each comment >:3