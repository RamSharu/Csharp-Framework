using OpenQA.Selenium.DevTools.V106.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Exporter.CommoditySummary
{
    public interface ICommoditySummary
    {
        public bool IsCommoditiesSummaryPage { get; }
        public void ClickChangeLink();
        public void ClickCopyLink();
        public bool IsCommoditySummaryPage();
        public void ClickShowDetails();
        public bool IsLabelTagNotEntered();
        public void ClickNoForAddMoreRecords(string No);
        public void ClickRadioOptionForAnotherRecord(string radioOption);
    }
}
