﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Core;

namespace Template10
{
    public enum AppVisibilities
    {
        Foreground,
        Background,
        Unknown
    }

    public static class Central
    {
        public static AppVisibilities Visibility { get; set; }
            = AppVisibilities.Unknown;

        public static ISessionState SessionState
            => DependencyService.Resolve<ISessionState>();

        public static Template10.Services.DependencyInjection.IDependencyService DependencyService
            => Template10.Services.DependencyInjection.Settings.Current;

        public static Template10.Services.Messaging.IMessengerService Messenger
            => DependencyService.Resolve<Template10.Services.Messaging.IMessengerService>();

        public static Template10.Services.Serialization.ISerializationService Serialization
            => DependencyService.Resolve<Template10.Services.Serialization.ISerializationService>();

        public static Template10.Services.Resources.IResourceService Resource
            => DependencyService.Resolve<Template10.Services.Resources.ResourceService>();

        public static Template10.Services.Network.INetworkService Network
            => DependencyService.Resolve<Template10.Services.Network.INetworkService>();

        public static Template10.Services.Logging.ILoggingService Logging
            => DependencyService.Resolve<Template10.Services.Logging.ILoggingService>();

        public static Template10.Services.Gesture.IGestureService Gesture
            => DependencyService.Resolve<Template10.Services.Gesture.IGestureService>();

        public static IWindowEx Window
            => WindowManager.Instances.First(x => x.Window.CoreWindow == Windows.UI.Core.CoreWindow.GetForCurrentThread());

        public static IDispatcherEx Dispatcher
            => Window.Dispatcher;
    }
}
