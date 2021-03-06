﻿using System.Linq;
using Template10.Common;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace Template10.Common
{
    public interface IWindowEx : IWindowEx2
    {
        ApplicationView ApplicationView { get; }
        bool IsMainView { get; }
        UIElement Content { get; set; }
        IDispatcherEx Dispatcher { get; }
        DisplayInformation DisplayInformation { get; }
        UIViewSettings UIViewSettings { get; }
        void Close();
    }
}