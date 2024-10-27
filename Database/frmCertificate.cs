using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.IO;

namespace Database
{
    public partial class frmCertificate : Form
    {
        private readonly Bitmap certificate = Properties.Resources.CertificateOfCompletion;
        private Bitmap certificateCurrent;

        private string dogName;
        private string className;

        private readonly Bitmap leftArrow = Properties.Resources.leftArrow2;
        private readonly Bitmap leftArrowHover = Properties.Resources.leftArrow2Hover;
        private readonly Bitmap leftArrowClick = Properties.Resources.leftArrow2Click;
        private readonly Bitmap save = Properties.Resources.Save;
        private readonly Bitmap saveHover = Properties.Resources.SaveHover;
        private readonly Bitmap saveClick = Properties.Resources.SaveClick;
        private readonly Bitmap print = Properties.Resources.Print;
        private readonly Bitmap printHover = Properties.Resources.PrintHover;
        private readonly Bitmap printClick = Properties.Resources.PrintClick;

        public frmCertificate(string dogName, string className)
        {
            InitializeComponent();
            this.dogName = dogName;
            this.className = className;
            AddMenuAndItems();
            xpbxCertificate.Image = certificate;
            xpbxCertificate.SizeMode = PictureBoxSizeMode.Zoom;
            xpbxBack.Image = leftArrow;
            xpbxBack.SizeMode = PictureBoxSizeMode.Zoom;
            xpbxSave.Image = save;
            xpbxSave.SizeMode = PictureBoxSizeMode.Zoom;
            xpbxPrint.Image = print;
            xpbxPrint.SizeMode = PictureBoxSizeMode.Zoom;
            SetDrawText();
        }

        private void AddMenuAndItems()
        {
            (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Main Menu");
        }

        private void xmsMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Main Menu")
            {
                OpenMainMenu();
            }
        }

        private void SetDrawText()
        {
            DrawText(dogName, new Font("Arial", 80), Brushes.Purple, StringAlignment.Center, StringAlignment.Near, 640, 675, 1280, certificate.Height - 675, true);
            DrawText(className, new Font("Arial", 80), Brushes.Purple, StringAlignment.Center, StringAlignment.Near, 640, 1050, 1280, certificate.Height - 1050, false);
        }

        private void DrawText(string text, Font font, Brush brush, StringAlignment horizontalAlignment, StringAlignment verticalAlignment, float x, float y, float width, float height, bool newImage)
        {
            Bitmap bitmap;
            if (newImage == true)
            {
                bitmap = new Bitmap(certificate);
            }
            else
            {
                bitmap = new Bitmap(certificateCurrent);
            }
            RectangleF rectangleF = new RectangleF(x, y, width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = horizontalAlignment,
                LineAlignment = verticalAlignment,
            };
            graphics.DrawString(text, font, brush, rectangleF, stringFormat);
            graphics.Flush();
            xpbxCertificate.Image = bitmap;
            xpbxCertificate.Refresh();
            certificateCurrent = bitmap;
        }

        private void OpenMainMenu()
        {
            frmMainMenu frmMainMenu = new frmMainMenu()
            {
                MdiParent = this.ParentForm,
                Dock = DockStyle.Fill,
            };
            frmMainMenu.Show();
            this.Close();
        }

        private void Print()
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += printDocument_PrintPage;
                printDocument.DefaultPageSettings.Landscape = true;
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void SaveToFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Pick a location to save to";
                saveFileDialog.Filter = "*.png|*.png|*.jpg|*.jpg|*.bmp|*.bmp|*.tiff|*.tiff";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!(string.IsNullOrWhiteSpace(saveFileDialog.FileName)))
                    {
                        using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            if (saveFileDialog.FilterIndex == 1)
                            {
                                certificateCurrent.Save(fileStream, System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                            else if (saveFileDialog.FilterIndex == 2)
                            {
                                certificateCurrent.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            else if (saveFileDialog.FilterIndex == 3)
                            {
                                certificateCurrent.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            else if (saveFileDialog.FilterIndex == 4)
                            {
                                certificateCurrent.Save(fileStream, System.Drawing.Imaging.ImageFormat.Tiff);
                            }
                        }
                    }
                }
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(certificateCurrent))
            {
                e.Graphics.DrawImage(bitmap, e.PageBounds);
            }
        }

        private void xpbxBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xpbxBack_MouseDown(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrowClick;
        }

        private void xpbxBack_MouseEnter(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrowHover;
        }

        private void xpbxBack_MouseLeave(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }

        private void xpbxBack_MouseUp(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }


        private void xpbxSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void xpbxSave_MouseDown(object sender, MouseEventArgs e)
        {
            xpbxSave.Image = saveClick;
        }

        private void xpbxSave_MouseEnter(object sender, EventArgs e)
        {
            xpbxSave.Image = saveHover;
        }

        private void xpbxSave_MouseLeave(object sender, EventArgs e)
        {
            xpbxSave.Image = save;
        }

        private void xpbxSave_MouseUp(object sender, MouseEventArgs e)
        {
            xpbxSave.Image = save;
        }

        private void xpbxPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void xpbxPrint_MouseDown(object sender, MouseEventArgs e)
        {
            xpbxPrint.Image = printClick;
        }

        private void xpbxPrint_MouseEnter(object sender, EventArgs e)
        {
            xpbxPrint.Image = printHover;
        }

        private void xpbxPrint_MouseLeave(object sender, EventArgs e)
        {
            xpbxPrint.Image = print;
        }

        private void xpbxPrint_MouseUp(object sender, MouseEventArgs e)
        {
            xpbxPrint.Image = print;
        }
    }
}
