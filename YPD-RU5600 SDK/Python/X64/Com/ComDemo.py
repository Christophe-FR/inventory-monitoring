#!/usr/bin/python
# -*- coding: UTF-8 -*-
import ctypes
import time
import platform

Objdll = ctypes.windll.LoadLibrary(r'C:\Users\PC-NH90\Desktop\Python\X86\USB\SWHidApi.dll')
#Objdll = cdll.LoadLibrary("./libSWComApi.so")
print(Objdll)

if Objdll.SWCom_OpenDevice("COM4".encode(), 115200) == 1:   # open device
    print("OpenSuccess")
else:
    print("OpenError")

Objdll.SWCom_ClearTagBuf()    # start to get data

from ctypes import *
import time

while True:
    arrBuffer = bytes(9182)
    iTagLength = c_int(0)
    iTagNumber = c_int(0)
    ret = Objdll.SWCom_GetTagBuf(arrBuffer, byref(iTagLength), byref(iTagNumber))
    if iTagNumber.value > 0:
        iIndex = int(0)
        iLength = int(0)
        bPackLength = c_byte(0)
        for iIndex in range(0,  iTagNumber.value):
            bPackLength = arrBuffer[iLength]
            str2 = ""
            str1 = ""
            str1 = hex(arrBuffer[1 + iLength + 0])
            str2 = str2 + "Type:" + str1 + " "  # Tag Type
            str1 = hex(arrBuffer[1 + iLength + 1])
            str2 = str2 + "Ant:" + str1 + " Tag:"  # Ant
            str3 = ""
            i = int(0)
            for i in range(2, bPackLength - 1):
                str1 = hex(arrBuffer[1 + iLength + i])
                str3 = str3 + str1 + " "
            str2 = str2 + str3   # TagID

            str1 = hex(arrBuffer[1 + iLength + i + 1])
            str2 = str2 + "RSSI:" + str1      # RSSI
            iLength = iLength + bPackLength + 1
            print(str2)    # print information
    time.sleep(1)










