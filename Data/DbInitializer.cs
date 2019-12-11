using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QinMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Data
{
    public class DbInitializer
    {
        public  static void Initialize(QMContext context)
        {
            //context.Database.Migrate();
            context.Database.EnsureCreated();

            // populate the officers
            if (!context.Officers.Any())
            {
                Officer[] officers = new Officer[]
                {
                    new Officer {FirstName = "Shin", LastName = "", Rank = "5000-Man Commander", Years = 9, Status = "Alive"},
                    new Officer {FirstName = "Hon", LastName = "Ou", Rank = "5000-Man Commander", Years = 9, Status = "Alive"},
                    new Officer {FirstName = "Ten", LastName = "Mou", Rank = "5000-Man Commander", Years = 9, Status = "Alive"},
                    new Officer {FirstName = "Renka", LastName = "Shou", Rank = "5000-Man Commander", Years = 9, Status = "Alive"},
                    new Officer {FirstName = "Bi", LastName = "Kaku", Rank = "1000-Man Commander", Years = 9, Status = "Deceased"}
                };
                foreach (Officer o in officers)
                {
                    context.Officers.Add(o);
                }
            }
            context.SaveChanges();

            // populate the units
            if (!context.Units.Any())
            {
                Unit[] units = new Unit[]
                {
                    new Unit{Name = "Hi SHin Unit", Numbers = 8000, OfficerID = 1},
                    new Unit{Name = "Gyoku Hou Unit",Numbers = 5000, OfficerID = 2},
                    new Unit{Name = "Gaku Ka Unit", Numbers = 5000, OfficerID = 3},
                    new Unit{Name = "Sou Ou Unit",Numbers = 5000, OfficerID = 4},
                    new Unit{Name = "Kaku Bi Unit", Numbers = 1000, OfficerID = 5}
                };
                foreach (Unit u in units)
                {
                    context.Units.Add(u);
                }

            }
            context.SaveChanges();

            // Populate the soldiers
            if (!context.Soldiers.Any())
            {
                Soldier[] soldiers = new Soldier[]
                {
                    new Soldier {LastName = "", FirstName = "Kei", Age = 28, Birthplace = "Jyouto Village", Status = "Alive", UnitID = 1},
                    new Soldier{LastName = "", FirstName = "Kou", Age = 23, Birthplace = "Jyouto Village", Status = "Alive", UnitID = 1},
                    new Soldier{LastName = "Sou", FirstName = "Man", Age = 27, Birthplace = "?", Status = "Alive", UnitID = 2},
                    new Soldier{LastName = "Ro", FirstName = "Han", Age = 26, Birthplace = "?", Status = "Alive", UnitID = 2},
                    new Soldier{LastName = "", FirstName = "Sou'an", Age = 28, Birthplace = "?", Status = "Alive", UnitID = 2},
                    new Soldier{LastName = "Kou", FirstName = "Moku", Age = 33, Birthplace = "?", Status = "Alive", UnitID = 3},
                    new Soldier{LastName = "Go", FirstName = "Ei", Age = 28, Birthplace = "?", Status = "Deceased", UnitID = 3},
                    new Soldier{LastName = "Kai", FirstName = "Gen", Age = 26, Birthplace = "?", Status = "Deceased", UnitID = 3},
                    new Soldier{LastName = "Bai", FirstName = "Da", Age = 32, Birthplace = "?", Status = "Alive", UnitID = 4},
                    new Soldier{LastName = "Huo", FirstName = "Ying", Age = 39, Birthplace = "?", Status = "Alive", UnitID = 4},
                    new Soldier{LastName = "Man", FirstName = "Jo", Age = 31, Birthplace = "?", Status = "Alive", UnitID = 5}
                };
                foreach (Soldier s in soldiers)
                {
                    context.Soldiers.Add(s);
                }
            }
            context.SaveChanges();


            // populate achievements
            if (!context.Achievements.Any())
            {
                Achievement[] achieves = new Achievement[]
                {
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 1},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 1},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 1},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 1},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 1},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 2},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 2},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 2},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 2},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 3},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 3},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 3},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 4},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 5},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 5},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 5},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 6},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 7},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 7},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 7},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 7},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 7},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 8},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 8},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 9},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 11}
                };
                foreach(Achievement a in achieves)
                {
                    context.Achievements.Add(a);
                }
                context.SaveChanges();
            }

            // assigning the soldier to their CO
            if (!context.Assignments.Any())
            {
                Assignment[] assigns = new Assignment[]
                {
                    new Assignment{SoldierID = 1, OfficerID = 1},
                    new Assignment{SoldierID = 2, OfficerID = 1},
                    new Assignment{SoldierID = 3, OfficerID = 2},
                    new Assignment{SoldierID = 4, OfficerID = 2},
                    new Assignment{SoldierID = 5, OfficerID = 2},
                    new Assignment{SoldierID = 6, OfficerID = 3},
                    new Assignment{SoldierID = 7, OfficerID = 3},
                    new Assignment{SoldierID = 8, OfficerID = 3},
                    new Assignment{SoldierID = 9, OfficerID = 4},
                    new Assignment{SoldierID = 10, OfficerID = 4},
                    new Assignment{SoldierID = 11, OfficerID = 5},
                };
                foreach(Assignment a in assigns)
                {
                    context.Assignments.Add(a);
                }
            }
            context.SaveChanges();

        }
    }
}
