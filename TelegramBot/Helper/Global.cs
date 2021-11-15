using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Telegram.Bot;

namespace TelegramBot.Helper
{
    public class Global
    {

        private static string Token = string.Empty;

        public static TelegramBotClient bot;
        public static string Base64Encode(string metin)
        {
            var metinBaytlari = Encoding.UTF8.GetBytes(metin);
            return Convert.ToBase64String(metinBaytlari);
        }
        public static string Base64Decode(string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }

        public static void baglanti()
        {
            string dosya = Application.StartupPath + "\\data.xml";
            XmlTextReader rdr = new XmlTextReader(dosya);
            List<string> baglantiList = new List<string>();
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                {
                    baglantiList.Add(rdr.Value);
                }
            }
            Token = Base64Decode(baglantiList[0]);
            bot = new TelegramBotClient(Token);

        }






    }




}
