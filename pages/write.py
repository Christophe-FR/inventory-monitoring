import streamlit as st
import pandas as pd
import time
import datetime


st.header('Write RFID')

with st.spinner('Searching tag...'):
    time.sleep(5)
    while True:
        tag_detected = True
        if tag_detected:
            text_write = st.text_input('Description')
            text_read = 'z'
            if text_write == text_read:
                st.success('text written')
                time.sleep(3)
            break
        time.sleep(0.2)
