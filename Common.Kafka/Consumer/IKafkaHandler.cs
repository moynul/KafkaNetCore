using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Kafka.Consumer
{
    public interface IKafkaHandler<Tk, Tv>
    {
        Task HandleAsync(Tk key, Tv value);
    }
}
