using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public partial class MyCompanyContext : DbContext
    {

        //public MyCompanyContext()
        //    : base("name=MyCompanyEntities")
        //{
        //}
       // public MyCompanyContext() { }
        public MyCompanyContext(DbContextOptions<MyCompanyContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public  DbSet<ServiceItems> ServiceItems { get; set; }
        public  DbSet<TextFields> TextFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
    public partial class ServiceItems
    {
        [Display(Name = "Название страницы(заголовок)")]
        public string Title { get; set; } = "Информационная страница";
        public string Subtitle { get; set; }
        [Display(Name = "Содержание страницы")]
        public  string Text { get; set; } = "Содержание заполняется администратором";

        public int Id { get; set; }
        [Display(Name = "Титульная картинка")]
        public  string TitleImagePath { get; set; }
        [Display(Name = "SEO метатег Discription")]
        public  string MetaDescription { get; set; }
        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }
        [Display(Name = "SEO метатег KeyWords")]
        public  string MetaKeywords { get; set; }
        [DataType(DataType.Time)]

        public Nullable<System.DateTime> DateAdded { get; set; }
    }
    public partial class TextFields
    {
        public string CodeWord { get; set; }
        [Display(Name = "Название страницы(заголовок)")]
        public  string Title { get; set; } = "Информационная страница";
        [Display(Name = "Содержание страницы")]
        public  string Text { get; set; } = "Содержание заполняется администратором";
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
