using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WP7_2012ULV
{
	public partial class SpoilerLikeEditForm : Form
	{
		public SpoilerLikeEditForm()
		{
			InitializeComponent();

			this.label1.Width = 400;
			this.label1.Text = "※この画面を開いた状態での週送りはしないでください\r\nデータが破損する恐れがあります";
			this.Resize += new EventHandler(SpoilerLikeForm_Resize);
		}

		void SpoilerLikeForm_Resize(object sender, EventArgs e)
		{
			this.button1.Location = new Point( this.panel1.Width - this.button1.Width - this.button2.Width - 10, this.button1.Top );
			this.button2.Location = new Point( this.panel1.Width - this.button1.Width - 5, this.button2.Top );
		}

		public TabControl MainTabPanel {
			get {
				return this.tabControl1;
			}
		}

		public void TabPageAdd( String text, Control[] controls )
		{
			var tabpage = new TabPage( text );
			tabpage.Controls.AddRange( controls );

			this.tabControl1.TabPages.Add( tabpage );
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
