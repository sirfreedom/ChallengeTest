using System;

namespace WinFormDisegnPattern.FactoryMethodPattern
{
    public abstract class MediosDeTrasporte : IMediosDeTrasporte
    {

        public string MedioDeTrasporteNombre 
        {
            get
            {
                Type t = this.GetType();
                return t.Name;
            }
        }


        public virtual string Prender() {
            return "Prender Medios de transporte";
        }

        public virtual string Apagar() 
        {
            return "Apagar Medios de transporte";
        }

        public override string ToString()
        {
            return MedioDeTrasporteNombre;
        }


    }
}
