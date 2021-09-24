﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.NLog
{
    public interface ILog
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
