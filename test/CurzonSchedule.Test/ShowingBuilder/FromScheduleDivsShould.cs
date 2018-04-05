using System;
using System.Collections.Generic;
using System.Text;
using sut = CurzonSchedule;
using Xunit;
using System.Linq;
using HtmlAgilityPack;

namespace CurzonSchedule.Test.ShowingBuilder
{
    public class FromScheduleDivsShould
    {
        [Fact]
        public void ReturnEmptyList_GivenEmptyInput()
        {
            var sut = new sut.ShowingBuilder();

            var sourceShowing = new Showing
            {
                At = new Cinema
                {
                    Number = "123"
                },
                What = new Film
                {
                    Slug = "new-film"
                }
            };

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> {  });

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void NoShowingAdded_WhenNoTimeLinkUnderneathListItem()
        {
            var sut = new sut.ShowingBuilder();

            var sourceShowing = new Showing
            {
                At = new Cinema
                {
                    Number = "123"
                },
                What = new Film
                {
                    Slug = "new-film"
                }
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Text, parentDoc, 5);
            session1Film.Name = "p";
            session1Film.InnerHtml = "This is a note about the film";

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnSingleShowing_GivenSingleDivWithSingleDateAndTimeInput()
        {
            var sut = new sut.ShowingBuilder();

            var sourceShowing = new Showing
            {
                At = new Cinema
                {
                    Number = "123"
                },
                What = new Film
                {
                    Slug = "new-film"
                }
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Single(result);
        }

        [Fact]
        public void ReturnedShowingHasFilmSet_GivenSingleFilmAndShowing()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Equal(film, result.First().What);
        }

        [Fact]
        public void ReturnedShowingHasCinemaSet_GivenSingleFilmAndShowing()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Equal(cinema, result.First().At);
        }

        [Fact]
        public void ReturnedShowingHasTimeAndDateSet_GivenSingleFilmAndShowing()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Equal(new DateTime(2018, 4, 7, 18, 15, 00), result.First().When);
        }


        [Fact]
        public void ReturnsTwoShowing_GivenSingleDateWithTwoTimes()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            var session2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session2.Name = "li";

            var session2Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session2Film.Name = "a";
            session2Film.InnerHtml = "9:15 AM";
            session2Film.Attributes.Add("href", "/booking/240/6184758");
            session2Film.Attributes.Add("data-filmpage-exp", "");
            session2Film.AddClass("filmTimeItem");

            session2.AppendChild(session2Film);
            sessionList.AppendChild(session2);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Equal(2, result.Count());
        }


        [Fact]
        public void ReturnsTwoShowingWithTwoDifferentTimes_GivenSingleDateWithTwoTimes()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            parentFilmSession.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            var session2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session2.Name = "li";

            var session2Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session2Film.Name = "a";
            session2Film.InnerHtml = "9:15 AM";
            session2Film.Attributes.Add("href", "/booking/240/6184758");
            session2Film.Attributes.Add("data-filmpage-exp", "");
            session2Film.AddClass("filmTimeItem");

            session2.AppendChild(session2Film);
            sessionList.AppendChild(session2);

            parentFilmSession.AppendChild(sessionList);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });


            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 7, 9, 15, 00)));
            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 7, 18, 15, 00)));
        }

        [Fact]
        public void ReturnsFourShowings_GivenTwoDaysWithTwoShowings()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var day1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            day1.Name = "div";
            day1.AddClass("filmSessions");
            day1.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            day1.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            day1.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            var session2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session2.Name = "li";

            var session2Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session2Film.Name = "a";
            session2Film.InnerHtml = "9:15 AM";
            session2Film.Attributes.Add("href", "/booking/240/6184758");
            session2Film.Attributes.Add("data-filmpage-exp", "");
            session2Film.AddClass("filmTimeItem");

            session2.AppendChild(session2Film);
            sessionList.AppendChild(session2);

            day1.AppendChild(sessionList);

            var day2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            day2.Name = "div";
            day2.AddClass("filmSessions");
            day2.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            day2.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-08"">Sunday 8 April 2018</div>";

            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            day2.AppendChild(unused);

            var day2List = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            day2List.Name = "ul";
            day2List.AddClass("filmTimes");
            day2List.AddClass("filmInfo");

            var session3 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session3.Name = "li";

            var session3Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session3Film.Name = "a";
            session3Film.InnerHtml = "4:25 PM";
            session3Film.Attributes.Add("href", "/booking/240/6184758");
            session3Film.Attributes.Add("data-filmpage-exp", "");
            session3Film.AddClass("filmTimeItem");

            session3.AppendChild(session3Film);
            day2List.AppendChild(session3);

            var session4 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session4.Name = "li";

            var session4Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session4Film.Name = "a";
            session4Film.InnerHtml = "5:25 AM";
            session4Film.Attributes.Add("href", "/booking/240/6184758");
            session4Film.Attributes.Add("data-filmpage-exp", "");
            session4Film.AddClass("filmTimeItem");

            session4.AppendChild(session4Film);
            day2List.AppendChild(session4);

            day2.AppendChild(day2List);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { day1, day2 });

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void ReturnsFourShowingsWithCorrectTimes_GivenTwoDaysWithTwoShowings()
        {
            var sut = new sut.ShowingBuilder();

            var film = new Film
            {
                Slug = "new-film"
            };
            var cinema = new Cinema
            {
                Number = "123"
            };

            var sourceShowing = new Showing
            {
                At = cinema,
                What = film
            };

            var parentDoc = new HtmlDocument();
            var titleElement = new HtmlNode(HtmlNodeType.Text, parentDoc, 0);
            titleElement.InnerHtml = @"<h1 class=""h2 filmPageTitle"">Ghost Stories</h1>";
            var day1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            day1.Name = "div";
            day1.AddClass("filmSessions");
            day1.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            day1.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div>";
            var unused = new HtmlNode(HtmlNodeType.Element, parentDoc, 2);
            unused.Name = "ul";
            unused.InnerHtml = @"<ul class=""filmExp dn""></ul>";
            day1.AppendChild(unused);

            var sessionList = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            sessionList.Name = "ul";
            sessionList.AddClass("filmTimes");
            sessionList.AddClass("filmInfo");

            var session1 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session1.Name = "li";

            var session1Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session1Film.Name = "a";
            session1Film.InnerHtml = "6:15 PM";
            session1Film.Attributes.Add("href", "/booking/240/6184758");
            session1Film.Attributes.Add("data-filmpage-exp", "");
            session1Film.AddClass("filmTimeItem");

            session1.AppendChild(session1Film);
            sessionList.AppendChild(session1);

            var session2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session2.Name = "li";

            var session2Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session2Film.Name = "a";
            session2Film.InnerHtml = "9:15 AM";
            session2Film.Attributes.Add("href", "/booking/240/6184758");
            session2Film.Attributes.Add("data-filmpage-exp", "");
            session2Film.AddClass("filmTimeItem");

            session2.AppendChild(session2Film);
            sessionList.AppendChild(session2);

            day1.AppendChild(sessionList);

            var day2 = new HtmlNode(HtmlNodeType.Element, parentDoc, 1);
            day2.Name = "div";
            day2.AddClass("filmSessions");
            day2.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            day2.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-08"">Sunday 8 April 2018</div>";
            day2.AppendChild(unused);

            var day2List = new HtmlNode(HtmlNodeType.Element, parentDoc, 3);
            day2List.Name = "ul";
            day2List.AddClass("filmTimes");
            day2List.AddClass("filmInfo");

            var session3 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session3.Name = "li";

            var session3Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session3Film.Name = "a";
            session3Film.InnerHtml = "4:25 PM";
            session3Film.Attributes.Add("href", "/booking/240/6184758");
            session3Film.Attributes.Add("data-filmpage-exp", "");
            session3Film.AddClass("filmTimeItem");

            session3.AppendChild(session3Film);
            day2List.AppendChild(session3);

            var session4 = new HtmlNode(HtmlNodeType.Element, parentDoc, 4);
            session4.Name = "li";

            var session4Film = new HtmlNode(HtmlNodeType.Element, parentDoc, 5);
            session4Film.Name = "a";
            session4Film.InnerHtml = "5:25 AM";
            session4Film.Attributes.Add("href", "/booking/240/6184758");
            session4Film.Attributes.Add("data-filmpage-exp", "");
            session4Film.AddClass("filmTimeItem");

            session4.AppendChild(session4Film);
            day2List.AppendChild(session4);

            day2.AppendChild(day2List);

            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { day1, day2 });

            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 8, 5, 25, 00)));
            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 8, 16, 25, 00)));
            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 7, 9, 15, 00)));
            Assert.True(result.Any(s => s.When == new DateTime(2018, 4, 7, 18, 15, 00)));
        }

    }
}
