using System;
using System.Collections.Generic;

namespace DAL.Interfases
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="TEntiy">Entity</typeparam>
    public interface IGenericRepository<TEntiy> where TEntiy : class
    {
        /// <summary>
        /// Get all entity objects
        /// </summary>
        /// <returns>All objects of TEntiy entity</returns>
        IEnumerable<TEntiy> GetAll();

        /// <summary>
        /// Gett element by Id
        /// </summary>
        /// <param name="key">Elemetnt id</param>
        /// <returns>TEntiy Element</returns>
        TEntiy Get(object key);

        /// <summary>
        /// Find objects by predicate
        /// </summary>
        /// <param name="predicate">Seach predicate</param>
        /// <returns>Found elements</returns>
        IEnumerable<TEntiy> Find(Func<TEntiy, bool> predicate);

        /// <summary>
        /// Create a new item
        /// </summary>
        /// <param name="item">Creating object</param>
        void Create(TEntiy item);

        /// <summary>
        /// Update TEntiy item
        /// </summary>
        /// <param name="item">Updating item</param>
        void Update(TEntiy item);

        /// <summary>
        /// Delete element by Id
        /// </summary>
        /// <param name="key">Elemetnt id</param>
        void Delete(object key);
    }
}