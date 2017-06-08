using SampleManager.Core.ViewModels;

namespace SampleManager.Core.Interfaces
{
    public interface ISampleDataService
    {
        void SaveSample(SampleViewModel sample);
    }
}
