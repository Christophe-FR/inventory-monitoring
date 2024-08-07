import sqlite3
import pandas as pd
import streamlit as st
from st_aggrid import AgGrid, GridOptionsBuilder, GridUpdateMode

# Connect to SQLite database
conn = sqlite3.connect('rfid_tags.db')
c = conn.cursor()

# Function to load data from database
def load_data():
    query = "SELECT * FROM rfid_tags"
    df = pd.read_sql(query, conn)
    return df

# Function to update data in the database
def update_data(tag_id, tag_type, antenna, rssi, datetime, comment):
    c.execute(
        "UPDATE rfid_tags SET Type = ?, Antenna = ?, RSSI = ?, Datetime = ?, Comment = ? WHERE TagID = ?",
        (tag_type, antenna, rssi, datetime, comment, tag_id)
    )
    conn.commit()

# Streamlit app
st.title('RFID Tags Database Viewer & Editor')

# Load data
data = load_data()

# Display data with editable grid
st.write('Data from RFID Tags SQLite database:')
gb = GridOptionsBuilder.from_dataframe(data)
gb.configure_pagination()
gb.configure_default_column(editable=True)
grid_options = gb.build()

grid_response = AgGrid(
    data,
    gridOptions=grid_options,
    update_mode=GridUpdateMode.MODEL_CHANGED,
    allow_unsafe_jscode=True,
    theme='streamlit'
)

updated_data = grid_response['data']

# Check for updates and push to database
if st.button('Update Database'):
    for index, row in updated_data.iterrows():
        update_data(row['TagID'], row['Type'], row['Antenna'], row['RSSI'], row['Datetime'], row['Comment'])
    st.success('Database updated successfully!')

# Refresh data after update
data = load_data()
st.write('Updated data:')
st.dataframe(data)
