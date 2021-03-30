using System;
using System.Collections.Generic;
using System.Text;
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
            var property = await inputField.GetPropertyAsync("value");
        }
    }
}
