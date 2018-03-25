using System;
using System.Collections.Generic;
using System.Runtime;
using Models;

namespace BLL.Interfaces
{
    /// <summary>
    /// Comment service interface
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Creating new comment
        /// </summary>
        /// <param name="item">New comment</param>
        void Create(Comment item);

        /// <summary>
        /// Get comments by game
        /// </summary>
        /// <param name="key">Game key</param>
        /// <returns>Game coments</returns>
        IEnumerable<Comment> GetCommnetsByGame(object key);
    }
}