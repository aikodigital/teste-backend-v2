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
    public class EquipmentStateLastHistory_TestClass
    {
        public IList<EquipmentStateLastHistory> EquipmentStateLastHistory { get; set; }

        [TestMethod]
        public async Task EquipmentStateLastHistories_ByIDAsync()
        {
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentStateLastHistoriesAsync(Guid.Parse("fe2a2e11-bfa6-46b6-990b-fd8175946b7e"));

            EquipmentStateLastHistory = result;

            Assert.IsNotNull(EquipmentStateLastHistory);
        }

        [TestMethod]
        public async Task EquipmentStateLastHistories_AllAsync()
        {
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.All2Async(Guid.Parse("fe2a2e11-bfa6-46b6-990b-fd8175946b7e"));

            EquipmentStateLastHistory = result;

            Assert.IsNotNull(EquipmentStateLastHistory);
        }
    }
}
