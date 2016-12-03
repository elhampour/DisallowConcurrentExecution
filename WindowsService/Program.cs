using Topshelf;

namespace WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SampleTask>(s =>
                {
                    s.ConstructUsing(a => new SampleTask());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("SampleTask");
                x.SetDisplayName("SampleTask");
                x.SetServiceName("SampleTask");
            });
        }
    }
}
