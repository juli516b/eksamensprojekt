﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;

namespace RabatmanViewModelTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestOfferDiscountdims()
        {
            //Arrange
            OfferViewModel novm = new OfferViewModel();
            IBaseItem item = new Item("PommesDeluxe", "12345678", 1);
            IBaseItem item2 = new Item("PommesDeluxe", "12345678", 2.50);

            Assert.AreEqual(0, novm.OfferTotal); // no OfferLines added
            novm.AddOfferLine(item, 100);
            Assert.AreEqual(100, novm.OfferTotal); // one offerline added : OfferTotal = 100
            novm.OfferDiscount = "20";
            //Act

            Assert.AreEqual(80, novm.OfferTotal); // OfferDiscount set to 20 (%) : OfferTotal = 80
            novm.AddOfferLine(item2,4);
            Assert.AreEqual(88, novm.OfferTotal); // one more offerline added : OfferTotal = (100 + 10) *0,8 = 88 
            novm.OfferDiscount = "10";
            Assert.AreEqual(99, novm.OfferTotal); // OfferDiscount corrected to 10 (%) : OfferTotal = (100 + 10) * 0,9 = 99

            novm.AddOfferLine(item,100);
            novm.OfferLines[2].PercentDiscount = 20;
            Assert.AreEqual(171, novm.OfferTotal); // one more offerline added and that lines discount set to 20
            // OfferTotal = (100 + 10 + 100 * 0,8) * 0,9 = 171

        }
    }
}