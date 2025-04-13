
namespace PatronAdapter
{
    public class MotorElectricoAdapter : Motor,IMotor
    {

        private MotorElectrico _MotorElectrico = new MotorElectrico();


        public override void Acelerar()
        {
            _MotorElectrico.Activar();
        }

        public override void Arrancar()
        {
            _MotorElectrico.Activar();
            _MotorElectrico.Mover();
        }

        public override void CargarCombustible()
        {
            _MotorElectrico.EnchufarCarga();
        }

        public override void Apagar()
        {
            _MotorElectrico.Desconectar();
        }


    }
}
