﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InstruktorerPassMVC.Models;

namespace InstruktorerPassMVC.Data
{
    public class Context : DbContext 
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Instruktorer> Instruktorer { get; set; }
        public DbSet<InstruktorerPass> InstruktorerPass { get; set; }
        public DbSet<Pass> Pass { get; set; }
    }
}
