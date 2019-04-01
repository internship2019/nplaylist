using System;
using System.Diagnostics;
using System.Linq;

namespace NPlaylist.Player
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args[0] == "-h" || args[0] == "--help" || String.IsNullOrEmpty(args[0]))
            {
                PrintHelp();
                return 1;
            }
            if (args.Length >1)
            {
                Console.Error.WriteLine("Wrong number of arguments");
                return -1;
            }
            var deserializedPlaylist = Playlist.Read(args[0]);
            var items = deserializedPlaylist.GetItems().ToArray();
            var itemCount = items.Count();
            PrintTrackPath(deserializedPlaylist);

            while (true)
            {
                var command = Console.ReadLine();
                var cmd = int.TryParse(command, out var res);
                if (cmd)
                {
                    if (int.Parse(command) <= itemCount && int.Parse(command) > -1)
                    {
                        CreateStream(items[int.Parse(command)].Path);
                    }
                }
                if (command == "stop")
                {
                    KillAllFfplayProcesses();
                }
                if (command == "exit")
                {
                    KillAllFfplayProcesses();
                    break;
                }
            }

            return 1;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Unicode Slayers Player 1.0:");
            Console.WriteLine("Arguments: <source file>");
            Console.WriteLine("If yo want to stop track: stop");
            Console.WriteLine("If yo want to exit: exit");
        }

        private static void PrintTrackPath(IPlaylist deserializedPlaylist)
        {
            var counter = 0;
            Console.WriteLine("*****Tracklist:*****");
            foreach (var playlistItem in deserializedPlaylist.GetItems())
            {
                Console.WriteLine($"{counter}.{playlistItem.Path}");
                counter++;
            }
        }

        private static void CreateStream(string filePath)
        {
            KillAllFfplayProcesses();
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "ffplay.exe";
            startInfo.Arguments = "-vn -showmode 0 -nodisp -nostats " + filePath;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        private static void KillAllFfplayProcesses()
        {
            foreach (var proces in Process.GetProcessesByName("ffplay"))
            {
                proces.Kill();
            }
        }
    }
}
