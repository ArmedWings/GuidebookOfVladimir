using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AvraamProject
{
    public interface IBar
    {
        void SetStatusBarColor(Color color);
        void SetFullScreen();
    }
}
