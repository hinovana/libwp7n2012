using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SpoilerLikeControls
{
	public delegate void DataChangedHandler( UInt32[] new_data );

	public partial class BitCheckList : UserControl
	{
		public DataChangedHandler DataChanged {
			get;
			set;
		}

		private KOEI.WP7_2012.WP7 wp_;
		private UInt32[] raw_data_;
		private KOEI.WP7_2012.DataStructPropertyInfo[][] properties_;
		private int current_data_index_ = -1;
		public Font controls_font_;

		/// <summary>
		/// データのアップデートを停止するフラグ
		/// </summary>
		private Boolean data_update_stop_flag_ = false;


		/// <summary>
		/// チェックボックスの状態を変えないフラグ
		/// </summary>
		private Boolean checked_update_cancel_flag_ = false;

		public BitCheckList( KOEI.WP7_2012.WP7 wp, KOEI.WP7_2012.DataStructPropertyInfo[][] properties, UInt32[] raw_data )
		{
			InitializeComponent();

			if( properties.Length != raw_data.Length ) {
				throw new ArgumentException(
					String.Format( "[BUG]プロパティが求める要素数({0})と配列の長さ({1})が違います", properties.Length, raw_data.Length )
				);
			}
			this.wp_ = wp;
			this.properties_ = properties;
			this.raw_data_ = raw_data;
			this.controls_font_ = this.listBox1.Font;
			this.Controls_Setup();
		}

		public Font ControlsFont {
			get {
				return this.controls_font_;
			}
			set {
				this.controls_font_ = value;
				this.listBox1.Font = this.checkedListBox1.Font = this.label1.Font = this.controls_font_;
			}
		}

		private void Controls_Setup()
		{
			for( var i=0; i<this.raw_data_.Length; ++i ) {
				this.listBox1.Items.Add( new ListBoxItem( String.Format("DATA {0,2}", i), null ) );
			}
			this.label1.Text = "";
			this.listBox1.SelectedIndexChanged += this.ListBox1_SelectedIndexChangedHandler;
			this.checkedListBox1.Click += this.CheckedListBox1_ClickHandler;
			this.checkedListBox1.ItemCheck += CheckedListBox1_ItemCheckHandler;
			this.checkedListBox1.MouseMove += CheckedListBox1_MouseMoveHandler;
		}

		private void ListBox1_SelectedIndexChangedHandler( Object sender, EventArgs e )
		{
			if( this.listBox1.SelectedIndex == -1 ) {
				return;
			}
			var index = this.listBox1.SelectedIndex;
			var property_pos = this.listBox1.SelectedIndex;
			var data = this.raw_data_[index];
			var start_byte_pos = index * 4;
			this.current_data_index_ = index;

			this.DispCheckBoxList( data, start_byte_pos, property_pos );
		}

		private void CheckedListBox1_MouseMoveHandler(object sender, MouseEventArgs e)
		{
			this.checked_update_cancel_flag_ = e.X > 15;
			//this.Parent.Text = e.X.ToString();
		}

		private void CheckedListBox1_ClickHandler( Object sender, EventArgs e )
		{
			if( this.checkedListBox1.SelectedIndex == -1 ) {
				return;
			}
			var pro = (KOEI.WP7_2012.DataStructPropertyInfo) ((ListBoxItem)this.checkedListBox1.Items[this.checkedListBox1.SelectedIndex]).Tag;
			this.label1.Text = pro.Description;
		}

		private void CheckedListBox1_ItemCheckHandler( object sender, ItemCheckEventArgs e )
		{
			if( this.current_data_index_ == -1 || this.data_update_stop_flag_ ) {
				return ;
			}
			if( this.checked_update_cancel_flag_ ) {
				e.NewValue = e.CurrentValue;
				return ;
			}

			var data = 0;

			foreach( int index in this.checkedListBox1.CheckedIndices ) {
				if( e.Index == index && e.NewValue == CheckState.Unchecked )
					continue;
				data = data | ( 1 << index );
			}
			if( e.NewValue == CheckState.Checked ) {
				data = data | ( 1 << e.Index );
			}
			this.raw_data_[ this.current_data_index_ ] = (uint)data;

			if( this.DataChanged != null ) {
				this.DataChanged( this.raw_data_ );
			}
		}

		private void DispCheckBoxList( UInt32 data, int start_byte_pos, int start_property_pos )
		{
			var byte_pos = start_byte_pos;
			var property_pos = start_property_pos;
			var bit_pos = 0;

			this.checkedListBox1.Items.Clear();
			this.data_update_stop_flag_ = true;

			foreach( var pro in this.properties_[ start_property_pos ] ) {
				for( var i=0; i<pro.nBits; ++i ) {
					var flag = ( ( data >> bit_pos ) & 0x1 ) == 1;
					var label = pro.Summary != "" ? pro.Summary : pro.Property.Name;
					var text = String.Format( "0x{0:X2}_{1} | +{2,5} | {3}", byte_pos, bit_pos % 8, (uint)(1<<i), label );

					this.checkedListBox1.Items.Add( new ListBoxItem( text, pro ), flag);

					bit_pos++;

					if( bit_pos % 8 == 0 ) {
						byte_pos++;
					}
				}
			}
			this.data_update_stop_flag_ = false;
		}
	}
}
