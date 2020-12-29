using System;
using System.Collections.Generic;
using System.Text;

namespace UD6_M4
{
    public class ExcepcionSeguir
    {
        public void SeguirPedido(string seguir)
        {
            if (seguir != "Si" && seguir != "No")
            {
                throw new InvalidOperationException("No existe ese valor introducido, por favor ponga Si o No");
            }
        }
    }
}
