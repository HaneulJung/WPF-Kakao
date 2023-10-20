using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kakao.LayoutSupport.UI.Units
{
    public class FriendsBox : ListBox
    {
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(FriendsBox), new PropertyMetadata(null));

        static FriendsBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FriendsBox), new FrameworkPropertyMetadata(typeof(FriendsBox)));
        }

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)GetValue(DoubleClickCommandProperty); }
            set { SetValue(DoubleClickCommandProperty, value); }
        }
        
        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext != null)
            {
                DoubleClickCommand?.Execute(fe.DataContext);
            }
        }
    }
}
