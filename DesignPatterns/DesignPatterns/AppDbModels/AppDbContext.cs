﻿using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.AppDbModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }
    }
}
