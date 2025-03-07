//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace diary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class broker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public broker()
        {
            this.appointments = new HashSet<appointment>();
        }
    
        public int idBroker { get; set; }

        [Required(ErrorMessage = "Champ requis")] //champ requis
        [StringLength(50)] // 50 caracs. max
        [DisplayName("Nom de famille")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [StringLength(50)]
        [DisplayName("Prénom")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [StringLength(100)]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Adresse mail non valide")] //regex mail
        [DisplayName("Adresse Mail")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [StringLength(10)]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numéro de télephone non valide.")] //regex tél.
        [DisplayName("Numéro de télephone")]
        public string phoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointments { get; set; }
    }
}
