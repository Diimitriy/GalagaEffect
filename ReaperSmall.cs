using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class ReaperSmall : Enemy
    {
        public ReaperSmall(Path path) : base(path)
        {
            image = Properties.Resources.e2;
            type = "ReaperSmall";
        }
    }
}
