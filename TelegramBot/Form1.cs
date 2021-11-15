using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.WinForm.Helper;
using TelegramBot.Helper;

namespace TelegramBot
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();

            Global.baglanti();
            Global.bot.StartReceiving();
            Global.bot.OnMessage += Bot_OnMessage;


        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var id = txtKisiId.Text;
            var mesaj= txtMessage.Text;
            Global.bot.SendTextMessageAsync(id, mesaj);
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            var tarih = DateTime.Now.ToString();
            var saat = DateTime.Now.ToLongTimeString();
            if (e.Message.Text != null)
            {
                LogHelper.Log(String.Concat(e.Message.Chat.Id.ToString(), e.Message.Text, e.Message.Chat.FirstName, e.Message.Chat.LastName));
            }
            switch (e.Message.Text)
            {
                case "Selam":
                    Global.bot.SendTextMessageAsync(e.Message.Chat.Id, "Aleyküm Selam " + e.Message.Chat.FirstName);
                    break;
                case "Tarih":
                    Global.bot.SendTextMessageAsync(e.Message.Chat.Id, tarih + " " + e.Message.Chat.FirstName);
                    break;
                case "Saat":
                    Global.bot.SendTextMessageAsync(e.Message.Chat.Id, saat + " " + e.Message.Chat.FirstName);
                    break;
                case "Hello":
                    Global.bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello " + e.Message.Chat.FirstName);
                    break;
                case "Çık":
                    //Application.Exit();
                    break;
            }
        }

    }
}
