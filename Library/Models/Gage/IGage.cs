using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Gage
{
    /// <summary>
    /// Gage disponible dans le jeux
    /// </summary>
    public interface IGage
    {
        public string Status {get;} //meurtrier ou non
        public string LabelGage { get; } //le message qui représente le gage
        public bool InvolveAll { get; } //si ce gage correspond a tout les membre
        public bool InvolveSpecialAction { get; } //nécessite une action spéciale type chatouille ou autre
    }
}
