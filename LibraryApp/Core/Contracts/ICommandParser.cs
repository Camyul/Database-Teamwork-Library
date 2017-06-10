﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string commandString);
    }
}
