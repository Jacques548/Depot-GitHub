using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIORIENTATION
{
    class Equipe
    {
        private int id;
        private string nom;
        private string couleur;
        private List<Participant> lesParticipants;

        public Equipe(string Lenom, string lacouleur)
        {
            this.nom = Lenom;
            this.couleur = lacouleur;
            this.lesParticipants = new List<Participant>();
        }
        public Equipe()
        {
            this.lesParticipants = new List<Participant>();
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        internal List<Participant> LesParticipants { get => lesParticipants; set => lesParticipants = value; }







        public string toString()
        {
            return "id : " + this.id + "\n" + "Nom : " + this.nom + "\n" + "couleur : " + this.couleur + "\n";
        }
    }

    
}
