using SoftwareProductApp.Shared;
using System.Collections.Generic;

namespace SoftwareProductApp.Client.Services
{
    public interface ISoftwareProductService
    {
        IEnumerable<SoftwareProduct> GetAllSoftwareProducts();
    }

    public class SoftwareProductService : ISoftwareProductService
    {
        public IEnumerable<SoftwareProduct> GetAllSoftwareProducts()
        {
            return new List<SoftwareProduct>        {            new SoftwareProduct            {                Name = "MS Word",                Version = "13.2.1"                //Version = "13.2.1." //TODO: handle if time, technically doesn't meet requirements            },            new SoftwareProduct            {                Name = "AngularJS",                Version = "1.7.1"            },            new SoftwareProduct            {                Name = "Angular",                Version = "8.1.13"            },            new SoftwareProduct            {                Name = "React",                Version = "0.0.5"            },            new SoftwareProduct            {                Name = "Vue.js",                Version = "2.6"            },            new SoftwareProduct            {                Name = "Visual Studio",                Version = "2017.0.1"            },            new SoftwareProduct            {                Name = "Visual Studio",                Version = "2019.1"            },            new SoftwareProduct            {                Name = "Visual Studio Code",                Version = "1.35"            },            new SoftwareProduct            {                Name = "Blazor",                Version = "0.7"            }        };
        }
    }
}