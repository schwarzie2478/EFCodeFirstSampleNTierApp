using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace ServiceActivation.Specs
{
    [Binding]
    public class BusinessControllerSteps
    {
        private Calculator calci = new Calculator();
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            calci.FirstNumber = p0;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            calci.SecondNumber = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calci.AddPressed();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, calci.Result);
        }
    }
}
