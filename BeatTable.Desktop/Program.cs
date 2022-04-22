using osu.Framework.Platform;
using osu.Framework;
using BeatTable.Game;

namespace BeatTable.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"BeatTable"))
            using (osu.Framework.Game game = new BeatTableGame())
                host.Run(game);
        }
    }
}
