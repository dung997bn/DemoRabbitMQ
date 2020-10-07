using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Exchanges
{
    public class DirectExchangeConsumer
    {
        public static void Consume(IModel chanel)
        {
            chanel.ExchangeDeclare(exchange: "demo-direct-exchange", type: ExchangeType.Direct, durable: false, autoDelete: false, arguments: null);
            chanel.QueueDeclare(queue: "demo-direct-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            chanel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.init");
            chanel.BasicQos(0, 10, false);
            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            chanel.BasicConsume("demo-direct-queue", true, consumer);
            Console.WriteLine("Consumer Direct Exchange start!");
            Console.ReadLine();
        }
    }
}
