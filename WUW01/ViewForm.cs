using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WUW01
{
	public class ViewForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblNone;
		private System.Windows.Forms.TabControl StrokeTabs;
		private ArrayList _prototypes;

		public ViewForm(ArrayList prototypes)
		{
			InitializeComponent();
			_prototypes = prototypes;
		}

		private void ViewForm_Load(object sender, System.EventArgs e)
		{
			this.Left = Owner.Right + 1;
			this.Top = Owner.Top;

			StrokeTabs.Dock = DockStyle.Fill;
			ViewForm_Resize(null, EventArgs.Empty);

			if (_prototypes.Count == 0)
			{
				StrokeTabs.Visible = false;
				lblNone.Visible = true;
			}
			else
			{
				foreach (Gesture p in _prototypes)
				{
					TabPage page = new TabPage(p.Name);
                    page.BackColor = SystemColors.Window;
					page.Paint += new PaintEventHandler(OnPaintPage);
					StrokeTabs.TabPages.Add(page);
				}
				int tabWidth = 0;
				for (int i = 0; i < StrokeTabs.TabCount; i++)
				{
					Rectangle r = StrokeTabs.GetTabRect(i);
					tabWidth += r.Width;
				}
                this.Width = Math.Max(Width, Math.Min(Screen.PrimaryScreen.WorkingArea.Width / 2, tabWidth + 20));
            }
		}

		private void OnPaintPage(object sender, PaintEventArgs e)
		{
			TabPage page = (TabPage) sender;
			foreach (Gesture g in _prototypes)
			{
                if (page.Text == g.Name)
				{
                    PointF p0 = (PointF) (PointR) g.RawPoints[0];
                    e.Graphics.FillEllipse(Brushes.Firebrick, p0.X - 5f, p0.Y - 5f, 10f, 10f);

                    foreach (PointR r in g.RawPoints)
					{
						PointF p = (PointF) r; // cast
						e.Graphics.FillEllipse(Brushes.Firebrick, p.X - 2f, p.Y - 2f, 4f, 4f);
					}
					break;
				}
			}
		}

		private void ViewForm_Resize(object sender, System.EventArgs e)
		{
			lblNone.Left = ClientRectangle.Width / 2 - lblNone.Width / 2;
			lblNone.Top = ClientRectangle.Height / 2 - lblNone.Height / 2;
		}

        private void ViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_prototypes.Clear();

				foreach (TabPage page in StrokeTabs.TabPages)
				{
					page.Dispose();
				}

				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.StrokeTabs = new System.Windows.Forms.TabControl();
            this.lblNone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StrokeTabs
            // 
            this.StrokeTabs.Location = new System.Drawing.Point(16, 16);
            this.StrokeTabs.Name = "StrokeTabs";
            this.StrokeTabs.SelectedIndex = 0;
            this.StrokeTabs.Size = new System.Drawing.Size(80, 72);
            this.StrokeTabs.TabIndex = 0;
            // 
            // lblNone
            // 
            this.lblNone.AutoSize = true;
            this.lblNone.Location = new System.Drawing.Point(56, 160);
            this.lblNone.Name = "lblNone";
            this.lblNone.Size = new System.Drawing.Size(239, 13);
            this.lblNone.TabIndex = 1;
            this.lblNone.Text = "There are no prototype gestures currently loaded.";
            this.lblNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNone.Visible = false;
            // 
            // ViewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(352, 326);
            this.Controls.Add(this.lblNone);
            this.Controls.Add(this.StrokeTabs);
            this.Name = "ViewForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Templates";
            this.Resize += new System.EventHandler(this.ViewForm_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewForm_FormClosing);
            this.Load += new System.EventHandler(this.ViewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
