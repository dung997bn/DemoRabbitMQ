using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbbit.Producer.Exchanges
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel chanel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 30000 }
            };

            chanel.ExchangeDeclare(exchange: "demo-direct-exchange", type: ExchangeType.Direct, durable: false, autoDelete: false, arguments: ttl);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = "Hello Count " + count };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                chanel.BasicPublish(exchange: "demo-direct-exchange", routingKey: "account.init", null, body);
                count++;
                Console.WriteLine(message);
                Thread.Sleep(2000);
            }
        }
    }
}
