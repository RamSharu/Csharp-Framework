using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Exporter.AccompanyingDocs
{
    public interface IAccompanyingDocs
    {
        public bool IsAccompanyingDocsPage();
        public bool IsAccompanyingDocAdded { get; }
        public void CheckIfDocAlreadyAdded();
        public bool AddDocument(string docType, string docRef);
        public bool VerifyIfDocIsAddedSuccessfully { get; }
        public bool VerifyAccompanyingDocStatus();
    }
}
