using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// Emulator helper class to start and stop emulator
    /// </summary>
    public static class EmulatorHelper
    {
        /// <summary>
        /// Start emulator.
        /// </summary>
        public static void StartEmulator()
        {
            // Stop if any instance running.
            StopEmulator();

            string args = $"/C {Path.Combine(Constants.ExecutionSetting.AndroidSdkPath, "emulator", "emulator.exe")} @{Constants.ExecutionSetting.DeviceName}";
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            var process = Process.Start(processStartInfo);
            process.Close();

            //Wait time for android emulator to start.
            Thread.Sleep(35000);

        }

        /// <summary>
        /// Stop emulator.
        /// </summary>
        public static void StopEmulator()
        {
            Regex regex = new Regex(@"qemu-system.*");
            foreach (Process p in Process.GetProcesses("."))
            {
                if (regex.Match(p.ProcessName).Success)
                {
                    p.Kill();
                }
            }
        }
    }
}
