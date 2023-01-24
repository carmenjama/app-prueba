using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public abstract class Estado
    {
        public abstract void ControlarEstado(Switch sw);
        public abstract string Describir();
    }
}
