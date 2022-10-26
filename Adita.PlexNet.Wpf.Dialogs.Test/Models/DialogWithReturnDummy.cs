using Adita.PlexNet.Core.Dialogs;

namespace Adita.PlexNet.Wpf.Dialogs.Test.Models
{
    public class DialogWithReturnDummy : Dialog<double?>
    {
        public void CallAccept()
        {
            Accept();
        }
        public void CallRefuse()
        {
            Refuse();
        }
        public void CallSubmit(double result)
        {
            Submit(result);
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
