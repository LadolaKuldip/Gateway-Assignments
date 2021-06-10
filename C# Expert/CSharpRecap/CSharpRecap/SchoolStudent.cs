﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRecap
{
    public class SchoolStudent
    {
        public SchoolStudent(int id, string firstName)
        {
            Id = id;
            FirstName = firstName;
            LastName = String.Empty;
            Age = 0;
            InterestedInSports = false;
            InterestedInMusic = false;
            IsSchoolStudent = true;
            RegisterationTime = DateTime.Now;
            Address = String.Empty;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public bool? InterestedInSports { get; set; }
        public bool? InterestedInMusic { get; set; }
        public bool? IsSchoolStudent { get; set; }
        public DateTime? RegisterationTime { get; set; }
        public string Address { get; set; }
    }
}