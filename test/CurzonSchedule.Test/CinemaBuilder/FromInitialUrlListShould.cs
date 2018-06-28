using System;
using System.Collections.Generic;
using System.Text;
using sut = CurzonSchedule;
using HtmlAgilityPack;
using CurzonSchedule.Models;
using Xunit;
using System.Linq;

namespace CurzonSchedule.Test.ShowingBuilder
{
    public class GetCinemasFromInitialLinks
    {
        [Fact]
        public void ReturnEmptyList_GivenEmptyInput()
        {
            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(new List<HtmlNode>());

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnEmptyList_GivenNullInput()
        {
            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(null);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnSingleCinema_GivenSingleInput()
        {
            var parentDoc = new HtmlDocument();

            var film = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film.Name = "a";
            film.AddClass("customSelectorListItem");
            film.Attributes.Add("data-film-list-item-cinema-item", "7733");
            film.Attributes.Add("href", "/cinema/7733/film-info/leave-no-trace");
            film.InnerHtml = "Aldgate";

            var inputList = new List<HtmlNode> { film };

            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(inputList);

            Assert.Single(result);
        }


        [Fact]
        public void ReturnTwoCinemas_GivenTwoDifferentInputLinks()
        {
            var parentDoc = new HtmlDocument();

            var film = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film.Name = "a";
            film.AddClass("customSelectorListItem");
            film.Attributes.Add("data-film-list-item-cinema-item", "7733");
            film.Attributes.Add("href", "/cinema/7733/film-info/leave-no-trace");
            film.InnerHtml = "Aldgate";

            var film2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film2.Name = "a";
            film2.AddClass("customSelectorListItem");
            film2.Attributes.Add("data-film-list-item-cinema-item", "237");
            film2.Attributes.Add("href", "/cinema/237/film-info/leave-no-trace");
            film2.InnerHtml = "Bloomsbury";
            //<a href="/cinema/237/film-info/leave-no-trace" class="customSelectorListItem" data-film-list-item-cinema-item="237">Bloomsbury</a>
            var inputList = new List<HtmlNode> { film, film2 };

            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(inputList);

            Assert.Equal(2, result.Count());
        }


        [Fact]
        public void ReturnOneCinemas_GivenTwoMatchingInputLinks()
        {
            var parentDoc = new HtmlDocument();

            var film = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film.Name = "a";
            film.AddClass("customSelectorListItem");
            film.Attributes.Add("data-film-list-item-cinema-item", "7733");
            film.Attributes.Add("href", "/cinema/7733/film-info/leave-no-trace");
            film.InnerHtml = "Aldgate";

            var film2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film2.Name = "a";
            film2.AddClass("customSelectorListItem");
            film2.Attributes.Add("data-film-list-item-cinema-item", "7733");
            film2.Attributes.Add("href", "/cinema/7733/film-info/leave-no-trace");
            film2.InnerHtml = "Aldgate";
            
            var inputList = new List<HtmlNode> { film, film2 };

            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(inputList);

            Assert.Single(result);
        }


        [Fact]
        public void ReturnTwoCinemas_GivenTwoMatchingInputLinksAndOneDifferent()
        {
            var parentDoc = new HtmlDocument();

            var film = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film.Name = "a";
            film.AddClass("customSelectorListItem");
            film.Attributes.Add("data-film-list-item-cinema-item", "7733");
            film.Attributes.Add("href", "/cinema/7733/film-info/leave-no-trace");
            film.InnerHtml = "Aldgate";

            var film2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film2.Name = "a";
            film2.AddClass("customSelectorListItem");
            film2.Attributes.Add("data-film-list-item-cinema-item", "237");
            film2.Attributes.Add("href", "/cinema/237/film-info/leave-no-trace");
            film2.InnerHtml = "Bloomsbury";

            var film3 = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            film3.Name = "a";
            film3.AddClass("customSelectorListItem");
            film3.Attributes.Add("data-film-list-item-cinema-item", "237");
            film3.Attributes.Add("href", "/cinema/237/film-info/leave-no-trace");
            film3.InnerHtml = "Bloomsbury";
            
            var inputList = new List<HtmlNode> { film, film2, film3 };

            var sut = new sut.CinemaBuilder();

            var result = sut.FromInitialLinks(inputList);

            Assert.Equal(2, result.Count());
        }


    }
}
