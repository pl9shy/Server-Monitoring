using System.Net.NetworkInformation;
using System.Timers;

class ServerMonitor
{   
    private static System.Timers.Timer monitorTimer;
    private static int totalPings = 0;
    private static Dictionary<string, int> successfulPings = new Dictionary<string, int>();
    private static Dictionary<string, int> failedPings = new Dictionary<string, int>();
    
    static void Main(string[] args)
    {
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = "ServersList.txt"; // Имя файла, где хранятся IP серверов
        string filePath = Path.Combine(directoryPath, fileName);

        string[] lines = File.ReadAllLines(filePath);

        int intervalMinutes = 5; // Интервал таймера в минутах

        monitorTimer = new System.Timers.Timer(intervalMinutes * 60 * 1000);
        monitorTimer.Elapsed += (sender, e) => MonitorServers(lines);
        monitorTimer.AutoReset = monitorTimer.Enabled = true;

        Console.WriteLine("Нажмите [Enter] для выхода...");
        Console.ReadLine();
    }
    private static void MonitorServers(string[] lines)
    {
        foreach (string line in lines)
        {
            string[] info = line.Split(", ");
            string ipAddress = info[0].Trim();
            string serverName = info[1].Trim();

            if (!successfulPings.ContainsKey(serverName))
            {
                successfulPings[serverName] = 0;
            }
            if (!failedPings.ContainsKey(serverName))
            {
                failedPings[serverName] = 0;
            }

            bool activity = new Ping().Send(ipAddress).Status == IPStatus.Success;

            totalPings++;

            switch(activity)
            {
                case true:
                    successfulPings[serverName]++;
                    Console.WriteLine($"Сервер {serverName} ({ipAddress}) в сети.");
                    break;

                case false:
                    failedPings[serverName]++;
                    Console.WriteLine($"Сервер {serverName} ({ipAddress}) недоступен.");
                    break;
            }
            
            int serverTotalPings = successfulPings[serverName]+failedPings[serverName];
            double successChance;
            if (serverTotalPings > 0)
            {
                successChance = (double)successfulPings[serverName] / serverTotalPings * 100;
            }
            else
            {
                successChance = 0;
            }
            
            Console.WriteLine($"Доступность {serverName}: {successChance:F2} %. ({successfulPings[serverName]}/{serverTotalPings})");
            Console.WriteLine("------------------------");
        }
    }
}