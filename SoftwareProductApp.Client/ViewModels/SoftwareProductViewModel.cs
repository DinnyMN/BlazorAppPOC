using SoftwareProductApp.Client.Models;
using SoftwareProductApp.Shared;
using System.Collections.Generic;

namespace SoftwareProductApp.Client.ViewModels
{
    public interface ISoftwareProductViewModel
    {
        IEnumerable<SoftwareProduct> GetHigherVersionSoftwareProducts(string version);
        bool IsValidVersion(string version);
    }

    public class SoftwareProductViewModel : ISoftwareProductViewModel
    {
        private readonly ISoftwareProductModel _softwareProductModel;
        public SoftwareProductViewModel(ISoftwareProductModel softwareProductModel)
        {
            _softwareProductModel = softwareProductModel;
        }

        public bool IsValidVersion(string version)
        {
            return _softwareProductModel.IsValidVersion(version);
        }

        public IEnumerable<SoftwareProduct> GetHigherVersionSoftwareProducts(string version)
        {
            return _softwareProductModel.GetHigherVersionSoftwareProducts(version);
        }
    }
}
