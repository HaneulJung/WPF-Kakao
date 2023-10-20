using Kakao.LayoutSupport.UI.Units;
using System.Windows;

namespace Kakao.Friends.Favorites.UI.Units
{
    public class FavoritesBox : FriendsBox
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FavoritesBoxItem();
        }
    }
}
