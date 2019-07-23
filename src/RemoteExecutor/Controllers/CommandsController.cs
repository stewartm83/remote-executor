using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RemoteExecutor.Lib;

namespace RemoteExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        // POST api/commands
        [HttpPost]
        public string Post(string command)
        {
            switch (command)
            {
                case "docker":
                    return RunDocker();
                case "list":
                    return RunListDir();
                case "python":
                    return RunPythonScript();
                default:
                    return RunPythonScript();
            }
        }

        private string RunDocker()
        {
            return ShellCommands.ExecuteCommand("docker", "build --help");
        }

        private string RunListDir()
        {
            return ShellCommands.ExecuteCommand("ls", "--lah");
        }

        private string RunPythonScript()
        {
            return ShellCommands.ExecuteCommand("python", "python2json.py");
        }
    }

}
