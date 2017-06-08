using System;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Services
{
    public class SampleDataService : ISampleDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SampleDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveSample(SampleViewModel sample)
        {
            var sampleToSave = new Sample
            {
                Barcode = sample.Barcode,
                CreatedAt = DateTime.Now,
                StatusId = sample.StatusId,
                UserId = sample.UserId
            };

            _unitOfWork.SampleRepository.Add(sampleToSave);

            _unitOfWork.Commit();
        }
    }
}
