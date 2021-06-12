using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRecap.Assignment1
{
    public class CollegeStudent
    {
        public CollegeStudent()
        {
        }
        public CollegeStudent(int id, string firstName, string lastName, int age, bool interestedInSports, bool interestedInMusic, bool isSchoolStudent, DateTime registerationTime, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            InterestedInSports = interestedInSports;
            InterestedInMusic = interestedInMusic;
            IsSchoolStudent = isSchoolStudent;
            RegisterationTime = registerationTime;
            Address = address;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool InterestedInSports { get; set; }
        public bool InterestedInMusic { get; set; }
        public bool IsSchoolStudent { get; set; }
        public DateTime RegisterationTime { get; set; }
        public string Address { get; set; }
    }
}
