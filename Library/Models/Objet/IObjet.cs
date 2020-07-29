using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IObjet
    {
        public string Name { get; set; }
        public string Icon { get; set; } //fontawesomme icon 
        public string Type { get; set; } //type d'objet
        public void Use();
    }
}
