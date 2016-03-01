using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.redis
{
    public class RedisDemo
    {
        static RedisClient redisClient = new RedisClient("localhost", 6379);

        public IList<T> GetAll<T>()
        {
            return redisClient.GetAll<T>();
        }

        public T Get<T>(string redisKey)
        {
            return redisClient.Get<T>(redisKey);
        }


        public bool Set(string redisKey, string values)
        {
            return redisClient.Set(redisKey, values);
        }
    }
}
