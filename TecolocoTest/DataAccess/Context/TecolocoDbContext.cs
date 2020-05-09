using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class TecolocoDbContext: DbContext
    {

        public TecolocoDbContext(DbContextOptions<TecolocoDbContext> options) : base(options)
        {

        }

        public DbSet<Jobs> Jobs { get; set; }
 
    }
}
