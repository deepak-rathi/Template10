﻿using System.Threading.Tasks;
using Template10.Common;
using Template10.Navigation;

namespace Template10.Strategies
{
    public interface INavStateStrategy
    {
        Task<IFrameExState> GetFrameStateAsync(string frameId);
        Task<IPropertyBagEx> GetPageStateAsync(string frameId, string pageId);
        Task ClearAsync();
    }
}