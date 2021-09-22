using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_LINQ
{
    internal class Program
    {
        public class Product_
        {
            public int ID { set; get; }
            public string Name { set; get; }         // tên
            public double Price { set; get; }        // giá
            public string[] Colors { set; get; }     // cá màu
            public int Brand { set; get; }           // ID Nhãn hiệu, hãng

            public Product_(int id, string name, double price, string[] colors, int brand)
            {
                ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
            }

            // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
            override public string ToString()
               => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
        }

        public class Brand
        {
            public string Name { set; get; }
            public int ID { set; get; }
        }

        private static void Main(string[] args)
        {
            var brands = new List<Brand>()
            {
    new Brand{ID = 1, Name = "Công ty AAA"},
    new Brand{ID = 2, Name = "Công ty BBB"},
    new Brand{ID = 4, Name = "Công ty CCC"},
            };
            var products = new List<Product_>()
            {
    new Product_(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
    new Product_(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
    new Product_(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
    new Product_(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
    new Product_(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
    new Product_(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
    new Product_(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            // select
            // where
            // SelectMany
            // max, min, sum, average
            // Join, GroupJoin
            // Take(int n) : get n first elements
            // Skip(int n) : ignore n first elements
            // Orderby, OrderByDesencding
            // Reverse
            // Groupby
            // Distinct
            // Single / SingleOrDefault
            // Any, All, Count

            //------------------
            // var kq = products.Select(
            //     (Product_ p) =>
            //     {
            //         return new {
            //             Ten = p.Name,
            //             Gia = p.Price
            //         };
            //     }
            // );
            // var kq = products.SelectMany(
            //     (Product_ p) =>
            //     {
            //         return p.Colors;
            //     }
            // );
            // var kq = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            // {
            //     return new
            //     {
            //         Ten = p.Name,
            //         ThuongHieu = b.Name
            //     };
            // });
            // foreach (var item in kq)
            // {
            //     Console.WriteLine(item);
            // }

            // GroupJoin
            // var kqG = brands.GroupJoin(products, br => br.ID, p => p.Brand, (br, pro) =>
            // {
            //     return new
            //     {
            //         NhanHang = br,
            //         ListSp = pro
            //     };
            // });
            // foreach (var nh in kqG)
            // {
            //     Console.WriteLine(nh.NhanHang.Name);
            //     foreach (var sp in nh.ListSp)
            //     {
            //         Console.WriteLine($"San pham: {sp.Name}");
            //     }
            // }

            // products.Skip(4).ToList().ForEach(p => Console.WriteLine(p.Name));

            // products.OrderBy(
            //     (p) =>
            //     {
            //         return p.Price;
            //     }
            // ).ToList().ToList().ForEach(p => Console.WriteLine(p));

            // products.Sort((p1, p2) =>
            // {
            //     return (p1.Price > p2.Price) ? 1 : -1;
            // });
            // products.ToList().ForEach(p => Console.WriteLine(p));

            // var kqgr = products.GroupBy(p => p.Brand);
            // foreach (var item in kqgr)
            // {
            //     Console.WriteLine(item.Key);
            //     foreach (var pp in item)
            //     {
            //         Console.WriteLine(pp);
            //     }
            // }

            //products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(mau => Console.WriteLine(mau));
            // int[] arrr = {1,2,4,3,2,5,6,4,3,4,2,3,1,2,3,4,32,2,67};
            // arrr.Distinct().ToList().ForEach(item => Console.WriteLine(item));

            //Console.WriteLine(products.Count(p => p.Price >= 300));

            // in ra sanpham thuong hieu, gia (300-400), gia giam dam
            // products.Join(brands, p => p.Brand, br => br.ID, (p, br) =>
            // {
            //     return new
            //     {
            //         Tensp = p.Name,
            //         TenNhanHieu = br.Name,
            //         Gia = p.Price
            //     };
            // }).Where(
            //     (item) =>
            //     {
            //         return item.Gia <= 400 && item.Gia >= 300;
            //     }
            // ).OrderByDescending(item1 => item1.Gia).ToList().ForEach(it => Console.WriteLine(it));
            // other way
            // products.Where(pro => pro.Price >= 300 && pro.Price <= 400)
            //         .OrderByDescending(pro => pro.Price)
            //         .Join(brands, pro => pro.Brand, bra => bra.ID, (pro, bra) =>
            //             new
            //             {
            //                 Tensp = pro.Name,
            //                 TenNhanHieu = bra.Name,
            //                 GiaSp = pro.Price
            //             }
            //         ).ToList().ForEach(ano => Console.WriteLine(ano));

            // var kq = from product in products
            //          from color in product.Colors

            //          where product.Price <= 400 && color == "Xanh"
            //          orderby product.Price descending
            //          select new {
            //              Ten = product.Name,
            //              Gia = product.Price,
            //              Cacmau = product.Colors
            //          };
            //          kq.ToList().ForEach(p=>{
            //              Console.WriteLine($"Ten: {p.Ten}, Gia: {p.Gia}");
            //              Console.WriteLine(string.Join(",",p.Cacmau.ToArray()));
            //          });

            //Nhom sp theo gia
            var qr = from p in products
                     group p by p.Price into tmp_Group
                     orderby tmp_Group.Key
                     let sl = $"So luong sp: {tmp_Group.Count()}"
                     select new
                     {
                         Pr = tmp_Group.Key,
                         Cacsanpham = tmp_Group.ToList(),
                         Sl = sl
                     };

            qr.ToList().ForEach(
                group =>
                {
                    Console.WriteLine(group.Pr);
                    group.Cacsanpham.ForEach(pr => Console.WriteLine(pr));
                    Console.WriteLine(group.Sl);
                }
            );
        }
    }
}