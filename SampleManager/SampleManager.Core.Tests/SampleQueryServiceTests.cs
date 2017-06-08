using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Core.Services;

namespace SampleManager.Core.Tests
{
    [TestClass]
    public class SampleQueryServiceTests
    {
        

        [TestMethod]
        public void TestGetAllSamples()
        {
            var uow = GetUnitOfWork(GetSampleRepository(), GetUserRepository());
            var sampleQueryService = new SampleQueryService(uow);

            var results = sampleQueryService.GetAllSamples();

            Assert.AreEqual(results.Count, 1);

        }

        [TestMethod]
        public void TestGetSampleByStatus()
        {
            var uow = GetUnitOfWork(GetSampleRepository(), GetUserRepository());
            var sampleQueryService = new SampleQueryService(uow);

            var results = sampleQueryService.GetSamplesByStatusId(0);

            Assert.AreEqual(results.Count, 1);
        }

        [TestMethod]
        public void TestGetSampleByUser()
        {
            var uow = GetUnitOfWork(GetSampleRepository(), GetUserRepository());
            var sampleQueryService = new SampleQueryService(uow);

            var results = sampleQueryService.GetSamplesByUser("kristine");

            Assert.AreEqual(results.Count, 1);
        }

        private static IRepository<Sample> GetSampleRepository()
        {
            var repo = Substitute.For<IRepository<Sample>>();
            repo.Find(Arg.Any<Expression<Func<Sample, bool>>>()).Returns(new EnumerableQuery<Sample>(new List<Sample>
            {
                new Sample
                {
                    Barcode = "0123",
                    CreatedAt = DateTime.UtcNow,
                    SampleId = 1,
                    Status = new Status { StatusId = 0, StatusDescription = "Received"},
                    StatusId = 0,
                    User =  new User {FirstName = "Kristine", LastName = "Butler"}
                }
            }));

            return repo;
        }

        private static IRepository<User> GetUserRepository()
        {
            var repo = Substitute.For<IRepository<User>>();
            repo.Find(Arg.Any<Expression<Func<User, bool>>>()).Returns(new EnumerableQuery<User>(new List<User>
            {
                new User
                {
                    FirstName = "Kristine",
                    LastName = "Butler",
                    Samples = new List<Sample>
                    {
                        new Sample
                        {
                            Barcode = "0123",
                            CreatedAt = DateTime.UtcNow,
                            SampleId = 1,
                            Status = new Status { StatusId = 0, StatusDescription = "Received"},
                            StatusId = 0,
                            User =  new User {FirstName = "Kristine", LastName = "Butler"}
                        }
                    }
                }
            }));

            return repo;
        }

        private static IUnitOfWork GetUnitOfWork(IRepository<Sample> sampleRepo, IRepository<User> userRepo)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.SampleRepository.Returns(sampleRepo);
            uow.UserRepository.Returns(userRepo);

            return uow;
        }
    }
}
