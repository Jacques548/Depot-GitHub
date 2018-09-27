using CsvHelper;
using CsvHelper.Configuration;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIORIENTATION
{

    public partial class Orientation : Form
    {
        Mysql connection;
        OpenFileDialog import;
        List<Participant> LesParticipants;
        List<Equipe> lesEquipes;
        public Orientation()
        {
            InitializeComponent();
            connection = new Mysql();

            //GMAP INITIALISATION
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(48.772104, 5.159856);

            //MARQUEUR GMAP
            connection.connect();

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(connection.getLatitude(), connection.getLongitude()),
              GMarkerGoogleType.green);
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application SIORIENTATION Version 0.1");
        }

        private void démarrerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Orientation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            import = new OpenFileDialog();
            import.ShowDialog();
            string startPath = @import.FileName;

            LesParticipants = ReadFile<Participant>(startPath);
            this.lesEquipes = new List<Equipe>();
            // créer la liste d'équipes
            foreach (Participant p in LesParticipants)
            {
                bool trouve = false;
                foreach (Equipe eq in this.lesEquipes)
                {
                    if (eq.Id == p.NumEquipe)
                    {
                        trouve = true;
                    }
                }
                if (!trouve)
                {
                    Equipe equipe = new Equipe();
                    equipe.Id = p.NumEquipe;
                    this.lesEquipes.Add(equipe);
                }
            }
            foreach (Equipe eq in this.lesEquipes)
            {
                Mysql bdd = new Mysql();
                bdd.connect();
                bdd.ajouterEquipe(eq.Id, " ", " ");
                this.comboBox1.Items.Add(eq.Id);
            }
            foreach (Participant p in LesParticipants)
            {
                Mysql bdd = new Mysql();
                bdd.connect();
                bdd.ajouterParticipant(p.Nom, p.Prenom, p.Mail, p.Age, p.Telephone, p.Sexe, p.NumEquipe);
            }
        }

        private List<T> ReadFile<T>(string startPath) where T : class
        {
            List<T> result = new List<T>();
            using (TextReader tr = new StreamReader(startPath, Encoding.GetEncoding(1252)))
            {
                var csv = new CsvReader(tr);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HeaderValidated = null;
                result = csv.GetRecords<T>().ToList();
            }
            return result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string couleur = textBox2.Text;
            int Id = Convert.ToInt32(comboBox1.SelectedItem);
            Mysql bdd = new Mysql();
            bdd.connect();
            bdd.update(Id, nom, couleur);
        }
    }
}
