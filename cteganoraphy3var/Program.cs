using System;

namespace cteganoraphy3var
{
    class Program
    {
        static void Main(string[] args)
        {

            TailWhitespaces tailWhitespaces = new TailWhitespaces();
            tailWhitespaces.message = "Some secret";
            tailWhitespaces.pathtoFile = "D:\\test.txt";
            string encryptMessage = tailWhitespaces.EncryptMessage();
            string decryptMessage = tailWhitespaces.Decrypt(encryptMessage);

            Console.WriteLine("DecryptMessage: " + decryptMessage);
            Console.ReadKey();
        }


    }
}
