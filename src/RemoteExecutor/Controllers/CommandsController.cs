using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RemoteExecutor.Controllers
{
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "values 1", "values 2" };
        }



        // POST api/commands
        [HttpPost]
        public string Post(string name, string arguments)
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
