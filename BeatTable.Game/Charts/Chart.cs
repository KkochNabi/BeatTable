using System;

namespace BeatTable.Game.Charts
{
    public class Chart
    {
        private int song; // TODO: Create song object
        private int notes; // TODO: Create notes object

        public int ChartHash => throw new NotImplementedException(); // TODO; Create hash of notes or get it from song list db

        private ChartMetadata metadata { get; }
        private string genre => metadata.Genre;
        private string title => metadata.Title;
        private string artist => metadata.Artist;
        private int bpm => metadata.BPM;
        private string subtitle => metadata.Subtitle;
        private int difficulty => metadata.Difficulty;
        private int total => metadata.Total;
        private int lntype => metadata.Lntype;

        public Chart(int song, int notes, ChartMetadata metadata)
        {
            this.song = song;
            this.notes = notes;
            this.metadata = metadata;
        }
    }
}
