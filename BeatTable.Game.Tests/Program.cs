﻿using osu.Framework;
using osu.Framework.Platform;

namespace BeatTable.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost("visual-tests"))
            using (var game = new BeatTableTestBrowser())
                host.Run(game);
        }
    }
}
