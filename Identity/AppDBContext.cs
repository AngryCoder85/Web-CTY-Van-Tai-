using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CTY_DVVT.Identity
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext() : base("DVVTConnectionString") {}
    }
}