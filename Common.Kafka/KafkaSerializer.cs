using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Kafka
{
    internal sealed class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
                return null;

            if (typeof(T) == typeof(Ignore))
                throw new NotSupportedException("Not Supported.");

            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
