using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using sut = CurzonSchedule;

namespace CurzonSchedule.Test.SiteParser
{
    public class GetFilmTitleShould
    {
        [Fact]
        public void ReturnTitle_WhenPageContainsIt()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            parentDoc.DocumentNode.AppendChild(titleElement);

            var result = parser.GetFilmTitle(parentDoc);

            Assert.Equal("Ghost Stories", result);
        }

        [Fact]
        public void ReturnEmptyString_WhenPageDoesNotHaveTitle()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 not a title"">Blah</h1>";
            parentDoc.DocumentNode.AppendChild(titleElement);

            var result = parser.GetFilmTitle(parentDoc);

            Assert.Equal("", result);
        }

        [Fact]
        public void ReturnDecodedString_WhenTitleHasEncodedCharacter()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">L&#39;Amant Double</h1>";
            parentDoc.DocumentNode.AppendChild(titleElement);

            var result = parser.GetFilmTitle(parentDoc);

            Assert.Equal("L'Amant Double", result);
        }
    }
}
