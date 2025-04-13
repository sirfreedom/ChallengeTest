using System.Collections.Generic;

namespace ConsoleChallenge
{
    public class Dia
    {
        public Dia(string fecha) 
        {
            this.Fecha = fecha;
            lHoras = new List<Hora>();
        }

        public string Fecha { get; set; }

        public List<Hora> lHoras { get; set; }


    }
}
