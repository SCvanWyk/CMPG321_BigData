from pymongo import MongoClient
import os
import json
import traceback

# --- CONFIG ---
# Folder where your cleaned JSON files are
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
print("SCRIPT_DIR =", SCRIPT_DIR)

# MongoDB connection
client = MongoClient("mongodb+srv://admin:admin@clearvueprod.si7sh3x.mongodb.net/")
db = client["CLEARVUE_BI"]

# List of dimension collections (will use existing _id)
dim_collections = [
    "dim_date", "dim_customer", "dim_products",
    "dim_representatives", "dim_suppliers", "dim_transtype", "age_analysis"
]

# Indexes for fact tables
fact_indexes = {
    "sales": ["date_id", "customer_id", "inventory_code","transtype_id","rep_id"],
    "purchases": ["date_id", "supplier_id", "inventory_id"],
    "payments": ["date_id", "customer_id"]
}

# --- Get all JSON files in folder ---
json_files = [f for f in os.listdir(SCRIPT_DIR) if f.endswith(".json")]
if not json_files:
    print("⚠️ No JSON files found in", SCRIPT_DIR)

# --- FUNCTIONS ---
def load_json_file(file_name):
    file_path = os.path.join(SCRIPT_DIR, file_name)
    print("Loading:", file_path)
    with open(file_path, "r") as f:
        data = json.load(f)
    return data

def get_collection_name(file_name):
    return os.path.splitext(file_name)[0]

# --- DROP ALL COLLECTIONS FIRST ---
for coll_name in db.list_collection_names():
    db.drop_collection(coll_name)
    print(f"🗑 Dropped collection: {coll_name}")

# --- LOAD JSON FILES ---
for file_name in json_files:
    collection_name = get_collection_name(file_name)
    data = load_json_file(file_name)

    if not data:
        print(f"⚠️ {collection_name} is empty, skipping")
        continue

    # Dimensions: set _id from unique key
    if collection_name in dim_collections:
        for doc in data:
            unique_keys = [k for k in doc.keys() if k.endswith("_id")]
            if unique_keys:
                doc["_id"] = doc[unique_keys[0]]

    # Insert into MongoDB
    collection = db[collection_name]
    try:
        collection.insert_many(data)
    except Exception:
        print(f"❌ Failed inserting {collection_name}")
        traceback.print_exc()
        continue

    # Create indexes for fact tables
    if collection_name in fact_indexes:
        for field in fact_indexes[collection_name]:
            collection.create_index(field)

    print(f"✅ Loaded {len(data)} documents into '{collection_name}' collection")
    print(f"   First doc: {data[0]}")

print("\n🎯 All JSON files loaded successfully into MongoDB!")
