using System;
using System.Collections.Generic;
using System.Linq;

// Anonymous - kieu vo danh
// object  - thuoc tinhs, chi doc
// new {thuoctinh = gia tri 1, thuoctinh2 = gia tri 2}
// dynamic - kieu du lieu dong, kiểu dữ liệu được xác định khi thực thi chạy chương trình. 
// khac voi var, kieu du lieu duoc ngam dinh ngay khi gan gia tri cho no

namespace Basic_Anonymous
{
    public class Program
    {
        public class sinhvien
        {
            public string HoTen { get; set; }
            public int Namsinh { get; set; }
        }
        static void Main(string[] args)
        {
            // anonymous type example
            var sp = new
            {
                Ten = "Abc",
                Gia = 12,
                Namsx = 2000
            };
            Console.WriteLine(sp.Gia + " " + sp.Ten);
            List<sinhvien> cacsv = new List<sinhvien>(){
                new sinhvien(){HoTen = "Nguyen Van A", Namsinh = 2000},
                new sinhvien(){HoTen = "Nguyen Hoang A", Namsinh = 2002},
                new sinhvien(){HoTen = "Nguyen Yen A", Namsinh = 2012}
            };
            var kq = from sv in cacsv
                     where sv.Namsinh <= 2020
                     // Most of anonymous type used in Linq Syntax
                     select new
                     {
                         Ten = sv.HoTen,
                         NS = sv.Namsinh
                     };
            foreach (var item in kq)
            {
                Console.WriteLine(item.Ten + " " + item.NS);
            }
            // dynamic tenbien;
        }
    }
}
