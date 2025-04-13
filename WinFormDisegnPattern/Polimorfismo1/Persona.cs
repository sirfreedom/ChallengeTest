

using System.Text;

namespace WinFormDisegnPattern.Polimorfismo1
{
    public abstract class Persona : IPersona
    {

        public string Nombre { get; set; }
        public string Telefono { get; set; }


        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nombre);
            sb.Append(" ");
            sb.Append(Telefono);
            return sb.ToString();
        }
    }
}
