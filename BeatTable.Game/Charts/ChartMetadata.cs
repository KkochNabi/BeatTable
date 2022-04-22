namespace BeatTable.Game.Charts
{
    public struct ChartMetadata
    { // TODO: Find and implement missing metadata types from all formats
        public string Genre;
        public string Title;
        public string Artist;
        public int BPM;
        public string Subtitle;
        public int Difficulty;
        public int Total;
        public int Lntype;

        public ChartMetadata(string genre, string title, string artist, int bpm, string subtitle, int difficulty, int total, int lntype)
        {
            Genre = genre;
            Title = title;
            Artist = artist;
            BPM = bpm;
            Subtitle = subtitle;
            Difficulty = difficulty;
            Total = total;
            Lntype = lntype;
        }
    }
}
