using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using System.Data.Entity;
using Library.Models.Migrations;

namespace LibraryApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                                    new MigrateDatabaseToLatestVersion
                                    <LibraryDbContext, Configuration>());
        }
    }
}
