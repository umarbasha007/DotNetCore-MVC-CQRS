
using ExamPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPortal.Data.Common
{
    public class ExamPortalContext : DbContext
    {

        public ExamPortalContext()
        {
        }
        public ExamPortalContext(DbContextOptions<ExamPortalContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnection = string.Empty;

            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();


            if (Environment.GetEnvironmentVariable("Environment") == "dev")
            {
                if (!string.IsNullOrEmpty(config.GetValue<string>("ConnectionStrings:DefaultConnectionDev")))
                {
                    dbConnection = config.GetValue<string>("ConnectionStrings:DefaultConnectionDev");
                }
            }
            else if (Environment.GetEnvironmentVariable("Environment") == "stage")
            {
                if (!string.IsNullOrEmpty(config.GetValue<string>("ConnectionStrings:DefaultConnectionStage")))
                {
                    dbConnection = config.GetValue<string>("ConnectionStrings:DefaultConnectionStage");
                }
            }
            else if (Environment.GetEnvironmentVariable("Environment") == "prod")
            {
                if (!string.IsNullOrEmpty(config.GetValue<string>("ConnectionStrings:DefaultConnectionProd")))
                {
                    dbConnection = config.GetValue<string>("ConnectionStrings:DefaultConnectionProd");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(config.GetValue<string>("ConnectionStrings:DefaultConnection")))
                {
                    dbConnection = config.GetValue<string>("ConnectionStrings:DefaultConnection");
                }
            }
            //dbConnection = config.GetValue<string>("ConnectionStrings:DefaultConnectionDev");
            //optionsBuilder.UseNpgsql(dbConnection); //pgSQL DB
            optionsBuilder.UseSqlServer(dbConnection); //SQL Server DB
        }

      
        public DbSet<Users> Users { get; set; }
        /*
        public DbSet<QAns> QAns { get; set; }
        */
    }


}
