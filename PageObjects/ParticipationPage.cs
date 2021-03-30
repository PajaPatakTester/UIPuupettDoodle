using PuppeteerSharp;
using System.Threading.Tasks;

namespace PageObjects
{
    public class ParticipationPage : PageBase
    {
        public async Task<string> FetchInvitationLink()
        {
            var link = await FindElementByCss("#d-sharingView input");
            var property = await link.GetPropertyAsync("value");
            var value = property.RemoteObject.Value.ToString();
            return value;
        }

        public async Task<string> FetchParticipantName()
        {
            var name = await FindElementByCss(".d-participantInfo input");
            var property = await name.GetPropertyAsync("value");
            var value = property.RemoteObject.Value.ToString();
            return value;
        }

        public async Task<ElementHandle> FetchAnOption(string optionTxt)
        {
            var option = await FindElementContainingText(optionTxt, "#d-pollView .d-optionDetails .d-text");
            return option;
        }
    }
}
