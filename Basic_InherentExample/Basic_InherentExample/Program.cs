using System;

namespace Basic_InherentExample
{
    internal class Program
    {
        // abstract - class nay la class phai dc lop khac ke thua
        private abstract class nhanvien
        {
            private string HoTen { get; set; }
            private int NamSinh { get; set; }
            // Method TinhLuong phai dc ke thua o lop khac
            public abstract double Tinhluong();
            // dinh nghia lai method o class ke thua
            public virtual void nhap()
            {
                HoTen = Console.ReadLine();
                NamSinh = Convert.ToInt32(Console.ReadLine());
            }

            public virtual void xuat()
            {
                Console.WriteLine($"Ho ten: {HoTen}, Nam sinh: {NamSinh}");
            }
        }
        private class nvthinghiem : nhanvien
        {
            // override, dinh nghia tiep  method o lop co so
            public override double Tinhluong()
            {
                return 1.1;
            }

            public override void nhap()
            {
                base.nhap();
            }

            public override void xuat()
            {
                base.xuat();
            }
        }        

        private static void Main(string[] args)
        {
            var nvtn = new nvthinghiem();
            nvtn.nhap();
            nvtn.xuat();
        }
    }
}