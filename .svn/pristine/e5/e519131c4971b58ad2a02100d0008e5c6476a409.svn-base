using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

namespace WP7_2012ULV
{
	public class HorseRaceListView : UMAListView.UMAListViewTpl
	{
		/// <summary>
		/// カラムリスト
		/// </summary>
		private ColumnHeader[] DefaultColumnHeaders = new ColumnHeader[] {
			new ColumnHeader() { Text = "馬名",     Name = "name",           Width = 200, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "国",       Name = "country",        Width = 30,  TextAlign = HorizontalAlignment.Center, Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "年",       Name = "age",            Width = 30,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "性",       Name = "gender",         Width = 30,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "SP",       Name = "speed",          Width = 50,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "ST",       Name = "stamina",        Width = 35,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "力",       Name = "power",          Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "瞬",       Name = "syunpatsu",      Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "勝",       Name = "konzyou",        Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "柔",       Name = "zyuunan",        Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "精",       Name = "seishin",        Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "賢",       Name = "kashikosa",      Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "健",       Name = "health",         Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "サ",       Name = "subpara",        Width = 50,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "気",       Name = "kisyou",         Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "場",       Name = "babatekisei",    Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "脚質",     Name = "senpou",         Width = 45,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "成型",     Name = "seichougata",    Width = 40,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "成力",     Name = "seichouryoku",   Width = 40,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "成度",     Name = "seichou",        Width = 40,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "成限",     Name = "seigen",         Width = 40,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "寿命",     Name = "zyumyou",        Width = 40,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "調子",     Name = "choushi",        Width = 50,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "疲労",     Name = "hirou",          Width = 50,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "馬体重",   Name = "weight",         Width = 70,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "距離適性", Name = "kyoritekisei",   Width = 100, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "子出",     Name = "kodashi",        Width = 40,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "毛色",     Name = "keiro",          Width = 60,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "高",       Name = "taikou",         Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "長",       Name = "zenchou",        Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "跳",       Name = "souhou",         Width = 30,  TextAlign = HorizontalAlignment.Center, Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "小",       Name = "komawari_X",     Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "左",       Name = "hidarimawari_X", Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "右",       Name = "migimawari_X",   Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "脚",       Name = "weak_point_1",   Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "喉",       Name = "weak_point_2",   Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "腰",       Name = "weak_point_3",   Width = 30,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "特性",     Name = "tokusei",        Width = 300, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "父馬",     Name = "father",         Width = 200, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "父系",     Name = "family_line",    Width = 200, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "母馬",     Name = "mother",         Width = 200, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "出走",     Name = "race_len",       Width = 40,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "戦績",     Name = "race_win_len",   Width = 160, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
			new ColumnHeader() { Text = "次走",     Name = "zisou",          Width = 120, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING   },
			new ColumnHeader() { Text = "クラス",   Name = "klass",          Width = 100, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "賞金",     Name = "earning_all",    Width = 80,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "本賞金",   Name = "earning_hon",    Width = 80,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "生産国",   Name = "seisankoku",     Width = 80,  TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "馬主",     Name = "owner",          Width = 50,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "牧場",     Name = "bokuzyou",       Width = 50,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "調教師",   Name = "trainer",        Width = 70,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "騎手",     Name = "shusen_jk_num",  Width = 50,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "現役",     Name = "is_intai",       Width = 50,  TextAlign = HorizontalAlignment.Center, Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "史実",     Name = "is_sizitsu",     Width = 50,  TextAlign = HorizontalAlignment.Center, Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "史実番号", Name = "shizitsu_num",   Width = 80,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "能力番号", Name = "abl_num",        Width = 80,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "馬番号",   Name = "horse_num",      Width = 80,  TextAlign = HorizontalAlignment.Right,  Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC, },
			new ColumnHeader() { Text = "馬名",     Name = "name2",          Width = 200, TextAlign = HorizontalAlignment.Left,   Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,  },
		};

		// .NET Frameworkの構造体は値渡しなのでサイズの大きな構造体を扱うときは
		// 上手く扱わないとオーバーヘッドが大きくなる
		// ここではスタックを使って高速化している
		private ListViewItem.ListViewSubItem[] __subitems_stack__;

		/// <summary>
		/// 白毛馬の数
		/// </summary>
		private int white_color_horse_ = 0;

		/// <summary>
		/// 白毛馬の数
		/// </summary>
		public override int WhiteColorHorseCount {
			get {
				return this.white_color_horse_;
			}
		}

		/// <summary>
		/// 拡張機能のメソッドが要求する引数の型
		/// </summary>
		protected override Type[] ExtensionArgTypes {
			get {
				return new Type[] {
					typeof(KOEI.WP7_2012.WP7),
					typeof(UInt32),
					typeof(KOEI.WP7_2012.Datastruct.HRaceData),
				};
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="config"></param>
		/// <param name="extensions"></param>
		/// <param name="extnensions_dir"></param>
		public HorseRaceListView( UMAListView.Config config, ReadWriteMode mode,Setting.ExtensionSetting.Command[] extensions, String extnensions_dir )
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
		private void DataUpdateAndRefresh( int item_index, UInt32 horse_num, ref KOEI.WP7_2012.Datastruct.HRaceData data )
		{
			this.__subitems_stack__ = new ListViewItem.ListViewSubItem[ DefaultColumnHeaders.Length ];
			this.ListView1_VirtualItems[item_index] = this.CreateListViewItemByHorseNum( WP7, horse_num, ref data );
			this.ListView1_OddColor();
			this.ListView1.Refresh();
		}

		/// <summary>
		/// スポイラーライクな編集を行う
		/// このままだとプログラミングミスが起きそうなのでコードを整理したい
		/// </summary>
		/// <param name="item_index">リストビューのアイテムインデックス</param>
		protected override void SpoilerLikeItemEdit( int item_index )
		{
			var item = this.ListView1.Items[ item_index ];
			var horse_num = (UInt32)((int)item.SubItems["horse_num"].Tag);

			var data = new KOEI.WP7_2012.Datastruct.HRaceData();
			var abl_data = new KOEI.WP7_2012.Datastruct.HAblData();

			this.WP7.HRaceTable.GetData( horse_num, ref data );
			this.WP7.HAblTable.GetData( data.abl_num, ref abl_data );

			var name_type = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ) == Enums.CountryType.JAPAN
				? WP7_2012ULV.Enums.NameType.KANA
				: WP7_2012ULV.Enums.NameType.ENGLISH;

			if( this.ListViewConfig.DispNameType == WP7_2012ULV.Enums.NameType.KANA ) {
				name_type = WP7_2012ULV.Enums.NameType.KANA;
			}

			var form = new SpoilerLikeEditForm() {
				Text = String.Format( "{0} 編集中 - SpoilerALライク編集(β)", this.WP7.馬名( name_type, data.name_left, data.name_right ) ),
				Size = new System.Drawing.Size( 700, 800 ),
			};

			// 競走馬データの編集コントロール
			var data_editor = new SpoilerLikeControls.BitCheckList( this.WP7, HRaceData.Properties, data.Decode() ){
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
					var temp_data = new HRaceData();
					temp_data.Encode( new_data );
					this.WP7.HRaceTable.SetData( horse_num, ref temp_data );
					this.WP7.HRaceTable.Commit( horse_num );
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
			form.TabPageAdd( "競走馬データ", new Control[]{ data_editor } );

			if( form.ShowDialog() == DialogResult.Cancel ) {
				if( this.WP7.TransactionWeekNumber == this.WP7.GetCurrentWeekNumber() ) {
					this.WP7.HRaceTable.SetData( horse_num, ref data );
					this.WP7.HRaceTable.Commit( horse_num );
					this.WP7.HAblTable.SetData( data.abl_num, ref abl_data );
					this.WP7.HAblTable.Commit( data.abl_num );
					this.DataUpdateAndRefresh( item_index, horse_num, ref data );
				}
			}
		}

		/// <summary>
		/// C#の拡張機能を実行する
		/// </summary>
		/// <param name="method">呼び出すメソッド</param>
		protected override void ExecCSharpExtension( System.Reflection.MethodInfo method, WP7_2012ULV.Setting.ExtensionSetting.Manifest manifest )
		{
			var data = new KOEI.WP7_2012.Datastruct.HRaceData();

			SelectedItemsEach( ( item_index, horse_num ) => {
				this.WP7.HRaceTable.GetData( horse_num, ref data );		
				
				var args = new object[]{
					this.WP7,
					horse_num,
					data
				};
				data = (KOEI.WP7_2012.Datastruct.HRaceData) method.Invoke( null, args );

				if( this.Mode == ReadWriteMode.ReadWrite && manifest.Mode == ReadWriteMode.ReadWrite ) {
					this.WP7.HRaceTable.SetData( horse_num, ref data );
					this.WP7.HRaceTable.Commit( horse_num );

					this.ListView1_VirtualItems[ item_index ] = this.CreateListViewItemByHorseNum( this.WP7, horse_num, ref data );
				}
			});
			this.ListView1.Refresh();
			this.ListView1_OddColor();
		}

		/// <summary>
		/// リストビューのカラムをセットアップする
		/// </summary>
		protected override void ListView1_ColumnSetup()
		{
			this.ListView1.Columns.Clear();
			this.ListView1.Columns.AddRange( DefaultColumnHeaders );
		}

		private UInt32 GetRaceString( ref WP7 wp, ref HRaceData data, ref String zisou_race_name, ref String zisou_sort_string )
		{
			if( data.nyuukyuu == 0 ) {
				zisou_race_name = "入厩前";
				zisou_sort_string = String.Format( "Y-00-00" );
				return 0;
			} else if( data.houbokuchuu > 0 ) {
				zisou_sort_string = String.Format( "Z-{0:D2}-{1:D2}", data.houbokuchuu, data.houboku_len );
//				zisou_race_name = String.Format( "{0}放牧中(残り{1}週) {2}", data.houbokuchuu.放牧理由(), data.houboku_len, zisou_sort_string );
				zisou_race_name = String.Format( "{0}放牧中(残り{1}週)", data.houbokuchuu.放牧理由(), data.houboku_len );
				return 0;
			}

			if( data.rase_next_week > wp.Config.YearWeekLength ) {
				zisou_race_name = "不明なレース(1)";
				zisou_sort_string = String.Format( "X-00-00" );
				return 0;
			}
			var week = wp.RProgramTable[ data.rase_next_week ];
			var pos = 0u;
			
			if( data.rase_next_location != 3 ) {
				pos += data.rase_next_location * 22;
				pos += data.rase_next_sunday == 0u ? 0u : 11u;
				pos += data.rase_next_num;
			} else {
				pos += 22 * 3;
				pos += (uint)( data.rase_next_sunday == 1 || data.rase_next_num > 13 ? 14 : 0 );
				pos += data.rase_next_num;
			}

			if( pos > (wp.Config.RaceProgramTable.RecordSize / 2) ) {
				zisou_race_name = "不明なレース(2)";
				zisou_sort_string = String.Format( "W-00-00" );
				return 0;
			}

			var race_num = week[pos];
			var str = String.Empty;
			var race_data = new KOEI.WP7_2012.Datastruct.RRaceData();

			if( race_num == wp.Config.NullRaceProgramNumber ) {
				str = "不明なレース";
			} else {
				wp.RDataTable.GetData( race_num, ref race_data );
				str = wp.RNameTable[ (int)race_data.race_name_num ].ShortName;
			}

			zisou_sort_string = String.Format( "{0}-{1:D2}-{2:D2}",
				( data.race_next_age == data.age ? "A" : "B" ), data.rase_next_week, pos
			);

//			zisou_race_name = String.Format( "{0} - {1}({2})", wp.月週( data.rase_next_week ), str, zisou_sort_string );
			zisou_race_name = String.Format( "{0} - {1}", wp.月週( data.rase_next_week ), str );

			return race_data.distance;
		}

		private String GetDispName( WP7 wp, out String father_name, out String mother_name, ref HRaceData data, ref HAblData abl_data, ref HBloodData father_blood_data, ref HBloodData mother_blood_data )
		{
			var name_type = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ) == Enums.CountryType.JAPAN
				? WP7_2012ULV.Enums.NameType.KANA
				: WP7_2012ULV.Enums.NameType.ENGLISH;

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

			var name = wp.馬名( name_type, data.name_left, data.name_right );

			return name;
		}

		private ListViewItem CreateListViewItemByHorseNum( KOEI.WP7_2012.WP7 wp, UInt32 horse_num, ref KOEI.WP7_2012.Datastruct.HRaceData data )
		{
			var abl_data = new HAblData();
			var father_data = new HSireData();
			var mother_data = new HDamData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var father_family_line_data = new HFamilyLineData();
			var owner_ship_data = new HOwnershipRaceData();

			wp.HAblTable.GetData( data.abl_num, ref abl_data );
			wp.HSireTable.GetData( data.father_num, ref father_data );
			wp.HDamTable.GetData( data.mother_num, ref mother_data );
			wp.HBloodTable.GetData( father_data.blood_num, ref father_blood_data );
			wp.HBloodTable.GetData( mother_data.blood_num, ref mother_blood_data );
			wp.HFamilyLineTable.GetData( father_blood_data.family_line_num, ref father_family_line_data );
			
			var item = new ListViewItem() {
				Tag = (UInt32)horse_num,
			};

			String father_name, mother_name;

			var name = this.GetDispName( wp, out father_name, out mother_name, ref data, ref abl_data, ref father_blood_data, ref mother_blood_data ); 

			var age_value = data.age + 2;
			var is_ownership_horse = false;
			var seichou_value = data.seichou;

			if( data.owner == 41 ) {
				for( var ii=0; ii< wp.HOwnershipRaceTable.RecordCount; ++ii ) {
					wp.HOwnershipRaceTable.GetData( (uint)ii, ref owner_ship_data );
					if( owner_ship_data.horse_num == horse_num ) {
						is_ownership_horse = true;
						break;
					}
				}
			}

			var career = data.career_dirt_1 + data.career_shiba_1
					+ data.career_dirt_2 + data.career_shiba_2
					+ data.career_dirt_3 + data.career_shiba_3
					+ data.career_dirt_4 + data.career_shiba_4;

			var is_shizitsu = data.shizitsu_num != wp.Config.NullShizitsuNumber;
	
			var subparams = new [] {
				new { raw_param = abl_data.power,     name = "power",     seichou = owner_ship_data.seichou_power, },
				new { raw_param = abl_data.syunpatsu, name = "syunpatsu", seichou = owner_ship_data.seichou_syunpatsu, },
				new { raw_param = abl_data.konzyou,   name = "konzyou",   seichou = owner_ship_data.seichou_konzyou, },
				new { raw_param = abl_data.zyuunan,   name = "zyuunan",   seichou = owner_ship_data.seichou_zyuunan, },
				new { raw_param = abl_data.seishin,   name = "seishin",   seichou = owner_ship_data.seichou_seishin, },
				new { raw_param = abl_data.kashikosa, name = "kashikosa", seichou = owner_ship_data.seichou_kashikosa, },
				new { raw_param = abl_data.health,    name = "health",    seichou = owner_ship_data.seichou_health, },
			};

			var zisou_race_name   = String.Empty;
			var zisou_sort_string = String.Empty;

			var race_distance = this.GetRaceString( ref wp, ref data, ref zisou_race_name, ref zisou_sort_string );

			var zyuunan = abl_data.zyuunan + owner_ship_data.seichou_zyuunan / 10;

			if( race_distance.レース距離() > abl_data.stamina.距離適性上限( zyuunan ) ) {
				item.ForeColor = System.Drawing.Color.Red;
			}

			if( abl_data.keiro == 9 ) {
				++this.white_color_horse_;
			}

			var subparam_total = 0u;

			var n = 1;


			item.Text = String.Format( "{0}{1}", 
				data.maruchihou != 0 ? "(地)" 
				: abl_data.seisankoku != 0 && Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ) == Enums.CountryType.JAPAN ? "(外)" : "", name );

			item.SubItems[0].Tag = name;
			item.SubItems[0].Name = "name";

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = Helper.GetCountryByBokuzyouNum( abl_data.bokuzyou ).国().Substring( 0, 1 ),
				Tag = (int)abl_data.bokuzyou,
				Name = "country",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = age_value.ToString(),
				Tag = (int)age_value,
				Name = "age_value",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.gender.性別(),
				Tag = (int)data.gender,
				Name = "gender",
			});

			if( is_ownership_horse ) {
				var subparam_seichou_total = 0u;

				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}({1})",
						abl_data.speed + owner_ship_data.seichou_speed,
						abl_data.speed
					).ToString(),
					Tag = (int)( abl_data.speed + owner_ship_data.seichou_speed ),
					Name = "speed",
				});
				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = abl_data.stamina.ToString(),
					Tag = (int)abl_data.stamina,
					Name = "stamina",
				});

				foreach( var param in subparams ) {
					var param_value = param.raw_param + param.seichou / 10;
					__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
						Text = String.Format( "{0}({1,3})", param_value.サブパラ(), "+" + param.seichou.ToString() ),
						Tag = (int)param_value,
						Name = param.name,
					});
					subparam_total += param.raw_param + param.seichou / 10;
					subparam_seichou_total += param.seichou / 10;
				}

				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}({1,3})",
						subparam_total,
						"+" + subparam_seichou_total.ToString()
					).ToString() ,
					Tag = (int)subparam_total,
					Name = "subparam_total",
				});
			} else {
				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}",
						abl_data.speed
					).ToString() ,
					Tag = (int)( abl_data.speed ),
					Name = "speed",
				});
				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = abl_data.stamina.ToString(),
					Tag = (int)abl_data.stamina,
					Name = "stamina",
				});

				foreach( var param in subparams ) {
					var param_value = param.raw_param;
					__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
						Text = String.Format( "{0}", param_value.サブパラ() ),
						Tag = (int)param_value,
						Name = param.name,
					});
					subparam_total += param.raw_param;
				}

				__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
					Text = String.Format( "{0}",
						subparam_total
					).ToString() ,
					Tag = (int)subparam_total,
					Name = "kisyou",
				});
			}

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.kisyou.気性().Substring(0,1),
				Tag = (int)abl_data.kisyou,
				Name = "kisyou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.babatekisei.馬場適正().Substring(0,1),
				Tag = (int)abl_data.babatekisei,
				Name = "babatekisei",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.senpou.戦法(),
				Tag = (int)abl_data.senpou,
				Name = "senpou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.seichougata.成長型(),
				Tag = (int)abl_data.seichougata,
				Name = "seichougata",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.seichouryoku.成長力(),
				Tag = (int)abl_data.seichouryoku,
				Name = "seichouryoku",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = seichou_value.ToString(),
				Tag = (int)seichou_value,
				Name = "seichou_value",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = ( 100 + data.seigen ).ToString(),
				Tag = (int)data.seigen,
				Name = "seigen",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.zyumyou.ToString(),
				Tag = (int)data.zyumyou,
				Name = "zyumyou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0} {1}", data.choushi, data.choushi_status.調子向き() ),
				Tag = (int)data.choushi,
				Name = "choushi",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.hirou.ToString(),
				Tag = (int)data.hirou,
				Name = "hirou",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0}{1}({2})", 
					data.weight_now > data.weight_best ? "+" : "",
					( (int)data.weight_now - (int)data.weight_best ) * 2,
					( data.weight_now * 2 ) + 370 ),
				Tag = (int)data.weight_now,
				Name = "weight",
			});


			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.stamina.距離適性( zyuunan ),
				Tag =  abl_data.stamina.距離適性上限( zyuunan ),
				Name = "kyoritekisei",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.kodashi.ToString(),
				Tag = (int)abl_data.kodashi,
				Name = "kodashi",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.keiro.毛色(),
				Tag = (int)abl_data.keiro,
				Name = "keiro",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.taikou.体高(),
				Tag = (int)abl_data.taikou,
				Name = "taikou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.zenchou.全長(),
				Tag = (int)abl_data.zenchou,
				Name = "zenchou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.souhou.走法().Substring( 0, 1 ),
				Tag = (int)data.souhou,
				Name = "souhou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.komawari_X.苦手(),
				Tag = (int)abl_data.komawari_X,
				Name = "komawari_X",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.hidarimawari_X.苦手(),
				Tag = (int)data.hidarimawari_X,
				Name = "hidarimawari_X",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.migimawari_X.苦手(),
				Tag = (int)data.migimawari_X,
				Name = "migimawari_X",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_1.持病(),
				Tag = (int)data.weak_point_1,
				Name = "weak_point_1",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_2.持病(),
				Tag = (int)data.weak_point_2,
				Name = "weak_point_2",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.weak_point_3.持病(),
				Tag = (int)data.weak_point_3,
				Name = "weak_point_3",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.特性(" "),
				Tag = abl_data.特性二進数(),
				Name = "tokusei",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = father_name,
				Tag = father_name,
				Name = "father_name",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = father_family_line_data.系統名() + "系",
				Tag = father_family_line_data.系統名() + "系",
				Name = "father_family_line_",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = mother_name,
				Tag = mother_name,
				Name = "mother_name",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = career.ToString(),
				Tag = (int) career,
				Name = "race_len",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0,2} - {1,2} - {2,2} - {3,2}",
					data.career_dirt_1 + data.career_shiba_1,
					data.career_dirt_2 + data.career_shiba_2,
					data.career_dirt_3 + data.career_shiba_3,
					data.career_dirt_4 + data.career_shiba_4
				),
				Tag = String.Format( "{0:D2}{1:D2}{2:D2}{3:D2}",
					data.career_dirt_1 + data.career_shiba_1,
					data.career_dirt_2 + data.career_shiba_2,
					data.career_dirt_3 + data.career_shiba_3,
					data.career_dirt_4 + data.career_shiba_4
				),
				Name = "race_win_len",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = zisou_race_name,
				Tag = zisou_sort_string,
				Name = "zisou",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.klass.クラス(),
				Tag = (int) data.klass,
				Name = "klass",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.earning_all ) ),
				Tag = (int) data.earning_all,
				Name = "earning_all",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.earning_hon ) ),
				Tag = (int) data.earning_hon,
				Name = "earning_hon",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.seisankoku.生産国(),
				Tag = (int) abl_data.seisankoku,
				Name = "seisankoku",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.owner.ToString(),
				Tag = (int) data.owner,
				Name = "owner",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = abl_data.bokuzyou.ToString(),
				Tag = (int) abl_data.bokuzyou,
				Name = "bokuzyou",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.trainer.ToString(),
				Tag = (int) data.trainer,
				Name = "trainer",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.shusen_jk_num.ToString(),
				Tag = (int) data.shusen_jk_num,
				Name = "shusen_jk_num",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = data.intai == 0 ? "○" : "×",
				Tag = data.intai == 0  ? 0 : 1,
				Name = "is_intai",
			});

			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = is_shizitsu ? "○" : "",
				Tag = is_shizitsu  ? 1 : 0,
				Name = "is_shizitsu",
			});
			
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", data.shizitsu_num ),
				Tag = (int)data.shizitsu_num,
				Name = "shizitsu_num",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", data.abl_num ),
				Tag = (int)data.abl_num,
				Name = "abl_num",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = String.Format( "0x{0:X4}", horse_num ),
				Tag = (int)horse_num,
				Name = "horse_num",
			});
			__subitems_stack__[n++] = (new ListViewItem.ListViewSubItem() {
				Text = name,
				Tag = name,
				Name = "name2",
			});

			item.SubItems.AddRange( __subitems_stack__ );


			return item;
		}

		private Boolean IsViewRecord( WP7 wp, UInt32 horse_num, ref HRaceData data )
		{
			if( this.ListViewConfig.WatchHorse ) {
				return data.kansen == 1;
			}

			switch( data.age )
			{
			case 0:
				if( !this.ListViewConfig.Age_2 )
					return false;
				break;
			case 1:
				if( !this.ListViewConfig.Age_3 )
					return false;
				break;
			default:
				if( !this.ListViewConfig.Age_ETC )
					return false;
				break;
			}

			switch( horse_num <= 0xb3f ? Enums.CountryType.JAPAN : horse_num <= 0xe4b ? Enums.CountryType.USA : Enums.CountryType.EURO )
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

			switch( data.intai )
			{
			case 0:
				if( !this.ListViewConfig.Status_Geneki ) {
					return false;
				}
				break;
			default:
				if( !this.ListViewConfig.Status_Intai )
					return false;
				break;
			}

			if( this.ListViewConfig.OwnerHorse || this.ListViewConfig.ClubHorse || this.ListViewConfig.WatchHorse ) {
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
			return true;
		}

		protected override ListViewItem[] CreateHorseListSub( KOEI.WP7_2012.WP7 wp, object arg )
		{
			this.__subitems_stack__ = new ListViewItem.ListViewSubItem[ DefaultColumnHeaders.Length ];

			var data = new KOEI.WP7_2012.Datastruct.HRaceData();

			this.white_color_horse_ = 0;

			if( this.ListViewConfig.CurrentHorse ) {
				var n = wp.GetCurrentCharacterNumber();
				wp.HRaceTable.GetData( n, ref data );
				var item = CreateListViewItemByHorseNum( wp, n, ref data );
				if( item == null ) {
					return new ListViewItem[0];
				}
				return new ListViewItem[1] {
					item,
				};
			}
			var items = new ListViewItem[ wp.Config.HorseRaceTable.RecordMaxLength ];
			var count = 0;

			for( var i=0; i<wp.Config.HorseRaceTable.RecordMaxLength; ++i ) {
				var horse_num = (uint)i;

				wp.HRaceTable.GetData( horse_num, ref data );

				if( !this.IsViewRecord( wp, horse_num, ref data ) ) {
					continue;
				}
				var item = CreateListViewItemByHorseNum( wp, horse_num, ref data );

				if( item != null ) {
					items[ count++ ] = item;
				}
			}
			Array.Resize( ref items, count );

			return items;
		}
	}
}
