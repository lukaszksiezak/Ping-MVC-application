using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
namespace StateControl.Models
{
    public class Site
    {
        private Uri siteAddress;
        private string description;
        private string idName;
        private ServerStatus siteStatus;

        public Site(string name, string url, string descr="")
        {
            try
            {
                this.idName = name;
                this.siteAddress = new UriBuilder(url).Uri;

                if (descr != String.Empty)
                {
                    this.description = descr;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public string IdName
        {
            get
            {
                return this.idName;
            }
        }
        public string SiteAddress
        {
            get
            {
                return this.siteAddress.ToString();
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public ServerStatus SiteStatus
        {
            get
            {
                this.siteStatus = GetServerStatus();
                return this.siteStatus;
            }
        }

        private ServerStatus GetServerStatus()
        {
            using (var ping = new Ping())
            {
                try
                {
                    var pingReply = ping.Send(siteAddress.Host,1500);

                    if (pingReply.Status.Equals(IPStatus.Success))
                    {
                        return ServerStatus.Online;
                    }
                    else
                    {
                        return ServerStatus.Offline;
                    }
                }
                catch
                {
                    return ServerStatus.Offline;
                }

            }
        }

        public void UpdateSiteStatus()
        {
            this.siteStatus = GetServerStatus();
        }

    }

    public enum ServerStatus
    {
        Online,
        Offline,
        Warning,
        Fault
    }
}