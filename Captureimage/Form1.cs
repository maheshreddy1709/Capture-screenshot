using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Captureimage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filename = "sample";
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
                filename = txtName.Text;
            m_strFilename = txtFileBrowse.Text.Trim();
            CaptureMyScreen();
        }
        private void CaptureMyScreen()

        {

            try

            {

                //Creating a new Bitmap object

                Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);


                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

                //Creating a Rectangle object which will  

                //capture our Current Screen

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;



                //Creating a New Graphics Object

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);



                //Copying Image from The Screen

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);


                lblStatus.Text = "-";
                //Saving the Image File (I am here Saving it in My E drive).
                if (m_strFilename != "")
                {
                    if (Directory.Exists(m_strFilename))
                        Directory.CreateDirectory(m_strFilename);
                    captureBitmap.Save(m_strFilename + "\\" + filename + ".jpg", ImageFormat.Jpeg);
                    lblStatus.Text = "Captured";
                }
                else
                {
                    lblStatus.Text = "ERROR";
                    MessageBox.Show("ERROR!");
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }
        string m_strFilename = "";
        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            m_strFilename = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileBrowse.Text = folderBrowserDialog1.SelectedPath;
                m_strFilename = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
