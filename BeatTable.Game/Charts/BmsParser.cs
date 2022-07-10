using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeatTable.Game.Charts
{
    public class BmsParser : IChartFormatParser // TODO: Make this entire class and interface static
    {
        private static int player;
        private static string genre;
        private static string title;
        private static string artist;
        private static int bpm;
        private static int playLevel;
        private static int rank;
        private static int volWav;
        private static int total;
        private static string stageFile;
        private static Dictionary<string, string> musicFiles;
        private static Dictionary<string, string> graphicFiles;

        private static void setPlayer(string value) => player = int.Parse(value);
        private static void setGenre(string value) => genre = value;
        private static void setTitle(string value) => title = value;
        private static void setArtist(string value) => artist = value;
        private static void setBpm(string value) => bpm = int.Parse(value);
        private static void setPlayLevel(string value) => playLevel = int.Parse(value);
        private static void setRank(string value) => rank = int.Parse(value);
        private static void setVolWav(string value) => volWav = int.Parse(value);
        private static void setTotal(string value) => total = int.Parse(value);
        private static void setStageFile(string value) => stageFile = value;
        private static void addWav(string id, string value) => musicFiles.Add(id, value);
        private static void addOgg(string id, string value) => musicFiles.Add(id, value); // TODO: Decide if distinguishing filetypes is necessary
        private static void addBmp(string id, string value) => graphicFiles.Add(id, value);

        private readonly Dictionary<string, Action<string>> headerCommands = new()
        {
            { "PLAYER", setPlayer },
            { "GENRE", setGenre },
            { "TITLE", setTitle },
            { "ARTIST", setArtist },
            { "BPM", setBpm },
            { "PLAYLEVEL", setPlayLevel },
            { "RANK", setRank },
            { "VOLWAV", setVolWav },
            { "TOTAL", setTotal },
            { "STAGEFILE", setStageFile }
        };

        private readonly Dictionary<string, Action<string, string>> fileCommands = new()
        {
            { "WAV", addWav },
            { "OGG", addOgg },
            { "BMP", addBmp }
        };

        public BmsParser(string path) => Parse(new List<string>(File.ReadAllLines(path)));
        public BmsParser(List<string> data) => Parse(data);
        public BmsParser() { }

        public Chart Parse(List<string> data)
        {
            var split = new Func<string, string[]>(s => s.Split(' ', 2));
            // TODO: Use range indexers instead of substring
            var splitId = new Func<string, string[]>(s => new string[] { s.Substring(0, s.Length - 2), s.Substring(s.Length - 2) });

            // Every useful line starts with # (comments starting with * will be ignored)
            foreach (string line in data.Where(l => l.StartsWith("#")))
            {
                var splitLine = split(line.Remove(0, 1));

                switch (splitLine.Length)
                {
                    case 1:
                        if (splitLine[0].Contains(":"))
                        {
                            // Guaranteed to contain data in the form of #XXXYY:ZZZZZZ...
                            // XXX defines the measure
                            // YY defines the channel
                            // ZZZZZZ defines the data
                            // The data is split into groups of 2 digits, each representing a value in base 36 (0-9, a-z)

                            // TODO: Check if you can use range indexers instead of substring
                            var measure = int.Parse(splitLine[0][..3]);
                            var channel = int.Parse(splitLine[0].Substring(3, 2));
                            var components = splitLine[0][6..];

                            break;
                        }

                        break;

                    case 2:
                        // Header commands follow the format #<command> <value>
                        if (headerCommands.ContainsKey(splitLine[0]))
                        {
                            headerCommands[splitLine[0]](splitLine[1]);
                            break;
                        }

                        // Commands declaring files follow the format #<filetype><id> <filename>>
                        var command = splitId(splitLine[0]);

                        if (fileCommands.ContainsKey(command[1]))
                        {
                            fileCommands[command[0]](command[0], command[1]);
                            break;
                        }

                        if (splitLine[0].ToLower() == "if") // TODO: Implement if statements within data
                            throw new NotImplementedException();

                        break;

                    default: // Don't know what to do with this data, so ignore it
                        continue;
                }
            }

            throw new System.NotImplementedException();
        }

        public int ConvertTo(Chart data)
        {
            throw new System.NotImplementedException();
        }
    }
}
