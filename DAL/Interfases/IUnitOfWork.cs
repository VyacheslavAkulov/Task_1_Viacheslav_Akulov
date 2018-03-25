using Models;

namespace DAL.Interfases
{
    /// <summary>
    /// Providing access to repositories
    /// Defining the general context for repositories
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Getter for Game repository
        /// </summary>
        IGenericRepository<Game> GameRepository { get; }

        /// <summary>
        /// Getter for Comment repository
        /// </summary>
        IGenericRepository<Comment> CommentRepository { get; }

        /// <summary>
        /// Getter for Genre repository
        /// </summary>
        IGenericRepository<Genre> GenreRepository { get; }

        /// <summary>
        /// Getter for PlatformType repository
        /// </summary>
        IGenericRepository<PlatformType> PlatformTypeRepository { get; }

        /// <summary>
        /// Commit database changes
        /// </summary>
        void Commit();
    }
}