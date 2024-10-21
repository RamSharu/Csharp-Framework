﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Defra.UI.Tests.Feature.Acceptance.Exporter.Create
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PlaceOfOrigin")]
    [NUnit.Framework.CategoryAttribute("acceptance")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    public partial class PlaceOfOriginFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "acceptance",
                "Regression"};
        
#line 1 "PlaceOfOrigin.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Feature/Acceptance/Exporter/Create", "PlaceOfOrigin", "As an exporter, I want the ability to skip place of origin, so that I continue wi" +
                    "th my application and submit it to the certifier to help complete the informatio" +
                    "n I did not know", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Exporter tries to continue with blank fields without choosing skip")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", null)]
        public void ExporterTriesToContinueWithBlankFieldsWithoutChoosingSkip(string logininfo, string reference, string certificate, string commodityNumber, string noofidentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noofidentification", noofidentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Exporter tries to continue with blank fields without choosing skip", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 10
 testRunner.And("application page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("start a new application and click start now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And(string.Format("enter a unique application reference \'{0}\' and continue", reference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.And(string.Format("select certificate for your export \'{0}\' and continue", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noofidentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.When("I navigate to place of origin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.And("I press save and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
    testRunner.Then("I can see the validation informing me to select the skip checkbox validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Skip validation (and checkbox) disappears from bottom of page where all mandatory" +
            " details are populated")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", null)]
        public void SkipValidationAndCheckboxDisappearsFromBottomOfPageWhereAllMandatoryDetailsArePopulated(string logininfo, string reference, string certificate, string commodityNumber, string noofidentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noofidentification", noofidentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Skip validation (and checkbox) disappears from bottom of page where all mandatory" +
                    " details are populated", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 26
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 27
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 29
 testRunner.And("application page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
 testRunner.And("start a new application and click start now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.And(string.Format("enter a unique application reference \'{0}\' and continue", reference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.And(string.Format("select certificate for your export \'{0}\' and continue", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noofidentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.When("I navigate to place of origin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.And("I press save and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
    testRunner.Then("I can see the validation informing me to select the skip checkbox validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
 testRunner.When(string.Format("complete place of origin with \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\'", countryOfOrigin, placeOfDispatchCountry, placeOfDispatch, placeOfLoadingCountry, placeOfLoading), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("the skip validation message and checkbox is removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Exporter continues after selecting skip with some blank place of origin fields")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", null)]
        public void ExporterContinuesAfterSelectingSkipWithSomeBlankPlaceOfOriginFields(string logininfo, string reference, string certificate, string commodityNumber, string noofidentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noofidentification", noofidentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Exporter continues after selecting skip with some blank place of origin fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 48
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
 testRunner.Then(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.And("application page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
 testRunner.And("start a new application and click start now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And(string.Format("enter a unique application reference \'{0}\' and continue", reference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And(string.Format("select certificate for your export \'{0}\' and continue", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noofidentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.When("I navigate to place of origin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.And("I have ticked the skip checkbox for place of origin and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
 testRunner.When("I navigate to place of origin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
    testRunner.Then("I can still see the blank fields that I skipped with the skip tickbox still check" +
                        "ed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Skip checkbox no longer displayed when all mandatory place of origin fields are p" +
            "rovided")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", null)]
        public void SkipCheckboxNoLongerDisplayedWhenAllMandatoryPlaceOfOriginFieldsAreProvided(string logininfo, string reference, string certificate, string commodityNumber, string noofidentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noofidentification", noofidentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Skip checkbox no longer displayed when all mandatory place of origin fields are p" +
                    "rovided", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 66
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 67
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 68
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 69
 testRunner.Then(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 70
 testRunner.And("application page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.And("start a new application and click start now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And(string.Format("enter a unique application reference \'{0}\' and continue", reference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.And(string.Format("select certificate for your export \'{0}\' and continue", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noofidentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.When("I navigate to place of origin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 78
 testRunner.And(string.Format("complete place of origin with \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\'", countryOfOrigin, placeOfDispatchCountry, placeOfDispatch, placeOfLoadingCountry, placeOfLoading), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
 testRunner.Then("I can see that the skip checkbox is no longer there", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check operator approval no present in the operator search result in place of disp" +
            "atch")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", "Place of dispatch", null)]
        public void CheckOperatorApprovalNoPresentInTheOperatorSearchResultInPlaceOfDispatch(string logininfo, string reference, string certificate, string commodityNumber, string noOfIdentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string removeSection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noOfIdentification", noOfIdentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            argumentsOfScenario.Add("RemoveSection", removeSection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check operator approval no present in the operator search result in place of disp" +
                    "atch", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 85
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 86
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 87
 testRunner.And(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("setup an application via backend", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.And(string.Format("I deeplink to the commodity selection page with certificate \'{0}\'", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 91
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noOfIdentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 93
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
 testRunner.When("I navigate to place of origin page from Task list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
 testRunner.Then(string.Format("Check Operator Approval no present in the operator search in Place of Despatch wi" +
                            "th \'{0}\',\'{1}\', \'{2}\'", countryOfOrigin, placeOfDispatchCountry, placeOfDispatch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check operator approval no present in the operator search result in place of load" +
            "ing")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", "Place of dispatch", null)]
        public void CheckOperatorApprovalNoPresentInTheOperatorSearchResultInPlaceOfLoading(string logininfo, string reference, string certificate, string commodityNumber, string noOfIdentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string removeSection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noOfIdentification", noOfIdentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            argumentsOfScenario.Add("RemoveSection", removeSection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check operator approval no present in the operator search result in place of load" +
                    "ing", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 101
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 102
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 103
 testRunner.And(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
 testRunner.And(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.And("setup an application via backend", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 106
 testRunner.And(string.Format("I deeplink to the commodity selection page with certificate \'{0}\'", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noOfIdentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 110
 testRunner.When("I navigate to place of origin page from Task list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 111
 testRunner.Then(string.Format("Check Operator Approval no present in the operator search in Place of Loading wit" +
                            "h \'{0}\',\'{1}\', \'{2}\'", countryOfOrigin, placeOfLoadingCountry, placeOfLoading), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check operator approval no present after selection of place of dispatch and place" +
            " of loading")]
        [NUnit.Framework.TestCaseAttribute("exporter", "skiptest", "EHC8361", "030231", "1", "GB", "GB", "Defra eTrade", "GB", "Defra eTrade", "Place of dispatch", null)]
        public void CheckOperatorApprovalNoPresentAfterSelectionOfPlaceOfDispatchAndPlaceOfLoading(string logininfo, string reference, string certificate, string commodityNumber, string noOfIdentification, string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string removeSection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("reference", reference);
            argumentsOfScenario.Add("certificate", certificate);
            argumentsOfScenario.Add("commodityNumber", commodityNumber);
            argumentsOfScenario.Add("noOfIdentification", noOfIdentification);
            argumentsOfScenario.Add("CountryOfOrigin", countryOfOrigin);
            argumentsOfScenario.Add("PlaceOfDispatchCountry", placeOfDispatchCountry);
            argumentsOfScenario.Add("PlaceOfDispatch", placeOfDispatch);
            argumentsOfScenario.Add("PlaceOfLoadingCountry", placeOfLoadingCountry);
            argumentsOfScenario.Add("PlaceOfLoading", placeOfLoading);
            argumentsOfScenario.Add("RemoveSection", removeSection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check operator approval no present after selection of place of dispatch and place" +
                    " of loading", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 118
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 119
 testRunner.Given("that I navigate to the DEFRA application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 120
 testRunner.And(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 121
 testRunner.And(string.Format("check the user is \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 122
 testRunner.And("setup an application via backend", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 123
 testRunner.And(string.Format("I deeplink to the commodity selection page with certificate \'{0}\'", certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 124
 testRunner.And(string.Format("select commodity \'{0}\' and continue", commodityNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 125
 testRunner.And(string.Format("add commodity \'{0}\' for \'{1}\' data and continue", noOfIdentification, certificate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 126
 testRunner.And("verify commodity has been added successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
 testRunner.When("I navigate to place of origin page from Task list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 128
 testRunner.And(string.Format("complete place of origin with \'{0}\',\'{1}\', \'{2}\', \'{3}\', \'{4}\'", countryOfOrigin, placeOfDispatchCountry, placeOfDispatch, placeOfLoadingCountry, placeOfLoading), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 129
 testRunner.Then("verify approval no present in the place of dispatch and place of loading selectio" +
                        "ns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
