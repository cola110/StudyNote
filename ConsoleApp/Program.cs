using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp._WebClient;
using ConsoleApp.redis;

/*
 * for some app or simple useful funtion
 */
namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            TestRedisInPractise();
        }

        public static void TestDataRedisInPractise()
        {
            BlogPostExample testData = new BlogPostExample();
            testData.OnBeforeEachTest();
        }

        public static void TestRedisInPractise()
        {
            RedisInPractise practise = new RedisInPractise();
            practise.Show_a_list_of_blogs();
            practise.Show_a_list_of_recent_posts_and_comments();
        }

        public static void TestRedisDemo()
        {
            RedisDemoTest redisTest = new RedisDemoTest();
            // string result = redisTest.TestGet("helr");
            // string result = redisTest.TestGet("helo");
            IList<string> result = redisTest.TestGetAll();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void TestWebClient()
        {
            new WebClientTest().TestWebClient(); // webClient Test
        }
    }
}
