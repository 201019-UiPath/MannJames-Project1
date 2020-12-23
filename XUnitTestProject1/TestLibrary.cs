using System;
using Xunit;
using StoreDB.Models;

namespace TestProject
{
    public class TestLibrary
    {
        public void TestObjects() { 
            #region User
            User user1 = new User();
            user1.Email = "test@test.com";
            user1.LocationId = 0;
            user1.Name = "testName";
            user1.Password = "testPW";
            user1.Type = 0;
            user1.UserId = 1;
            user1.Username = "tesUsername";

            User user2 = new User();
            user2.Email = "test@test.com";
            user2.LocationId = 0;
            user2.Name = "testName";
            user2.Password = "testPW";
            user2.Type = 0;
            user2.UserId = 2;
            user2.Username = "tesUsername";
            #endregion

            #region CartItem
            CartItem cartItem1 = new CartItem();
            cartItem1.CartId = 1;
            cartItem1.CartItemId = 1;
            cartItem1.ProductId = 1;
            cartItem1.Quantity = 1;

            CartItem cartItem2 = new CartItem();
            cartItem2.CartId = 1;
            cartItem2.CartItemId = 2;
            cartItem2.ProductId = 1;
            cartItem2.Quantity = 1;
            #endregion

            #region Cart
            Cart cart1 = new Cart();
            cart1.CartId = 1;
            cart1.UserId = 1;

            Cart cart2 = new Cart();
            cart2.CartId = 2;
            cart2.UserId = 1;
            #endregion

            #region InventoryItem
            InventoryItem inventoryItem1 = new InventoryItem();
            inventoryItem1.IIId = 1;
            inventoryItem1.LocationId = 1;
            inventoryItem1.ProductId = 1;
            inventoryItem1.Quantity = 1;

            InventoryItem inventoryItem2 = new InventoryItem();
            inventoryItem2.IIId = 2;
            inventoryItem2.LocationId = 1;
            inventoryItem2.ProductId = 1;
            inventoryItem2.Quantity = 1;
            #endregion

            #region LineItem
            LineItem lineItem1 = new LineItem();
            lineItem1.LIId = 1;
            lineItem1.OrderId = 1;
            lineItem1.ProductId = 1;
            lineItem1.Quantity = 1;

            LineItem lineItem2 = new LineItem();
            lineItem2.LIId = 2;
            lineItem2.OrderId = 1;
            lineItem2.ProductId = 1;
            lineItem2.Quantity = 1;
            #endregion

            #region Location
            Location location1 = new Location();
            location1.City = "testCity";
            location1.LocationId = 1;
            location1.State = "FL";
            location1.Street = "testStreet";
            location1.StreetNumber = "123";
            location1.ZipCode = "12345";

            Location location2 = new Location();
            location2.City = "testCity";
            location2.LocationId = 1;
            location2.State = "FL";
            location2.Street = "testStreet";
            location2.StreetNumber = "123";
            location2.ZipCode = "12345";
            #endregion

            #region Order
            Order order1 = new Order();
            order1.LocationId = 1;
            order1.OrderId = 1;
            order1.TotalPrice = 20;
            order1.UserId = 1;

            Order order2 = new Order();
            order2.LocationId = 1;
            order2.OrderId = 2;
            order2.TotalPrice = 20;
            order2.UserId = 1;
            #endregion

            #region Product
            Product product1 = new Product();
            product1.Price = 10;
            product1.ProductId = 1;
            product1.ProductName = "testProduct";

            Product product2 = new Product();
            product2.Price = 10;
            product2.ProductId = 2;
            product2.ProductName = "testProduct";
            #endregion
        }
    }
}