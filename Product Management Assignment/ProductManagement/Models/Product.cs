using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Product
    {
        
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Product's Name.")]
        public String Name { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Please Enter Product's Price.")]
        public float Price { get; set; }

        [Display(Name = "Product Quantity")]
        [Required(ErrorMessage = "Please Enter Product's Quantity.")]
        public int Quantity { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Please Enter Product's Short Discription.")]
        [StringLength(250, MinimumLength = 2)]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Display(Name = "Small Image")]
        public string SmallImagePath { get; set; }

        [Display(Name = "Large Image")]
        public string LargeImagePath { get; set; }


        public Category Category { get; set; }

        [Display(Name = " Product Category")]
        [Required]
        public int CategoryId { get; set; }

        [NotMapped]
        public HttpPostedFileBase SmallImageFile { get; set; }

        [NotMapped]
        public HttpPostedFileBase LargeImageFile { get; set; }
    }
}