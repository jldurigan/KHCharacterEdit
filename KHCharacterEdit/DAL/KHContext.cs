using KHCharacterEdit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.DAL
{
    public class KHContext : DbContext
    {
        public KHContext(): base("KHContext")
        {
        }

        //Especifica quais tabelas serão relacionadas
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Remove a configuração que cria as tabelas com nomes no plural por padrão
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Remove a configuração que faz com que tabelas com relação um-para-muitos façam exclusões em cascata
        }
    }
}