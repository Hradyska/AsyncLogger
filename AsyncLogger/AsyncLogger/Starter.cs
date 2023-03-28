using System.Reflection.Metadata;
using System.Text.Json;
using static AsyncLogger.Actions;
namespace AsyncLogger
{
    internal static class Starter
    {
        public static async Task Run()
        {
            Logwriter logwriter = new Logwriter();
            string configFile = File.ReadAllText("config.json");
            Config config = JsonSerializer.Deserialize<Config>(configFile);
            string path = config.GetLogConfig.Path;
            string fileName = $"{DateTime.Now.ToString(config.GetLogConfig.TimeFormat)}" + config.GetLogConfig.LogName;
            string backup = config.GetLogConfig.BackupPath;
            int j;
            logwriter.WriteBackup += (logwriter, count) =>
            {
                if (count >= config.GetLogConfig.N)
                {
                    Task.Delay(10);
                    Task task = Logwriter.WriteLogToFile(backup, $"{DateTime.Now.ToString(config.GetLogConfig.TimeFormat)}" + config.GetLogConfig.LogName);
                    Logwriter.Count = 0;
                }
            };
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                bool flag = false;
                j = rand.Next(0, 100);
                if (j < 30)
                {
                    j = 0;
                }
                else if (j >= 30 && j < 60)
                {
                    j = 1;
                }
                else
                {
                    j = 2;
                }

                try
                {
                    switch (j)
                    {
                        case 0:
                            flag = Info();
                            break;
                        case 1:
                            flag = Warning();
                            break;
                        case 2:
                            flag = Error();
                            break;
                    }
                }
                catch (BusinessException e)
                {
                   await logwriter.WriteLog(e.ErrorTime, LogType.Warning, "Action got this custom Exception: " + e.ExMessage + " " + e.TargetSite, path, fileName);
                }
                catch (Exception e)
                {
                    await logwriter.WriteLog(DateTime.Now, LogType.Error, "Action failed by reason: " + e.Message + " " + e.ToString(), path, fileName);
                }

                if (flag)
                {
                    await logwriter.WriteLog(DateTime.Now, LogType.Info, $"Start method: {nameof(Actions.Info)}", path, fileName);
                }
            }
        }
    }
}
