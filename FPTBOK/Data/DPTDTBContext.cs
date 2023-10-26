using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FPTBOK.Models;

    public class DPTDTBContext : DbContext
    {
        public DPTDTBContext (DbContextOptions<DPTDTBContext> options)
            : base(options)
        {
        }

        public DbSet<FPTBOK.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
