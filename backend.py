import sqlite3
import os
from RFIDReader import *

# Function to check if database exists and create it if not
def create_database_if_not_exists(db_name):
    if not os.path.exists(db_name):
        conn = sqlite3.connect(db_name)
        cursor = conn.cursor()
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS rfid_tags (
            TagID TEXT PRIMARY KEY,
            Datetime TEXT,
            Product TEXT,
            Comment TEXT
        )
        ''')
        conn.commit()
        conn.close()
        print(f"Database {db_name} created with table rfid_tags.")
    else:
        print(f"Database {db_name} already exists.")

# Function to insert or update RFID tag records
def insert_or_update_records(db_name, data):
    conn = sqlite3.connect(db_name)
    cursor = conn.cursor()

    for tag in data:
        print(tag)
        cursor.execute('''
        INSERT INTO rfid_tags (TagID, Datetime)
        VALUES (:TagID, :Datetime)
        ON CONFLICT(TagID) DO UPDATE SET
            Datetime=excluded.Datetime
        ''', tag)

    conn.commit()
    conn.close()
    print("Records have been inserted or updated.")

# # Sample data from the API
# data = [
#     {'Type': '1', 'Antenna': '1', 'TagID': 'e2806915005017abf9a99a', 'RSSI': '0', 'Datetime': '2024-08-07 14:50:18'},
#     {'Type': '1', 'Antenna': '1', 'TagID': 'e2001757d174490e3f4', 'RSSI': '0', 'Datetime': '2024-08-07 14:50:18'},
#     {'Type': '1', 'Antenna': '1', 'TagID': '0bc614e', 'RSSI': '0', 'Datetime': '2024-08-07 14:50:19'}
#     # Add more data as needed
# ]

# Database name
db_name = 'rfid_tags.db'

# Create database if it doesn't exist
create_database_if_not_exists(db_name)

# Read records

rfid_reader = RFIDReader(r'C:\Users\PC-NH90\Desktop\Python\test\SWHidApi.dll')
usb_count = rfid_reader.get_usb_count()
    
if usb_count == 0:
    print("No USB Device")
else:
    if rfid_reader.open_device():
        rfid_reader.flush_device()
        while True:
            tags = rfid_reader.read_tags()
            insert_or_update_records(db_name, tags)
            time.sleep(1)
            
# Insert or update records

