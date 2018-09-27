using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIORIENTATION
{
    class Course
    {
        private int id;
        private string nom;
        private string description;
        private string ville;
        private string heure_Debut;
        private string heure_Fin;

        public Course(string Lenom, string Ladescription, string Laville, string Lheure_Debut, string Lheure_Fin)
        {
            this.nom = Lenom;
            this.description = Ladescription;
            this.ville = Laville;
            this.heure_Debut = Lheure_Debut;
            this.heure_Fin = Lheure_Fin;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Description { get => description; set => description = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Heure_Debut { get => heure_Debut; set => heure_Debut = value; }
        public string Heure_Fin { get => heure_Fin; set => heure_Fin = value; }

        public string toString()
        {
            return "id : " + this.id + "\n" + "nom : " + this.nom + "\n" + "ville : " + this.ville + "\n" + "Heure Debut : " + this.heure_Debut + "\n" + "Heure Fin : " + this.heure_Fin;
        }
   
    }
}
