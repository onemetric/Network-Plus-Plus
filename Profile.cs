using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkPlusPlus
{

    class Profile
    {
    
        private String strName = "";
        private String strIP = "";
        private String strSubnet = "";
        private String strGateway = "";
        private String strPrimaryDNS = "";
        private String strSecondaryDNS = "";

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

        public String IP
        {
            get
            {
                return strIP;
            }
            set
            {
                strIP = value;
            }
        }

        public String Subnet
        {
            get
            {
                return strSubnet;
            }
            set
            {
                strSubnet = value;
            }
        }

        public String Gateway
        {
            get
            {
                return strGateway;
            }
            set
            {
                strGateway = value;
            }
        }

        public String PrimaryDNS
        {
            get
            {
                return strPrimaryDNS;
            }
            set
            {
                strPrimaryDNS = value;
            }
        }

        public String SecondaryDNS
        {
            get
            {
                return strSecondaryDNS;
            }
            set
            {
                strSecondaryDNS = value;
            }
        }
    
    }
}
