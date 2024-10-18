using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.ApplicationComplete
{
    public interface IApplicationComplete
    {
        public bool IsApplicationCompletePage { get; }

        public void ClickFinishButton();
        public string GetApplicationSerialReference();
    }
}
