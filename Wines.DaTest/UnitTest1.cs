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
            wine.Name = "unit test wine";
            wine.Grapes = "23";
            wine.Country = "Bolivia";
            wine.Region = "Sucre";
            wine.Year = "2013";
            wine.Description = "No description";
            wine.Picture = "wine1.png";

            WineDa da = new WineDa();
            int rowsAffected = da.Insert(wine);
            Assert.IsTrue(rowsAffected >= 0);
        }

        [TestMethod]
        public void UpdateWine() {
            Wine wine = new Wine();
            wine.Id = 4;
            wine.Name = "unit test wine";
            wine.Grapes = "23";
            wine.Country = "Bolivia";
            wine.Region = "Bermejo";
            wine.Year = "2013";
            wine.Description = "No description";
            wine.Picture = "wine2.png";

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
