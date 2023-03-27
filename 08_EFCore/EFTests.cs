using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Xunit;
using DL;
using Models;

namespace Tests
{
    //To Test repo methods
    //you need Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.Design
    //Microsoft.EntityFrameworkCore.Sqlite packages installed in your Test project
    public class DLTests
    {
        private readonly DbContextOptions<Entity.RestaurantDBContext> options;

        public DLTests()
        {
            //we are constructing db context options
            //using options builder everytime we instantiate DLTests class
            //and using SQlite's in memory db
            //instead of our real db
            options = new DbContextOptionsBuilder<Entity.RestaurantDBContext>()
                        .UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        //Testing Read ops
        [Fact]
        public void GetAllRestaurantsShouldGetAllRestaurants()
        {
            using(var context = new Entity.RestaurantDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var restaurants = repo.GetAllRestaurants();
                
                //Assert
                Assert.Equal(2, restaurants.Count);
            }
        }


        //For anything that modifies a data set
        //like Write, Update, Delete
        //Test using 2 contexts
        //1 to arrange and act
        //another to directly access the data with context (bypassing repo methods)
        //to assert/ensure that the operations are being performed correctly.
        [Fact]
        public void AddingARestaurantShouldAddARestaurant()
        {
            using(var context = new Entity.RestaurantDBContext(options))
            {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new DBRepo(context);
                Models.Restaurant restoToAdd = new Models.Restaurant(){
                    Id = 3,
                    Name = "Chipotle",
                    City = "Warner Robins",
                    State = "GA"
                };

                //Act
                repo.AddRestaurant(restoToAdd);
            }

            using(var context = new Entity.RestaurantDBContext(options))
            {
                //Assert
                Entity.Restaurant resto = context.Restaurants.FirstOrDefault(r => r.Id == 3);

                Assert.NotNull(resto);
                Assert.Equal(resto.Name, "Chipotle");
                Assert.Equal(resto.City, "Warner Robins");
                Assert.Equal(resto.State, "GA");
            }
        }

        private void Seed()
        {
            using(var context = new Entity.RestaurantDBContext(options))
            {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange(
                    new Entity.Restaurant(){
                        Id = 1,
                        Name = "Bone Fish",
                        City = "Lakeland",
                        State = "FL",
                        Reviews = new List<Entity.Review>(){
                            new Entity.Review(){
                                Id = 1,
                                Rating = 5,
                                Note = "Best Sea bass I've ever had"
                            }
                        }
                    },
                    new Entity.Restaurant(){
                        Id = 2,
                        Name = "Grumpy Monk",
                        City = "Myrtle Beach",
                        State = "SC",
                        Reviews = new List<Entity.Review>(){
                            new Entity.Review(){
                                Id = 2,
                                Rating = 4,
                                Note = "Beer selection in infinite and everchanging"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}