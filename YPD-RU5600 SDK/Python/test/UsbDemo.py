import ctypes
import time
from ctypes import c_int, byref
from datetime import datetime

class RFIDReader:
    def __init__(self, dll_path):
        self.dll_path = dll_path
        self.lib = ctypes.windll.LoadLibrary(dll_path)
        self.device_opened = False

    def get_usb_count(self):
        return self.lib.SWHid_GetUsbCount()

    def open_device(self, device_index=0):
        if self.lib.SWHid_OpenDevice(device_index) == 1:
            self.device_opened = True
            print("Device opened successfully.")
            return True
        else:
            print("Failed to open device.")
            return False

    def flush_device(self):
        self.lib.SWHid_ClearTagBuf()

    def read_tags(self):
        if not self.device_opened:
            raise Exception("Device is not opened. Call open_device() first.")
        
        arrBuffer = bytes(9182)
        iTagLength = c_int(0)
        iTagNumber = c_int(0)
        ret = self.lib.SWHid_GetTagBuf(arrBuffer, byref(iTagLength), byref(iTagNumber))
        if iTagNumber.value > 0:
            tags = self._process_tags(arrBuffer, iTagNumber.value)
            unique_tags = self._remove_duplicates(tags)
            timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            for tag in unique_tags:
                tag["Datetime"] = timestamp
            return unique_tags
        else:
            return []

    def _process_tags(self, buffer, tag_count):
        tags = []
        iLength = 0
        for _ in range(tag_count):
            tag_info = {
                "Type": hex(buffer[1 + iLength])[2:],
                "Antenna": hex(buffer[1 + iLength + 1])[2:],
                "TagID": "".join(hex(buffer[1 + iLength + i])[2:] for i in range(2, buffer[iLength] - 1)),
                "RSSI": hex(buffer[1 + iLength + buffer[iLength] - 1])[2:]
            }
            iLength += buffer[iLength] + 1
            tags.append(tag_info)
        return tags

    def _remove_duplicates(self, tags):
        seen = set()
        unique_tags = []
        for tag in tags:
            tag_id = tag["TagID"]
            if tag_id not in seen:
                seen.add(tag_id)
                unique_tags.append(tag)
        return unique_tags

if __name__ == "__main__":
    rfid_reader = RFIDReader(r'C:\Users\PC-NH90\Desktop\Python\test\SWHidApi.dll')
    usb_count = rfid_reader.get_usb_count()
    
    if usb_count == 0:
        print("No USB Device")
    else:
        if rfid_reader.open_device():
            rfid_reader.flush_device()
            while True:
                tags = rfid_reader.read_tags()
                print(f"{len(tags)} TAGS FOUND !")
                for tag in tags:
                    print(tag)
                time.sleep(1)
