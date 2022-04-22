using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace BeatTable.Game
{
    public class MainScreen : Screen
    {
        private BasicDropdown<Anchor> dropDown;
        private Checkbox checkbox;
        private SpriteText checkboxValText;
        private Anchor anchor;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                },
                new SpriteText
                {
                    Y = 20,
                    Text = "Main Screen",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font = FontUsage.Default.With(size: 40)
                },
                new SpinningBox
                {
                    Anchor = Anchor.Centre,
                },
                dropDown = new BasicDropdown<Anchor>()
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Items = new List<Anchor>() { Anchor.BottomLeft, Anchor.BottomCentre, Anchor.BottomRight },
                    Width = 200,
                },
                checkbox = new BasicCheckbox()
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                },
                checkboxValText = new SpriteText()
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    X = 60,
                    Y = 5,
                    Text = "False",
                    Font = FontUsage.Default.With(size: 40),
                },
                new BasicTextBox()
                {
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    Height = 60,
                    Width = 200
                },
            };
        }

        protected override void Update()
        {
            checkboxValText.Text = checkbox.Current.Value ? "True" : "False";

            base.Update();
        }
    }
}
