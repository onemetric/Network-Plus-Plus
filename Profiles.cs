using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace NetworkPlusPlus
{
    static class Profiles
    {

        private static List<Profile> prfs = new List<Profile>();

        public static int getProfileCount()
        {
            if (prfs != null)
            {
                return prfs.Count;
            }
            else
            {
                return 0;
            }
        }

        public static Profile getProfile(int index)
        {
            return prfs[index];
        }

        public static void addProfile(Profile prfl)
        {
            prfs.Add(prfl);
        }

        public static Profile findProfilebyName(String ProfileName)
        {

            for (int i = 0; i < getProfileCount(); i++)
            {

                if (getProfile(i).Name == ProfileName)
                {
                    return getProfile(i);
                }

            }

            return null;

        }

        public static void removeProfile(String ProfileName)
        {
            
            for (int i = 0; i < getProfileCount(); i++)
            {

                if (prfs[i].Name == ProfileName)
                {
                    prfs.Remove(prfs[i]);
                }

            }

        }

        public static void saveProfiles()
        {

            string configFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkPlusPlus", "config.xml");
            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(configFile);
            writer.WriteStartDocument();

            writer.WriteStartElement("Profiles");

            for (int i = 0; i < getProfileCount(); i++)
            {

                writer.WriteStartElement("Profile");
                writer.WriteElementString("Name", getProfile(i).Name);
                writer.WriteElementString("IPAddress", getProfile(i).IP);
                writer.WriteElementString("Subnet", getProfile(i).Subnet);
                writer.WriteElementString("Gateway", getProfile(i).Gateway);
                writer.WriteElementString("PrimaryDNS", getProfile(i).PrimaryDNS);
                writer.WriteElementString("SecondaryDNS", getProfile(i).SecondaryDNS);
                writer.WriteEndElement();

            }
            
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

        }

    }
}
