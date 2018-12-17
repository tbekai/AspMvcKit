using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AspProject.Models
{
    public class Dal : DbContext
    {// les dbsets reference les tables ici 

        private static Dal _context;
        public static Dal Db // accesseur nommé db, verifie si on est sur une unique instance de dal et renvoi celle deja trouver
        {
            get
            {
                if (_context == null)
                {
                    _context = new Dal();
                }
                return _context;

            }


        }
        public Dal()
            : base("mainContext") // nom reprit du Web config, possible a omettre si il n'ya une qu'une config de préparé dans le Web.config
        {

        }

        public Dal(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // definit comment la base de donnée est initialise, les modifs, les insertions, et recrée la base a chaque fois qu'elle change
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Dal>()); // si la couche modele change la base de données change
        }

        public Repository<User> Users { get; set; }

    }    
}