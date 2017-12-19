﻿using System;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Template10.Navigation
{
    public interface INavigationService : INavigationServiceAsync, INavigationServiceVoid
    {
        event EventHandler<NavigatedEventArgs> Navigated;
        event EventHandler<NavigatingEventArgs> Navigating;
        event EventHandler<HandledEventArgs> BackRequested;
        event EventHandler<HandledEventArgs> ForwardRequested;

        IFrameEx FrameEx { get; }
        IWindowEx Window { get; }
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        object CurrentPageParam { get; }
        Type CurrentPageType { get; }
        BackButton BackButtonHandling { get; set; }
        void ClearHistory();
    }

    public interface INavigationServiceAsync
    {
        Task<bool> GoBackAsync(NavigationTransitionInfo infoOverride = null);
        Task<bool> GoForwardAsync();
        Task<bool> NavigateAsync(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null);
        Task<bool> NavigateAsync<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible;
        Task<bool> RefreshAsync();
        Task<bool> RefreshAsync(object param);
        Task<IViewLifetimeControl> OpenAsync(Type page, object parameter = null, string title = null, ViewSizePreference size = ViewSizePreference.UseHalf);
    }

    public interface INavigationServiceVoid
    {
        void GoBack(NavigationTransitionInfo infoOverride = null);
        void GoForward();
        void Navigate(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null);
        void Navigate<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible;
        void Refresh();
        void Refresh(object param);
    }
}