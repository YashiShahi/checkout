using NUnit;
using NUnit.Framework;
using checkoutapp;
using Moq;
using System;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           

        }

        [Test]
        public void Test_Checkout()
        {
            checkout a = new checkout();
            decimal result = (decimal)0.85;
            result result1 = a.bill("Apple,Apple,Apple,Avocado,Apple");
            Assert.AreEqual(result, result1.opresult);
        }

        [Test]
        public void Test_Checkout_Invalid_Input()
        {
            checkout a = new checkout();
            
            result result1 = a.bill("Apole,Apple,Apple,Avocado,Apple");
            Assert.AreEqual("Please check the input", result1.errormessage);
            
        }

    
    }
}