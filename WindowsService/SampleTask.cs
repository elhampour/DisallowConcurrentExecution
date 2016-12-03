using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Impl;
using Quartz.Unity;

namespace WindowsService
{
    public class SampleTask
    {
        public void Start()
        {
            var container = new UnityContainer();
            container.RegisterType<ISchedulerFactory, UnitySchedulerFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IScheduler>(new InjectionFactory(c => c.Resolve<ISchedulerFactory>().GetScheduler()));

            var scheduler = container.Resolve<IScheduler>();

            var trigger = TriggerBuilder.Create()
               .WithIdentity("SampleTaskTrigger", "SampleTaskGroup")
               .WithSimpleSchedule(x => x
                   .WithIntervalInSeconds(1)
                   .RepeatForever())
               .StartNow()
               .Build();

            scheduler.ScheduleJob(new JobDetailImpl("SampleJob", typeof(SampleJob)), trigger);

            scheduler.Start();
        }

        public void Stop()
        {
        }
    }
}
