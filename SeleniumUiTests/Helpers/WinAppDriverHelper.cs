using System;
using System.Diagnostics;
using System.IO;

namespace SeleniumUiTests.Helpers
{
    internal static class WinAppDriverHelper
    {
        private static readonly string winAppDriverName = "WinAppDriver";
        public static void LaunchWinAppDriver()
        {
            string winAppDriverPath = @"C:/Program Files (x86)/Windows Application Driver/";
            string fullpath = Path.Combine(winAppDriverPath, $"{winAppDriverName}.exe");
            try
            {
                if (File.Exists(fullpath))
                {
                    ProcessStartInfo start = new ProcessStartInfo();
                    
                    start.FileName = fullpath;

                    using (Process process = Process.Start(start))
                    {
                        process.WaitForExit();
                    }
                }
                else
                {
                    Console.WriteLine("The WinAppDriver application was not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start WinAppDriver application {ex.Message}");
            }
        }

        public static void CloseWinAppDriver()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(winAppDriverName);

                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service not found {ex.Message}");
            }
        }
    }
}
