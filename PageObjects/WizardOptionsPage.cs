using System.Threading.Tasks;

namespace PageObjects
{
    public class WizardOptionsPage : PageBase
    {
        public async Task TextClick()
        {
            var textLink = await FindElementContainingText("Text", "#d-monthWeekTabSwitchView a");
            await textLink.ClickAsync();
        }

        public async Task EnterFirstOption(string inputText)
        {
            var inputField = await FindElementByCss("#d-wizardChoicesView0");
            await inputField.TypeAsync(inputText);
        }

        public async Task EnterSecondOption(string inputText)
        {
            var inputField = await FindElementByCss("#d-wizardChoicesView1");
            await inputField.TypeAsync(inputText);
        }

        public async Task ContinueClick()
        {
            var btn = await FindElementByCss("#d-wizardOptionsNavigationView .d-nextButton");
            await btn.ClickAsync();
        }
    }
}
