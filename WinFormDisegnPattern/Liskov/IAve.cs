

namespace WinFormDisegnPattern.Liskov
{
    /*
    Toda clase heredada, tiene que ser compatible con la clase base.
    ej. Aguila hereda de ave, puede volar, y comer.
    pero un piguino es un ave y no vuela. asi que no podriamos heredarlo.
    */

    public interface IAve
    {

        public string Comer();



        //public void Volar(); este metodo es incorrecto ya que pinguieno es un ave pero no vuela.
        
        


    }
}
