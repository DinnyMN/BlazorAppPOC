using SoftwareProductApp.Client.Services;
using SoftwareProductApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProductApp.Client.Models
{
    public interface ISoftwareProductModel
    {
        IEnumerable<SoftwareProduct> GetHigherVersionSoftwareProducts(string version);
        bool IsValidVersion(string version);
    }

    public class SoftwareProductModel : ISoftwareProductModel
    {
        private readonly ISoftwareProductService _softwareProductService;
        public SoftwareProductModel(ISoftwareProductService softwareProductService)
        {
            _softwareProductService = softwareProductService;
        }
        public IEnumerable<SoftwareProduct> GetHigherVersionSoftwareProducts(string version)
        {
            var softwareProducts = _softwareProductService.GetAllSoftwareProducts();
            var greaterThanSoftware = new List<SoftwareProduct>();

            foreach (var softwareProduct in softwareProducts)
            {
                var inputVersionParts = Array.ConvertAll(version.Split('.'), int.Parse).ToList();
                var currentSoftwareParts = Array.ConvertAll(softwareProduct.Version.Split('.'), int.Parse).ToList();

                //pad zeros 0
                while (inputVersionParts.Count < currentSoftwareParts.Count) inputVersionParts.Add(0);
                while (inputVersionParts.Count > currentSoftwareParts.Count) currentSoftwareParts.Add(0);

                for (int i = 0; i < inputVersionParts.Count; i++)
                {
                    if (currentSoftwareParts[i] > inputVersionParts[i])
                    {
                        greaterThanSoftware.Add(softwareProduct);
                        break;
                    }
                    else if(currentSoftwareParts[i] < inputVersionParts[i])
                    {
                        break;
                    }else
                    {
                        //if == continue walking thorugh
                    }

                }
            }


            return greaterThanSoftware;
        }


        public bool IsValidVersion(string version)
        {
            if (VersionInterger(version))
            {
                return true;
            }
            else
            {
                var spilt = version.Split('.');
                return spilt.All(_ => VersionInterger(_));

            }
        }

        private bool VersionInterger(string version)
        {
            return !string.IsNullOrEmpty(version) && int.TryParse(version, out _);
        }

    }
}
