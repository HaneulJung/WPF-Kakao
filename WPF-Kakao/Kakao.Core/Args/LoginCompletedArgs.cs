﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Args
{
    public class LoginCompletedArgs : EventArgs
    {
        public string Email { get; set; }
    }
}
