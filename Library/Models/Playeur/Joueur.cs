using System;

namespace Library.Models.Playeur
{
    public enum Genre
    {
        Unknow = 0,
        Female = 1,
        Male = 2,
        TooMuchDifficulties = Male | Female
    }
    public class Joueur
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string ConnectionID { get; private set; }
        public string Email => $"@{Surname}.{Name}";
        public bool IsKing = false;
        public Genre Gender { get; private set; }


        public Joueur(int agi, int str, int vit, int intel, int perce,string name,string surname,string connectionID,int gender)
        {
            if ((agi + str + vit + intel + perce) == MaxPointStat+5)
            {
                _agi = agi;
                _str = str;
                _vit = vit;
                _intel = intel;
                _perce = perce;
                Name = name;
                Surname = surname;
                ConnectionID = connectionID;
                Gender = (Genre)gender;
            }
            else
                throw new Exception("Les stat du joueur ne sont pas bonne");
            
        }
        public Joueur(string connectionID) => ConnectionID = connectionID;

        //Statistique variable 
        private int _agi = 0;
        private int _str = 0;
        private int _vit = 5;
        private int _intel = 0;
        private int _perce = 0;

        //Statistique property
        public int AGI { get => _agi; private set { _agi = value >= 0 && value <= MaxPerStat ? value : _agi; } }
        public int STR { get => _str; private set { _str = value >= 0 && value <= MaxPerStat ? value : _str; } }
        public int VIT { get => _vit; private set { _vit = value >= 0 && value <= MaxPerStat ? value : _vit; } }
        public int INT { get => _intel; private set { _intel = value >= 0 && value <= MaxPerStat ? value : _intel; } }
        public int PER { get => _perce; private set { _perce = value >= 0 && value <= MaxPerStat ? value : _perce; } }

        //Status variable 
        private int _money = 0;
        private int _life = 10;
        private int _happiness = 50;
        private int _stress = 0;
        private int _love;
        private int _stamina;

        //status property
        public int Money { get => _money; private set { _money = value; } }
        public int Life { get => _life; private set { _life = value; } }
        public int Hapiness { get => _happiness; private set { _happiness = value; } }
        public int Stress { get => _stress; private set { _stress = value; } }
        public int Love { get => _love; private set { _love = value; } }
        public int Stamina { get => _stamina; private set { _stamina = value; } }

        //status Max property
        public int MaxLife => _vit * 2;
        public int MaxHapiness => 100;
        public int MaxStress => 50;
        public int MaxLove => 50; //date a live ?
        public int MaxStamina => _vit + _stamina + _str; //a équilibrer j'ai pas encore spéciallement d'idée

        public static int MaxPerStat = 20;
        public static int MaxPointStat = 40;

        //Status Spéciphique
        public bool IsInLove => _love >= 30;
        public bool IsTired => _stamina <= 0;
        public bool IsDead => _life == 0;
        public bool IsStressed => _stress > (MaxStress/2);
        public bool IsHappy => _happiness > (MaxHapiness / 2);
        public bool IsDepressed => _happiness < (MaxHapiness / 2);
        public bool IsOutOFMoney => _money<= 0;

        /// <summary>
        /// Permet de définir si un joueur peux acheter telle ou telle objet
        /// </summary>
        /// <param name="price">Prix de l'objet a acheter</param>
        /// <returns></returns>
        public bool Canbuy(int price) => (_money- price) >= 0; 

        /// <summary>
        /// Nom du joueur aimer dans la partie
        /// </summary>
        public string LovedOne { get; private set; }

        /// <summary>
        /// dis si oui ou non le joueur est mort
        /// </summary>
        public void die() => _life = 0;

        /// <summary>
        /// permet de comparer si le joueur est le propriétaire de l'iD 
        /// </summary>
        /// <param name="other"> Autre joueur</param>
        /// <returns></returns>
        public bool Equals(Joueur other) => other.ConnectionID == this.ConnectionID ? true : false;
    }
}
