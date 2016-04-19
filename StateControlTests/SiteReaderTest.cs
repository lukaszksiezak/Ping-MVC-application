using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateControl;
using StateControl.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace StateControlTests
{
    [TestClass]
    public class SiteReaderTest
    {
        [TestMethod]
        public void StateControl_ShouldReturnOnline()
        {
            string address = "www.google.pl";
            Site sampleWebsite = new Site("1", address);

            Assert.IsNotNull(sampleWebsite.SiteAddress);
            Assert.AreEqual<ServerStatus>(sampleWebsite.SiteStatus, ServerStatus.Online);
        }

        [TestMethod]
        public void StateControl_ShouldReturnOffline()
        {
            string address = "192.168.10.10";
            Site sampleWebsite = new Site("1", address);

            Assert.IsNotNull(sampleWebsite.SiteAddress);
            Assert.AreEqual<ServerStatus>(sampleWebsite.SiteStatus, ServerStatus.Offline);
        }
    }
}
