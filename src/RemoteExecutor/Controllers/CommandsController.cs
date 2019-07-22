using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RemoteExecutor.Lib;

namespace RemoteExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "values 1", "values 2" };
        }

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
                default:
                    return RunListDir();
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
    }

}
