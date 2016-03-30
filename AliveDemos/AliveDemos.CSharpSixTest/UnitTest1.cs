using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliveDemos.CSharpSix;
using Newtonsoft.Json;
using Shouldly;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OrderIsCorrectlySerialized()
        {
            // Arrange
            var date = DateTime.Parse("2016 03 30, 2:20pm");
            var customer = new CustomerData { Name = "Alice" };
            var item = new Item("Gift card", 50.00m);

            // Act
            var order = new Order(item, customer, date);
            var serialized = JsonConvert.SerializeObject(order.ToJson());

            // Assert
            var desiredObject = new
            {
                date = "2016-03-30",
                time = "14:20",
                customer = "Alice",
                total = 50.00m,
                tax = 6.50m,
            };
            var desiredJson = JsonConvert.SerializeObject(desiredObject);
            serialized.ShouldBe(desiredJson);
        }

        [TestMethod]
        public async Task HandleNullCustomer()
        {
            var date = DateTime.Parse("2016 03 30, 2:20pm");
            CustomerData customer = null;
            var item = new Item("Gift card", 50.00m);

            try
            {
                var order = new Order(item, customer, date);
                var serialized = JsonConvert.SerializeObject(order.ToJson());

                var desiredObject = new
                {
                    date = "2016-03-30",
                    time = "14:20",
                    customer = "",
                    total = 50.00m,
                    tax = 6.50m,
                };
                var desiredJson = JsonConvert.SerializeObject(desiredObject);
                serialized.ShouldBe(desiredJson);
                //var deserialized = JsonConvert.DeserializeAnonymousType(serialized, desiredObject);
            }
            
            catch (ArgumentNullException ex)
            {
                if (ex.ParamName == "customer")
                {
                    await ExceptionHandling.Log(ex);
                    await ExceptionHandling.NotifyBoss(ex);
                    // swallow
                }
                else
                {
                    await ExceptionHandling.Log(ex);
                    await ExceptionHandling.NotifyBoss(ex);
                    await ExceptionHandling.PageDevOnCall(ex);
                    throw;
                }
            }
             /*
            // Exception filters
            catch (ArgumentNullException ex) when (ex.ParamName == "customer")
            {
                await ExceptionHandling.Log(ex);
                await ExceptionHandling.NotifyBoss(ex);
                // swallow
            }*/
            catch (Exception ex)
            {
                await ExceptionHandling.Log(ex);
                await ExceptionHandling.NotifyBoss(ex);
                await ExceptionHandling.PageDevOnCall(ex);
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
            email.ShouldStartWith("Dear Alice");
        }

        [TestMethod]
        public void CreateOrderEmailWithoutCustomer()
        {
            // Arrange
            Item item = new Item("Gift card", 50.00m);
            CustomerData customer = new CustomerData();
            Order order = new Order(item, customer);

            // Act
            var email = Helpers.CreateEmail(order);

            // Assert
            email.ShouldStartWith("Dear Valued Customer");
        }

    }

    internal static class ExceptionHandling
    {
        internal static async Task Log(Exception ex) { }
        internal static async Task NotifyBoss(Exception ex) { }
        internal static async Task PageDevOnCall(Exception ex) { }
    }
}
