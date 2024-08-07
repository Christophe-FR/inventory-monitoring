using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RFID;
using System.Runtime.InteropServices;
using System.Net;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button11.Enabled = false;

            string strSN = "";
            byte[] arrBuffer = new byte[512];
            int iHidNumber = 0;
            UInt16 iIndex = 0;
            comboBox1.Items.Clear();
            iHidNumber = RFID.CFHidApi.CFHid_GetUsbCount();
            for (iIndex = 0; iIndex < iHidNumber; iIndex++)
            {
                RFID.CFHidApi.CFHid_GetUsbInfo(iIndex, arrBuffer);
                strSN = System.Text.Encoding.Default.GetString(arrBuffer);
                comboBox1.Items.Add(strSN);
            }
            if (iHidNumber > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            byte[] arrBuffer = new byte[64];

            if (RFID.CFHidApi.CFHid_OpenDevice((UInt16)comboBox1.SelectedIndex))
            {
				this.SetText("Open Success\r\n");
                if (RFID.CFHidApi.CFHid_GetDeviceSystemInfo(0xFF,arrBuffer) == false) //获取系统信息失败
                {
                    this.SetText("Device is Out\r\n");
                    //RFID.CFHidApi.CFHid_CloseDevice();
                    //return;
                }
            }
            else
            {
                this.SetText("Failed\r\n");
                return;
            }

            string str = "",str1="";
            str = String.Format("SoftVer:{0:D}.{0:D}\r\n", arrBuffer[0] >> 4, arrBuffer[0] & 0x0F);
            this.SetText(str);
            str = String.Format("HardVer:{0:D}.{0:D}\r\n", arrBuffer[1] >> 4, arrBuffer[1] & 0x0F);
            this.SetText(str);
            str = "SN:";
            for (int i = 0; i < 7; i++)
            {
                str1 = String.Format("{0:X2}", arrBuffer[2 + i]);
                str = str + str1;
            }
            str = str + "\r\n";
            this.SetText(str);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            RFID.CFHidApi.CFHid_CloseDevice();
            button1.Enabled = true;
            button2.Enabled = false;
            button6.Enabled = true;
            button11.Enabled = false;
            this.SetText("Close\r\n");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button6.Enabled = true;
            button11.Enabled = false;
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (this.textBox1.TextLength > 1000) this.textBox1.Text = "";
                this.textBox1.Text = this.textBox1.Text + text;
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret(); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.SetText("ActiveMode\r\n");
            RFID.CFHidApi.CFHid_ClearTagBuf();
            timer1.Interval = 100;
            timer1.Enabled = true;
            button6.Enabled = false;
            button11.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] arrBuffer = new byte[64000];
            ushort iNum = 0;
            ushort iTotalLen = 0; 
            this.SetText("AnswerMode\r\n");
            if (RFID.CFHidApi.CFHid_InventoryG2(0xFF, arrBuffer, out iTotalLen, out iNum) == false)
            {
                this.SetText("Failed\r\n");
                return;
            }
            int iTagLength = 0;
            int iTagNumber = 0;
            iTagLength = iTotalLen;
            iTagNumber = iNum;
            if (iTagNumber == 0) return;
            int iIndex = 0;
            int iLength = 0;
            byte bPackLength = 0;
            int iIDLen = 0;
            int i = 0;

            for (iIndex = 0; iIndex < iTagNumber; iIndex++)
            {
                bPackLength = arrBuffer[iLength];
                string str2 = "";
                string str1 = "";
                str1 = arrBuffer[1 + iLength + 0].ToString("X2");
                if ((arrBuffer[1 + iLength + 0] & 0x80) == 0x80)
                {   // with TimeStamp , last 6 bytes is time
                    iIDLen = bPackLength - 7;
                }
                else iIDLen = bPackLength - 1;

                str2 = str2 + "Type:" + str1 + " ";  //Tag Type

                str1 = arrBuffer[1 + iLength + 1].ToString("X2");
                str2 = str2 + "Ant:" + str1 + " Tag:";  //Ant

                string str3 = "";
                for (i = 2; i < iIDLen; i++)
                {
                    str1 = arrBuffer[1 + iLength + i].ToString("X2");
                    str3 = str3 + str1 + " ";
                }
                str2 = str2 + str3;
                str1 = arrBuffer[1 + iLength + i].ToString("X2");
                str2 = str2 + "RSSI:" + str1 + "\r\n";  //RSSI
                iLength = iLength + bPackLength + 1;
                this.SetText(str2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] Password = new byte[4];
            Password[0] = 0; 
            Password[1] = 0;
            Password[2] = 0;
            Password[3] = 0;
            byte[] arrBuffer = new byte[12];
            arrBuffer[0] = 0x00;
            arrBuffer[1] = 0x11;
            arrBuffer[2] = 0x22;
            arrBuffer[3] = 0x33;
            arrBuffer[4] = 0x44;
            arrBuffer[5] = 0x55;
            arrBuffer[6] = 0x66;
            arrBuffer[7] = 0x77;
            arrBuffer[8] = 0x88;
            arrBuffer[9] = 0x99;
            arrBuffer[10] = 0xAA;
            arrBuffer[11] = 0xBB;
            if (RFID.CFHidApi.CFHid_WriteCardG2(0xFF, Password, 1, 2, 6, arrBuffer) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string strSN = "";
            byte[] arrBuffer = new byte[256];
            int iHidNumber = 0;
            UInt16 iIndex = 0;
            comboBox1.Items.Clear();
            iHidNumber = RFID.CFHidApi.CFHid_GetUsbCount();
            for (iIndex = 0; iIndex < iHidNumber; iIndex++)
            {
                RFID.CFHidApi.CFHid_GetUsbInfo(iIndex, arrBuffer);
                strSN = System.Text.Encoding.Default.GetString(arrBuffer);
                comboBox1.Items.Add(strSN);
            }
            if (iHidNumber > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {  //ReadRFPower
            byte bParamAddr = 0;
            byte[] bValue = new byte[2];

            /*  01: Transport
                02: WorkMode
                03: DeviceAddr
                04: FilterTime
                05: RFPower
                06: BeepEnable
                07: UartBaudRate*/
            bParamAddr = 0x05;

            if (RFID.CFHidApi.CFHid_ReadDeviceOneParam(0xFF, bParamAddr, bValue) == false)
            {
                this.SetText("Faild");
                return;
            }
            string str1 = "";
            str1 = bValue[0].ToString("d2");
            str1 = "RF:"+str1 + "\r\n";

            comboBox2.SelectedIndex = bValue[0];
            this.SetText(str1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte bParamAddr = 0;
            byte bValue = 0;

            /*  01: Transport
                02: WorkMode
                03: DeviceAddr
                04: FilterTime
                05: RFPower
                06: BeepEnable
                07: UartBaudRate*/
            bParamAddr = 0x05;
            //bValue = 26;   //RF = 26

            bValue = (byte)Convert.ToInt16(comboBox2.SelectedItem);

            if (RFID.CFHidApi.CFHid_SetDeviceOneParam(0xFF, bParamAddr, bValue) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (RFID.CFHidApi.CFHid_RelayOn(0xFF) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (RFID.CFHidApi.CFHid_RelayOff(0xFF) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] arrBuffer = new byte[64000];
            int iNum = 0;
            int iTotalLen = 0;
            byte bRet = 0;

            bRet = RFID.CFHidApi.CFHid_GetTagBuf(arrBuffer, out iTotalLen, out iNum);
            if (bRet == 1)
            {
                this.SetText("DevOut");
                return; //DevOut
            }
            else if (bRet == 0) return; //No Connect
            int iTagLength = 0;
            int iTagNumber = 0;
            iTagLength = iTotalLen;
            iTagNumber = iNum;
            if (iTagNumber == 0) return;
            int iIndex = 0;
            int iLength = 0;
            byte bPackLength = 0;
            int i = 0;
            int iIDLen = 0;
            for (iIndex = 0; iIndex < iTagNumber; iIndex++)
            {
                bPackLength = arrBuffer[iLength];
                string str2 = "";
                string str1 = "";
                str1 = arrBuffer[1 + iLength + 0].ToString("X2");
                str2 = str2 + "Type:" + str1 + " ";  //Tag Type
                if ((arrBuffer[1 + iLength + 0] & 0x80) == 0x80)
                {   // with TimeStamp , last 6 bytes is time
                    iIDLen = bPackLength - 7;
                }
                else iIDLen = bPackLength - 1;

                str1 = arrBuffer[1 + iLength + 1].ToString("X2");
                str2 = str2 + "Ant:" + str1 + " Tag:";  //Ant

                string str3 = "";
                for (i = 2; i < iIDLen; i++)
                {
                    str1 = arrBuffer[1 + iLength + i].ToString("X2");
                    str3 = str3 + str1 + " ";
                }
                str2 = str2 + str3;
                str1 = arrBuffer[1 + iLength + i].ToString("X2");
                str2 = str2 + "RSSI:" + str1 + "\r\n";  //RSSI
                iLength = iLength + bPackLength + 1;
                this.SetText(str2);
            }
        }
        byte g_bDevType = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            byte[] pBuffer = new byte[512];
            byte[] bDevType = new byte[2];
            byte ucParamLength = 0;
            string str1, str2;
            int i = 0;
            if (RFID.CFHidApi.CFHid_ReadDeviceNetParam(0xFF, bDevType, pBuffer, out ucParamLength))
            {
                g_bDevType = bDevType[0]; //copy devtype for set
                str2 = "";
                for (i = 0; i < 6; i++)
                {
                    str1 = pBuffer[0 + i].ToString("X2");
                    str2 = str2 + str1;
                }
                textBoxMac.Text = str2;  //Mac

                str2 = "";
                for (i = 0; i < 4; i++)
                {
                    str1 = pBuffer[6 + i].ToString();
                    str2 = str2 + str1 + ".";
                }
                str2 = str2.Substring(0, str2.Length - 1);
                textBoxLocalIP.Text = str2;  //IP

                str2 = "";
                for (i = 0; i < 4; i++)
                {
                    str1 = pBuffer[10 + i].ToString();
                    str2 = str2 + str1 + ".";
                }
                str2 = str2.Substring(0, str2.Length - 1);
                textBoxMask.Text = str2;  //Mask

                str2 = "";
                for (i = 0; i < 4; i++)
                {
                    str1 = pBuffer[14 + i].ToString();
                    str2 = str2 + str1 + ".";
                }
                str2 = str2.Substring(0, str2.Length - 1);
                textBoxGate.Text = str2;  //Gate

                str2 = "";
                for (i = 0; i < 4; i++)
                {
                    str1 = pBuffer[18 + i].ToString();
                    str2 = str2 + str1 + ".";
                }
                str2 = str2.Substring(0, str2.Length - 1);
                textBoxDistinIP.Text = str2;  //Gate

                int iPort = 0;
                iPort = pBuffer[23] * 256 + pBuffer[22];
                textBoxLocalPort.Text = iPort.ToString();

                iPort = pBuffer[25] * 256 + pBuffer[24];
                textBoxDistinPort.Text = iPort.ToString();

                if (pBuffer[26] == 1) checkBoxDHCP.Checked = true;
                else checkBoxDHCP.Checked = false;

                if (pBuffer[27] == 1) checkBoxDNS.Checked = true;
                else checkBoxDNS.Checked = false;

                textBoxHeartTime.Text = pBuffer[28].ToString();

                byte[] arrDns = new byte[48];
                for (i = 0; i < 32; i++)
                {
                    arrDns[i] = pBuffer[29 + i];
                }
                str1 = System.Text.Encoding.ASCII.GetString(arrDns);
                textBoxDNS.Text = str1;

                for (i = 0; i < 32; i++)
                {
                    arrDns[i] = pBuffer[29 + 32 + i];
                }
                str1 = System.Text.Encoding.ASCII.GetString(arrDns);
                textBoxRSSI.Text = str1;

                for (i = 0; i < 32; i++)
                {
                    arrDns[i] = pBuffer[29 + 64 + i];
                }
                str1 = System.Text.Encoding.ASCII.GetString(arrDns);
                textBoxPass.Text = str1;

                SetText("Success\r\n");

            }
            else { SetText("failed\r\n"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] arrSN = new byte[16];
            byte[] arrTemp = new byte[512];
            byte[] ucBuffer = new byte[512];
            int i = 0;

            for (i = 0; i < 12; i += 2)
            {
                ucBuffer[i / 2] = (byte)Convert.ToByte(textBoxMac.Text.Substring(i, 2), 16);
            }

            byte[] byts = IPAddress.Parse(textBoxLocalIP.Text).GetAddressBytes();

            ucBuffer[6] = byts[0]; ucBuffer[7] = byts[1]; ucBuffer[8] = byts[2]; ucBuffer[9] = byts[3]; //IP

            byts = IPAddress.Parse(textBoxMask.Text).GetAddressBytes();
            ucBuffer[10] = byts[0]; ucBuffer[11] = byts[1]; ucBuffer[12] = byts[2]; ucBuffer[13] = byts[3]; //Mask

            byts = IPAddress.Parse(textBoxGate.Text).GetAddressBytes();
            ucBuffer[14] = byts[0]; ucBuffer[15] = byts[1]; ucBuffer[16] = byts[2]; ucBuffer[17] = byts[3]; //Gate

            byts = IPAddress.Parse(textBoxDistinIP.Text).GetAddressBytes();
            ucBuffer[18] = byts[0]; ucBuffer[19] = byts[1]; ucBuffer[20] = byts[2]; ucBuffer[21] = byts[3]; //DistinIP

            UInt16 iPort = Convert.ToUInt16(textBoxLocalPort.Text);
            ucBuffer[22] = (Byte)(iPort % 256);
            ucBuffer[23] = (Byte)(iPort / 256);  //LocalPort

            iPort = Convert.ToUInt16(textBoxDistinPort.Text);
            ucBuffer[24] = (Byte)(iPort % 256);
            ucBuffer[25] = (Byte)(iPort / 256);  //DistinPort

            if (checkBoxDHCP.Checked) ucBuffer[26] = 1;
            else ucBuffer[26] = 0;

            if (checkBoxDNS.Checked) ucBuffer[27] = 1;
            else ucBuffer[27] = 0;

            ucBuffer[28] = Convert.ToByte(textBoxHeartTime.Text);

            arrTemp = System.Text.Encoding.Default.GetBytes(textBoxDNS.Text);
            for (i = 0; i < textBoxDNS.Text.Length; i++) ucBuffer[29 + i] = arrTemp[i];   //DNS name

            arrTemp = System.Text.Encoding.Default.GetBytes(textBoxRSSI.Text);
            for (i = 0; i < textBoxRSSI.Text.Length; i++) ucBuffer[29 + 32 + i] = arrTemp[i];   //DNS name

            arrTemp = System.Text.Encoding.Default.GetBytes(textBoxPass.Text);
            for (i = 0; i < textBoxPass.Text.Length; i++) ucBuffer[29 + 64 + i] = arrTemp[i];   //DNS name

            if (RFID.CFHidApi.CFHid_SetDeviceNetParam(0xFF,g_bDevType,ucBuffer, 29 + 64 + 32))
            {
                SetText("Success\r\n");
            }
            else SetText("failed\r\n");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (RFID.CFHidApi.CFHid_DefaultDeviceNetParam(0xFF))
            {
                SetText("Success\r\n");
            }
            else SetText("failed\r\n");
        }
    }
}