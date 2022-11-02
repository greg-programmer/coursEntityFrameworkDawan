using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ContraintesRelationsWithAnnotations
{
    [Table("t_utilisateurs")]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //la clé est en auto increment
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("firstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        //Proprité dérivée: pas besoin de colonne - demander a EF de l'ignorer 
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; }}

        [Required]
        [DataType(DataType.Password)] //permet de personnaliser le champ de saisie dans les applications web
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }

        [Required]
        [MaxLength(2000)]
        [EmailAddress] //permet de valider le contenu du champ de saisie
        [Index(IsUnique = true)]
        public string Email { get; set; }


        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Adresse { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg")] //valider le champ de saisie
        public string Photo { get; set; }

        [Required]
        [Range(1,10)]
        public int Evaluation { get; set; }

    }
}
