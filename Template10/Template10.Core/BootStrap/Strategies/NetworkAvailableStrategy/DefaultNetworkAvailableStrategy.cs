﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Services.Network;
using Windows.UI.Xaml;

namespace Template10.Strategies
{
    public enum NetworkRequirements { None, NetworkRequired, InternetRequired }

    public static partial class Settings
    {
        public static NetworkRequirements NetworkRequirement { get; set; } = NetworkRequirements.None;
    }

    public interface INetworkAvailableStrategy
    {
        DataTemplate DataTemplate { get; set; }
        void HandleCorrect(NetworkRequirements desired);
        void HandleIncorrect(NetworkRequirements desired);
    }

    public class DefaultNetworkAvailableStrategy : INetworkAvailableStrategy
    {
        private INetworkAvailableService _service;
        public DefaultNetworkAvailableStrategy(INetworkAvailableService service)
        {
            (_service = service).AvailabilityChanged += _service_AvailabilityChanged;
        }

        private async void _service_AvailabilityChanged(object sender, AvailabilityChangedEventArgs e)
        {
            switch (Settings.NetworkRequirement)
            {
                case NetworkRequirements.None:
                    HandleCorrect(NetworkRequirements.None);
                    break;
                case NetworkRequirements.NetworkRequired when (await _service.GetIsNetworkAvailableAsync()):
                    HandleCorrect(NetworkRequirements.NetworkRequired);
                    break;
                case NetworkRequirements.InternetRequired when (await _service.GetIsInternetAvailableAsync()):
                    HandleCorrect(NetworkRequirements.InternetRequired);
                    break;
                default:
                    HandleIncorrect(Settings.NetworkRequirement);
                    break;
            }
        }

        public DataTemplate DataTemplate { get; set; }

        public void HandleCorrect(NetworkRequirements desired)
        {
            // TODO
        }

        public void HandleIncorrect(NetworkRequirements desired)
        {
            // TODO
        }
    }
}
