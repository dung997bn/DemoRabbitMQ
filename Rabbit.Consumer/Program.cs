using Rabbit.Consumer.Exchanges;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Rabbit.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using (var connection = factory.CreateConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    DirectExchangeConsumer.Consume(chanel);
                }
            }

            Console.ReadKey();
        }
    }
}
