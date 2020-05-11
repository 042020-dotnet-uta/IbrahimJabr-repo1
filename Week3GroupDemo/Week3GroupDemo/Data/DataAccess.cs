using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week3GroupDemo.Data;
using Week3GroupDemo.Models;

namespace Week3GroupDemo.Data
{
    public  class DataAccess
    {
        private  readonly MvcGameContext DB ;

        public  DataAccess(MvcGameContext context)
        {
            DB = context;
        }

        

        public async  Task<List<Game>> gitIndex()
        {
           var d = await DB.Game.ToListAsync();
            return d;
        }

        public  Game getGameD(int? id)
        {
            var game = DB.Game.Include(r => r.Rating)
                .FirstOrDefault(m => m.Id == id);
        
            return game;
        }

        /*public static void creatGame(Game g)
        {
            g.Rating = DB.Rating.Where(r => r.Rating == g.Rating.Rating).FirstOrDefault();
            if (ModelState.IsValid)
            {
                DB.Add(game);
                DB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }*/
    }
}
