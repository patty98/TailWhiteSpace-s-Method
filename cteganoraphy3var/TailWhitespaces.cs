using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cteganoraphy3var
{
    class TailWhitespaces
    {
        public string message { get; set; }
        public string pathtoFile { get; set; }
        private byte[] file;
        private string decryptMessage = "";
        private string _fileContainer = "";
        public string EncryptMessage()
        {
            string stego = ToBinary(ConvertToByteArray(message, Encoding.UTF8));
            int counter = 0;
            using (StreamReader filestream = new StreamReader(pathtoFile))
            {

                while (!filestream.EndOfStream)
                {
                    if (counter == stego.Length)
                    {
                        break;
                    }

                    string line = filestream.ReadLine();
                    line = line.TrimEnd();
                    if (stego[counter] == '1')
                    {

                        line += " ";
                    }

                    _fileContainer += line;
                    _fileContainer += "\n";
                    counter++;
                }
            }



            byte[] file = File.ReadAllBytes(pathtoFile);

            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "encryptMessage.txt"))
            {
                  writer.Write(_fileContainer);
       
            }
            return _fileContainer;
        }

        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static string ToBinary(Byte[] data)
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                string binary = Convert.ToString(data[i], 2);
                if (binary.Length < 8)
                {
                    while (binary.Length < 8)
                    {
                        binary = binary.Insert(0, "0");
                    }
                }
                result += binary;

            }
            return result;
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }

            return Encoding.UTF8.GetString(byteList.ToArray());
        }
        public string Decrypt(string encryptMes)
        {
            string binaryMessage = "";
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "encryptMessage.txt"))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Length == 0)
                    {
                        binaryMessage += 0;
                        continue;
                    }
                    if (line[line.Length - 1] == ' ')
                    {
                        binaryMessage += 1;

                    }
                    else
                    {
                        binaryMessage += 0;
                    }
                }
            }

            string decryptMessage = BinaryToString(binaryMessage);
            return decryptMessage;
        }
    }
}
