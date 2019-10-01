using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace DurableFunctions_2_demo
{
    public class Counter
    {
        public int Count { get; set; }
        public void Increment() => Count++;
        public void Decrement() => Count--;
        public void End() => Entity.Current.DestructOnExit();

        [FunctionName(nameof(Counter))]
        public static Task Run(
            [EntityTrigger] IDurableEntityContext ctx) => ctx.DispatchAsync<Counter>();
    }
}