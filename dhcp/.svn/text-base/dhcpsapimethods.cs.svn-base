using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace dhcp
{
    public class dhcpsapimethods {

        [DllImport("dhcpsapi.DLL", EntryPoint="DhcpEnumSubnetClients",  SetLastError=true,CharSet=CharSet.Unicode)]
        public static extern int DhcpEnumSubnetClients(
            string IpAddress,
            uint SubnetAddress,
            ref uint ResumeHandle,
            uint PreferredMaximum,
            out IntPtr ClientInfo,
            out uint ClientsRead,
            out uint ClientsTotal);
        [DllImport("dhcpsapi.DLL", EntryPoint = "DhcpCreateClientInfo", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DhcpCreateClientInfo(
            string IpAddress,
            ref DHCP_CLIENT_INFO ClientInfo);
        [DllImport("dhcpsapi.DLL", EntryPoint = "DhcpCreateOption", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DhcpCreateOption(
            string IpAddress,
            uint OptionID,
            ref DHCP_OPTION OptionInfo);

        [DllImport("dhcpsapi.DLL", EntryPoint = "DhcpSetOptionValue", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DhcpSetOptionValue(
            string IpAddress,
            uint OptionID,
            ref DHCP_OPTION_SCOPE_INFO ScopeInfo,
            ref DHCP_OPTION_DATA OptionData);

    }
}
