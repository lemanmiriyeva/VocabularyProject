using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VocabularyProject.Data.Abstract
{
    public interface IWordDal
    {
        public List<Words> GetByName(string key);
        public List<Words> GetAll(Expression<Func<Words,bool>>filter);
        
    }
}
