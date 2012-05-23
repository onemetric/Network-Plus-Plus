using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace NetworkPlusPlus
{
    static class Interfaces
    {

        private static List<Interface> inter = new List<Interface>();

        public static int getInterfaceCount()
        {
            if (inter != null)
            {
                return inter.Count;
            }
            else
            {
                return 0;
            }
        }

        public static Interface getInterface(int index)
        {
            return inter[index];
        }

        public static void addInterface(Interface newInterface)
        {
            inter.Add(newInterface);
        }

        public static Interface findInterfacebyName(String InterfaceName)
        {

            for (int i = 0; i < getInterfaceCount(); i++)
            {
                if (getInterface(i).Name == InterfaceName)
                {
                    return getInterface(i);
                }
            }

            return null;

        }

        public static void findInterfaces()
        {

            inter.Clear();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\%'");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                Interface tmpInterface = new Interface();

                //PropertyData pd = mgtObject.Properties;
                foreach (PropertyData pd in mgtObject.Properties)
                {

                    String keyName = pd.Name;

                    if (keyName == "NetConnectionID")
                    {

                        String interfaceName = pd.Value.ToString();
                        tmpInterface.Name = interfaceName;

                    }
                    else if (keyName == "Description")
                    {
                        String interfaceDescription = pd.Value.ToString();
                        tmpInterface.Description = interfaceDescription;
                    }
                    else if (keyName == "AdapterType")
                    {
                        if (pd.Value != null)
                        {
                            String adapterType = pd.Value.ToString();
                            tmpInterface.Type = adapterType;
                        }

                    }
                    else if (keyName == "Index")
                    {
                        UInt32 interfaceIndex = (UInt32)pd.Value;
                        tmpInterface.ID = (int)interfaceIndex;
                    }
                    else if (keyName == "MACAddress")
                    {
                        if (pd.Value != null)
                        {
                            String macAddress = pd.Value.ToString();
                            tmpInterface.MacAddress = macAddress;
                        }
                    }
                    else if (keyName == "Manufacturer")
                    {
                        String manufacturer = pd.Value.ToString();
                        tmpInterface.Manufacturer = manufacturer;
                    }
                    else if (keyName == "NetConnectionStatus")
                    {
                        UInt16 connectionStatus = (UInt16)pd.Value;
                        tmpInterface.ConnectionStatus = (int)connectionStatus;
                    }
                    else if (keyName == "NetEnabled")
                    {
                        bool enabled = (bool)pd.Value;
                        tmpInterface.Enabled = enabled;
                    }

                }

                inter.Add(tmpInterface);
            }

            //load all the additional information
            for (int i = 0; i < inter.Count; i++)
            {

                searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index=" + inter[i].ID);

                objCol = searcher.Get();
                
                foreach (ManagementObject mgtObject in objCol)
                {

                    foreach (PropertyData pd in mgtObject.Properties)
                    {

                        String keyName = pd.Name;

                        if (keyName == "DHCPEnabled")
                        {
                            bool dhcpEnabled = (bool)pd.Value;
                            inter[i].DHCPEnabled = dhcpEnabled;
                        }
                        else if (keyName == "DHCPLeaseExpires")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DHCPLeaseExpires = WMIDateTime(pd.Value.ToString());
                            }
                        }
                        else if (keyName == "DHCPLeaseObtained")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DHCPLeaseStarted = WMIDateTime(pd.Value.ToString());
                            }
                        }
                        else if (keyName == "DHCPServer")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DHCPServer = pd.Value.ToString();
                            }
                        }
                        else if (keyName == "DNSDomain")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DNSSuffix = pd.Value.ToString();
                            }
                        }
                        else if (keyName == "DNSHostName")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].Hostname = pd.Value.ToString();
                            }
                        }
                        else if (keyName == "DefaultIPGateway")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DefaultGateway = (String[])pd.Value;
                            }
                        }
                        else if (keyName == "IPAddress")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].IPAddresses = (String[])pd.Value;
                            }
                        }
                        else if (keyName == "DNSServerSearchOrder")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].DNSServers = (String[])pd.Value;
                            }
                        }
                        else if (keyName == "IPSubnet")
                        {
                            if (pd.Value != null)
                            {
                                inter[i].SubnetMasks = (String[])pd.Value;
                            }
                        }
                        else if (keyName == "IPEnabled") //XP Doesn't have NetEnabled attribute so use this instead
                        {
                            if (pd.Value != null)
                            {
                                bool enabled = (bool)pd.Value;
                                inter[i].Enabled = enabled;
                            }
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

        public static String getConnectionStatus(int statusid)
        {

            if (statusid == 0)
            {
                return "Disconnected";
            }
            else if (statusid == 1)
            {
                return "Connecting";
            }
            else if (statusid == 2)
            {
                return "Connected";
            }
            else if (statusid == 3)
            {
                return "Disconnecting";
            }
            else if (statusid == 4)
            {
                return "Hardware not present";
            }
            else if (statusid == 5)
            {
                return "Hardware disabled";
            }
            else if (statusid == 6)
            {
                return "Hardware malfunction";
            }
            else if (statusid == 7)
            {
                return "Media disconnected";
            }
            else if (statusid == 8)
            {
                return "Authenticating";
            }
            else if (statusid == 9)
            {
                return "Authentication succeeded";
            }
            else if (statusid == 10)
            {
                return "Authentication failed";
            }
            else if (statusid == 11)
            {
                return "Invalid address";
            }
            else if (statusid == 12)
            {
                return "Credentials required";
            }
            else
            {
                return "Unknown";
            }

        }

        public static void renewDHCP(Interface currInt)
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index=" + currInt.ID);
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol)
            {

                mgtObject.InvokeMethod("ReleaseDHCPLease", null);
                mgtObject.InvokeMethod("RenewDHCPLease", null);

            }

        }

    }
}
