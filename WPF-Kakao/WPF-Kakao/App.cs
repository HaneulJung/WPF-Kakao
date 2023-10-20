using Jamesnet.Wpf.Controls;
using Kakao.Core.Talking;
using Kakao.Forms.UI.Views;
using Kakao.Receiver;
using Prism.Ioc;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Kakao
{
    class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new KakaoWindow();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);

            containerRegistry.RegisterInstance<TalkWindowManager>(new TalkWindowManager());
            containerRegistry.RegisterInstance<ChatStorage>(new ChatStorage());

            HubManager conn = HubManager.Create();

            conn.Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(1, 5) * 1000);
                await conn.Connection.StartAsync();
            };

            containerRegistry.RegisterInstance(conn);
        }
    }
}
