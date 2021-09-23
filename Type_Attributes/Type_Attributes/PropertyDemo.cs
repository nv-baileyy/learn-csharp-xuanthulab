using System;
using System.Linq;
using System.Reflection;

namespace Type_Attributes
{
    internal class PropertyDemo
    {
        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }

        public void Process()
        {
            int[] a = { 1, 2, 3 };
            Type t = a.GetType();
            Console.WriteLine(t.FullName);
            t.GetProperties().ToList().ForEach(
                (PropertyInfo o) =>
                {
                    Console.WriteLine(o.Name);
                }
            );
            User user = new User()
            {
                Age = 20,
                Email = "haivann2000@gmail.com",
                Name = "Nguyen Van Hai"
            };
            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                var value = property.GetValue(user);
                Console.WriteLine($"{name} : {value}");
            }
        }
    }
}