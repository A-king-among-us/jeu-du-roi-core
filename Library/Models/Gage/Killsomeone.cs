using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Gage
{
    public class Killsomeone : IGage
    {
        public string _victime = "";
        private string _labelgage = "Tu dois tuer quelqu'un";
        public bool _involveall = false;
        public bool _involvespecialaction = true;
        public string Status { get; private set; } = "Meurtrier";
        public string LabelGage { get => $"{_labelgage} {_victime}"; private set => _labelgage = value; }
        public bool InvolveAll { get =>_involveall; private set => _involveall=value; }
        public bool InvolveSpecialAction { get => _involvespecialaction; private set => _involvespecialaction=value; }
    }
}
