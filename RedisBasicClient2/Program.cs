using System;
using StackExchange.Redis;


namespace RedisBasicClient2
{
    class Program
    {
        static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");  //ConnectionMultiplexer.Connect("hostname:port,password=password");
        static void Main(string[] args)
        {

            ISubscriber sub = redis.GetSubscriber();

            sub.Subscribe("messages", (channel, message) => {
                Console.WriteLine((string)message);
            });

            Console.WriteLine("Preass any key to exit...");
            Console.ReadKey();
        }
    }
}
