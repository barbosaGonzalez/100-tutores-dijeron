using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_Tutores_Dijieron
{
    class Pregunta
    {
        public String texto;
        public List<Respuesta> respuestas;

        public Pregunta()
        {
            respuestas = new List<Respuesta>();
        }
    }
}
