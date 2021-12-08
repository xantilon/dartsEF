using System;
using System.Collections.Generic;
using System.Linq;

namespace EFmanymanymany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var db = new DartsContext())
            {
                db.Players.AddRange(new List<Player>{
                            new Player { Name = "Sepp" },
                            new Player { Name = "Hanna" },
                            new Player { Name="Susanne"}
                        }
                    );

                db.SaveChanges();
                db.Games.Add(new Game
                {
                    Positions = new List<Position>
                    {
                        new Position { Pos=1, Player = db.Players.First(p=>p.Name == "Susanne") },
                        new Position { Pos=2, Player = db.Players.First(p=>p.Name == "Hanna") }
                    }
                });

                db.Games.Add(new Game
                {
                    Positions = new List<Position>
                    {
                        new Position { Pos = 1, Player = db.Players.First(p=>p.Name == "Sepp") },
                        new Position { Pos = 2, Player = db.Players.First(p=>p.Name == "Hanna") }
                    }
                });


                db.SaveChanges();
            }
        }
    }
}
