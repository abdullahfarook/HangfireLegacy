﻿using System.Data.Entity.Migrations;
using HangFireLegacy.Data;

namespace HangFireLegacy.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HangFireLegacyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HangFireLegacyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
