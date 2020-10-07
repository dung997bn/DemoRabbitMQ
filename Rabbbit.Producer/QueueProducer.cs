﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbbit.Producer
{
    public class QueueProducer
    {
        public static void Publish(IModel chanel)
        {
            chanel.QueueDeclare(queue: "demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = "Hello Count " + count };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                chanel.BasicPublish("", "demo-queue", null, body);
                count++;
                Console.WriteLine(message);
                Thread.Sleep(2000);
            }

        }
    }
}
