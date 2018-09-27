using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIORIENTATION
{
    class Participant
    {
        private int id;
        private string nom;
        private string prenom;
        private string mail;
        private int age;
        private string telephone;
        private char sexe;
        private int numEquipe;
        
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public char Sexe { get => sexe; set => sexe = value; }
        public int NumEquipe { get => numEquipe; set => numEquipe = value; }

        public Participant(string Lenom, string Leprenom, string Lemail, int Lage, string Letelephone, char Lesexe, int lequipe)
        {
            this.nom = Lenom;
            this.prenom = Leprenom;
            this.mail = Lemail;
            this.age = Lage;
            this.telephone = Letelephone;
            this.sexe = Lesexe;
            this.NumEquipe = lequipe;
        }

        public string toString()
        {
            return "id : " + this.id + "\n" + "nom : " + this.nom + "\n" + "prenom : " + this.prenom + "\n" + "age : " + this.age + "\n" + "telephone : " + this.telephone + "\n" + "sexe : " + this.sexe + "\n";
        }
    }
}
