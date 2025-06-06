using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ball
{
    abstract class _3d
    {
        public string name;
        abstract public void Draw();
        override public string ToString()
        {
            return "It`s 3d";
        }
    }
}
