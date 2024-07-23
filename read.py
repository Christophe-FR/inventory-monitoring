import streamlit as st
import pandas as pd
import time
import datetime

st.header('Read RFID')
t = datetime.datetime.now()
st.write(':clock10:', t)


read = [{"UID": "123456789", "Description": "Sample Tag 1"},
        {"UID": "987654321", "Description": "Sample Tag 2"}]

if not read:
    st.warning('no tags detected')
else:
    df = pd.DataFrame(read)
    st.write(df.shape[0], ' tags detected')
    df

time.sleep(1)
st.rerun()
