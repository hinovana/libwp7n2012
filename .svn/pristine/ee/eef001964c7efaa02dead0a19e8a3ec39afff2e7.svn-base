using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

namespace WP7_2012ULV
{
	public class HorseSireListView : UMAListView.UMAListViewTpl
	{
		// .NET Frameworkの構造体は値渡しなのでサイズの大きな構造体を扱うときは
		// 上手く扱わないとオーバーヘッドが大きくなる
		// ここではスタックと参照を使って高速化を図る
		private ListViewItem.ListViewSubItem[] __subitems_stack__;

		private int white_color_horse_ = 0;

		public override int WhiteColorHorseCount {
			get {
				return this.white_color_horse_;
			}
		}

		protected override Type[] ExtensionArgTypes {
			get {
				return new Type[] {
					typeof(KOEI.WP7_2012.WP7),
					typeof(UInt32),
					typeof(KOEI.WP7_2012.Datastruct.HSireData),
				};
			}
		}

		protected override void ExecCSharpExtension( System.Reflection.MethodInfo method, WP7_2012ULV.Setting.ExtensionSetting.Manifest manifest )
		{
			var data = new KOEI.WP7_2012.Datastruct.HSireData();

			SelectedItemsEach( ( item_index, horse_num ) => {
				this.WP7.HSireTable.GetData( horse_num, ref data );		
				
				var args = new object[]{
					this.WP7,
					horse_num,
					data
				};
				data = (KOEI.WP7_2012.Datastruct.HSireData) method.Invoke( null, args );

				if( this.Mode == ReadWriteMode.ReadWrite && manifest.Mode == ReadWriteMode.ReadWrite ) {
					this.WP7.HSireTable.SetData( horse_num, ref data );
					this.WP7.HSireTable.Commit( horse_num );

					this.ListView1_VirtualItems[ item_index ] = this.CreateListViewItemByHorseNum( this.WP7, horse_num, ref data );
				}
			});
			this.ListView1.Refresh();
			this.ListView1_OddColor();
		}

		public HorseSireListView( UMAListView.Config config, ReadWriteMode mode, WP7_2012ULV.Setting.ExtensionSetting.Command[] extensions, String extnensions_dir )
			: base( config, mode, extensions, extnensions_dir )
		{
			// pass
		}

		/// <summary>
		/// データを更新してフォームを描画しなおす
		/// </summary>
		/// <param name="item_index">リストビューのアイテムインデックス</param>
		/// <param name="horse_num">馬番号</param>
		/// <param name="data">馬データ</param>
		private void DataUpdateAndRefresh( int item_index, UInt32 horse_num, ref KOEI.WP7_2012.Datastruct.HSireData data )
		{
			this.ListView1_VirtualItems[item_index] = this.CreateListViewItemByHorseNum( WP7, horse_num, ref data );
			this.ListView1_OddColor();
			this.ListView1.Refresh();
		}

		/// <summary>
		/// スポイラーライクな編集を行う
		/// </summary>
		/// <param name="item_index">リストビューのアイテムインデックス</param>
		protected override void SpoilerLikeItemEdit( int item_index )
		{
			var item = this.ListView1.Items[ item_index ];
			var horse_num = (UInt32)((int)item.SubItems["horse_num"].Tag);

			var data = new KOEI.WP7_2012.Datastruct.HSireData();

			var blood_data = new HBloodData();
			var abl_data = new HAblData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var family_line_data = new HFamilyLineData();

			this.WP7.HSireTable.GetData( horse_num, ref data );
			this.WP7.HAblTable.GetData( data.abl_num, ref abl_data );
			this.WP7.HBloodTable.GetData( data.blood_num, ref blood_data );
			this.WP7.HFamilyLineTable.GetData( blood_data.family_line_num, ref family_line_data );

			this.WP7.HBloodTable.GetData( blood_data.father_num, ref father_blood_data );
			this.WP7.HBloodTable.GetData( blood_data.mother_num, ref mother_blood_data );

			var father_name = String.Empty;
			var mother_name = String.Empty;
			var name = this.GetDispName( this.WP7, out mother_name, out father_name, ref blood_data, ref abl_data, ref father_blood_data, ref mother_blood_data );

			var form = new SpoilerLikeEditForm() {
				Text = String.Format( "{0} 編集中 - SpoilerALライク編集(β)", name ),
				Size = new System.Drawing.Size( 700, 800 ),
			};

			// 種牡馬データの編集コントロール
			var data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HSireData.Properties, data.Decode() ){
				Dock = DockStyle.Fill,
				ControlsFont = this.ListView1.Font,
				DataChanged = ( new_data )=> {
					if( this.WP7.TransactionWeekNumber != this.WP7.GetCurrentWeekNumber() ) {
						var message = String.Format(
							"データ取得時から週が変わっています({0}→{1})\r\n安全のため書き込みは行いません、再取得してください",
							this.WP7.TransactionWeekNumber,
							this.WP7.GetCurrentWeekNumber()
						);
						MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
						form.DialogResult = DialogResult.Ignore;
						return;
					}
					var temp_data = new HSireData();
					temp_data.Encode( new_data );
					this.WP7.HSireTable.SetData( horse_num, ref temp_data );
					this.WP7.HSireTable.Commit( horse_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref temp_data );
				},
			};

			// 能力データの編集コントロール
			var abl_data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HAblData.Properties, abl_data.Decode() ) {
				Dock = DockStyle.Fill,
				ControlsFont = this.ListView1.Font,
				DataChanged = ( new_abl_data )=> {
					if( this.WP7.TransactionWeekNumber != this.WP7.GetCurrentWeekNumber() ) {
						var message = String.Format(
							"データ取得時から週が変わっています({0}→{1})\r\n安全のため書き込みは行いません、再取得してください",
							this.WP7.TransactionWeekNumber,
							this.WP7.GetCurrentWeekNumber()
						);
						MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
						form.DialogResult = DialogResult.Ignore;
						return;
					}
					var temp_data = new HAblData();
					temp_data.Encode( new_abl_data );
					this.WP7.HAblTable.SetData( data.abl_num, ref temp_data );
					this.WP7.HAblTable.Commit( data.abl_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				},
			};

			// 血統データの編集コントロール
			var blood_data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HBloodData.Properties, blood_data.Decode() ) {
				Dock = DockStyle.Fill,
				ControlsFont = this.ListView1.Font,
				DataChanged = ( new_blood_data )=> {
					if( this.WP7.TransactionWeekNumber != this.WP7.GetCurrentWeekNumber() ) {
						var message = String.Format(
							"データ取得時から週が変わっています({0}→{1})\r\n安全のため書き込みは行いません、再取得してください",
							this.WP7.TransactionWeekNumber,
							this.WP7.GetCurrentWeekNumber()
						);
						MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
						form.DialogResult = DialogResult.Ignore;
						return;
					}
					var temp_data = new HBloodData();
					temp_data.Encode( new_blood_data );
					this.WP7.HBloodTable.SetData( data.blood_num, ref temp_data );
					this.WP7.HBloodTable.Commit( data.blood_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				},
			};

			// 系統データの編集コントロール
			var family_line_data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HFamilyLineData.Properties, family_line_data.Decode() ) {
				Dock = DockStyle.Fill,
				ControlsFont = this.ListView1.Font,
				DataChanged = ( new_family_line_data )=> {
					if( this.WP7.TransactionWeekNumber != this.WP7.GetCurrentWeekNumber() ) {
						var message = String.Format(
							"データ取得時から週が変わっています({0}→{1})\r\n安全のため書き込みは行いません、再取得してください",
							this.WP7.TransactionWeekNumber,
							this.WP7.GetCurrentWeekNumber()
						);
						MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
						form.DialogResult = DialogResult.Ignore;
						return;
					}
					var temp_data = new HFamilyLineData();
					temp_data.Encode( new_family_line_data );
					this.WP7.HFamilyLineTable.SetData( blood_data.family_line_num, ref temp_data );
					this.WP7.HFamilyLineTable.Commit( blood_data.family_line_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				},
			};

			form.TabPageAdd( "能力データ", new Control[]{ abl_data_editor } );
			form.TabPageAdd( "種牡馬データ", new Control[]{ data_editor } );
			form.TabPageAdd( "血統データ", new Control[]{ blood_data_editor } );
			form.TabPageAdd( String.Format( "{0}系データ", family_line_data.系統名() ), new Control[]{ family_line_data_editor } );

			if( form.ShowDialog() == DialogResult.Cancel ) {
				if( this.WP7.TransactionWeekNumber == this.WP7.GetCurrentWeekNumber() ) {
					this.WP7.HSireTable.SetData( horse_num, ref data );
					this.WP7.HSireTable.Commit( horse_num );
					this.WP7.HAblTable.SetData( data.abl_num, ref abl_data );
					this.WP7.HAblTable.Commit( data.abl_num );
					this.WP7.HBloodTable.SetData( data.blood_num, ref blood_data );
					this.WP7.HBloodTable.Commit( data.blood_num );
					this.WP7.HFamilyLineTable.SetData( blood_data.family_line_num, ref family_line_data );
					this.WP7.HFamilyLineTable.Commit( blood_data.family_line_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				}
			}
		}

		private ColumnHeader[] DefaultColumnHeaders = new ColumnHeader[]
		{
			new ColumnHeader() { Text = "馬名",         Name = "name",              Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "国",           Name = "country",           Width =  30, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "年",           Name = "age",               Width =  30, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "SP",           Name = "speed",             Width =  35, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ST",           Name = "stamina",           Width =  35, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "力",           Name = "power",             Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "瞬",           Name = "syunpatsu",         Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "勝",           Name = "konzyou",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "柔",           Name = "zyuunan",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "精",           Name = "seishin",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "賢",           Name = "kashikosa",         Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "健",           Name = "health",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "サ",           Name = "subpara",           Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "因左",         Name = "factor_left",       Width =  50, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "因右",         Name = "factor_right",      Width =  50, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "子出",         Name = "kodashi",           Width =  40, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "気",           Name = "kisyou",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "場",           Name = "babatekisei",       Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "脚質",         Name = "senpou",            Width =  45, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "成型",         Name = "seichougata",       Width =  40, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "成力",         Name = "seichouryoku",      Width =  40, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "距離適性",     Name = "kyoritekisei",      Width = 100, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "毛色",         Name = "keiro",             Width =  60, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "高",           Name = "taikou",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "長",           Name = "zenchou",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "小",           Name = "komawari_X",        Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "特性",         Name = "tokusei",           Width = 300, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "戦",           Name = "record_len",        Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "勝",           Name = "record_win",        Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "種付料",       Name = "tanetsuke",         Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "BF",           Name = "bookfull",          Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "SC",           Name = "syndicate",         Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "獲得賞金",     Name = "syoukin",           Width = 120, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "重賞勝",       Name = "win_grade_count",   Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "G1勝",         Name = "win_g1_count",      Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "1順位",        Name = "rank_1_ago",        Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "2順位",        Name = "rank_2_ago",        Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "3順位",        Name = "rank_3_ago",        Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "4順位",        Name = "rank_4_ago",        Width =  60, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "父馬",         Name = "father",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "父系",         Name = "family_line",       Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "母馬",         Name = "mother",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "生産国",       Name = "seisankoku",        Width =  80, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "牧場",         Name = "bokuzyou",          Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "特殊配合",     Name = "special_combo",     Width =  80, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "現役",         Name = "is_intai",          Width =  50, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "能力番号",     Name = "abl_num",           Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬番号",       Name = "id",                Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬名",         Name = "name2",             Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
		};
		
		protected override void ListView1_ColumnSetup()
		{
			this.ListView1.Columns.AddRange( DefaultColumnHeaders );
		}

		private Boolean IsViewRecord( WP7 wp, UInt32 horse_num, ref HSireData data, ref HAblData abl_data )
		{
			if( !this.ListViewConfig.Status_Intai && data.intai != 0 ) {
				return false;
			}
			if( !this.ListViewConfig.Status_Geneki && data.intai == 0 ) {
				return false;
			}
			
			if( this.ListViewConfig.OwnerHorse || this.ListViewConfig.ClubHorse ) {
				switch( abl_data.bokuzyou )
				{
				case 25:
				case 27:
				case 28:
					if( !this.ListViewConfig.OwnerHorse )
						return false;
					break;
				case 26:
					if( !this.ListViewConfig.ClubHorse )
						return false;
					break;
				default:
					return false;
				}
			}

			var country = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou );

			switch( country )
			{
			case Enums.CountryType.JAPAN:
				if( !this.ListViewConfig.Country_JAPAN )
					return false;
				break;
			case Enums.CountryType.USA:
				if( !this.ListViewConfig.Country_USA )
					return false;
				break;
			case Enums.CountryType.EURO:
				if( !this.ListViewConfig.Country_EURO )
					return false;
				break;
			default:
				throw new Exception("[BUG]");
			}

			return true;
		}

		private String GetDispName( WP7 wp, out String father_name, out String mother_name, ref HBloodData blood_data, ref HAblData abl_data, ref HBloodData father_blood_data, ref HBloodData mother_blood_data )
		{
//			var name_type = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ) == Enums.CountryType.JAPAN
//				? WP7_2012ULV.Enums.NameType.KANA
//				: WP7_2012ULV.Enums.NameType.ENGLISH;
			var name_type = WP7_2012ULV.Enums.NameType.ENGLISH;

			if( this.ListViewConfig.DispNameType == WP7_2012ULV.Enums.NameType.KANA ) {
				name_type = WP7_2012ULV.Enums.NameType.KANA;
			}

			if( father_blood_data.display == 1 && name_type == WP7_2012ULV.Enums.NameType.ENGLISH ) {
				father_name = wp.馬名( WP7_2012ULV.Enums.NameType.ENGLISH, father_blood_data.name_left, father_blood_data.name_right );
			} else {
				father_name = wp.馬名( WP7_2012ULV.Enums.NameType.KANA, father_blood_data.name_left, father_blood_data.name_right );
			}

			if( mother_blood_data.display == 1 && name_type == WP7_2012ULV.Enums.NameType.ENGLISH ) {
				mother_name = wp.馬名( WP7_2012ULV.Enums.NameType.ENGLISH, mother_blood_data.name_left, mother_blood_data.name_right );
			} else {
				mother_name = wp.馬名( WP7_2012ULV.Enums.NameType.KANA, mother_blood_data.name_left, mother_blood_data.name_right );
			}

			var name = ""; 
			
			if( blood_data.display == 1 ) {
				name = wp.馬名( name_type, blood_data.name_left, blood_data.name_right );
			} else {
				name = wp.馬名( WP7_2012ULV.Enums.NameType.KANA, blood_data.name_left, blood_data.name_right );
			}
			return name;
		}

		private ListViewItem CreateListViewItemByHorseNum( KOEI.WP7_2012.WP7 wp, UInt32 horse_num, ref KOEI.WP7_2012.Datastruct.HSireData data )
		{
			var blood_data = new HBloodData();
			var abl_data = new HAblData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var family_line_data = new HFamilyLineData();

			wp.HAblTable.GetData( data.abl_num, ref abl_data );

			wp.HBloodTable.GetData( data.blood_num, ref blood_data );
			wp.HFamilyLineTable.GetData( blood_data.family_line_num, ref family_line_data );

			wp.HBloodTable.GetData( blood_data.father_num, ref father_blood_data );
			wp.HBloodTable.GetData( blood_data.mother_num, ref mother_blood_data );

			var age_value = data.age + 2;
			var is_intai = data.intai != 0 ? true : false;

			var item = new ListViewItem();
			var n = 1;

			var subparams = new [] {
				new { raw_param = abl_data.power,     },
				new { raw_param = abl_data.syunpatsu, },
				new { raw_param = abl_data.konzyou,   },
				new { raw_param = abl_data.zyuunan,   },
				new { raw_param = abl_data.seishin,   },
				new { raw_param = abl_data.kashikosa, },
				new { raw_param = abl_data.health,    },
			};

			var father_name = String.Empty;
			var mother_name = String.Empty;

			var name = this.GetDispName( wp, out father_name, out mother_name, ref blood_data, ref abl_data, ref father_blood_data, ref mother_blood_data );

			if( abl_data.keiro == 9 ) {
				++this.white_color_horse_;
			}

			var subparam_total = 0u;

			item.Text = name;
			item.SubItems[0].Tag = name;

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ).国().Substring( 0, 1 ),
				Tag = (int)abl_data.bokuzyou,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = age_value.ToString(),
				Tag = (int)age_value,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0}",
					abl_data.speed
				).ToString() ,
				Tag = (int)( abl_data.speed ),
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.stamina.ToString(),
				Tag = (int)abl_data.stamina,
			});
			foreach( var param in subparams ) {
				var param_value = param.raw_param;
				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}", param_value.サブパラ() ),
					Tag = (int)param_value,
				});
				subparam_total += param.raw_param;
			}

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0}", subparam_total ),
				Tag = (int)subparam_total,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = blood_data.factor_left.因子(),
				Tag = (int)blood_data.factor_left,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = blood_data.factor_right.因子(),
				Tag = (int)blood_data.factor_right,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.kodashi.ToString(),
				Tag = (int)abl_data.kodashi,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.kisyou.気性().Substring(0,1),
				Tag = (int)abl_data.kisyou,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.babatekisei.馬場適正().Substring(0,1),
				Tag = (int)abl_data.babatekisei,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.senpou.戦法(),
				Tag = (int)abl_data.senpou,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.seichougata.成長型(),
				Tag = (int)abl_data.seichougata,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.seichouryoku.成長力(),
				Tag = (int)abl_data.seichouryoku,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.stamina.距離適性( abl_data.zyuunan ),
				Tag =  abl_data.stamina.距離適性( abl_data.zyuunan ),
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.keiro.毛色(),
				Tag = (int)abl_data.keiro,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.taikou.体高(),
				Tag = (int)abl_data.taikou,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.zenchou.全長(),
				Tag = (int)abl_data.zenchou,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.komawari_X.苦手(),
				Tag = (int)abl_data.komawari_X,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.特性(" "),
				Tag = abl_data.特性二進数(),
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.record_len.ToString(),
				Tag = (int)data.record_len,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.record_win.ToString(),
				Tag = (int)data.record_win,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", (( data.tanetsuke >> 1 ) * 100 ) + ( data.tanetsuke == 1 ? 50 : 0 ) ),
				Tag = (int)data.tanetsuke,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.bookfull == 1 ? "○" : "",
				Tag = (int)data.bookfull,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.syndicate == 1 ? "○" : "",
				Tag = (int)data.syndicate,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.syoukin ) ),
				Tag = (int) data.syoukin,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.win_grade_count ) ),
				Tag = (int) data.win_grade_count,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.win_g1_count ) ),
				Tag = (int) data.win_g1_count,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = ( data.rank_1_ago + 1 ).ToString(),
				Tag = (int)data.rank_1_ago,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = ( data.rank_2_ago + 1 ).ToString(),
				Tag = (int)data.rank_2_ago,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = ( data.rank_3_ago + 1 ).ToString(),
				Tag = (int)data.rank_3_ago,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = ( data.rank_4_ago + 1 ).ToString(),
				Tag = (int)data.rank_4_ago,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = father_name,
				Tag = father_name,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = family_line_data.系統名() + "系",
				Tag = family_line_data.系統名() + "系",
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = mother_name,
				Tag = mother_name,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.seisankoku.生産国(),
				Tag = (int) abl_data.seisankoku,
			});


			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.bokuzyou.ToString(),
				Tag = (int) abl_data.bokuzyou,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.特殊配合(),
				Tag = abl_data.特殊配合(),
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.intai == 0 ? "○" : "×",
				Tag = data.intai == 0  ? 0 : 1,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", data.abl_num ),
				Tag = (int)data.abl_num,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", horse_num ),
				Tag = (int)horse_num,
				Name = "horse_num",
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = name,
				Tag = name,
			});

			item.SubItems.AddRange( __subitems_stack__ );

			return item;
		}

		protected override ListViewItem[] CreateHorseListSub( KOEI.WP7_2012.WP7 wp, object arg )
		{
			this.__subitems_stack__ = new ListViewItem.ListViewSubItem[ DefaultColumnHeaders.Length ];

			var data = new HSireData();
			var blood_data = new HBloodData();
			var abl_data = new HAblData();

			var items = new List< ListViewItem >();

			this.white_color_horse_ = 0;

			if( this.ListViewConfig.TargetHorseNum != null ) {
				foreach( var horse_num in this.ListViewConfig.TargetHorseNum ) {
					wp.HSireTable.GetData( horse_num, ref data );
					var item = CreateListViewItemByHorseNum( wp, horse_num, ref data );
					if( item == null ) {
						return new ListViewItem[0];
					}
					return new ListViewItem[1] {
						item,
					};
				}
			}

			if( this.ListViewConfig.CurrentHorse ) {
				var n = wp.GetCurrentCharacterNumber();
				wp.HSireTable.GetData( n, ref data );
				var item = CreateListViewItemByHorseNum( wp, n, ref data );
				if( item == null ) {
					return new ListViewItem[0];
				}
				return new ListViewItem[1] {
					item,
				};
			}

			for( var i=0; i<wp.Config.HorseSireTable.RecordMaxLength; ++i )
			{
				var horse_num = i;

				wp.HSireTable.GetData( (uint)horse_num, ref data );
				wp.HAblTable.GetData( data.abl_num, ref abl_data );

				if( !this.IsViewRecord( wp, (uint)horse_num, ref data, ref abl_data ) ) {
					continue;
				}

				wp.HBloodTable.GetData( data.blood_num, ref blood_data );

				if( blood_data.father_num == wp.Config.IgnoreBloodNumber ) {
					continue;
				}

				items.Add( this.CreateListViewItemByHorseNum( wp, (uint)horse_num, ref data ) );
			}

			return items.ToArray();
		}
	}
}
