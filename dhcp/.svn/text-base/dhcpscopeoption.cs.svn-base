using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dhcp
{
    public class DhcpOption {
        private uint _optionID;
        private string _optionName;
        private string _optionComment;
        private string[] _stringData;
        private uint[] _intData;
        private byte[] _byteData;
        private DHCP_OPTION_DATA _optionData;
        private DHCP_OPTION_TYPE _optionType;
        private DHCP_OPTION_DATA_TYPE _optionDataType;

        public byte[] ByteData {
            get { return _byteData; }
            set { _byteData = value; }
        }
        public uint[] IntData
        {
            get { return _intData; }
            set { _intData = value; }
        }
        public string[] StringData {
            get { return _stringData; }
            set { _stringData = value; }
        }
        public uint OptionID
        {
            get { return _optionID; }
            set { _optionID = value; }
        }
        public string OptionName {
            get { return _optionName; }
            set { _optionName = value; }
        }
        public string OptionComment {
            get { return _optionComment; }
            set { _optionComment = value; }
        }
        public DHCP_OPTION_DATA OptionData {
            get { return _optionData; }
            set { _optionData = value; }
        }
        public DHCP_OPTION_TYPE OptionType {
            get { return _optionType; }
            set { _optionType = value; }
        }
        public DHCP_OPTION_DATA_TYPE OptionDataType {
            get { return _optionDataType; }
            set { _optionDataType = value; }
        }


        public static int DhcpCreateOption(string ipAddress, DhcpOption Option) {
            DHCP_OPTION convertedOption = new DHCP_OPTION();
            convertedOption.OptionType = Option.OptionType;
            convertedOption.OptionName = Option.OptionName;
            convertedOption.OptionID = Option.OptionID;
            convertedOption.OptionComment = Option.OptionComment;
            convertedOption.DefaultValue = ConvertToNative(Option); 
            int success = dhcpsapimethods.DhcpCreateOption(ipAddress, convertedOption.OptionID, ref convertedOption);
            return success;
        }

        public static int DhcpSetOptionValue(string server, DhcpOption Option) { 
            DHCP_OPTION_SCOPE_INFO scopeInfo = new DHCP_OPTION_SCOPE_INFO();
            scopeInfo.ScopeType = DHCP_OPTION_SCOPE_TYPE.DhcpGlobalOptions;
            DHCP_OPTION convertedOption = new DHCP_OPTION();
            //convertedOption.
            int success = dhcpsapimethods.DhcpSetOptionValue(server, Option.OptionID, ref scopeInfo, ref convertedOption.DefaultValue);
            return success;


        }
        
        private static DHCP_OPTION_DATA ConvertToNative(DhcpOption Option) {
            DHCP_OPTION_DATA_ELEMENT dataElement = new DHCP_OPTION_DATA_ELEMENT();
            DHCP_OPTION_DATA data = new DHCP_OPTION_DATA();
            IntPtr dataPtr;
            if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpStringDataOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpByteOption) {
                data.NumElements = Option.ByteData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.ByteData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpDWordDWordOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpDWordOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpEncapsulatedDataOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpIpAddressOption) {
                data.NumElements = Option.IntData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.IntData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpIpAddressOption;
                    dataElement.IpAddressOption = Option.IntData[i];
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpIpv6AddressOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            } else if (Option.OptionDataType == DHCP_OPTION_DATA_TYPE.DhcpWordOption) {
                data.NumElements = Option.StringData.Length;
                data.Elements = Marshal.AllocHGlobal(Option.StringData.Length);
                for (int i = 0; i < data.NumElements; i++) {
                    dataElement.OptionType = DHCP_OPTION_DATA_TYPE.DhcpStringDataOption;
                    dataElement.StringDataOption = Marshal.StringToBSTR(Option.StringData[i]);
                    dataPtr = (IntPtr)(data.Elements.ToInt32()) + (i * Marshal.SizeOf(typeof(DHCP_OPTION_DATA_ELEMENT)));
                    Marshal.StructureToPtr(dataElement, dataPtr, false);
                }
                return data;
            }
            return data;
        }
    }
}
