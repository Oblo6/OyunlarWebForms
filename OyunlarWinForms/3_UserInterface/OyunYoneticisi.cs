using System;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunYoneticisi : Form
    {
        public OyunYoneticisi()
        {
            InitializeComponent();
        }

        private void oyunlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Oyunlar oyunlarForm = new Oyunlar();
            //oyunlarForm.MdiParent = this;
            //oyunlarForm.WindowState = FormWindowState.Maximized;
            //oyunlarForm.Show();

            Oyunlar oyunlarForm = new Oyunlar(this);
        }

        private void uygulamadanÇıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oyunRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OyunRaporu form = new OyunRaporu(this);
        }       
    }
}
