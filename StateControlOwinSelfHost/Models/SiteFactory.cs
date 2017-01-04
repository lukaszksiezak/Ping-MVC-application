using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Security;
using System.Web.Hosting;

namespace StateControl.Models
{
    public class SiteFactory
    {
        private int sitesCount;
       
        public SiteFactory()
        {
            sitesCount = 0;
            string path = HostingEnvironment.MapPath("/Devices.xml");
            ReadXml(path);
        }

        public SiteFactory(string path)
        {
            sitesCount = 0;
            ReadXml(path);
        }
        private List<Site> sitesList = new List<Site>();

        public List<Site> SitesList 
        { 
            get 
            {
                return this.sitesList;
            }
        }

        private Site GenerateSite(string ip, string description)
        {
            if (ip != null && ip != String.Empty)
            {
                var _site = new Site(sitesCount.ToString(), ip, description);
                sitesCount++;
                return _site;
            }
            else
            {
                throw new Exception("Ip not defined or in bad format");
            }
        }

        private void ReadXml(string path)
        {
            try
            {
                using (var xmlReader = XmlReader.Create(path))
                {
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Device"))
                        {
                            xmlReader.ReadToFollowing("Ip");
                            string ip = xmlReader.ReadElementContentAsString();
                            xmlReader.ReadToFollowing("Description");
                            string description = xmlReader.ReadElementContentAsString();

                            sitesList.Add(GenerateSite(ip, description));
                        }
                    }
                }
            }
            catch (SecurityException ex)
            {
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}