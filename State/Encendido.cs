using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class Encendido : Estado
    {
        public override void ControlarEstado(Switch sw)
        {
            sw.DefinirEstado(new Apagado());
        }

        public override string Describir()
        {
            return "Switch encendido";
        }
    }
}
