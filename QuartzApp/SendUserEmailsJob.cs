using Quartz;

namespace QuartzApp
{
    public class SendUserEmailsJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            return Task.CompletedTask;
        }
    }
}