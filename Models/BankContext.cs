using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Entities;

namespace BankApi.Models
{
    public class BankContext:DbContext
    {
        public BankContext(DbContextOptions<BankContext> options): base(options)
        {
        }
        public DbSet<Account> Account { get; set; } = null!;
        
    }
}