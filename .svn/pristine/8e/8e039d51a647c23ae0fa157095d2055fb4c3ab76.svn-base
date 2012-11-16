using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;
using KOEI.WP7_2012.Horse.Breeding;

namespace WP7_2012ULV.Breeding
{
	public class BreedingToDamListView : UMAListView.UMAListViewTpl
	{
		private ListViewItem.ListViewSubItem[] __subitems_stack__;

		private int white_color_horse_ = 0;

		/// <summary>
		/// カラムリスト
		/// </summary>
		private ColumnHeader[] DefaultColumnHeaders = new ColumnHeader[]
		{
			new ColumnHeader() { Text = "馬名",         Name = "name",              Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "国",           Name = "country",           Width =  30, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "年",           Name = "age",               Width =  30, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "子出",         Name = "kodashi",           Width =  40, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },

			new ColumnHeader() { Text = "爆発",         Name = "point",             Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "危険",         Name = "risk",              Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ﾆｯｸｽ",         Name = "ニックス",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ｲﾝﾌﾞﾘｰﾄﾞ",     Name = "インブリ",          Width =  90, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ﾗｲﾝﾌﾞﾘｰﾄﾞ",    Name = "ライブリ",          Width =  90, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },

			new ColumnHeader() { Text = "母父効果",     Name = "母父効果",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ﾗｲﾝ活性",      Name = "ライ活性",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "血脈活性",     Name = "血脈活性",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "大種馬",       Name = "大種馬",            Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "名種馬",       Name = "名種馬",            Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "隔世遺伝",     Name = "隔世遺伝",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "SP昇華",       Name = "SP昇華",            Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ST昇華",       Name = "ST昇華",            Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "SPST融合",     Name = "SPST融合",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "完全活力",     Name = "完全活力",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "お笑い",       Name = "お笑い",            Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "お似合い",     Name = "お似合い",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "三冠",         Name = "三冠",              Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "ｻﾖﾅﾗ",         Name = "サヨナラ",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "稲妻",         Name = "稲妻",              Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "疾風",         Name = "疾風",              Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },

			new ColumnHeader() { Text = "名種活力",     Name = "名種活力",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "名牝活力",     Name = "名牝活力",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "異系活力",     Name = "異系活力",          Width =  70, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },

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
			new ColumnHeader() { Text = "札",           Name = "fuda_color",        Width =  35, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "評価額",       Name = "price",             Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "繁年",         Name = "career_years",      Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "繁頭",         Name = "career_count",      Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "戦",           Name = "record_len",        Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "勝",           Name = "record_win",        Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "G1",           Name = "g1_win_count",      Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "勝鞍",         Name = "kachikura",         Width =  45, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "父馬",         Name = "father",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "父系",         Name = "family_line",       Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "母馬",         Name = "mother",            Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "生産国",       Name = "seisankoku",        Width =  80, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "牧場",         Name = "bokuzyou",          Width =  50, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "状態",         Name = "status",            Width =  70, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "種付け種牡馬", Name = "tanetsuke_sire",    Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "受胎中史実馬", Name = "zyutai_shizitsu_name", Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "特殊配合",     Name = "special_combo",     Width =  80, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
			new ColumnHeader() { Text = "現役",         Name = "is_intai",          Width =  50, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "史実",         Name = "is_sizitsu",        Width =  50, TextAlign = HorizontalAlignment.Center,    Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "史実番号",     Name = "shizitsu_num",      Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "能力番号",     Name = "abl_num",           Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬番号",       Name = "id",                Width =  80, TextAlign = HorizontalAlignment.Right,     Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_NUMERIC,   },
			new ColumnHeader() { Text = "馬名",         Name = "name2",             Width = 200, TextAlign = HorizontalAlignment.Left,      Tag = WP7_2012ULV.UMAListView.Sorter.ComparerMode.TAG_STRING,    },
		};


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="config"></param>
		/// <param name="extensions"></param>
		/// <param name="extnensions_dir"></param>
		public BreedingToDamListView( UMAListView.Config config, ReadWriteMode mode, WP7_2012ULV.Setting.ExtensionSetting.Command[] extensions, String extnensions_dir )
			: base( config, mode, extensions, extnensions_dir )
		{
			// pass
		}

		/// <summary>
		/// 派生クラスで実装するメソッド
		/// C#の拡張機能を実行する
		/// </summary>
		/// <param name="method">呼び出す拡張機能のメソッド</param>
		protected override void ExecCSharpExtension( System.Reflection.MethodInfo method, WP7_2012ULV.Setting.ExtensionSetting.Manifest manifest )
		{
			// pass
		}

		/// <summary>
		/// 派生クラスで実装するメソッド
		/// リストビューのカラムをセットアップする
		/// </summary>
		protected override void ListView1_ColumnSetup()
		{
			this.ListView1.Columns.AddRange( DefaultColumnHeaders );
		}

		/// <summary>
		/// スポイラーALライクな編集を行う
		/// </summary>
		/// <param name="item_index">対象のリストビューのアイテムインデックス</param>
		protected override void SpoilerLikeItemEdit( int item_index )
		{
			// pass
		}

		/// <summary>
		/// 拡張機能のメイン関数が要求する引数のタイプ
		/// </summary>
		protected override Type[] ExtensionArgTypes {
			get {
				return new Type[0];	
			}
		}

		/// <summary>
		/// 白毛の数
		/// </summary>
		public override int WhiteColorHorseCount {
			get {
				return 0;
			}
		}

		private String GetDispName( WP7 wp, out String father_name, out String mother_name, ref HBloodData blood_data, ref HAblData abl_data, ref HBloodData father_blood_data, ref HBloodData mother_blood_data )
		{
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
		
		private ListViewItem CreateListViewItemByHorseNum( 
			KOEI.WP7_2012.WP7 wp,
			UInt32 horse_num,
			ref KOEI.WP7_2012.Datastruct.HDamData data,
			KOEI.WP7_2012.Horse.Breeding.Breeding breeding )
		{
			var blood_data = new HBloodData();
			var family_line_data = new HFamilyLineData();
			var abl_data = new HAblData();
			var father_blood_data = new HBloodData();
			var mother_blood_data = new HBloodData();
			var sire_data = new HSireData();
			var tanetsuke_blood_data = new HBloodData();

			wp.HAblTable.GetData( data.abl_num, ref abl_data );
			wp.HBloodTable.GetData( data.blood_num, ref blood_data );
			wp.HFamilyLineTable.GetData( blood_data.family_line_num, ref family_line_data );
			wp.HBloodTable.GetData( blood_data.father_num, ref father_blood_data );
			wp.HBloodTable.GetData( blood_data.mother_num, ref mother_blood_data );

			var age_value = data.age + 2;
			var is_intai = data.intai != 0 ? true : false;

			var item = new ListViewItem();

			var is_shizitsu = data.shizitsu_num != wp.Config.NullShizitsuNumber;

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

			var tanetsuke_sire_name = "";

			if( data.tanetsuke_sire != wp.Config.NullSireNumber ) {
				wp.HSireTable.GetData( data.tanetsuke_sire, ref sire_data );
				wp.HBloodTable.GetData( sire_data.blood_num, ref tanetsuke_blood_data );
				
				if( this.ListViewConfig.DispNameType == WP7_2012ULV.Enums.NameType.KANA || tanetsuke_blood_data.display == 0 ) {
					tanetsuke_sire_name = wp.馬名( WP7_2012ULV.Enums.NameType.KANA, tanetsuke_blood_data.name_left, tanetsuke_blood_data.name_right );
				} else {
					tanetsuke_sire_name = wp.馬名( WP7_2012ULV.Enums.NameType.ENGLISH, tanetsuke_blood_data.name_left, tanetsuke_blood_data.name_right );
				}

			}

			var preg_shizitsu_name = "";

			if( data.preg_shizitsu_num != wp.Config.NullShizitsuNumber ) {
				var blood_num = (UInt32) BitConverter.ToUInt16( wp.HShizitsuNameTable[ data.preg_shizitsu_num ], 0 );
				var temp_blood_data = new KOEI.WP7_2012.Datastruct.HBloodData();
				wp.HBloodTable.GetData( blood_num, ref temp_blood_data );

				if( this.ListViewConfig.DispNameType == WP7_2012ULV.Enums.NameType.KANA || tanetsuke_blood_data.display == 0 ) {
					preg_shizitsu_name = wp.馬名( WP7_2012ULV.Enums.NameType.KANA, temp_blood_data.name_left, temp_blood_data.name_right );
				} else {
					preg_shizitsu_name = wp.馬名( WP7_2012ULV.Enums.NameType.ENGLISH, temp_blood_data.name_left, temp_blood_data.name_right );
				}
			}

			if( abl_data.keiro == 9 ) {
				++this.white_color_horse_;
			}
			var combination = breeding.Combination;
			var combinationPoint = breeding.Combination.GetPoint( wp );

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
				Text = abl_data.kodashi.ToString(),
				Tag = (int)abl_data.kodashi,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = combinationPoint.Point.ToString(),
				Tag = (int)combinationPoint.Point,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = combinationPoint.Risk.ToString(),
				Tag = (int)combinationPoint.Risk,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "+{0}", combinationPoint.ニックス.Point ),
				Tag = (int) combinationPoint.ニックス.Point,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "+{0,2},{1,3}", combinationPoint.インブリード.Point, 0 - (int)combinationPoint.インブリード.Risk ),
				Tag = (int) combinationPoint.インブリード.Point,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "+{0},{1,2}", combinationPoint.ラインブリード.Point, 0 - (int)combinationPoint.ラインブリード.Risk ),
				Tag = (int) combinationPoint.ラインブリード.Point,
			});

			foreach( var objs in new object [][] {
				new object[] { combinationPoint.母父効果 },
				new object[] { combinationPoint.ライン活性配合, },
				new object[] { combinationPoint.血脈活性化配合, },
				new object[] { combinationPoint.活力源化大種牡馬因子, },
				new object[] { combinationPoint.活力源化名種牡馬因子, },
				new object[] { combinationPoint.隔世遺伝, },
				new object[] { combinationPoint.SP昇華配合, },
				new object[] { combinationPoint.ST昇華配合, },
				new object[] { combinationPoint.SPST融合配合, },
				new object[] { combinationPoint.完全型活力補完, },
				new object[] { combinationPoint.お笑い配合, },
				new object[] { combinationPoint.お似合い配合, },
				new object[] { combinationPoint.三冠配合 },
				new object[] { combination.サヨナラ配合 ? combinationPoint.サヨナラ配合 : combinationPoint.Wサヨナラ配合, },
				new object[] { combination.稲妻配合 ? combinationPoint.稲妻配合 : combinationPoint.真稲妻配合, },
				new object[] { combination.疾風配合 ? combinationPoint.疾風配合 : combinationPoint.真疾風配合, },
			}) {
				var p = (PointRiskPair) objs[0];
				var msg = "";

				msg = String.Format( "+{0}", p.Point );

				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = msg,
					Tag = (int) p.Point,
				});
			}

			foreach( var objs in new object [][] {
				new object[] { combination.名種牡馬型活力補完 },
				new object[] { combination.名牝型活力補完 },
				new object[] { combination.異系血脈型活力補完 },
			}) {
				var p = (uint) objs[0];
				var msg = "";

				msg = String.Format( "{0}本", p );

				__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
					Text = msg,
					Tag = (int) p,
				});
			}

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
				Text = data.fuda_color.お札(),
				Tag = (int)data.fuda_color,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = String.Format( "{0:N0}", ( data.price * 100 ) ),
				Tag = (int) data.price,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.career_years.ToString(),
				Tag = (int)data.career_years,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.career_count.ToString(),
				Tag = (int)data.career_count,
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
				Text = data.g1_win_count.ToString(),
				Tag = (int)data.g1_win_count,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = data.kachikura.ToString(),
				Tag = (int)data.kachikura,
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
				Text = data.status.繁殖牝馬状態(),
				Tag = (int) data.status,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = tanetsuke_sire_name,
				Tag = tanetsuke_sire_name,
			});

			__subitems_stack__[n++] = ( new ListViewItem.ListViewSubItem() {
				Text = preg_shizitsu_name,
				Tag = preg_shizitsu_name,
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
	
		private Boolean IsViewRecord( WP7 wp, UInt32 horse_num, ref HDamData data, ref HAblData abl_data )
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
	
		/// <summary>
		/// 表示する馬リストを作成する
		/// </summary>
		/// <param name="wp"></param>
		/// <param name="arg">配合する種牡馬の番号</param>
		/// <returns></returns>
		protected override ListViewItem[] CreateHorseListSub( KOEI.WP7_2012.WP7 wp, object arg )
		{
			this.__subitems_stack__ = new ListViewItem.ListViewSubItem[ DefaultColumnHeaders.Length ];

			var sire_num = (uint)arg;
			var sire_pedigree = new KOEI.WP7_2012.Horse.Pedigree( wp, sire_num, KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.父系 );

			var family_line_info = KOEI.WP7_2012.Horse.FamilyLineInfo.CreateFamilyLineInfoList( wp, this.ListViewConfig.BreedingArea );

			var dam_data = new HDamData();
			var dam_blood_data = new HBloodData();
			var dam_abl_data = new HAblData();

			var items = new List< ListViewItem >();

			this.white_color_horse_ = 0;

			for( var i=0; i<wp.Config.HorseDamTable.RecordMaxLength; ++i )
			{
				var horse_num = i;

				wp.HDamTable.GetData( (uint)horse_num, ref dam_data );
				wp.HAblTable.GetData( dam_data.abl_num, ref dam_abl_data );

				if( !this.IsViewRecord( wp, (uint)horse_num, ref dam_data, ref dam_abl_data ) ) {
					continue;
				}

				wp.HBloodTable.GetData( dam_data.blood_num, ref dam_blood_data );

				if( dam_blood_data.father_num == wp.Config.IgnoreBloodNumber ) {
					continue;
				}
				var dam_pedigree = new KOEI.WP7_2012.Horse.Pedigree( wp, (uint)horse_num, KOEI.WP7_2012.Horse.Breeding.Enums.血統タイプ.母系 ); 

				var breeding = new KOEI.WP7_2012.Horse.Breeding.Breeding(
					wp, family_line_info, this.ListViewConfig.BreedingArea, sire_pedigree, dam_pedigree );

				if( this.ListViewConfig.MaxRisk < breeding.Combination.GetPoint(wp).Risk ) {
					continue;
				}

				items.Add( this.CreateListViewItemByHorseNum( wp, (uint)horse_num, ref dam_data, breeding ) );
			}

			return items.ToArray();
		}
	}
}
