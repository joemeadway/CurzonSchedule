using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using CurzonSchedule.Models;

namespace CurzonSchedule{

    public class CinemaBuilder
    {
        public IEnumerable<Cinema> FromInitialLinks(IEnumerable<HtmlNode> inputList)
        {
            
            var toReturn =  new List<Cinema>();

            if(inputList == null || inputList.Count() == 0)
            {
                return toReturn; 
            }

            toReturn = inputList.Select(i => new Cinema
            {
                Name = HtmlEntity.DeEntitize(i.InnerText),
                Number = i.Attributes["data-film-list-item-cinema-item"].Value
            }).Distinct(new CinemaEqualityComparer()).ToList();
            
            return toReturn;
        }
    }

}