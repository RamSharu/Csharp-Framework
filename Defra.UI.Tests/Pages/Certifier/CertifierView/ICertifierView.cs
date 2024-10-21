using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Certifier.CertifyEHC
{
    public interface ICertifierView
    {
        public bool IsCertifierViewPage { get; }
        public bool IsAdditionalDocsSection { get; }
        public void ClickAdditionalDocsTabLink();
        public void ClickEditAdditionalDocsLink();
        public bool ClickPart1Tab(string TabName);
        public bool EditConsigneeDetails(string Country, string ConsigneeName);
        public bool VerifyConsigneeDetails(string ConsigneeName);
        public bool EditConsignorDetails(string ConsignorName);
        public bool VerifyConsignorDetails(string ConsignorName);
        public bool EditGrossWeightOnCertifier(string grossWeightAmount, string grossWeightUnit);
        public bool EditContainerSealNumberOnCertifier(string containeNumber, string sealNumber);
        bool VerifyIfContinerNumberSealNumbersAndRowCountAreValid(string containerNumber, string sealNumber);
        public bool VerifyIfGrossWeightUpdatedSuccessfully(string grossWeightAmount);
        public void ClickOnCertificationPart2();
        public void ClickSignAndApprove();
        public void ClickCheckApplicationDataTraces();
        public string[] ValidateandVerifyErrorforDocuments();
        public void ClickBackButtonOnApplicationSummary();
        public string[] ValidateandVerifyErrorforQuantityTotal();
        public void ClickOnGrossWeightEdithLink();
        public void ClickOnPlaceOfOriginEditLink();
        public void ClickOnBCPEditLink();
        public bool IsDiseaseClearancePanelDisplayed { get; }
        public string DiseaseClearancePanelHeaderText { get; }
        public string ChecksPerformedQuestionText { get; }
        public bool ChecksPerformedHintText { get; }
        public bool IsDiseaseClearanceTextBoxDisplayed { get; }
        public bool EditMeansOfTransportOnCertifier();
        public bool VerifyIfMeansOfTransportSummaryErrorFousAndAriaDescribedByValid();
    }
}