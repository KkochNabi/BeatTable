using osu.Framework.Testing;

namespace BeatTable.Game.Tests.Visual
{
    public class BeatTableTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new BeatTableTestSceneTestRunner();

        private class BeatTableTestSceneTestRunner : BeatTableGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
