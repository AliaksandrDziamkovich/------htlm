using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = GetCode("http://tut.by/");
            Console.WriteLine(text);
            Console.Read();
        }
        public static String GetCode(string urlAddress)
        {
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);

            Cookie cookie = new Cookie
            {
                Name = "beget",
                Value = "begetok"
            };

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri(urlAddress), cookie);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
        }
    }
}