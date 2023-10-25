using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookFPTShop.Models;

    public class FPTDBTContext : DbContext
    {
        public FPTDBTContext (DbContextOptions<FPTDBTContext> options)
            : base(options)
        {
        }

        public DbSet<BookFPTShop.Models.Book> Book { get; set; } = default!;

        public DbSet<BookFPTShop.Models.Category>? Category { get; set; }
    }
