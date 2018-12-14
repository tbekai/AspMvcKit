using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AspProject.Models
{
    [Table("Users")]
    public class User : Model
    {
     

        [Required(ErrorMessage = "Nom d'utilisateur requis")]
        [DisplayName("Nom d'utilisateur")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Adresse email requise")]
        [DisplayName("Adresse Email")]
        [StringLength(64)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mot de passe requis")]
        [DisplayName("Mot de passe")]
        [MinLength(8)]
        [MaxLength(63)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [NotMapped]
        [HiddenInput(DisplayValue = false)]
        public bool IsAuthenticated { get; set; } = false;

        public User()
        {

        }
        //public string Lastname { get; set; }

        //public string Firstname { get; set; }
       /* public void Copy(User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.Password = user.Password;
            //this.Lastname = user.Lastname;
            //this.Firstname = user.Firstname;
        }*/

        public override void UpdateFrom(Model source)
        {
            if (source is User user && user.Id == Id)
            { this.Username = user.Username;
                this.Email = user.Email;
            }
        }
    }
}