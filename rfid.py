import ctypes
from ctypes import c_int, c_bool, c_ushort, c_ubyte, c_char_p, POINTER, CFUNCTYPE, create_string_buffer

class SWHidApi:
    def __init__(self, library_path):
        self.swhidapi = ctypes.CDLL(library_path)
        self._setup_functions()

    def _setup_functions(self):
        self.swhidapi.SWHid_GetUsbCount.restype = c_int

        self.swhidapi.SWHid_GetUsbInfo.argtypes = [c_ushort, c_char_p]
        self.swhidapi.SWHid_GetUsbInfo.restype = c_bool

        self.swhidapi.SWHid_OpenDevice.argtypes = [c_ushort]
        self.swhidapi.SWHid_OpenDevice.restype = c_bool

        self.swhidapi.SWHid_CloseDevice.restype = c_bool

        self.swhidapi.SWHid_GetDeviceSystemInfo.argtypes = [c_ubyte, c_char_p]
        self.swhidapi.SWHid_GetDeviceSystemInfo.restype = c_bool

        self.swhidapi.SWHid_ReadDeviceOneParam.argtypes = [c_ubyte, c_ubyte, POINTER(c_ubyte)]
        self.swhidapi.SWHid_ReadDeviceOneParam.restype = c_bool

        self.swhidapi.SWHid_SetDeviceOneParam.argtypes = [c_ubyte, c_ubyte, c_ubyte]
        self.swhidapi.SWHid_SetDeviceOneParam.restype = c_bool

        self.swhidapi.SWHid_StopRead.argtypes = [c_ubyte]
        self.swhidapi.SWHid_StopRead.restype = c_bool

        self.swhidapi.SWHid_StartRead.argtypes = [c_ubyte]
        self.swhidapi.SWHid_StartRead.restype = c_bool

        self.swhidapi.SWHid_SetCallback.argtypes = [CFUNCTYPE(None, c_int, c_int, POINTER(c_ubyte), c_int, POINTER(c_ubyte))]
        self.swhidapi.SWHid_SetCallback.restype = c_int

        self.swhidapi.SWHid_InventoryG2.argtypes = [c_ubyte, POINTER(c_ubyte), POINTER(c_ushort), POINTER(c_ushort)]
        self.swhidapi.SWHid_InventoryG2.restype = c_bool

        self.swhidapi.SWHid_WriteEPCG2.argtypes = [c_ubyte, POINTER(c_ubyte), POINTER(c_ubyte), c_ubyte]
        self.swhidapi.SWHid_WriteEPCG2.restype = c_bool

        self.swhidapi.SWHid_ReadCardG2.argtypes = [c_ubyte, POINTER(c_ubyte), c_ubyte, c_ubyte, c_ubyte, POINTER(c_ubyte)]
        self.swhidapi.SWHid_ReadCardG2.restype = c_bool

        self.swhidapi.SWHid_WriteCardG2.argtypes = [c_ubyte, POINTER(c_ubyte), c_ubyte, c_ubyte, c_ubyte, POINTER(c_ubyte)]
        self.swhidapi.SWHid_WriteCardG2.restype = c_bool

        self.swhidapi.SWHid_RelayOn.argtypes = [c_ubyte]
        self.swhidapi.SWHid_RelayOn.restype = c_bool

        self.swhidapi.SWHid_RelayOff.argtypes = [c_ubyte]
        self.swhidapi.SWHid_RelayOff.restype = c_bool

    def get_usb_count(self):
        return self.swhidapi.SWHid_GetUsbCount()

    def get_usb_info(self, iIndex):
        pucDeviceInfo = create_string_buffer(256)  # Assuming 256 is sufficient
        result = self.swhidapi.SWHid_GetUsbInfo(iIndex, pucDeviceInfo)
        return result, pucDeviceInfo.value

    def open_device(self, iIndex):
        return self.swhidapi.SWHid_OpenDevice(iIndex)

    def close_device(self):
        return self.swhidapi.SWHid_CloseDevice()

    def get_device_system_info(self, bDevAdr):
        pucSystemInfo = create_string_buffer(9)
        result = self.swhidapi.SWHid_GetDeviceSystemInfo(bDevAdr, pucSystemInfo)
        return result, pucSystemInfo.raw

    def read_device_one_param(self, bDevAdr, pucDevParamAddr):
        pValue = c_ubyte()
        result = self.swhidapi.SWHid_ReadDeviceOneParam(bDevAdr, pucDevParamAddr, ctypes.byref(pValue))
        return result, pValue.value

    def set_device_one_param(self, bDevAdr, pucDevParamAddr, bValue):
        return self.swhidapi.SWHid_SetDeviceOneParam(bDevAdr, pucDevParamAddr, bValue)

    def stop_read(self, bDevAdr):
        return self.swhidapi.SWHid_StopRead(bDevAdr)

    def start_read(self, bDevAdr):
        return self.swhidapi.SWHid_StartRead(bDevAdr)

    def set_callback(self, callback_function):
        CALLBACK = CFUNCTYPE(None, c_int, c_int, POINTER(c_ubyte), c_int, POINTER(c_ubyte))
        return self.swhidapi.SWHid_SetCallback(CALLBACK(callback_function))

    def inventory_g2(self, bDevAdr, buffer_size=256):
        pBuffer = (c_ubyte * buffer_size)()
        Totallen = c_ushort()
        CardNum = c_ushort()
        result = self.swhidapi.SWHid_InventoryG2(bDevAdr, pBuffer, ctypes.byref(Totallen), ctypes.byref(CardNum))
        return result, pBuffer[:Totallen.value], CardNum.value

    def write_epc_g2(self, bDevAdr, password, write_epc, write_epc_len):
        Password = (c_ubyte * len(password))(*password)
        WriteEPC = (c_ubyte * len(write_epc))(*write_epc)
        return self.swhidapi.SWHid_WriteEPCG2(bDevAdr, Password, WriteEPC, write_epc_len)

    def read_card_g2(self, bDevAdr, password, mem, word_ptr, read_epc_len):
        Password = (c_ubyte * len(password))(*password)
        Data = (c_ubyte * read_epc_len)()
        result = self.swhidapi.SWHid_ReadCardG2(bDevAdr, Password, mem, word_ptr, read_epc_len, Data)
        return result, Data[:read_epc_len]

    def write_card_g2(self, bDevAdr, password, mem, word_ptr, write_len, write_data):
        Password = (c_ubyte * len(password))(*password)
        WriteData = (c_ubyte * len(write_data))(*write_data)
        return self.swhidapi.SWHid_WriteCardG2(bDevAdr, Password, mem, word_ptr, write_len, WriteData)

    def relay_on(self, bDevAdr):
        return self.swhidapi.SWHid_RelayOn(bDevAdr)

    def relay_off(self, bDevAdr):
        return self.swhidapi.SWHid_RelayOff(bDevAdr)


if __name__ == "__main__":
    api = SWHidApi('libSWHidApi.so')

    usb_count = api.get_usb_count()
    print(f"USB Count: {usb_count}")

    if usb_count > 0:
        result, info = api.get_usb_info(0)
        print(f"USB Info: {info.decode()}")

        if api.open_device(0):
            print("Device opened successfully.")

            result, system_info = api.get_device_system_info(0xFF)
            if result:
                print(f"System Info: {system_info}")

            if api.close_device():
                print("Device closed successfully.")
