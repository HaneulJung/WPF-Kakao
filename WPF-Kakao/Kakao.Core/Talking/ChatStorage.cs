using Kakao.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Talking
{
    public class ChatStorage
    {
        private Dictionary<FriendsModel, List<MessageModel>> _chatHistory;

        public ChatStorage()
        {
            _chatHistory = new Dictionary<FriendsModel, List<MessageModel>>();
        }

        public void Add(FriendsModel receiver, MessageModel message)
        {
            if (!_chatHistory.ContainsKey(receiver))
            {
                _chatHistory.Add(receiver, new List<MessageModel>());
            }
            _chatHistory[receiver].Add(message);
        }

        public List<MessageModel> GetChatHistory(FriendsModel receiver)
        {
            if (!_chatHistory.ContainsKey(receiver))
            {
                _chatHistory.Add(receiver, new List<MessageModel>());
            }
            return _chatHistory[receiver];
        }
    }
}
