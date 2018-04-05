using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using sut = CurzonSchedule;

namespace CurzonSchedule.Test.ShowingBuilder
{
    public class GetCinemaNumberShould
    {
        [Fact]
        public void ReturnsNumber_FromProperlyFormattedLink()
        {
            var input = "/cinema/7733/film-info/isle-of-dogs";
            var builder = new sut.ShowingBuilder();

            var result = builder.GetCinemaNumber(input);

            Assert.Equal("7733", result);
        }

        [Fact]
        public void ReturnsNumber_FromLinkWithNoCinema()
        {
            var input = "7733/film-info/isle-of-dogs";
            var builder = new sut.ShowingBuilder();

            var result = builder.GetCinemaNumber(input);

            Assert.Equal("7733", result);
        }


        [Fact]
        public void ReturnsNumber_FromLinkWithNoCinemaAndStartingSlash()
        {
            var input = "/7733/film-info/isle-of-dogs";
            var builder = new sut.ShowingBuilder();

            var result = builder.GetCinemaNumber(input);

            Assert.Equal("7733", result);
        }
    }
}
