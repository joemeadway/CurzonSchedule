using System;
using System.Collections.Generic;
using System.Text;
using sut = CurzonSchedule;
using Xunit;
using System.Linq;

namespace CurzonSchedule.Test.ShowingBuilder
{
    public class FromInitialUrlListShould
    {
        [Fact]
        public void ReturnEmptyList_GivenEmptyInput()
        {
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(new List<string>());

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnEmptyList_GivenNullInput()
        {
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(null);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnSingleShowing_GivenSingleInput()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film"
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.Single(result);
        }

        [Fact]
        public void SingleShowingHaveCinemaNumberSet_GivenSingleInput()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film"
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.NotNull(result.First().At);
            Assert.Equal("123", result.First().At.Number);
        }

        [Fact]
        public void SingleShowingHaveFilmSlugSet_GivenSingleInput()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film"
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.NotNull(result.First().What);
            Assert.Equal("new-film", result.First().What.Slug);
        }

        [Fact]
        public void TwoShowingsHaveCinemaNumberSet_GivenTwoInput()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film",
                "cinema/456/film/another-new-film",
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.True(result.Any(f => f.At.Number == "123"));
            Assert.True(result.Any(f => f.At.Number == "456"));
        }

        [Fact]
        public void TwoShowingHaveFilmSlugSet_GivenTwoInput()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film",
                "cinema/456/film/another-new-film",
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.True(result.Any(f => f.What.Slug == "new-film"));
            Assert.True(result.Any(f => f.What.Slug == "another-new-film"));
        }

        [Fact]
        public void TwoCinemasHavingSameFilm_HasSameFilmObjectInShowing()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film",
                "cinema/456/film/new-film",
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.True(result.ElementAt(0).What == result.ElementAt(1).What);
            Assert.False(result.ElementAt(0).At == result.ElementAt(1).At);
        }

        [Fact]
        public void OneCinemasHavingTwoFilms_HasSameCinemaObjectInShowing()
        {
            var input = new List<string>
            {
                "cinema/123/film/new-film",
                "cinema/123/film/another-new-film",
            };
            var sut = new sut.ShowingBuilder();

            var result = sut.FromInitialUrlList(input);

            Assert.True(result.ElementAt(0).At == result.ElementAt(1).At);
            Assert.False(result.ElementAt(0).What == result.ElementAt(1).What);
        }


    }
}
