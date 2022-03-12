using DomainClassModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProjectContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
    }
}
