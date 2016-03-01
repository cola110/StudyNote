using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.redis
{
    public class RedisDemoTest
    {
        static RedisDemo redisDemo = new RedisDemo();

        public IList<string> TestGetAll()
        {
            return redisDemo.GetAll<string>();
        }

        public string TestGet(string key)
        {
            return redisDemo.Get<string>(key);
        }
    }
}
