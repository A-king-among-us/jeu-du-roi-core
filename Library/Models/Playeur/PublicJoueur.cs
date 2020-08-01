using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Playeur
{
    class PublicJoueur
    {
        public PublicJoueur(Joueur WhoIwas)
        {
            Name = WhoIwas.Name;
            Surname = WhoIwas.Surname;
            MaxLife = WhoIwas.MaxLife;
            Life = WhoIwas.Life;
            Hapiness = WhoIwas.Hapiness;
            IsDead = WhoIwas.IsDead;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email => $"@{Surname}.{Name}";

        public int MaxLife { get; private set; }
        public int Life { get; private set; }
        public int Hapiness { get; private set; }
        public bool IsDead { get; private set; }
    }
}
