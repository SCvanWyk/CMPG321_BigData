# CMPG321_BigData

Project Overview
This project develops a contemporary Business Intelligence (BI) solution for ClearVue Ltd. using a NoSQL database (MongoDB Atlas) and a real-time streaming framework (Apache Kafka). The aim here is to consolidate sales and operational data, carry out vital ETL (Extract, Transform, Load) processes, and offer interactive visual dashboards through Power BI.
Table of Contents

Setup and Configuration
  Prerequisites
  Local Environment
  Cloud Services
Phase 2: ETL & Streaming Development Steps
  Task 1: Batch ETL (Pandas)
  Task 2: Streaming ETL (Kafka)
  Task 3: Evaluation
Project Structure

1. Setup and Configuration

Prerequisites
You must have the following software installed locally:
Python 3.8+
Git
MongoDB Compass (for database exploration and testing)
Power BI Desktop (for Phase 3 visualization)

Local Environment
1. Clone the Repository:
Bash
git clone https://github.com/SCvanWyk/CMPG321_BigData.git
cd clearvue-bi-solution

2. Create Virtual Environment:
Bash
python -m venv venv
source venv/bin/activate  # macOS/Linux
.\venv\Scripts\activate   # Windows

3. Install Dependencies:
Bash
pip install -r requirements.txt
requirements.txt should contain: pandas, pymongo, kafka-python, python-dotenv

4. Configuration File (.env):
Create a file named .env in the root directory to store sensitive credentials securely. DO NOT commit this file to Git.
Ini, TOML
# MongoDB Atlas Connection
MONGO_URI="mongodb+srv://admin:admin@clearvueprod.si7sh3x.mongodb.net/"

# Kafka Connection (Example using Confluent Cloud)
KAFKA_BOOTSTRAP_SERVERS="pkc-xxxxx.region.aws.confluent.cloud:9092"
KAFKA_API_KEY="ABCDEFGHIJK"
KAFKA_API_SECRET="lmnopqrstuvwxyz"
KAFKA_TOPIC="payment_events"

Cloud Services
Ensure the following cloud services are active and configured:

MongoDB Atlas
Cluster provisioned, Database User created with read/write access, and Network Access configured to allow team IP addresses.

Apache Kafka
Topic (payment_events) created for real-time data flow. Connection credentials (API Key, Secret, Bootstrap Servers) secured in the .env file.

# Phase 2: ETL & Streaming Development Steps
The focus of this phase is delivering a working MongoDB instance with clean, integrated data.

Task 1: Batch ETL (Pandas)
Prepare the historical CSV files and conduct the initial batch loading into MongoDB Atlas.
Data Extraction: In BatchUploadScript.py.py, import each source CSV file as a Pandas DataFrame.
Data Cleaning: Execute the standard cleaning procedures, dealing with missing data, converting data types, and duplication.
Transformation (Business Logic):
- Compute primary business values (for example, Profit = Revenue - Cost).
- Fiscal Attributes Derivation Logic: Execute the determination logic and append columns       FiscalMonth and FiscalQuarter for the transaction dates to correspond with Clearvue's   historical reporting.
Schema Mapping: Convert the flat dataframe records into a nested JSON format as outlined in the Conceptual NoSQL Design.
Load: Use pymongo to connect and perform a bulk insert of the transformed documents to MongoDB Atlas.

Task 2: Streaming ETL (Kafka)
Create a simulation for real-time data ingestion and continuous loading to MongoDB Atlas.
Producer (kafka_streaming): Create a script to generate structured JSON documents simulating new payment transactions and push them to the payment_events Kafka topic. 
User (kafka_streaming):
- Connect to the Kafka topic and consume messages on a continuous basis.
- Implement minimal real-time transformation logic that determines how to map the simple event message to the complete NoSQL document.
- Use pymongo to complete an insert_one() to the target collection in MongoDB for every message that is processed successfully.

Task 3: Evaluation
For BI reporting, optimize the MongoDB instance as well as the data quality.
Data Quality Validation:
- Reconciliation: Compare the total document count in MongoDB against the source record count (CSV lines + total Kafka messages).
- Run sample aggregation queries on MongoDB and compare the results (e.g., total sales, average profit) against the metrics compiled in Pandas.
Performance Testing in MongoDB Compass:
- Determine the most common queries for the Power BI dashboard (e.g., date range filters, group by product/fiscal quarter).
- Run these through the explain("executionStats") command in MongoDB Compass to analyze execution plans.
- Use the explain()

# Project Structure
.
├── configuration files    	# Setup files for environment and dependencies.
├── scripts/               		# All executable code and ETL logic.
│   ├── batch_etl/       		# Scripts for Pandas data cleaning and batch loading to MongoDB.
│   └── kafka_streaming/        	# Scripts for Kafka producer/user to handle real-time data flow.
├── data/                 		# Repository for data files.
│   ├── raw/               		# Original, source data (e.g., historical CSVs).
│   └── cleaned/         	# Cleaned and transformed data (ready for database loading).
├── database_schemas/      	# Conceptual and logical data models (NoSQL structure, dimension definitions).
├── dashboards/            	# Final BI visualization assets (e.g., Power BI .pbix files).
└── docs/                 		# Project documentation, reports, and meeting notes.




