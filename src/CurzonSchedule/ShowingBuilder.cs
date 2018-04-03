using System.Collections.Generic;
using System.Linq;

namespace CurzonSchedule{

    public class ShowingBuilder
    {
        public IEnumerable<Showing> FromInitialUrlList(IEnumerable<string> inputList)
        {
            
            var toReturn =  new List<Showing>();

            if(inputList == null || inputList.Count() == 0)
            {
                return toReturn; 
            }

            foreach (var item in inputList)
            {
                toReturn.Add(new Showing{
                    At = new Cinema{
                        Number = item.Substring((item.IndexOf('/')+1),(item.IndexOf('/', item.IndexOf('/')+1)-(item.IndexOf('/')+1)))
                    },
                    What = new Film{
                        Slug = item.Substring((item.LastIndexOf('/')+1))
                    }
                });
            }

            return toReturn;
        }

    }

}