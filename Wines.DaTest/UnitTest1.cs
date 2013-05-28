using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wines.DataAccess;
using System.Collections.Generic;

namespace Wines.DaTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void GetAllWines() {
            WineDa da = new WineDa();
            List<Wine> wines = da.GetWines();
            Assert.IsTrue(wines.Count > 0);
        }

        [TestMethod]
        public void GetWine() {
            WineDa da = new WineDa();
            Wine wine = da.GetWine(1);
            Assert.IsTrue(wine != null);
        }

        [TestMethod]
        public void InsertWine() {
            Wine wine = new Wine();
            wine.name = "unit test wine";
            wine.grapes = "23";
            wine.country = "Bolivia";
            wine.region = "Sucre";
            wine.year = "2013";
            wine.description = "No description";
            wine.picture = "wine1.png";

            WineDa da = new WineDa();
            Wine result = da.Insert(wine);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void UpdateWine() {
            Wine wine = new Wine();
            wine.id = 4;
            wine.name = "unit test wine";
            wine.grapes = "23";
            wine.country = "Bolivia";
            wine.region = "Bermejo";
            wine.year = "2013";
            wine.description = "No description";
            wine.picture = "wine2.png";

            WineDa da = new WineDa();
            int rowsAffected = da.Update(wine);
            Assert.IsTrue(rowsAffected >= 0);
        }

        [TestMethod]
        public void DeleteWine() {
            WineDa da = new WineDa();

            long id = -332;
            int rowsAffected = da.Delete(id);

            Assert.IsTrue(rowsAffected == 0);
        }
    }
}
