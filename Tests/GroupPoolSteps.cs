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
        public void ThenInvitationLinkShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"participant name should be '(.*)'")]
        public void ThenParticipantNameShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"pool options should be")]
        public void ThenPoolOptionsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
