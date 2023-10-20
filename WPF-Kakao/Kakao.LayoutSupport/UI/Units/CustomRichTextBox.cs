using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Kakao.LayoutSupport.UI.Units
{
    public class CustomRichTextBox : RichTextBox
    {
        public IEnumerable ItemsSource  
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CustomRichTextBox), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public CustomRichTextBox()
        {
            Document = new FlowDocument();
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomRichTextBox? richTextBox = d as CustomRichTextBox;

            if (e.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= richTextBox!.OnCollectionChanged;
            }

            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += richTextBox!.OnCollectionChanged;
            }

            richTextBox!.UpdateFlowDocument();
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateFlowDocument();
        }

        private void UpdateFlowDocument()
        {
            FlowDocument document = new FlowDocument();

            if (ItemsSource != null)
            {       
                foreach (var item in ItemsSource)
                {
                    var control = GetTextContainerItemForOverride();
                    control.DataContext = item;

                    InlineUIContainer iuc = new InlineUIContainer();
                    iuc.Child = control;

                    Paragraph paragraph = new Paragraph();
                    paragraph.Margin = new(0);

                    if (item is IMessage message)
                    {
                        paragraph.TextAlignment = message.Type == "Send" 
                                                ? TextAlignment.Right 
                                                : TextAlignment.Left;
                    }
                    paragraph.Inlines.Add(iuc);
                                        
                    document.Blocks.Add(paragraph);
                }
            }

            Document = document;

            ScrollToEnd();
        }

        protected virtual Control GetTextContainerItemForOverride()
        {
            Control control = new Control();
            return control;
        }
    }
}
