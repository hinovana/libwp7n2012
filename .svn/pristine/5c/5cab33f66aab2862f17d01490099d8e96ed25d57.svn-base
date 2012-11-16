using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Horse;
using KOEI.WP7_2012.Horse.Breeding;
using KOEI.WP7_2012.Datastruct;


namespace WP7_2012ULV.Breeding
{
	public partial class BreedingForm : Form
	{
		private Controls breedingToDamControls_;
		private Controls breedingToSireControls_;

		public BreedingForm(
			KOEI.WP7_2012.WP7 wp,
			Enums.NameType dispNameType,
			UMAListView.Setting sireListViewSetting,
			UMAListView.Setting damListViewSetting,
			Breeding.ListViewSetting breedingSireSetting,
			Breeding.ListViewSetting breedingDamSetting
		) {
			this.InitializeComponent();
			this.Size = new Size( 1080, 800 );
			this.Text = String.Format( "配合支援 - {0}", Program.AssemblyName );
			this.Shown += this.Form_Shown;

			this.breedingToDamControls_ = new Controls(
				wp,
				KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.父系,
				dispNameType,
				sireListViewSetting,
				breedingSireSetting
			);
			this.breedingToDamControls_.Dock = DockStyle.Fill;
			this.breedingToDamControls_.Name = "breedingControls";

			this.breedingToSireControls_ = new Controls(
				wp,
				KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.母系,
				dispNameType,
				damListViewSetting,
				breedingDamSetting
			);
			this.breedingToSireControls_.Dock = DockStyle.Fill;
			this.breedingToSireControls_.Name = "breedingControls";


			this.toolStripStatusLabel1.Text = String.Empty;
			this.toolStripStatusLabel2.Text = String.Empty;
			this.toolStripStatusLabel3.Text = String.Empty;

			this.tabPage1.Controls.Add( this.breedingToDamControls_ );
			this.tabPage2.Controls.Add( this.breedingToSireControls_ );

			this.FormClosing += ( obj, e )=> {
				this.breedingToDamControls_.UpdateBreedingListViewSetting();
				this.breedingToSireControls_.UpdateBreedingListViewSetting();
			};
		}

		private void Form_Shown( object sender, EventArgs e )
		{
			// pass
		}

		public void UpdateToolStripStatusLabel1Text( String message )
		{
			this.toolStripStatusLabel1.Text = message;
		}

		public void UpdateToolStripStatusLabel2Text( String message )
		{
			this.toolStripStatusLabel2.Text = message;
		}

		public void UpdateToolStripStatusLabel3Text( String message )
		{
			this.toolStripStatusLabel3.Text = message;
		}
	}
}
