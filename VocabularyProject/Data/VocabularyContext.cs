using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VocabularyProject.Models;

namespace VocabularyProject.Data
{
    public class VocabularyContext:DbContext
    {
        public VocabularyContext(DbContextOptions<VocabularyContext>options):base(options)
        {
            
        }
        public DbSet<Words>Words { get; set; }
        
    }
}
