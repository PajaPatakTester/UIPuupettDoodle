using System.Threading.Tasks;

namespace PageObjects
{
    public class WizardGeneralInformationPage : PageBase
    {
        public async Task EnterTitle(string title)
        {
            var inputField = await FindElementByCss("#d-pollTitle");
            await inputField.TypeAsync(title);
        }

        public async Task LocationSet(string location)
        {
            var inputField = await FindElementByCss("#d-pollLocation");
            await inputField.ClickAsync();
            var locationSelector = await FindElementContainingText(location, "li.d-locationSuggestion");
            await locationSelector.ClickAsync();
        }

        public async Task ContinueClick()
        {
            var btn = await FindElementByCss(".d-nextButton");
            await btn.ClickAsync();
        }
    }
}
