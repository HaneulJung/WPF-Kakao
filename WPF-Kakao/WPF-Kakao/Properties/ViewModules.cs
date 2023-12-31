﻿using Jamesnet.Wpf.Controls;
using Kakao.Chats.UI.Views;
using Kakao.Core.Names;
using Kakao.Friends.UI.Views;
using Kakao.Login.UI.Views;
using Kakao.Main.UI.Views;
using Kakao.More.UI.Views;
using Kakao.Tests.UI.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace WPF_Kakao.Properties
{
    class ViewModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, LoginContent>(ContentNameManager.Login);
            containerRegistry.RegisterSingleton<IViewable, MainContent>(ContentNameManager.Main);
            containerRegistry.RegisterSingleton<IViewable, FriendsContent>(ContentNameManager.Friends);
            containerRegistry.RegisterSingleton<IViewable, ChatsContent>(ContentNameManager.Chats);
            containerRegistry.RegisterSingleton<IViewable, MoreContent>(ContentNameManager.More);

            containerRegistry.RegisterSingleton<IViewable, SimulatorWindow>(ContentNameManager.Simulator);
        }
    }
}
