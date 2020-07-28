using System;

namespace Library.Models.Joueur
{
    public class Joueur
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private bool IsKing = false;

        //Statistique variable 
        private int _agi = 0;
        private int _str = 0;
        private int _vit = 5;
        private int _intel = 0;
        private int _perce = 0;

        //Statistique property
        public int AGI { get => _agi; private set { _agi = value >= 0 && value <= 20 ? value : _agi; } }
        public int STR { get => _str; private set { _str = value >= 0 && value <= 20 ? value : _str; } }
        public int VIT { get => _vit; private set { _vit = value >= 0 && value <= 20 ? value : _vit; } }
        public int INT { get => _intel; private set { _intel = value >= 0 && value <= 20 ? value : _intel; } }
        public int PER { get => _perce; private set { _perce = value >= 0 && value <= 20 ? value : _perce; } }

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
        public int MaxStamina => _vit + _stamina + _str; //a équilibrer j'ai pas enore spéciallement d'idée

        //Status Spéciphique
        public bool IsInLove => _love >= 30;
        public bool IsTired => _stamina <= 0;
        public bool IsDead => _life == 0;
        public bool IsStressed => _stress > (MaxStress/2);
        public bool IsHappy => _happiness > (MaxHapiness / 2);
        public bool IsDepressed => _happiness < (MaxHapiness / 2);
        public bool IsOutOFMoney => _money<= 0;

        public bool Canbuy(int price) => (_money- price) >= 0; 

        public string LovedOne { get; private set; }
    }
}
