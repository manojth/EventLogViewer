namespace EventLogParser
{
    internal interface IEventLogParser
    {
        unsafe void Parse(string locationName);
        event ProgressHandler OnProgress;
        event MessageHandler OnAction;
        event NewEventFoundHandler OnFoundRecord;
    }
}