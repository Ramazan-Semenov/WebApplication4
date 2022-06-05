using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceItems> ServiceItems { get; set; }
        public DbSet<TextFields> TextFields { get; set; }
    }

    public partial class ServiceItems
    {
        [Display(Name = "Название страницы(заголовок)")]
        public string Title { get; set; } = "Информационная страница";
        public string Subtitle { get; set; }
        [Display(Name = "Содержание страницы")]
        public string Text { get; set; } = "Содержание заполняется администратором";

        public int Id { get; set; }
        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }
        [Display(Name = "SEO метатег Discription")]
        public string MetaDescription { get; set; }
        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }
        [Display(Name = "SEO метатег KeyWords")]
        public string MetaKeywords { get; set; }
        [DataType(DataType.Time)]

        public Nullable<System.DateTime> DateAdded { get; set; }
    }
    public partial class TextFields
    {
        public string CodeWord { get; set; }
        [Display(Name = "Название страницы(заголовок)")]
        public string Title { get; set; } = "Информационная страница";
        [Display(Name = "Содержание страницы")]
        public string Text { get; set; } = "Содержание заполняется администратором";
        public int Id { get; set; }
        public string Subtitle { get; set; }
        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }
        [Display(Name = "SEO метатег Discription")]
        public string MetaDescription { get; set; }
        [Display(Name = "SEO метатег Title")]

        public string MetaTitle { get; set; }
        [Display(Name = "SEO метатег KeyWords")]

        public string MetaKeywords { get; set; }
        [DataType(DataType.Time)]
        public Nullable<System.DateTime> DateAdded { get; set; }
    }
}
