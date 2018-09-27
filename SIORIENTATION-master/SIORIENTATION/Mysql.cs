using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SIORIENTATION
{
    class Mysql
    {
        string IP;
        string ID;
        string MDP;
        string NOMBASE;
        MySqlConnection MaBase;
        MySqlDataReader reader;
        public Mysql()
        {
            IP = "172.19.0.16";
            ID = "sio";
            MDP = "0550002D";
            NOMBASE = "ORIENTATION";
        }
        public Mysql(string monIP, string monID, string monMDP, string nomBASE)
        {
            IP = monIP;
            ID = monID;
            MDP = monMDP;
            NOMBASE = nomBASE;
        }
        public void connect()
        {
            MaBase = new MySqlConnection("Server="+ IP + ";Database="+ NOMBASE + ";Uid="+ ID + "; Pwd="+ MDP + ";");
            MaBase.Open();
        }
        public void disconnect()
        {
            MaBase.Close();
        }

        public void ajouterEquipe(int id, string nom, string couleur)
        {
            MySqlCommand cmd = new MySqlCommand ("INSERT INTO `EQUIPE` (`ID`, `NOM`, `COULEUR`) VALUES (?param1, ?param2, ?param3);", MaBase);
            cmd.Parameters.Add(new MySqlParameter("param1", id));
            cmd.Parameters.Add(new MySqlParameter("param2", nom));
            cmd.Parameters.Add(new MySqlParameter("param3", couleur));

            cmd.ExecuteNonQuery();

        }

        public void update(int id, string nom, string couleur)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `EQUIPE` SET `NOM` = ?param2, `COULEUR` = ?param3 WHERE `EQUIPE`.`ID` = ?param1;", MaBase);
            cmd.Parameters.Add(new MySqlParameter("param1", id));
            cmd.Parameters.Add(new MySqlParameter("param2", nom));
            cmd.Parameters.Add(new MySqlParameter("param3", couleur));

            cmd.ExecuteNonQuery();
        }
        public void ajouterParticipant(string nom, string prenom, string mail, int age, string telephone, char sexe, int equipe )
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `PARTICIPANT` (`NOM`, `PRENOM`, `MAIL`, `AGE`, `TELEPHONE`, `SEXE`, `ID_EQUIPE`) VALUES (?param1, ?param2, ?param3, ?param4, ?param5, ?param6, ?param7);", MaBase);
            cmd.Parameters.Add(new MySqlParameter("param1", nom));
            cmd.Parameters.Add(new MySqlParameter("param2", prenom));
            cmd.Parameters.Add(new MySqlParameter("param3", mail));
            cmd.Parameters.Add(new MySqlParameter("param4", age));
            cmd.Parameters.Add(new MySqlParameter("param5", telephone));
            cmd.Parameters.Add(new MySqlParameter("param6", sexe));
            cmd.Parameters.Add(new MySqlParameter("param7", equipe));

            cmd.ExecuteNonQuery();
        }

        public void getPosition()
        {
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT LATITUDE,LONGITUDE FROM LOCALISATION WHERE ID_PARTICIPANT=75", MaBase);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader.GetString(0) + ", " + reader.GetString(1));
            }
        }
        public double getLatitude()
        {

            MySqlCommand command = new MySqlCommand("SELECT LATITUDE FROM LOCALISATION WHERE ID_PARTICIPANT=75", MaBase);
            reader = command.ExecuteReader();
            reader.Read();
            double resultat = Convert.ToDouble(reader.GetString(0));
            reader.Close();
            return resultat;
        }
        public double getLongitude()
        {
            MySqlCommand command = new MySqlCommand("SELECT LONGITUDE FROM LOCALISATION WHERE ID_PARTICIPANT=75", MaBase);
            reader = command.ExecuteReader();
            reader.Read();
            double resultat = Convert.ToDouble(reader.GetString(0));
            reader.Close();
            return resultat;
        }
    }

}
