using System.Collections.Generic;
using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Interfaces
{
    public interface IUserQueryService
    {
        IList<UserViewModel> ReturnAllUsers();
    }
}
