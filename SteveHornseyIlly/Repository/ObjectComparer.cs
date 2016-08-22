using System;
using System.Collections.Generic;
using System.Reflection;
using SteveHornseyIlly.Model;
using System.Text.RegularExpressions;

namespace SteveHornseyIlly.Repository
{
    public class ObjectComparer
    {
        public List<Difference> CompareObject(Object Object1, Object Object2)
        {
            //In my opinion storing the differences in an object and then creating the output lines is better, as the output object can
            //then be used and parsed by systems later on. Plus it would make it easier to replace the horribe cmd input form and
            //replace with a web page.

            if (Object.ReferenceEquals(Object1, Object2))
            {
                //objects are references of the same object 
                return new List<Difference>();
            }
            var differnces = new List<Difference>();
            differnces = GetDifferences(Object1, Object2);
            return differnces;  
        }

        private List<Difference> GetDifferences(Object Object1, Object Object2)
        {
            var differnces = new List<Difference>();
            var object1Properties = GetProperties(Object1);
            var object2Properties = GetProperties(Object2);
            foreach (var prop in object1Properties)
            {
                var Value1 = prop.GetValue(Object1, null);
                var Value2 = prop.GetValue(Object2, null);

                if (!Value1.Equals(Value2))
                {
                    //Could reformat datetime as date but we might want to show the time element of some dates so date of birth will show time element.
                    differnces.Add(new Difference
                    {
                        PropertyName = formatPropertyName(prop.Name),
                        Value1 = Value1.ToString(),
                        Value2 = Value2.ToString()
                    });
                }
            }
            return differnces;
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        private string formatPropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, "([a-z])([A-Z])", "$1 $2");
            //I couldn't think how to change DateOfBirth to Date of Birth, with 'of' as lower case and 'Birth' like the specification states
            //as upper case without having an extra property of display name. Which in my opinion would weaken the program as it then
            //couldn't work with any object. So I used a regular expression which keeps the letters as upper case but adds the space this 
            //is the kind of requirement I would always check before changing at my own whim and even then I would consult a collegue before hand.

        }
    }
}
