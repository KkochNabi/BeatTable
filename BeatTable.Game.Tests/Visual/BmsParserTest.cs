using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace BeatTable.Game.Tests.Visual
{
    public class BmsParserTest : BeatTableTestScene
    {
        public BmsParserTest()
        {
            Add(new ScreenStack(new BmsParserTestScreen()) { RelativeSizeAxes = Axes.Both });
        }
    }
}

