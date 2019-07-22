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
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo(name, arguments)
                    {

                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();
                result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
