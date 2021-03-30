using System.Threading.Tasks;

namespace PageObjects
{
    public class WizardSettingsPage : PageBase
    {
        public async Task ContinueClick()
        {
            var btn = await FindElementByCss("#d-wizardSettingsNavigationView .d-nextButton");
            await btn.ClickAsync();
        }
    }
}
