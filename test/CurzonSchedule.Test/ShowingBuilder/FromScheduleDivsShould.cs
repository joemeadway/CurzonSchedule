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
            var parentFilmSession = new HtmlNode(HtmlNodeType.Element, parentDoc, 0);
            parentFilmSession.Name = "div";
            parentFilmSession.AddClass("filmSessions");
            parentFilmSession.SetAttributeValue("data-filmpage-sessions", "data-filmpage-sessions");

            parentFilmSession.InnerHtml = @"<div class=""filmItemDate"" data-dateformat=""2018-04-07"">Saturday 7 April 2018</div><ul class=""filmExp dn""></ul><ul class=""filmTimes filmInfo""><li><a href=""/booking/240/6184758"" class=""filmTimeItem""data-filmpage-exp="">6:15 PM</a></li></ul>";

            
            var result = sut.FromScheduleDivs(sourceShowing, new List<HtmlNode> { parentFilmSession });

            Assert.Single(result);
        }


        //     <div class="filmSessions" data-filmpage-sessions="">
        //<div class="filmItemDate" data-dateformat="2018-04-07">Saturday 7 April 2018</div>

        //             <ul class="filmExp dn"></ul>
        //	<ul class="filmTimes filmInfo">
        //		<li>
        //        		<a href = "/booking/240/6184758" class="filmTimeItem" data-filmpage-exp="">6:15 PM</a>
        //		</li>
        //		<li>
        //        		<a href = "/booking/240/6175341" class="filmTimeItem" data-filmpage-exp="">8:30 PM</a>
        //		</li>
        //	</ul>

        //     </div>



    }
}
