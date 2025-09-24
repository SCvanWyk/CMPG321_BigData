#!/usr/bin/env python
# coding: utf-8

import pandas as pd
import json
import os

# Always resolve paths relative to script location
base_dir = os.path.dirname(os.path.abspath(__file__))

# Load cleaned Excel files
reps = pd.read_excel(os.path.join(base_dir, "cleaned_Representatives.xlsx"))
suppliers = pd.read_excel(os.path.join(base_dir, "cleaned_Suppliers.xlsx"))

# --- Representatives JSON ---
# Rename to match your desired keys
reps_json = reps.rename(columns={
    "rep_code": "rep_id",
    "rep_desc": "rep_desc",
    "comm_method": "comm_method",
    "commission": "commision"   # note: your JSON spec uses single "s"
})

# Convert to list of dicts
reps_records = reps_json.to_dict(orient="records")

# Save to JSON file
with open(os.path.join(base_dir, "Representatives.json"), "w", encoding="utf-8") as f:
    json.dump(reps_records, f, indent=4, ensure_ascii=False)


# --- Suppliers JSON ---
suppliers_json = suppliers.rename(columns={
    "supplier_id": "supplier_id",
    "supplier_name": "supplier_desc",
    "exclusive_flag": "exclsv"
})

# Convert boolean True/False back to "Y"/"N" for JSON
suppliers_json["exclsv"] = suppliers_json["exclsv"].map({True: "Y", False: "N"})

# Convert to list of dicts
suppliers_records = suppliers_json.to_dict(orient="records")

# Save to JSON file
with open(os.path.join(base_dir, "Suppliers.json"), "w", encoding="utf-8") as f:
    json.dump(suppliers_records, f, indent=4, ensure_ascii=False)

print("✅ JSON export complete: Representatives.json & Suppliers.json")
