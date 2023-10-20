using System.Windows;
using System.Windows.Controls;

namespace Kakao.Friends.Favorites.UI.Units
{
    public class FavoritesBoxItem : ListBoxItem
    {
        static FavoritesBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FavoritesBoxItem), new FrameworkPropertyMetadata(typeof(FavoritesBoxItem)));
        }
    }
}
