using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop01.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Department { get; set; }
        public Double GPA { get; set; }
        public BitmapImage Image { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public User(string firstName, string lastName, string gender, string dateOfBirth, string department, double gpa, BitmapImage image)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Department = department;
            GPA = gpa;
            Image = image;

        }

        public User()
        {
        }
    }
}
