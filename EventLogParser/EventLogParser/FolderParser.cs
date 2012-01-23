using System.IO;

namespace EventLogParser
{
    public class FolderParser : IEventLogParser
    {
        private EventLogParser eventLogParser;
        
        public unsafe void Parse(string folderName)
        {
            string[] files = Directory.GetFiles(folderName,"*.evt");
            eventLogParser = new EventLogParser();
            eventLogParser.OnAction += OnAction;
            eventLogParser.OnProgress += OnProgress;
            eventLogParser.OnFoundRecord += OnFoundRecord;
           
            foreach(var file in files)
            {
                eventLogParser.Parse(file);
            }
            
        }

        public event ProgressHandler OnProgress;
        public event MessageHandler OnAction;
        public event NewEventFoundHandler OnFoundRecord;
    }
}