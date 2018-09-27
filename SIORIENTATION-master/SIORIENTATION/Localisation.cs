using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIORIENTATION
{
    class Localisation
    {
        private int id;
        private string date;
        private string latitude;
        private string longitude;


        public Localisation(string Ladate, string Lalatitude, string Lalongitude)
        {
            this.date = Ladate;
            this.latitude = Lalatitude;
            this.longitude = Lalongitude;
        }

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }

        public string toString()
        {
            return "id : " + this.id + "\n" + "Date : " + this.date + "\n" + "Latitude : " + this.latitude + "\n" + "Longitude : " + this.longitude;
        }

    }
}
