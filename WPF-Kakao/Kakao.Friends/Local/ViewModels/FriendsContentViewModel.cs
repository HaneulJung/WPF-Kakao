using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Core.Talking;
using Kakao.Receiver;
using Kakao.Talk.UI.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {
        private readonly IEventHub _eventHub;
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private readonly TalkWindowManager _talkWindowManager;
        private readonly HubManager _hubManager;

        [ObservableProperty]
        private List<FriendsModel> _birthdays;

        [ObservableProperty]
        private List<FriendsModel> _favorites;


        public FriendsContentViewModel(IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider, TalkWindowManager talkWindowManager, HubManager hubManager)
        {
            _eventHub = eventHub;
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _talkWindowManager = talkWindowManager;
            _hubManager = hubManager;
            _talkWindowManager.WindowCountChanged += _talkWindowManager_WindowCountChanged;


            _eventHub.Subscribe<SyncFriendsPubSub, SyncFriendsArgs>(SyncFriendsReceived);

            _hubManager.Start(eventHub);
        }

        private void _talkWindowManager_WindowCountChanged(object? sender, EventArgs e)
        {
            RefreshTalkWindowArgs args = new RefreshTalkWindowArgs();
            _eventHub.Publish<RefreshTalkWindowEvent, RefreshTalkWindowArgs>(args);
        }

        [RelayCommand]
        private void DoubleClick(FriendsModel data)
        {
            TalkContent content = new TalkContent();
            TalkWindow talkWindow = _talkWindowManager.ResolveWindow<TalkWindow>(data.Id);
            talkWindow.Content = content;
            talkWindow.Title = data.Name;
            talkWindow.Width = 360;
            talkWindow.Height = 500;

            if (content.DataContext is IReceiverInfo info)
            {
                info.InitReceiver(data);
            }

            talkWindow.Show();
        }      

        [RelayCommand]
        private void ShowSimulator()
        {
            var simulatorWindow = _containerProvider.Resolve<IViewable>(ContentNameManager.Simulator);

            if (simulatorWindow is JamesWindow win)
            {
                win.Show();
            }
        }

        [RelayCommand]
        private async void SyncFriends()
        {
            await _hubManager.Connection.InvokeAsync("SyncFriends", new RequestInfo());
        }

        private void SyncFriendsReceived(SyncFriendsArgs obj)
        {
            Birthdays = obj.Friends;
            Favorites = obj.Friends;
        }
    }
}
