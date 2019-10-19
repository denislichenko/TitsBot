﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TitsBot.Events;

namespace TitsBot.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        public static TelegramBotClient GetBotClient()
        {
            if (botClient != null) return botClient;
            botClient = new TelegramBotClient(AppSettings.Token);

            botClient.OnMessage += MessageEvents.OnMessageReceived;
            botClient.OnReceiveError += ErrorEvents.BotOnReceiveError;

            botClient.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine("Started!");
            return botClient;
        }
    }
}
