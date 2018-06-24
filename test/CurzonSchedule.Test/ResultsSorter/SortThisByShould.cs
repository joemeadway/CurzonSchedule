using CurzonSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CurzonSchedule.Test.ResultsSorter
{
    public class SortThisByShould
    {
        [Fact]
        public void ReturnEmpty_GivenEmptyInput()
        {
            var input = new List<Showing>();

            input = input.SortThisBy(SortOrder.Cinema).ToList();

            Assert.Empty(input);
        }


        [Fact]
        public void ReturnSingle_GivenSingleInput()
        {
            var input = new List<Showing> {
                new Showing()
            };

            input = input.SortThisBy(SortOrder.Cinema).ToList();

            Assert.Single(input);
        }

        [Fact]
        public void ReturnTwoCinemasIrrelevantOrder_GivenTwoInputAndCinemaSort()
        {
            var input = new List<Showing> {
                new Showing{
                    At = new Cinema
                    {
                        Number = "123",
                        Name = "Name 1"
                    }
                },
                new Showing{
                    At = new Cinema
                    {
                        Number = "456",
                        Name = "Name 2"
                    }
                },
            };

            input = input.SortThisBy(SortOrder.Cinema).ToList();

            Assert.Equal(2, input.Count);
        }


        [Fact]
        public void ReturnTwoCinemasGroupedThenOne_GivenThreeInputAndCinemaSort()
        {
            var cinema1 = new Cinema
            {
                Number = "123",
                Name = "Name 1"
            };
            var cinema2 = new Cinema
            {
                Number = "456",
                Name = "Name 2"
            };
            var input = new List<Showing> {
                new Showing{
                    At = cinema1
                },
                new Showing{
                    At = cinema2
                },
                new Showing{
                    At = cinema1
                }
            };

            input = input.SortThisBy(SortOrder.Cinema).ToList();

            Assert.True((input.ElementAt(0).At == input.ElementAt(1).At) || 
                        (input.ElementAt(1).At == input.ElementAt(2).At));
        }

        [Fact]
        public void ReturnOrderedCinemasGrouped_GivenThreeInputCinemasSort()
        {
            var cinema1 = new Cinema
            {
                Number = "123",
                Name = "Name 1"
            };
            var cinema2 = new Cinema
            {
                Number = "456",
                Name = "Name 2"
            };
            var cinema3 = new Cinema
            {
                Number = "789",
                Name = "Name 3"
            };
            var input = new List<Showing> {
                new Showing{
                    At = cinema1
                },
                new Showing{
                    At = cinema2
                },
                new Showing{
                    At = cinema1
                },
                new Showing{
                    At = cinema3
                },
                new Showing{
                    At = cinema3
                },
                new Showing{
                    At = cinema1
                },
                new Showing{
                    At = cinema2
                },
                new Showing{
                    At = cinema1
                }
            };

            input = input.SortThisBy(SortOrder.Cinema).ToList();

            Assert.Equal(cinema1, input.ElementAt(0).At);
            Assert.Equal(cinema1, input.ElementAt(1).At);
            Assert.Equal(cinema1, input.ElementAt(2).At);
            Assert.Equal(cinema1, input.ElementAt(3).At);
            Assert.Equal(cinema2, input.ElementAt(4).At);
            Assert.Equal(cinema2, input.ElementAt(5).At);
            Assert.Equal(cinema3, input.ElementAt(6).At);
            Assert.Equal(cinema3, input.ElementAt(7).At);
        }


        [Fact]
        public void ReturnTwoCinemasDateOrder_GivenTwoInputAndCinemaSort()
        {
            var showing1 = new Showing{
                When = new DateTime(2018, 01, 01, 13, 00, 00)
            };
            var showing2 = new Showing
            {
                When = new DateTime(2018, 01, 02, 13, 00, 00)
            };
            var input = new List<Showing> {
                showing2, showing1
            };

            input = input.SortThisBy(SortOrder.Date).ToList();

            Assert.Equal(showing1, input.ElementAt(0));
            Assert.Equal(showing2, input.ElementAt(1));
        }



        [Fact]
        public void ReturnTwoCinemasGroupedThenOne_GivenThreeInputAndFilmSort()
        {
            var film1 = new Film
            {
                Name = "Film 1"
            };
            var film2 = new Film
            {
                Name = "Film 2"
            };
            var input = new List<Showing> {
                new Showing{
                    What = film1
                },
                new Showing{
                    What = film2
                },
                new Showing{
                    What = film1
                }
            };

            input = input.SortThisBy(SortOrder.Film).ToList();

            Assert.True((input.ElementAt(0).What == input.ElementAt(1).What) ||
                        (input.ElementAt(1).What == input.ElementAt(2).What));
        }
    }
}
