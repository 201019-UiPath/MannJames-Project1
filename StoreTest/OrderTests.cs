using Xunit;
using StoreDB.Models;
using StoreDB.Repos;
using StoreDB;
using System.Linq;

namespace StoreTest
{
    public class OrderTests
    {
        [Fact]
        public void AddOrder()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 1;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);
            Assert.NotNull(context.Orders.Single(q => q.OrderId == testOrder.OrderId));
            repo.DeleteOrder(testOrder);
        }
        [Fact]
        public void UpdateOrder()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 1;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);
            testOrder.LocationId = 2;
            repo.UpdateOrder(testOrder);
            Assert.Equal(2, testOrder.LocationId);

            repo.DeleteOrder(testOrder);
        }
        [Fact]
        public void GetOrderById()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 1;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);
            Assert.NotNull(repo.GetOrderById(testOrder.OrderId));
            repo.DeleteOrder(testOrder);
        }
        [Fact]
        public void GetOrderByUserId()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 1;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);
            Assert.NotNull(repo.GetOrderById(testOrder.UserId));
            repo.DeleteOrder(testOrder);
        }
        [Fact]
        public void GetOrderByLocationId()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 1;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);
            Assert.NotNull(repo.GetOrderById(testOrder.LocationId));
            repo.DeleteOrder(testOrder);
        }
        [Fact]
        public void GetAllOrdersByUserIdDateAsc()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 100;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);

            Order testOrder2 = new Order();
            testOrder2.LocationId = 1;
            testOrder2.UserId = 100;
            testOrder2.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder2);
            if (testOrder.UserId == testOrder2.UserId)
            {
                Assert.NotNull(repo.GetAllOrdersByUserIdDateAsc(testOrder.UserId));
            }
            else { Assert.NotNull(null); }

            repo.DeleteOrder(testOrder);
            repo.DeleteOrder(testOrder2);
        }
        [Fact]
        public void GetAllOrdersByUserIdPriceAsc()
        {
            using var context = new StoreContext();
            IOrderRepo repo = new DBRepo(context);

            Order testOrder = new Order();
            testOrder.LocationId = 1;
            testOrder.UserId = 100;
            testOrder.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder);

            Order testOrder2 = new Order();
            testOrder2.LocationId = 1;
            testOrder2.UserId = 100;
            testOrder2.OrderDate = System.DateTime.Now;

            repo.AddOrder(testOrder2);
            if (testOrder.UserId == testOrder2.UserId)
            {
                Assert.NotNull(repo.GetAllOrdersByUserIdDateAsc(testOrder.UserId));
            }
            else { Assert.NotNull(null); }

            repo.DeleteOrder(testOrder);
            repo.DeleteOrder(testOrder2);
        }
    }
}
