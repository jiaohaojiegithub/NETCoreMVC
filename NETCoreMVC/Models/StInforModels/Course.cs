using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETCoreMVC.Models.StInforModels
{
    public partial class Course
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Credit { get; set; }
        public int? CourseNum { get; set; }
    }
}
