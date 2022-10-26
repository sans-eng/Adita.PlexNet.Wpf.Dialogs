using Adita.PlexNet.Core.Dialogs;

namespace Adita.PlexNet.Wpf.Dialogs.Test.Models
{
    public class DialogDummy : Dialog
    {
        public void CallAccept()
        {
            Accept();
        }
        public void CallRefuse()
        {
            Refuse();
        }
        public void CallSubmit()
        {
            Submit();
        }
        public void CallCancel()
        {
            Cancel();
        }
        public void CallIgnore()
        {
            Ignore();
        }
        public void CallAbort()
        {
            Abort();
        }
    }
}
