using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Gage
{
    public interface IGage
    {
        public string Status {get;set;}
        public string LabelGage { get; set; }
        public bool InvolveAll { get; set; }
        public bool InvolveSpecialAction { get; set; }
    }
}
