using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfases;
using Models;
using System.Collections.Generic;

namespace BLL.Services
{
    /// <summary>
    /// Comment service interface
    /// </summary>
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creating new comment
        /// </summary>
        /// <param name="item">New comment</param>
        public void Create(Comment item)
        {
            if (item != null)
            {
                Logger.Log.Info($"Creating new comment (Author:{item.Name}, Body:{item.Body})");

                unitOfWork.CommentRepository.Create(item);

                unitOfWork.Commit();
            }

        }

        /// <summary>
        /// Get comments by game
        /// </summary>
        /// <param name="key">Game key</param>
        /// <returns>Game coments</returns>
        public IEnumerable<Comment> GetCommnetsByGame(object key)
        {
            Logger.Log.Info($"Get all comments by game key {key}");

            return unitOfWork.GameRepository.Get(key).Comments;
        }
    }

  

}