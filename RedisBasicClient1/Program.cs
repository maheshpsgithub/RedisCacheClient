using System;
using StackExchange.Redis;


namespace RedisBasicClient1
{
    class Program
    {
        static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");  //ConnectionMultiplexer.Connect("hostname:port,password=password");
        static void Main(string[] args)
        {

            IDatabase conn = redis.GetDatabase();

            //SET AND GET STRING VALUE
            conn.StringSet("foo", "bar");
            var value = conn.StringGet("foo");
            Console.WriteLine("values of foo:" + value);

            ISubscriber sub = redis.GetSubscriber();

            sub.Publish("messages", "hello");


            Console.WriteLine("Preass any key to exit...");
            Console.ReadKey();
        }
    }
}
