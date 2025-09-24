import os
import pandas as pd

# Get the folder where this script is located
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))

# Helper to build full paths
def path(filename):
    return os.path.join(SCRIPT_DIR, filename)

# --- Step 1: Load fact tables and date dimensions ---
sales = pd.read_json(path("sales_fact.json"))
purchases = pd.read_json(path("clean_purchases_fact.json"))
payments = pd.read_json(path("clean_payments_fact.json"))

sales_date = pd.read_json(path("date_dimension.json"))
purchases_date = pd.read_json(path("purchase_date_dimension.json"))
payments_date = pd.read_json(path("payments_date_dimension.json"))

# --- Step 2: Add a real date_value column to each local date dimension ---
def add_date_value(df):
    # Some JSONs may not have all columns (quarter may be missing sometimes)
    if {'year','month','day'}.issubset(df.columns):
        df['date_value'] = pd.to_datetime(
            df[['year','month','day']].astype(str).agg('-'.join, axis=1),
            errors='coerce'
        )
    else:
        raise ValueError("Date dimension missing year/month/day columns")
    return df

sales_date = add_date_value(sales_date)
purchases_date = add_date_value(purchases_date)
payments_date = add_date_value(payments_date)

# --- Step 3: Merge all date dimensions ---
all_dates = pd.concat(
    [sales_date[['date_value']], purchases_date[['date_value']], payments_date[['date_value']]],
    ignore_index=True
)

# Drop duplicates and assign NEW global surrogate key
all_dates = all_dates.drop_duplicates().reset_index(drop=True)
all_dates['date_id'] = all_dates.index + 1

# Extract attributes
all_dates['day'] = all_dates['date_value'].dt.day
all_dates['month'] = all_dates['date_value'].dt.month
all_dates['quarter'] = all_dates['date_value'].dt.quarter
all_dates['year'] = all_dates['date_value'].dt.year

# Final dim_date
dim_date = all_dates[['date_id', 'day', 'month', 'quarter', 'year', 'date_value']]

# --- Step 4: Create mapping old -> new IDs for each file ---
date_mapping = dim_date.set_index('date_value')['date_id'].to_dict()

def update_fact(fact_df, old_date_df):
    # Merge fact with its local date dimension (get actual date_value from old date_id)
    merged = fact_df.merge(old_date_df[['date_id', 'date_value']], on='date_id', how='left')
    # Replace with new global date_id
    merged['date_id'] = merged['date_value'].map(date_mapping)
    return merged.drop(columns=['date_value'])

sales = update_fact(sales, sales_date)
purchases = update_fact(purchases, purchases_date)
payments = update_fact(payments, payments_date)

# --- Step 5: Save outputs ---
dim_date[['date_id', 'day', 'month', 'quarter', 'year']].to_json(
    path("dim_date.json"), 
    orient='records', 
    indent=4
)

sales.to_json(path("sales.json"), orient='records', indent=4)
purchases.to_json(path("purchases.json"), orient='records', indent=4)
payments.to_json(path("payments.json"), orient='records', indent=4)

print("✅ Unified dim_date.json created with new global IDs. All fact tables updated.")
