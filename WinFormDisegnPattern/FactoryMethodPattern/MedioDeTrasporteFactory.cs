using System.Collections.Generic;

namespace WinFormDisegnPattern.FactoryMethodPattern
{
    public class MedioDeTrasporteFactory
    {

        private List<IMediosDeTrasporte> lMedios = new List<IMediosDeTrasporte>();
        private string _tipo;

        public MedioDeTrasporteFactory(string Tipo) 
        {
            lMedios.Add(new Camion());
            lMedios.Add(new Avion());
            lMedios.Add(new Barco());
            lMedios.Add(new NingunMedio());
            _tipo = Tipo;
        }

        public IMediosDeTrasporte Create() 
        {
            IMediosDeTrasporte instance = new NingunMedio();
            instance = lMedios.Find(x => x.ToString() == _tipo);
            return instance;
        }

    }
}
