using System;
using System.Collections.Generic;

namespace NETCoreMVC.Models.StInforModels
{
    public partial class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public string Dept { get; set; }
    }
}
