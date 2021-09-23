// Entity -> Database, Table...
// Database - SQL Server : data1 -> DbContext
// -- Product

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Models;

namespace EDCore
{
    internal class CRUD
    {
        /*

        static void ReadData()
        {
            using var dbContext = new ShopContext();
            // Linq
            dbContext.products.ToList().ForEach(
                (Product p) =>
                {
                    p.PrintInfor();
                }
            );
        }
        static void RenameData(int id, string newname)
        {
            using var dbContext = new ShopContext();
            // Linq
            Product p = (from item in dbContext.products
                         where item.ProductID == id
                         select item
                            ).FirstOrDefault();
            int row_effected = 0;
            if (p != null)
            {
                // su dung Linq thi product van duoc giam sat bowi dbcontext, moi su thay doi trong product sau SaveChange() se dc update trong db
                //
                EntityEntry<Product> entry = dbContext.Entry(p);
                entry.State = EntityState.Detached;
                // untracking from dbcontext
                p.ProductName = newname;
                row_effected = dbContext.SaveChanges();
            }
            Console.WriteLine($"Row effected: {row_effected}");
        }
        static void DeleteData(int id)
        {
            using var dbContext = new ShopContext();
            // Linq
            Product p = (from item in dbContext.products
                         where item.ProductID == id
                         select item
                            ).FirstOrDefault();
            int row_effected = 0;
            if (p != null)
            {
                // su dung Linq thi product van duoc giam sat bowi dbcontext, moi su thay doi trong product sau SaveChange() se dc update trong db
                //
                // EntityEntry<Product> entry = dbContext.Entry(p);
                // entry.State = EntityState.Detached;
                // untracking from dbcontext
                dbContext.Remove(p);
                row_effected = dbContext.SaveChanges();
            }
            Console.WriteLine($"Row effected: {row_effected}");
        }
        */
    }

    internal class Program
    {
        private static void CreateDatabase()
        {
            using var dbContext = new ShopContext();
            string dbname = dbContext.Database.GetDbConnection().Database;

            // check on sql server:
            // - if dbName not exist, create on sql server
            var kq = dbContext.Database.EnsureCreated();
            if (kq == true)
            {
                Console.WriteLine($"tao csdl {dbname} thanh cong!");
            }
            else
            {
                Console.WriteLine("Tao khong thanh cong");
            }
        }

        private static void DropDatabase()
        {
            using var dbContext = new ShopContext();
            string dbname = dbContext.Database.GetDbConnection().Database;

            // check on sql server:
            // - if dbName exist, delete on sql server
            var kq = dbContext.Database.EnsureDeleted();
            if (kq == true)
            {
                Console.WriteLine($"xoa csdl {dbname} thanh cong!");
            }
            else
            {
                Console.WriteLine("khong xoa duoc databasae");
            }
        }

        private static void InsertData()
        {
            using var _context = new ShopContext();

            List<Product> pros = new List<Product>();
            pros.Add(new Product() { Name = "San pham 1", Price = 100, CategID = 1 });
            pros.Add(new Product() { Name = "San pham 2", Price = 200, CategID = 1 });
            pros.Add(new Product() { Name = "San pham 3", Price = 300, CategID = 2 });
            pros.Add(new Product() { Name = "San pham 4", Price = 400, CategID = 2 });
            pros.Add(new Product() { Name = "San pham 5", Price = 500, CategID = 1 });

            List<Category> cates = new List<Category>();
            cates.Add(new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" });
            cates.Add(new Category() { Name = "Do uong", Description = "Cac loai do uong" });

            _context.AddRange((object[])cates.ToArray());
            int row_effected = _context.SaveChanges();
            Console.WriteLine($"Number row category effected: {row_effected}");

            _context.AddRange((object[])pros.ToArray());
            row_effected = _context.SaveChanges();
            Console.WriteLine($"Number row products effected: {row_effected}");
        }

        private static void ReferenceNavigation()
        {
            using var _context = new ShopContext();
            var res = from item in _context.products select item;
            res.ToList().ForEach(
                p =>
                {
                    // by default, references entiry is null in FK
                    // use tracking to load category to product
                    var e = _context.Entry(p);
                    e.Reference(pro => pro.category).Load();
                    //
                    if (p.category == null) Console.WriteLine("Catefory is null");
                    else
                    {
                        Console.WriteLine($"{p.category.Name} - {p.category.Description}");
                    }
                }
            );
        }

        private static void CollectionNavigation()
        {
            using var _context = new ShopContext();
            _context.categories.ToList().ForEach(
                cate =>
                {
                    // collection navigation
                    // mac dinh, cac bien kieu tham chieu trong model se co gia tri null
                    // su dung entiryEntry de tracking du lieu duoc tham chieu toi
                    var e = _context.Entry(cate);
                    e.Collection(c => c.products).Load();
                    //
                    if (cate.products == null) Console.WriteLine("product is null");
                    else
                    {
                        cate.products.ForEach(p => p.PrintInfor());
                    }
                }
            );
        }

        private static void Main(string[] args)
        {
            DropDatabase();
            CreateDatabase();
            // InsertData();
            // RenameData(1, "San pham fake");
            // DeleteData(4);
            // ReadData();

            // CollectinbsjgkonNavigation();
        }
    }
}