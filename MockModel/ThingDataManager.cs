using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMEditComboBoxItemsSample.MockModel
{
    class ThingDataManager
    {
        private static ThingDataManager _instance;

        public static ThingDataManager Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new ThingDataManager();
                }
                return _instance;
            }
        }

        private ThingDataManager()
        {
        }

        public List<Thing> GetThings()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing { Name = "Book", Price = "12$" });
            things.Add(new Thing { Name = "Hammer", Price = "2$" });
            things.Add(new Thing { Name = "Fridge", Price = "1200$" });

            return things;
        }
    }
}
