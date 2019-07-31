﻿using SoftwareProductApp.Shared;
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
            return new List<SoftwareProduct>
        }
    }
}