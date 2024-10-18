using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Exporter.ApplicationReference
{
    public interface IApplicationReference
    {
        public bool IsApplicationReferencePage { get; }
        public bool IsCopyApplicationReferencePage { get; }
        public void CreateNewReferenceOnCopyApp();
        public string ChangeApplicationReference();
        public void ClickCreateCopyButton();
        public void InvalidApplicationReference(int noOfCharacters);
        public bool ValidationError(string error);
    }
}
