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
    
    public partial class Reservation
    {
        public int equipe_fk_id { get; set; }
        public int stade_fk_id { get; set; }
        public Nullable<System.DateTime> date_reservation { get; set; }
    
        public virtual equipe equipe { get; set; }
        public virtual stade stade { get; set; }
    }
}
