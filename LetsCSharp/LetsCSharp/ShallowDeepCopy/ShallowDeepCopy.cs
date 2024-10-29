using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.ShallowDeepCopy
{
    internal class ShallowDeepCopy
    {
        public void Test()
        {
            int a = 1;
            int b = 2;
            a = b;

            int c = a;

            string s1 = "abc";
            string s2 = "xyz";

            s1 = s2;

        }

        public class DescriptionShallowDeep
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        public class StudentShallowDeep
        {
            public int RollNum { get; set; }
            public string Subject { get; set; }
            public DescriptionShallowDeep Description { get; set; }

            public object ShallowCopy() => this.MemberwiseClone();
            public StudentShallowDeep DeepCopy() => new StudentShallowDeep()
            {
                RollNum = this.RollNum,
                Subject = this.Subject,
                Description = new DescriptionShallowDeep
                {
                    Age = this.Description.Age,
                    FirstName = this.Description.FirstName,
                    LastName = this.Description.LastName,
                }
            };
        }

        public class StudentShallowDeepCheck
        {
            public void Test()
            {
                StudentShallowDeep s = new StudentShallowDeep
                {
                    Description = new DescriptionShallowDeep
                    {
                        Age = 30,
                        FirstName = "Vedika",
                        LastName = "Gujar"
                    },
                    RollNum = 30,
                    Subject = "Maths"
                };

                var shallowCheck = (StudentShallowDeep)s.ShallowCopy();
                shallowCheck.Description.Age = 35;//will change S's age 
                shallowCheck.Description.FirstName = "Vedika N";//will change S's age 
                shallowCheck.Description.LastName = "Gujars";//will change S's age 
                shallowCheck.RollNum = 35;//will change S's age 
                shallowCheck.Subject = "Computer";//will change S's age 

                var deepCheck = s.DeepCopy();
                deepCheck.Description.Age = 45;//will change S's age 
                deepCheck.Description.FirstName = "Vedika 1";//will change S's age 
                deepCheck.Description.LastName = "Gujar";//will change S's age 
                deepCheck.RollNum = 55;//will change S's age 
                deepCheck.Subject = "Computers";//will change S's age 
            }
        }
    }
}
