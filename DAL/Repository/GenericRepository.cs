using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfases;

namespace DAL.Repository
{
    /// <summary>
    /// Implementing generic repository for all entities
    /// </summary>
    public class GenericRepository<TEntiy> : IGenericRepository<TEntiy> where TEntiy : class
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializing the context of the database
        /// </summary>
        /// <param name="context">Database context</param>
        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Create new object in database
        /// </summary>
        /// <param name="item">Adding object</param>
        public virtual void Create(TEntiy item)
        {
            if (item != null)
            {
                context.Set<TEntiy>().Add(item);
            }
        }

        /// <summary>
        /// Delete element by key
        /// </summary>
        /// <param name="key">Elemetnt id</param>
        public virtual void Delete(object key)
        {
            TEntiy item = context.Set<TEntiy>().Find(key);

            if (item != null)
            {
                context.Set<TEntiy>().Remove(item);
            }
        }

        /// <summary>
        /// Find objects by predicate
        /// </summary>
        /// <param name="predicate">Seach predicate</param>
        /// <returns>founded elements</returns>
        public virtual IEnumerable<TEntiy> Find(System.Func<TEntiy, bool> predicate)
        {
            return context.Set<TEntiy>().Where(predicate).ToList();
        }

        /// <summary>
        /// Gett element by key
        /// </summary>
        /// <param name="key">Elemetnt id</param>
        /// <returns>TEntiy Element</returns>
        public virtual TEntiy Get(object key)
        {
           return context.Set<TEntiy>().Find(key);
        }

        /// <summary>
        /// Get all entity objects
        /// </summary>
        /// <returns>All objects of TEntiy entity</returns>
        public virtual IEnumerable<TEntiy> GetAll()
        {
            return context.Set<TEntiy>().ToList();
        }

        /// <summary>
        /// Update TEntiy item
        /// </summary>
        /// <param name="item">Updating item</param>
        public virtual void Update(TEntiy item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}