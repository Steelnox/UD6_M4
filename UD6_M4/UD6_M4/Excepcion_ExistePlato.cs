using System;
using System.Collections.Generic;
using System.Text;

namespace UD6_M4
{
    public class Excepcion_ExistePlato
    {
        public int num_plato = 0;
        public void ExistePlato(string platoPedido, string[] menu_array)
        {
            bool existe = false;

            for (int i = 0; i < menu_array.Length; i++)
            {
                if (platoPedido == menu_array[i])
                {
                    num_plato = i;
                    existe = true;
                }
            }

            if (!existe)
            {
                throw new InvalidOperationException("No existe este plato");
            }

        }
    }
}
