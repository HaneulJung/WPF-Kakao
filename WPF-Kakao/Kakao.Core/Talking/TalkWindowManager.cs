using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kakao.Core.Talking
{
    public class TalkWindowManager
    {
        private Dictionary<string, JamesWindow> _windows;
        public event EventHandler WindowCountChanged;

        public TalkWindowManager()
        {
            _windows = new Dictionary<string, JamesWindow>();
        }

        public List<KeyValuePair<string, JamesWindow>> GetAllWindows()
        {
            return _windows.ToList();
        }

        public T ResolveWindow<T>(string id) where T : JamesWindow, new()
        {
            if (_windows.ContainsKey(id))
            {
                return (T)_windows[id];
            }
            else
            {
                var window = new T();
                window.Closed += (s, e) => UnregisterWindow(id);
                _windows.Add(id, window);

                WindowCountChanged?.Invoke(this, EventArgs.Empty);

                return window;
            }
        }

        private void UnregisterWindow(string id)
        {
            _windows.Remove(id);

            WindowCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
