using System.Collections.Generic;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessUsuario1
    {
        public PaperlessUsuario1()
        {
            Paso1HousesBL = new List<PaperlessUsuario1HousesBL>();
            Paso1HousesBLInfo = new PaperlessUsuario1HouseBLInfo();
            Excepciones = new List<PaperlessExcepcion>();
            Disputas = new List<PaperlessUsuario1Disputas>();
        }

        public IList<PaperlessUsuario1HousesBL> Paso1HousesBL { get; set; }
        public PaperlessUsuario1HouseBLInfo Paso1HousesBLInfo { get; set; }

        public IList<PaperlessExcepcion> Excepciones { get; set; }
        public IList<PaperlessUsuario1Disputas> Disputas { set; get; }

    }
}
