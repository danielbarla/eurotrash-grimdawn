using System;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.Import.Common
{
    public static class Controls
    {
        /// <summary>
        ///     Invokes an action on a <see cref="Control" /> if required.
        ///     Invoke is always required when accessing controls on another thread than the thread that created the control.
        /// </summary>
        /// <typeparam name="T">Type of the control.</typeparam>
        /// <param name="control">Control to run an action on.</param>
        /// <param name="action">Action to execute for the control.</param>
        public static void InvokeSafe<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => action(control)));
            else
                action(control);
        }
    }
}