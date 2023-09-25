using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MAUI
{
    public static class ToastDisplay
    {
        public static async void Display(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            IToast toast = Toast.Make(text, duration);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
