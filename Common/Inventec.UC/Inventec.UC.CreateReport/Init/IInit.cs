﻿using Inventec.UC.CreateReport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventec.UC.CreateReport.Init
{
    interface IInit
    {
        UserControl InitUC(MainCreateReport.EnumTemplate template, InitData Data);
    }
}
