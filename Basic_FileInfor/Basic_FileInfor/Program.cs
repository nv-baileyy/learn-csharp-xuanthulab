using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Basic_FileInfor
{
    internal class Program
    {
        private static void PrintProperties(Type type, object ob)
        {
            type.GetProperties().ToList().ForEach(
               (PropertyInfo p) =>
               {
                   Console.Write(p.Name + ": " + p.GetValue(ob) + "\n");
               }
           );
        }

        private static void GetDriveInfor()
        {
            DriveInfo.GetDrives().ToList().ForEach(
                (DriveInfo drive) =>
                {
                    Console.WriteLine($"Drive: {drive.Name}");
                    Console.WriteLine($"Drive Type: {drive.DriveType}");
                    Console.WriteLine($"Lable: {drive.VolumeLabel}");
                    Console.WriteLine($"Format: {drive.DriveFormat}");
                    Console.WriteLine($"Drive: {drive.TotalSize}");
                    Console.WriteLine($"TotalFreeSpace: {drive.TotalFreeSpace}");
                    Console.WriteLine("-----------------------------");
                }
            );
            DriveInfo drive = new DriveInfo("D");
            Type t = drive.GetType();
            Console.WriteLine("List name of properties: ");
            PrintProperties(t, drive);
            Console.WriteLine("\n-----------------------------");
        }

        private static void DirectoryInfor()
        {
            string path = "TMP_Directory";
            Directory.CreateDirectory(path);
            Directory.Delete(path);
            if (Directory.Exists(path))
            {
                Console.WriteLine($"{path} - ton tai");
            }
            else
            {
                Console.WriteLine($"{path} - khong ton tai");
            }
            Console.WriteLine("list file of folder net5.0 ");
            var files = Directory.GetFiles("net5.0");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            var subdirectory = Directory.GetDirectories("net5.0");
            Console.WriteLine("sub directory: ");
            foreach (var dir in subdirectory)
            {
                Console.WriteLine(dir);
            }
        }

        private static void GetFileAndDirectory(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
                GetFileAndDirectory(dir);
            }
        }

        private static void PathInfor()
        {
            Console.WriteLine(Path.DirectorySeparatorChar);
            var path = Path.Combine("Dir1", "Dir2", "Tenfile.txt");
            var p = "Dir1\\Dir2\\Tenfile.txt";
            p = Path.ChangeExtension(p, "data");
            Console.WriteLine(p);
        }

        private class Product
        {
            public int Id { get; set; }
            public double Price { get; set; }
            public string Name { get; set; }

            public void Save(Stream stream)
            {
                // int = 4 bytes
                var byte_id = BitConverter.GetBytes(Id);
                stream.Write(byte_id, 0, 4);
                var byte_price = BitConverter.GetBytes(Price);
                stream.Write(byte_price, 0, 8);

                var byte_name = Encoding.UTF8.GetBytes(Name);
                var byte_length = BitConverter.GetBytes(byte_name.Length);
                stream.Write(byte_length, 0, 4);
                stream.Write(byte_name, 0, byte_name.Length);
            }

            public void Restore(Stream stream)
            {
                // int = 4 bytes
                var byte_id = new byte[4];
                stream.Read(byte_id, 0, 4);
                Id = BitConverter.ToInt32(byte_id, 0);
            }
        }

        private static void Main(string[] args)
        {
            //GetDriveInfor();
            //DirectoryInfor();
            //PathInfor();
            string path = "data.dat";
            using var stream = new FileStream(path: path, FileMode.OpenOrCreate);
            Product product = new Product()
            {
                Id = 3,
                Name = "San pham abc",
                Price = 12234
            };
            product.Save(stream);

            Product pRestore = new Product();
            pRestore.Restore(stream);
            Console.WriteLine($"ID: {pRestore.Id}, Name: {pRestore.Name}, Price: {pRestore.Price}");

            // // luu du lieu
            // byte[] buffer = {1,2,3};
            // int offset = 0;
            // int count = 3;
            // stream.Write(buffer, offset, count);
            // // doc du lieu
            // int sl = stream.Read(buffer, offset, count); //~tra ve so byte doc dc, 0 = cuoi file

            // // int, double ->> bytes
            // int abc = 1;
            // var byte_abc =  BitConverter.GetBytes(abc);
            // // bytes -> int, double...
            // BitConverter.ToInt32(byte_abc,0);
            // //
            // string s = "Abv";
            // var bytes_s = Encoding.UTF8.GetBytes(s);
            // Encoding.UTF8.GetString(bytes_s, 0, 10);
        }
    }
}