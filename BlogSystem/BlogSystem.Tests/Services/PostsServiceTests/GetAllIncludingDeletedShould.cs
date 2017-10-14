﻿using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Factories;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Services.PostsServiceTests
{
    [TestFixture]
    class GetAllIncludingDeletedShould
    {
        [Test]
        public void CallRepositoryGetAllIncludingDeleted()
        {
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );

            service.GetAllIncludingDeleted();

            mockedRepository.Verify(r => r.AllIncludingDeleted, Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            var posts = new List<Post> { new Post() }
                .AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.AllIncludingDeleted).Returns(posts);

            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );

            var result = service.GetAllIncludingDeleted();

            Assert.AreEqual(posts, result);
        }
    }
}