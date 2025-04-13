
namespace WinFormDisegnPattern.Builder
{
    public class HouseBuilder
    {

        IHouse _House = new House(); //Casa por default

        public House setParticularHouse 
        {
            set { _House = value; }
        }

        public IHouse BuildMinimal()
        {
            this._House.CreateArbol();
            return _House;
        }

        public IHouse BuildFull() 
        {
            this._House.CreateArbol();
            this._House.CreateCerco();
            this._House.CreateParque();
            this._House.CreatePicina();
            return _House;
        }


    }
}
