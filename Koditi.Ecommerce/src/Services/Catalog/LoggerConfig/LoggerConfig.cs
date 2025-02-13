using LoggerConfig;
using Serilog;


public static class LoggerConfigg
{
    public static void ConfigureLogger(PapertrailSettings papertrailSettings)
    {
        if (papertrailSettings == null)
        {
            throw new ArgumentNullException(nameof(papertrailSettings));
        }

        Log.Logger = new LoggerConfiguration()
            
            .WriteTo.TcpSyslog(
                papertrailSettings.Host, // Host de Papertrail
                papertrailSettings.Port  //Puerto de Papertrail
                

            )
            .CreateLogger();
    }
}