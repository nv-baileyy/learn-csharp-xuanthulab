using System;

namespace Basic_ExceptionDemo
{
    internal class Program
    {
        public class CustomException : Exception
        {
            public CustomException(string msg)
            {
                Console.WriteLine(msg);
            }
        }

        public static void CatchOrder()
        {
            try
            {
                using (var imm = new System.IO.StreamWriter("E:/text.txt"))
                {
                    imm.WriteLine("Hello! Fuck you!");
                    Console.WriteLine("Write OK");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int[] ar = new int[3] { 1, 2, 3 };
            int index = -1;
            try
            {
                int x = ar[index];
            }
            catch (Exception e) when (index < 0)
            {
                Console.WriteLine("index do not negative " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("index out of range" + e.Message);
            }
        }

        private static void Main(string[] args)
        {
            System.IO.FileStream file = null;
            //Change the path to something that works on your machine.
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("D:/file.txt");

            try
            {
                file = fileInfo.OpenWrite();
                file.WriteByte(0xF);
            }
            finally
            {
                // Closing the file allows you to reopen it immediately - otherwise IOException is thrown.
                file?.Close();
            }

            try
            {
                file = fileInfo.OpenWrite();
                Console.WriteLine("OpenWrite() succeeded");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("OpenWrite() failed");
            }
        }
    }
}