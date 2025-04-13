using System.Text;

namespace WinFormDisegnPattern.Polimorfismo1
{
    public class Profesor : Persona, IPersona
    {

        public string AsignaturaDada { get; set;}

        public int Horas { get; set; }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(" Horas ");
            sb.Append(Horas);
            sb.Append(" ");
            sb.Append("AsignaturaDada ");
            sb.Append(AsignaturaDada);
            return base.MostrarDatos();
        }


    }
}
