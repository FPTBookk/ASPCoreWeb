using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FPTBOK.Models;

    public class FPTDBTContext : DbContext
    {
        public FPTDBTContext (DbContextOptions<FPTDBTContext> options)
            : base(options)
        {
        }

        public DbSet<FPTBOK.Models.Cart> Cart { get; set; } = default!;
    }
