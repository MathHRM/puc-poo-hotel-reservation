using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Room
    {
        [Key]
        public int Number { get; set; }
        public string Description {  get; set; }
        public double Preco { get; set; }
        public string ImgURL { get; set; }

    }
}

