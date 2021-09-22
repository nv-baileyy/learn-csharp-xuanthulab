using System;

// một phương thức có thể được định nghiax lại ở lớp kết thừa thì được gọi là phương thức ảo (virtual)\
// khác với 1 phương thức bùnh thường, ta dùng new ở lớp kết thừa. Tạo ra 2 phương thức khác nhau ở
// 2 lớp khác nhau
// abtract class  (truu tuong) lớp không được dùng để tạo ra object (đối tượng), chỉ được làm cơ sở
// cho lớp kế thừa
// abstract method - không được có phần thân ở trong phương thức trừu tượng tại lớp cơ sở.
// Ở lớp kết thừa thì bắt buộc phải ovveride (nạp chồng phương thức) để định nghĩa lại nó
// mặc định tất cả các method ở trong interface đều là abstract, chỉ cần khai báo tên phưong thức
namespace Basic_Vitual_Abstract_Interface
{
    internal class Program
    {
        public abstract class Product
        {
            protected double Price { get; set; }

            public virtual void ProductInfor()
            {
                Console.WriteLine($"gia sp: {Price}");
            }

            public abstract void tinhtoan();

            public void Test() => ProductInfor();
        }

        public class Iphone : Product
        {
            public Iphone() => this.Price = 500;

            // override - nap chong phuong thuc
            public override void ProductInfor()
            {
                Console.WriteLine("dien thoai iphone");
                base.ProductInfor();
            }

            public override void tinhtoan()
            {
                throw new NotImplementedException();
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}