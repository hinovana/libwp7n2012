using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

namespace WP7_2012ULV
{
	public class HorseChildListView : UMAListView.UMAListViewTpl
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
					typeof(KOEI.WP7_2012.Datastruct.HChildData),
				};
			}
		}

		public HorseChildListView( UMAListView.Config config, ReadWriteMode mode, Setting.ExtensionSetting.Command[] extensions, String extnensions_dir )
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
		private void DataUpdateAndRefresh( int item_index, UInt32 horse_num, ref HChildData data )
		{
			this.__subitems_stack__ = new ListViewItem.ListViewSubItem[ DefaultColumnHeaders.Length ];
			this.ListView1_VirtualItems[item_index] = this.CreateListViewItemByHorseNum( this.WP7, horse_num, ref data );
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

			var data = new KOEI.WP7_2012.Datastruct.HChildData();
			var abl_data = new HAblData();
			var father_data = new HSireData();
			var mother_data = new HDamData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var father_family_line_data = new HFamilyLineData();

			this.WP7.HChildTable.GetData( horse_num, ref data );
			this.WP7.HAblTable.GetData( data.abl_num, ref abl_data );
			this.WP7.HSireTable.GetData( data.father_num, ref father_data );
			this.WP7.HDamTable.GetData( data.mother_num, ref mother_data );
			this.WP7.HBloodTable.GetData( father_data.blood_num, ref father_blood_data );
			this.WP7.HBloodTable.GetData( mother_data.blood_num, ref mother_blood_data );
			this.WP7.HFamilyLineTable.GetData( father_blood_data.family_line_num, ref father_family_line_data );

			var father_name = String.Empty;
			var mother_name = String.Empty;
			var name = this.GetDispName( this.WP7, out mother_name, out father_name, ref data, ref abl_data, ref father_blood_data, ref mother_blood_data );

			var form = new SpoilerLikeEditForm() {
				Text = String.Format( "{0} 編集中 - SpoilerALライク編集(β)", name ),
				Size = new System.Drawing.Size( 700, 800 ),
			};

			// 競走馬データの編集コントロール
			var data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HChildData.Properties, data.Decode() ){
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
					var temp_data = new HChildData();
					temp_data.Encode( new_data );
					this.WP7.HChildTable.SetData( horse_num, ref temp_data );
					this.WP7.HChildTable.Commit( horse_num );
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

			form.TabPageAdd( "能力データ", new Control[]{ abl_data_editor } );
			form.TabPageAdd( "幼駒データ", new Control[]{ data_editor } );

			if( form.ShowDialog() == DialogResult.Cancel ) {
				if( this.WP7.TransactionWeekNumber == this.WP7.GetCurrentWeekNumber() ) {
					this.WP7.HChildTable.SetData( horse_num, ref data );
					this.WP7.HChildTable.Commit( horse_num );
					this.WP7.HAblTable.SetData( data.abl_num, ref abl_data );
					this.WP7.HAblTable.Commit( data.abl_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				}
			}
		}

		protected override void ExecCSharpExtension( System.Reflection.MethodInfo method, WP7_2012ULV.Setting.ExtensionSetting.Manifest manifest )
		{
			var data = new KOEI.WP7_2012.Datastruct.HChildData();

			SelectedItemsEach( ( item_index, horse_num ) => {
				this.WP7.HChildTable.GetData( horse_num, ref data );		
				
				var args = new object[]{
					this.WP7,
					horse_num,
					data
				};
				data = (KOEI.WP7_2012.Datastruct.HChildData) method.Invoke( null, args );

				if( this.Mode == ReadWriteMode.ReadWrite && manifest.Mode == ReadWriteMode.ReadWrite ) {
					this.WP7.HChildTable.SetData( horse_num, ref data );
					this.WP7.HChildTable.Commit( horse_num );

					this.ListView1_VirtualItems[ item_index ] = this.CreateListViewItemByHorseNum( this.WP7, horse_num, ref data );
				}
			});
			this.ListView1.Refresh();
			this.ListView1_OddColor();
		}

		private ColumnHeader[] DefaultColumnHeaders = new ColumnHeader[]
		{
			new ColumnHeader() { Text = "馬名",         Name = "name",              Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "国",           Name = "country",           Width =  30, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "年",           Name = "age",               Width =  30, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "性",           Name = "gender",            Width =  30, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "SP",           Name = "speed",             Width =  50, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ST",           Name = "stamina",           Width =  35, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "力",           Name = "power",             Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "瞬",           Name = "syunpatsu",         Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "勝",           Name = "konzyou",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "柔",           Name = "zyuunan",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "精",           Name = "seishin",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "賢",           Name = "kashikosa",         Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "健",           Name = "health",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "サ",           Name = "subpara",           Width =  50, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "気",           Name = "kisyou",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "場",           Name = "babatekisei",       Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "脚質",         Name = "senpou",            Width =  45, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "成型",         Name = "seichougata",       Width =  40, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "成力",         Name = "seichouryoku",      Width =  40, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "成限",         Name = "seigen",            Width =  40, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "寿命",         Name = "zyumyou",           Width =  40, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "距離適性",     Name = "kyoritekisei",      Width = 100, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "子出",         Name = "kodashi",           Width =  40, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "毛色",         Name = "keiro",             Width =  60, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "高",           Name = "taikou",            Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "長",           Name = "zenchou",           Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "小",           Name = "komawari_X",        Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "左",           Name = "hidarimawari_X",    Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "右",           Name = "migimawari_X",      Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "脚",           Name = "weak_point_1",      Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "喉",           Name = "weak_point_2",      Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "腰",           Name = "weak_point_3",      Width =  30, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "特性",         Name = "tokusei",           Width = 300, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "札",           Name = "fuda_color",        Width =  35, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬印",         Name = "mark",              Width =  50, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "評価額",       Name = "price2",            Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "取引額",       Name = "price1",            Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "父馬",         Name = "father",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "父系",         Name = "family_line",       Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "母馬",         Name = "mother",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "生産国",       Name = "seisankoku",        Width =  80, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬主",         Name = "owner",             Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "牧場",         Name = "bokuzyou",          Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "史実",         Name = "is_sizitsu",        Width =  50, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "史実番号",     Name = "shizitsu_num",      Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "能力番号",     Name = "abl_num",           Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬番号",       Name = "horse_num",         Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬名",         Name = "name2",             Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
		};

		protected override void ListView1_ColumnSetup()
		{
			this.ListView1.Columns.AddRange( DefaultColumnHeaders );
		}

		private Boolean IsViewRecord( WP7 wp, UInt32 horse_num, ref HChildData data, ref HAblData abl_data )
		{
			if( data.abl_num == wp.Config.NullAbilityNumber ) { 
				return false;
			}

			// セリ馬
			if( this.ListViewConfig.SaleHorse ) {
				return data.owner == 43;
			}

			switch( data.age )
			{
			case 0:
				if( !this.ListViewConfig.Age_0 )
					return false;
				break;
			case 1:
				if( !this.ListViewConfig.Age_1 )
					return false;
				break;
			default:
				throw new Exception("[BUG]");
			}		

			if( this.ListViewConfig.OwnerHorse || this.ListViewConfig.ClubHorse ) {
				switch( data.owner )
				{
				case 41:
					if( !this.ListViewConfig.OwnerHorse )
						return false;
					break;
				case 42:
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

		private String GetDispName( WP7 wp, out String father_name, out String mother_name, ref HChildData data, ref HAblData abl_data, ref HBloodData father_blood_data, ref HBloodData mother_blood_data )
		{
			var name = "";

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

			if( data.shizitsu_num == wp.Config.NullShizitsuNumber ) {
				name = String.Format( "{0}の{1}歳", mother_name, data.age );
			} else {
				var blood_num = (UInt32) BitConverter.ToUInt16( wp.HShizitsuNameTable[ data.shizitsu_num ], 0 );
				var blood_data = new KOEI.WP7_2012.Datastruct.HBloodData();

				wp.HBloodTable.GetData( blood_num, ref blood_data );

				if( blood_data.display == 1 && name_type == WP7_2012ULV.Enums.NameType.ENGLISH ) {
					name = String.Format( "☆{0}", wp.馬名( WP7_2012ULV.Enums.NameType.ENGLISH, blood_data.name_left, blood_data.name_right ) );
				} else {
					name = String.Format( "☆{0}", wp.馬名( WP7_2012ULV.Enums.NameType.KANA, blood_data.name_left, blood_data.name_right ) );
				}
			}
			return name;
		}

		private ListViewItem CreateListViewItemByHorseNum( KOEI.WP7_2012.WP7 wp, UInt32 horse_num, ref KOEI.WP7_2012.Datastruct.HChildData data )
		{
			var abl_data = new HAblData();
			var father_data = new HSireData();
			var mother_data = new HDamData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var father_family_line_data = new HFamilyLineData();
			var owner_ship_data = new HOwnershipChildData();

			wp.HAblTable.GetData( data.abl_num, ref abl_data );
			wp.HSireTable.GetData( data.father_num, ref father_data );
			wp.HDamTable.GetData( data.mother_num, ref mother_data );
			wp.HBloodTable.GetData( father_data.blood_num, ref father_blood_data );
			wp.HBloodTable.GetData( mother_data.blood_num, ref mother_blood_data );
			wp.HFamilyLineTable.GetData( father_blood_data.family_line_num, ref father_family_line_data );

			var age_value = data.age;
			var is_ownership_horse = false;

			var father_name = String.Empty;
			var mother_name = String.Empty;

			var name = this.GetDispName( wp, out father_name, out mother_name, ref data, ref abl_data, ref father_blood_data, ref mother_blood_data );

			var mark = 0u;

			if( data.owner == 41 ) {
				owner_ship_data = new KOEI.WP7_2012.Datastruct.HOwnershipChildData();
				for( var ii=0; ii< wp.HOwnershipRaceTable.RecordCount; ++ii ) {
					wp.HOwnershipChildTable.GetData( (uint)ii, ref owner_ship_data );
					if( owner_ship_data.horse_num == horse_num ) {
						mark = owner_ship_data.mark;
						is_ownership_horse = true;
						break;
					}
				}
			}

			var item = new ListViewItem();

			var is_shizitsu = data.shizitsu_num != wp.Config.NullShizitsuNumber;

			var subparams = new [] {
				new { raw_param = abl_data.power,     seichou = owner_ship_data.seichou_power, },
				new { raw_param = abl_data.syunpatsu, seichou = owner_ship_data.seichou_syunpatsu, },
				new { raw_param = abl_data.konzyou,   seichou = owner_ship_data.seichou_konzyou, },
				new { raw_param = abl_data.zyuunan,   seichou = owner_ship_data.seichou_zyuunan, },
				new { raw_param = abl_data.seishin,   seichou = owner_ship_data.seichou_seishin, },
				new { raw_param = abl_data.kashikosa, seichou = owner_ship_data.seichou_kashikosa, },
				new { raw_param = abl_data.health,    seichou = owner_ship_data.seichou_health, },
			};

			var zyuunan = abl_data.zyuunan + owner_ship_data.seichou_zyuunan / 10;

			if( abl_data.keiro == 9 ) {
				++this.white_color_horse_;
			}

			var n = 1;
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
				Text = data.gender.性別(),
				Tag = (int)data.gender,
			});

			if( is_ownership_horse ) {
				var subparam_seichou_total = 0u;

				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}({1})",
						abl_data.speed + owner_ship_data.seichou_speed,
						abl_data.speed
					).ToString() ,
					Tag = (int)( abl_data.speed + owner_ship_data.seichou_speed ),
				});
				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = abl_data.stamina.ToString(),
					Tag = (int)abl_data.stamina,
				});

				foreach( var param in subparams ) {
					var param_value = param.raw_param + param.seichou / 10;
					__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
						Text = String.Format( "{0}({1,3})", param_value.サブパラ(), "+" + param.seichou.ToString() ),
						Tag = (int)param_value,
					});
					subparam_total += param.raw_param;
					subparam_seichou_total += param.seichou / 10;
				}

				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0,2}({1,3})",
						subparam_total + subparam_seichou_total,
						"+" + subparam_seichou_total.ToString()
					).ToString() ,
					Tag = (int)subparam_total,
				});
			} else {
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
					Text = String.Format( "{0}",
						subparam_total
					).ToString() ,
					Tag = (int)subparam_total,
				});
			}

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
				Text = ( 100 + data.seigen ).ToString(),
				Tag = (int)data.seigen,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.zyumyou.ToString(),
				Tag = (int)data.zyumyou,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.stamina.距離適性( zyuunan ),
				Tag =  abl_data.stamina.距離適性( zyuunan ),
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.kodashi.ToString(),
				Tag = (int)abl_data.kodashi,
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
				Text = data.hidarimawari_X.苦手(),
				Tag = (int)data.hidarimawari_X,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.migimawari_X.苦手(),
				Tag = (int)data.migimawari_X,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_1.持病(),
				Tag = (int)data.weak_point_1,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_2.持病(),
				Tag = (int)data.weak_point_2,
			});
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_3.持病(),
				Tag = (int)data.weak_point_3,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.特性(" "),
				Tag = abl_data.特性二進数(),
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.fuda_color.お札(),
				Tag = (int) data.fuda_color,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = mark.馬印(),
				Tag = (int) mark,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.price2 * 100 ) ),
				Tag = (int) data.price2,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.price * 100 ) ),
				Tag = (int) data.price,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = father_name,
				Tag = father_name,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = father_family_line_data.系統名() + "系",
				Tag = father_family_line_data.系統名() + "系",
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
				Text = data.owner.ToString(),
				Tag = (int) data.owner,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = abl_data.bokuzyou.ToString(),
				Tag = (int) abl_data.bokuzyou,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = is_shizitsu ? "○" : "",
				Tag = is_shizitsu  ? 1 : 0,
			});
			
			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", data.shizitsu_num ),
				Tag = (int)data.shizitsu_num,
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

			var data = new KOEI.WP7_2012.Datastruct.HChildData();
			var abl_data = new KOEI.WP7_2012.Datastruct.HAblData();

			var items = new List< ListViewItem >();

			this.white_color_horse_ = 0;

			if( this.ListViewConfig.CurrentHorse ) {
				var n = wp.GetCurrentCharacterNumber();
				wp.HChildTable.GetData( n, ref data );
				var item = CreateListViewItemByHorseNum( wp, n, ref data );
				if( item == null ) {
					return new ListViewItem[0];
				}
				return new ListViewItem[1] {
					item,
				};
			}

			for( var i=0; i<wp.Config.HorseChildTable.RecordMaxLength; ++i )
			{
				var horse_num = (uint)i;

				wp.HChildTable.GetData( (uint)horse_num, ref data );
				wp.HAblTable.GetData( data.abl_num, ref abl_data );

				if( !this.IsViewRecord( wp, horse_num, ref data, ref abl_data ) ) {
					continue;
				}
				items.Add( this.CreateListViewItemByHorseNum( wp, horse_num, ref data ) );
			}
			return items.ToArray();
		}
	}
}
