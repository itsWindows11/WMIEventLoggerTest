using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WMIEventLoggerTest;

public sealed class WMIEventLogger : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var type = logLevel switch
        {
            LogLevel.Warning => EventLogEntryType.Warning,
            LogLevel.Error or LogLevel.Critical => EventLogEntryType.Error,
            _ => EventLogEntryType.Information,
        };

        EventLog.WriteEntry("Logger Test App", formatter(state, exception), type);
    }
}
