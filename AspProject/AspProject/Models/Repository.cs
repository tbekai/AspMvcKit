using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspProject.Models
{ 
    public class Repository<T> :DbSet<T> where T :Model
    {   public DbSet<T> Table { get; protected set; }

        public Repository(DbContext Db)
        {
            Table = Db.Set<T>();
        }
        /// <summary>
    /// retourne un élément correspondant a un id renseigné en parametre
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
        public T Find(int? /*nullable<int>*/ id) // ? == peut etre null 
        {
            if (id.HasValue) // verifie si l'Id a une valeur 
            {
                return Local.FirstOrDefault(item => item.Id == id);// parcours un foreach 
            }
            return null;
        }
        /// <summary>
        /// retourne tout les éléments 
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll()
        {
            return Local.ToList(); // retourn tout les éléments
        }
        /// <summary>
        /// Crée un élément et l'ajoute dans le DBset
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override T Add(T source) // genere un élément, l'ajoute dans le dbset add est une méthode propre au dbset
        {
            try
            {
               return base.Add(source);
            }
            catch
            {
                return null; 
            }
        }
        /// <summary>
        /// recherche l'élement pour le mettre a jour
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool Update(T source)
        {
            T dbItem = Find(source.Id); // cherche l'élément

            if (dbItem != null) // si different de null 
            {
                dbItem.UpdateFrom(source); //mets a jour
                return true;
            }
            return false;
                       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int? id)
        {
            if (id.HasValue)
            {
                T dbItem = Find(id);

                if (dbItem != null)
                {
                    return Remove(dbItem);

                }return false;

            } return false;
        }
        public new bool Remove(T source)
        {
            try
            {
                base.Remove(source);
                return true; 
            }
            catch
            {
                return false;
            }
        }
    }
}