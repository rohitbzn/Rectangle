using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangles
{
    class Rectangle
    {
        private Guid _Id;
        private int _Width;
        private int _Height;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
    }
}
