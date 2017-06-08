using System.Collections.Generic;
using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Interfaces
{
    public interface ISampleQueryService
    {
        IList<SampleViewModel> GetAllSamples();
        IList<SampleViewModel> GetSamplesByStatusId(int statusId);
        IList<SampleViewModel> GetSamplesByUser(string searchString);

        
    }
}
