using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Horse;
using KOEI.WP7_2012.Horse.Breeding;
using KOEI.WP7_2012.Datastruct;

namespace WP7_2012ULV.Breeding
{
	public partial class Controls : UserControl
	{
		private UMAListView.UMAListViewTpl breedingTargetListView;
		private UMAListView.UMAListViewTpl breedingPartnerListView;

		private UMAListView.Setting listViewSetting_;
		private Breeding.ListViewSetting breedingListViewSetting_;

		private Enums.NameType dispNameType_;

		private WP7 wp_;
		private Area area_;
		private KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ type_;

		public Controls(
			KOEI.WP7_2012.WP7 wp,
			KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ type,
			Enums.NameType dispNameType,
			UMAListView.Setting listViewSetting,
			Breeding.ListViewSetting breedingListViewSetting
		) {
			this.InitializeComponent();

			this.wp_ = wp;
			this.type_ = type;
			this.dispNameType_ = dispNameType;
			this.area_ = Area.日本;
			this.listViewSetting_ = listViewSetting;
			this.breedingListViewSetting_ = breedingListViewSetting;
			this.SetupControls();
		}


		private void SetupControls()
		{
			this.comboBox1.Items.Add( new KeyValuePair< String, UInt32 >(
				String.Format( "全て表示" ),
				(uint)100
			));
			for( var i=0; i<10; ++i ) {
				this.comboBox1.Items.Add( new KeyValuePair< String, UInt32 >(
					String.Format( "{0}以下", i ),
					(uint)i
				));
			}
			this.comboBox1.DisplayMember = "Key";
			this.comboBox1.SelectedIndex = 0;

			this.radioButton1.Tag = Area.日本;
			this.radioButton2.Tag = Area.米国;
			this.radioButton3.Tag = Area.欧州;

			switch( this.area_ ) {
			case Area.日本:
				this.radioButton1.Checked = true;
				this.checkBox1.Checked = true;
				break;
			case Area.米国:
				this.radioButton2.Checked = true;
				this.checkBox2.Checked = true;
				break;
			case Area.欧州:
				this.radioButton3.Checked = true;
				this.checkBox3.Checked = true;
				break;
			}
			this.checkBox4.Checked = true;
			this.checkBox5.Checked = false;

			this.comboBox1.SelectedIndexChanged += this.ComboBoxChangedHandler;
			this.radioButton1.CheckedChanged += this.AreaChangedHandler;
			this.radioButton2.CheckedChanged += this.AreaChangedHandler;
			this.radioButton3.CheckedChanged += this.AreaChangedHandler;
			this.checkBox1.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox2.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox3.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox4.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox5.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox6.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox7.CheckedChanged += this.CheckBoxChangedHandler;
			this.checkBox8.CheckedChanged += this.CheckBoxChangedHandler;

			switch( this.type_ ) {
			case KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.父系:
				this.breedingTargetListView = new HorseSireListView( null, KOEI.WP7_2012.ReadWriteMode.ReadOnly, null, String.Empty );
				this.breedingPartnerListView = new BreedingToDamListView( null, KOEI.WP7_2012.ReadWriteMode.ReadOnly, null, String.Empty );
				break;
			case KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.母系:
				this.breedingTargetListView = new HorseDamListView( null, KOEI.WP7_2012.ReadWriteMode.ReadOnly, null, String.Empty );
				this.breedingPartnerListView = new BreedingToSireListView( null, KOEI.WP7_2012.ReadWriteMode.ReadOnly, null, String.Empty );
			break;
			}
			// 上のリストビュー
			this.breedingTargetListView.Dock = DockStyle.Fill;
			this.breedingTargetListView.ListView1.MultiSelect = false;
			this.breedingTargetListView.ListView1.SelectedIndexChanged += ListView1_SelectedIndexChangedHandler;
			this.breedingTargetListView.FromSetting( this.listViewSetting_ );
			this.breedingTargetListView.ListView1.MouseMove += ( obj, e )=> { 
				if( Form.ActiveForm == this.FindForm() )
					this.breedingTargetListView.ListView1.Focus();
			};

			// 下のリストビュー
			this.breedingPartnerListView.ListView1.MouseMove += ( obj, e )=> { 
				if( Form.ActiveForm == this.FindForm() )
					this.breedingPartnerListView.ListView1.Focus();
			};
			this.breedingPartnerListView.Dock = DockStyle.Fill;
			this.breedingPartnerListView.FromSetting( this.breedingListViewSetting_ );

			this.UpdateSireList();
			this.panel2.Controls.Add( this.breedingTargetListView );
			this.panel3.Controls.Add( this.breedingPartnerListView );

			this.panel2.Size = new Size( 0, this.breedingListViewSetting_.Height );
		}

		public void UpdateBreedingListViewSetting()
		{
			var setting = this.breedingPartnerListView.ToSetting();

			this.breedingListViewSetting_.Columns = setting.Columns;
			this.breedingListViewSetting_.Height = this.panel2.Height;
		}

		private String GetDispName( ref HBloodData blood_data )
		{
			var name_type = WP7_2012ULV.Enums.NameType.ENGLISH;

			if( this.dispNameType_ == WP7_2012ULV.Enums.NameType.KANA ) {
				name_type = WP7_2012ULV.Enums.NameType.KANA;
			}
			if( blood_data.display == 1 ) {
				return this.wp_.馬名( name_type, blood_data.name_left, blood_data.name_right );
			} else {
				return this.wp_.馬名( WP7_2012ULV.Enums.NameType.KANA, blood_data.name_left, blood_data.name_right );
			}
		}
	
		private void ListView1_SelectedIndexChangedHandler( object sender, EventArgs e )
		{
			if( this.breedingTargetListView.ListView1.SelectedIndices.Count == 0 ) {
				return ;
			}
			var n = this.breedingTargetListView.ListView1.SelectedIndices[0];
			var item = this.breedingTargetListView.ListView1.Items[n];

			var horse_num = (uint)((int)item.SubItems["horse_num"].Tag);
			var blood_data = new HBloodData();

			switch( this.type_ ) {
			case KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.父系:
				var sire_data = new HSireData();
				this.wp_.HSireTable.GetData( horse_num, ref sire_data );
				this.wp_.HBloodTable.GetData( sire_data.blood_num, ref blood_data );
				break;
			case KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.母系:
				var dam_data = new HDamData();
				this.wp_.HDamTable.GetData( horse_num, ref dam_data );
				this.wp_.HBloodTable.GetData( dam_data.blood_num, ref blood_data );
				break;
			}

			var horse_name = this.GetDispName( ref blood_data );

			var sw = new System.Diagnostics.Stopwatch();

			try {
				sw.Start();
				this.BreedingAndDisp( horse_num );
				sw.Stop();

				var form = this.FindForm() as BreedingForm;
				if( form != null ) {
					form.UpdateToolStripStatusLabel1Text( String.Format( "{0}(ms)", sw.ElapsedMilliseconds ) );
					form.UpdateToolStripStatusLabel2Text( String.Format( "{0}(line)", this.breedingPartnerListView.ItemsCount ) );
					form.UpdateToolStripStatusLabel3Text( String.Format( "{0}", horse_name ) );
				}
			} catch( Exception ex ) {
				sw.Stop();
				var message = String.Format( "エラーが発生しました - {0}", ex.Message );
				MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private void UpdateSireList()
		{
			this.breedingTargetListView.ListViewConfig = new UMAListView.Config() {
				BreedingArea  = this.area_,
				Country_JAPAN = this.checkBox1.Checked,
				Country_USA   = this.checkBox2.Checked,
				Country_EURO  = this.checkBox3.Checked,
				Status_Geneki = this.checkBox4.Checked,
				Status_Intai  = this.checkBox5.Checked,
				OwnerHorse    = this.checkBox6.Checked,
				ClubHorse     = this.checkBox8.Checked,
				SaleHorse     = false,
				CurrentHorse  = false,
				DispNameType  = this.dispNameType_,
			};
			this.breedingTargetListView.CreateHorseList( this.wp_ );
		}

		private void ComboBoxChangedHandler( object sender, EventArgs e )
		{
			this.ListView1_SelectedIndexChangedHandler( null, null );
		}

		private void AreaChangedHandler( object sender, EventArgs e )
		{
			//this.UpdateSireList();
			foreach( var radio in new[]{ this.radioButton1, this.radioButton2, this.radioButton3 } ) {
				if( radio.Checked ) {
					this.area_ = (Area)radio.Tag;
				}
			}
			this.ListView1_SelectedIndexChangedHandler( null, null );
		}

		private void CheckBoxChangedHandler( object sender, EventArgs e )
		{
			this.UpdateSireList();
			this.ListView1_SelectedIndexChangedHandler( null, null );
		}

		private void BreedingAndDisp( UInt32 horse_num )
		{
			var config = new UMAListView.Config() {
				BreedingArea  = this.area_,
				Country_JAPAN = this.checkBox1.Checked,
				Country_USA   = this.checkBox2.Checked,
				Country_EURO  = this.checkBox3.Checked,
				Status_Geneki = this.checkBox4.Checked,
				Status_Intai  = this.checkBox5.Checked,
				OwnerHorse    = this.checkBox7.Checked,
				ClubHorse     = this.checkBox8.Checked,
				MaxRisk       = ((KeyValuePair<String,UInt32>)this.comboBox1.SelectedItem).Value,
				DispNameType  = this.dispNameType_,
			};

			this.breedingPartnerListView.ListViewConfig = config;
			this.breedingPartnerListView.ListViewDefaultSortColumn = 4;
			this.breedingPartnerListView.CreateHorseList( this.wp_, horse_num );
			this.GCCollect();
		}

		private void GCCollect()
		{
			GC.Collect( GC.MaxGeneration, GCCollectionMode.Forced );
			GC.WaitForPendingFinalizers();
			GC.Collect( GC.MaxGeneration, GCCollectionMode.Forced );
		}
	}
}
