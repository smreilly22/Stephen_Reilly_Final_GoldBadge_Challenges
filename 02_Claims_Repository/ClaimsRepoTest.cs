using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims_Challenge
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        [TestInitialize]
        public void Arrange()
        {
            Claims claim1 = new Claims( Claims.ClaimTypes.Car, "Stolen Car", 300d, new DateTime(2019, 09, 18), new DateTime(2020, 04, 06), true);
            Claims claim2 = new Claims( Claims.ClaimTypes.House, "Fire", 1000d, new DateTime(2021, 02, 03), new DateTime(2021, 04, 05), false);
            
            _claimRepo.AddClaim(claim1);
            _claimRepo.AddClaim(claim2);

        }

        [TestMethod]
        public void ShouldAddClaim()
        {
            Claims claim = new Claims( Claims.ClaimTypes.Car, "Accidnet", 700d, new DateTime(2021, 07, 18), new DateTime(2021, 08, 12), true);
            bool addResult = _claimRepo.AddClaim(claim);

            Assert.IsTrue(addResult);
            Assert.IsTrue(_claimRepo.GetAllClaims().Contains(claim));

        }

        [TestMethod]
        public void ShouldRemove()
        {
            Claims claim = new Claims( Claims.ClaimTypes.House, "B&E", 6000d, new DateTime(2021, 03, 04), new DateTime(2022, 07, 08), false);
            _claimRepo.AddClaim(claim);

            Assert.IsTrue(_claimRepo.RemoveClaim(claim));
            Assert.IsFalse(_claimRepo.GetAllClaims().Contains(claim));
        }
    }
}
