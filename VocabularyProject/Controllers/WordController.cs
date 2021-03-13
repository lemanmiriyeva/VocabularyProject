using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VocabularyProject.Data;
using VocabularyProject.Models;

namespace VocabularyProject.Controllers
{
    public class WordController : Controller
    {
        private readonly VocabularyContext _context;

        public WordController(VocabularyContext context)
        {
            _context = context;
        }

        public IActionResult List(string key)
        {
            
            if (key==null)
            {
                key = "";
            }
            var words = from m in _context.Words where m.InEnglish.Contains(key)||m.InAzerbaijan.Contains(key)
                select m;
            string sortType = HttpContext.Request.Query["sortType"];
            if (sortType== "AzerbaijanAtoZ")
            {
                words = words.OrderBy(w => w.InAzerbaijan);
            }
            else if (sortType== "AzerbaijanZtoA")
            {
                words = words.OrderBy(w => w.InAzerbaijan).Reverse();
            }
            else if (sortType== "EnglishAtoZ")
            {
                words = words.OrderBy(w => w.InEnglish);
            }
            else if (sortType== "EnglishZtoA")
            {
                words = words.OrderBy(w => w.InEnglish).Reverse();
            }
            else if (sortType== "date")
            {
                words = words.OrderBy(w => w.AddedTime);
            }
            var model=new WordListViewModel()
            {
                Words = words.ToList()
            };
            return View(model);
            
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AddWord(Words obj)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.Id==0)
                    {
                        obj.AddedTime = DateTime.Now;
                        await _context.Words.AddAsync(obj);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("List");
                }
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("List");
            }
        }

        public async Task<IActionResult> DeleteWord(int id)
        {
                var word =await  _context.Words.FindAsync(id);
             
                    _context.Words.Remove(word);
                    await _context.SaveChangesAsync();
               return RedirectToAction("List");


        }

      
        
    }
}
