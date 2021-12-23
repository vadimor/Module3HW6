using System;
using System.Threading.Tasks;

namespace Module3HW6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var messageBox = new MessageBox();
            var tcs = new TaskCompletionSource<State>();
            Action<State> action = (x) =>
            {
                if (x == State.Cancel)
                {
                    Console.WriteLine("Operation rejected");
                }
                else
                {
                    Console.WriteLine("Operation accept");
                }

                tcs.SetResult(x);
            };
            messageBox.OnClose += action;
            messageBox.Open();

            tcs.Task.GetAwaiter().GetResult();
        }
    }
}
