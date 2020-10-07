using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer
{
    public static class QueueConsumer
    {
        public static void Consume(IModel chanel)
        {
            chanel.QueueDeclare(queue: "demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            chanel.BasicConsume("demo-queue", true, consumer);
            Console.WriteLine("Consumer start!");
            Console.ReadLine();
        }
    }
}
