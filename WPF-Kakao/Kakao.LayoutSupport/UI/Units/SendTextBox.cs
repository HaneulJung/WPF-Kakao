﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Kakao.LayoutSupport.UI.Units
{
    public class SendTextBox : TextBox
    {
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register("EnterCommand", typeof(ICommand), typeof(SendTextBox));

        static SendTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SendTextBox), new FrameworkPropertyMetadata(typeof(SendTextBox)));
        }

        public ICommand EnterCommand
        {
            get { return (ICommand)GetValue(EnterCommandProperty); }
            set { SetValue(EnterCommandProperty, value); }
        }

        public SendTextBox()
        {
            PreviewKeyDown += SendTextBox_PreviewKeyDown;
        }

        private void SendTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.IsKeyDown(Key.LeftShift))
            {
                int caretIndex = this.CaretIndex;
                SetValue(TextProperty, this.Text.Insert(caretIndex, Environment.NewLine));
                this.CaretIndex = caretIndex + Environment.NewLine.Length;
                e.Handled = true;
            }
            else if (e.Key == Key.Enter && EnterCommand != null && EnterCommand.CanExecute(null))
            {
                EnterCommand.Execute(null);
            }
        }
    }
}
