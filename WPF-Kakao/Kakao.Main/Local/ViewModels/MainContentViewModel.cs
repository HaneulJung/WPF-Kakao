using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;

namespace Kakao.Main.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        [ObservableProperty]
        private List<MenuModel> _menus;

        [ObservableProperty]
        private MenuModel _menu;

        public MainContentViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;

            Menus = GetMenus();
        }

        public void OnLoaded(IViewable view)
        {
            Menu = Menus[0];
        }

        private List<MenuModel> GetMenus()
        {
            List<MenuModel> source = new List<MenuModel>();
            source.Add(new MenuModel().DataGen(ContentNameManager.Friends));
            source.Add(new MenuModel().DataGen(ContentNameManager.Chats));
            source.Add(new MenuModel().DataGen(ContentNameManager.More));

            return source;
        }

        partial void OnMenuChanged(MenuModel value)
        {
            var contentRegion = _regionManager.Regions[RegionNameManager.ContentRegion];
            var content = _containerProvider.Resolve<IViewable>(value.Id);

            if (!contentRegion.Views.Contains(content))
            {
                contentRegion.Add(content);
            }
            contentRegion.Activate(content);
        }

        [RelayCommand]
        private void Logout()
        {
            var mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
            var loginContent = _containerProvider.Resolve<IViewable>(ContentNameManager.Login);

            if (!mainRegion.Views.Contains(loginContent))
            {
                mainRegion.Add(loginContent);
            }
            mainRegion.Activate(loginContent);
        }
    }
}
