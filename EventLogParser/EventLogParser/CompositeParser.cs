using System.IO;

namespace EventLogParser
{
    public class CompositeParser : IEventLogParser
    {
        public unsafe void Parse(string locationName)
        {
            IEventLogParser parser;
            if (Directory.Exists(locationName) )
            {
                parser = new FolderParser();
            }
            else
            {
                parser = new EventLogParser();
            }
            parser.OnAction += OnAction;
            parser.OnProgress += OnProgress;
            parser.OnFoundRecord += OnFoundRecord;
            parser.Parse(locationName);
        }

        public event ProgressHandler OnProgress;
        public event MessageHandler OnAction;
        public event NewEventFoundHandler OnFoundRecord;
    }
}