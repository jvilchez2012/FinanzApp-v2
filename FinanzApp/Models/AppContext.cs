using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzApp.Models
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        { 
        
        }
    }
}
