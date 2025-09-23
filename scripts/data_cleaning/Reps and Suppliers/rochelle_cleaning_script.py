#!/usr/bin/env python
# coding: utf-8

# In[7]:


# Step 1: Import pandas & Load the Excel files
import pandas as pd

reps = pd.read_excel("Representatives.xlsx")
suppliers = pd.read_excel("Suppliers.xlsx")

print("Representatives file preview:")
print(reps.head())  

print("\nSuppliers file preview:")
print(suppliers.head())  


# In[8]:


# Step 2: Rename columns to follow ClearVue conventions

# For Representatives.xlsx
reps = reps.rename(columns={
    "REP_CODE": "rep_code",
    "REP_DESC": "rep_desc",
    "COMM_METHOD": "comm_method",
    "COMMISSION": "commission"
})

# For Suppliers.xlsx
suppliers = suppliers.rename(columns={
    "SUPPLIER_CODE": "supplier_id",
    "SUPPLIER_DESC": "supplier_name",
    "EXCLSV": "exclusive_flag",
    "NORMAL_PAYTERMS": "normal_payterms",
    "CREDIT_LIMIT": "credit_limit"
})

print("Representatives columns:", reps.columns.tolist())
print("Suppliers columns:", suppliers.columns.tolist())


# In[9]:


# Step 3: Clean text columns

# Representatives.xlsx
reps['rep_desc'] = reps['rep_desc'].str.strip().str.title()
reps['comm_method'] = reps['comm_method'].str.strip().str.title()

# Suppliers.xlsx
suppliers['supplier_name'] = suppliers['supplier_name'].str.strip().str.title()

print("Representatives preview after cleaning text:")
print(reps.head())

print("\nSuppliers preview after cleaning text:")
print(suppliers.head())


# In[11]:


# Step 4: Convert numeric and boolean columns

# Suppliers numeric columns
suppliers['normal_payterms'] = pd.to_numeric(suppliers['normal_payterms'], errors='coerce')
suppliers['credit_limit'] = pd.to_numeric(suppliers['credit_limit'], errors='coerce')

# Suppliers boolean column
suppliers['exclusive_flag'] = suppliers['exclusive_flag'].str.upper()  # ensure all caps
suppliers['exclusive_flag'] = suppliers['exclusive_flag'].map({'Y': True, 'N': False})

print("Suppliers preview after numeric and boolean conversion:")
print(suppliers.head())


# In[12]:


# Step 5: Check for missing data

print("Missing values in Representatives:")
print(reps.isna().sum())

print("\nMissing values in Suppliers:")
print(suppliers.isna().sum())


# In[13]:


# Step 6: Remove duplicate rows

# Check how many duplicates exist
print("Number of duplicate rows in Representatives:", reps.duplicated().sum())
print("Number of duplicate rows in Suppliers:", suppliers.duplicated().sum())

# Drop duplicate rows 
reps = reps.drop_duplicates()
suppliers = suppliers.drop_duplicates()

print("\nAfter dropping duplicates:")
print("Representatives:", reps.shape[0], "rows")
print("Suppliers:", suppliers.shape[0], "rows")


# In[14]:


# Step 7: Optional transformations

# Round commission to 2 decimal places
reps['commission'] = reps['commission'].round(2)

# Ensure ID columns stay as strings to preserve leading zeros
reps['rep_code'] = reps['rep_code'].astype(str)
suppliers['supplier_id'] = suppliers['supplier_id'].astype(str)

print("Representatives preview after rounding and ID formatting:")
print(reps.head())

print("\nSuppliers preview after ID formatting:")
print(suppliers.head())


# In[15]:


# Step 8: Save the cleaned files

# Save cleaned Representatives.xlsx
reps.to_excel("cleaned_Representatives.xlsx", index=False)

# Save cleaned Suppliers.xlsx
suppliers.to_excel("cleaned_Suppliers.xlsx", index=False)

print("✅ Cleaned files saved successfully!")


# In[ ]:




