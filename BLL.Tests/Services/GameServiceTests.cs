using Xunit;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tests
{
    using BLL.Interfaces;

    using DAL.Interfases;
    using DAL.Repository;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;

    using Moq;

    using Assert = Xunit.Assert;

    [TestClass]
    public class GameServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;

        private IGameService gameService;

        [TestMethod]
        public void GameServiceCreateWithGame()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Create(It.IsNotNull<Game>()));
            unitOfWorkMock.Setup(x => x.Commit());

            gameService.Create(new Game());

            unitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void GameServiceCreateWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);

            gameService.Create(null);

            unitOfWorkMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void DeleteWithAnyString()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Delete(It.IsAny<string>()));
            unitOfWorkMock.Setup(x => x.Commit());

            gameService.Delete(It.IsAny<string>());

            unitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void GameServiceGetAllTest()
        {
            var expect = new List<Game>() { new Game() };

            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.GetAll()).Returns(expect);

            var actual = gameService.GetAll();

            unitOfWorkMock.VerifyAll();
            Assert.Equal(expect, actual);
        }

        [TestMethod]
        public void GameServiceGetWithAnyKey()
        {
            var expect = new Game();

            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Get(It.IsAny<string>())).Returns(expect);

            var actual = gameService.Get(It.IsAny<string>());

            unitOfWorkMock.VerifyAll();
            Assert.Equal(expect, actual);
        }

        [TestMethod]
        public void GameServiceGetWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Get(null));

            var actual = gameService.Get(null);

            unitOfWorkMock.VerifyAll();
            Assert.Null(actual);
        }

        [TestMethod]
        public void GameServiceUpdateWithGame()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Update(It.IsNotNull<Game>()));
            unitOfWorkMock.Setup(x => x.Commit());

            gameService.Update(new Game());

            unitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void GameServiceUpdateWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            gameService = new GameService(unitOfWorkMock.Object);

            gameService.Update(null);

            unitOfWorkMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void GameServiceGetGamesByPlatformTypeWithKey()
        {
            var expect = new List<Game>() { new Game() };
            var game = new PlatformType() { Games = expect };

            unitOfWorkMock = new Mock<IUnitOfWork>();
            this.gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.PlatformTypeRepository.Get(It.IsAny<string>())).Returns(game);

            var actual = this.gameService.GetGamesByPlatformType(It.IsAny<string>());

            unitOfWorkMock.VerifyAll();

            Assert.Equal(expect, actual);
        }

        [TestMethod]
        public void GameServiceGetGamesByPlatformTypeWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            this.gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.PlatformTypeRepository.Get(null));

            Assert.Throws<NullReferenceException>(() => this.gameService.GetGamesByPlatformType(null));
        }

        [TestMethod]
        public void GameServiceGetGamesByGenreWithKey()
        {
            var expect = new List<Game>() { new Game() };
            var game = new Genre() { Games = expect };

            unitOfWorkMock = new Mock<IUnitOfWork>();
            this.gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GenreRepository.Get(It.IsAny<string>())).Returns(game);

            var actual = this.gameService.GetGamesByGenre(It.IsAny<string>());

            unitOfWorkMock.VerifyAll();

            Assert.Equal(expect, actual);
        }

        [TestMethod]
        public void GameServiceGetGetGamesByGenreWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            this.gameService = new GameService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Get(null));

            Assert.Throws<NullReferenceException>(() => this.gameService.GetGamesByGenre(null));
        }

    }
}