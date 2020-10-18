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
        public string Email => $"@{Name}.{Surname}";
        public bool IsKing = false;
        public string WhereHeIs { get; set; }
        public Genre Gender { get; private set; }


        public Joueur(int agi, int str, int vit, int intel, int perce,string name,string surname,string connectionID,int gender)
        {
            if (ValidatorStat(agi) || ValidatorStat(str) || ValidatorStat(vit) || ValidatorStat(intel) || ValidatorStat(perce))
                throw new Exception("Stat incorrect, one or multiple stat isnt in the max or minimal boundadrie of 0->20");
            if ((agi + str + vit-5 + intel + perce) == MaxPointStat)
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
        private int _love = 30;
        private int _stamina = 10;

        //status property
        public int Money { get => _money; private set { _money = value; } }
        public int Life { get => _life; private set { _life = value; } }
        public int Hapiness { get => _happiness; private set { _happiness = value; } }
        public int Stress { get => _stress; private set { _stress = value; } }
        public int Love { get => _love; private set { _love = value; } }
        public int Stamina { get => _stamina; private set { _stamina = value; } }

        //status Max property
        /// <summary>
        /// Get the m
        /// </summary>
        public int MaxLife => _vit * 2;
        public static int MaxHapiness => 100;
        public static int MaxStress => 50;
        public static int MaxLove => 50; //date a live ?
        public int MaxStamina => _vit + _stamina + _str; //a équilibrer j'ai pas encore spéciallement d'idée

        public static int MaxPerStat = 20;
        public static int MaxPointStat = 40;

        //Status Spéciphique
        /// <summary>
        /// Say if the player is able to enter a love state
        /// </summary>
        public bool CanBeInLove => _love >= 30;
        /// <summary>
        /// Say if the player is tired
        /// </summary>
        public bool IsTired => _stamina <= 0;
        /// <summary>
        /// Say if the player is dead (life<=0)
        /// </summary>
        public bool IsDead => _life <= 0;
        /// <summary>
        /// Say if the player is in a stressed state
        /// </summary>
        public bool IsStressed => _stress > (MaxStress/2);
        /// <summary>
        /// Say if the playeur is in a hapy state
        /// </summary>
        public bool IsHappy => _happiness > (MaxHapiness / 2);
        /// <summary>
        /// Say if the playeur is in a depressed state
        /// </summary>
        public bool IsDepressed => _happiness < (MaxHapiness / 2);
        /// <summary>
        /// Say if the platyeur has run out of money
        /// </summary>
        public bool IsOutOFMoney => _money<= 0;

        /// <summary>
        /// Permet de définir si un joueur peux acheter telle ou telle objet
        /// </summary>
        /// <param name="price">Prix de l'objet a acheter</param>
        /// <returns></returns>
        public bool HaveEnoughToBuy(int price) => (_money- price) >= 0; 

        /// <summary>
        /// Nom du joueur aimer dans la partie
        /// </summary>
        public string LovedOne { get; private set; }

        /// <summary>
        /// Kille the current player
        /// </summary>
        public void KillThePlayer() => _life = 0;

        /// <summary>
        /// permet de comparer si le joueur est le propriétaire de l'iD 
        /// </summary>
        /// <param name="other"> Autre joueur</param>
        /// <returns></returns>
        public bool Equals(Joueur other) => other.ConnectionID == this.ConnectionID ? true : false;

        public static bool ValidatorStat(int num) => num < 0 || num > MaxPerStat;
    }
}
