using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KOEI.WP7_2012.Horse;
using KOEI.WP7_2012.Datastruct;

namespace KOEI.WP7_2012.Horse
{
	/// <summary>
	/// 系統状態の管理クラス
	/// </summary>
	public class FamilyLineInfo
	{
		/// <summary>
		/// 対象地域
		/// </summary>
		public Horse.Area Coutry { get; private set; }

		/// <summary>
		/// 系統番号
		/// </summary>
		public UInt32 FamilyLineNum       { get; private set; }

		/// <summary>
		/// 大元の親系統番号
		/// </summary>
		public UInt32 ParentFamilyLuneNum { get; private set; }

		/// <summary>
		/// 系統データ
		/// </summary>
		public HFamilyLineData Data       { get; private set; }

		/// <summary>
		/// 種牡馬数
		/// </summary>
		public UInt32 SireCount           { get; set; }

		/// <summary>
		/// 地域での種牡馬の割合
		/// </summary>
		public Double SirePercent         { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="country">地域</param>
		/// <param name="family_line_num">系統番号</param>
		/// <param name="parent_family_line_num">大元の親系統番号</param>
		/// <param name="data">系統データ</param>
		public FamilyLineInfo( Horse.Area country, UInt32 family_line_num, UInt32 parent_family_line_num, ref HFamilyLineData data )
		{
			this.Coutry = country;
			this.FamilyLineNum = family_line_num;
			this.ParentFamilyLuneNum = parent_family_line_num;
			this.Data = data;
		}

		/// <summary>
		/// 流行血統かどうかを返す
		/// </summary>
		/// <returns>流行血統なら真</returns>
		public Boolean 流行血統か()
		{
			if( this.SirePercent >= 10.0 ) {
				return true;
			}
			switch( this.Coutry ) {
			case Horse.Area.日本:
				return this.Data.share_J >= 100;
			case Horse.Area.米国:
				return this.Data.share_U >= 100;
			case Horse.Area.欧州:
				return this.Data.share_E >= 100;
			default:
				throw new Exception("[BUG or データ破損]");
			}
		}

		/// <summary>
		/// 零細血統かどうかを返す
		/// </summary>
		/// <returns>零細血統なら真</returns>
		public Boolean 零細血統か()
		{
			if( this.SireCount < 2 ) {
				return true;
			}
			if( this.SirePercent <= 1.0 ) {
				return true;
			}
			switch( this.Coutry ) {
			case Horse.Area.日本:
				return this.Data.share_J <= 10;
			case Horse.Area.米国:
				return this.Data.share_U <= 10;
			case Horse.Area.欧州:
				return this.Data.share_E <= 10;
			default:
				throw new Exception("[BUG or データ破損]");
			}
		}

		/// <summary>
		/// 牧場番号から国を取得する
		/// </summary>
		/// <param name="bokuzyou_num">牧場番号</param>
		/// <returns>地域</returns>
		private static Horse.Area 牧場はどこの地域か( UInt32 bokuzyou_num )
		{
			if( bokuzyou_num < 214 && bokuzyou_num != 27 && bokuzyou_num != 28 ) {
				return Horse.Area.日本;
			} else if( bokuzyou_num < 233 && bokuzyou_num != 28 ) {
				return Horse.Area.米国;
			}
			return Horse.Area.欧州;
		}
		
		/// <summary>
		/// 地域の系統状態のリストを作成して返す
		/// </summary>
		/// <returns>系統状態のリスト</returns>
		public static FamilyLineInfo[] CreateFamilyLineInfoList( WP7 wp, Horse.Area country )
		{
			var info_list = new FamilyLineInfo[ wp.HFamilyLineTable.RecordCount ];

			for( var i=0; i<wp.HFamilyLineTable.RecordCount; ++i ) {
				var family_line_num = (uint)i;
				var family_line_data = new HFamilyLineData();
				wp.HFamilyLineTable.GetData( family_line_num, ref family_line_data );

				// 大元の親系統番号を取得する
				var parent_family_line_num = family_line_num;
				var parent_data = family_line_data;

				if( parent_data.family_line_num != wp.Config.NullFamilyLineNumber ) {
					while( true ) {
						if( parent_data.family_line_num == parent_family_line_num ) {
							break;
						}
						parent_family_line_num = parent_data.family_line_num;
						
						if( parent_family_line_num == wp.Config.NullFamilyLineNumber ) {
							throw new Exception("[BUGもしくはデータが壊れています]");
						}
						wp.HFamilyLineTable.GetData( parent_family_line_num, ref parent_data );
					}
				}
				info_list[ family_line_num ] = new FamilyLineInfo( country, family_line_num, parent_family_line_num, ref family_line_data );
			}

			var sire_total_length = 0;

			for( var i=0; i<wp.HSireTable.RecordCount; ++i ) {
				var sire_num = (uint)i;
				var data = new HSireData();
				var abl = new HAblData();
				var blood = new HBloodData();

				wp.HSireTable.GetData( sire_num, ref data );

				if( data.intai != 0 ) {
					continue;
				}

				wp.HAblTable.GetData( data.abl_num, ref abl );

				if( 牧場はどこの地域か( abl.bokuzyou ) != country ) {
					continue;
				}

				wp.HBloodTable.GetData( data.blood_num, ref blood );

				if( blood.father_num == wp.Config.IgnoreBloodNumber ) {
					continue;
				}
				sire_total_length++;
				info_list[ blood.family_line_num ].SireCount++;
			}

			foreach( var info in info_list ) {
				info.SirePercent = (Double)info.SireCount / (Double)sire_total_length * 100.0;
			}
			return info_list;
		}
	}
}
