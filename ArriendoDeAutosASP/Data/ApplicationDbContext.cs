using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendoDeAutosASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Bill> Bill { get; set; }
    }
}
