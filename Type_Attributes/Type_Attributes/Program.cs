using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Type_Attributes
{
    internal class Program
    {
        // Type
        // Attribute
        // Reflection
        // AttributeName
        // attribute duoc su dung o?
        //Custome Attirbute
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
        private class MotaAttribute : Attribute
        {
            public string Thongtinchitiet { get; set; }

            // message
            public MotaAttribute(string _Thongtinchitiet)
            {
                Thongtinchitiet = _Thongtinchitiet;
            }
        }

        // demo using custome attribute
        [Mota("Lop chua user tren he thong")]
        private class User
        {
            [Mota("ten nguoi dung")]
            public string Name { get; set; }

            [Mota("tuoi nguoi dung")]
            public int Age { get; set; }

            [Mota("email nguoi dung")]
            public string Email { get; set; }

            public void PrintInfor() => Console.WriteLine(Name);
        }

        private class Persion
        {
            [Required(ErrorMessage = "Name phai thiet lap")]
            [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Ten phai tu 3 toi 50 ki tu")]
            public string Name { get; set; }

            [Range(10, 80, ErrorMessage = "tuoi phai tu 10 toi 80")]
            public int Age { get; set; }

            [EmailAddress(ErrorMessage = "dia chi email k dung cau truc")]
            public string Email { get; set; }

            public void PrintInfor() => Console.WriteLine(Name);
        }

        private static void Main(string[] args)
        {
            User user = new User()
            {
                Age = 20,
                Email = "haivann2000@gmail.com",
                Name = "Nguyen Van Hai"
            };

            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // GetCustomAttributes - list all user custome attribute
                foreach (var attr in property.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attr as MotaAttribute;
                    if (mota != null)
                    {
                        var value = property.GetValue(user);
                        var name = property.Name;
                        Console.WriteLine($"({name}) - {mota.Thongtinchitiet}: {value}");
                    }
                }
            }

            Persion persion = new Persion()
            {
                Age = 20,
                Email = "haivann2000gmail.com",
                Name = "Ng"
            };
            ValidationContext context = new ValidationContext(persion);
            var result = new List<ValidationResult>();
            // return if all attribute no return error msg
            bool kq = Validator.TryValidateObject(persion, context, result, true);
            if (kq == false)
            {
                // list of error return 
                result.ToList().ForEach(
                    (ValidationResult er) =>
                    {
                        Console.WriteLine(er.MemberNames.First());
                        Console.WriteLine(er.ErrorMessage);
                    }
                );
            }
        }
    }
}