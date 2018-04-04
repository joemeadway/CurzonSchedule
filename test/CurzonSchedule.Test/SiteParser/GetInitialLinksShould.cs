using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using sut = CurzonSchedule;

namespace CurzonSchedule.Test.SiteParser
{
    public class GetInitialLinksShould
    {
        [Fact]
        public void ReturnLink_WhenPageHasOneCinemaAndPageLink()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/123/film-info/film-title"">Link</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetInitialLinks(parentDoc);

            Assert.Single(result);
        }

        [Fact]
        public void ReturnsTwoLinks_WhenPageHasTwoCinemasWithSameFilm()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/123/film-info/film-title"">Link</a> <a href=""/cinema/456/film-info/film-title"">Link</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetInitialLinks(parentDoc);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ReturnsTwoLinks_WhenPageHasOneCinemasWithTwoFilms()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/123/film-info/film-title"">Link</a> <a href=""/cinema/123/film-info/different-film-title"">Link</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetInitialLinks(parentDoc);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ReturnsTwoLinks_WhenPageHasTwoCinemasWithTwoFilms()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/123/film-info/film-title"">Link</a> <a href=""/cinema/456/film-info/different-film-title"">Link</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetInitialLinks(parentDoc);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ReturnsEmptyList_WhenPageHasNoLinks()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<div>Something Else</div>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetInitialLinks(parentDoc);

            Assert.Empty(result);
        }
    }
}
