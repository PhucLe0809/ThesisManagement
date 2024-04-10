using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using ThesisManagementProject.Forms;

namespace ThesisManagementProject
{
    public partial class UCCommentLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private Comment comment = new Comment();
        private People creator = new People();
        private PeopleDAO peopleDAO = new PeopleDAO();

        public UCCommentLine()
        {
            InitializeComponent();
        }
        public UCCommentLine(Comment comment)
        {
            InitializeComponent();
            this.comment = comment;
            InitUserControl();
        }
        private void InitUserControl()
        {
            this.creator = peopleDAO.SelectOnlyByID(comment.IdCreator);
            SetUserControlSize();
            rtbContent.Text = comment.Content;
            lblCreator.Text = creator.FullName;
            gCirclePictureBoxCreator.Image = myProcess.NameToImage(creator.AvatarName);
        }
        private int CalculateTextWidth(string text, Font font)
        {
            using (var pictureBox = new PictureBox())
            {
                using (var g = pictureBox.CreateGraphics())
                {
                    SizeF size = g.MeasureString(text, font);
                    return (int)Math.Ceiling(size.Width);
                }
            }
        }
        private void SetUserControlSize()
        {
            int len = comment.Content.Length;
            int pixelContent = CalculateTextWidth(comment.Content, rtbContent.Font);
            int width = Math.Min(Math.Max(pixelContent + 15, creator.FullName.Length * 10), 510);
            int hight = Math.Max((pixelContent / 500 + (pixelContent % 500 != 0 ? 1 : 0)) * 30, 35);

            rtbContent.Size = new Size(width, hight);
            gShadowPanelTeam.Size = new Size(Math.Min(width + 30, 550), hight + 35);
            this.Size = new Size(640, hight + 42);
        }
        private void gCirclePictureBoxCreator_Click(object sender, EventArgs e)
        {
            FPeopleDetails fPeopleDetails = new FPeopleDetails(creator);
            fPeopleDetails.ShowDialog();
        }
    }
}
