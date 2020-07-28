using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Joueur
{
    class PublicJoueur
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public int MaxLife { get; private set; }
        public int Life { get; private set; }
        public int Hapiness { get; private set; }
        public bool IsDead { get; private set; }
    }
}
