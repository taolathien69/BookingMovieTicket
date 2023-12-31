namespace RapChieuPhim.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RapChieuPhim.Models.DBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
