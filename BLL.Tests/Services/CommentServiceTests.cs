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

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;

    using Moq;

    using Assert = Xunit.Assert;

    [TestClass]
    public class CommentServiceTests
    {
        private Mock<IUnitOfWork> unitOfWorkMock;

        private ICommentService commentService;

        [TestMethod]
        public void CommentServiceCreateWithNotNullComment()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            commentService = new CommentService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.CommentRepository.Create(It.IsNotNull<Comment>()));
            unitOfWorkMock.Setup(x => x.Commit());

            commentService.Create(new Comment());

            unitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void CommentServiceCreateWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            commentService = new CommentService(unitOfWorkMock.Object);

            commentService.Create(null);

            unitOfWorkMock.VerifyNoOtherCalls();
        }


        [TestMethod]
        public void CommentServiceGetCommnetsByGameWithKey()
        {
            var expect = new List<Comment>() { new Comment() };
            var game = new Game() { Comments = expect };

            unitOfWorkMock = new Mock<IUnitOfWork>();
            commentService = new CommentService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Get(It.IsAny<string>())).Returns(game);

            var actual = commentService.GetCommnetsByGame(It.IsAny<string>());

            unitOfWorkMock.VerifyAll();

            Assert.Equal(expect, actual);
        }

        [TestMethod]
        public void CommentServiceGetCommnetsByGameWithNull()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            commentService = new CommentService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.GameRepository.Get(null));
          
            Assert.Throws<NullReferenceException>(() => commentService.GetCommnetsByGame(null));
        }
    }
}