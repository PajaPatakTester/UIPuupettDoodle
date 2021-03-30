using FluentAssertions;
using Framework;
using NUnit.Framework;
using PageObjects;
using PuppeteerSharp.Contrib.Extensions;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class GroupPoolSteps : TestBase
    {
        public GroupPoolSteps(ScenarioContext scenarioContext, FeatureContext featureContext, TestContext testContext) : base(scenarioContext, featureContext, testContext)
        { }

        private HomePage _homePage = new HomePage();
        private WizardGeneralInformationPage _generalInfoPage = new WizardGeneralInformationPage();
        private WizardOptionsPage _optionsPage = new WizardOptionsPage();
        private WizardSettingsPage _settingsPage = new WizardSettingsPage();
        private WizardInitiatorPage _initiatorPage = new WizardInitiatorPage();
        private ParticipationPage _participationPage = new ParticipationPage();

        [Given(@"create his first doodle action")]
        public async Task GivenCreateHisFirstDoodleAction()
        {
            await _generalInfoPage.LocationSet("Skype");
        }

        [Given(@"unregistred user initiate his first doodle action")]
        public async Task GivenUnregistredUserInitiateHisFirstDoodleAction()
        {
            await _homePage.GoTo();
            await _homePage.CreateADoodleClick();
        }

        [Given(@"set a title of the occasion")]
        public async Task GivenSetATitleOfTheOccasion()
        {
            await _generalInfoPage.EnterTitle("Test title");
            await _generalInfoPage.ContinueClick();
        }

        [Given(@"add text options:")]
        public async Task GivenAddTextOptions(Table table)
        {
            var dictionary = CommonActions.TableToDictionary(table);

            await _optionsPage.TextClick();

            await _optionsPage.EnterFirstOption(dictionary[1]);
            await _optionsPage.EnterSecondOption(dictionary[2]);

            await _optionsPage.ContinueClick();
        }

        [Given(@"skip Pool settings")]
        public async Task GivenSkipPoolSettings()
        {
            await _settingsPage.ContinueClick();
        }

        [When(@"enter participant name '(.*)' and email address")]
        public async Task WhenEnterParticipantNameAndEmailAddress(string name)
        {
            await _initiatorPage.EnterName(name);
            await _initiatorPage.EnterEmail("dummyEmail@test.com");

            await _initiatorPage.FinishClick();
        }

        [Then(@"invitation link should be created")]
        public async Task ThenInvitationLinkShouldBeCreated()
        {
            var fetchedLink = await _participationPage.FetchInvitationLink();
            fetchedLink.Should().NotBeNullOrEmpty(because: "Link should be created, but it is not the case.");
        }

        [Then(@"participant name should be '(.*)'")]
        public async Task ThenParticipantNameShouldBe(string name)
        {
            var fetchedName = await _participationPage.FetchParticipantName();
            fetchedName.Should().BeEquivalentTo(name, because: $"Participant should be \"{name}\", but it is not the case.");
        }

        [Then(@"pool options should be")]
        public async Task ThenPoolOptionsShouldBe(Table table)
        {
            var dictionary = CommonActions.TableToDictionary(table);

            var firstOption = await _participationPage.FetchAnOption(dictionary[1]);
            firstOption.Should().NotBeNull(because: $"Option \"{dictionary[1]}\" should be present, but it is not the case.");

            var secondOption = await _participationPage.FetchAnOption(dictionary[2]);
            secondOption.Should().NotBeNull(because: $"Option \"{dictionary[2]}\" should be present, but it is not the case.");
        }


    }
}
