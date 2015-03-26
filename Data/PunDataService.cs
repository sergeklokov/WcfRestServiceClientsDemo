using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class PunDataService
    {
        private List<Pun> _puns;
        private void generatePuns()
        {
            _puns = new List<Pun>
            {
                new Pun{Joke ="Why can't a bike stand on its own? It's two tired!", PunID = 0, Title = "Lazy Bike"},
                new Pun{Joke ="Red face", PunID = 1, Title = "Face"},
                new Pun{Joke ="Baby face made", PunID = 2, Title = "Baby Face"},
                new Pun{Joke ="Big cheeks", PunID = 3, Title = "Cheeks"},
                new Pun{Joke ="Show tongue", PunID = 4, Title = "Tongue"},
            };
        }

        public Pun[] GetPuns()
        {
            if (_puns == null)
                generatePuns();

            return _puns.ToArray();
        }

        public Pun GetPunById(long punID)
        {
            if (_puns == null)
                generatePuns();

            return _puns.Find(p=>p.PunID == punID);
        }

        public Pun AddPun(Pun pun)
        {
            if (_puns == null)
                generatePuns();

            pun.PunID = _puns.Count;
            _puns.Add(pun);

            return GetPunById(_puns.Count-1);
        }

        public Pun UpdatePun(long punID, Pun pun)
        {
            if (_puns == null)
                generatePuns();

            var p = GetPunById(punID);

            p.Joke = pun.Joke;
            p.Title = pun.Title;
            p.PunID = punID;

            return p;
        }
    }
}