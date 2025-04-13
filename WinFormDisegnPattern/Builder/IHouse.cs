
namespace WinFormDisegnPattern.Builder
{
    public interface IHouse
    {
        //Podriamos hablar de un HTML, donde cada parte no es dependente de las demas.
        //entonces podemos crear un DIV, TABLE, etc.

        void CreateParque();
        void CreatePicina();
        void CreateArbol();
        void CreateCerco();
        void Reset();

    }
}
