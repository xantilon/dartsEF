using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFmanymanymany
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitializer.Init();

            using (var db = new DartsContext())
            {
                var games = db.Games.Include(g=>g.Positions).ThenInclude(p=>p.Player).ToList();

                foreach (var g in games)
                {
                    string vs = ", ";
                    if(!g.Positions.Any())
                    {
                        Console.WriteLine($@"Game{g.Id} has no players yet");
                        continue;
                    }
                    
                    string pos = string.Join(vs, g.Positions.Select(p => $@"{p.Pos}. {p.Player.Name}"));
                    Console.WriteLine($@"Game{g.Id}: {pos}");
                }
            }
        }
    }
}
