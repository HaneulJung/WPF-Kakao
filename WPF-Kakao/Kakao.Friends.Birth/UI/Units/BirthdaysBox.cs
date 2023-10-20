using Kakao.LayoutSupport.UI.Units;
using System.Windows;

namespace Kakao.Friends.Birth.UI.Units
{
    public class BirthdaysBox : FriendsBox
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new BirthdaysBoxItem();
        }
    }
}
