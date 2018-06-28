using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using sut = CurzonSchedule;

namespace CurzonSchedule.Test.SiteParser
{
    public class GetAllCinemasShould
    {
        [Fact]
        public void ReturnCinemaLink_WhenPageContainsOneLink()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/7733/film-info//leave-no-trace"" class=""customSelectorListItem"" data-film-list-item-cinema-item=""7733"">Aldgate</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var result = parser.GetAllCinemas(parentDoc);

            Assert.Single(result);
        }

        [Fact]
        public void ReturnTwoCinemaLinks_WhenPageContainsTwoLinks()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var filmLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            filmLink.InnerHtml = @"<a href=""/cinema/7733/film-info//leave-no-trace"" class=""customSelectorListItem"" data-film-list-item-cinema-item=""7733"">Aldgate</a>";
            parentDoc.DocumentNode.AppendChild(filmLink);

            var secondLink = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            secondLink.InnerHtml = @"<a href=""/cinema/237/film-info/leave-no-trace"" class=""customSelectorListItem"" data-film-list-item-cinema-item=""237"">Bloomsbury</a>";
            parentDoc.DocumentNode.AppendChild(secondLink);

            var result = parser.GetAllCinemas(parentDoc);

            Assert.Equal(2, result.Count());
        }


        [Fact]
        public void ReturnEmptyList_WhenPageContainsNoLinks()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            
            var result = parser.GetAllCinemas(parentDoc);

            Assert.Empty(result);
        }



    }
}
