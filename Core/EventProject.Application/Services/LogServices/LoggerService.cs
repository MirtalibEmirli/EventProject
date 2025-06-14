using Microsoft.EntityFrameworkCore.Storage;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace EventProject.Application.Services.LogServices;

public static class LoggerService
{

    //string connnectionstring    
    public static void SetUpNlog(string dbconnection)
    {

        NLog.Common.InternalLogger.LogLevel = LogLevel.Trace;
        NLog.Common.InternalLogger.LogFile = "logs\\nlog-internal-errors.txt";

        var fileTarget = new FileTarget("logfile")
        {
            FileName = "C:\\Users\\Mirtalib\\source\\repos\\EventProject\\Presentation\\EventProject.Api\\logs\\logFile-${date:format=yyyy-MM-dd}.txt",
            Layout = "${longdate} ${level} ${message} ${exception}"
        };
        var consoleTarget = new ConsoleTarget("consoleTarget")
        {
            Layout = "${longdate}  ${level}   ${message} ${exception}"
            ,
            Encoding = System.Text.Encoding.UTF8,
        };

        var config = new LoggingConfiguration();


        var databaseTarget = new DatabaseTarget("databaseTarget")
        {
            DBProvider = "Microsoft.Data.SqlClient.SqlConnection, Microsoft.Data.SqlClient",
            ConnectionString = "Data Source=DESKTOP-U9UFRFT\\SQLEXPRESS;Initial Catalog=PartyHubEventDatabase-2025-5-16-2-20;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False",
            CommandText = @"
        INSERT INTO  dbo.Logs 
        (MachineName, Logged, Level, Message, Logger, Callsite, Exception, Application, Thread, UserName)
        VALUES 
        (@MachineName, @Logged, @Level, @Message, @Logger, @Callsite, @Exception, @Application, @Thread, @UserName);",

        };
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Logged", "${date:format=yyyy-MM-dd HH\\:mm\\:ss}"));

        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Level", "${level}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Logger", "${logger}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Message", "${message}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Exception", "${exception:format=tostring}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@MachineName", "${machinename}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@CallSite", "${callsite}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Application", "${appdomain:format={1\\}}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Thread", "${threadid}"));
        databaseTarget.Parameters.Add(new DatabaseParameterInfo("@UserName", "${windows-identity}"));

        config.AddTarget(databaseTarget);


        config.AddTarget(fileTarget);
        config.AddTarget(consoleTarget);
        config.AddRule(NLog.LogLevel.Warn, NLog.LogLevel.Fatal, fileTarget);
        config.AddRule(LogLevel.Warn, LogLevel.Error, databaseTarget);
        config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, consoleTarget);

        LogManager.Configuration = config;
    }
}
