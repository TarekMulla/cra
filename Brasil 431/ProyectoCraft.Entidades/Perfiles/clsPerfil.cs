namespace ProyectoCraft.Entidades.Perfiles {
    public class clsPerfil : GlobalObject.NamedObject {

        public int Prioridad { set; get; }
        public ClsPanelDeControl PanelDeControl { set; get; }
        public clsPerfil() {
            PanelDeControl = new ClsPanelDeControl();
        }
    }
}
