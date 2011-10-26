using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Globalization;

namespace dhcp
{
    

    public class DhcpClient
    {
        
        private string _clientIpAddress;
        private string _subnetMask;
        private string _clientHardwareAddress;
        private string _clientName;
        private string _clientComment;
        private DateTime _clientLeaseExpires;
        private OWNER_HOST _ownerHost = new OWNER_HOST();
        

        public class OWNER_HOST{
            private string _ipAddress;
            private string _netbiosName;
            private string _hostname;

            #region Constructors
            public OWNER_HOST(){}
            #endregion
            #region Properties
            public string IpAddress {
                get { return _ipAddress; }
                set { _ipAddress = value; }
            }
            public string NetBiosName {
                get { return _netbiosName; }
                set { _netbiosName = value; }
            }
            public string HostName {
                get { return _hostname; }
                set { _hostname = value; }
            }
            #endregion
        }
        #region Constructors
        public DhcpClient()
        {
        }
        #endregion
        #region Properties
        public string ClientIpAddress
        {
            get { return _clientIpAddress; }
            set { _clientIpAddress = value; }
        }
        public string SubnetMask
        {
            get { return _subnetMask; }
            set { _subnetMask = value; }
        }
        public string ClientHardwareAddress
        {
            get { return _clientHardwareAddress; }
            set { _clientHardwareAddress = value; }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public string ClientComment
        {
            get { return _clientComment; }
            set { _clientComment = value; }
        }
        public DateTime ClientLeaseExpires
        {
            get { return _clientLeaseExpires; }
            set { _clientLeaseExpires = value; }
        }
        public OWNER_HOST OwnerHost
        {
            get { return _ownerHost; }
            set { _ownerHost = value; }
        }
        #endregion



        public static List<DhcpClient> DhcpEnumSubnetClients(string IpAddress, string subnetMask)  {
            DHCP_CLIENT_INFO_ARRAY nativeClientArray;
            DHCP_CLIENT_INFO nativeClient;
            uint PreferredMaximum = 65536, ResumeHandle = 0, ClientsRead = 0, ClientsTotal = 0;
            IntPtr ClientInfo, client;
            List<DhcpClient> dhcpclientslist = new List<DhcpClient>();
            uint SubnetMask = StringToUint(subnetMask);
            int Error = dhcpsapimethods.DhcpEnumSubnetClients(IpAddress, SubnetMask, ref ResumeHandle, PreferredMaximum, out ClientInfo, out ClientsRead, out ClientsTotal);
            if (Error != 0)
                return dhcpclientslist;
            nativeClientArray = (DHCP_CLIENT_INFO_ARRAY)Marshal.PtrToStructure(ClientInfo, typeof(DHCP_CLIENT_INFO_ARRAY));
            client = nativeClientArray.Clients;
            for (int i = 0; i < (int)nativeClientArray.NumElements; i++) {
                nativeClient = (DHCP_CLIENT_INFO)Marshal.PtrToStructure(Marshal.ReadIntPtr(client), typeof(DHCP_CLIENT_INFO));
                DhcpClient dhcpclient = new DhcpClient();
                dhcpclient.ClientComment = nativeClient.ClientComment;
                dhcpclient.ClientHardwareAddress = ByteToString(nativeClient.ClientHardwareAddress);
                dhcpclient.ClientIpAddress = UintToString(nativeClient.ClientIpAddress);
                dhcpclient.ClientLeaseExpires = nativeClient.ClientLeaseExpires.ConvertToNonNative();
                dhcpclient.ClientName = nativeClient.ClientName;
                dhcpclientslist.Add(dhcpclient);
                client = (IntPtr)((int)client + (int)Marshal.SizeOf(typeof(IntPtr)));
            }            
            return dhcpclientslist;
        }

        public static void DhcpCreateClientInfo(string ServerIpAddress, DhcpClient dhcpClient) {
            DHCP_CLIENT_INFO clientInfo = ConvertClientInfoToNative(dhcpClient);
            int error = dhcpsapimethods.DhcpCreateClientInfo(ServerIpAddress, ref clientInfo);
            if (error != 0) {
                Console.WriteLine(error);
                Console.ReadLine();
            }
        }



        public static DHCP_CLIENT_INFO ConvertClientInfoToNative(DhcpClient client) {
            DHCP_CLIENT_INFO ClientInfo = new DHCP_CLIENT_INFO();
            ClientInfo.ClientIpAddress = StringToUint(client.ClientIpAddress);
            ClientInfo.SubnetMask = StringToUint(client.SubnetMask);
            ClientInfo.ClientHardwareAddress = ConverToNativeMac(client.ClientHardwareAddress);
            ClientInfo.ClientName = client.ClientName;
            ClientInfo.ClientComment = client.ClientComment;
            ClientInfo.ClientLeaseExpires = ConvertDateTimeToNative(client);
            DHCP_HOST_INFO host = new DHCP_HOST_INFO();
            host.HostName = client.OwnerHost.HostName;
            host.IpAddress = StringToUint(client.OwnerHost.IpAddress);
            host.NetBiosName = client.OwnerHost.NetBiosName;
            ClientInfo.OwnerHost = host;
            return ClientInfo;
        }

        public static DATE_TIME ConvertDateTimeToNative(DhcpClient client) {
            DATE_TIME dTime = new DATE_TIME();
            dTime.dwHighDateTime = (uint)(client.ClientLeaseExpires.ToFileTime() >> 32);
            dTime.dwLowDateTime = (uint)(client.ClientLeaseExpires.ToFileTime() + 0xFFFFFFFF);
            return dTime;
        }

        public static DHCP_CLIENT_UID ConverToNativeMac(string mac) { 
            DHCP_CLIENT_UID nativeMac = new DHCP_CLIENT_UID();
            nativeMac.Data = MacPtr(StringToByteArray(mac));
            nativeMac.DataLength = (uint)mac.Length / 2;
            return nativeMac;
        }

        public static IntPtr MacPtr(byte[] macBytes) {
            IntPtr macPtr = Marshal.AllocHGlobal(macBytes.Length);
            Marshal.Copy(macBytes, 0, macPtr, macBytes.Length);
            return macPtr;
        }

        public static byte[] StringToByteArray(string stringByte) {
            // Convert MAC address to Hex bytes
            long value = long.Parse(stringByte, NumberStyles.HexNumber, CultureInfo.CurrentCulture.NumberFormat);
            byte[] macBytes = BitConverter.GetBytes(value);
            Array.Reverse(macBytes);
            byte[] macAddress = new byte[6];
            int j = 0;
            for (int i = 0; i <= 5; i++)
                macAddress[i] = macBytes[j++ + 2];
            return macAddress;
        }

        public static string ByteToString(DHCP_CLIENT_UID mac) {
            string macAddress = String.Format("{0:x2}-{1:x2}-{2:x2}-{3:x2}-{4:x2}-{5:x2}",
                                    Marshal.ReadByte(mac.Data),
                                    Marshal.ReadByte(mac.Data, 1),
                                    Marshal.ReadByte(mac.Data, 2),
                                    Marshal.ReadByte(mac.Data, 3),
                                    Marshal.ReadByte(mac.Data, 4),
                                    Marshal.ReadByte(mac.Data, 5));
            return macAddress;

        }

        public static uint StringToUint(string ip) {
            IPAddress ipAddress = IPAddress.Parse(ip);
            byte[] ipAddByte = ipAddress.GetAddressBytes();
            uint ipuiunt = (uint)(ipAddByte[0] << 24) + (uint)(ipAddByte[1] << 16) + (uint)(ipAddByte[2] << 8) + (uint)(ipAddByte[3]);
            return ipuiunt;
        }


        public static string UintToString(uint ip) {
            IPAddress ipAddr = new IPAddress(ip);
            byte[] ipMinusByte = ipAddr.GetAddressBytes();
            string ipAddress = ipMinusByte[3].ToString() + "." + ipMinusByte[2].ToString() + "." + ipMinusByte[1].ToString() + "." + ipMinusByte[0].ToString();
            return ipAddress;
        
        }

        
    }
    

   
}
