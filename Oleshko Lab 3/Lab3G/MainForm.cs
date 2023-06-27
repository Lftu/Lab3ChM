using Lab3G.CLasses;

namespace Lab3G
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var n = Convert.ToInt32(textBox1.Text);
                Function.n = n;
                var a = Convert.ToInt32(textBox2.Text);
                Drawer.xMin = a;
                var b = Convert.ToInt32(textBox3.Text);
                Drawer.xMax = b;
            }
            catch { }
            Drawer.CreateGraphics(MainPictureBox);
            Drawer.DrawCoordinateSystem();
            Drawer.DrawFunction();
        }
    }
}