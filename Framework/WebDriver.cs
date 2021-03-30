using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Framework
{
    public abstract class WebDriver
    {
        public static Browser BrowserBase { get; set; }
        public static Page PageBase { get; set; }
        public static async Task DownloadBrowser()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
        }

        public static async Task Initialize()
        {
            if (BrowserBase != null) await BrowserBase.CloseAsync();
            await DownloadBrowser();

            BrowserBase = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                Args = new[] { "--start-maximized" },
                DefaultViewport = null,
                Timeout = 10000
            });

            PageBase = await BrowserBase.NewPageAsync();
            PageBase.DefaultNavigationTimeout = (int)TimeSpan.FromSeconds(15).TotalMilliseconds;
        }

        public static async Task Cleanup()
        {
            if (BrowserBase == null) return;
            await BrowserBase.CloseAsync();
        }

        public static async Task<string> TakeScreenshotAsync(string testName)
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}", $"{testName}_{DateTime.UtcNow:ddMMMyyyy_HH.mm.ss}.jpg");
                await PageBase.ScreenshotAsync(fileName);
                return fileName;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to take screenschot: {e}");
                return null;
            }
        }
    }
}
