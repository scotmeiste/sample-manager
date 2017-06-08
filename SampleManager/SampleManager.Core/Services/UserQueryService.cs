using System.Collections.Generic;
using System.Linq;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Services
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserQueryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<UserViewModel> ReturnAllUsers()
        {
            var results = _unitOfWork.UserRepository
                .Find(user => true)
                .Select(user => MapUser(user))
                .ToList();

            return results;
        }

        private static UserViewModel MapUser(User user)
        {
            return new UserViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
