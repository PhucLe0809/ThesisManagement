using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisManagementProject
{
    public partial class UCTopicLine : UserControl
    {
        public UCTopicLine()
        {
            InitializeComponent();
        }

        public void SetFavorites()
        {
            gButtonStar.Image = Properties.Resources.PicInLineGradientStar;
        }

        private void UCLineThesis_Load(object sender, EventArgs e)
        {
            lblCreatedAt.Text = DateTime.Now.ToString();
        }

        private void UCLineTopic_Click(object sender, EventArgs e)
        {
            FTopicDetails viewTopic = new FTopicDetails();
            viewTopic.Show();
        }

        private void lblDetails_Click(object sender, EventArgs e)
        {
            FTopicDetails viewTopic = new FTopicDetails();
            viewTopic.Show();
        }

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FTopicDetails viewTopic = new FTopicDetails();
            viewTopic.Show();
        }
    }
}
