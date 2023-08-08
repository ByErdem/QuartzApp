using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzApp
{
    public class Initialize
    {
        public static async void InitializeJobs()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var userEmailsJob = JobBuilder.Create<SendUserEmailsJob>()
                .WithIdentity("SendUserEmailsJob")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("SendUserEmailsCron")
                .StartNow()
                .WithCronSchedule("30 47 10 ? * * *")
                .Build();


            //Her gün 09:57'de --> 0 57 9 ? * *

            var result = await _scheduler.ScheduleJob(userEmailsJob, trigger);
        }

    }
}
