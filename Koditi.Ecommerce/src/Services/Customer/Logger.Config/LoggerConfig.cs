using Serilog;
using Serilog.Sinks.Syslog;

namespace Logger.Config
{
    public class LoggerConfig
    {
        public static void  LoggerConfigurations(PapertrailSettings Papertrail)
        {
            if(Papertrail is null)
            {
                throw new ArgumentNullException(nameof(Papertrail));
            }

            Log.Logger = new LoggerConfiguration()
                .WriteTo.TcpSyslog(
                host : Papertrail.Host,
                port : Papertrail.Port
                ).CreateLogger();

            Log.Information("Se creo la configuracion del logg correctamente");
        }
    }
}
