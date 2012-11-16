using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using KOEI.WP7_2012;
using KOEI.WP7_2012.Datastruct;

namespace KOEI.WP7_2012.Horse.Breeding
{
	/// <summary>
	/// 配合クラス
	/// </summary>
	public class Breeding
	{
		/// <summary>
		/// ３冠配合が成立するレースID
		/// </summary>
		public static readonly UInt32[] SANKAN_RACE_ID_LIST = new UInt32[] {
			2207, // ３冠
			2208, // 牝馬３冠
			2209, // 米国３冠
			2210, // 欧州３冠
			2365, // トリプルティアラ
			2366, // 欧州オークス３冠
			2367, // 仏国牝馬３冠
			2373, // 秋古馬３冠
			2420, // 英国３冠
			2421, // 英国牝馬３冠
			2422, // 仏国３冠
			2423, // 愛国３冠
			2424, // 欧州牡馬マイル３冠
			2425, // 欧州牝馬マイル３冠
			2496, // 南関東３冠
		};

		private WP7 wp;
		private FamilyLineInfo[] family_line_info;

		/// <summary>
		/// 配合地域
		/// </summary>
		public Horse.Area  TargetCountry { get; private set; }

		/// <summary>
		/// 種牡馬血統
		/// </summary>
		public Pedigree    SirePedigree  { get; private set; }

		/// <summary>
		/// 繁殖牝馬血統
		/// </summary>
		public Pedigree    DamPedigree   { get; private set; }

		/// <summary>
		/// 配合結果
		/// </summary>
		public Combination.Combination Combination { get; private set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="wp">WP7</param>
		/// <param name="family_line_info">系統状態のリスト</param>
		/// <param name="target_country">配合地域</param>
		/// <param name="sire_pedigree">種牡馬の血統</param>
		/// <param name="dam_pedigree">繁殖牝馬の血統</param>
		public Breeding( WP7 wp, FamilyLineInfo[] family_line_info, Horse.Area target_country, Pedigree sire_pedigree, Pedigree dam_pedigree )
		{
			if( sire_pedigree.Type != Enums.血統タイプ.父系 ) {
				throw new ArgumentException("種牡馬の血統に繁殖牝馬の血統が与えられました");
			}
			if( dam_pedigree.Type != Enums.血統タイプ.母系 ) {
				throw new ArgumentException("繁殖牝馬の血統に種牡馬の血統が与えられました");
			}
			this.wp = wp;
			this.family_line_info = family_line_info;
			this.TargetCountry = target_country;
			this.SirePedigree = sire_pedigree;
			this.DamPedigree = dam_pedigree;
			this.DoCombination();
		}

		/// <summary>
		/// 配合する
		/// </summary>
		private void DoCombination()
		{
			this.Combination = new Combination.Combination();

			this.ラインブリードのチェック();
			this.インブリードのチェック();
			this.ニックスのチェック();
			this.血脈活性化配合のチェック();
			this.昇華配合のチェック( 1, ref this.Combination.SP昇華配合 );
			this.昇華配合のチェック( 2, ref this.Combination.ST昇華配合 );
			this.SPST融合配合のチェック();
			this.母父効果のチェック();
			this.活力補完のチェック();

			this.隔世遺伝のチェック();
			this.ライン活性配合のチェック();
			this.活力源化種牡馬因子のチェック();
			this.特殊配合のチェック();
		}
		
		/// <summary>
		/// ラインブリードのチェックをする
		/// 
		/// --------------------------------------------------
		/// |        |             |    (あ)    | 父父父父   |
		/// |        |             |   父父父   +------------|
		/// |        |             |            | 父父父母   |
		/// |        |    父父     +------------+------------|
		/// |        |             |            | 父父母父   |
		/// |        |             |   父父母   +------------|
		/// |        |             |            | 父父母母   |
		/// | 父     |-------------+------------+------------|
		/// |        |             |    (い)    | 父母父父   |
		/// |        |             |   父母父   +------------|
		/// |        |             |            | 父母父母   |
		/// |        |    父母     +------------+------------|
		/// |        |             |            | 父母母父   |
		/// |        |             |   父母母   +------------|
		/// |        |             |            | 父母母母   |
		/// |--------+-------------+------------+------------|
		/// |        |             |    (う)    | 母父父父   |
		/// |        |             |   母父父   +------------|
		/// |        |             |            | 母父父母   |
		/// |        |    母父     +------------+------------|
		/// |        |             |            | 母父母父   |
		/// |        |             |   母父母   +------------|
		/// |        |             |            | 母父母母   |
		/// | 母     +-------------+------------+------------|
		/// |        |             |    (え)    | 母母父父   |
		/// |        |             |   母母父   +------------|
		/// |        |             |            | 母母父母   |
		/// |        |    母母     +------------+------------|
		/// |        |             |            | 母母母父   |
		/// |        |             |   母母母   +------------|
		/// |        |             |            | 母母母母   |
		/// --------------------------------------------------
		/// 
		/// 親系統ラインブリード4本爆発型(危険度1)
		/// 	3代目先祖の種牡馬4頭（あ・い・う・え）の親系統が全て同じで、
		/// 	子系統がすべて違う場合に成立します。
		/// 	父の特性がSPの場合は「親系統ラインブリード4本爆発SP型」になります。
		/// 	3代前の他の先祖馬がそれぞれ異なった親系統でないと、気性難や体質の弱化が起こる可能性 が高くなります。
		/// 
		/// 親系統ラインブリード3本爆発型(危険度1)
		/// 	3代目先祖の種牡馬4頭（あ・い・う・え）の うち、3頭の親系統が全て同じで、
		/// 	子系統がすべて違う場合に成立します。
		/// 	父の特性がSPの場合は「親系統ラインブリード3本爆発SP型」になります。
		/// 	3代前の他の先祖馬がそれぞれ異なった親系統でないと、気性難や体質の弱化が起こる可能性 が高くなります。
		/// 
		/// 親系統ラインブリード(危険度1)
		/// 	父母ともに、同じ親系統の場合成立します。
		/// 	父の特性がSPの場合は「親系統ラインブリードSP型」になります。3代前の祖先8頭のうち、
		/// 	親系統の種類が5より多いい場合は危険度が下がります。
		/// 
		/// 子系統ラインブリード(危険度2)
		/// 	父母ともに、同じ子系統の場合成立します。
		/// 	父の特性がSPの場合は「子系統ラインブリードSP型 」になります。
		/// 	3代前の祖先8頭のうち、親系統の種類が5より多いい場合は危険度が下がります。
		/// 
		///		×父の特性がSPの場合は「子系統ラインブリードSP型 」になります。
		///		○父と母の特性がSP型の場合は「子系統ラインブリードSP型 」になります。
		/// </summary>
		private void ラインブリードのチェック()
		{
			var target_blood_list = new List< Pedigree.Node >();

			// ラインブリード対象になる血統を取得
			foreach( var pedigree in new []{ this.SirePedigree, this.DamPedigree } ) {
				foreach( var node in pedigree.NodeList(2) ) {
					if( node.Type == Enums.血統タイプ.父系 ) {
						target_blood_list.Add( node );
					}
				}
			}
			Debug.Assert( target_blood_list.Count == 4 );

			HBloodData
				blood1 = new HBloodData(),
				blood2 = new HBloodData(),
				blood3 = new HBloodData(),
				blood4 = new HBloodData();

			this.wp.HBloodTable.GetData( target_blood_list[0].BloodNum, ref blood1 );
			this.wp.HBloodTable.GetData( target_blood_list[1].BloodNum, ref blood2 );
			this.wp.HBloodTable.GetData( target_blood_list[2].BloodNum, ref blood3 );
			this.wp.HBloodTable.GetData( target_blood_list[3].BloodNum, ref blood4 );
			
			FamilyLineInfo
				child_line1  = this.family_line_info[ blood1.family_line_num ],
				child_line2  = this.family_line_info[ blood2.family_line_num ],
				child_line3  = this.family_line_info[ blood3.family_line_num ],
				child_line4  = this.family_line_info[ blood4.family_line_num ];

			// 出現率の1番多い親系統の数を数える
			var parent_line_match_count = 1;
			var info_ary = new []{ child_line1, child_line2, child_line3, child_line4, };

			for( var i=0; i<info_ary.Length; ++i ) {
				var temp = 1;
				for( var j=0; j<info_ary.Length; ++j ) {
					if( i != j && info_ary[i].ParentFamilyLuneNum == info_ary[j].ParentFamilyLuneNum ) {
						temp++;
					}
				}
				if( temp > parent_line_match_count ) {
					parent_line_match_count = temp;
				}
			}

			// 親系統ラインブリード爆発型のチェック
			if( parent_line_match_count >= 3 ) {
				// 子系統の種類を数える
				var child_num_ary = new UInt32[]{ 
					blood1.family_line_num,
					blood2.family_line_num,
					blood3.family_line_num,
					blood4.family_line_num,
				};
				// 重複カット
				child_num_ary = child_num_ary.Distinct().ToArray();

				if( parent_line_match_count == 4 && child_num_ary.Length == 4 ) {
					if( child_line1.Data.family_line_attr == 1 ) {
						this.Combination.ラインブリード = Enums.ラインブリード.親系統4本爆発SP型;
					} else {
						this.Combination.ラインブリード = Enums.ラインブリード.親系統4本爆発型;
					}
					return;
				}
				if( parent_line_match_count == 3 && child_num_ary.Length == 4 ) {
					if( child_line1.Data.family_line_attr == 1 ) {
						this.Combination.ラインブリード = Enums.ラインブリード.親系統3本爆発SP型;
					} else {
						this.Combination.ラインブリード = Enums.ラインブリード.親系統3本爆発型;
					}
					return;
				}
			}

			var father_family_line = this.family_line_info[ this.SirePedigree.Tree.Data.family_line_num ];
			var mother_family_line = this.family_line_info[ this.DamPedigree.Tree.Data.family_line_num ];

			// 子系統ラインブリードのチェック
			if( this.SirePedigree.Tree.Data.family_line_num == this.DamPedigree.Tree.Data.family_line_num ) {
				if( father_family_line.Data.family_line_attr == 1 ) {
					this.Combination.ラインブリード = Enums.ラインブリード.子系統SP型;
				} else {
					this.Combination.ラインブリード = Enums.ラインブリード.子系統;
				}
				return;
			}

			// 親系統ラインブリードのチェック
			// 資料とは少し違う
			if( father_family_line.ParentFamilyLuneNum == mother_family_line.ParentFamilyLuneNum ) {
				if( father_family_line.Data.family_line_attr == 1 && mother_family_line.Data.family_line_attr == 1 ) {
					this.Combination.ラインブリード = Enums.ラインブリード.親系統SP型;
				} else {
					this.Combination.ラインブリード = Enums.ラインブリード.親系統;
				}
				return;
			}
		}
	
		/// <summary>
		/// インブリードのチェックをする
		/// </summary>
		private void インブリードのチェック()
		{
			var inbreed_list = new List< Combination.Inbreed >();

			foreach( var sire_node in this.SirePedigree.NodeList() ) {
				var query = from q in this.DamPedigree.NodeList()
							where q.BloodNum == sire_node.BloodNum
							select q;

				var node_list = this.DamPedigree.NodeList();

				foreach( var mare_node in query ) {
					inbreed_list.Add( new Combination.Inbreed( sire_node, mare_node ) );
				}
			}
			
			inbreed_list = new List< Combination.Inbreed >(
				(from q in inbreed_list
				 group q by q.BloodNum into qq
				 select qq.First()).ToArray()
			);

			this.Combination.インブリード = inbreed_list.ToArray();
		}

		/// <summary>
		/// ニックスのチェックをする
		/// 
		/// ---------------------------------------------------
		/// |        |             |            | 父父父父    |
		/// |        |             |   父父父   +-------------|
		/// |        |             |            | 父父父母    |
		/// |        |    父父     +------------+-------------|
		/// |        |             |            | 父父母父    |
		/// |        |             |   父父母   +-------------|
		/// |  (あ)  |             |            | 父父母母    |
		/// | 父     |-------------+------------+-------------|
		/// |        |             |            | 父母父父    |
		/// |        |             |   父母父   +-------------|
		/// |        |             |            | 父母父母    |
		/// |        |    父母     +------------+-------------|
		/// |        |             |            | 父母母父    |
		/// |        |             |   父母母   +-------------|
		/// |        |             |            | 父母母母    |
		/// |--------+-------------+------------+-------------|
		/// |        |             |            | 母父父父    |
		/// |        |             |   母父父   +-------------|
		/// |        |     (い)    |            | 母父父母    |
		/// |        |    母父     +------------+-------------|
		/// |        |             |            | 母父母父    |
		/// |        |             |   母父母   +-------------|
		/// |        |             |            | 母父母母    |
		/// | 母     +-------------+------------+-------------|
		/// |        |             |     (う)   | 母母父父    |
		/// |        |             |   母母父   +-------------|
		/// |        |             |            | 母母父母    |
		/// |        |    母母     +------------+-------------|
		/// |        |             |            | 母母母父(え)|
		/// |        |             |   母母母   +-------------|
		/// |        |             |            | 母母母母(お)|
		/// ---------------------------------------------------
		/// 
		/// 父と母父の子系統がニックス対象の場合成立します。
		/// 
		/// シングルニックス        母父(い)
		/// ダブルニックス          母父(い)／母母父 (う)
		/// トリプルニックス        母父(い)／母母父 (う)／母母母父(え)
		/// フォースニックス        母父(い)／母母父 (う)／母母母父(え)／母母母母(お)
		/// 2次ニックス             母母父 (う)
		/// 3次ニックス             母母母父(え)
		/// 4次ニックス             母母母母(お)
		/// </summary>
		private void ニックスのチェック()
		{
			var family_line_info = this.family_line_info[ this.SirePedigree.Tree.Data.family_line_num ];

			var nicks_array = new [] {
				family_line_info.Data.nicks_1_num,
				family_line_info.Data.nicks_2_num,
				family_line_info.Data.nicks_3_num,
				family_line_info.Data.nicks_4_num,
				family_line_info.Data.nicks_5_num,
				family_line_info.Data.nicks_6_num,
				family_line_info.Data.nicks_7_num,
				family_line_info.Data.nicks_8_num,
				family_line_info.Data.nicks_9_num,
				family_line_info.Data.nicks_10_num,
			};

			var nicks_family_line_nums = (from q in nicks_array
										 where q != this.wp.Config.NullFamilyLineNumber
										 select q).ToArray();

			var target_family_line_nums = (from q in this.DamPedigree.NodeList()
										  where Array.IndexOf( q.Line, Enums.血統タイプ.父系 ) == -1
										  select q.Data.family_line_num).ToArray();
			
			Debug.Assert( target_family_line_nums.Length == 4 );

			var nicks_count = 0;

			foreach( var family_line_num in target_family_line_nums ) {
				if( Array.IndexOf( nicks_family_line_nums, family_line_num ) == -1 ) {
					break;
				}
				nicks_count++;
			}

			var result = new List< Enums.ニックス >();

			if( nicks_count > 0 ) {
				switch( nicks_count ) {
				case 1:
					result.Add( Enums.ニックス.シングルニックス );
					break;
				case 2:
					result.Add( Enums.ニックス.ダブルニックス );
					break;
				case 3:
					result.Add( Enums.ニックス.トリプルニックス );
					break;
				case 4:
					result.Add( Enums.ニックス.フォースニックス );
					break;
				default:
					throw new Exception("[BUG]");
				}
			}
			if( nicks_count == 0 ) {
				if( Array.IndexOf( nicks_family_line_nums, target_family_line_nums[1] ) != -1 ) {
					result.Add( Enums.ニックス.二次ニックス );
				}
			}
			if( nicks_count < 2 ) {
				if( Array.IndexOf( nicks_family_line_nums, target_family_line_nums[2] ) != -1 ) {
					result.Add( Enums.ニックス.三次ニックス );
				}
			}
			if( nicks_count < 3 ) {
				if( Array.IndexOf( nicks_family_line_nums, target_family_line_nums[3] ) != -1 ) {
					result.Add( Enums.ニックス.四次ニックス );
				}
			}
			this.Combination.ニックス = result.ToArray();
		}

		/// <summary>
		/// 血脈活性化配合のチェック
		/// 
		/// ---------------------------------------------------
		/// |        |             |  ※        | 父父父父    |
		/// |        |             |   父父父   +-------------|
		/// |        |             |            | 父父父母    |
		/// |        |    父父     +------------+-------------|
		/// |        |             |  ※        | 父父母父    |
		/// |        |             |   父父母   +-------------|
		/// |        |             |            | 父父母母    |
		/// | 父     |-------------+------------+-------------|
		/// |        |             |  ※        | 父母父父    |
		/// |        |             |   父母父   +-------------|
		/// |        |             |            | 父母父母    |
		/// |        |    父母     +------------+-------------|
		/// |        |             |  ※        | 父母母父    |
		/// |        |             |   父母母   +-------------|
		/// |        |             |            | 父母母母    |
		/// |--------+-------------+------------+-------------|
		/// |        |             |  ※        | 母父父父    |
		/// |        |             |   母父父   +-------------|
		/// |        |             |            | 母父父母    |
		/// |        |    母父     +------------+-------------|
		/// |        |             |  ※        | 母父母父    |
		/// |        |             |   母父母   +-------------|
		/// |        |             |            | 母父母母    |
		/// | 母     +-------------+------------+-------------|
		/// |        |             |  ※        | 母母父父    |
		/// |        |             |   母母父   +-------------|
		/// |        |             |            | 母母父母    |
		/// |        |    母母     +------------+-------------|
		/// |        |             |  ※        | 母母母父    |
		/// |        |             |   母母母   +-------------|
		/// |        |             |            | 母母母母    |
		/// ---------------------------------------------------
		/// 
		/// 3代前の先祖馬の親系統が6種類以上の場合成立する。
		/// 親系統の数に応じて爆発力がアップします。また同時にインブリードを成立させた場合、
		/// インブリードによるデメリットが少なくなります。
		/// (インブリードが3×4より薄い場合)7本型以上の場合はデメリットがなくなります。
		/// </summary>
		private void 血脈活性化配合のチェック()
		{
			var TARGET_LEN = 8;
			var activity_node_list = new Pedigree.Node[TARGET_LEN];
			var counter = 0;

			foreach( var pedigree in new []{ this.SirePedigree, this.DamPedigree } ) {
				foreach( var node in pedigree.NodeList(2) ) {
					activity_node_list[ counter++ ] = node;
				}
			}
			Debug.Assert( counter == TARGET_LEN );

			var parent_family_line_list = new UInt32[TARGET_LEN];

			counter = 0;
			foreach( var node in activity_node_list ) {
				var family_line_info = this.family_line_info[ node.Data.family_line_num ];
				parent_family_line_list[ counter++ ] = family_line_info.ParentFamilyLuneNum;
			}

			var count = parent_family_line_list.Distinct().Count();

			switch( count ) {
			case 6:
				this.Combination.血脈活性化配合 = Enums.血脈活性化配合.六本型;
				break;
			case 7:
				this.Combination.血脈活性化配合 = Enums.血脈活性化配合.七本型;
				break;
			case 8:
				this.Combination.血脈活性化配合 = Enums.血脈活性化配合.八本型;
				break;
			default:
				this.Combination.血脈活性化配合 = Enums.血脈活性化配合.無し;
				break;
			}
		}

		/// <summary>
		/// 昇華配合のチェック
		/// 
		/// ---------------------------------------------------
		/// |        |             |  (き)      | 父父父父    |
		/// |        |             |   父父父   +-------------|
		/// |        |    (う)     |            | 父父父母    |
		/// |        |    父父     +------------+-------------|
		/// |        |             |  (く)      | 父父母父    |
		/// |        |             |   父父母   +-------------|
		/// | (あ)   |             |            | 父父母母    |
		/// | 父     |-------------+------------+-------------|
		/// |        |             |  (け)      | 父母父父    |
		/// |        |             |   父母父   +-------------|
		/// |        |    (え)     |            | 父母父母    |
		/// |        |    父母     +------------+-------------|
		/// |        |             |  (こ)      | 父母母父    |
		/// |        |             |   父母母   +-------------|
		/// |        |             |            | 父母母母    |
		/// |--------+-------------+------------+-------------|
		/// |        |             |  (さ)      | 母父父父    |
		/// |        |             |   母父父   +-------------|
		/// |        |    (お)     |            | 母父父母    |
		/// |        |    母父     +------------+-------------|
		/// |        |             |  (し)      | 母父母父    |
		/// |        |             |   母父母   +-------------|
		/// | (い)   |             |            | 母父母母    |
		/// | 母     +-------------+------------+-------------|
		/// |        |             |  (す)      | 母母父父    |
		/// |        |             |   母母父   +-------------|
		/// |        |    (か)     |            | 母母父母    |
		/// |        |    母母     +------------+-------------|
		/// |        |             |  (せ)      | 母母母父    |
		/// |        |             |   母母母   +-------------|
		/// |        |             |            | 母母母母    |
		/// ---------------------------------------------------
		/// 
		/// 父、母(あ・い)がともに SP|ST 系統の場合に成立します (レベル1)。
		/// 爆発力のアップが期待できます。
		/// 繁殖牝馬は、いずれかの因子を持っていれば、SP系統でなくてもかまいません。
		/// 加えて、2代前のすべての先祖(う・え・お・か)が SP|ST 系統だとより効果が高く(レベル2)
		/// 3代前のすべての先祖(き・ く・け・こ・さ・し・す・せ)が SP|ST 系統だとより効果が高くなります(レベル3)
		/// レベル3の場合は、瞬発力のアップも期待できます。
		/// </summary>
		/// <param name="family_line_attr">系統特性</param>
		/// <param name="resultSet">成立した昇華配合を書き込みます</param>
		private void 昇華配合のチェック( UInt32 family_line_attr, ref Enums.昇華配合 resultSet )
		{
			var s_family_line_info = this.family_line_info[ this.SirePedigree.Tree.Data.family_line_num ];
			var d_family_line_info = this.family_line_info[ this.DamPedigree.Tree.Data.family_line_num ];

			if( s_family_line_info.Data.family_line_attr != family_line_attr ) {
				resultSet = Enums.昇華配合.無し; 
				return;
			}

			if( d_family_line_info.Data.family_line_attr != family_line_attr ) {
				// 繁殖牝馬は、いずれかの因子を持っていれば、SP系統でなくてもかまいません。
				if( this.DamPedigree.Tree.Data.factor_left > 8 && this.DamPedigree.Tree.Data.factor_right > 8 ) {
					resultSet = Enums.昇華配合.無し; 
					return;
				}
			}

			// (う)～(か)までを調べる
			foreach( var pedigree in new []{ this.SirePedigree, this.DamPedigree } ) {
				foreach( var node in pedigree.NodeList(1) ) {
					var family_line_info = this.family_line_info[ node.Data.family_line_num ];
					if( family_line_info.Data.family_line_attr != family_line_attr ) {
						resultSet = Enums.昇華配合.Lv1; 
						return;
					}
				}
			}

			// (き)～(せ)までを調べる
			foreach( var pedigree in new []{ this.SirePedigree, this.DamPedigree } ) {
				foreach( var node in pedigree.NodeList(2) ) {
					var family_line_info = this.family_line_info[ node.Data.family_line_num ];
					if( family_line_info.Data.family_line_attr != family_line_attr ) {
						resultSet = Enums.昇華配合.Lv2; 
						return;
					}
				}
			}
			resultSet = Enums.昇華配合.Lv3; 
		}

		/// <summary>
		/// SPST融合配合のチェック
		/// 
		/// 	---------------------------------------------------
		/// 	|        |             |  (あ)      | 父父父父    |
		/// 	|        |             |   父父父   +-------------|
		/// 	|        |             |            | 父父父母    |
		/// 	|        |    父父     +------------+-------------|
		/// 	|        |             |  (い)      | 父父母父    |
		/// 	|        |             |   父父母   +-------------|
		/// 	|        |             |            | 父父母母    |
		/// 	| 父     |-------------+------------+-------------|
		/// 	|        |             |  (う)      | 父母父父    |
		/// 	|        |             |   父母父   +-------------|
		/// 	|        |             |            | 父母父母    |
		/// 	|        |    父母     +------------+-------------|
		/// 	|        |             |  (え)      | 父母母父    |
		/// 	|        |             |   父母母   +-------------|
		/// 	|        |             |            | 父母母母    |
		/// 	|--------+-------------+------------+-------------|
		/// 	|        |             |  (お)      | 母父父父    |
		/// 	|        |             |   母父父   +-------------|
		/// 	|        |             |            | 母父父母    |
		/// 	|        |    母父     +------------+-------------|
		/// 	|        |             |  (か)      | 母父母父    |
		/// 	|        |             |   母父母   +-------------|
		/// 	|        |             |            | 母父母母    |
		/// 	| 母     +-------------+------------+-------------|
		/// 	|        |             |  (き)      | 母母父父    |
		/// 	|        |             |   母母父   +-------------|
		/// 	|        |             |            | 母母父母    |
		/// 	|        |    母母     +------------+-------------|
		/// 	|        |             |  (く)      | 母母母父    |
		/// 	|        |             |   母母母   +-------------|
		/// 	|        |             |            | 母母母母    |
		/// 	---------------------------------------------------
		/// 	父方の3代前のすべての先祖(あ・い・う・え)がSP系統で、
		/// 	母方の3代前のすべての先祖(お・か・き・く)がST系統の場合に成立します(逆でも可)
		/// 	牝馬は、いずれかの因子を持っていれば、系統特性(SP系統・ST系統)でなくてもかまいません。
		/// 	爆発力・パワーのアップが期待できます。
		/// </summary>
		private void SPST融合配合のチェック()
		{
			object temp = null;

			foreach( var node in this.SirePedigree.NodeList(2) ) {
				var family_line_info = this.family_line_info[ node.Data.family_line_num ];

				if( temp == null ) {
					temp = family_line_info.Data.family_line_attr;

					if( (uint)temp != 1 && (uint)temp != 2 ) {
						this.Combination.SPST融合配合 = false;
						return;
					}
				} else if( (uint)temp != family_line_info.Data.family_line_attr ) {
					// 牝馬は、いずれかの因子を持っていれば、系統特性(SP系統・ST系統)でなくてもかまいません。
					if( node.Type == Enums.血統タイプ.母系 && ( node.Data.factor_left < 9 || node.Data.factor_right < 9 ) ) {
						continue;
					}
					this.Combination.SPST融合配合 = false;
					return;
				}
			}
			var check_attr   = (uint)temp == 2 ? 1 : 2;
			var check_factor = (uint)temp == 2 ? 0 : 1;

			foreach( var node in this.DamPedigree.NodeList(2) ) {
				var family_line_info = this.family_line_info[ node.Data.family_line_num ];
				
				if( check_attr != family_line_info.Data.family_line_attr ) {
					// 牝馬は、いずれかの因子を持っていれば、系統特性(SP系統・ST系統)でなくてもかまいません。
					if( node.Type == Enums.血統タイプ.母系 && ( node.Data.factor_left < 9 || node.Data.factor_right < 9 ) ) {
						continue;
					}
					this.Combination.SPST融合配合 = false;
					return;
				}
			}
			this.Combination.SPST融合配合 = true;
		}

		/// <summary>
		/// 母父効果のチェック
		/// 
		///	88 こんな名無しでは、どうしようもないよ。 sage 2012/03/30(金) 11:10:05.60 ID:wGxQ0LBn
		///	sheep(とそのパクリブログ)の配合理論　２０１２の相違点
        	///
		///	母父◎○→大種牡馬も名種牡馬も爆発力は(能力系因子×２)
		///	　　　　　　　　能力系因子２つ持ちは爆発力４　１つ持ちは爆発力２
		///
		/// </summary>
		private void 母父効果のチェック()
		{
			// 母父の血統
			var father_node = this.DamPedigree.Tree.Father;
			var family_line_info = this.family_line_info[ father_node.Data.family_line_num ];

			if( father_node.BloodNum != family_line_info.Data.blood_num ) {
				this.Combination.母父効果 = Enums.母父効果.無し;
				return;
			}
			var factor_count = 0;

			if( father_node.Data.factor_left < 9 ) 
				factor_count++;
			if( father_node.Data.factor_right < 9 ) {
				factor_count++;
			}
			switch( factor_count ) {
			case 0:
				this.Combination.母父効果 = Enums.母父効果.無し;
				break;
			case 1:
				this.Combination.母父効果 = Enums.母父効果.小;
				break;
			case 2:
				this.Combination.母父効果 = Enums.母父効果.大;
				break;
			default:
				throw new Exception("[BUG]");
			}
		}

		/// <summary>
		/// 活力補完
		/// 
		/// ---------------------------------------------------
		/// |        |             |  (あ)      | 父父父父    |
		/// |        |             |   父父父   +-------------|
		/// |        |             |            | 父父父母    |
		/// |        |    父父     +------------+-------------|
		/// |        |             |  (い)      | 父父母父    |
		/// |        |             |   父父母   +-------------|
		/// |        |             |            | 父父母母    |
		/// | 父     |-------------+------------+-------------|
		/// |        |             |  (う)      | 父母父父    |
		/// |        |             |   父母父   +-------------|
		/// |        |             |            | 父母父母    |
		/// |        |    父母     +------------+-------------|
		/// |        |             |  (え)      | 父母母父    |
		/// |        |             |   父母母   +-------------|
		/// |        |             |            | 父母母母    |
		/// |--------+-------------+------------+-------------|
		/// |        |             |  (お)      | 母父父父    |
		/// |        |             |   母父父   +-------------|
		/// |        |             |            | 母父父母    |
		/// |        |    母父     +------------+-------------|
		/// |        |             |  (か)      | 母父母父    |
		/// |        |             |   母父母   +-------------|
		/// |        |             |            | 母父母母    |
		/// | 母     +-------------+------------+-------------|
		/// |        |             |  (き)      | 母母父父    |
		/// |        |             |   母母父   +-------------|
		/// |        |             |            | 母母父母    |
		/// |        |    母母     +------------+-------------|
		/// |        |             |  (く)      | 母母母父    |
		/// |        |             |   母母母   +-------------|
		/// |        |             |            | 母母母母    |
		/// ---------------------------------------------------
		/// 
		/// *名種牡馬型活力補完
		/// 	3代前先祖馬の中に、大種牡馬因子や名種牡馬因子を持つ(つまり系統を確立している)種牡馬がいる場合に成立します。 
		/// 	種牡馬の数に比例して、競走寿命のアップが期待できます。
		/// 	
		/// *名牝型活力補完
		/// 	3代前先祖馬の中に、因子を持つ繁殖牝馬がいる場合に成立します。
		/// 	繁殖牝馬の数に比例して、競走寿命のアップが期待できます。
		/// 	
		/// *異系血脈型活力補完
		/// 	3代前先祖馬の中に、零細血統の馬がいる場合に成立します。
		/// 	馬の数に比例して、競走寿命のアップが期待できます。
		/// 	
		/// *完全型活力補完
		/// 	3代前先祖馬すべてが、上記のいずれかの活力補完の対象になっている場合に成立します。
		/// </summary>
		private void 活力補完のチェック()
		{
			this.Combination.名種牡馬型活力補完 = 0;
			this.Combination.名牝型活力補完 = 0;
			this.Combination.異系血脈型活力補完 = 0;
			this.Combination.完全型活力補完 = true;

			foreach( var pedigree in new[]{ this.SirePedigree, this.DamPedigree } ) {
				foreach( var node in pedigree.NodeList(2) ) {
					var match = false;
					var family_line_info = this.family_line_info[ node.Data.family_line_num ];

					switch( node.Type ) {
					case Enums.血統タイプ.父系:
						if( family_line_info.Data.blood_num == node.BloodNum ) {
							match = true;
							this.Combination.名種牡馬型活力補完++;
						}
						break;
					case Enums.血統タイプ.母系:
						if( node.Data.factor_left < 9 || node.Data.factor_right < 9 ) {
							match = true;
							this.Combination.名牝型活力補完++;
						}
						break;
					}
					if( family_line_info.零細血統か() ) {
						match = true;
						this.Combination.異系血脈型活力補完++;
					}
					if( match == false ) {
						this.Combination.完全型活力補完 = false;
					}
				}
			}
		}

		/// <summary>
		/// 隔世遺伝のチェック
		/// 
		/// --------------------------------------------------------
		/// |             |             |            | 父父父父    |
		/// |             |             |   父父父   +-------------|
		/// |             |    (う)     |            | 父父父母    |
		/// |             |    父父     +------------+-------------|
		/// |             |             |            | 父父母父    |
		/// |             |             |   父父母   +-------------|
		/// | (あ)        |             |            | 父父母母    |
		/// | 父          |-------------+------------+-------------|
		/// |             |             |            | 父母父父    |
		/// |             |             |   父母父   +-------------|
		/// |             |             |            | 父母父母    |
		/// |             |    父母     +------------+-------------|
		/// |             |             |            | 父母母父    |
		/// |             |             |   父母母   +-------------|
		/// |             |             |            | 父母母母    |
		/// |-------------+-------------+------------+-------------|
		/// |             |             |            | 母父父父    |
		/// |             |             |   母父父   +-------------|
		/// |             |    (え)     |            | 母父父母    |
		/// |             |    母父     +------------+-------------|
		/// |             |             |            | 母父母父    |
		/// |             |             |   母父母   +-------------|
		/// | (い)        |             |            | 母父母母    |
		/// | 母          +-------------+------------+-------------|
		/// |             |             |            | 母母父父    |
		/// |             |             |   母母父   +-------------|
		/// |             |             |            | 母母父母    |
		/// |             |    母母     +------------+-------------|
		/// |             |             |            | 母母母父    |
		/// |             |             |   母母母   +-------------|
		/// |             |             |            | 母母母母    |
		/// --------------------------------------------------------
		/// 
		/// 父と母(あ・い)がともに因子を持たず、祖父(う・え)が因子を持っている場合に成立します。
		/// 父 と母の祖父とも因子を持っている場合は、父方の祖父(う)が優先され、母方の祖父(え)は影響しません。
		/// 祖父の持つ因子の能力がアップします。(SP因子を持っている場合は爆発力がアップします)
		/// </summary>
		private void 隔世遺伝のチェック()
		{
			var sire_blood = this.SirePedigree.Tree.Data;
			var dam_blood  = this.DamPedigree.Tree.Data;

			if( sire_blood.factor_left < 9 || sire_blood.factor_right < 9 || dam_blood.factor_left < 9 || dam_blood.factor_right < 9 ) {
				this.Combination.隔世遺伝 = this.wp.Config.NullBloodNumber;
				return ;
			}
			

			foreach( var pedigree in new[]{ this.SirePedigree, this.DamPedigree } ) {
				if( pedigree.Tree.Father.Data.factor_left < 9 || pedigree.Tree.Father.Data.factor_right < 9 ) {
					this.Combination.隔世遺伝 = pedigree.Tree.Father.BloodNum;
					return ;
				}
			}
			this.Combination.隔世遺伝 = this.wp.Config.NullBloodNumber;
		}

		/// <summary>
		/// ライン活性配合のチェック
		/// </summary>
		private void ライン活性配合のチェック()
		{
			var result = this.sub_メールライン活性配合のチェック();


			if( result != Enums.ライン活性配合.無し ) {
				this.Combination.ライン活性配合 = result;
				return ;
			}
			this.Combination.ライン活性配合 = this.sub_ボトムライン活性配合のチェック();
		}

		/// <summary>
		/// メールライン活性配合のチェック
		/// 
		/// --------------------------------------------------------
		/// |             |             |   (け)     | 父父父父    |
		/// |             |             |   父父父   +-------------|
		/// |             |             |            | 父父父母    |
		/// |             |    父父     +------------+-------------|
		/// |             |             |   (く)     | 父父母父    |
		/// |  [流行]     |             |   父父母   +-------------|
		/// |             |             |            | 父父母母    |
		/// | 父          |-------------+------------+-------------|
		/// |             |             |   (き)     | 父母父父    |
		/// |             |             |   父母父   +-------------|
		/// |             |             |            | 父母父母    |
		/// |             |    父母     +------------+-------------|
		/// |             |             |   (か)     | 父母母父    |
		/// |             |             |   父母母   +-------------|
		/// |             |             |            | 父母母母    |
		/// |-------------+-------------+------------+-------------|
		/// |             |             |   (お)     | 母父父父    |
		/// |             |             |   母父父   +-------------|
		/// |             |             |            | 母父父母    |
		/// |             |    母父     +------------+-------------|
		/// |             |             |   (え)     | 母父母父    |
		/// |             |             |   母父母   +-------------|
		/// |  (あ)       |             |            | 母父母母    |
		/// | 母          +-------------+------------+-------------|
		/// |             |             |   (う)     | 母母父父    |
		/// |             |             |   母母父   +-------------|
		/// |             |             |            | 母母父母    |
		/// |             |    母母     +------------+-------------|
		/// |             |             |   (い)     | 母母母父    |
		/// |             |             |   母母母   +-------------|
		/// |             |             |            | 母母母母    |
		/// --------------------------------------------------------
		/// 
		/// メールライン活性配合Lv1
		/// 	父が「流行」で、母、母母、母母母が(あ・い・う)ともに「零細」の場合に成立します。
		/// 	
		/// メールライン活性配合Lv2
		/// 	加えて、母方の3代前の先祖(え・お)がすべて零細血統だとより効果が高くなります。
                /// 
		/// メールライン活性配合Lv3
		/// 	メールライン以外の3代前の先祖(い・う・え・お・か・き・く・け)がすべて零細血統だと
		/// 	さらに効果が高くなります
		/// 
		/// 
		/// > 88 名前：こんな名無しでは、どうしようもないよ。[sage] 投稿日：2012/03/30(金) 11:10:05.60 ID:wGxQ0LBn [1/2]
		/// > sheep（とそのパクリブログ）の配合理論　２０１２の相違点
		/// > メールラインLV3→父父父は流行でもよい
		/// 
		/// MEMO:
		///		×流行でもよい
		///		○零細で無くてもよい
		///	</summary>
		private Enums.ライン活性配合 sub_メールライン活性配合のチェック()
		{
			var sire_blood = this.SirePedigree.Tree.Data;
			var temp_info = this.family_line_info[ sire_blood.family_line_num ];

			// 父が流行血統ではないなら活性無し
			if( !temp_info.流行血統か() ) {
				return Enums.ライン活性配合.無し;
			}

			Pedigree.Node[] node_check_list;

			// (あ)の零細チェック
			temp_info = this.family_line_info[ this.DamPedigree.Tree.Data.family_line_num ];

			if( !temp_info.零細血統か() ) {
				return Enums.ライン活性配合.無し;
			}

			// (い),(う)の零細チェック
			node_check_list = new Pedigree.Node[] {
				this.DamPedigree.Tree.Mother.Mother,
				this.DamPedigree.Tree.Mother.Father,
			};

			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.零細血統か() ) {
					return Enums.ライン活性配合.無し;
				}
			}

			// (い),(う),(え),(お)の零細チェック
			node_check_list = new Pedigree.Node[] {
				this.DamPedigree.Tree.Mother.Mother,
				this.DamPedigree.Tree.Mother.Father,
				this.DamPedigree.Tree.Father.Mother,
				this.DamPedigree.Tree.Father.Father,
			};
			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.零細血統か() ) {
					return Enums.ライン活性配合.メールライン活性配合Lv1;;
				}
			}

			//  (か),(き),(く),(け)の零細チェック((い),(う),(え),(お)は零細確定済み)
			node_check_list = new Pedigree.Node[] {
				this.SirePedigree.Tree.Mother.Mother,
				this.SirePedigree.Tree.Mother.Father,
				this.SirePedigree.Tree.Father.Mother,
				// (け)は零細の必要は無くなった 
				//this.SirePedigree.Tree.Father.Father
			};
			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.零細血統か() ) {
					// メールライン活性配合Lv2
					return Enums.ライン活性配合.メールライン活性配合Lv2;
				}
			}
			return Enums.ライン活性配合.メールライン活性配合Lv3;
		}

		/// <summary>
		/// ボトムライン 活性配合
		/// 
		/// --------------------------------------------------------
		/// |             |             |   (こ)     | 父父父父    |
		/// |             |             |   父父父   +-------------|
		/// |             |             |            | 父父父母    |
		/// |             |    父父     +------------+-------------|
		/// |             |             |   (け)     | 父父母父    |
		/// |             |             |   父父母   +-------------|
		/// |  [零細]     |             |            | 父父母母    |
		/// | 父          |-------------+------------+-------------|
		/// |             |             |   (く)     | 父母父父    |
		/// |             |             |   父母父   +-------------|
		/// |             |             |            | 父母父母    |
		/// |             |    父母     +------------+-------------|
		/// |             |             |   (き)     | 父母母父    |
		/// |             |             |   父母母   +-------------|
		/// |             |             |            | 父母母母    |
		/// |-------------+-------------+------------+-------------|
		/// |             |             |   (か)     | 母父父父    |
		/// |             |             |   母父父   +-------------|
		/// |             |             |            | 母父父母    |
		/// |             |    母父     +------------+-------------|
		/// |             |             |   (お)     | 母父母父    |
		/// |             |             |   母父母   +-------------|
		/// |  (あ)       |             |            | 母父母母    |
		/// | 母          +-------------+------------+-------------|
		/// |             |             |   (え)     | 母母父父    |
		/// |             |             |   母母父   +-------------|
		/// |             |    (い)     |            | 母母父母    |
		/// |             |    母母     +------------+-------------|
		/// |             |             |   (う)     | 母母母父    |
		/// |             |             |   母母母   +-------------|
		/// |             |             |            | 母母母母    |
		/// --------------------------------------------------------
		/// 
		/// ボトムライン活性配合Lv1
		/// 	父が「零細」で、母、母母、母母母が(あ・い・う)ともに流行か因子を持っている場合に成立します。
		/// 
		/// ボトムライン活性配合Lv2
		/// 	加えて、父方の3代前の先祖(こ・け・く・き)がすべて零細血統だとより効果が高くなります。
		/// 
		/// ボトムライン活性配合Lv3
		/// 	加えての母方の3代前の先祖(う・え・お・か)がすべて 
		/// 	流行血統だとさらに効果が高くなります
		/// </summary>
		/// <returns></returns>
		private Enums.ライン活性配合 sub_ボトムライン活性配合のチェック()
		{
			var sire_blood = this.SirePedigree.Tree.Data;
			var temp_info = this.family_line_info[ sire_blood.family_line_num ];

			if( !temp_info.零細血統か() ) {
				return Enums.ライン活性配合.無し;
			}

			// Lv1のチェック
			var level = Enums.ライン活性配合.無し;

			Pedigree.Node[] node_check_list;

			temp_info = this.family_line_info[ this.DamPedigree.Tree.Data.family_line_num ];

			// (あ)の流行or因子持ちチェック
			if( !temp_info.流行血統か() ) {
				if( this.DamPedigree.Tree.Data.factor_left > 8 && this.DamPedigree.Tree.Data.factor_right > 8 ) {
					return  Enums.ライン活性配合.無し;
				}
			}
			// (い),(う)の流行or因子持ちチェック
			node_check_list = new Pedigree.Node[] {
				this.DamPedigree.Tree.Mother,
				this.DamPedigree.Tree.Mother.Mother,
			};
			level = Enums.ライン活性配合.ボトムライン活性配合Lv1;

			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.流行血統か() && ( node.Data.factor_left > 8 && node.Data.factor_right > 8 ) ) {
					return Enums.ライン活性配合.無し;
				}
			}

			// (こ),(け),(く),(き)の零細チェック
			node_check_list = new Pedigree.Node[] {
				this.DamPedigree.Tree.Father.Father,
				this.DamPedigree.Tree.Father.Mother,
				this.DamPedigree.Tree.Mother.Father,
				this.DamPedigree.Tree.Mother.Mother,
			};
			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.零細血統か() ) {
					// ボトムライン活性配合Lv1 or 無し
					return level;
				}
			}

			// (う),(え),(お),(か)の流行チェック((こ),(け),(く),(き)は零細確定済み)
			node_check_list = new Pedigree.Node[] {
				this.SirePedigree.Tree.Mother.Mother,
				this.SirePedigree.Tree.Mother.Father,
				this.SirePedigree.Tree.Father.Mother,
				this.SirePedigree.Tree.Father.Father
			};
			foreach( var node in node_check_list ) {
				temp_info = this.family_line_info[ node.Data.family_line_num ];
				if( !temp_info.零細血統か() ) {
					return Enums.ライン活性配合.ボトムライン活性配合Lv2;
				}
			}
			return Enums.ライン活性配合.ボトムライン活性配合Lv3;
		}

		/// <summary>
		/// 活力源化種牡馬因子のチェック
		/// 
		/// 活力源化大種牡馬因子
		/// 父と母の先祖に「大種牡馬因子 」を持つ馬がいる場合に成立します。
		/// 因子の数に応じて爆発力がアップします。ただしインブリードが発生した場合は、効果が半減します。
		/// 
		/// 活力源化名種牡馬因子
		/// 父と母の先祖にそれぞれ「名種牡馬因子 」を持つ馬がいる場合に成立します。
		/// 因子の数に応じて爆発力がアップします。ただしインブリードが発生した場合は、効果が半減します。
		/// </summary>
		private void 活力源化種牡馬因子のチェック()
		{
			var big_sire_factor_list = new List< UInt32 >();
			var small_sire_factor_list = new List< UInt32 >();

			var sire_having_big_sire_factor = false;
			var sire_having_small_sire_factor = false;

			foreach( var node in this.SirePedigree.NodeList() ) {
				var family_line_info = this.family_line_info[ node.Data.family_line_num ];
				if( family_line_info.Data.blood_num == node.BloodNum ) {
					if( family_line_info.ParentFamilyLuneNum == node.Data.family_line_num ) {
						sire_having_big_sire_factor = true;
						big_sire_factor_list.Add( node.BloodNum );
					} else {
						sire_having_small_sire_factor = true;
						small_sire_factor_list.Add( node.BloodNum );
					}
				}
			}

			if( !sire_having_big_sire_factor && !sire_having_small_sire_factor ) {
				this.Combination.活力源化大種牡馬因子 = new UInt32[0];
				this.Combination.活力源化名種牡馬因子 = new UInt32[0];
				return ;
			}

			var dam_having_big_sire_factor = false;
			var dam_having_small_sire_factor = false;

			foreach( var node in this.DamPedigree.NodeList() ) {
				var family_line_info = this.family_line_info[ node.Data.family_line_num ];
				if( family_line_info.Data.blood_num == node.BloodNum ) {
					if( family_line_info.ParentFamilyLuneNum == node.Data.family_line_num ) {
						if( sire_having_big_sire_factor ) {
							dam_having_big_sire_factor = true;
							big_sire_factor_list.Add( node.BloodNum );
						}
					} else if( sire_having_small_sire_factor ) {
						dam_having_small_sire_factor = true;
						small_sire_factor_list.Add( node.BloodNum );
					}
				}
			}
			if( !dam_having_big_sire_factor ) {
				big_sire_factor_list.Clear();
			}
			if( !dam_having_small_sire_factor ) {
				small_sire_factor_list.Clear();
			}
			this.Combination.活力源化大種牡馬因子 = big_sire_factor_list.ToArray();
			this.Combination.活力源化名種牡馬因子 = small_sire_factor_list.ToArray();
		}

		/// <summary>
		/// 特殊配合のチェック
		/// 
		/// お笑い配合
		/// 	評価額が1億円以上で賢さも高い母に、種付け料100万円以下の父を配合する場合に成立します。
		/// 	精神力・賢さ・勝負根性・爆発力のアップが期待できます。
		/// 
		/// お似合い配合
		/// 	種付け料が200万円以下で賢さが高い父と、評価額が1000万円以下で賢さが高い母を配合する場合に成立します。
		/// 	精神力・賢さ・勝負根性・爆発力のアップが期待できます。
		/// 
		/// サヨナラ配合
		/// 	23歳以上で、同じ子系統の種牡馬がその地域（日本・米国・欧州）に1頭もいない父を配合する場合に成立します。
		/// 	神力・健康・勝負根性・爆発力のアップが期待できます。
		/// 
		/// Wサヨナラ配合
		/// 	サヨナラ配合が成立する父と、15歳以上で零細血統の母を配合する場合に成立します。
		/// 	精神力・賢さ・健康・パワー・勝負根性・瞬発力・爆発力のアップが期待できます。
		/// 	
		/// 稲妻配合
		/// 	瞬発力が高く勝負根性の低い父と、瞬発力が高く勝負根性の低い母を配合した場合に成立します。
		/// 	瞬発力・柔軟性・爆発力のアップが期待できますが、勝負根性がダウンします。
		/// 
		/// 真稲妻配合
		/// 	瞬発力が高く勝負根性の低い父（毛色が白毛または芦毛）と、
		/// 	瞬発力が高く勝負根性の低い母（毛色が白毛または芦毛）を配合した場合に成立します。
		/// 	瞬発力・柔軟性・爆発力のアップが期待できますが、勝負根性がダウンします。
		/// 
		/// 疾風配合
		/// 	勝負根性が高く瞬発力の低い父と、勝負根性が高く瞬発力の低い母を配合した場合に成立します。
		/// 	精神力・勝負根性・爆発力のアップが期待できますが、瞬発力がダウンします。
		/// 
		/// 真疾風配合
		/// 	勝負根性が高く瞬発力の低い父（毛色が黒鹿毛、青鹿毛または青毛）と、
		/// 	勝負根性が高く瞬発力の低い母（毛色が黒鹿毛、青鹿毛または青毛）を配合した場合に成立します。
		/// 	精神力・勝負根性・爆発力のアップが期待できますが、瞬発力がダウンします。
		/// 
		/// 3冠配合
		/// 	3冠馬の父と3冠馬の母を配合した場合に成立します（欧州3冠、秋古馬3冠など、普通の3冠以外でも可）。
		/// 	爆発力のアップが期待できます。
		/// </summary>
		private void 特殊配合のチェック()
		{
			HSireData
				sire_data = new HSireData();

			HDamData
				dam_data = new HDamData();

			HAblData 
				sire_abl = new HAblData(),
				dam_abl = new HAblData();

			HBloodData
				sire_blood = new HBloodData(),
				dam_blood = new HBloodData();

			this.wp.HSireTable.GetData( this.SirePedigree.HorseNum, ref sire_data );
			this.wp.HDamTable.GetData( this.DamPedigree.HorseNum, ref dam_data );

			this.wp.HAblTable.GetData( sire_data.abl_num, ref sire_abl );
			this.wp.HAblTable.GetData( dam_data.abl_num, ref dam_abl );
			
			this.wp.HBloodTable.GetData( sire_data.blood_num, ref sire_blood );
			this.wp.HBloodTable.GetData( dam_data.blood_num, ref dam_blood );

			var tanetsuke_price = ( sire_data.tanetsuke >> 1 ) * 100 + ( ( sire_data.tanetsuke & 0x1 ) == 1 ? 50 : 0 );

			this.Combination.お笑い配合 = false;
			if( tanetsuke_price <= 100 && dam_data.price >= 100 && dam_abl.kashikosa >= 2 ) {
				this.Combination.お笑い配合 = true;
			}

			this.Combination.お似合い配合 = false;
			if( tanetsuke_price <= 200 && dam_data.price <= 10 && sire_abl.kashikosa >= 2 && dam_abl.kashikosa >= 2 ) {
				this.Combination.お似合い配合 = true;
			}

			this.Combination.サヨナラ配合 = false;
			this.Combination.Wサヨナラ配合 = false;
			if( (sire_data.age + 2) >= 23 && this.family_line_info[ sire_blood.family_line_num ].SireCount <= 1 ) {
				if( (dam_data.age + 2) > 15 && this.family_line_info[ dam_blood.family_line_num ].零細血統か() ) {
					this.Combination.Wサヨナラ配合 = true;
				} else {
					this.Combination.サヨナラ配合 = true;
				}
			}

			this.Combination.稲妻配合 = false;
			this.Combination.真稲妻配合 = false;
			if( sire_abl.syunpatsu == 3 && sire_abl.konzyou <= 1 && dam_abl.syunpatsu == 3 && dam_abl.konzyou <= 1 ) {
				if( ( sire_abl.keiro >= 6 && sire_abl.keiro <= 9 ) && ( dam_abl.keiro >= 6 && dam_abl.keiro <= 9 ) ) {
					this.Combination.真稲妻配合 = true;
				} else {
					this.Combination.稲妻配合 = true;
				}
			}

			this.Combination.真疾風配合 = false;
			this.Combination.疾風配合 = false;
			if( sire_abl.syunpatsu <= 1 && sire_abl.konzyou == 3 && dam_abl.syunpatsu <= 1 && dam_abl.konzyou == 3 ) {
				if( sire_abl.keiro == 1 && dam_abl.keiro == 1 ) {
					this.Combination.真疾風配合 = true;
				} else {
					this.Combination.疾風配合 = true;
				}
			}

			this.Combination.三冠配合 = false;
			if( Array.IndexOf( SANKAN_RACE_ID_LIST, dam_data.kachikura ) != -1 ) {
				foreach( var kachikura in new[]{ sire_data.kachikura_LB, sire_data.kachikura_LT, sire_data.kachikura_RB, sire_data.kachikura_RT } ) {
					if( Array.IndexOf( SANKAN_RACE_ID_LIST, kachikura ) != -1 ) {
						this.Combination.三冠配合 = true;
						break;
					}
				}
			}
		}

	} // Class Breeding
} // namespace KOEI.WP7_2012.Horse.Breeding
