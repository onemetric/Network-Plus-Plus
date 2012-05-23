using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace NetworkPlusPlus
{

    class Interface
    {

        private int intID;
        private String strName;
        private String strDescription;
        private String strType;
        private String strMac;
        private String strManufacturer;
        private int intConnectionStatus;
        private bool blEnabled;
        private bool blDHCPEnabled;
        private DateTime dtDHCPLeaseExpires;
        private DateTime dtDHCPLeaseStarted;
        private String strDHCPServer;
        private String strDNSSuffix;
        private String strHostname;
        private String[] strDefaultGateway;
        private String[] strIPAddresses;
        private String[] strSubnetMasks;
        private String[] strDNSServers;

        public int ID
        {
            get
            {
                return intID;
            }
            set
            {
                intID = value;
            }
        }

        public String[] SubnetMasks
        {
            get
            {
                return strSubnetMasks;
            }
            set
            {
                strSubnetMasks = value;
            }
        }

        public String[] IPAddresses
        {
            get
            {
                return strIPAddresses;
            }
            set
            {
                strIPAddresses = value;
            }
        }

        public String[] DNSServers
        {
            get
            {
                return strDNSServers;
            }
            set
            {
                strDNSServers = value;
            }
        }

        public String[] DefaultGateway
        {
            get
            {
                return strDefaultGateway;
            }
            set
            {
                strDefaultGateway = value;
            }
        }

        public String DNSSuffix
        {
            get
            {
                return strDNSSuffix;
            }
            set
            {
                strDNSSuffix = value;
            }
        }

        public String Hostname
        {
            get
            {
                return strHostname;
            }
            set
            {
                strHostname = value;
            }
        }

        public String DHCPServer
        {
            get
            {
                return strDHCPServer;
            }
            set
            {
                strDHCPServer = value;
            }
        }

        public DateTime DHCPLeaseStarted
        {
            get
            {
                return dtDHCPLeaseStarted;
            }
            set
            {
                dtDHCPLeaseStarted = value;
            }
        }

        public DateTime DHCPLeaseExpires
        {
            get
            {
                return dtDHCPLeaseExpires;
            }
            set
            {
                dtDHCPLeaseExpires = value;
            }
        }

        public bool DHCPEnabled
        {
            get
            {
                return blDHCPEnabled;
            }
            set
            {
                blDHCPEnabled = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return blEnabled;
            }
            set
            {
                blEnabled = value;
            }
        }

        public int ConnectionStatus
        {
            get
            {
                return intConnectionStatus;
            }
            set
            {
                intConnectionStatus = value;
            }
        }
            

        public String Manufacturer
        {
            get
            {
                return strManufacturer;
            }
            set
            {
                strManufacturer = value;
            }
        }

        public String MacAddress
        {
            get
            {
                return strMac;
            }
            set
            {
                strMac = value;
            }
        }

        public String Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }

        public String Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }

        public String Type
        {
            get
            {
                return strType;
            }
            set
            {
                strType = value;
            }
        }

        public void applyProfile(Profile selectedProfile)
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index=" + intID);
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                if (selectedProfile.IP != "")
                {

                    object[] IPs = { selectedProfile.IP };
                    object[] Subnets = { selectedProfile.Subnet };
                    object[] methodArgs = { IPs, Subnets };

                    object[] GatewayIPs = { selectedProfile.Gateway };
                    object[] Metrics = { "1" };
                    object[] gatewayArgs = { GatewayIPs, Metrics };

                    object returnVal = mgtObject.InvokeMethod("EnableStatic", methodArgs);
                    object returnVal2 = mgtObject.InvokeMethod("SetGateways", gatewayArgs);

                }
                else
                {
                    mgtObject.InvokeMethod("EnableDHCP", null);
                }

                if (selectedProfile.PrimaryDNS == "" && selectedProfile.SecondaryDNS == "")
                {
                    object returnVal3 = mgtObject.InvokeMethod("SetDNSServerSearchOrder", null);
                }
                else
                {
                    object[] DNSServers = { selectedProfile.PrimaryDNS, selectedProfile.SecondaryDNS };
                    object[] DNS = { DNSServers };
                    object returnVal3 = mgtObject.InvokeMethod("SetDNSServerSearchOrder", DNS);
                }
                
            }
            
        }

        public void disableInterface()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapter WHERE Index=" + intID);
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {
                
                object returnVal = mgtObject.InvokeMethod("Disable", null);

            }

        }

        public void enableInterface()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapter WHERE Index=" + intID);
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                object returnVal = mgtObject.InvokeMethod("Enable", null);
                
            }

        }

        public void reloadInterface()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapter WHERE Index=" + intID);
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                //PropertyData pd = mgtObject.Properties;
                foreach (PropertyData pd in mgtObject.Properties)
                {

                    String keyName = pd.Name;

                    if (pd.Value != null)
                    {

                        if (keyName == "NetConnectionID")
                        {

                            String interfaceName = pd.Value.ToString();
                            strName = interfaceName;

                        }
                        else if (keyName == "Description")
                        {
                            String interfaceDescription = pd.Value.ToString();
                            strDescription = interfaceDescription;
                        }
                        else if (keyName == "AdapterType")
                        {
                            String adapterType = pd.Value.ToString();
                            strType = adapterType;

                        }
                        else if (keyName == "MACAddress")
                        {
                            String macAddress = pd.Value.ToString();
                            strMac = macAddress;
                        }
                        else if (keyName == "Manufacturer")
                        {
                            String manufacturer = pd.Value.ToString();
                            strManufacturer = manufacturer;
                        }
                        else if (keyName == "NetConnectionStatus")
                        {
                            UInt16 connectionStatus = (UInt16)pd.Value;
                            intConnectionStatus = (int)connectionStatus;
                        }
                        else if (keyName == "NetEnabled")
                        {
                            bool enabled = (bool)pd.Value;
                            blEnabled = enabled;
                        }
                        
                    }

                }

            }

            searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index=" + intID);
            objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                foreach (PropertyData pd in mgtObject.Properties)
                {

                    String keyName = pd.Name;

                    if (keyName == "DHCPEnabled")
                    {
                        bool dhcpEnabled = (bool)pd.Value;
                        blDHCPEnabled = dhcpEnabled;
                    }
                    else if (keyName == "DHCPLeaseExpires")
                    {
                        if (pd.Value != null)
                        {
                            dtDHCPLeaseExpires = WMIDateTime(pd.Value.ToString());
                        }
                    }
                    else if (keyName == "DHCPLeaseObtained")
                    {
                        if (pd.Value != null)
                        {
                            dtDHCPLeaseStarted = WMIDateTime(pd.Value.ToString());
                        }
                    }
                    else if (keyName == "DHCPServer")
                    {
                        if (pd.Value != null)
                        {
                            strDHCPServer = pd.Value.ToString();
                        }
                    }
                    else if (keyName == "DNSDomain")
                    {
                        if (pd.Value != null)
                        {
                            strDNSSuffix = pd.Value.ToString();
                        }
                    }
                    else if (keyName == "DNSHostName")
                    {
                        if (pd.Value != null)
                        {
                            strHostname = pd.Value.ToString();
                        }
                    }
                    else if (keyName == "DefaultIPGateway")
                    {
                        if (pd.Value != null)
                        {
                            strDefaultGateway = (String[])pd.Value;
                        }
                    }
                    else if (keyName == "IPAddress")
                    {
                        if (pd.Value != null)
                        {
                            strIPAddresses = (String[])pd.Value;
                        }
                    }
                    else if (keyName == "DNSServerSearchOrder")
                    {
                        if (pd.Value != null)
                        {
                            strDNSServers = (String[])pd.Value;
                        }
                    }
                    else if (keyName == "IPSubnet")
                    {
                        if (pd.Value != null)
                        {
                            strSubnetMasks = (String[])pd.Value;
                        }
                    }

                }

            }

        }

        private static DateTime WMIDateTime(String s)
        {

            int year = int.Parse(s.Substring(0, 4));
            int month = int.Parse(s.Substring(4, 2));
            int day = int.Parse(s.Substring(6, 2));
            int hour = int.Parse(s.Substring(8, 2));
            int minute = int.Parse(s.Substring(10, 2));
            int second = int.Parse(s.Substring(12, 2));
            return new DateTime(year, month, day, hour, minute, second);

        }

    }
}
