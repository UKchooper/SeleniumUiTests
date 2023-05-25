using System;
using System.Diagnostics;
using System.IO;

namespace SeleniumUiTests.Helpers
{
    public static class CommonHelpers
    {
        public static void LaunchApplication(string applicationName)
        {
            var folderLocation = Environment.GetFolderPath(Environment.SpecialFolder.System);

            var zsStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(folderLocation, $"{applicationName}.exe"),
                WorkingDirectory = folderLocation,
                UseShellExecute = true
            };

            Debug.WriteLine($"Run application '{zsStartInfo.FileName}'.");

            Process.Start(zsStartInfo);
        }

        public static void CloseApplication(string appProcessName)
        {
            foreach (var process in Process.GetProcessesByName(appProcessName))
            {
                process.Kill();
            }
        }
    }
}
