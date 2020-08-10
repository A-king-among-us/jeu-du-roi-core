using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// interface qui représente les objet disponible dans le jeux
    /// </summary>
    public interface IObjet
    {
        public string Name { get; set; }
        public string Icon { get; set; } //fontawesomme icon ou icon normale
        public string Type { get; set; } //type d'objet
        public void Use(); //action que peux effectuer l'objet
    }
}
