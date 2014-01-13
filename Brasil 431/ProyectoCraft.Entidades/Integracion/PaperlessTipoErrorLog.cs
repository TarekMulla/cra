namespace ProyectoCraft.Entidades.Integracion
{
    public class PaperlessTipoErrorLog
    {
        public enum PaperlessTipoError
        {
            RegVarios = 1,
            SinNumeroConsolidada = 2,
            DobleDefinicionPpValorNetShip = 3,
            SinNumeroMaster = 4,
            DifValoresBls = 5,
            RutNoExiste = 6,
            Resumen = 7
            /*
1	Rut en Blanco -> Registro Varios
2	No viene Numero de Consolidada
3	Paperless Doble Definicion = null, sino NetShip
4	No se encontro Numero Master
5	Existe una diferencia entre los valores de hbls
6	rut no existe, se Crea Cliente tipo Paperless
             */
        }
    }
}
