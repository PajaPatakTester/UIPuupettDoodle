using Framework;
using NUnit.Framework;
using PuppeteerSharp;
using PuppeteerSharp.Contrib.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjects
{
    public abstract class PageBase
    {
        private string NameToCss(string name) => String.Format("[name='{0}']", name);

        #region Wait methods
        private readonly WaitForSelectorOptions waitForSelectorOptions = new WaitForSelectorOptions();

        private readonly NavigationOptions navigationOptions = new NavigationOptions
        {
            WaitUntil = new[] { WaitUntilNavigation.Networkidle0 },
        };

        public async Task WaitForNetworkIdle(int timeout = 15000)
        {
            navigationOptions.Timeout = timeout;
            await WebDriver.PageBase.WaitForNavigationAsync(navigationOptions);
        }

        private async Task WaitForCssElement(string css, int timeout)
        {
            waitForSelectorOptions.Timeout = timeout;
            await WebDriver.PageBase.WaitForSelectorAsync(css, waitForSelectorOptions);
        }

        public async Task WaitForALoader(double maxWaitSec = 10)
        {
            while (maxWaitSec > 0)
            {
                var loader = await FindElementByCss("div.loderStyle");
                var property = await loader.GetAttributeAsync("style");
                var style = property.ToString();
                if (style.Contains("display: none")) break;
                Thread.Sleep(TimeSpan.FromMilliseconds(300));
                maxWaitSec -= 0.3;
            }
        }

        public async Task WaitForAnElement(string css, double maxWaitSec = 10)
        {
            while (maxWaitSec > 0)
            {
                var loader = await FindElementsByCss(css, 100);
                if (loader.Length == 1) break;
                Thread.Sleep(TimeSpan.FromMilliseconds(200));
                maxWaitSec -= 0.3;
            }
        }
        #endregion

        #region Finding element(s)
        public async Task<ElementHandle> FindElementByCss(string css, int timeout = 15000)
        {
            await WaitForCssElement(css, timeout);
            ElementHandle element = await WebDriver.PageBase.QuerySelectorAsync(css);
            return element;
        }

        public async Task<ElementHandle> FindElementByName(string name, int timeout = 15000)
        {
            return await FindElementByCss(NameToCss(name), timeout);
        }

        public async Task<ElementHandle[]> FindElementsByCss(string css, int timeout = 15000)
        {
            try
            {
                await WaitForCssElement(css, timeout);
            }
            catch
            {
                // ignore error
            }
            ElementHandle[] elements = await WebDriver.PageBase.QuerySelectorAllAsync(css);
            return elements;
        }

        public async Task<ElementHandle> FindElementContainingText(string txt, string cssSelector)
        {
            var elements = await FindElementsByCss(cssSelector);
            foreach (var element in elements)
            {
                var elementText = await element.TextContentAsync();
                if (elementText.Contains(txt)) return element;
            }
            TestContext.WriteLine($"!!!UPS!!! Did not find element  \"{cssSelector}\" containing text: \"{txt}\"!!!");
            return null;
        }
        #endregion

        #region Fetch data from an element
        public async Task<string> GetTextFromElement(string elementName)
        {
            var element = await FindElementByName(elementName);
            return await element.TextContentAsync();
        }

        public async Task<string> GetValueFromSelector(string elementName)
        {
            elementName = NameToCss(elementName) + " [selected]";
            var element = await FindElementByCss(elementName);
            var property = await element.GetPropertyAsync("value");
            var value = property.RemoteObject.Value.ToString();
            return value;
        }

        public async Task<string> GetValueFromElement(string elementName)
        {
            var element = await FindElementByName(elementName);
            var property = await element.GetPropertyAsync("value");
            var value = property.RemoteObject.Value.ToString();
            return value;
        }

        #endregion
    }
}
