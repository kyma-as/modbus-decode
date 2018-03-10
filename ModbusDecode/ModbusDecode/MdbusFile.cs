using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusDecode
{
    class MdbusCommand
    {
        public MdbusCommand(DateTime timestamp, char checksum, string message)
        {
            TimeStamp = timestamp;
            Checksum = checksum;
            Message = message;
        }

        public int date { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public Char Checksum { get; private set; }
        public string Message { get; private set; }

        public static MdbusCommand Parse(string command, DateTime fileDate)
        {
            // The line in the mdbus.LOG file looks like this:
            // 08 22:27:40.158 G  TX 01 03 00 00 00 64 44 21 
            var parts = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var day = int.Parse(parts[0]);
            var timestamp = DateTime.Parse(parts[1]);
            // Since we only get day in addition to time in the mdbus.log file, we use the rest of the date from the file
            timestamp = new DateTime(fileDate.Year, fileDate.Month, day, timestamp.Hour, timestamp.Minute, timestamp.Second, timestamp.Millisecond);
            var checksum = parts[2][0];
            var message = command.Substring(command.IndexOf(checksum) + 1).Trim();
            return new MdbusCommand(timestamp, checksum, message);
        }

        public override string ToString()
        {
            return TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + Checksum + " " + Message;
        }
    }

    class MdbusFile
    {
        public string FileName { get; private set; }

        public static MdbusFile CreateFromFile(string fileName)
        {
            var mdbusFile = new MdbusFile();
            mdbusFile.FileName = fileName;
            return mdbusFile;
        } 

        public MdbusCommand[] GetAllCommands()
        {
            var lines = System.IO.File.ReadAllLines(FileName);
            var fileDate = System.IO.File.GetLastWriteTime(FileName);
            var commands = new List<MdbusCommand>(lines.Length);

            foreach (var line in lines)
            {
                commands.Add(MdbusCommand.Parse(line, fileDate));
            }
            
            return commands.ToArray();
        }
    }
}
