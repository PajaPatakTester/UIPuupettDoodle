using NUnit.Framework;
using System.Diagnostics;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Framework
{
    [Binding]
    public abstract class TestBase
    {
        private Stopwatch _stopwatch = new Stopwatch();
        public ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public TestContext _testContext;

        public TestBase(ScenarioContext scenarioContext, FeatureContext featureContext, TestContext testContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _testContext = testContext;
        }

        [BeforeScenario]
        public async Task Init()
        {
            _stopwatch.Restart();
            await WebDriver.Initialize();
        }

        [AfterScenario]
        public async Task Cleanup()
        {
            _stopwatch.Stop();

            if (!TestCompletedWithoutErrors())
            {
                await TakeScreenshotAsync(_featureContext.FeatureInfo.Title + "_" + _scenarioContext.ScenarioInfo.Title.ToString());
                ErrorCleanup();
            }
            else
            {
                TestCleanup();
            }

            await WebDriver.Cleanup();
        }

        protected virtual void TestCleanup() { }

        protected virtual void ErrorCleanup() { }


        private async Task TakeScreenshotAsync(string name)
        {
            var fileName = await WebDriver.TakeScreenshotAsync(name);
            if (fileName != null) TestContext.AddTestAttachment(fileName);
        }

        public bool TestCompletedWithoutErrors()
        {
            return _scenarioContext.TestError == null;
        }
    }
}
