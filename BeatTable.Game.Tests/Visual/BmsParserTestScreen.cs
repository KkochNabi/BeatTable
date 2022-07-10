using System.IO;
using BeatTable.Game.Charts;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Screens;
using osuTK;

namespace BeatTable.Game.Tests.Visual;

public class BmsParserTestScreen : Screen
{
    // TODO: Properly name variables
    private SpriteText inputTest;
    private SpriteText dynamicText;
    private BasicTextBox sampleTextBox;
    private string testFilePath;
    private SpriteText testOutput;
    private Chart testChart;
    private BmsParser parser;
    private bool testFilesFound => File.Exists(testFilePath);

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            inputTest = new SpriteText()
            {
                Text = "Sample Text",
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(0, 0),
                Font = new FontUsage(size: 20)
            },
            new SpriteText()
            {
                Text = "Sample Files Directory",
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Position = new Vector2(0, 0),
                Font = new FontUsage(size: 20)
            },
            sampleTextBox = new BasicTextBox()
            {
                Text = "",
                Position = new Vector2(0, 25),
                Height = 20,
                Width = 400,
            },
            dynamicText = new SpriteText()
            {
                Text = "",
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Position = new Vector2(0, 50),
                Font = new FontUsage(size: 20),
                Colour = new Colour4(255, 0, 0, 255)
            },
            testOutput = new SpriteText()
            {
                Text = "",
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Position = new Vector2(0, 0),
                Font = new FontUsage(size: 20),
            }
        };
    }

    protected override void Update()
    {
        if (dynamicText.Text != sampleTextBox.Text)
        {
            dynamicText.Text = testFilePath = sampleTextBox.Text + "\\test.bms";
            dynamicText.FadeColour(testFilesFound ? new Colour4(255, 255, 255, 255) : new Colour4(255, 0, 0, 255), 50);
        }

        if (testFilesFound && testOutput.Text == "")
        {
            parser = new BmsParser(testFilePath);
            testOutput.Text = "File Loaded";
        }

        base.Update();
    }
}
