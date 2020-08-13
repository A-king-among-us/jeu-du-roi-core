using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Playeur
{
    /// <summary>
    /// Class représentatnt une version visible publiquement d'un joueur, permet de seulement communiquer les information accesible par le commun des mortel
    /// </summary>
    public class PublicJoueur
    {
        public PublicJoueur(Joueur WhoIwas)
        {
            Joueur test =WhoIwas ?? throw new ArgumentNullException();
            Name = WhoIwas.Name;
            Surname = WhoIwas.Surname;
            MaxLife = WhoIwas.MaxLife;
            Life = WhoIwas.Life;
            Hapiness = WhoIwas.Hapiness;
            IsDead = WhoIwas.IsDead;
            Gender = WhoIwas.Gender;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email => $"@{Surname}.{Name}";

        public int MaxLife { get; private set; }
        public int Life { get; private set; }
        public int Hapiness { get; private set; }
        public bool IsDead { get; private set; }
        public Genre Gender { get; private set; }
    }
}
