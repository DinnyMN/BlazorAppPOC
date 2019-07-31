using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SoftwareProductApp.Client.Models;
using SoftwareProductApp.Client.Services;
using SoftwareProductApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareProductApp.UnitTest
{
    [TestClass]
    public class SoftwareProductModelUnitTest
    {
        [TestMethod]
        public void MatchingLength()
        {
            var mock = new Mock<ISoftwareProductService>();

            mock.Setup(_ => _.GetAllSoftwareProducts()).Returns(
                new List<SoftwareProduct>
                {
                    new SoftwareProduct { Version = "1.7.1"},
                    new SoftwareProduct { Version = "2.6.1"},
                    new SoftwareProduct { Version = "1.2.1"}
                }
                );

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.GetHigherVersionSoftwareProducts("1.5.2");

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void NotMatchingLength()
        {
            var mock = new Mock<ISoftwareProductService>();

            mock.Setup(_ => _.GetAllSoftwareProducts()).Returns(
                new List<SoftwareProduct>
                {
                    new SoftwareProduct { Version = "1.7"},
                    new SoftwareProduct { Version = "2"},
                    new SoftwareProduct { Version = "1.2.1"}
                }
                );

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.GetHigherVersionSoftwareProducts("1.5.2");

            Assert.AreEqual(result.Count(), 2);
        }


        [TestMethod]
        public void DirectEqual()
        {
            var mock = new Mock<ISoftwareProductService>();

            mock.Setup(_ => _.GetAllSoftwareProducts()).Returns(
                new List<SoftwareProduct>
                {
                    new SoftwareProduct { Version = "1.7"},
                    new SoftwareProduct { Version = "2"},
                    new SoftwareProduct { Version = "1.5.2"},
                    new SoftwareProduct { Version = "0.6"}
                }
                );

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.GetHigherVersionSoftwareProducts("1.5.2");

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void NotMatchingLengthEqual()
        {
            var mock = new Mock<ISoftwareProductService>();

            mock.Setup(_ => _.GetAllSoftwareProducts()).Returns(
                new List<SoftwareProduct>
                {
                    new SoftwareProduct { Version = "1.7"},
                    new SoftwareProduct { Version = "2"},
                    new SoftwareProduct { Version = "2.0"},
                    new SoftwareProduct { Version = "2.0.0"},
                    new SoftwareProduct { Version = "1.5.2"},
                    new SoftwareProduct { Version = "0.6"},
                    new SoftwareProduct { Version = "1239.12234"},
                    new SoftwareProduct { Version = "2.1"},
                    new SoftwareProduct { Version = "2.0.1"}
                }
                );

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.GetHigherVersionSoftwareProducts("2");

            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void ValidVersionSingle()
        {
            var mock = new Mock<ISoftwareProductService>();

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.IsValidVersion("2");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidVersionMultiple()
        {
            var mock = new Mock<ISoftwareProductService>();

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.IsValidVersion("2.9.1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvalidVersionString()
        {
            var mock = new Mock<ISoftwareProductService>();

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.IsValidVersion("a");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidVersionTrailingDot()
        {
            var mock = new Mock<ISoftwareProductService>();

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.IsValidVersion("1.");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidVersionStringInt()
        {
            var mock = new Mock<ISoftwareProductService>();

            var softwareProductModel = new SoftwareProductModel(mock.Object);

            var result = softwareProductModel.IsValidVersion("1.ab");

            Assert.IsFalse(result);
        }

    }
}
