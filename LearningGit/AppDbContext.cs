using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningGit
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){}

        public DbSet<Title> Titles { get; set; }
        public DbSet<Step> Steps { get; set; }
    }

   public class Title
    {
        [Display(Name="Title")]
        public int TitleID { get; set; }
        [Display(Name ="Order")]
        public int? TitleOrder { get; set; }
        [Display(Name ="Text")]
        public string TitleText { get; set; }
        public ICollection<Step> Steps { get; set; }
    }

    public class Step
    {
        public int StepID { get; set; }
        [Display(Name ="Order")]
        public int? StepOrder { get; set; }
        [Display(Name ="Description")]
        public string StepText { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Code")]
        public string StepCode { get; set; }

        public int TitleID { get; set; }
        public Title Title { get; set; }
    }
}
