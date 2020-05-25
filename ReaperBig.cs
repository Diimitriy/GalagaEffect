using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class ReaperBig : Enemy
    {
        public ReaperBig(Path path) : base(path)
        {
            image = Properties.Resources.e3;
            type = "ReaperBig";
        }
    }
}
