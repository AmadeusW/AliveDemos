﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliveDemos.CSharpSix;
using Newtonsoft.Json;

namespace AliveDemos.CSharpSixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OrderIsCorrectlySerialized()
        {
            var date = DateTime.Parse("2016 03 30, 4:20pm");
            var customer = new CustomerData { Name = "Alice" };
            var item = new Item("Gift card", 50.00m);

            var desiredObject = new
            {
                Date = "2016-03-30",
                Time = "16:20",
                Customer = "Alice",
                Total = 50.00m,
                Tax = 6.50m,
            };

            var order = new Order(item, customer, date);

            var serialized = JsonConvert.SerializeObject(order.ToJson());
            var deserialized = JsonConvert.DeserializeAnonymousType(serialized, desiredObject);
            Assert.AreEqual(desiredObject, deserialized);
        }

        [TestMethod]
        public void HandleIncorrectCustomer()
        {
            var date = DateTime.Parse("2016 03 30, 4:20pm");
            var customer = new CustomerData();
            var item = new Item("Gift card", 50.00m);

            var desiredObject = new
            {
                Date = "2016-03-30",
                Time = "16:20",
                Customer = "",
                Total = 50.00m,
                Tax = 6.50m,
            };

            var order = new Order(item, customer, date);

            var serialized = JsonConvert.SerializeObject(order.ToJson());
            var deserialized = JsonConvert.DeserializeAnonymousType(serialized, desiredObject);
            Assert.AreEqual(desiredObject, deserialized);
        }

        [TestMethod]
        public void HandleNullCustomer()
        {
            var date = DateTime.Parse("2016 03 30, 4:20pm");
            CustomerData customer = null;
            var item = new Item("Gift card", 50.00m);

            var desiredObject = new
            {
                Date = "2016-03-30",
                Time = "16:20",
                Customer = "",
                Total = 50.00m,
                Tax = 6.50m,
            };

            try
            {
                var order = new Order(item, customer, date);
                var serialized = JsonConvert.SerializeObject(order.ToJson());
                var deserialized = JsonConvert.DeserializeAnonymousType(serialized, desiredObject);
                Assert.AreEqual(desiredObject, deserialized);
            }
            /*
            catch (ArgumentNullException ex)
            {
                if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Tuesday)
                {
                    // swallow
                }
                else
                {
                    // do
                    // a lot of
                    // logic
                    throw;
                }
            }
            /*
            // Exception filters

            catch (ArgumentNullException ex) when (DateTime.UtcNow.DayOfWeek == DayOfWeek.Tuesday)
            {
                // swallow
                return;
            }*/
            catch (Exception ex)
            {
                // do
                // a lot of
                // logic
                throw;
            }
        }

        [TestMethod]
        public void CreateOrderEmail()
        {
            // Arrange
            Item item = new Item("Gift card", 50.00m);
            CustomerData customer = new CustomerData { Name = "Alice" };
            Order order = new Order(item, customer);

            // Act
            var email = Helpers.CreateEmail(order);

            // Assert
            Assert.IsTrue(email.StartsWith("Dear Alice"));
        }

        [TestMethod]
        public void CreateOrderEmailWithoutCustomer()
        {
            Item item = new Item("Gift card", 50.00m);
            CustomerData customer = new CustomerData();
            Order order = new Order(item, customer);

            var email = Helpers.CreateEmail(order);

            Assert.IsTrue(email.StartsWith("Dear Valued Customer"));
        }

    }
}