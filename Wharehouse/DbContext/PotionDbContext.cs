using Microsoft.EntityFrameworkCore.Design;
using PotionMerchant.Entity;

namespace Catalog.DbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    public class PotionDbContext :DbContext
    {
        private static string _connStr = @"
                   Server=127.0.0.1,1434;
                   Database=PotionDatabase;
                   User Id=SA;
                   Password=PierPaolo:)
                ";
        
        public DbSet<Potion> Potions { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingrediant> Ingrediants { get; set; }
        
        
        public PotionDbContext() : base(_connStr)
        {
            Database.SetInitializer<PotionDbContext>(new CreateDatabaseIfNotExists<PotionDbContext>());

        }
    }
}