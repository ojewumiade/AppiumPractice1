using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Training8A.PageObjects;
using Training8A.Utilities;

namespace Training8A.StepDefinitions
{
    [Binding]
    public class RegistrationsSteps
    {
        RegistrationPage registration;

        public RegistrationsSteps()
        {
            registration = new RegistrationPage();
        }

        [Given(@"I navigate to the site")]
        public void GivenINavigateToTheSite()
        {
            Hooks.Driver.Navigate().GoToUrl("http://www.giftrete.com");
            Hooks.Driver.Manage().Window.Maximize();
        }
        
        [When(@"Click on register link")]
        public void WhenClickOnRegisterLink()
        {
            registration.ClickOnRegister();
        }
        
        [When(@"I enter firstname")]
        public void WhenIEnterFirstname()
        {
            registration.EnterFirstName();
        }
        
        [When(@"I enter last name")]
        public void WhenIEnterLastName()
        {
            registration.EnterLastName();
        }

        [When(@"I enter emailadd")]
        public void WhenIEnterEmailadd()
        {
            registration.EnterEmailAddress();
        }



        [When(@"I enter mobile number")]
        public void WhenIEnterMobileNumber()
        {
            registration.EnterMobileNumber();
        }
        
        [When(@"I enter password")]
        public void WhenIEnterPassword()
        {
            registration.EnterPassword();
        }
        
        [When(@"I confirm password")]
        public void WhenIConfirmPassword()
        {
            registration.EnterConfirmPassword();
        }
        
        [When(@"the click on signUp")]
        public void WhenTheClickOnSignUp()
        {
            registration.ClickSignUP();
        }

        [Then(@"I not should be registered")]
        public void ThenINotShouldBeRegistered()
        {
            Thread.Sleep(5000);
            
            // NUnit Assertion
            // Assert.Equals(registration.ConfirmNotRegistrationMessage(), true); (For other examples)
            // Assert.True(registration.ConfirmNotRegistrationMessage(), "This is register Error Message");

            //FluentAssertions: First add the Nuget Package
            // registration.ConfirmNotRegistrationMessage().Should().BeFalse("Error Message: registration Failed");
            registration.ConfirmNotRegistrationMessage().Should().Be(true);
        }

        [When(@"I enter incompleted emailadd error text")]
        public void WhenIEnterIncompletedEmailadd()
        {
            Thread.Sleep(1000);
            Assert.IsTrue (registration.confirmIncompleteEmailError());
        }

        [When(@"I confirm incomplete password error text")]
        public void WhenIConfirmIncompletePassword()
        {
            registration.confirmIncompleteConfirmationPasswordError().Should().Be(true);
        }

        [When(@"I enter incomplete emailadd ""(.*)""")]
        public void WhenIEnterIncompleteEmailadd(string mailadd)
        {
            registration.EnterIncompleteMailAdd(mailadd);
        }

        [When(@"I confirm incomplete password ""(.*)""")]
        public void WhenIConfirmIncompletePassword(string pswd)
        {
            registration.EnterIncompleteConfirmPassword(pswd);
        }

        [Then(@"the Error ""(.*)"" is displayed for ""(.*)""")]
        public void ThenTheErrorIsDisplayedFor(string message, string test)
        {
            registration.GetErrorTextIncompleteEmail();        }


    }
}
