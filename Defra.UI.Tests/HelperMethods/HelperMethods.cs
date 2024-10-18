﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;

namespace Defra.UI.Tests.HelperMethods
{
    internal static class HelperMethods
    {
        public static void SelectFromDropdown(this IWebDriver driver, IWebElement Element, string value)
        {
            SelectElement dropDown = new SelectElement(Element);
            dropDown.SelectByValue(value);
        }

        private static void SelectFromDropdownJS(this IWebDriver driver, IWebElement Element, string value)
        {
            string script = $"const element = arguments[0]; element.value = '" + value + "'; element.dispatchEvent(new Event('change')); element.dispatchEvent(new Event('blur'));";
            ((IJavaScriptExecutor)driver).ExecuteScript($"{script}", Element);
        }

        public static void ClickRadioButton(this IWebDriver driver, string code)
        {
            IWebElement commLabel = driver.WaitForElement(By.XPath($"//label[contains(.,'{code}')]"));
            bool commRadioButton = commLabel.Text.Contains(code);
            if (commRadioButton)
            {
                var eleme = driver.FindElements(By.TagName("input"));
                eleme.LastOrDefault().Click();
            }
        }

        public static IReadOnlyCollection<IWebElement> GetRadioButtonChildElements(this IWebDriver driver, string code)
        {
            IReadOnlyCollection<IWebElement> commLabel = driver.WaitForElements(By.XPath($"//label[contains(.,'{code}')]"));
            return commLabel;
        }

        public static void ClickFristRadioButton(this IWebDriver driver, string code)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath($"//label[contains(text(),'{code}')]")).Text.Contains(code));
        }

        public static void ClickRadioButtonOption(this IWebDriver driver, string radioOption)
        {
            IWebElement radioLabel = driver.WaitForElement(By.XPath($"//label[contains(.,'{radioOption}')]"));
            radioLabel.Click();
        }
    }
}
