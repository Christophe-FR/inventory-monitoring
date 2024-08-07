import dash
import dash_bootstrap_components as dbc
from dash import dcc, html, Input, Output, State
from dash import dash_table
import pandas as pd
import sqlite3
from io import BytesIO

# Function to load data from database
def load_data():
    conn = sqlite3.connect('rfid_tags.db')
    query = "SELECT * FROM rfid_tags"
    df = pd.read_sql(query, conn)
    conn.close()
    return df

# Function to update data in the database
def update_data(tag_id, column, value):
    conn = sqlite3.connect('rfid_tags.db')
    c = conn.cursor()
    c.execute(f"UPDATE rfid_tags SET {column} = ? WHERE TagID = ?", (value, tag_id))
    conn.commit()
    conn.close()

# Function to delete data from the database
def delete_data(tag_id):
    conn = sqlite3.connect('rfid_tags.db')
    c = conn.cursor()
    c.execute("DELETE FROM rfid_tags WHERE TagID = ?", (tag_id,))
    conn.commit()
    conn.close()

# Function to convert DataFrame to Excel and return as bytes
def dataframe_to_excel_bytes(df):
    output = BytesIO()
    with pd.ExcelWriter(output, engine='xlsxwriter') as writer:
        df.to_excel(writer, index=False, sheet_name='Sheet1')
    return output.getvalue()

# Initialize Dash app
app = dash.Dash(__name__, external_stylesheets=[dbc.themes.BOOTSTRAP])

app.layout = dbc.Container([
    html.H1('Inventory Monitoring Tool'),
    
    html.Br(),

    # Interval component to trigger data load once
    dcc.Interval(id='interval-component', interval=1, n_intervals=0, max_intervals=1),

    dbc.Button("Refresh Data", id="refresh-button", color="primary", className="mb-3"),


    dcc.Download(id="download"),

    dcc.Loading(id='loading', children=[
        dash_table.DataTable(
            id='data-table',
            columns=[
                {'name': 'TagID', 'id': 'TagID', 'editable': False},
                {'name': 'Datetime', 'id': 'Datetime', 'editable': True},
                {'name': 'Product', 'id': 'Product', 'editable': True},
                {'name': 'Comment', 'id': 'Comment', 'editable': True},
            ],
            data=[],
            editable=True,
            row_deletable=True
        ),
        dcc.Store(id='data-store')
    ]),
    
    html.Br(),
    
    
    dbc.Button("Download Excel", id="download-button", color="secondary", className="mb-3", n_clicks=0)
    
])

@app.callback(
    Output('data-store', 'data'),
    [Input('interval-component', 'n_intervals'),
     Input('refresh-button', 'n_clicks')],
    prevent_initial_call=True
)
def load_data_callback(n_intervals, n_clicks):
    data = load_data().to_dict('records')
    return data

@app.callback(
    Output('data-table', 'data'),
    Input('data-store', 'data')
)
def update_data_table(data):
    if data is None:
        return []
    return data

@app.callback(
    Output('data-store', 'data', allow_duplicate=True),
    Input('data-table', 'data_timestamp'),
    State('data-table', 'data_previous'),
    State('data-table', 'data'),
    prevent_initial_call=True
)
def update_database_on_edit(timestamp, previous_data, current_data):
    if previous_data is None:
        raise dash.exceptions.PreventUpdate

    for old_row, new_row in zip(previous_data, current_data):
        for column in old_row:
            if old_row[column] != new_row[column]:
                update_data(new_row['TagID'], column, new_row[column])

    return current_data

@app.callback(
    Output('data-store', 'data', allow_duplicate=True),
    Input('data-table', 'data_previous'),
    State('data-table', 'data'),
    prevent_initial_call=True
)
def delete_row(previous_data, current_data):
    if len(previous_data) > len(current_data):
        for old_row in previous_data:
            if old_row not in current_data:
                delete_data(old_row['TagID'])
                break
    return current_data

@app.callback(
    Output("download", "data"),
    Input("download-button", "n_clicks"),
    State("data-store", "data"),
    prevent_initial_call=True
)
def download_data(n_clicks, data):
    df = pd.DataFrame(data)
    return dcc.send_bytes(dataframe_to_excel_bytes(df), "rfid_tags_data.xlsx")

if __name__ == '__main__':
    app.run_server(debug=False)
