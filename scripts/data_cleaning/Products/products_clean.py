import pandas as pd
import os
import re

def clean_products_dimension(
    products_file,
    brands_file,
    categories_file,
    ranges_file,
    styles_file,
    output_json,
    output_excel
):
    base_dir = os.path.dirname(os.path.abspath(__file__))

    # === Load and rename columns for consistent join keys ===
    products_df = pd.read_excel(os.path.join(base_dir, products_file)).rename(columns={
        "INVENTORY_CODE": "inventory_code",
        "PRODCAT_CODE"  : "category_code",
        "BRAND_CODE"    : "brand_code",
        "PRAN_CODE"     : "range_code",
        "LAST_COST"     : "last_cost",
        "STOCK_IND"     : "stock_ind"
    })

    brands_df = pd.read_excel(os.path.join(base_dir, brands_file)).rename(columns={
        "PRODBRA_CODE": "brand_code",
        "PRODBRA_DESC": "brand",
    })

    categories_df = pd.read_excel(os.path.join(base_dir, categories_file)).rename(columns={
        "PRODCAT_CODE": "category_code",
        "PRODCAT_DESC": "category",
        "BRAND_CODE" : "brand_code",
        "PRAN_CODE"  : "range_code",
    })

    ranges_df = pd.read_excel(os.path.join(base_dir, ranges_file)).rename(columns={
        "PRAN_CODE": "range_code",
        "PRAN_DESC": "range",
    })

    styles_df = pd.read_excel(os.path.join(base_dir, styles_file)).rename(columns={
        "INVENTORY_CODE": "inventory_code",
        "STYLE": "style",
        "MATERIAL": "material",
        "COLOUR": "colour",
        "BRANDING": "branding",
        "QUAL_PROBS": "qual_process",
        "GENDER": "gender",
    })

    # === Merge all data ===
    df = (
        products_df
        .merge(categories_df, how="left", on="category_code")
        .merge(brands_df,     how="left", on="brand_code")
        .merge(ranges_df,     how="left", on="range_code")
        .merge(styles_df,     how="left", on="inventory_code")
    )

    # --- Helper cleaning functions ---
    def standard_case(val):
        if pd.isna(val):
            return ""
        return str(val).strip().title()

    def clean_category(text):
        if pd.isna(text):
            return ""
        t = str(text).strip()
        t = re.sub(r"[+/\\\\]", " ", t)   # remove + and slashes
        t = re.sub(r"\b\d{1,2}[/-]\d{1,2}[/-]?\d{0,4}\b", " ", t)  # date-like
        t = re.sub(r"\d{4}", " ", t)      # 4 digit years
        t = re.sub(r"\d{2}", " ", t)      # 2 digit numbers
        t = re.sub(r"\d{1}", " ", t)      # single digits
        t = re.sub(r"[^A-Za-z0-9\s-]", " ", t)
        t = re.sub(r"\s+", " ", t)
        return t.strip().title()

    def clean_range(text):
        if pd.isna(text):
            return ""
        t = str(text).strip()
        t = re.sub(r"[+/\\\\]", " ", t)
        t = re.sub(r"\s+", " ", t)
        return t.strip().title()

    def clean_gender(text):
        if pd.isna(text):
            return ""
        t = str(text).strip().lower()
        if t.startswith("m"): return "Male"
        if t.startswith("f"): return "Female"
        return t.title()

    def clean_style(text):
        if pd.isna(text):
            return ""
        # convert slash to hyphen and title case
        t = str(text).strip()
        t = re.sub(r"/", "-", t)
        t = re.sub(r"\s+", " ", t)
        return t.strip().title()

    # === Apply cleaning ===
    if "category" in df.columns:
        df["category"] = df["category"].apply(clean_category)
    if "range" in df.columns:
        df["range"] = df["range"].apply(clean_range)
    if "gender" in df.columns:
        df["gender"] = df["gender"].apply(clean_gender)

    # style gets special handling to unify separator
    if "style" in df.columns:
        df["style"] = df["style"].apply(clean_style)

    for col in ["material", "colour", "branding", "qual_process"]:
        if col in df.columns:
            df[col] = df[col].apply(standard_case)

    # === Rename to final JSON headers ===
    df.rename(columns={
        "inventory_code": "inventory_id",
        "last_cost": "last_cost",
        "stock_ind": "stock_ind",
        "brand": "brand",
        "category": "category",
        "range": "range",
        "style": "style",
        "material": "material",
        "colour": "colour",
        "branding": "branding",
        "qual_process": "qual_process",
        "gender": "gender"
    }, inplace=True)

    # Keep only required columns in correct order
    final_cols = [
        "inventory_id", "category", "brand", "range", "last_cost",
        "stock_ind", "gender", "material", "style", "colour",
        "branding", "qual_process"
    ]
    df = df[final_cols]

    # === Ensure no empty cells ===
    # Replace NaN, blanks, or pure whitespace with "N/A"
    df = df.replace(r"^\s*$", "N/A", regex=True).fillna("N/A")

    # === Save outputs ===
    df.to_excel(os.path.join(base_dir, output_excel), index=False)

    # Convert to JSON and remove escaped slashes
    json_text = df.to_json(orient="records", indent=4, force_ascii=False)
    json_text = json_text.replace("\\/", "/")  # <-- ensures plain N/A instead of N\/A

    with open(os.path.join(base_dir, output_json), "w", encoding="utf-8") as f:
        f.write(json_text)

    print(f"✅ Cleaning complete → {output_excel} & {output_json}")


# === Example call ===
if __name__ == "__main__":
    clean_products_dimension(
        products_file   = "Products.xlsx",
        brands_file     = "Product Brands.xlsx",
        categories_file = "Product Categories.xlsx",
        ranges_file     = "Product Ranges.xlsx",
        styles_file     = "Products Styles.xlsx",
        output_json     = "products_dimension_clean.json",
        output_excel    = "products_dimension_clean.xlsx"
    )
