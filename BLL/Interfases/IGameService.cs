using System.Collections.Generic;
using Models;

namespace BLL.Interfaces
{
    /// <summary>
    /// Game service interface
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Get all games
        /// </summary>
        /// <returns></returns>
        IEnumerable<Game> GetAll();

        /// <summary>
        /// Get game by key
        /// </summary>
        /// <param name="key">Game key</param>
        /// <returns>Game</returns>
        Game Get(object key);

        /// <summary>
        /// Create new game
        /// </summary>
        /// <param name="item">New game</param>
        void Create(Game item);

        /// <summary>
        /// Updating game
        /// </summary>
        /// <param name="item">Updating item</param>
        void Update(Game item);

        /// <summary>
        /// Delete game by key
        /// </summary>
        /// <param name="key">Game key</param>
        void Delete(object key);

        /// <summary>
        /// Get all games by platform type
        /// </summary>
        /// <param name="platformType">Platform type</param>
        /// <returns>Games by platform type</returns>
        IEnumerable<Game> GetGamesByPlatformType(string platformType);

        /// <summary>
        /// Get all games by genre
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <returns>>Games by genre</returns>
        IEnumerable<Game> GetGamesByGenre(string genre);

    }
}