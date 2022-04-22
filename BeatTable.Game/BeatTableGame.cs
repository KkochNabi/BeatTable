using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace BeatTable.Game
{
    public class BeatTableGame : BeatTableGameBase
    {
        private ScreenStack mainScreenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            mainScreenStack = new ScreenStack { RelativeSizeAxes = Axes.Both, };
            Children = new List<ScreenStack> { mainScreenStack };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            mainScreenStack.Push(new MainScreen());
        }
    }
}
