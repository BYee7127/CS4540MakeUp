/**
    Author: Beverly Yee
    Date:   2019.12.10
**/

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
        public static async Task InitializeAsync(QMContext context, IServiceProvider serviceProvider)
        {
            context.Database.Migrate();
            // context.Database.EnsureCreated();

            UsersRolesDB userContext = serviceProvider.GetRequiredService<UsersRolesDB>();
            userContext.Database.Migrate();

            // populate the officers
            if (!context.Officers.Any())
            {
                Officer[] officers = new Officer[]
                {
                    // admins/generals/great generals
                    // 0 = king, 1 = chancellor, 2 = great general, 3 = general
                    new Officer {FirstName = "Sei", LastName = "Ei", Rank = 0, Years = 9, Status = "Alive", Email = "ei_sei@qin.com"},

                    // high commanders 1000-5000 
                    new Officer {FirstName = "Shin", LastName = "", Rank = 5000, Years = 9, Status = "Alive", Email = "shin@qin.com"},
                    new Officer {FirstName = "Hon", LastName = "Ou", Rank = 5000, Years = 9, Status = "Alive", Email = "ou_hon@qin.com"},
                    new Officer {FirstName = "Ten", LastName = "Mou", Rank = 5000, Years = 9, Status = "Alive", Email = "mou_ten@qin.com"},
                    new Officer {FirstName = "Renka", LastName = "Shou", Rank = 5000, Years = 9, Status = "Alive", Email = "shou_renka@qin.com"},
                    new Officer {FirstName = "Bi", LastName = "Kaku", Rank = 1000, Years = 2, Status = "Deceased", Email = "kaku_bi@qin.com"},

                    // commanders 100-500 
                    new Officer {FirstName = "Fun", LastName = "Sa", Rank = 100, Years = 9, Status = "Alive", Email = "sa_fun@qin.com"},
                    new Officer {FirstName = "Un", LastName = "Sen", Rank = 100, Years = 9, Status = "Alive", Email = "sen_un@qin.com"},
                    new Officer {FirstName = "Shun", LastName = "Ken", Rank = 500, Years = 13, Status = "Alive", Email = "ken_shun@qin.com"},
                    new Officer {FirstName = "Shin", LastName = "Ryou", Rank = 300, Years = 6, Status = "Deceased", Email = "ryou_shin@qin.com"},
                    new Officer {FirstName = "Toukai", LastName = "Ki", Rank = 300, Years = 4, Status = "Deceased", Email = "ki_toukai@qin.com"}
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
                    new Unit{Name = "Hi SHin Unit", Numbers = 8000, OfficerID = 24},
                    new Unit{Name = "Gyoku Hou Unit",Numbers = 5000, OfficerID = 25},
                    new Unit{Name = "Gaku Ka Unit", Numbers = 5000, OfficerID = 26},
                    new Unit{Name = "Sou Ou Unit",Numbers = 5000, OfficerID = 27},
                    new Unit{Name = "Kaku Bi Unit", Numbers = 1000, OfficerID = 28},

                    new Unit{Name = "Red Leaf Tribe", Numbers = 100, OfficerID = 29},
                    new Unit{Name = "Yellow Bark Tribe", Numbers = 100, OfficerID = 30},
                    new Unit{Name = "Kin Gou Troops", Numbers = 500, OfficerID = 31},
                    new Unit{Name = "Chou Archers", Numbers = 300, OfficerID = 32},
                    new Unit{Name = "Ki Toukai Troops", Numbers = 300, OfficerID = 33}
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
                    new Soldier {LastName = "", FirstName = "Kei", Age = 28, Birthplace = "Jyouto Village", Status = "Alive", UnitID = 11},
                    new Soldier{LastName = "", FirstName = "Kou", Age = 23, Birthplace = "Jyouto Village", Status = "Alive", UnitID = 12},
                    new Soldier{LastName = "Sou", FirstName = "Man", Age = 27, Birthplace = "?", Status = "Alive", UnitID = 13},
                    new Soldier{LastName = "Ro", FirstName = "Han", Age = 26, Birthplace = "?", Status = "Alive", UnitID = 14},
                    new Soldier{LastName = "", FirstName = "Sou'an", Age = 28, Birthplace = "?", Status = "Alive", UnitID = 15},

                    new Soldier{LastName = "Kou", FirstName = "Moku", Age = 33, Birthplace = "?", Status = "Alive", UnitID = 16},
                    new Soldier{LastName = "Go", FirstName = "Ei", Age = 28, Birthplace = "?", Status = "Deceased", UnitID = 17},
                    new Soldier{LastName = "Kai", FirstName = "Gen", Age = 26, Birthplace = "?", Status = "Deceased", UnitID = 18},
                    new Soldier{LastName = "Bai", FirstName = "Da", Age = 32, Birthplace = "?", Status = "Alive", UnitID = 19},
                    new Soldier{LastName = "Huo", FirstName = "Ying", Age = 39, Birthplace = "?", Status = "Alive", UnitID = 20},

                    new Soldier{LastName = "Kou", FirstName = "Moku", Age = 33, Birthplace = "?", Status = "Alive", UnitID = 11},
                    new Soldier{LastName = "Go", FirstName = "Ei", Age = 28, Birthplace = "?", Status = "Deceased", UnitID = 12},
                    new Soldier{LastName = "Kai", FirstName = "Gen", Age = 26, Birthplace = "?", Status = "Deceased", UnitID = 13},
                    new Soldier{LastName = "Bai", FirstName = "Da", Age = 32, Birthplace = "?", Status = "Alive", UnitID = 14},
                    new Soldier{LastName = "Huo", FirstName = "Ying", Age = 39, Birthplace = "?", Status = "Alive", UnitID = 15},

                    new Soldier{LastName = "Man", FirstName = "Jo", Age = 31, Birthplace = "?", Status = "Alive", UnitID = 17},
                    new Soldier{LastName = "Man", FirstName = "Jo", Age = 31, Birthplace = "?", Status = "Alive", UnitID = 11}
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
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 16},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 16},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 16},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 16},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 16},

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

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 13},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 13},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 9},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 10},

                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14},
                    new Achievement { Description = "desc", Battle = "bttl", Reward = "rwrd", SolderID = 14}
                };
                foreach (Achievement a in achieves)
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
                    new Assignment{SoldierID = 16, OfficerID = 24},
                    new Assignment{SoldierID = 2, OfficerID = 24},
                    new Assignment{SoldierID = 3, OfficerID = 25},
                    new Assignment{SoldierID = 4, OfficerID = 25},
                    new Assignment{SoldierID = 5, OfficerID = 25},
                    new Assignment{SoldierID = 6, OfficerID = 26},
                    new Assignment{SoldierID = 7, OfficerID = 26},
                    new Assignment{SoldierID = 13, OfficerID = 26},
                    new Assignment{SoldierID = 9, OfficerID = 27},
                    new Assignment{SoldierID = 10, OfficerID = 27},
                    new Assignment{SoldierID = 14, OfficerID = 28},

                    new Assignment{SoldierID = 16, OfficerID = 29},
                    new Assignment{SoldierID = 2, OfficerID = 29},
                    new Assignment{SoldierID = 3, OfficerID = 30},
                    new Assignment{SoldierID = 4, OfficerID = 30},
                    new Assignment{SoldierID = 5, OfficerID = 30},
                    new Assignment{SoldierID = 6, OfficerID = 31},
                    new Assignment{SoldierID = 7, OfficerID = 31},
                    new Assignment{SoldierID = 13, OfficerID = 31},
                    new Assignment{SoldierID = 9, OfficerID = 32},
                    new Assignment{SoldierID = 10, OfficerID = 32},
                    new Assignment{SoldierID = 14, OfficerID = 33}
                };
                foreach (Assignment a in assigns)
                {
                    context.Assignments.Add(a);
                }
            }
            context.SaveChanges();

            // create the users of the website
            RoleManager<IdentityRole> rm = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "High Commander", "Commander" };
            IdentityResult result;
            foreach (string s in roleNames)
            {
                // check if the role exists first before adding it
                bool RExists = await rm.RoleExistsAsync(s);
                if (!RExists)
                {
                    // there is no role in the database so add it
                    result = await rm.CreateAsync(new IdentityRole(s));
                }
            }

            // get a user manager
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            // create an admin
            IdentityUser admin = new IdentityUser { UserName = "ei_sei@qin.com", Email = "ei_sei@qin.com", EmailConfirmed = true };
            // check if that admin exists
            IdentityUser userExists = await userManager.FindByEmailAsync("ei_sei@qin.com");
            if (userExists == null)
            {
                // if it doesn't, add it to the database with the following password
                IdentityResult create = await userManager.CreateAsync(admin, "asd123ASD!@#");
                if (create.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            // now, create High Commanders
            IdentityUser[] hcs = new IdentityUser[]
            {
                new IdentityUser{ UserName = "shin@qin.com", Email = "shin@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "mou_ten@qin.com", Email = "mou_ten@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "ou_hon@qin.com", Email = "ou_hon@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "shou_renka@qin.com", Email = "shou_renka@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "kaku_bi@qin.com", Email = "kaku_bi@qin.com", EmailConfirmed = true }
            };
            // do the same thing for High Commanders as admin - find if they exist first before adding them
            foreach (IdentityUser h in hcs)
            {
                userExists = await userManager.FindByEmailAsync(h.Email);
                if (userExists == null)
                {
                    IdentityResult create = await userManager.CreateAsync(h, "asd123ASD!@#");
                    if (create.Succeeded) { await userManager.AddToRoleAsync(h, "High Commander"); }
                }
            }

            // onto the commanders!
            IdentityUser[] cs = new IdentityUser[]
            {
                new IdentityUser{ UserName = "sa_fun@qin.com", Email = "sa_fun@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "sen_un@qin.com", Email = "sen_un@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "ken_shun@qin.com", Email = "ken_shun@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "ryou_shin@qin.com", Email = "ryou_shin@qin.com", EmailConfirmed = true },
                new IdentityUser{ UserName = "ki_toukai@qin.com", Email = "ki_toukai@qin.com", EmailConfirmed = true }
            };
            foreach (IdentityUser c in cs)
            {
                userExists = await userManager.FindByEmailAsync(c.Email);
                if (userExists == null)
                {
                    IdentityResult create = await userManager.CreateAsync(c, "asd123ASD!@#");
                    if (create.Succeeded) { await userManager.AddToRoleAsync(c, "Commander"); }
                }
            }

            var users = from u in userContext.Users select u;
            var commanders = from o in context.Officers select o;
            foreach (var u in users)
            {
                foreach (var o in commanders)
                {
                    if (o.Email == u.Email)
                    {
                        o.UserID = u.Id;
                        context.Update(o);
                        break;
                    }
                }
            }

            context.SaveChanges();
            userContext.SaveChanges();
        }
    }
}
