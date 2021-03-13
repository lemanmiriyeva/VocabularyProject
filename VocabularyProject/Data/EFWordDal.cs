using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VocabularyProject.Data.Abstract;

namespace VocabularyProject.Data
{
    public class EfWordDal:IWordDal
    {
        private VocabularyContext _context;

        public List<Words> GetByName(string key)
        {
            return _context.Words.Where(p => p.InAzerbaijan.Contains(key)||p.InEnglish.Contains(key)).ToList();
        }

        public List<Words> GetAll(Expression<Func<Words, bool>> filter)
        {
            return filter == null ? _context.Words.ToList() : _context.Words.Where(filter).ToList();
        }

    }
}

