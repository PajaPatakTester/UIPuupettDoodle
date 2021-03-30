
using System.Threading.Tasks;

namespace PageObjects
{
    public class WizardSettingsPage : PageBase
    {
        public async Task ContinueClick()
        {
            var btn = await FindElementByCss("#d-wizardOptionsNavigationView .d-nextButton");
            await btn.ClickAsync();
        }
    }
}
