using System;
using System.Diagnostics;

namespace RemoteExecutor.Lib
{
    public static class ShellCommands
    {
        public static string ExecuteCommand(string name, string arguments)
        {
            string result;
            try
            {
                var startInfo = new ProcessStartInfo(name, arguments)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                using (var process = Process.Start(startInfo))
                {
                    result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
