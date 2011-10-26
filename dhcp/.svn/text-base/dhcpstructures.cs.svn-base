using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dhcp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_IP_ADDRESS {
        public String IpAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_OPTION_ID {
        public Int32 OptionID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_IP_MASK {
        public string SubnetMask;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_RESUME_HANDLE {
        public Int32 ResumeHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_ATTRIB_ID {
        public Int32 AttributeID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_IPV6_ADDRESS {
        public Int32 IPv6Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_CLIENT_INFO_ARRAY {
        public Int32 NumElements;
        public IntPtr Clients;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_CLIENT_INFO
    {
        public uint ClientIpAddress;
        public uint SubnetMask;
        public DHCP_CLIENT_UID ClientHardwareAddress;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ClientName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ClientComment;
        public DATE_TIME ClientLeaseExpires;
        public DHCP_HOST_INFO OwnerHost;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_OPTION
    {
        public uint OptionID;
        public string OptionName;
        public string OptionComment;
        public DHCP_OPTION_DATA DefaultValue;
        public DHCP_OPTION_TYPE OptionType;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_OPTION_DATA
    {
        public Int32 NumElements;
        public IntPtr Elements;
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct DHCP_OPTION_SCOPE_INFO {
        [FieldOffset(0)]
        public DHCP_OPTION_SCOPE_TYPE ScopeType;
        [FieldOffset(4)]
        public uint IpAddress;
        [FieldOffset(4)]
        public DHCP_RESERVED_SCOPE ReservedScopeInfo;
        [FieldOffset(4)]
        public string MScopeInfo;
        [FieldOffset(4)]
        public DHCP_OPTION_ARRAY DefaultScopeInfo;
        [FieldOffset(4)]
        public DHCP_OPTION_ARRAY GlobalScopeInfo;

    }

    public enum DHCP_OPTION_SCOPE_TYPE {
        DhcpDefaultOptions,
        DhcpGlobalOptions,
        DhcpSubnetOptions,
        DhcpReservedOptions,
        DhcpMScopeOptions
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_OPTION_ARRAY {
        public Int32 NumElements;
        public DHCP_OPTION Options;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_RESERVED_SCOPE
    {
        public uint ReservedIpAddress;
        public uint ReservedIpSubnetAddress;
    }

    [StructLayout(LayoutKind.Explicit, Size=12)]
    public struct DHCP_OPTION_DATA_ELEMENT
    {        
        [FieldOffset(0)]
        public DHCP_OPTION_DATA_TYPE OptionType;
        [FieldOffset(4)]
        public byte ByteOption;
        [FieldOffset(4)]
        public uint WordOption;
        [FieldOffset(4)]
        public UInt32 DWordOption;
        [FieldOffset(4)]
        public UInt32 DWordDWordOption;
        [FieldOffset(4)]
        public uint IpAddressOption;
        [FieldOffset(4)]
        public IntPtr StringDataOption;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_CLIENT_UID {
        public uint DataLength;
        public IntPtr Data;
        
    }
    public enum DHCP_OPTION_DATA_TYPE {
        DhcpByteOption,
        DhcpWordOption,
        DhcpDWordOption,
        DhcpDWordDWordOption,
        DhcpIpAddressOption,
        DhcpStringDataOption,
        DhcpBinaryDataOption,
        DhcpEncapsulatedDataOption,
        DhcpIpv6AddressOption
    }

    public enum DHCP_OPTION_TYPE {
        DhcpUnaryElementTypeOption,
        DhcpArrayTypeOption
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct DATE_TIME {
        public uint dwLowDateTime;
        public uint dwHighDateTime; 
        public DateTime ConvertToNonNative() {
            if (dwHighDateTime == 0 && dwLowDateTime == 0) {
                return DateTime.MinValue;
            }
            if (dwHighDateTime == int.MaxValue && dwLowDateTime == UInt32.MaxValue) {
                return DateTime.MaxValue;
            }
            return DateTime.FromFileTime((((long)dwHighDateTime) << 32) | (UInt32)dwLowDateTime);
        }

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_HOST_INFO {
        public uint IpAddress;
        public string NetBiosName;
        public string HostName;
    }

}
