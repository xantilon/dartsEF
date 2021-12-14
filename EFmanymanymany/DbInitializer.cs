using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFmanymanymany
{
    internal class DbInitializer
    {
        internal static void Init()
        {
            using (var db = new DartsContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                if (db.Database.CanConnect())
                {
                    db.Database.Migrate();

                    if (!db.Players.Any())
                    {
                        db.Players.AddRange(new List<Player>{
                                new Player { Name = "Sepp" },
                                new Player { Name = "Hanna" },
                                new Player { Name = "Susanne" },
                                new Player { Name = "Manfred" },
                                new Player { Name = "Batman" }
                            }
                        );

                        db.SaveChanges();
                        
                        db.Games.Add(new Game
                        {
                            Positions = new List<Position>
                            {
                                new Position { Pos=1, PlayerId = db.Players.First(p=>p.Name == "Susanne").Id },
                                new Position { Pos=2, PlayerId = db.Players.First(p=>p.Name == "Hanna").Id }
                            }
                        });
                        db.SaveChanges();

                        var game1 = db.Games.First();

                        game1.Positions.Add( new Position { Pos=1, PlayerId = db.Players.First(p=>p.Name == "Susanne").Id });

                        //db.Games.Add(new Game
                        //{
                        //    Positions = new List<Position>
                        //    {
                        //        new Position { Pos = 1, Player = db.Players.First(p=>p.Name == "Sepp") },
                        //        new Position { Pos = 2, Player = db.Players.First(p=>p.Name == "Hanna") }
                        //    }
                        //});

                        //db.Games.Add(new Game
                        //{
                        //    Positions = new List<Position>
                        //    {
                        //        new Position { Pos = 1, Player = db.Players.First(p=>p.Name == "Hanna") },
                        //        new Position { Pos = 2, Player = db.Players.First(p=>p.Name == "Batman") },
                        //        new Position { Pos = 3, Player = db.Players.First(p=>p.Name == "Manfred") },
                        //        new Position { Pos = 4, Player = db.Players.First(p=>p.Name == "Sepp") }
                        //    }
                        //});

                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
