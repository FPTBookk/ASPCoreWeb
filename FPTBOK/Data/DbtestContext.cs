using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FPTBOK.Models;

    public class DbtestContext : DbContext
    {
        public DbtestContext (DbContextOptions<DbtestContext> options)
            : base(options)
        {
        }

        public DbSet<FPTBOK.Models.Category> Category { get; set; } = default!;
    }
