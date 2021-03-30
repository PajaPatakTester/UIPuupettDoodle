using System.Threading.Tasks;

namespace PageObjects
{
    public class WizardInitiatorPage : PageBase
    {
        public async Task EnterName(string name)
        {
            var inputField = await FindElementByCss("input#d-initiatorName");
            await inputField.TypeAsync(name);
        }

        public async Task EnterEmail(string name)
        {
            var inputField = await FindElementByCss("#d-initiatorEmailInput input");
            await inputField.TypeAsync(name);
        }

        public async Task FinishClick()
        {
            var finishButton = await FindElementByCss("#d-persistPollButton");
            await finishButton.ClickAsync();
        }

    }
}
