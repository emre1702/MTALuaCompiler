using System.Windows.Forms;
using System.Windows.Media;

namespace MTALuaCompiler
{
    static class FolderDialog
    {

        public static IWin32Window GetIWin32Window(this Visual visual)
        {
            var source = System.Windows.PresentationSource.FromVisual(visual) as System.Windows.Interop.HwndSource;
            IWin32Window win = new OldWindow(source.Handle);
            return win;
        }

        private class OldWindow : IWin32Window
        {
            private readonly System.IntPtr _handle;
            public OldWindow(System.IntPtr handle)
            {
                _handle = handle;
            }

            #region IWin32Window Members
            System.IntPtr IWin32Window.Handle
            {
                get { return _handle; }
            }
            #endregion
        }
    }
}
