using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VaperREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private static List<Vaper> vapers = new List<Vaper>
        {
            new Vaper(1, "Darth Vaper", "Torsk", 40, "Smoke IT", 1),
            new Vaper(2, "D.Vaper", "Mountain Dew", 30, "Faraos Cigarer", 4),
            new Vaper {Id = 3, Navn = "Aspire PockeX", Aroma = "Vælg ml.: Dragon Treasure, Home Baked, Green Steam", Effekt = 35, Butik = "Smoke It", Uge = 24}
        };

        public void AddVaper(Vaper newVaper)
        {
            vapers.Add(newVaper);
        }

        public Vaper DeleteVaper(int id)
        {
            var deleteVaper = GetOneVaper(id.ToString());
            if (deleteVaper != null)
            {
                vapers.Remove(deleteVaper);
                return deleteVaper;
            }

            return null;
        }

        public Vaper GetOneVaper(string id)
        {
            int idToInt = Int32.Parse(id);
            return vapers.Find(v => v.Id == idToInt);
        }

        public IList<Vaper> GetVapers()
        {
            return vapers;
        }

        public Vaper UpdateVaper(Vaper myVaper)
        {
            var updateVaper = GetOneVaper(myVaper.Id.ToString());
            if (updateVaper != null)
            {
                //updateVaper.Id = myVaper.Id;
                updateVaper.Navn = myVaper.Navn;
                updateVaper.Aroma = myVaper.Aroma;
                updateVaper.Effekt = myVaper.Effekt;
                updateVaper.Butik = myVaper.Butik;
                updateVaper.Uge = myVaper.Uge;
            }
            return null;
        }
    }

}
