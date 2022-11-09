using Adita.PlexNet.Core.Dialogs;
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Interop;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a base class for dialog container.
    /// </summary>
    public class DialogContainerBase : Window
    {
        #region Private constants
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_DLGMODALFRAME = 0x0001;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const uint WM_SETICON = 0x0080;
        #endregion Private constants

        #region Private static constructors
        static DialogContainerBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogContainerBase), new FrameworkPropertyMetadata(typeof(DialogContainerBase)));
        }
        #endregion Private static constructors

        #region Public instance constructors
        /// <summary>
        /// Initialize a new instace of <see cref="DialogContainerBase"/>.
        /// </summary>
        public DialogContainerBase()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;

            RemoveIcon(this);
        }
        #endregion Public instance constructors

        #region Protected methods
        /// <summary>
        /// Closes the dialog using specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">An <see cref="DialogActionResult"/> to close the dialog.</param>
        protected void CloseDialog(DialogActionResult action)
        {
            switch (action)
            {
                case DialogActionResult.None:
                    DialogResult = false;
                    break;
                case DialogActionResult.Accept:
                    DialogResult = true;
                    break;
                case DialogActionResult.Refuse:
                    DialogResult = false;
                    break;
                case DialogActionResult.Submit:
                    DialogResult = true;
                    break;
                case DialogActionResult.Cancel:
                case DialogActionResult.Ignore:
                case DialogActionResult.Abort:
                    DialogResult = false;
                    break;
            }
        }
        /// <summary>Raises the <see cref="E:System.Windows.Window.SourceInitialized" /> event.</summary>
        /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            RemoveIcon(this);
            base.OnSourceInitialized(e);
        }
        #endregion Protected methods

        #region Private methods
        private static void RemoveIcon(Window window)
        {
            if (window == null)
            {
                return;
            }

            var hWnd = new WindowInteropHelper(window).Handle;

            var exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            _ = SetWindowLong(hWnd, GWL_EXSTYLE, exStyle | WS_EX_DLGMODALFRAME);

            SendMessage(hWnd, WM_SETICON, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hWnd, WM_SETICON, new IntPtr(1), IntPtr.Zero);

            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE | SWP_FRAMECHANGED);
        }
        #endregion Private methods

        #region External methods
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, Int32 nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 x, Int32 y, Int32 cx, Int32 cy, UInt32 uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        #endregion External methods
    }
}
