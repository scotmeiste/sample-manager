using System;
using System.Collections.Generic;
using System.Linq;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Services
{
    public class SampleQueryService : ISampleQueryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SampleQueryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<SampleViewModel> GetAllSamples()
        {
            // return all view models
            return _unitOfWork.SampleRepository
                .Find(s => true)
                .Select(s => MapViewModel(s))
                .ToList();
        }

        public IList<SampleViewModel> GetSamplesByStatusId(int statusId)
        {
            // return view models with the given status
            return _unitOfWork.SampleRepository
                .Find(s => s.StatusId == statusId)
                .Select(s => MapViewModel(s))
                .ToList();
        }

        public IList<SampleViewModel> GetSamplesByUser(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ArgumentException("SearchString is null or empy", nameof(searchString));

            // return view models for users with a name that contains the search string
            var searchStringLower = searchString.ToLower();

            var result = new List<SampleViewModel>();

            foreach (var user in _unitOfWork.UserRepository.Find(
                u => u.FirstName.ToLower().Contains(searchStringLower) ||
                     u.LastName.ToLower().Contains(searchStringLower)))
            {
                result.AddRange(user.Samples.Select(MapViewModel));
            }

            return result;
        }

        private static SampleViewModel MapViewModel(Sample sample)
        {
            return new SampleViewModel
            {
                Barcode = sample.Barcode,
                CreatedAt = sample.CreatedAt,
                SampleId = sample.SampleId,
                Status = sample.Status.StatusDescription,
                UserFirstName = sample.User.FirstName,
                UserLastName = sample.User.LastName,
                UserId = sample.UserId,
                StatusId = sample.StatusId
            };
        }
    }
}
