using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Gage
{
    public class DontSleep : IGage
    {
        public bool _involveall = true;
        public bool _involvespecialaction = true;
        public string Status { get; private set; } = "Can Be";
        public string LabelGage { get; private set; } = "Personne ne dois dormir pendant les prochaine 24h";
        public bool InvolveAll { get => _involveall; private set => _involveall = value; }
        public bool InvolveSpecialAction { get => _involvespecialaction; private set => _involvespecialaction = value; }
    }
}
