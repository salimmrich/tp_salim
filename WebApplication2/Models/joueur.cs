//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class joueur
    {
        public int joueur_id { get; set; }
        public string Joueur_nom { get; set; }
        public string joueur_prenom { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> joueur_fk_equipe_id { get; set; }
    
        public virtual equipe equipe { get; set; }
    }
}