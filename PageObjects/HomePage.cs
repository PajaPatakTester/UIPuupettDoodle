using System.Threading.Tasks;
using Framework;
using PuppeteerSharp;

namespace PageObjects
{
    public class HomePage : PageBase
    {
        private const string Url = "https://www.doodle.com/en/";


        public async Task GoTo()
        {
            await WebDriver.PageBase.GoToAsync(Url, 10000, waitUntil: new[] { WaitUntilNavigation.Networkidle0 });
        }

        public async Task CreateADoodleClick()
        {
            var button = await FindElementByCss("span.CreatePollMenu-createMenuLabel");
            await button.ClickAsync();
            await WaitForLoader();
        }
    }
}