unit CFHidApi;

interface

//******** Func: Get Usb Device Number**********/
//  Param: None
//  Return: Success return number, failed return 0
//*********************************************************/
function CFHid_GetUsbCount():Integer;cdecl;external 'CFHidApi.dll';

//******** Func: Get USB HID value**********/
//  Param: iIndex: HID Index 0,1,2....
//         pucDeviceInfo: HID value
//  Return: Success return number, failed return 0
//*********************************************************/
function CFHid_GetUsbInfo(iIndex:Word;pucDeviceInfo:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Open Device  *******************************/
//  Param:iIndex: HID Index 0,1,2....
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_OpenDevice(iIndex:Word):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Close Device *******************************/
//  Param: None
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_CloseDevice():Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: GetDeviceInfo. 9Bytes**********/
//  Param: bDevAdr: 0xFF
//         pucSystemInfo: SysInfo  9Bytes 1:SoftVer 2:HardVer 3 - 9:DeviceSN
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_GetDeviceSystemInfo(bDevAdr:Byte; pucSystemInfo:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Get Device One Param**********/
//  Param: bDevAdr: 0xFF
//         pucDevParamAddr: Param Addr
//         pValue: Return Param Value
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_ReadDeviceOneParam(bDevAdr:Byte; DevParamAddr:Byte;pValue:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Set Device One Param**********/
//  Param: bDevAdr: 0xFF
//         pucDevParamAddr: Param Addr
//         bValue: Param
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_SetDeviceOneParam(bDevAdr:Byte; DevParamAddr:Byte;bValue:Byte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Stop all RF reading**********/
//  Param: bDevAdr: 0xFF
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_StopRead(bDevAdr:Byte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Start all RF reading**********/
//  Param: bDevAdr: 0xFF
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_StartRead(bDevAdr:Byte):Boolean;cdecl;external 'CFHidApi.dll';

type  FUNPTR_ACTIVE_CALLBACK=procedure(msg:Integer;tagnum:Integer;tagdata:PByte;devsn:PByte);cdecl;
function  CFHid_SetCallback(pActiveCallback:FUNPTR_ACTIVE_CALLBACK):Integer;cdecl;external 'CFHidApi.dll';

//******** Func: Inventory EPC**********/
//  Param: bDevAdr: 0xFF
//         pBuffer: Get Buffer
//         Totallen: Get Buffer Length
//         CardNum: Tag Number
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_InventoryG2(bDevAdr:Byte;pBuffer:PByte;Totallen:PByte;CardNum:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Write EPC**********/
//  Param: bDevAdr: 0xFF
//         Password: Password (4 bytes)
//         WriteEPC: Write Data
//         WriteEPClen: Write Length
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_WriteEPCG2(bDevAdr:Byte;Password:PByte;WriteEPC:PByte;WriteEPClen:Byte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Read Card**********/
//  Param: bDevAdr: 0xFF
//         Password: Password (4 bytes)
//         Mem:      0:Reserved 1:EPC 2:TID 3:USER
//         WordPtr:  Start Address
//         ReadEPClen: Read Length
//         Data: Read Data
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_ReadCardG2(bDevAdr:Byte;Password:PByte;Mem:Byte;WordPtr:Byte;ReadEPClen:Byte;ReadData:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: Write Card**********/
//  Param: bDevAdr: 0xFF
//         Password: Password (4 bytes)
//         Mem:      0:Reserved 1:EPC 2:TID 3:USER
//         WordPtr:  Start Address
//         WriteEPC: Write Data
//         WriteEPClen: Write Length
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_WriteCardG2(bDevAdr:Byte;Password:PByte;Mem:Byte;WordPtr:Byte;Writelen:Byte;Writedata:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: RelayOn**********/
//  Param: bDevAdr: 0xFF
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_RelayOn(bDevAdr:Byte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: RelayOff**********/
//  Param: bDevAdr: 0xFF
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_RelayOff(bDevAdr:Byte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: SetFreq**********/
//  Param: bDevAdr: 0xFF
//         pFreq: Set 2bytes Freq Value
	//pFreq[0]   pFreq[1]
	//0x31        0x80     //US Freq
	//0x4E        0x00     //Europe
	//0x2C        0xA3     //China
	//0x29        0x9D     //Korea
	//0x2E        0x9F     //Australia
	//0x4E        0x00     //New Zealand
	//0x4E        0x00     //India
	//0x2C        0x81     //Singapore
	//0x2C        0xA3     //Hongkong
	//0x31        0xA7     //Taiwan
	//0x31        0x80     //Canada
	//0x31        0x80     //Mexico
	//0x31        0x99     //Brazil
	//0x1C        0x99     //Israel
	//0x24        0x9D     //South Africa
	//0x2C        0xA3     //Thailand
	//0x28        0xA1     //Malaysia
	//0x29        0x9D     //Japan
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_SetFreq(bDevAdr:Byte;pFreq:PByte):Boolean;cdecl;external 'CFHidApi.dll';

//******** Func: ReadFreq**********/
//  Param: bDevAdr: 0xFF
//         pFreq: Return 2bytes Freq Value
	//pFreq[0]   pFreq[1]
	//0x31        0x80     //US Freq
	//0x4E        0x00     //Europe
	//0x2C        0xA3     //China
	//0x29        0x9D     //Korea
	//0x2E        0x9F     //Australia
	//0x4E        0x00     //New Zealand
	//0x4E        0x00     //India
	//0x2C        0x81     //Singapore
	//0x2C        0xA3     //Hongkong
	//0x31        0xA7     //Taiwan
	//0x31        0x80     //Canada
	//0x31        0x80     //Mexico
	//0x31        0x99     //Brazil
	//0x1C        0x99     //Israel
	//0x24        0x9D     //South Africa
	//0x2C        0xA3     //Thailand
	//0x28        0xA1     //Malaysia
	//0x29        0x9D     //Japan
//  Return: Success return 1, failed return 0
//*********************************************************/
function CFHid_ReadFreq(bDevAdr:Byte;pFreq:PByte):Boolean;cdecl;external 'CFHidApi.dll';

implementation

end.