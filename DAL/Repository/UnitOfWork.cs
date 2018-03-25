using System;
using DAL.Interfases;
using Models;

namespace DAL.Repository
{
    /// <summary>
    /// Providing access to repositories
    /// Defining the general context for repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;

        private readonly Lazy<GenericRepository<Game>> lazyGameRepository;
        private readonly Lazy<GenericRepository<Genre>> lazyGenreRepository;
        private readonly Lazy<GenericRepository<Comment>> lazyCommentRepository;
        private readonly Lazy<GenericRepository<PlatformType>> lazyPlatformTypeRepository;


        public UnitOfWork(string connection)
        {
            context = new DatabaseContext(connection);

            lazyGameRepository = new Lazy<GenericRepository<Game>>(
                () => new GenericRepository<Game>(context));
            lazyGenreRepository = new Lazy<GenericRepository<Genre>>(
                () => new GenericRepository<Genre>(context));
            lazyCommentRepository = new Lazy<GenericRepository<Comment>>(
                () => new GenericRepository<Comment>(context));
            lazyPlatformTypeRepository = new Lazy<GenericRepository<PlatformType>>(
                () => new GenericRepository<PlatformType>(context));

        }

        /// <summary>
        /// Getter for Game repository
        /// </summary>
        public IGenericRepository<Game> GameRepository => lazyGameRepository.Value;

        /// <summary>
        /// Getter for Genre repository
        /// </summary>
        public IGenericRepository<Genre> GenreRepository => lazyGenreRepository.Value;

        /// <summary>
        /// Getter for Comment repository
        /// </summary>
        public IGenericRepository<Comment> CommentRepository => lazyCommentRepository.Value;

        /// <summary>
        /// Getter for PlatformType repository
        /// </summary>
        public IGenericRepository<PlatformType> PlatformTypeRepository => lazyPlatformTypeRepository.Value;

        /// <summary>
        /// Commit database changes
        /// </summary>
        public void Commit() => context.SaveChanges();
    }
}