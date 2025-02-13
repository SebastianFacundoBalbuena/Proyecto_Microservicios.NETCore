using Serilog;
using Serilog.Sinks.Syslog;

public static class LoggerConfig
{
    public static void ConfigureLogger(PapertrailSettings papertrailSettings)
    {
        if (papertrailSettings == null)
        {
            throw new ArgumentNullException(nameof(papertrailSettings));
        }

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Syslog(
                papertrailSettings.Host, // Host de Papertrail
                papertrailSettings.Port, // Puerto de Papertrail
                format: SyslogFormat.RFC3164 // Formato de syslog
            )
            .CreateLogger();
    }
}