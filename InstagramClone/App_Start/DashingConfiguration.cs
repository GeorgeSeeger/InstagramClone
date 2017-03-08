using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dashing.Configuration;
using InstagramClone.Models.Domain;

namespace InstagramClone.App_Start
{
    public class DashingConfiguration : DefaultConfiguration
    {
        public DashingConfiguration() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"])
        {
            this.AddNamespaceOf<User>();
        }
    }
}