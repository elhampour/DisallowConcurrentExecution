using Quartz;
using System;
using System.Diagnostics;

namespace WindowsService
{
    [DisallowConcurrentExecution]
    public class SampleJob : IJob
    {
        private static string TextPath = "C://ninisite//test.txt";

        public void Execute(IJobExecutionContext context)
        {
            Log("Before Execute exe file." + DateTime.Now.ToString());
            var output = ExecuteAsync();
            Log("Before Show output " + DateTime.Now.ToString());
            Log("After Execute exe file. with output : " + output + " " + DateTime.Now.ToString());
        }

        private static void Log(string text)
        {
            string[] lines = { text };
            System.IO.File.AppendAllLines(TextPath, lines);
        }

        private string ExecuteAsync()
        {
            Process mProcess = null;
            ProcessStartInfo oInfo =
                new ProcessStartInfo("C://ninisite//DisallowExe//CoreJob.exe")
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardError = true
                };
            mProcess = Process.Start(oInfo);
            var SROutput = mProcess.StandardOutput;
            var outPut = SROutput.ReadToEnd();
            mProcess.WaitForExit();
            mProcess.Close();
            mProcess.Dispose();
            SROutput.Close();
            SROutput.Dispose();
            return outPut;
        }
    }
}
