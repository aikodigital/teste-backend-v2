using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Extras;
using UnitTests.Services;

namespace UnitTests.Tests
{
    [TestClass]
    public class EquipmentPositionLastHistory_TestClass
    {
        public IList<EquipmentPositionLastHistory> EquipmentPositionLastHistory { get; set; }

        [TestMethod]
        public async Task EquipmentPositionLastHistories_ByIDAsync()
        {
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentPositionLastHistoriesAsync(Guid.Parse("fe2a2e11-bfa6-46b6-990b-fd8175946b7e"));

            EquipmentPositionLastHistory = result;

            Assert.IsNotNull(EquipmentPositionLastHistory);
        }

        [TestMethod]
        public async Task EquipmentPositionLastHistories_AllAsync()
        {
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.AllAsync(Guid.Parse("fe2a2e11-bfa6-46b6-990b-fd8175946b7e"));

            EquipmentPositionLastHistory = result;

            Assert.IsNotNull(EquipmentPositionLastHistory);
        }
    }
}
