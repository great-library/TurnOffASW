using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnOffASW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string oculusSoftwarePath = @"C:\Program Files\Oculus\Support\oculus-diagnostics";
            string cliToolFileName = oculusSoftwarePath + "\\OculusDebugToolCLI.exe";
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo() {
                FileName = cliToolFileName,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false                
            };
            var process = System.Diagnostics.Process.Start(processStartInfo);
            string output;            
            process.StandardInput.WriteLine("server:asw.off");
            process.StandardInput.WriteLine("exit");
            output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }
    }
}
