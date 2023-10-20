using Prism.Ioc;
using Prism.Modularity;

namespace WPF_Kakao.Properties
{
    internal class DirectModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("MainRegion", "LoginContent");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
