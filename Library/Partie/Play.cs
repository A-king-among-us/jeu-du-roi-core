using Library.Models.Playeur;
using System.Collections.Generic;

namespace Library.Partie
{
    public class Play
    {
        public List<Joueur> _ListDeJoueur = new List<Joueur>();
        public string GroupName { get; private set; }
        public int Turn { get; private set; }
        public int NbrJoueur => _ListDeJoueur.Count;

        public Play(string Groupname)
        {
            GroupName = Groupname;
        }
        /// <summary>
        /// Fonction d'instanciation d'un nouveau joueur
        /// </summary>
        /// <param name="agi">Stat d'agilité du joueur</param>
        /// <param name="str">Stat de Force</param>
        /// <param name="vit">Stat de Vitalité</param>
        /// <param name="intel">Stat d'intelligence</param>
        /// <param name="perce">Stat de Perception</param>
        /// <param name="name">Nom du joueur</param>
        /// <param name="surname">Nom de famille du joueur</param>
        /// <param name="ConnexionID">Id de connexion du joueur</param>
        /// <returns></returns>
        public bool NewPlayeur(int agi, int str, int vit, int intel, int perce, string name, string surname, string ConnexionID)
        {
            if ((agi + str + vit + intel + perce) != Joueur.MaxPointStat)
            {
                try
                {
                    _ListDeJoueur.Add(new Joueur(agi, str, vit, intel, perce, name, surname, ConnexionID));
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Donne le Joueur public d'un joueur dont on connais le nom de famille (unique aux cours d'une partie)
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public PublicJoueur GetPlayeur(string surname) => new PublicJoueur(_ListDeJoueur.Find(e => e.Surname == surname));

        public Joueur GetMyself(string connectionID) => _ListDeJoueur.Find(e => e.ConnectionID == connectionID);

        public string GetName(string ConnectID) => _ListDeJoueur.Find(e => e.ConnectionID == ConnectID).Name;

        public string GetConnectIDfrommail(string Email) => _ListDeJoueur.Find(e => e.Email == Email).ConnectionID;
        public bool MailExist(string Email)
        {
            try
            {
                _ListDeJoueur.Find(e => e.Email == Email);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<PublicJoueur> GetAllPlayeur()
        {
            List<PublicJoueur> publicjoueur = new List<PublicJoueur>();
            foreach (Joueur treatedone in _ListDeJoueur)
                publicjoueur.Add(new PublicJoueur(treatedone));
            return publicjoueur;
        }

        public string DisconnectPlayeur(string ConnectID)
        {
            if (_ListDeJoueur.Contains(new Joueur(ConnectID)))
            {
                _ListDeJoueur.Find(e => e.ConnectionID == ConnectID).die();
                return $"{ _ListDeJoueur.Find(e => e.ConnectionID == ConnectID).Name} Est mort en fuillant... il a fait une chute de son lits"; //ajouter des message random
            }
            else
                return "";
        }
    }
}