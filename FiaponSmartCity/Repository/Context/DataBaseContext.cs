﻿using FiapSmartCity.Models;
using Microsoft.EntityFrameworkCore;


namespace FiapSmartCity.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        //public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        //public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaEF> PessoaEF { get; set; }
        public DbSet<TipoProdutoEF> TipoProdutoEF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}