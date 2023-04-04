using System;
using System.Collections.Generic;
using System.Text;

namespace ControlsUI
{
    public interface ICombo
    {
        string DisplayMember
        {
            get;
        }
        string ValueMember
        {
            get;
        }
    }
}
