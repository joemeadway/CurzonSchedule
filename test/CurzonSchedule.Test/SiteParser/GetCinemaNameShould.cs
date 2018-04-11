using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using sut = CurzonSchedule;

namespace CurzonSchedule.Test.SiteParser
{
    public class GetCinemaNameShould
    {
        [Fact]
        public void ReturnName_WhenPageContainsIt()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var body = new HtmlNode(HtmlNodeType.Element, parentDoc, 0);
            body.Name = "body";
            body.Attributes.Add("data-cinema-name", "Cinema Name");
            parentDoc.DocumentNode.AppendChild(body);

            var result = parser.GetCinemaName(parentDoc);

            Assert.Equal("Cinema Name", result);
        }

        [Fact]
        public void ReturnEmptyString_WhenPageDoesNotHaveCinemaNameAttribute()
        {
            var parser = new sut.SiteParser();

            var parentDoc = new HtmlDocument();
            var body = new HtmlNode(HtmlNodeType.Element, parentDoc, 0);
            body.Name = "body";
            body.Attributes.Add("data-cinema-name", "");
            parentDoc.DocumentNode.AppendChild(body);

            var result = parser.GetCinemaName(parentDoc);

            Assert.Equal("", result);
        }
    }
}
