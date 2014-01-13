using System.Windows.Forms;
using SCCMultimodal.Panel_de_control;

namespace SCCMultimodal {
    public partial class formPanelDeControl : Form {

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 

        private static formPanelDeControl _form = null;
        public formPanelDeControl() {
            InitializeComponent();
        }

        public static formPanelDeControl Instancia {
            get {
                if (_form == null)
                    _form = new formPanelDeControl();

                return _form;
            }
            set {
                _form = value;
            }
        }

        private void formPanelDeControl_Load(object sender, System.EventArgs e) {
            PanelDecontrol foo = new PanelDecontrol();
            this.WindowState = FormWindowState.Maximized;
            foo.LoadControls("panel1");
            foo.Generate();
            foo.Dispose(this);

        }
    }
}
