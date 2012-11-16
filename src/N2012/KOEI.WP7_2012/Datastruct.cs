
/* libwp7n2012 -- Winning Post 7 2012 Cheat Library

   Copyright (C) 2012 AIPON of author

   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 2.1 of the License, or (at your option) any later version.

   This library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with this library; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

   Written by AIPON */

namespace KOEI.WP7_2012.Datastruct
{
	using System;
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Explicit)]
	public struct HBloodData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// father_numの最大値
		/// </summary>
		public const UInt32 father_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 父馬血統番号
		/// </summary>
		public UInt32 father_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00007fff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffff8000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// mother_numの最大値
		/// </summary>
		public const UInt32 mother_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 母馬血統番号
		/// </summary>
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 15 ) & 0x00007fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xc0007fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_1
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// displayの最大値
		/// </summary>
		public const UInt32 display_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 馬名表示(0カナ,1英字)
		/// </summary>
		public UInt32 display {
			get { return ( this.__bitfield0 >> 31 ) & 0x00000001;  }
			set {
				if( value > display_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield1 >> 0 ) & 0x00000001;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffffe ) | ( value << 0 );
			}
		}
		/// <summary>
		/// family_line_numの最大値
		/// </summary>
		public const UInt32 family_line_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 子系統
		/// </summary>
		public UInt32 family_line_num {
			get { return ( this.__bitfield1 >> 1 ) & 0x000000ff;  }
			set {
				if( value > family_line_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffe01 ) | ( value << 1 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield1 >> 9 ) & 0x00007fff;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff0001ff ) | ( value << 9 );
			}
		}
		/// <summary>
		/// factor_leftの最大値
		/// </summary>
		public const UInt32 factor_left_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 因子左
		/// </summary>
		public UInt32 factor_left {
			get { return ( this.__bitfield1 >> 24 ) & 0x0000000f;  }
			set {
				if( value > factor_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf0ffffff ) | ( value << 24 );
			}
		}
		/// <summary>
		/// factor_rightの最大値
		/// </summary>
		public const UInt32 factor_right_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 因子右
		/// </summary>
		public UInt32 factor_right {
			get { return ( this.__bitfield1 >> 28 ) & 0x0000000f;  }
			set {
				if( value > factor_right_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// name_leftの最大値
		/// </summary>
		public const UInt32 name_left_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 馬名前半番号
		/// </summary>
		public UInt32 name_left {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > name_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_rightの最大値
		/// </summary>
		public const UInt32 name_right_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 馬名後半番号
		/// </summary>
		public UInt32 name_right {
			get { return ( this.__bitfield2 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > name_right_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield2 = ( this.__bitfield2 & 0x0000ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("father_num"), 15, 32767, "父馬血統番号", "父馬の血統番号" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("mother_num"), 15, 32767, "母馬血統番号", "母馬の血統番号" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("padding_1"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("display"), 1, 1, "馬名表示(0カナ,1英字)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("padding_2"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("family_line_num"), 8, 255, "子系統", "系統番号" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("padding_3"), 15, 32767, "", "" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("factor_left"), 4, 15, "因子左", "0=スピード 1=スタミナ 2=パワー 3=瞬発力 4=勝負根性\r\n5=柔軟性 6=早熟 7=晩成 8=気性灘 9=無し" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("factor_right"), 4, 15, "因子右", "0=スピード 1=スタミナ 2=パワー 3=瞬発力 4=勝負根性\r\n5=柔軟性 6=早熟 7=晩成 8=気性灘 9=無し" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("name_left"), 16, 65535, "馬名前半番号", "" ),
				new DataStructPropertyInfo( typeof(HBloodData).GetProperty("name_right"), 16, 65535, "馬名後半番号", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[3];
			data[0] = data[0] | ( this.father_num << 0 ) ;
			data[0] = data[0] | ( this.mother_num << 15 ) ;
			data[0] = data[0] | ( this.padding_1 << 30 ) ;
			data[0] = data[0] | ( this.display << 31 ) ;
			data[1] = data[1] | ( this.padding_2 << 0 ) ;
			data[1] = data[1] | ( this.family_line_num << 1 ) ;
			data[1] = data[1] | ( this.padding_3 << 9 ) ;
			data[1] = data[1] | ( this.factor_left << 24 ) ;
			data[1] = data[1] | ( this.factor_right << 28 ) ;
			data[2] = data[2] | ( this.name_left << 0 ) ;
			data[2] = data[2] | ( this.name_right << 16 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HBloodData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 3 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 3)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 3;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HFamilyLineData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// family_line_numの最大値
		/// </summary>
		public const UInt32 family_line_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 親系統(自身を指せば親昇格)
		/// </summary>
		public UInt32 family_line_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x000000ff;  }
			set {
				if( value > family_line_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// family_line_attrの最大値
		/// </summary>
		public const UInt32 family_line_attr_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 系統特性
		/// </summary>
		public UInt32 family_line_attr {
			get { return ( this.__bitfield0 >> 8 ) & 0x00000003;  }
			set {
				if( value > family_line_attr_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffcff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// eikyouryokuの最大値
		/// </summary>
		public const UInt32 eikyouryoku_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 影響力
		/// </summary>
		public UInt32 eikyouryoku {
			get { return ( this.__bitfield0 >> 10 ) & 0x00000001;  }
			set {
				if( value > eikyouryoku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffbff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// bms_Oの最大値
		/// </summary>
		public const UInt32 bms_O_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 母父○
		/// </summary>
		public UInt32 bms_O {
			get { return ( this.__bitfield0 >> 11 ) & 0x00000001;  }
			set {
				if( value > bms_O_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffff7ff ) | ( value << 11 );
			}
		}
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_1
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield0 >> 12 ) & 0x00000001;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffefff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// blood_numの最大値
		/// </summary>
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 血統ポインタ
		/// </summary>
		public UInt32 blood_num {
			get { return ( this.__bitfield0 >> 13 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf0001fff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield0 >> 28 ) & 0x0000000f;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield0 = ( this.__bitfield0 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// share_Jの最大値
		/// </summary>
		public const UInt32 share_J_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 支配率(日本)
		/// </summary>
		public UInt32 share_J {
			get { return ( this.__bitfield1 >> 0 ) & 0x000003ff;  }
			set {
				if( value > share_J_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// share_Uの最大値
		/// </summary>
		public const UInt32 share_U_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 支配率(米国)
		/// </summary>
		public UInt32 share_U {
			get { return ( this.__bitfield1 >> 10 ) & 0x000003ff;  }
			set {
				if( value > share_U_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfff003ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// share_Eの最大値
		/// </summary>
		public const UInt32 share_E_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 支配率(欧州)
		/// </summary>
		public UInt32 share_E {
			get { return ( this.__bitfield1 >> 20 ) & 0x000003ff;  }
			set {
				if( value > share_E_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xc00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield1 >> 30 ) & 0x00000003;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// nicks_1_numの最大値
		/// </summary>
		public const UInt32 nicks_1_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス1系統
		/// </summary>
		public UInt32 nicks_1_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_1_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// nicks_1_shareの最大値
		/// </summary>
		public const UInt32 nicks_1_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス1繁栄度
		/// </summary>
		public UInt32 nicks_1_share {
			get { return ( this.__bitfield2 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_1_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// nicks_2_numの最大値
		/// </summary>
		public const UInt32 nicks_2_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス2系統
		/// </summary>
		public UInt32 nicks_2_num {
			get { return ( this.__bitfield2 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_2_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// nicks_2_shareの最大値
		/// </summary>
		public const UInt32 nicks_2_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス2繁栄度
		/// </summary>
		public UInt32 nicks_2_share {
			get { return ( this.__bitfield2 >> 24 ) & 0x000000ff;  }
			set {
				if( value > nicks_2_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// nicks_3_numの最大値
		/// </summary>
		public const UInt32 nicks_3_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス3系統
		/// </summary>
		public UInt32 nicks_3_num {
			get { return ( this.__bitfield3 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_3_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// nicks_3_shareの最大値
		/// </summary>
		public const UInt32 nicks_3_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス3繁栄度
		/// </summary>
		public UInt32 nicks_3_share {
			get { return ( this.__bitfield3 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_3_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// nicks_4_numの最大値
		/// </summary>
		public const UInt32 nicks_4_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス4系統
		/// </summary>
		public UInt32 nicks_4_num {
			get { return ( this.__bitfield3 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_4_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// nicks_4_shareの最大値
		/// </summary>
		public const UInt32 nicks_4_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス4繁栄度
		/// </summary>
		public UInt32 nicks_4_share {
			get { return ( this.__bitfield3 >> 24 ) & 0x000000ff;  }
			set {
				if( value > nicks_4_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// nicks_5_numの最大値
		/// </summary>
		public const UInt32 nicks_5_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス5系統
		/// </summary>
		public UInt32 nicks_5_num {
			get { return ( this.__bitfield4 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_5_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// nicks_5_shareの最大値
		/// </summary>
		public const UInt32 nicks_5_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス5繁栄度
		/// </summary>
		public UInt32 nicks_5_share {
			get { return ( this.__bitfield4 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_5_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// nicks_6_numの最大値
		/// </summary>
		public const UInt32 nicks_6_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス6系統
		/// </summary>
		public UInt32 nicks_6_num {
			get { return ( this.__bitfield4 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_6_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// nicks_6_shareの最大値
		/// </summary>
		public const UInt32 nicks_6_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス6繁栄度
		/// </summary>
		public UInt32 nicks_6_share {
			get { return ( this.__bitfield4 >> 24 ) & 0x000000ff;  }
			set {
				if( value > nicks_6_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		/// <summary>
		/// nicks_7_numの最大値
		/// </summary>
		public const UInt32 nicks_7_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス7系統
		/// </summary>
		public UInt32 nicks_7_num {
			get { return ( this.__bitfield5 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_7_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// nicks_7_shareの最大値
		/// </summary>
		public const UInt32 nicks_7_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス7繁栄度
		/// </summary>
		public UInt32 nicks_7_share {
			get { return ( this.__bitfield5 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_7_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// nicks_8_numの最大値
		/// </summary>
		public const UInt32 nicks_8_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス8系統
		/// </summary>
		public UInt32 nicks_8_num {
			get { return ( this.__bitfield5 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_8_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// nicks_8_shareの最大値
		/// </summary>
		public const UInt32 nicks_8_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス8繁栄度
		/// </summary>
		public UInt32 nicks_8_share {
			get { return ( this.__bitfield5 >> 24 ) & 0x000000ff;  }
			set {
				if( value > nicks_8_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		/// <summary>
		/// nicks_9_numの最大値
		/// </summary>
		public const UInt32 nicks_9_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス9系統
		/// </summary>
		public UInt32 nicks_9_num {
			get { return ( this.__bitfield6 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_9_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// nicks_9_shareの最大値
		/// </summary>
		public const UInt32 nicks_9_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス9繁栄度
		/// </summary>
		public UInt32 nicks_9_share {
			get { return ( this.__bitfield6 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_9_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// nicks_10_numの最大値
		/// </summary>
		public const UInt32 nicks_10_num_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス10系統
		/// </summary>
		public UInt32 nicks_10_num {
			get { return ( this.__bitfield6 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_10_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// nicks_10_shareの最大値
		/// </summary>
		public const UInt32 nicks_10_share_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ニックス10繁栄度
		/// </summary>
		public UInt32 nicks_10_share {
			get { return ( this.__bitfield6 >> 24 ) & 0x000000ff;  }
			set {
				if( value > nicks_10_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		/// <summary>
		/// name_1の最大値
		/// </summary>
		public const UInt32 name_1_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名1
		/// </summary>
		public UInt32 name_1 {
			get { return ( this.__bitfield7 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_2の最大値
		/// </summary>
		public const UInt32 name_2_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名2
		/// </summary>
		public UInt32 name_2 {
			get { return ( this.__bitfield7 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// name_3の最大値
		/// </summary>
		public const UInt32 name_3_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名3
		/// </summary>
		public UInt32 name_3 {
			get { return ( this.__bitfield7 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// name_4の最大値
		/// </summary>
		public const UInt32 name_4_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名4
		/// </summary>
		public UInt32 name_4 {
			get { return ( this.__bitfield7 >> 24 ) & 0x000000ff;  }
			set {
				if( value > name_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		/// <summary>
		/// name_5の最大値
		/// </summary>
		public const UInt32 name_5_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名5
		/// </summary>
		public UInt32 name_5 {
			get { return ( this.__bitfield8 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_6の最大値
		/// </summary>
		public const UInt32 name_6_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名6
		/// </summary>
		public UInt32 name_6 {
			get { return ( this.__bitfield8 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// name_7の最大値
		/// </summary>
		public const UInt32 name_7_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名7
		/// </summary>
		public UInt32 name_7 {
			get { return ( this.__bitfield8 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// name_8の最大値
		/// </summary>
		public const UInt32 name_8_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名8
		/// </summary>
		public UInt32 name_8 {
			get { return ( this.__bitfield8 >> 24 ) & 0x000000ff;  }
			set {
				if( value > name_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		/// <summary>
		/// name_9の最大値
		/// </summary>
		public const UInt32 name_9_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名9
		/// </summary>
		public UInt32 name_9 {
			get { return ( this.__bitfield9 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_10の最大値
		/// </summary>
		public const UInt32 name_10_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名10
		/// </summary>
		public UInt32 name_10 {
			get { return ( this.__bitfield9 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// name_11の最大値
		/// </summary>
		public const UInt32 name_11_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名11
		/// </summary>
		public UInt32 name_11 {
			get { return ( this.__bitfield9 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// name_12の最大値
		/// </summary>
		public const UInt32 name_12_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名12
		/// </summary>
		public UInt32 name_12 {
			get { return ( this.__bitfield9 >> 24 ) & 0x000000ff;  }
			set {
				if( value > name_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		/// <summary>
		/// name_13の最大値
		/// </summary>
		public const UInt32 name_13_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名13
		/// </summary>
		public UInt32 name_13 {
			get { return ( this.__bitfield10 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield10 = ( this.__bitfield10 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_14の最大値
		/// </summary>
		public const UInt32 name_14_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 系統名14
		/// </summary>
		public UInt32 name_14 {
			get { return ( this.__bitfield10 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield10 = ( this.__bitfield10 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// padding_4の最大値
		/// </summary>
		public const UInt32 padding_4_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// padding_4
		/// </summary>
		public UInt32 padding_4 {
			get { return ( this.__bitfield10 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > padding_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield10 = ( this.__bitfield10 & 0x0000ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("family_line_num"), 8, 255, "親系統(自身を指せば親昇格)", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("family_line_attr"), 2, 3, "系統特性", "0=無し 1=スピード 2=スタミナ 3=未定義" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("eikyouryoku"), 1, 1, "影響力", "0=影響力弱 1=影響力強" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("bms_O"), 1, 1, "母父○", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("padding_1"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("blood_num"), 15, 32767, "血統ポインタ", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("padding_2"), 4, 15, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("share_J"), 10, 1023, "支配率(日本)", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("share_U"), 10, 1023, "支配率(米国)", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("share_E"), 10, 1023, "支配率(欧州)", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("padding_3"), 2, 3, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_1_num"), 8, 255, "ニックス1系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_1_share"), 8, 255, "ニックス1繁栄度", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_2_num"), 8, 255, "ニックス2系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_2_share"), 8, 255, "ニックス2繁栄度", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_3_num"), 8, 255, "ニックス3系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_3_share"), 8, 255, "ニックス3繁栄度", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_4_num"), 8, 255, "ニックス4系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_4_share"), 8, 255, "ニックス4繁栄度", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_5_num"), 8, 255, "ニックス5系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_5_share"), 8, 255, "ニックス5繁栄度", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_6_num"), 8, 255, "ニックス6系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_6_share"), 8, 255, "ニックス6繁栄度", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_7_num"), 8, 255, "ニックス7系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_7_share"), 8, 255, "ニックス7繁栄度", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_8_num"), 8, 255, "ニックス8系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_8_share"), 8, 255, "ニックス8繁栄度", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_9_num"), 8, 255, "ニックス9系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_9_share"), 8, 255, "ニックス9繁栄度", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_10_num"), 8, 255, "ニックス10系統", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("nicks_10_share"), 8, 255, "ニックス10繁栄度", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_1"), 8, 255, "系統名1", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_2"), 8, 255, "系統名2", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_3"), 8, 255, "系統名3", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_4"), 8, 255, "系統名4", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_5"), 8, 255, "系統名5", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_6"), 8, 255, "系統名6", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_7"), 8, 255, "系統名7", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_8"), 8, 255, "系統名8", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_9"), 8, 255, "系統名9", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_10"), 8, 255, "系統名10", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_11"), 8, 255, "系統名11", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_12"), 8, 255, "系統名12", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_13"), 8, 255, "系統名13", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("name_14"), 8, 255, "系統名14", "" ),
				new DataStructPropertyInfo( typeof(HFamilyLineData).GetProperty("padding_4"), 16, 65535, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[11];
			data[0] = data[0] | ( this.family_line_num << 0 ) ;
			data[0] = data[0] | ( this.family_line_attr << 8 ) ;
			data[0] = data[0] | ( this.eikyouryoku << 10 ) ;
			data[0] = data[0] | ( this.bms_O << 11 ) ;
			data[0] = data[0] | ( this.padding_1 << 12 ) ;
			data[0] = data[0] | ( this.blood_num << 13 ) ;
			data[0] = data[0] | ( this.padding_2 << 28 ) ;
			data[1] = data[1] | ( this.share_J << 0 ) ;
			data[1] = data[1] | ( this.share_U << 10 ) ;
			data[1] = data[1] | ( this.share_E << 20 ) ;
			data[1] = data[1] | ( this.padding_3 << 30 ) ;
			data[2] = data[2] | ( this.nicks_1_num << 0 ) ;
			data[2] = data[2] | ( this.nicks_1_share << 8 ) ;
			data[2] = data[2] | ( this.nicks_2_num << 16 ) ;
			data[2] = data[2] | ( this.nicks_2_share << 24 ) ;
			data[3] = data[3] | ( this.nicks_3_num << 0 ) ;
			data[3] = data[3] | ( this.nicks_3_share << 8 ) ;
			data[3] = data[3] | ( this.nicks_4_num << 16 ) ;
			data[3] = data[3] | ( this.nicks_4_share << 24 ) ;
			data[4] = data[4] | ( this.nicks_5_num << 0 ) ;
			data[4] = data[4] | ( this.nicks_5_share << 8 ) ;
			data[4] = data[4] | ( this.nicks_6_num << 16 ) ;
			data[4] = data[4] | ( this.nicks_6_share << 24 ) ;
			data[5] = data[5] | ( this.nicks_7_num << 0 ) ;
			data[5] = data[5] | ( this.nicks_7_share << 8 ) ;
			data[5] = data[5] | ( this.nicks_8_num << 16 ) ;
			data[5] = data[5] | ( this.nicks_8_share << 24 ) ;
			data[6] = data[6] | ( this.nicks_9_num << 0 ) ;
			data[6] = data[6] | ( this.nicks_9_share << 8 ) ;
			data[6] = data[6] | ( this.nicks_10_num << 16 ) ;
			data[6] = data[6] | ( this.nicks_10_share << 24 ) ;
			data[7] = data[7] | ( this.name_1 << 0 ) ;
			data[7] = data[7] | ( this.name_2 << 8 ) ;
			data[7] = data[7] | ( this.name_3 << 16 ) ;
			data[7] = data[7] | ( this.name_4 << 24 ) ;
			data[8] = data[8] | ( this.name_5 << 0 ) ;
			data[8] = data[8] | ( this.name_6 << 8 ) ;
			data[8] = data[8] | ( this.name_7 << 16 ) ;
			data[8] = data[8] | ( this.name_8 << 24 ) ;
			data[9] = data[9] | ( this.name_9 << 0 ) ;
			data[9] = data[9] | ( this.name_10 << 8 ) ;
			data[9] = data[9] | ( this.name_11 << 16 ) ;
			data[9] = data[9] | ( this.name_12 << 24 ) ;
			data[10] = data[10] | ( this.name_13 << 0 ) ;
			data[10] = data[10] | ( this.name_14 << 8 ) ;
			data[10] = data[10] | ( this.padding_4 << 16 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HFamilyLineData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 11 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 11)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
			this.__bitfield5 = data[5];
			this.__bitfield6 = data[6];
			this.__bitfield7 = data[7];
			this.__bitfield8 = data[8];
			this.__bitfield9 = data[9];
			this.__bitfield10 = data[10];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 11;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HAblData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// speedの最大値
		/// </summary>
		public const UInt32 speed_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// スピード
		/// </summary>
		public UInt32 speed {
			get { return ( this.__bitfield0 >> 0 ) & 0x0000007f;  }
			set {
				if( value > speed_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// staminaの最大値
		/// </summary>
		public const UInt32 stamina_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// スタミナ
		/// </summary>
		public UInt32 stamina {
			get { return ( this.__bitfield0 >> 7 ) & 0x0000007f;  }
			set {
				if( value > stamina_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// healthの最大値
		/// </summary>
		public const UInt32 health_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 健康
		/// </summary>
		public UInt32 health {
			get { return ( this.__bitfield0 >> 14 ) & 0x00000003;  }
			set {
				if( value > health_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffff3fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// kodashiの最大値
		/// </summary>
		public const UInt32 kodashi_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 仔出し
		/// </summary>
		public UInt32 kodashi {
			get { return ( this.__bitfield0 >> 16 ) & 0x0000000f;  }
			set {
				if( value > kodashi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfff0ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// taikouの最大値
		/// </summary>
		public const UInt32 taikou_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 体高
		/// </summary>
		public UInt32 taikou {
			get { return ( this.__bitfield0 >> 20 ) & 0x00000003;  }
			set {
				if( value > taikou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffcfffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// powerの最大値
		/// </summary>
		public const UInt32 power_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// パワー
		/// </summary>
		public UInt32 power {
			get { return ( this.__bitfield0 >> 22 ) & 0x00000003;  }
			set {
				if( value > power_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xff3fffff ) | ( value << 22 );
			}
		}
		/// <summary>
		/// zyuunanの最大値
		/// </summary>
		public const UInt32 zyuunan_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 柔軟性
		/// </summary>
		public UInt32 zyuunan {
			get { return ( this.__bitfield0 >> 24 ) & 0x00000003;  }
			set {
				if( value > zyuunan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfcffffff ) | ( value << 24 );
			}
		}
		/// <summary>
		/// syunpatsuの最大値
		/// </summary>
		public const UInt32 syunpatsu_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 瞬発力
		/// </summary>
		public UInt32 syunpatsu {
			get { return ( this.__bitfield0 >> 26 ) & 0x00000003;  }
			set {
				if( value > syunpatsu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf3ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// konzyouの最大値
		/// </summary>
		public const UInt32 konzyou_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 勝負根性
		/// </summary>
		public UInt32 konzyou {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000003;  }
			set {
				if( value > konzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xcfffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// kashikosaの最大値
		/// </summary>
		public const UInt32 kashikosa_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 賢さ
		/// </summary>
		public UInt32 kashikosa {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000003;  }
			set {
				if( value > kashikosa_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// babatekiseiの最大値
		/// </summary>
		public const UInt32 babatekisei_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 馬場適性
		/// </summary>
		public UInt32 babatekisei {
			get { return ( this.__bitfield1 >> 0 ) & 0x00000003;  }
			set {
				if( value > babatekisei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffffc ) | ( value << 0 );
			}
		}
		/// <summary>
		/// bokuzyouの最大値
		/// </summary>
		public const UInt32 bokuzyou_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 繁養牧場
		/// </summary>
		public UInt32 bokuzyou {
			get { return ( this.__bitfield1 >> 2 ) & 0x000000ff;  }
			set {
				if( value > bokuzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc03 ) | ( value << 2 );
			}
		}
		/// <summary>
		/// zenchouの最大値
		/// </summary>
		public const UInt32 zenchou_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 全長
		/// </summary>
		public UInt32 zenchou {
			get { return ( this.__bitfield1 >> 10 ) & 0x00000003;  }
			set {
				if( value > zenchou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffff3ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// keiroの最大値
		/// </summary>
		public const UInt32 keiro_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 毛色
		/// </summary>
		public UInt32 keiro {
			get { return ( this.__bitfield1 >> 12 ) & 0x0000000f;  }
			set {
				if( value > keiro_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffff0fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// ryuuseiの最大値
		/// </summary>
		public const UInt32 ryuusei_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 星・流星
		/// </summary>
		public UInt32 ryuusei {
			get { return ( this.__bitfield1 >> 16 ) & 0x0000001f;  }
			set {
				if( value > ryuusei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffe0ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// seishinの最大値
		/// </summary>
		public const UInt32 seishin_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 精神力
		/// </summary>
		public UInt32 seishin {
			get { return ( this.__bitfield1 >> 21 ) & 0x00000003;  }
			set {
				if( value > seishin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff9fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// seichougataの最大値
		/// </summary>
		public const UInt32 seichougata_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 成長型
		/// </summary>
		public UInt32 seichougata {
			get { return ( this.__bitfield1 >> 23 ) & 0x00000007;  }
			set {
				if( value > seichougata_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfc7fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// seichouryokuの最大値
		/// </summary>
		public const UInt32 seichouryoku_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 成長力
		/// </summary>
		public UInt32 seichouryoku {
			get { return ( this.__bitfield1 >> 26 ) & 0x00000003;  }
			set {
				if( value > seichouryoku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf3ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// kisyouの最大値
		/// </summary>
		public const UInt32 kisyou_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 気性
		/// </summary>
		public UInt32 kisyou {
			get { return ( this.__bitfield1 >> 28 ) & 0x00000007;  }
			set {
				if( value > kisyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0x8fffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 08_8
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// seisankokuの最大値
		/// </summary>
		public const UInt32 seisankoku_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 生産国
		/// </summary>
		public UInt32 seisankoku {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000000f;  }
			set {
				if( value > seisankoku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffff0 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// right_flontの最大値
		/// </summary>
		public const UInt32 right_flont_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 右前足模様
		/// </summary>
		public UInt32 right_flont {
			get { return ( this.__bitfield2 >> 4 ) & 0x00000003;  }
			set {
				if( value > right_flont_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffffcf ) | ( value << 4 );
			}
		}
		/// <summary>
		/// left_flontの最大値
		/// </summary>
		public const UInt32 left_flont_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 左前足模様
		/// </summary>
		public UInt32 left_flont {
			get { return ( this.__bitfield2 >> 6 ) & 0x00000003;  }
			set {
				if( value > left_flont_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff3f ) | ( value << 6 );
			}
		}
		/// <summary>
		/// right_hindの最大値
		/// </summary>
		public const UInt32 right_hind_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 右後足模様
		/// </summary>
		public UInt32 right_hind {
			get { return ( this.__bitfield2 >> 8 ) & 0x00000003;  }
			set {
				if( value > right_hind_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffcff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// left_hindeの最大値
		/// </summary>
		public const UInt32 left_hinde_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 左後足模様
		/// </summary>
		public UInt32 left_hinde {
			get { return ( this.__bitfield2 >> 10 ) & 0x00000003;  }
			set {
				if( value > left_hinde_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffff3ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// senpouの最大値
		/// </summary>
		public const UInt32 senpou_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 脚質
		/// </summary>
		public UInt32 senpou {
			get { return ( this.__bitfield2 >> 12 ) & 0x00000007;  }
			set {
				if( value > senpou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// komawari_Xの最大値
		/// </summary>
		public const UInt32 komawari_X_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 小回り
		/// </summary>
		public UInt32 komawari_X {
			get { return ( this.__bitfield2 >> 15 ) & 0x00000001;  }
			set {
				if( value > komawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff7fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// tokusei_1の最大値
		/// </summary>
		public const UInt32 tokusei_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 大舞台
		/// </summary>
		public UInt32 tokusei_1 {
			get { return ( this.__bitfield2 >> 16 ) & 0x00000001;  }
			set {
				if( value > tokusei_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffeffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// tokusei_2の最大値
		/// </summary>
		public const UInt32 tokusei_2_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// ＧⅡ横綱
		/// </summary>
		public UInt32 tokusei_2 {
			get { return ( this.__bitfield2 >> 17 ) & 0x00000001;  }
			set {
				if( value > tokusei_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffdffff ) | ( value << 17 );
			}
		}
		/// <summary>
		/// tokusei_3の最大値
		/// </summary>
		public const UInt32 tokusei_3_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 交流重賞
		/// </summary>
		public UInt32 tokusei_3 {
			get { return ( this.__bitfield2 >> 18 ) & 0x00000001;  }
			set {
				if( value > tokusei_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffbffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// tokusei_4の最大値
		/// </summary>
		public const UInt32 tokusei_4_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// ローカル
		/// </summary>
		public UInt32 tokusei_4 {
			get { return ( this.__bitfield2 >> 19 ) & 0x00000001;  }
			set {
				if( value > tokusei_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfff7ffff ) | ( value << 19 );
			}
		}
		/// <summary>
		/// tokusei_5の最大値
		/// </summary>
		public const UInt32 tokusei_5_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// スタート
		/// </summary>
		public UInt32 tokusei_5 {
			get { return ( this.__bitfield2 >> 20 ) & 0x00000001;  }
			set {
				if( value > tokusei_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffefffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// tokusei_6の最大値
		/// </summary>
		public const UInt32 tokusei_6_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 超長距離
		/// </summary>
		public UInt32 tokusei_6 {
			get { return ( this.__bitfield2 >> 21 ) & 0x00000001;  }
			set {
				if( value > tokusei_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffdfffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// tokusei_7の最大値
		/// </summary>
		public const UInt32 tokusei_7_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// タフネス
		/// </summary>
		public UInt32 tokusei_7 {
			get { return ( this.__bitfield2 >> 22 ) & 0x00000001;  }
			set {
				if( value > tokusei_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffbfffff ) | ( value << 22 );
			}
		}
		/// <summary>
		/// tokusei_8の最大値
		/// </summary>
		public const UInt32 tokusei_8_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 海外遠征
		/// </summary>
		public UInt32 tokusei_8 {
			get { return ( this.__bitfield2 >> 23 ) & 0x00000001;  }
			set {
				if( value > tokusei_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xff7fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// tokusei_9の最大値
		/// </summary>
		public const UInt32 tokusei_9_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 男勝り
		/// </summary>
		public UInt32 tokusei_9 {
			get { return ( this.__bitfield2 >> 24 ) & 0x00000001;  }
			set {
				if( value > tokusei_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfeffffff ) | ( value << 24 );
			}
		}
		/// <summary>
		/// tokusei_10の最大値
		/// </summary>
		public const UInt32 tokusei_10_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 夏馬
		/// </summary>
		public UInt32 tokusei_10 {
			get { return ( this.__bitfield2 >> 25 ) & 0x00000001;  }
			set {
				if( value > tokusei_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfdffffff ) | ( value << 25 );
			}
		}
		/// <summary>
		/// tokusei_11の最大値
		/// </summary>
		public const UInt32 tokusei_11_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 軽ハンデ
		/// </summary>
		public UInt32 tokusei_11 {
			get { return ( this.__bitfield2 >> 26 ) & 0x00000001;  }
			set {
				if( value > tokusei_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfbffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// tokusei_12の最大値
		/// </summary>
		public const UInt32 tokusei_12_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 格上挑戦
		/// </summary>
		public UInt32 tokusei_12 {
			get { return ( this.__bitfield2 >> 27 ) & 0x00000001;  }
			set {
				if( value > tokusei_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xf7ffffff ) | ( value << 27 );
			}
		}
		/// <summary>
		/// tokusei_13の最大値
		/// </summary>
		public const UInt32 tokusei_13_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 乾坤一擲
		/// </summary>
		public UInt32 tokusei_13 {
			get { return ( this.__bitfield2 >> 28 ) & 0x00000001;  }
			set {
				if( value > tokusei_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// tokusei_14の最大値
		/// </summary>
		public const UInt32 tokusei_14_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 大駆け
		/// </summary>
		public UInt32 tokusei_14 {
			get { return ( this.__bitfield2 >> 29 ) & 0x00000001;  }
			set {
				if( value > tokusei_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xdfffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// tokusei_15の最大値
		/// </summary>
		public const UInt32 tokusei_15_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 鉄砲
		/// </summary>
		public UInt32 tokusei_15 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000001;  }
			set {
				if( value > tokusei_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// tokusei_16の最大値
		/// </summary>
		public const UInt32 tokusei_16_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 叩き良化
		/// </summary>
		public UInt32 tokusei_16 {
			get { return ( this.__bitfield2 >> 31 ) & 0x00000001;  }
			set {
				if( value > tokusei_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0x7fffffff ) | ( value << 31 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("speed"), 7, 127, "スピード", "C=60 B=65 A=70 S=75" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("stamina"), 7, 127, "スタミナ", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("health"), 2, 3, "健康", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("kodashi"), 4, 15, "仔出し", "高いほど能力の高い馬が生みやすい" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("taikou"), 2, 3, "体高", "0低 1普 2高" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("power"), 2, 3, "パワー", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("zyuunan"), 2, 3, "柔軟性", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("syunpatsu"), 2, 3, "瞬発力", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("konzyou"), 2, 3, "勝負根性", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("kashikosa"), 2, 3, "賢さ", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("babatekisei"), 2, 3, "馬場適性", "0=芝 1=万能 2=ダート" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("bokuzyou"), 8, 255, "繁養牧場", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("zenchou"), 2, 3, "全長", "0=短い 1=普通 2=長い" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("keiro"), 4, 15, "毛色", "0鹿毛 1黒鹿毛 2栗毛 3栃栗毛 4青鹿毛 5青毛 6芦毛黒 7芦毛灰 8芦毛白 9白毛 10尾花栗毛" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("ryuusei"), 5, 31, "星・流星", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("seishin"), 2, 3, "精神力", "サブパラ\r\n0=C 1=B 2=A 3=S" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("seichougata"), 3, 7, "成長型", "0早熟 1普通早 2普通遅 3晩成 4超晩成 5早熟鍋 6普通鍋" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("seichouryoku"), 2, 3, "成長力", "0=無し 1=普通 2=あり 3=持続" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("kisyou"), 3, 7, "気性", "0=激2 1=激 2=荒い 3=普通 4=大人" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("padding_1"), 1, 1, "08_8", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("seisankoku"), 4, 15, "生産国", "0日本 1米国 2英国 3愛国 4仏国 5豪州 6独国 7伊国 8香港 9UAE 10加国 11南米" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("right_flont"), 2, 3, "右前足模様", "0=無し 1=小 2=中 3=大" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("left_flont"), 2, 3, "左前足模様", "0=無し 1=小 2=中 3=大" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("right_hind"), 2, 3, "右後足模様", "0=無し 1=小 2=中 3=大" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("left_hinde"), 2, 3, "左後足模様", "0=無し 1=小 2=中 3=大" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("senpou"), 3, 7, "脚質", "0大逃げ 1逃げ 2先行 3差し 4追込 5自在先行 6自在差し 7自在" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("komawari_X"), 1, 1, "小回り", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_1"), 1, 1, "大舞台", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_2"), 1, 1, "ＧⅡ横綱", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_3"), 1, 1, "交流重賞", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_4"), 1, 1, "ローカル", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_5"), 1, 1, "スタート", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_6"), 1, 1, "超長距離", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_7"), 1, 1, "タフネス", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_8"), 1, 1, "海外遠征", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_9"), 1, 1, "男勝り", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_10"), 1, 1, "夏馬", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_11"), 1, 1, "軽ハンデ", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_12"), 1, 1, "格上挑戦", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_13"), 1, 1, "乾坤一擲", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_14"), 1, 1, "大駆け", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_15"), 1, 1, "鉄砲", "" ),
				new DataStructPropertyInfo( typeof(HAblData).GetProperty("tokusei_16"), 1, 1, "叩き良化", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[3];
			data[0] = data[0] | ( this.speed << 0 ) ;
			data[0] = data[0] | ( this.stamina << 7 ) ;
			data[0] = data[0] | ( this.health << 14 ) ;
			data[0] = data[0] | ( this.kodashi << 16 ) ;
			data[0] = data[0] | ( this.taikou << 20 ) ;
			data[0] = data[0] | ( this.power << 22 ) ;
			data[0] = data[0] | ( this.zyuunan << 24 ) ;
			data[0] = data[0] | ( this.syunpatsu << 26 ) ;
			data[0] = data[0] | ( this.konzyou << 28 ) ;
			data[0] = data[0] | ( this.kashikosa << 30 ) ;
			data[1] = data[1] | ( this.babatekisei << 0 ) ;
			data[1] = data[1] | ( this.bokuzyou << 2 ) ;
			data[1] = data[1] | ( this.zenchou << 10 ) ;
			data[1] = data[1] | ( this.keiro << 12 ) ;
			data[1] = data[1] | ( this.ryuusei << 16 ) ;
			data[1] = data[1] | ( this.seishin << 21 ) ;
			data[1] = data[1] | ( this.seichougata << 23 ) ;
			data[1] = data[1] | ( this.seichouryoku << 26 ) ;
			data[1] = data[1] | ( this.kisyou << 28 ) ;
			data[1] = data[1] | ( this.padding_1 << 31 ) ;
			data[2] = data[2] | ( this.seisankoku << 0 ) ;
			data[2] = data[2] | ( this.right_flont << 4 ) ;
			data[2] = data[2] | ( this.left_flont << 6 ) ;
			data[2] = data[2] | ( this.right_hind << 8 ) ;
			data[2] = data[2] | ( this.left_hinde << 10 ) ;
			data[2] = data[2] | ( this.senpou << 12 ) ;
			data[2] = data[2] | ( this.komawari_X << 15 ) ;
			data[2] = data[2] | ( this.tokusei_1 << 16 ) ;
			data[2] = data[2] | ( this.tokusei_2 << 17 ) ;
			data[2] = data[2] | ( this.tokusei_3 << 18 ) ;
			data[2] = data[2] | ( this.tokusei_4 << 19 ) ;
			data[2] = data[2] | ( this.tokusei_5 << 20 ) ;
			data[2] = data[2] | ( this.tokusei_6 << 21 ) ;
			data[2] = data[2] | ( this.tokusei_7 << 22 ) ;
			data[2] = data[2] | ( this.tokusei_8 << 23 ) ;
			data[2] = data[2] | ( this.tokusei_9 << 24 ) ;
			data[2] = data[2] | ( this.tokusei_10 << 25 ) ;
			data[2] = data[2] | ( this.tokusei_11 << 26 ) ;
			data[2] = data[2] | ( this.tokusei_12 << 27 ) ;
			data[2] = data[2] | ( this.tokusei_13 << 28 ) ;
			data[2] = data[2] | ( this.tokusei_14 << 29 ) ;
			data[2] = data[2] | ( this.tokusei_15 << 30 ) ;
			data[2] = data[2] | ( this.tokusei_16 << 31 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HAblData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 3 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 3)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 3;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HDamData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// priceの最大値
		/// </summary>
		public const UInt32 price_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 評価額
		/// </summary>
		public UInt32 price {
			get { return ( this.__bitfield0 >> 0 ) & 0x000003ff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// tanetsuke_sireの最大値
		/// </summary>
		public const UInt32 tanetsuke_sire_MAXVALUE = 0x000007ff; // 2047
		/// <summary>
		/// 種付け種牡馬番号
		/// </summary>
		public UInt32 tanetsuke_sire {
			get { return ( this.__bitfield0 >> 10 ) & 0x000007ff;  }
			set {
				if( value > tanetsuke_sire_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffe003ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// padding_1
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield0 >> 21 ) & 0x0000007f;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf01fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// fuda_colorの最大値
		/// </summary>
		public const UInt32 fuda_color_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 札
		/// </summary>
		public UInt32 fuda_color {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000007;  }
			set {
				if( value > fuda_color_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield0 = ( this.__bitfield0 & 0x8fffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield0 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// career_yearsの最大値
		/// </summary>
		public const UInt32 career_years_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 繁殖年数
		/// </summary>
		public UInt32 career_years {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000001f;  }
			set {
				if( value > career_years_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffe0 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield1 >> 5 ) & 0x0000001f;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc1f ) | ( value << 5 );
			}
		}
		/// <summary>
		/// career_countの最大値
		/// </summary>
		public const UInt32 career_count_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 出産頭数
		/// </summary>
		public UInt32 career_count {
			get { return ( this.__bitfield1 >> 10 ) & 0x0000000f;  }
			set {
				if( value > career_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffc3ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// statusの最大値
		/// </summary>
		public const UInt32 status_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 受胎確認 0空胎 1受胎 2不受胎 3未確認
		/// </summary>
		public UInt32 status {
			get { return ( this.__bitfield1 >> 14 ) & 0x00000003;  }
			set {
				if( value > status_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffff3fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// intaiの最大値
		/// </summary>
		public const UInt32 intai_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 引退？
		/// </summary>
		public UInt32 intai {
			get { return ( this.__bitfield1 >> 16 ) & 0x00000001;  }
			set {
				if( value > intai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffeffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// padding_4の最大値
		/// </summary>
		public const UInt32 padding_4_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_4
		/// </summary>
		public UInt32 padding_4 {
			get { return ( this.__bitfield1 >> 17 ) & 0x00000001;  }
			set {
				if( value > padding_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffdffff ) | ( value << 17 );
			}
		}
		/// <summary>
		/// g1_win_countの最大値
		/// </summary>
		public const UInt32 g1_win_count_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 現役時代G1勝ち数
		/// </summary>
		public UInt32 g1_win_count {
			get { return ( this.__bitfield1 >> 18 ) & 0x000000ff;  }
			set {
				if( value > g1_win_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfc03ffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// ageの最大値
		/// </summary>
		public const UInt32 age_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// +2歳
		/// </summary>
		public UInt32 age {
			get { return ( this.__bitfield1 >> 26 ) & 0x0000001f;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0x83ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// padding_5の最大値
		/// </summary>
		public const UInt32 padding_5_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_5
		/// </summary>
		public UInt32 padding_5 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// abl_numの最大値
		/// </summary>
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 能力番号
		/// </summary>
		public UInt32 abl_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// blood_numの最大値
		/// </summary>
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 血統番号
		/// </summary>
		public UInt32 blood_num {
			get { return ( this.__bitfield2 >> 15 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc0007fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// padding_6の最大値
		/// </summary>
		public const UInt32 padding_6_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_6
		/// </summary>
		public UInt32 padding_6 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > padding_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// kachikuraの最大値
		/// </summary>
		public const UInt32 kachikura_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 主な勝ち鞍
		/// </summary>
		public UInt32 kachikura {
			get { return ( this.__bitfield3 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffff000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// record_lenの最大値
		/// </summary>
		public const UInt32 record_len_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 競走成績 戦数
		/// </summary>
		public UInt32 record_len {
			get { return ( this.__bitfield3 >> 12 ) & 0x000000ff;  }
			set {
				if( value > record_len_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfff00fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// record_winの最大値
		/// </summary>
		public const UInt32 record_win_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 競走成績 勝数
		/// </summary>
		public UInt32 record_win {
			get { return ( this.__bitfield3 >> 20 ) & 0x000000ff;  }
			set {
				if( value > record_win_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xf00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_7の最大値
		/// </summary>
		public const UInt32 padding_7_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_7
		/// </summary>
		public UInt32 padding_7 {
			get { return ( this.__bitfield3 >> 28 ) & 0x0000000f;  }
			set {
				if( value > padding_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield3 = ( this.__bitfield3 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// shizitsu_numの最大値
		/// </summary>
		public const UInt32 shizitsu_num_MAXVALUE = 0x00001fff; // 8191
		/// <summary>
		/// 史実番号
		/// </summary>
		public UInt32 shizitsu_num {
			get { return ( this.__bitfield4 >> 0 ) & 0x00001fff;  }
			set {
				if( value > shizitsu_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffe000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_8の最大値
		/// </summary>
		public const UInt32 padding_8_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_8
		/// </summary>
		public UInt32 padding_8 {
			get { return ( this.__bitfield4 >> 13 ) & 0x00000003;  }
			set {
				if( value > padding_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff9fff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// preg_shizitsu_numの最大値
		/// </summary>
		public const UInt32 preg_shizitsu_num_MAXVALUE = 0x00001fff; // 8191
		/// <summary>
		/// 受胎中の史実番号
		/// </summary>
		public UInt32 preg_shizitsu_num {
			get { return ( this.__bitfield4 >> 15 ) & 0x00001fff;  }
			set {
				if( value > preg_shizitsu_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield4 = ( this.__bitfield4 & 0xf0007fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// padding_9の最大値
		/// </summary>
		public const UInt32 padding_9_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_9
		/// </summary>
		public UInt32 padding_9 {
			get { return ( this.__bitfield4 >> 28 ) & 0x0000000f;  }
			set {
				if( value > padding_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield4 = ( this.__bitfield4 & 0x0fffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("price"), 10, 1023, "評価額", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("tanetsuke_sire"), 11, 2047, "種付け種牡馬番号", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_1"), 7, 127, "", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("fuda_color"), 3, 7, "札", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_2"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("career_years"), 5, 31, "繁殖年数", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_3"), 5, 31, "", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("career_count"), 4, 15, "出産頭数", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("status"), 2, 3, "受胎確認 0空胎 1受胎 2不受胎 3未確認", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("intai"), 1, 1, "引退？", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_4"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("g1_win_count"), 8, 255, "現役時代G1勝ち数", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("age"), 5, 31, "+2歳", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_5"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("abl_num"), 15, 32767, "能力番号", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("blood_num"), 15, 32767, "血統番号", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_6"), 2, 3, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("kachikura"), 12, 4095, "主な勝ち鞍", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("record_len"), 8, 255, "競走成績 戦数", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("record_win"), 8, 255, "競走成績 勝数", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_7"), 4, 15, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("shizitsu_num"), 13, 8191, "史実番号", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_8"), 2, 3, "", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("preg_shizitsu_num"), 13, 8191, "受胎中の史実番号", "" ),
				new DataStructPropertyInfo( typeof(HDamData).GetProperty("padding_9"), 4, 15, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[5];
			data[0] = data[0] | ( this.price << 0 ) ;
			data[0] = data[0] | ( this.tanetsuke_sire << 10 ) ;
			data[0] = data[0] | ( this.padding_1 << 21 ) ;
			data[0] = data[0] | ( this.fuda_color << 28 ) ;
			data[0] = data[0] | ( this.padding_2 << 31 ) ;
			data[1] = data[1] | ( this.career_years << 0 ) ;
			data[1] = data[1] | ( this.padding_3 << 5 ) ;
			data[1] = data[1] | ( this.career_count << 10 ) ;
			data[1] = data[1] | ( this.status << 14 ) ;
			data[1] = data[1] | ( this.intai << 16 ) ;
			data[1] = data[1] | ( this.padding_4 << 17 ) ;
			data[1] = data[1] | ( this.g1_win_count << 18 ) ;
			data[1] = data[1] | ( this.age << 26 ) ;
			data[1] = data[1] | ( this.padding_5 << 31 ) ;
			data[2] = data[2] | ( this.abl_num << 0 ) ;
			data[2] = data[2] | ( this.blood_num << 15 ) ;
			data[2] = data[2] | ( this.padding_6 << 30 ) ;
			data[3] = data[3] | ( this.kachikura << 0 ) ;
			data[3] = data[3] | ( this.record_len << 12 ) ;
			data[3] = data[3] | ( this.record_win << 20 ) ;
			data[3] = data[3] | ( this.padding_7 << 28 ) ;
			data[4] = data[4] | ( this.shizitsu_num << 0 ) ;
			data[4] = data[4] | ( this.padding_8 << 13 ) ;
			data[4] = data[4] | ( this.preg_shizitsu_num << 15 ) ;
			data[4] = data[4] | ( this.padding_9 << 28 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HDamData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 5 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 5)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 5;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HSireData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// win_grade_countの最大値
		/// </summary>
		public const UInt32 win_grade_count_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 産駒重賞勝ち
		/// </summary>
		public UInt32 win_grade_count {
			get { return ( this.__bitfield0 >> 0 ) & 0x000003ff;  }
			set {
				if( value > win_grade_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// win_g1_countの最大値
		/// </summary>
		public const UInt32 win_g1_count_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 産駒G1勝ち
		/// </summary>
		public UInt32 win_g1_count {
			get { return ( this.__bitfield0 >> 10 ) & 0x000003ff;  }
			set {
				if( value > win_g1_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfff003ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// tanetsukeの最大値
		/// </summary>
		public const UInt32 tanetsuke_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 種付け料
		/// </summary>
		public UInt32 tanetsuke {
			get { return ( this.__bitfield0 >> 20 ) & 0x0000007f;  }
			set {
				if( value > tanetsuke_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf80fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// padding_1
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield0 >> 27 ) & 0x0000001f;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield0 = ( this.__bitfield0 & 0x07ffffff ) | ( value << 27 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x007fffff; // 8388607
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield1 >> 0 ) & 0x007fffff;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8388607)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff800000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// record_lenの最大値
		/// </summary>
		public const UInt32 record_len_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 出走数
		/// </summary>
		public UInt32 record_len {
			get { return ( this.__bitfield1 >> 23 ) & 0x000000ff;  }
			set {
				if( value > record_len_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0x807fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// abl_numの最大値
		/// </summary>
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 能力番号
		/// </summary>
		public UInt32 abl_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// blood_numの最大値
		/// </summary>
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 血統番号
		/// </summary>
		public UInt32 blood_num {
			get { return ( this.__bitfield2 >> 15 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc0007fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// intaiの最大値
		/// </summary>
		public const UInt32 intai_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 引退？
		/// </summary>
		public UInt32 intai {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > intai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// syoukinの最大値
		/// </summary>
		public const UInt32 syoukin_MAXVALUE = 0x000fffff; // 1048575
		/// <summary>
		/// 獲得賞金
		/// </summary>
		public UInt32 syoukin {
			get { return ( this.__bitfield3 >> 0 ) & 0x000fffff;  }
			set {
				if( value > syoukin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfff00000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// ageの最大値
		/// </summary>
		public const UInt32 age_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// 馬齢
		/// </summary>
		public UInt32 age {
			get { return ( this.__bitfield3 >> 20 ) & 0x0000003f;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfc0fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_4の最大値
		/// </summary>
		public const UInt32 padding_4_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// padding_4
		/// </summary>
		public UInt32 padding_4 {
			get { return ( this.__bitfield3 >> 26 ) & 0x0000003f;  }
			set {
				if( value > padding_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0x03ffffff ) | ( value << 26 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// padding_5の最大値
		/// </summary>
		public const UInt32 padding_5_MAXVALUE = 0x000fffff; // 1048575
		/// <summary>
		/// padding_5
		/// </summary>
		public UInt32 padding_5 {
			get { return ( this.__bitfield4 >> 0 ) & 0x000fffff;  }
			set {
				if( value > padding_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfff00000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// record_winの最大値
		/// </summary>
		public const UInt32 record_win_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 勝利回数
		/// </summary>
		public UInt32 record_win {
			get { return ( this.__bitfield4 >> 20 ) & 0x000000ff;  }
			set {
				if( value > record_win_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xf00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_6の最大値
		/// </summary>
		public const UInt32 padding_6_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_6
		/// </summary>
		public UInt32 padding_6 {
			get { return ( this.__bitfield4 >> 28 ) & 0x0000000f;  }
			set {
				if( value > padding_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield4 = ( this.__bitfield4 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		/// <summary>
		/// padding_7の最大値
		/// </summary>
		public const UInt32 padding_7_MAXVALUE = 0x0fffffff; // 268435455
		/// <summary>
		/// padding_7
		/// </summary>
		public UInt32 padding_7 {
			get { return ( this.__bitfield5 >> 0 ) & 0x0fffffff;  }
			set {
				if( value > padding_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-268435455)");
				this.__bitfield5 = ( this.__bitfield5 & 0xf0000000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// bookfullの最大値
		/// </summary>
		public const UInt32 bookfull_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// BookFull
		/// </summary>
		public UInt32 bookfull {
			get { return ( this.__bitfield5 >> 28 ) & 0x00000001;  }
			set {
				if( value > bookfull_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield5 = ( this.__bitfield5 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// syndicateの最大値
		/// </summary>
		public const UInt32 syndicate_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// シンジケート
		/// </summary>
		public UInt32 syndicate {
			get { return ( this.__bitfield5 >> 29 ) & 0x00000001;  }
			set {
				if( value > syndicate_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield5 = ( this.__bitfield5 & 0xdfffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// padding_8の最大値
		/// </summary>
		public const UInt32 padding_8_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_8
		/// </summary>
		public UInt32 padding_8 {
			get { return ( this.__bitfield5 >> 30 ) & 0x00000003;  }
			set {
				if( value > padding_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield5 = ( this.__bitfield5 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		/// <summary>
		/// padding_9の最大値
		/// </summary>
		public const UInt32 padding_9_MAXVALUE = 0x000fffff; // 1048575
		/// <summary>
		/// padding_9
		/// </summary>
		public UInt32 padding_9 {
			get { return ( this.__bitfield6 >> 0 ) & 0x000fffff;  }
			set {
				if( value > padding_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield6 = ( this.__bitfield6 & 0xfff00000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// tanetsuke_countの最大値
		/// </summary>
		public const UInt32 tanetsuke_count_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 種付け数
		/// </summary>
		public UInt32 tanetsuke_count {
			get { return ( this.__bitfield6 >> 20 ) & 0x000000ff;  }
			set {
				if( value > tanetsuke_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xf00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_10の最大値
		/// </summary>
		public const UInt32 padding_10_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_10
		/// </summary>
		public UInt32 padding_10 {
			get { return ( this.__bitfield6 >> 28 ) & 0x0000000f;  }
			set {
				if( value > padding_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield6 = ( this.__bitfield6 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		/// <summary>
		/// padding_80の最大値
		/// </summary>
		public const UInt32 padding_80_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_80
		/// </summary>
		public UInt32 padding_80 {
			get { return ( this.__bitfield7 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_80_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield7 = ( this.__bitfield7 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		/// <summary>
		/// kachikura_LTの最大値
		/// </summary>
		public const UInt32 kachikura_LT_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 主な勝ち鞍(左上)
		/// </summary>
		public UInt32 kachikura_LT {
			get { return ( this.__bitfield8 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_LT_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield8 = ( this.__bitfield8 & 0xfffff000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// kachikura_LBの最大値
		/// </summary>
		public const UInt32 kachikura_LB_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 主な勝ち鞍(左下)
		/// </summary>
		public UInt32 kachikura_LB {
			get { return ( this.__bitfield8 >> 12 ) & 0x00000fff;  }
			set {
				if( value > kachikura_LB_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield8 = ( this.__bitfield8 & 0xff000fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// padding_12の最大値
		/// </summary>
		public const UInt32 padding_12_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// padding_12
		/// </summary>
		public UInt32 padding_12 {
			get { return ( this.__bitfield8 >> 24 ) & 0x000000ff;  }
			set {
				if( value > padding_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		/// <summary>
		/// kachikura_RTの最大値
		/// </summary>
		public const UInt32 kachikura_RT_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 主な勝ち鞍(右上)
		/// </summary>
		public UInt32 kachikura_RT {
			get { return ( this.__bitfield9 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_RT_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield9 = ( this.__bitfield9 & 0xfffff000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// kachikura_RBの最大値
		/// </summary>
		public const UInt32 kachikura_RB_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 主な勝ち鞍(右下)
		/// </summary>
		public UInt32 kachikura_RB {
			get { return ( this.__bitfield9 >> 12 ) & 0x00000fff;  }
			set {
				if( value > kachikura_RB_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield9 = ( this.__bitfield9 & 0xff000fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// youku1_countの最大値
		/// </summary>
		public const UInt32 youku1_count_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 1歳幼駒数
		/// </summary>
		public UInt32 youku1_count {
			get { return ( this.__bitfield9 >> 24 ) & 0x000000ff;  }
			set {
				if( value > youku1_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		/// <summary>
		/// daihyousan_w1の最大値
		/// </summary>
		public const UInt32 daihyousan_w1_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 代表産駒主な勝ち鞍(1)
		/// </summary>
		public UInt32 daihyousan_w1 {
			get { return ( this.__bitfield10 >> 0 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield10 = ( this.__bitfield10 & 0xfffff000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// daihyousan_w2の最大値
		/// </summary>
		public const UInt32 daihyousan_w2_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 代表産駒主な勝ち鞍(2)
		/// </summary>
		public UInt32 daihyousan_w2 {
			get { return ( this.__bitfield10 >> 12 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield10 = ( this.__bitfield10 & 0xff000fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// geneki_countの最大値
		/// </summary>
		public const UInt32 geneki_count_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 現役産駒数
		/// </summary>
		public UInt32 geneki_count {
			get { return ( this.__bitfield10 >> 24 ) & 0x000000ff;  }
			set {
				if( value > geneki_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield10 = ( this.__bitfield10 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 44 byte data
		[FieldOffset(44)] private UInt32 __bitfield11;
		/// <summary>
		/// daihyousan_w3の最大値
		/// </summary>
		public const UInt32 daihyousan_w3_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 代表産駒主な勝ち鞍(3)
		/// </summary>
		public UInt32 daihyousan_w3 {
			get { return ( this.__bitfield11 >> 0 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfffff000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// daihyousan_w4の最大値
		/// </summary>
		public const UInt32 daihyousan_w4_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// 代表産駒主な勝ち鞍(4)
		/// </summary>
		public UInt32 daihyousan_w4 {
			get { return ( this.__bitfield11 >> 12 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield11 = ( this.__bitfield11 & 0xff000fff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// rank_5_agoの最大値
		/// </summary>
		public const UInt32 rank_5_ago_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 5年前成績
		/// </summary>
		public UInt32 rank_5_ago {
			get { return ( this.__bitfield11 >> 24 ) & 0x000000ff;  }
			set {
				if( value > rank_5_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield11 = ( this.__bitfield11 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 48 byte data
		[FieldOffset(48)] private UInt32 __bitfield12;
		/// <summary>
		/// daihyousan_1の最大値
		/// </summary>
		public const UInt32 daihyousan_1_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// 代表産駒1
		/// </summary>
		public UInt32 daihyousan_1 {
			get { return ( this.__bitfield12 >> 0 ) & 0xffffffff;  }
			set {
				if( value > daihyousan_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield12 = ( this.__bitfield12 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 52 byte data
		[FieldOffset(52)] private UInt32 __bitfield13;
		/// <summary>
		/// daihyousan_2の最大値
		/// </summary>
		public const UInt32 daihyousan_2_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// 代表産駒2
		/// </summary>
		public UInt32 daihyousan_2 {
			get { return ( this.__bitfield13 >> 0 ) & 0xffffffff;  }
			set {
				if( value > daihyousan_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield13 = ( this.__bitfield13 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 56 byte data
		[FieldOffset(56)] private UInt32 __bitfield14;
		/// <summary>
		/// daihyousan_3の最大値
		/// </summary>
		public const UInt32 daihyousan_3_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// 代表産駒3
		/// </summary>
		public UInt32 daihyousan_3 {
			get { return ( this.__bitfield14 >> 0 ) & 0xffffffff;  }
			set {
				if( value > daihyousan_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield14 = ( this.__bitfield14 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 60 byte data
		[FieldOffset(60)] private UInt32 __bitfield15;
		/// <summary>
		/// daihyousan_4の最大値
		/// </summary>
		public const UInt32 daihyousan_4_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// 代表産駒4
		/// </summary>
		public UInt32 daihyousan_4 {
			get { return ( this.__bitfield15 >> 0 ) & 0xffffffff;  }
			set {
				if( value > daihyousan_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield15 = ( this.__bitfield15 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 64 byte data
		[FieldOffset(64)] private UInt32 __bitfield16;
		/// <summary>
		/// rank_1_agoの最大値
		/// </summary>
		public const UInt32 rank_1_ago_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 1年前成績
		/// </summary>
		public UInt32 rank_1_ago {
			get { return ( this.__bitfield16 >> 0 ) & 0x000000ff;  }
			set {
				if( value > rank_1_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// rank_2_agoの最大値
		/// </summary>
		public const UInt32 rank_2_ago_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 2年前成績
		/// </summary>
		public UInt32 rank_2_ago {
			get { return ( this.__bitfield16 >> 8 ) & 0x000000ff;  }
			set {
				if( value > rank_2_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// rank_3_agoの最大値
		/// </summary>
		public const UInt32 rank_3_ago_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 3年前成績
		/// </summary>
		public UInt32 rank_3_ago {
			get { return ( this.__bitfield16 >> 16 ) & 0x000000ff;  }
			set {
				if( value > rank_3_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// rank_4_agoの最大値
		/// </summary>
		public const UInt32 rank_4_ago_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 4年前成績
		/// </summary>
		public UInt32 rank_4_ago {
			get { return ( this.__bitfield16 >> 24 ) & 0x000000ff;  }
			set {
				if( value > rank_4_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 68 byte data
		[FieldOffset(68)] private UInt32 __bitfield17;
		/// <summary>
		/// padding_13の最大値
		/// </summary>
		public const UInt32 padding_13_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_13
		/// </summary>
		public UInt32 padding_13 {
			get { return ( this.__bitfield17 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield17 = ( this.__bitfield17 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 72 byte data
		[FieldOffset(72)] private UInt32 __bitfield18;
		/// <summary>
		/// padding_14の最大値
		/// </summary>
		public const UInt32 padding_14_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_14
		/// </summary>
		public UInt32 padding_14 {
			get { return ( this.__bitfield18 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield18 = ( this.__bitfield18 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 76 byte data
		[FieldOffset(76)] private UInt32 __bitfield19;
		/// <summary>
		/// padding_15の最大値
		/// </summary>
		public const UInt32 padding_15_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_15
		/// </summary>
		public UInt32 padding_15 {
			get { return ( this.__bitfield19 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield19 = ( this.__bitfield19 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 80 byte data
		[FieldOffset(80)] private UInt32 __bitfield20;
		/// <summary>
		/// padding_16の最大値
		/// </summary>
		public const UInt32 padding_16_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_16
		/// </summary>
		public UInt32 padding_16 {
			get { return ( this.__bitfield20 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield20 = ( this.__bitfield20 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 84 byte data
		[FieldOffset(84)] private UInt32 __bitfield21;
		/// <summary>
		/// padding_17の最大値
		/// </summary>
		public const UInt32 padding_17_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_17
		/// </summary>
		public UInt32 padding_17 {
			get { return ( this.__bitfield21 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_17_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield21 = ( this.__bitfield21 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 88 byte data
		[FieldOffset(88)] private UInt32 __bitfield22;
		/// <summary>
		/// padding_18の最大値
		/// </summary>
		public const UInt32 padding_18_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_18
		/// </summary>
		public UInt32 padding_18 {
			get { return ( this.__bitfield22 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_18_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield22 = ( this.__bitfield22 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 92 byte data
		[FieldOffset(92)] private UInt32 __bitfield23;
		/// <summary>
		/// padding_19の最大値
		/// </summary>
		public const UInt32 padding_19_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_19
		/// </summary>
		public UInt32 padding_19 {
			get { return ( this.__bitfield23 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_19_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield23 = ( this.__bitfield23 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 96 byte data
		[FieldOffset(96)] private UInt32 __bitfield24;
		/// <summary>
		/// padding_20の最大値
		/// </summary>
		public const UInt32 padding_20_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_20
		/// </summary>
		public UInt32 padding_20 {
			get { return ( this.__bitfield24 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield24 = ( this.__bitfield24 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 100 byte data
		[FieldOffset(100)] private UInt32 __bitfield25;
		/// <summary>
		/// padding_21の最大値
		/// </summary>
		public const UInt32 padding_21_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_21
		/// </summary>
		public UInt32 padding_21 {
			get { return ( this.__bitfield25 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_21_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield25 = ( this.__bitfield25 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 104 byte data
		[FieldOffset(104)] private UInt32 __bitfield26;
		/// <summary>
		/// padding_22の最大値
		/// </summary>
		public const UInt32 padding_22_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_22
		/// </summary>
		public UInt32 padding_22 {
			get { return ( this.__bitfield26 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_22_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield26 = ( this.__bitfield26 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 108 byte data
		[FieldOffset(108)] private UInt32 __bitfield27;
		/// <summary>
		/// padding_23の最大値
		/// </summary>
		public const UInt32 padding_23_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_23
		/// </summary>
		public UInt32 padding_23 {
			get { return ( this.__bitfield27 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_23_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield27 = ( this.__bitfield27 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 112 byte data
		[FieldOffset(112)] private UInt32 __bitfield28;
		/// <summary>
		/// padding_24の最大値
		/// </summary>
		public const UInt32 padding_24_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_24
		/// </summary>
		public UInt32 padding_24 {
			get { return ( this.__bitfield28 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_24_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield28 = ( this.__bitfield28 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 116 byte data
		[FieldOffset(116)] private UInt32 __bitfield29;
		/// <summary>
		/// padding_25の最大値
		/// </summary>
		public const UInt32 padding_25_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_25
		/// </summary>
		public UInt32 padding_25 {
			get { return ( this.__bitfield29 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_25_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield29 = ( this.__bitfield29 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 120 byte data
		[FieldOffset(120)] private UInt32 __bitfield30;
		/// <summary>
		/// padding_26の最大値
		/// </summary>
		public const UInt32 padding_26_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_26
		/// </summary>
		public UInt32 padding_26 {
			get { return ( this.__bitfield30 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_26_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield30 = ( this.__bitfield30 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 124 byte data
		[FieldOffset(124)] private UInt32 __bitfield31;
		/// <summary>
		/// padding_27の最大値
		/// </summary>
		public const UInt32 padding_27_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_27
		/// </summary>
		public UInt32 padding_27 {
			get { return ( this.__bitfield31 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_27_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield31 = ( this.__bitfield31 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 128 byte data
		[FieldOffset(128)] private UInt32 __bitfield32;
		/// <summary>
		/// padding_28の最大値
		/// </summary>
		public const UInt32 padding_28_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_28
		/// </summary>
		public UInt32 padding_28 {
			get { return ( this.__bitfield32 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_28_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield32 = ( this.__bitfield32 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 132 byte data
		[FieldOffset(132)] private UInt32 __bitfield33;
		/// <summary>
		/// padding_29の最大値
		/// </summary>
		public const UInt32 padding_29_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_29
		/// </summary>
		public UInt32 padding_29 {
			get { return ( this.__bitfield33 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_29_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield33 = ( this.__bitfield33 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 136 byte data
		[FieldOffset(136)] private UInt32 __bitfield34;
		/// <summary>
		/// padding_30の最大値
		/// </summary>
		public const UInt32 padding_30_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_30
		/// </summary>
		public UInt32 padding_30 {
			get { return ( this.__bitfield34 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_30_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield34 = ( this.__bitfield34 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 140 byte data
		[FieldOffset(140)] private UInt32 __bitfield35;
		/// <summary>
		/// padding_31の最大値
		/// </summary>
		public const UInt32 padding_31_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_31
		/// </summary>
		public UInt32 padding_31 {
			get { return ( this.__bitfield35 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_31_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield35 = ( this.__bitfield35 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 144 byte data
		[FieldOffset(144)] private UInt32 __bitfield36;
		/// <summary>
		/// padding_32の最大値
		/// </summary>
		public const UInt32 padding_32_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_32
		/// </summary>
		public UInt32 padding_32 {
			get { return ( this.__bitfield36 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_32_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield36 = ( this.__bitfield36 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 148 byte data
		[FieldOffset(148)] private UInt32 __bitfield37;
		/// <summary>
		/// padding_33の最大値
		/// </summary>
		public const UInt32 padding_33_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_33
		/// </summary>
		public UInt32 padding_33 {
			get { return ( this.__bitfield37 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_33_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield37 = ( this.__bitfield37 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 152 byte data
		[FieldOffset(152)] private UInt32 __bitfield38;
		/// <summary>
		/// padding_34の最大値
		/// </summary>
		public const UInt32 padding_34_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_34
		/// </summary>
		public UInt32 padding_34 {
			get { return ( this.__bitfield38 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_34_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield38 = ( this.__bitfield38 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 156 byte data
		[FieldOffset(156)] private UInt32 __bitfield39;
		/// <summary>
		/// padding_35の最大値
		/// </summary>
		public const UInt32 padding_35_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_35
		/// </summary>
		public UInt32 padding_35 {
			get { return ( this.__bitfield39 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_35_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield39 = ( this.__bitfield39 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 160 byte data
		[FieldOffset(160)] private UInt32 __bitfield40;
		/// <summary>
		/// padding_36の最大値
		/// </summary>
		public const UInt32 padding_36_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_36
		/// </summary>
		public UInt32 padding_36 {
			get { return ( this.__bitfield40 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_36_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield40 = ( this.__bitfield40 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 164 byte data
		[FieldOffset(164)] private UInt32 __bitfield41;
		/// <summary>
		/// padding_37の最大値
		/// </summary>
		public const UInt32 padding_37_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_37
		/// </summary>
		public UInt32 padding_37 {
			get { return ( this.__bitfield41 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_37_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield41 = ( this.__bitfield41 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 168 byte data
		[FieldOffset(168)] private UInt32 __bitfield42;
		/// <summary>
		/// padding_38の最大値
		/// </summary>
		public const UInt32 padding_38_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_38
		/// </summary>
		public UInt32 padding_38 {
			get { return ( this.__bitfield42 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_38_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield42 = ( this.__bitfield42 & 0x00000000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("win_grade_count"), 10, 1023, "産駒重賞勝ち", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("win_g1_count"), 10, 1023, "産駒G1勝ち", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("tanetsuke"), 7, 127, "種付け料", "+  50万\r\n+ 100万 + 200万 + 400万\r\n+ 800万 +1600万 +3200万" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_1"), 5, 31, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_2"), 23, 8388607, "", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("record_len"), 8, 255, "出走数", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_3"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("abl_num"), 15, 32767, "能力番号", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("blood_num"), 15, 32767, "血統番号", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("intai"), 2, 3, "引退？", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("syoukin"), 20, 1048575, "獲得賞金", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("age"), 6, 63, "馬齢", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_4"), 6, 63, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_5"), 20, 1048575, "", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("record_win"), 8, 255, "勝利回数", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_6"), 4, 15, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_7"), 28, 268435455, "", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("bookfull"), 1, 1, "BookFull", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("syndicate"), 1, 1, "シンジケート", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_8"), 2, 3, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_9"), 20, 1048575, "", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("tanetsuke_count"), 8, 255, "種付け数", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_10"), 4, 15, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_80"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("kachikura_LT"), 12, 4095, "主な勝ち鞍(左上)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("kachikura_LB"), 12, 4095, "主な勝ち鞍(左下)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_12"), 8, 255, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("kachikura_RT"), 12, 4095, "主な勝ち鞍(右上)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("kachikura_RB"), 12, 4095, "主な勝ち鞍(右下)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("youku1_count"), 8, 255, "1歳幼駒数", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_w1"), 12, 4095, "代表産駒主な勝ち鞍(1)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_w2"), 12, 4095, "代表産駒主な勝ち鞍(2)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("geneki_count"), 8, 255, "現役産駒数", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_w3"), 12, 4095, "代表産駒主な勝ち鞍(3)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_w4"), 12, 4095, "代表産駒主な勝ち鞍(4)", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("rank_5_ago"), 8, 255, "5年前成績", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_1"), 32, 4294967295, "代表産駒1", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_2"), 32, 4294967295, "代表産駒2", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_3"), 32, 4294967295, "代表産駒3", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("daihyousan_4"), 32, 4294967295, "代表産駒4", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("rank_1_ago"), 8, 255, "1年前成績", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("rank_2_ago"), 8, 255, "2年前成績", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("rank_3_ago"), 8, 255, "3年前成績", "" ),
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("rank_4_ago"), 8, 255, "4年前成績", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_13"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_14"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_15"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_16"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_17"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_18"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_19"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_20"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_21"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_22"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_23"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_24"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_25"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_26"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_27"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_28"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_29"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_30"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_31"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_32"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_33"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_34"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_35"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_36"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_37"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HSireData).GetProperty("padding_38"), 32, 4294967295, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[43];
			data[0] = data[0] | ( this.win_grade_count << 0 ) ;
			data[0] = data[0] | ( this.win_g1_count << 10 ) ;
			data[0] = data[0] | ( this.tanetsuke << 20 ) ;
			data[0] = data[0] | ( this.padding_1 << 27 ) ;
			data[1] = data[1] | ( this.padding_2 << 0 ) ;
			data[1] = data[1] | ( this.record_len << 23 ) ;
			data[1] = data[1] | ( this.padding_3 << 31 ) ;
			data[2] = data[2] | ( this.abl_num << 0 ) ;
			data[2] = data[2] | ( this.blood_num << 15 ) ;
			data[2] = data[2] | ( this.intai << 30 ) ;
			data[3] = data[3] | ( this.syoukin << 0 ) ;
			data[3] = data[3] | ( this.age << 20 ) ;
			data[3] = data[3] | ( this.padding_4 << 26 ) ;
			data[4] = data[4] | ( this.padding_5 << 0 ) ;
			data[4] = data[4] | ( this.record_win << 20 ) ;
			data[4] = data[4] | ( this.padding_6 << 28 ) ;
			data[5] = data[5] | ( this.padding_7 << 0 ) ;
			data[5] = data[5] | ( this.bookfull << 28 ) ;
			data[5] = data[5] | ( this.syndicate << 29 ) ;
			data[5] = data[5] | ( this.padding_8 << 30 ) ;
			data[6] = data[6] | ( this.padding_9 << 0 ) ;
			data[6] = data[6] | ( this.tanetsuke_count << 20 ) ;
			data[6] = data[6] | ( this.padding_10 << 28 ) ;
			data[7] = data[7] | ( this.padding_80 << 0 ) ;
			data[8] = data[8] | ( this.kachikura_LT << 0 ) ;
			data[8] = data[8] | ( this.kachikura_LB << 12 ) ;
			data[8] = data[8] | ( this.padding_12 << 24 ) ;
			data[9] = data[9] | ( this.kachikura_RT << 0 ) ;
			data[9] = data[9] | ( this.kachikura_RB << 12 ) ;
			data[9] = data[9] | ( this.youku1_count << 24 ) ;
			data[10] = data[10] | ( this.daihyousan_w1 << 0 ) ;
			data[10] = data[10] | ( this.daihyousan_w2 << 12 ) ;
			data[10] = data[10] | ( this.geneki_count << 24 ) ;
			data[11] = data[11] | ( this.daihyousan_w3 << 0 ) ;
			data[11] = data[11] | ( this.daihyousan_w4 << 12 ) ;
			data[11] = data[11] | ( this.rank_5_ago << 24 ) ;
			data[12] = data[12] | ( this.daihyousan_1 << 0 ) ;
			data[13] = data[13] | ( this.daihyousan_2 << 0 ) ;
			data[14] = data[14] | ( this.daihyousan_3 << 0 ) ;
			data[15] = data[15] | ( this.daihyousan_4 << 0 ) ;
			data[16] = data[16] | ( this.rank_1_ago << 0 ) ;
			data[16] = data[16] | ( this.rank_2_ago << 8 ) ;
			data[16] = data[16] | ( this.rank_3_ago << 16 ) ;
			data[16] = data[16] | ( this.rank_4_ago << 24 ) ;
			data[17] = data[17] | ( this.padding_13 << 0 ) ;
			data[18] = data[18] | ( this.padding_14 << 0 ) ;
			data[19] = data[19] | ( this.padding_15 << 0 ) ;
			data[20] = data[20] | ( this.padding_16 << 0 ) ;
			data[21] = data[21] | ( this.padding_17 << 0 ) ;
			data[22] = data[22] | ( this.padding_18 << 0 ) ;
			data[23] = data[23] | ( this.padding_19 << 0 ) ;
			data[24] = data[24] | ( this.padding_20 << 0 ) ;
			data[25] = data[25] | ( this.padding_21 << 0 ) ;
			data[26] = data[26] | ( this.padding_22 << 0 ) ;
			data[27] = data[27] | ( this.padding_23 << 0 ) ;
			data[28] = data[28] | ( this.padding_24 << 0 ) ;
			data[29] = data[29] | ( this.padding_25 << 0 ) ;
			data[30] = data[30] | ( this.padding_26 << 0 ) ;
			data[31] = data[31] | ( this.padding_27 << 0 ) ;
			data[32] = data[32] | ( this.padding_28 << 0 ) ;
			data[33] = data[33] | ( this.padding_29 << 0 ) ;
			data[34] = data[34] | ( this.padding_30 << 0 ) ;
			data[35] = data[35] | ( this.padding_31 << 0 ) ;
			data[36] = data[36] | ( this.padding_32 << 0 ) ;
			data[37] = data[37] | ( this.padding_33 << 0 ) ;
			data[38] = data[38] | ( this.padding_34 << 0 ) ;
			data[39] = data[39] | ( this.padding_35 << 0 ) ;
			data[40] = data[40] | ( this.padding_36 << 0 ) ;
			data[41] = data[41] | ( this.padding_37 << 0 ) ;
			data[42] = data[42] | ( this.padding_38 << 0 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HSireData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 43 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 43)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
			this.__bitfield5 = data[5];
			this.__bitfield6 = data[6];
			this.__bitfield7 = data[7];
			this.__bitfield8 = data[8];
			this.__bitfield9 = data[9];
			this.__bitfield10 = data[10];
			this.__bitfield11 = data[11];
			this.__bitfield12 = data[12];
			this.__bitfield13 = data[13];
			this.__bitfield14 = data[14];
			this.__bitfield15 = data[15];
			this.__bitfield16 = data[16];
			this.__bitfield17 = data[17];
			this.__bitfield18 = data[18];
			this.__bitfield19 = data[19];
			this.__bitfield20 = data[20];
			this.__bitfield21 = data[21];
			this.__bitfield22 = data[22];
			this.__bitfield23 = data[23];
			this.__bitfield24 = data[24];
			this.__bitfield25 = data[25];
			this.__bitfield26 = data[26];
			this.__bitfield27 = data[27];
			this.__bitfield28 = data[28];
			this.__bitfield29 = data[29];
			this.__bitfield30 = data[30];
			this.__bitfield31 = data[31];
			this.__bitfield32 = data[32];
			this.__bitfield33 = data[33];
			this.__bitfield34 = data[34];
			this.__bitfield35 = data[35];
			this.__bitfield36 = data[36];
			this.__bitfield37 = data[37];
			this.__bitfield38 = data[38];
			this.__bitfield39 = data[39];
			this.__bitfield40 = data[40];
			this.__bitfield41 = data[41];
			this.__bitfield42 = data[42];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 43;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HChildData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// priceの最大値
		/// </summary>
		public const UInt32 price_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 売買額 * 100万
		/// </summary>
		public UInt32 price {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// mother_numの最大値
		/// </summary>
		public const UInt32 mother_num_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 母
		/// </summary>
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 14 ) & 0x00003fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf0003fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// weak_point_3の最大値
		/// </summary>
		public const UInt32 weak_point_3_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 腰甘
		/// </summary>
		public UInt32 weak_point_3 {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000003;  }
			set {
				if( value > weak_point_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xcfffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// ageの最大値
		/// </summary>
		public const UInt32 age_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 1で1歳
		/// </summary>
		public UInt32 age {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// genderの最大値
		/// </summary>
		public const UInt32 gender_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 0牡 1牝
		/// </summary>
		public UInt32 gender {
			get { return ( this.__bitfield0 >> 31 ) & 0x00000001;  }
			set {
				if( value > gender_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// padding_1の最大値
		/// </summary>
		public const UInt32 padding_1_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// padding_1
		/// </summary>
		public UInt32 padding_1 {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000007f;  }
			set {
				if( value > padding_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// weak_point_1の最大値
		/// </summary>
		public const UInt32 weak_point_1_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 脚部不安
		/// </summary>
		public UInt32 weak_point_1 {
			get { return ( this.__bitfield1 >> 7 ) & 0x00000003;  }
			set {
				if( value > weak_point_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffe7f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// breederの最大値
		/// </summary>
		public const UInt32 breeder_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 生産者
		/// </summary>
		public UInt32 breeder {
			get { return ( this.__bitfield1 >> 9 ) & 0x000000ff;  }
			set {
				if( value > breeder_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffe01ff ) | ( value << 9 );
			}
		}
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield1 >> 17 ) & 0x0000007f;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff01ffff ) | ( value << 17 );
			}
		}
		/// <summary>
		/// zyumyouの最大値
		/// </summary>
		public const UInt32 zyumyou_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 競走寿命
		/// </summary>
		public UInt32 zyumyou {
			get { return ( this.__bitfield1 >> 24 ) & 0x0000007f;  }
			set {
				if( value > zyumyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0x80ffffff ) | ( value << 24 );
			}
		}
		/// <summary>
		/// migimawari_Xの最大値
		/// </summary>
		public const UInt32 migimawari_X_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 右回り苦手
		/// </summary>
		public UInt32 migimawari_X {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > migimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// price2の最大値
		/// </summary>
		public const UInt32 price2_MAXVALUE = 0x000003ff; // 1023
		/// <summary>
		/// 評価額 * 100万
		/// </summary>
		public UInt32 price2 {
			get { return ( this.__bitfield2 >> 0 ) & 0x000003ff;  }
			set {
				if( value > price2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield2 >> 10 ) & 0x0000007f;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffe03ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// weak_point_2の最大値
		/// </summary>
		public const UInt32 weak_point_2_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 喉なり
		/// </summary>
		public UInt32 weak_point_2 {
			get { return ( this.__bitfield2 >> 17 ) & 0x00000003;  }
			set {
				if( value > weak_point_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfff9ffff ) | ( value << 17 );
			}
		}
		/// <summary>
		/// father_numの最大値
		/// </summary>
		public const UInt32 father_num_MAXVALUE = 0x000007ff; // 2047
		/// <summary>
		/// 父馬番号
		/// </summary>
		public UInt32 father_num {
			get { return ( this.__bitfield2 >> 19 ) & 0x000007ff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc007ffff ) | ( value << 19 );
			}
		}
		/// <summary>
		/// padding_4の最大値
		/// </summary>
		public const UInt32 padding_4_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_4
		/// </summary>
		public UInt32 padding_4 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > padding_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// abl_numの最大値
		/// </summary>
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 能力番号
		/// </summary>
		public UInt32 abl_num {
			get { return ( this.__bitfield3 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffff8000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// ownerの最大値
		/// </summary>
		public const UInt32 owner_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// オーナー
		/// </summary>
		public UInt32 owner {
			get { return ( this.__bitfield3 >> 15 ) & 0x00000fff;  }
			set {
				if( value > owner_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield3 = ( this.__bitfield3 & 0xf8007fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// seigenの最大値
		/// </summary>
		public const UInt32 seigen_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 成長上限 +100
		/// </summary>
		public UInt32 seigen {
			get { return ( this.__bitfield3 >> 27 ) & 0x0000000f;  }
			set {
				if( value > seigen_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield3 = ( this.__bitfield3 & 0x87ffffff ) | ( value << 27 );
			}
		}
		/// <summary>
		/// hidarimawari_Xの最大値
		/// </summary>
		public const UInt32 hidarimawari_X_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 左回り×
		/// </summary>
		public UInt32 hidarimawari_X {
			get { return ( this.__bitfield3 >> 31 ) & 0x00000001;  }
			set {
				if( value > hidarimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// shizitsu_numの最大値
		/// </summary>
		public const UInt32 shizitsu_num_MAXVALUE = 0x00001fff; // 8191
		/// <summary>
		/// 史実番号
		/// </summary>
		public UInt32 shizitsu_num {
			get { return ( this.__bitfield4 >> 0 ) & 0x00001fff;  }
			set {
				if( value > shizitsu_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffe000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_5の最大値
		/// </summary>
		public const UInt32 padding_5_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// padding_5
		/// </summary>
		public UInt32 padding_5 {
			get { return ( this.__bitfield4 >> 13 ) & 0x0000001f;  }
			set {
				if( value > padding_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffc1fff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// fuda_colorの最大値
		/// </summary>
		public const UInt32 fuda_color_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 札
		/// </summary>
		public UInt32 fuda_color {
			get { return ( this.__bitfield4 >> 18 ) & 0x00000007;  }
			set {
				if( value > fuda_color_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffe3ffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// padding_6の最大値
		/// </summary>
		public const UInt32 padding_6_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_6
		/// </summary>
		public UInt32 padding_6 {
			get { return ( this.__bitfield4 >> 21 ) & 0x00000001;  }
			set {
				if( value > padding_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffdfffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// torihikiの最大値
		/// </summary>
		public const UInt32 torihiki_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 取引形態
		/// </summary>
		public UInt32 torihiki {
			get { return ( this.__bitfield4 >> 22 ) & 0x00000007;  }
			set {
				if( value > torihiki_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfe3fffff ) | ( value << 22 );
			}
		}
		/// <summary>
		/// padding_7の最大値
		/// </summary>
		public const UInt32 padding_7_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// padding_7
		/// </summary>
		public UInt32 padding_7 {
			get { return ( this.__bitfield4 >> 25 ) & 0x0000007f;  }
			set {
				if( value > padding_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield4 = ( this.__bitfield4 & 0x01ffffff ) | ( value << 25 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("price"), 14, 16383, "売買額 * 100万", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("mother_num"), 14, 16383, "母", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("weak_point_3"), 2, 3, "腰甘", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("age"), 1, 1, "1で1歳", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("gender"), 1, 1, "0牡 1牝", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_1"), 7, 127, "", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("weak_point_1"), 2, 3, "脚部不安", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("breeder"), 8, 255, "生産者", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_2"), 7, 127, "", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("zyumyou"), 7, 127, "競走寿命", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("migimawari_X"), 1, 1, "右回り苦手", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("price2"), 10, 1023, "評価額 * 100万", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_3"), 7, 127, "", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("weak_point_2"), 2, 3, "喉なり", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("father_num"), 11, 2047, "父馬番号", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_4"), 2, 3, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("abl_num"), 15, 32767, "能力番号", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("owner"), 12, 4095, "オーナー", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("seigen"), 4, 15, "成長上限 +100", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("hidarimawari_X"), 1, 1, "左回り×", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("shizitsu_num"), 13, 8191, "史実番号", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_5"), 5, 31, "", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("fuda_color"), 3, 7, "札", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_6"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("torihiki"), 3, 7, "取引形態", "" ),
				new DataStructPropertyInfo( typeof(HChildData).GetProperty("padding_7"), 7, 127, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[5];
			data[0] = data[0] | ( this.price << 0 ) ;
			data[0] = data[0] | ( this.mother_num << 14 ) ;
			data[0] = data[0] | ( this.weak_point_3 << 28 ) ;
			data[0] = data[0] | ( this.age << 30 ) ;
			data[0] = data[0] | ( this.gender << 31 ) ;
			data[1] = data[1] | ( this.padding_1 << 0 ) ;
			data[1] = data[1] | ( this.weak_point_1 << 7 ) ;
			data[1] = data[1] | ( this.breeder << 9 ) ;
			data[1] = data[1] | ( this.padding_2 << 17 ) ;
			data[1] = data[1] | ( this.zyumyou << 24 ) ;
			data[1] = data[1] | ( this.migimawari_X << 31 ) ;
			data[2] = data[2] | ( this.price2 << 0 ) ;
			data[2] = data[2] | ( this.padding_3 << 10 ) ;
			data[2] = data[2] | ( this.weak_point_2 << 17 ) ;
			data[2] = data[2] | ( this.father_num << 19 ) ;
			data[2] = data[2] | ( this.padding_4 << 30 ) ;
			data[3] = data[3] | ( this.abl_num << 0 ) ;
			data[3] = data[3] | ( this.owner << 15 ) ;
			data[3] = data[3] | ( this.seigen << 27 ) ;
			data[3] = data[3] | ( this.hidarimawari_X << 31 ) ;
			data[4] = data[4] | ( this.shizitsu_num << 0 ) ;
			data[4] = data[4] | ( this.padding_5 << 13 ) ;
			data[4] = data[4] | ( this.fuda_color << 18 ) ;
			data[4] = data[4] | ( this.padding_6 << 21 ) ;
			data[4] = data[4] | ( this.torihiki << 22 ) ;
			data[4] = data[4] | ( this.padding_7 << 25 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HChildData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 5 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 5)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 5;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HRaceData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// mother_numの最大値
		/// </summary>
		public const UInt32 mother_num_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 母馬番号
		/// </summary>
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// maruchihouの最大値
		/// </summary>
		public const UInt32 maruchihou_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 地方馬フラグ
		/// </summary>
		public UInt32 maruchihou {
			get { return ( this.__bitfield0 >> 14 ) & 0x00000001;  }
			set {
				if( value > maruchihou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffbfff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// padding_2の最大値
		/// </summary>
		public const UInt32 padding_2_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// padding_2
		/// </summary>
		public UInt32 padding_2 {
			get { return ( this.__bitfield0 >> 15 ) & 0x00000007;  }
			set {
				if( value > padding_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffc7fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// hidarimawari_Xの最大値
		/// </summary>
		public const UInt32 hidarimawari_X_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 左回り×
		/// </summary>
		public UInt32 hidarimawari_X {
			get { return ( this.__bitfield0 >> 18 ) & 0x00000001;  }
			set {
				if( value > hidarimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffbffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// padding_3の最大値
		/// </summary>
		public const UInt32 padding_3_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_3
		/// </summary>
		public UInt32 padding_3 {
			get { return ( this.__bitfield0 >> 19 ) & 0x00000003;  }
			set {
				if( value > padding_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffe7ffff ) | ( value << 19 );
			}
		}
		/// <summary>
		/// shusen_jk_numの最大値
		/// </summary>
		public const UInt32 shusen_jk_num_MAXVALUE = 0x000001ff; // 511
		/// <summary>
		/// 主戦騎手番号
		/// </summary>
		public UInt32 shusen_jk_num {
			get { return ( this.__bitfield0 >> 21 ) & 0x000001ff;  }
			set {
				if( value > shusen_jk_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield0 = ( this.__bitfield0 & 0xc01fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// padding_4の最大値
		/// </summary>
		public const UInt32 padding_4_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_4
		/// </summary>
		public UInt32 padding_4 {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > padding_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// genderの最大値
		/// </summary>
		public const UInt32 gender_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 性別
		/// </summary>
		public UInt32 gender {
			get { return ( this.__bitfield0 >> 31 ) & 0x00000001;  }
			set {
				if( value > gender_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// houbokuchuuの最大値
		/// </summary>
		public const UInt32 houbokuchuu_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 放牧中
		/// </summary>
		public UInt32 houbokuchuu {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000000f;  }
			set {
				if( value > houbokuchuu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffff0 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_5の最大値
		/// </summary>
		public const UInt32 padding_5_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_5
		/// </summary>
		public UInt32 padding_5 {
			get { return ( this.__bitfield1 >> 4 ) & 0x00000003;  }
			set {
				if( value > padding_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffcf ) | ( value << 4 );
			}
		}
		/// <summary>
		/// kansenの最大値
		/// </summary>
		public const UInt32 kansen_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 観戦
		/// </summary>
		public UInt32 kansen {
			get { return ( this.__bitfield1 >> 6 ) & 0x00000001;  }
			set {
				if( value > kansen_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffbf ) | ( value << 6 );
			}
		}
		/// <summary>
		/// weight_bestの最大値
		/// </summary>
		public const UInt32 weight_best_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 理想体重
		/// </summary>
		public UInt32 weight_best {
			get { return ( this.__bitfield1 >> 7 ) & 0x0000007f;  }
			set {
				if( value > weight_best_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffc07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// weight_nowの最大値
		/// </summary>
		public const UInt32 weight_now_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 馬体重
		/// </summary>
		public UInt32 weight_now {
			get { return ( this.__bitfield1 >> 14 ) & 0x0000007f;  }
			set {
				if( value > weight_now_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffe03fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// zyumyouの最大値
		/// </summary>
		public const UInt32 zyumyou_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 競走寿命
		/// </summary>
		public UInt32 zyumyou {
			get { return ( this.__bitfield1 >> 21 ) & 0x0000007f;  }
			set {
				if( value > zyumyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf01fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// ageの最大値
		/// </summary>
		public const UInt32 age_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 年齢
		/// </summary>
		public UInt32 age {
			get { return ( this.__bitfield1 >> 28 ) & 0x00000007;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0x8fffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// padding_6の最大値
		/// </summary>
		public const UInt32 padding_6_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_6
		/// </summary>
		public UInt32 padding_6 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// seichouの最大値
		/// </summary>
		public const UInt32 seichou_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 成長度
		/// </summary>
		public UInt32 seichou {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000007f;  }
			set {
				if( value > seichou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// keikenchiの最大値
		/// </summary>
		public const UInt32 keikenchi_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 経験値
		/// </summary>
		public UInt32 keikenchi {
			get { return ( this.__bitfield2 >> 7 ) & 0x0000007f;  }
			set {
				if( value > keikenchi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffc07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// race_kanの最大値
		/// </summary>
		public const UInt32 race_kan_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// レース勘
		/// </summary>
		public UInt32 race_kan {
			get { return ( this.__bitfield2 >> 14 ) & 0x0000007f;  }
			set {
				if( value > race_kan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffe03fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// choushiの最大値
		/// </summary>
		public const UInt32 choushi_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// 調子
		/// </summary>
		public UInt32 choushi {
			get { return ( this.__bitfield2 >> 21 ) & 0x0000003f;  }
			set {
				if( value > choushi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield2 = ( this.__bitfield2 & 0xf81fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// klassの最大値
		/// </summary>
		public const UInt32 klass_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// クラス
		/// </summary>
		public UInt32 klass {
			get { return ( this.__bitfield2 >> 27 ) & 0x00000007;  }
			set {
				if( value > klass_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc7ffffff ) | ( value << 27 );
			}
		}
		/// <summary>
		/// choushi_statusの最大値
		/// </summary>
		public const UInt32 choushi_status_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 調子向き
		/// </summary>
		public UInt32 choushi_status {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > choushi_status_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// hirouの最大値
		/// </summary>
		public const UInt32 hirou_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 疲労度
		/// </summary>
		public UInt32 hirou {
			get { return ( this.__bitfield3 >> 0 ) & 0x0000007f;  }
			set {
				if( value > hirou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// houboku_lenの最大値
		/// </summary>
		public const UInt32 houboku_len_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// 何週間放牧
		/// </summary>
		public UInt32 houboku_len {
			get { return ( this.__bitfield3 >> 7 ) & 0x0000003f;  }
			set {
				if( value > houboku_len_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffe07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// father_numの最大値
		/// </summary>
		public const UInt32 father_num_MAXVALUE = 0x000007ff; // 2047
		/// <summary>
		/// 父馬番号
		/// </summary>
		public UInt32 father_num {
			get { return ( this.__bitfield3 >> 13 ) & 0x000007ff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield3 = ( this.__bitfield3 & 0xff001fff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// padding_8の最大値
		/// </summary>
		public const UInt32 padding_8_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// padding_8
		/// </summary>
		public UInt32 padding_8 {
			get { return ( this.__bitfield3 >> 24 ) & 0x000000ff;  }
			set {
				if( value > padding_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// padding_9の最大値
		/// </summary>
		public const UInt32 padding_9_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_9
		/// </summary>
		public UInt32 padding_9 {
			get { return ( this.__bitfield4 >> 0 ) & 0x00000003;  }
			set {
				if( value > padding_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffffffc ) | ( value << 0 );
			}
		}
		/// <summary>
		/// intaiの最大値
		/// </summary>
		public const UInt32 intai_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 引退
		/// </summary>
		public UInt32 intai {
			get { return ( this.__bitfield4 >> 2 ) & 0x00000001;  }
			set {
				if( value > intai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffffffb ) | ( value << 2 );
			}
		}
		/// <summary>
		/// padding_10の最大値
		/// </summary>
		public const UInt32 padding_10_MAXVALUE = 0x000001ff; // 511
		/// <summary>
		/// padding_10
		/// </summary>
		public UInt32 padding_10 {
			get { return ( this.__bitfield4 >> 3 ) & 0x000001ff;  }
			set {
				if( value > padding_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffff007 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// souhouの最大値
		/// </summary>
		public const UInt32 souhou_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 走法
		/// </summary>
		public UInt32 souhou {
			get { return ( this.__bitfield4 >> 12 ) & 0x00000003;  }
			set {
				if( value > souhou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffcfff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// weak_point_1の最大値
		/// </summary>
		public const UInt32 weak_point_1_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 脚部不安
		/// </summary>
		public UInt32 weak_point_1 {
			get { return ( this.__bitfield4 >> 14 ) & 0x00000003;  }
			set {
				if( value > weak_point_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff3fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// weak_point_2の最大値
		/// </summary>
		public const UInt32 weak_point_2_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// のどなり
		/// </summary>
		public UInt32 weak_point_2 {
			get { return ( this.__bitfield4 >> 16 ) & 0x00000003;  }
			set {
				if( value > weak_point_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffcffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// weak_point_3の最大値
		/// </summary>
		public const UInt32 weak_point_3_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 腰甘
		/// </summary>
		public UInt32 weak_point_3 {
			get { return ( this.__bitfield4 >> 18 ) & 0x00000003;  }
			set {
				if( value > weak_point_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfff3ffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// breederの最大値
		/// </summary>
		public const UInt32 breeder_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 生産者
		/// </summary>
		public UInt32 breeder {
			get { return ( this.__bitfield4 >> 20 ) & 0x000000ff;  }
			set {
				if( value > breeder_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xf00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// seigenの最大値
		/// </summary>
		public const UInt32 seigen_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 成長上限
		/// </summary>
		public UInt32 seigen {
			get { return ( this.__bitfield4 >> 28 ) & 0x0000000f;  }
			set {
				if( value > seigen_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield4 = ( this.__bitfield4 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		/// <summary>
		/// priceの最大値
		/// </summary>
		public const UInt32 price_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 売買額
		/// </summary>
		public UInt32 price {
			get { return ( this.__bitfield5 >> 0 ) & 0x00003fff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffffc000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// abl_numの最大値
		/// </summary>
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		/// <summary>
		/// 能力番号
		/// </summary>
		public UInt32 abl_num {
			get { return ( this.__bitfield5 >> 14 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield5 = ( this.__bitfield5 & 0xe0003fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// torihikiの最大値
		/// </summary>
		public const UInt32 torihiki_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 取引形態
		/// </summary>
		public UInt32 torihiki {
			get { return ( this.__bitfield5 >> 29 ) & 0x00000007;  }
			set {
				if( value > torihiki_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield5 = ( this.__bitfield5 & 0x1fffffff ) | ( value << 29 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		/// <summary>
		/// earning_honの最大値
		/// </summary>
		public const UInt32 earning_hon_MAXVALUE = 0x000fffff; // 1048575
		/// <summary>
		/// 本賞金
		/// </summary>
		public UInt32 earning_hon {
			get { return ( this.__bitfield6 >> 0 ) & 0x000fffff;  }
			set {
				if( value > earning_hon_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield6 = ( this.__bitfield6 & 0xfff00000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// ownerの最大値
		/// </summary>
		public const UInt32 owner_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// オーナー
		/// </summary>
		public UInt32 owner {
			get { return ( this.__bitfield6 >> 20 ) & 0x00000fff;  }
			set {
				if( value > owner_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield6 = ( this.__bitfield6 & 0x000fffff ) | ( value << 20 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		/// <summary>
		/// earning_allの最大値
		/// </summary>
		public const UInt32 earning_all_MAXVALUE = 0x000fffff; // 1048575
		/// <summary>
		/// 総賞金
		/// </summary>
		public UInt32 earning_all {
			get { return ( this.__bitfield7 >> 0 ) & 0x000fffff;  }
			set {
				if( value > earning_all_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield7 = ( this.__bitfield7 & 0xfff00000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// trainerの最大値
		/// </summary>
		public const UInt32 trainer_MAXVALUE = 0x000001ff; // 511
		/// <summary>
		/// 調教師
		/// </summary>
		public UInt32 trainer {
			get { return ( this.__bitfield7 >> 20 ) & 0x000001ff;  }
			set {
				if( value > trainer_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield7 = ( this.__bitfield7 & 0xe00fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// padding_11の最大値
		/// </summary>
		public const UInt32 padding_11_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_11
		/// </summary>
		public UInt32 padding_11 {
			get { return ( this.__bitfield7 >> 29 ) & 0x00000001;  }
			set {
				if( value > padding_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0xdfffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// nyuukyuuの最大値
		/// </summary>
		public const UInt32 nyuukyuu_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 入厩済み
		/// </summary>
		public UInt32 nyuukyuu {
			get { return ( this.__bitfield7 >> 30 ) & 0x00000001;  }
			set {
				if( value > nyuukyuu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// padding_12の最大値
		/// </summary>
		public const UInt32 padding_12_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_12
		/// </summary>
		public UInt32 padding_12 {
			get { return ( this.__bitfield7 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		/// <summary>
		/// padding_13の最大値
		/// </summary>
		public const UInt32 padding_13_MAXVALUE = 0x03ffffff; // 67108863
		/// <summary>
		/// padding_13
		/// </summary>
		public UInt32 padding_13 {
			get { return ( this.__bitfield8 >> 0 ) & 0x03ffffff;  }
			set {
				if( value > padding_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-67108863)");
				this.__bitfield8 = ( this.__bitfield8 & 0xfc000000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// enseiの最大値
		/// </summary>
		public const UInt32 ensei_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 遠征先
		/// </summary>
		public UInt32 ensei {
			get { return ( this.__bitfield8 >> 26 ) & 0x00000007;  }
			set {
				if( value > ensei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield8 = ( this.__bitfield8 & 0xe3ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// padding_14の最大値
		/// </summary>
		public const UInt32 padding_14_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_14
		/// </summary>
		public UInt32 padding_14 {
			get { return ( this.__bitfield8 >> 29 ) & 0x00000001;  }
			set {
				if( value > padding_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield8 = ( this.__bitfield8 & 0xdfffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// migimawari_Xの最大値
		/// </summary>
		public const UInt32 migimawari_X_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 右回り苦手
		/// </summary>
		public UInt32 migimawari_X {
			get { return ( this.__bitfield8 >> 30 ) & 0x00000001;  }
			set {
				if( value > migimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield8 = ( this.__bitfield8 & 0xbfffffff ) | ( value << 30 );
			}
		}
		/// <summary>
		/// senbaの最大値
		/// </summary>
		public const UInt32 senba_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// セン馬
		/// </summary>
		public UInt32 senba {
			get { return ( this.__bitfield8 >> 31 ) & 0x00000001;  }
			set {
				if( value > senba_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield8 = ( this.__bitfield8 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		/// <summary>
		/// padding_15の最大値
		/// </summary>
		public const UInt32 padding_15_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_15
		/// </summary>
		public UInt32 padding_15 {
			get { return ( this.__bitfield9 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		/// <summary>
		/// padding_16の最大値
		/// </summary>
		public const UInt32 padding_16_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_16
		/// </summary>
		public UInt32 padding_16 {
			get { return ( this.__bitfield10 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield10 = ( this.__bitfield10 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 44 byte data
		[FieldOffset(44)] private UInt32 __bitfield11;
		/// <summary>
		/// padding_17の最大値
		/// </summary>
		public const UInt32 padding_17_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_17
		/// </summary>
		public UInt32 padding_17 {
			get { return ( this.__bitfield11 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_17_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield11 = ( this.__bitfield11 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 48 byte data
		[FieldOffset(48)] private UInt32 __bitfield12;
		/// <summary>
		/// name_leftの最大値
		/// </summary>
		public const UInt32 name_left_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 馬名前半
		/// </summary>
		public UInt32 name_left {
			get { return ( this.__bitfield12 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > name_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield12 = ( this.__bitfield12 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// name_rightの最大値
		/// </summary>
		public const UInt32 name_right_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 馬名後半
		/// </summary>
		public UInt32 name_right {
			get { return ( this.__bitfield12 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > name_right_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield12 = ( this.__bitfield12 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 52 byte data
		[FieldOffset(52)] private UInt32 __bitfield13;
		/// <summary>
		/// race_next_ageの最大値
		/// </summary>
		public const UInt32 race_next_age_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 次走年齢 +2
		/// </summary>
		public UInt32 race_next_age {
			get { return ( this.__bitfield13 >> 0 ) & 0x00000007;  }
			set {
				if( value > race_next_age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield13 = ( this.__bitfield13 & 0xfffffff8 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// rase_next_locationの最大値
		/// </summary>
		public const UInt32 rase_next_location_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 開催地
		/// </summary>
		public UInt32 rase_next_location {
			get { return ( this.__bitfield13 >> 3 ) & 0x00000003;  }
			set {
				if( value > rase_next_location_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffffffe7 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// rase_next_sundayの最大値
		/// </summary>
		public const UInt32 rase_next_sunday_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 曜日
		/// </summary>
		public UInt32 rase_next_sunday {
			get { return ( this.__bitfield13 >> 5 ) & 0x00000001;  }
			set {
				if( value > rase_next_sunday_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffffffdf ) | ( value << 5 );
			}
		}
		/// <summary>
		/// rase_next_numの最大値
		/// </summary>
		public const UInt32 rase_next_num_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// レース番号
		/// </summary>
		public UInt32 rase_next_num {
			get { return ( this.__bitfield13 >> 6 ) & 0x0000000f;  }
			set {
				if( value > rase_next_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield13 = ( this.__bitfield13 & 0xfffffc3f ) | ( value << 6 );
			}
		}
		/// <summary>
		/// rase_next_weekの最大値
		/// </summary>
		public const UInt32 rase_next_week_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// 週番号
		/// </summary>
		public UInt32 rase_next_week {
			get { return ( this.__bitfield13 >> 10 ) & 0x0000003f;  }
			set {
				if( value > rase_next_week_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffff03ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// race_last_ageの最大値
		/// </summary>
		public const UInt32 race_last_age_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 前走年齢 +2
		/// </summary>
		public UInt32 race_last_age {
			get { return ( this.__bitfield13 >> 16 ) & 0x00000007;  }
			set {
				if( value > race_last_age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield13 = ( this.__bitfield13 & 0xfff8ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// rase_last_locationの最大値
		/// </summary>
		public const UInt32 rase_last_location_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// 開催地
		/// </summary>
		public UInt32 rase_last_location {
			get { return ( this.__bitfield13 >> 19 ) & 0x00000003;  }
			set {
				if( value > rase_last_location_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffe7ffff ) | ( value << 19 );
			}
		}
		/// <summary>
		/// rase_last_sundayの最大値
		/// </summary>
		public const UInt32 rase_last_sunday_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 曜日
		/// </summary>
		public UInt32 rase_last_sunday {
			get { return ( this.__bitfield13 >> 21 ) & 0x00000001;  }
			set {
				if( value > rase_last_sunday_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffdfffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// rase_last_numの最大値
		/// </summary>
		public const UInt32 rase_last_num_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// レース番号
		/// </summary>
		public UInt32 rase_last_num {
			get { return ( this.__bitfield13 >> 22 ) & 0x0000000f;  }
			set {
				if( value > rase_last_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield13 = ( this.__bitfield13 & 0xfc3fffff ) | ( value << 22 );
			}
		}
		/// <summary>
		/// rase_last_weekの最大値
		/// </summary>
		public const UInt32 rase_last_week_MAXVALUE = 0x0000003f; // 63
		/// <summary>
		/// 週番号
		/// </summary>
		public UInt32 rase_last_week {
			get { return ( this.__bitfield13 >> 26 ) & 0x0000003f;  }
			set {
				if( value > rase_last_week_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield13 = ( this.__bitfield13 & 0x03ffffff ) | ( value << 26 );
			}
		}
		// 56 byte data
		[FieldOffset(56)] private UInt32 __bitfield14;
		/// <summary>
		/// career_shiba_1の最大値
		/// </summary>
		public const UInt32 career_shiba_1_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 芝成績1着
		/// </summary>
		public UInt32 career_shiba_1 {
			get { return ( this.__bitfield14 >> 0 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield14 = ( this.__bitfield14 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// career_shiba_2の最大値
		/// </summary>
		public const UInt32 career_shiba_2_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 芝成績2着
		/// </summary>
		public UInt32 career_shiba_2 {
			get { return ( this.__bitfield14 >> 8 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield14 = ( this.__bitfield14 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// career_shiba_3の最大値
		/// </summary>
		public const UInt32 career_shiba_3_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 芝成績3着
		/// </summary>
		public UInt32 career_shiba_3 {
			get { return ( this.__bitfield14 >> 16 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield14 = ( this.__bitfield14 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// career_shiba_4の最大値
		/// </summary>
		public const UInt32 career_shiba_4_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// 芝成績4着以下
		/// </summary>
		public UInt32 career_shiba_4 {
			get { return ( this.__bitfield14 >> 24 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield14 = ( this.__bitfield14 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 60 byte data
		[FieldOffset(60)] private UInt32 __bitfield15;
		/// <summary>
		/// career_dirt_1の最大値
		/// </summary>
		public const UInt32 career_dirt_1_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ダート成績1着
		/// </summary>
		public UInt32 career_dirt_1 {
			get { return ( this.__bitfield15 >> 0 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield15 = ( this.__bitfield15 & 0xffffff00 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// career_dirt_2の最大値
		/// </summary>
		public const UInt32 career_dirt_2_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ダート成績2着
		/// </summary>
		public UInt32 career_dirt_2 {
			get { return ( this.__bitfield15 >> 8 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield15 = ( this.__bitfield15 & 0xffff00ff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// career_dirt_3の最大値
		/// </summary>
		public const UInt32 career_dirt_3_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ダート成績3着
		/// </summary>
		public UInt32 career_dirt_3 {
			get { return ( this.__bitfield15 >> 16 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield15 = ( this.__bitfield15 & 0xff00ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// career_dirt_4の最大値
		/// </summary>
		public const UInt32 career_dirt_4_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// ダート成績4着以下
		/// </summary>
		public UInt32 career_dirt_4 {
			get { return ( this.__bitfield15 >> 24 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield15 = ( this.__bitfield15 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 64 byte data
		[FieldOffset(64)] private UInt32 __bitfield16;
		/// <summary>
		/// padding_18の最大値
		/// </summary>
		public const UInt32 padding_18_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// padding_18
		/// </summary>
		public UInt32 padding_18 {
			get { return ( this.__bitfield16 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > padding_18_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield16 = ( this.__bitfield16 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// shizitsu_numの最大値
		/// </summary>
		public const UInt32 shizitsu_num_MAXVALUE = 0x00001fff; // 8191
		/// <summary>
		/// 史実番号
		/// </summary>
		public UInt32 shizitsu_num {
			get { return ( this.__bitfield16 >> 16 ) & 0x00001fff;  }
			set {
				if( value > shizitsu_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield16 = ( this.__bitfield16 & 0xe000ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// padding_19の最大値
		/// </summary>
		public const UInt32 padding_19_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// padding_19
		/// </summary>
		public UInt32 padding_19 {
			get { return ( this.__bitfield16 >> 29 ) & 0x00000007;  }
			set {
				if( value > padding_19_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield16 = ( this.__bitfield16 & 0x1fffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("mother_num"), 14, 16383, "母馬番号", "対象馬の母馬の血統番号" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("maruchihou"), 1, 1, "地方馬フラグ", "1=(地)\r\nフラグが立っていると(地)として表示されます" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_2"), 3, 7, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("hidarimawari_X"), 1, 1, "左回り×", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_3"), 2, 3, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("shusen_jk_num"), 9, 511, "主戦騎手番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_4"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("gender"), 1, 1, "性別", "0=牡馬 1=牝馬\r\nフラグが立っていると牝馬、立っていないと牡馬" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("houbokuchuu"), 4, 15, "放牧中", "0デビュー前 1通常放牧 2熱発 3疲労\r\n4疝痛 5フレグモーネ 6鼻出血 7ソエ 8裂蹄\r\n9去勢 10繋靱帯炎 11骨折 12屈腱炎\r\n13屈腱断裂 14粉砕骨折 15繋靱帯断裂" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_5"), 2, 3, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("kansen"), 1, 1, "観戦", "ONにすると観戦馬になる" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("weight_best"), 7, 127, "理想体重", "×2＋370kg" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("weight_now"), 7, 127, "馬体重", "×2＋370kg" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("zyumyou"), 7, 127, "競走寿命", "100以上にすると減らなくなる" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("age"), 3, 7, "年齢", "データ +2歳になる" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_6"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("seichou"), 7, 127, "成長度", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("keikenchi"), 7, 127, "経験値", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("race_kan"), 7, 127, "レース勘", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("choushi"), 6, 63, "調子", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("klass"), 3, 7, "クラス", "0:新馬 1:未勝利 2:500万下 3:1000万下 4:1600万下 5:オープン" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("choushi_status"), 2, 3, "調子向き", "0↓ 1→ 2↑" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("hirou"), 7, 127, "疲労度", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("houboku_len"), 6, 63, "何週間放牧", "残りの放牧週" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("father_num"), 11, 2047, "父馬番号", "対象馬の父馬の血統番号" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_8"), 8, 255, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_9"), 2, 3, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("intai"), 1, 1, "引退", "ONにすると引退" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_10"), 9, 511, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("souhou"), 2, 3, "走法", "0普通 1ピッチ 2大飛び" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("weak_point_1"), 2, 3, "脚部不安", "0なし 1改善 2あり" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("weak_point_2"), 2, 3, "のどなり", "0なし 1改善 2あり" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("weak_point_3"), 2, 3, "腰甘", "0なし 1改善 2あり" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("breeder"), 8, 255, "生産者", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("seigen"), 4, 15, "成長上限", "+100" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("price"), 14, 16383, "売買額", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("abl_num"), 15, 32767, "能力番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("torihiki"), 3, 7, "取引形態", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("earning_hon"), 20, 1048575, "本賞金", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("owner"), 12, 4095, "オーナー", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("earning_all"), 20, 1048575, "総賞金", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("trainer"), 9, 511, "調教師", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_11"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("nyuukyuu"), 1, 1, "入厩済み", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_12"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_13"), 26, 67108863, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("ensei"), 3, 7, "遠征先", "0or7他 1入厩前or放牧 2日本 3米国 4欧州 5ドバイ 6オセアニア" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_14"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("migimawari_X"), 1, 1, "右回り苦手", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("senba"), 1, 1, "セン馬", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_15"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_16"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_17"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("name_left"), 16, 65535, "馬名前半", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("name_right"), 16, 65535, "馬名後半", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("race_next_age"), 3, 7, "次走年齢 +2", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_next_location"), 2, 3, "開催地", "0関東 1関西 2ローカル 3海外,地方" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_next_sunday"), 1, 1, "曜日", "0土曜(米国,地方) 1日曜(欧州)" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_next_num"), 4, 15, "レース番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_next_week"), 6, 63, "週番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("race_last_age"), 3, 7, "前走年齢 +2", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_last_location"), 2, 3, "開催地", "0関東 1関西 2ローカル 3海外,地方" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_last_sunday"), 1, 1, "曜日", "0土曜(米国,地方) 1日曜(欧州)" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_last_num"), 4, 15, "レース番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("rase_last_week"), 6, 63, "週番号", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_shiba_1"), 8, 255, "芝成績1着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_shiba_2"), 8, 255, "芝成績2着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_shiba_3"), 8, 255, "芝成績3着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_shiba_4"), 8, 255, "芝成績4着以下", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_dirt_1"), 8, 255, "ダート成績1着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_dirt_2"), 8, 255, "ダート成績2着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_dirt_3"), 8, 255, "ダート成績3着", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("career_dirt_4"), 8, 255, "ダート成績4着以下", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_18"), 16, 65535, "", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("shizitsu_num"), 13, 8191, "史実番号", "" ),
				new DataStructPropertyInfo( typeof(HRaceData).GetProperty("padding_19"), 3, 7, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[17];
			data[0] = data[0] | ( this.mother_num << 0 ) ;
			data[0] = data[0] | ( this.maruchihou << 14 ) ;
			data[0] = data[0] | ( this.padding_2 << 15 ) ;
			data[0] = data[0] | ( this.hidarimawari_X << 18 ) ;
			data[0] = data[0] | ( this.padding_3 << 19 ) ;
			data[0] = data[0] | ( this.shusen_jk_num << 21 ) ;
			data[0] = data[0] | ( this.padding_4 << 30 ) ;
			data[0] = data[0] | ( this.gender << 31 ) ;
			data[1] = data[1] | ( this.houbokuchuu << 0 ) ;
			data[1] = data[1] | ( this.padding_5 << 4 ) ;
			data[1] = data[1] | ( this.kansen << 6 ) ;
			data[1] = data[1] | ( this.weight_best << 7 ) ;
			data[1] = data[1] | ( this.weight_now << 14 ) ;
			data[1] = data[1] | ( this.zyumyou << 21 ) ;
			data[1] = data[1] | ( this.age << 28 ) ;
			data[1] = data[1] | ( this.padding_6 << 31 ) ;
			data[2] = data[2] | ( this.seichou << 0 ) ;
			data[2] = data[2] | ( this.keikenchi << 7 ) ;
			data[2] = data[2] | ( this.race_kan << 14 ) ;
			data[2] = data[2] | ( this.choushi << 21 ) ;
			data[2] = data[2] | ( this.klass << 27 ) ;
			data[2] = data[2] | ( this.choushi_status << 30 ) ;
			data[3] = data[3] | ( this.hirou << 0 ) ;
			data[3] = data[3] | ( this.houboku_len << 7 ) ;
			data[3] = data[3] | ( this.father_num << 13 ) ;
			data[3] = data[3] | ( this.padding_8 << 24 ) ;
			data[4] = data[4] | ( this.padding_9 << 0 ) ;
			data[4] = data[4] | ( this.intai << 2 ) ;
			data[4] = data[4] | ( this.padding_10 << 3 ) ;
			data[4] = data[4] | ( this.souhou << 12 ) ;
			data[4] = data[4] | ( this.weak_point_1 << 14 ) ;
			data[4] = data[4] | ( this.weak_point_2 << 16 ) ;
			data[4] = data[4] | ( this.weak_point_3 << 18 ) ;
			data[4] = data[4] | ( this.breeder << 20 ) ;
			data[4] = data[4] | ( this.seigen << 28 ) ;
			data[5] = data[5] | ( this.price << 0 ) ;
			data[5] = data[5] | ( this.abl_num << 14 ) ;
			data[5] = data[5] | ( this.torihiki << 29 ) ;
			data[6] = data[6] | ( this.earning_hon << 0 ) ;
			data[6] = data[6] | ( this.owner << 20 ) ;
			data[7] = data[7] | ( this.earning_all << 0 ) ;
			data[7] = data[7] | ( this.trainer << 20 ) ;
			data[7] = data[7] | ( this.padding_11 << 29 ) ;
			data[7] = data[7] | ( this.nyuukyuu << 30 ) ;
			data[7] = data[7] | ( this.padding_12 << 31 ) ;
			data[8] = data[8] | ( this.padding_13 << 0 ) ;
			data[8] = data[8] | ( this.ensei << 26 ) ;
			data[8] = data[8] | ( this.padding_14 << 29 ) ;
			data[8] = data[8] | ( this.migimawari_X << 30 ) ;
			data[8] = data[8] | ( this.senba << 31 ) ;
			data[9] = data[9] | ( this.padding_15 << 0 ) ;
			data[10] = data[10] | ( this.padding_16 << 0 ) ;
			data[11] = data[11] | ( this.padding_17 << 0 ) ;
			data[12] = data[12] | ( this.name_left << 0 ) ;
			data[12] = data[12] | ( this.name_right << 16 ) ;
			data[13] = data[13] | ( this.race_next_age << 0 ) ;
			data[13] = data[13] | ( this.rase_next_location << 3 ) ;
			data[13] = data[13] | ( this.rase_next_sunday << 5 ) ;
			data[13] = data[13] | ( this.rase_next_num << 6 ) ;
			data[13] = data[13] | ( this.rase_next_week << 10 ) ;
			data[13] = data[13] | ( this.race_last_age << 16 ) ;
			data[13] = data[13] | ( this.rase_last_location << 19 ) ;
			data[13] = data[13] | ( this.rase_last_sunday << 21 ) ;
			data[13] = data[13] | ( this.rase_last_num << 22 ) ;
			data[13] = data[13] | ( this.rase_last_week << 26 ) ;
			data[14] = data[14] | ( this.career_shiba_1 << 0 ) ;
			data[14] = data[14] | ( this.career_shiba_2 << 8 ) ;
			data[14] = data[14] | ( this.career_shiba_3 << 16 ) ;
			data[14] = data[14] | ( this.career_shiba_4 << 24 ) ;
			data[15] = data[15] | ( this.career_dirt_1 << 0 ) ;
			data[15] = data[15] | ( this.career_dirt_2 << 8 ) ;
			data[15] = data[15] | ( this.career_dirt_3 << 16 ) ;
			data[15] = data[15] | ( this.career_dirt_4 << 24 ) ;
			data[16] = data[16] | ( this.padding_18 << 0 ) ;
			data[16] = data[16] | ( this.shizitsu_num << 16 ) ;
			data[16] = data[16] | ( this.padding_19 << 29 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HRaceData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 17 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 17)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
			this.__bitfield5 = data[5];
			this.__bitfield6 = data[6];
			this.__bitfield7 = data[7];
			this.__bitfield8 = data[8];
			this.__bitfield9 = data[9];
			this.__bitfield10 = data[10];
			this.__bitfield11 = data[11];
			this.__bitfield12 = data[12];
			this.__bitfield13 = data[13];
			this.__bitfield14 = data[14];
			this.__bitfield15 = data[15];
			this.__bitfield16 = data[16];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 17;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HOwnershipRaceData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// horse_numの最大値
		/// </summary>
		public const UInt32 horse_num_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 馬番号
		/// </summary>
		public UInt32 horse_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > horse_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_0の最大値
		/// </summary>
		public const UInt32 padding_0_MAXVALUE = 0x0003ffff; // 262143
		/// <summary>
		/// padding_0
		/// </summary>
		public UInt32 padding_0 {
			get { return ( this.__bitfield0 >> 14 ) & 0x0003ffff;  }
			set {
				if( value > padding_0_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-262143)");
				this.__bitfield0 = ( this.__bitfield0 & 0x00003fff ) | ( value << 14 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// padding_10の最大値
		/// </summary>
		public const UInt32 padding_10_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_10
		/// </summary>
		public UInt32 padding_10 {
			get { return ( this.__bitfield1 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield1 = ( this.__bitfield1 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// padding_20の最大値
		/// </summary>
		public const UInt32 padding_20_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_20
		/// </summary>
		public UInt32 padding_20 {
			get { return ( this.__bitfield2 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield2 = ( this.__bitfield2 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// padding_30の最大値
		/// </summary>
		public const UInt32 padding_30_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_30
		/// </summary>
		public UInt32 padding_30 {
			get { return ( this.__bitfield3 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_30_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield3 = ( this.__bitfield3 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// voice_numの最大値
		/// </summary>
		public const UInt32 voice_num_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 音声番号
		/// </summary>
		public UInt32 voice_num {
			get { return ( this.__bitfield4 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > voice_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_40の最大値
		/// </summary>
		public const UInt32 padding_40_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// padding_40
		/// </summary>
		public UInt32 padding_40 {
			get { return ( this.__bitfield4 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > padding_40_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield4 = ( this.__bitfield4 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		/// <summary>
		/// padding_50の最大値
		/// </summary>
		public const UInt32 padding_50_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_50
		/// </summary>
		public UInt32 padding_50 {
			get { return ( this.__bitfield5 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_50_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield5 = ( this.__bitfield5 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		/// <summary>
		/// padding_60の最大値
		/// </summary>
		public const UInt32 padding_60_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_60
		/// </summary>
		public UInt32 padding_60 {
			get { return ( this.__bitfield6 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_60_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield6 = ( this.__bitfield6 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		/// <summary>
		/// padding_70の最大値
		/// </summary>
		public const UInt32 padding_70_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_70
		/// </summary>
		public UInt32 padding_70 {
			get { return ( this.__bitfield7 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_70_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield7 = ( this.__bitfield7 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		/// <summary>
		/// padding_80の最大値
		/// </summary>
		public const UInt32 padding_80_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_80
		/// </summary>
		public UInt32 padding_80 {
			get { return ( this.__bitfield8 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_80_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield8 = ( this.__bitfield8 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		/// <summary>
		/// padding_90の最大値
		/// </summary>
		public const UInt32 padding_90_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_90
		/// </summary>
		public UInt32 padding_90 {
			get { return ( this.__bitfield9 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_90_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		/// <summary>
		/// padding_100の最大値
		/// </summary>
		public const UInt32 padding_100_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_100
		/// </summary>
		public UInt32 padding_100 {
			get { return ( this.__bitfield10 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_100_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield10 = ( this.__bitfield10 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 44 byte data
		[FieldOffset(44)] private UInt32 __bitfield11;
		/// <summary>
		/// padding_110の最大値
		/// </summary>
		public const UInt32 padding_110_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_110
		/// </summary>
		public UInt32 padding_110 {
			get { return ( this.__bitfield11 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_110_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield11 = ( this.__bitfield11 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 48 byte data
		[FieldOffset(48)] private UInt32 __bitfield12;
		/// <summary>
		/// padding_120の最大値
		/// </summary>
		public const UInt32 padding_120_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_120
		/// </summary>
		public UInt32 padding_120 {
			get { return ( this.__bitfield12 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_120_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield12 = ( this.__bitfield12 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 52 byte data
		[FieldOffset(52)] private UInt32 __bitfield13;
		/// <summary>
		/// padding_130の最大値
		/// </summary>
		public const UInt32 padding_130_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_130
		/// </summary>
		public UInt32 padding_130 {
			get { return ( this.__bitfield13 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_130_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield13 = ( this.__bitfield13 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 56 byte data
		[FieldOffset(56)] private UInt32 __bitfield14;
		/// <summary>
		/// padding_140の最大値
		/// </summary>
		public const UInt32 padding_140_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_140
		/// </summary>
		public UInt32 padding_140 {
			get { return ( this.__bitfield14 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_140_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield14 = ( this.__bitfield14 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 60 byte data
		[FieldOffset(60)] private UInt32 __bitfield15;
		/// <summary>
		/// padding_150の最大値
		/// </summary>
		public const UInt32 padding_150_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_150
		/// </summary>
		public UInt32 padding_150 {
			get { return ( this.__bitfield15 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_150_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield15 = ( this.__bitfield15 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 64 byte data
		[FieldOffset(64)] private UInt32 __bitfield16;
		/// <summary>
		/// padding_160の最大値
		/// </summary>
		public const UInt32 padding_160_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_160
		/// </summary>
		public UInt32 padding_160 {
			get { return ( this.__bitfield16 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_160_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield16 = ( this.__bitfield16 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 68 byte data
		[FieldOffset(68)] private UInt32 __bitfield17;
		/// <summary>
		/// padding_170の最大値
		/// </summary>
		public const UInt32 padding_170_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_170
		/// </summary>
		public UInt32 padding_170 {
			get { return ( this.__bitfield17 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_170_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield17 = ( this.__bitfield17 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 72 byte data
		[FieldOffset(72)] private UInt32 __bitfield18;
		/// <summary>
		/// padding_180の最大値
		/// </summary>
		public const UInt32 padding_180_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_180
		/// </summary>
		public UInt32 padding_180 {
			get { return ( this.__bitfield18 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_180_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield18 = ( this.__bitfield18 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 76 byte data
		[FieldOffset(76)] private UInt32 __bitfield19;
		/// <summary>
		/// padding_190の最大値
		/// </summary>
		public const UInt32 padding_190_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_190
		/// </summary>
		public UInt32 padding_190 {
			get { return ( this.__bitfield19 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_190_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield19 = ( this.__bitfield19 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 80 byte data
		[FieldOffset(80)] private UInt32 __bitfield20;
		/// <summary>
		/// padding_200の最大値
		/// </summary>
		public const UInt32 padding_200_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_200
		/// </summary>
		public UInt32 padding_200 {
			get { return ( this.__bitfield20 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_200_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield20 = ( this.__bitfield20 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 84 byte data
		[FieldOffset(84)] private UInt32 __bitfield21;
		/// <summary>
		/// padding_210の最大値
		/// </summary>
		public const UInt32 padding_210_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_210
		/// </summary>
		public UInt32 padding_210 {
			get { return ( this.__bitfield21 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_210_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield21 = ( this.__bitfield21 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 88 byte data
		[FieldOffset(88)] private UInt32 __bitfield22;
		/// <summary>
		/// padding_220の最大値
		/// </summary>
		public const UInt32 padding_220_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_220
		/// </summary>
		public UInt32 padding_220 {
			get { return ( this.__bitfield22 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_220_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield22 = ( this.__bitfield22 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 92 byte data
		[FieldOffset(92)] private UInt32 __bitfield23;
		/// <summary>
		/// padding_230の最大値
		/// </summary>
		public const UInt32 padding_230_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_230
		/// </summary>
		public UInt32 padding_230 {
			get { return ( this.__bitfield23 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_230_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield23 = ( this.__bitfield23 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 96 byte data
		[FieldOffset(96)] private UInt32 __bitfield24;
		/// <summary>
		/// padding_240の最大値
		/// </summary>
		public const UInt32 padding_240_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_240
		/// </summary>
		public UInt32 padding_240 {
			get { return ( this.__bitfield24 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_240_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield24 = ( this.__bitfield24 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 100 byte data
		[FieldOffset(100)] private UInt32 __bitfield25;
		/// <summary>
		/// padding_250の最大値
		/// </summary>
		public const UInt32 padding_250_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_250
		/// </summary>
		public UInt32 padding_250 {
			get { return ( this.__bitfield25 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_250_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield25 = ( this.__bitfield25 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 104 byte data
		[FieldOffset(104)] private UInt32 __bitfield26;
		/// <summary>
		/// padding_260の最大値
		/// </summary>
		public const UInt32 padding_260_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_260
		/// </summary>
		public UInt32 padding_260 {
			get { return ( this.__bitfield26 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_260_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield26 = ( this.__bitfield26 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 108 byte data
		[FieldOffset(108)] private UInt32 __bitfield27;
		/// <summary>
		/// padding_270の最大値
		/// </summary>
		public const UInt32 padding_270_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_270
		/// </summary>
		public UInt32 padding_270 {
			get { return ( this.__bitfield27 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_270_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield27 = ( this.__bitfield27 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 112 byte data
		[FieldOffset(112)] private UInt32 __bitfield28;
		/// <summary>
		/// padding_280の最大値
		/// </summary>
		public const UInt32 padding_280_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_280
		/// </summary>
		public UInt32 padding_280 {
			get { return ( this.__bitfield28 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_280_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield28 = ( this.__bitfield28 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 116 byte data
		[FieldOffset(116)] private UInt32 __bitfield29;
		/// <summary>
		/// padding_290の最大値
		/// </summary>
		public const UInt32 padding_290_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_290
		/// </summary>
		public UInt32 padding_290 {
			get { return ( this.__bitfield29 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_290_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield29 = ( this.__bitfield29 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 120 byte data
		[FieldOffset(120)] private UInt32 __bitfield30;
		/// <summary>
		/// padding_300の最大値
		/// </summary>
		public const UInt32 padding_300_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_300
		/// </summary>
		public UInt32 padding_300 {
			get { return ( this.__bitfield30 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_300_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield30 = ( this.__bitfield30 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 124 byte data
		[FieldOffset(124)] private UInt32 __bitfield31;
		/// <summary>
		/// padding_310の最大値
		/// </summary>
		public const UInt32 padding_310_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_310
		/// </summary>
		public UInt32 padding_310 {
			get { return ( this.__bitfield31 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_310_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield31 = ( this.__bitfield31 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 128 byte data
		[FieldOffset(128)] private UInt32 __bitfield32;
		/// <summary>
		/// padding_320の最大値
		/// </summary>
		public const UInt32 padding_320_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_320
		/// </summary>
		public UInt32 padding_320 {
			get { return ( this.__bitfield32 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_320_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield32 = ( this.__bitfield32 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 132 byte data
		[FieldOffset(132)] private UInt32 __bitfield33;
		/// <summary>
		/// race_num_2の最大値
		/// </summary>
		public const UInt32 race_num_2_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第2戦)
		/// </summary>
		public UInt32 race_num_2 {
			get { return ( this.__bitfield33 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_num_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield33 = ( this.__bitfield33 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// race_num_3の最大値
		/// </summary>
		public const UInt32 race_num_3_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第3戦)
		/// </summary>
		public UInt32 race_num_3 {
			get { return ( this.__bitfield33 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > race_num_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield33 = ( this.__bitfield33 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 136 byte data
		[FieldOffset(136)] private UInt32 __bitfield34;
		/// <summary>
		/// race_num_4の最大値
		/// </summary>
		public const UInt32 race_num_4_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第4戦)
		/// </summary>
		public UInt32 race_num_4 {
			get { return ( this.__bitfield34 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_num_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield34 = ( this.__bitfield34 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// race_num_5の最大値
		/// </summary>
		public const UInt32 race_num_5_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第5戦)
		/// </summary>
		public UInt32 race_num_5 {
			get { return ( this.__bitfield34 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > race_num_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield34 = ( this.__bitfield34 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 140 byte data
		[FieldOffset(140)] private UInt32 __bitfield35;
		/// <summary>
		/// race_num_6の最大値
		/// </summary>
		public const UInt32 race_num_6_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第6戦)
		/// </summary>
		public UInt32 race_num_6 {
			get { return ( this.__bitfield35 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_num_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield35 = ( this.__bitfield35 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// race_num_7の最大値
		/// </summary>
		public const UInt32 race_num_7_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第7戦)
		/// </summary>
		public UInt32 race_num_7 {
			get { return ( this.__bitfield35 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > race_num_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield35 = ( this.__bitfield35 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 144 byte data
		[FieldOffset(144)] private UInt32 __bitfield36;
		/// <summary>
		/// race_num_8の最大値
		/// </summary>
		public const UInt32 race_num_8_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第8戦)
		/// </summary>
		public UInt32 race_num_8 {
			get { return ( this.__bitfield36 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_num_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield36 = ( this.__bitfield36 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// race_num_9の最大値
		/// </summary>
		public const UInt32 race_num_9_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第9戦)
		/// </summary>
		public UInt32 race_num_9 {
			get { return ( this.__bitfield36 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > race_num_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield36 = ( this.__bitfield36 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 148 byte data
		[FieldOffset(148)] private UInt32 __bitfield37;
		/// <summary>
		/// race_num_10の最大値
		/// </summary>
		public const UInt32 race_num_10_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// ローテーション(第10戦)
		/// </summary>
		public UInt32 race_num_10 {
			get { return ( this.__bitfield37 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_num_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield37 = ( this.__bitfield37 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// jockey_1の最大値
		/// </summary>
		public const UInt32 jockey_1_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第1戦)
		/// </summary>
		public UInt32 jockey_1 {
			get { return ( this.__bitfield37 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > jockey_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield37 = ( this.__bitfield37 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 152 byte data
		[FieldOffset(152)] private UInt32 __bitfield38;
		/// <summary>
		/// jockey_2の最大値
		/// </summary>
		public const UInt32 jockey_2_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第2戦)
		/// </summary>
		public UInt32 jockey_2 {
			get { return ( this.__bitfield38 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > jockey_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield38 = ( this.__bitfield38 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// jockey_3の最大値
		/// </summary>
		public const UInt32 jockey_3_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第3戦)
		/// </summary>
		public UInt32 jockey_3 {
			get { return ( this.__bitfield38 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > jockey_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield38 = ( this.__bitfield38 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 156 byte data
		[FieldOffset(156)] private UInt32 __bitfield39;
		/// <summary>
		/// jockey_4の最大値
		/// </summary>
		public const UInt32 jockey_4_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第4戦)
		/// </summary>
		public UInt32 jockey_4 {
			get { return ( this.__bitfield39 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > jockey_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield39 = ( this.__bitfield39 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// jockey_5の最大値
		/// </summary>
		public const UInt32 jockey_5_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第5戦)
		/// </summary>
		public UInt32 jockey_5 {
			get { return ( this.__bitfield39 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > jockey_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield39 = ( this.__bitfield39 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 160 byte data
		[FieldOffset(160)] private UInt32 __bitfield40;
		/// <summary>
		/// jockey_6の最大値
		/// </summary>
		public const UInt32 jockey_6_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第6戦)
		/// </summary>
		public UInt32 jockey_6 {
			get { return ( this.__bitfield40 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > jockey_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield40 = ( this.__bitfield40 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// jockey_7の最大値
		/// </summary>
		public const UInt32 jockey_7_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第7戦)
		/// </summary>
		public UInt32 jockey_7 {
			get { return ( this.__bitfield40 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > jockey_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield40 = ( this.__bitfield40 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 164 byte data
		[FieldOffset(164)] private UInt32 __bitfield41;
		/// <summary>
		/// jockey_8の最大値
		/// </summary>
		public const UInt32 jockey_8_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第8戦)
		/// </summary>
		public UInt32 jockey_8 {
			get { return ( this.__bitfield41 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > jockey_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield41 = ( this.__bitfield41 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// jockey_9の最大値
		/// </summary>
		public const UInt32 jockey_9_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第9戦)
		/// </summary>
		public UInt32 jockey_9 {
			get { return ( this.__bitfield41 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > jockey_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield41 = ( this.__bitfield41 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 168 byte data
		[FieldOffset(168)] private UInt32 __bitfield42;
		/// <summary>
		/// jockey_10の最大値
		/// </summary>
		public const UInt32 jockey_10_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// 騎手(第10戦)
		/// </summary>
		public UInt32 jockey_10 {
			get { return ( this.__bitfield42 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > jockey_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield42 = ( this.__bitfield42 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_420の最大値
		/// </summary>
		public const UInt32 padding_420_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// padding_420
		/// </summary>
		public UInt32 padding_420 {
			get { return ( this.__bitfield42 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > padding_420_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield42 = ( this.__bitfield42 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 172 byte data
		[FieldOffset(172)] private UInt32 __bitfield43;
		/// <summary>
		/// training_yellowの最大値
		/// </summary>
		public const UInt32 training_yellow_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 育成度(黄)
		/// </summary>
		public UInt32 training_yellow {
			get { return ( this.__bitfield43 >> 0 ) & 0x0000007f;  }
			set {
				if( value > training_yellow_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield43 = ( this.__bitfield43 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// training_greenの最大値
		/// </summary>
		public const UInt32 training_green_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 育成度(緑)
		/// </summary>
		public UInt32 training_green {
			get { return ( this.__bitfield43 >> 7 ) & 0x0000007f;  }
			set {
				if( value > training_green_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield43 = ( this.__bitfield43 & 0xffffc07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// seichou_speedの最大値
		/// </summary>
		public const UInt32 seichou_speed_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 成長(SP)
		/// </summary>
		public UInt32 seichou_speed {
			get { return ( this.__bitfield43 >> 14 ) & 0x0000007f;  }
			set {
				if( value > seichou_speed_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield43 = ( this.__bitfield43 & 0xffe03fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// seichou_konzyouの最大値
		/// </summary>
		public const UInt32 seichou_konzyou_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(根性)
		/// </summary>
		public UInt32 seichou_konzyou {
			get { return ( this.__bitfield43 >> 21 ) & 0x0000001f;  }
			set {
				if( value > seichou_konzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield43 = ( this.__bitfield43 & 0xfc1fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// seichou_syunpatsuの最大値
		/// </summary>
		public const UInt32 seichou_syunpatsu_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(瞬発力)
		/// </summary>
		public UInt32 seichou_syunpatsu {
			get { return ( this.__bitfield43 >> 26 ) & 0x0000001f;  }
			set {
				if( value > seichou_syunpatsu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield43 = ( this.__bitfield43 & 0x83ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// memo_open_1の最大値
		/// </summary>
		public const UInt32 memo_open_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ成長型表示
		/// </summary>
		public UInt32 memo_open_1 {
			get { return ( this.__bitfield43 >> 31 ) & 0x00000001;  }
			set {
				if( value > memo_open_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield43 = ( this.__bitfield43 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 176 byte data
		[FieldOffset(176)] private UInt32 __bitfield44;
		/// <summary>
		/// seichou_powerの最大値
		/// </summary>
		public const UInt32 seichou_power_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(瞬発力)
		/// </summary>
		public UInt32 seichou_power {
			get { return ( this.__bitfield44 >> 0 ) & 0x0000001f;  }
			set {
				if( value > seichou_power_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield44 = ( this.__bitfield44 & 0xffffffe0 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// seichou_zyuunanの最大値
		/// </summary>
		public const UInt32 seichou_zyuunan_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(柔軟性)
		/// </summary>
		public UInt32 seichou_zyuunan {
			get { return ( this.__bitfield44 >> 5 ) & 0x0000001f;  }
			set {
				if( value > seichou_zyuunan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield44 = ( this.__bitfield44 & 0xfffffc1f ) | ( value << 5 );
			}
		}
		/// <summary>
		/// seichou_seishinの最大値
		/// </summary>
		public const UInt32 seichou_seishin_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(精神力)
		/// </summary>
		public UInt32 seichou_seishin {
			get { return ( this.__bitfield44 >> 10 ) & 0x0000001f;  }
			set {
				if( value > seichou_seishin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield44 = ( this.__bitfield44 & 0xffff83ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// seichou_kashikosaの最大値
		/// </summary>
		public const UInt32 seichou_kashikosa_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(賢さ)
		/// </summary>
		public UInt32 seichou_kashikosa {
			get { return ( this.__bitfield44 >> 15 ) & 0x0000001f;  }
			set {
				if( value > seichou_kashikosa_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield44 = ( this.__bitfield44 & 0xfff07fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// seichou_healthの最大値
		/// </summary>
		public const UInt32 seichou_health_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(健康)
		/// </summary>
		public UInt32 seichou_health {
			get { return ( this.__bitfield44 >> 20 ) & 0x0000001f;  }
			set {
				if( value > seichou_health_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield44 = ( this.__bitfield44 & 0xfe0fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// memo_open_2の最大値
		/// </summary>
		public const UInt32 memo_open_2_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ気性表示
		/// </summary>
		public UInt32 memo_open_2 {
			get { return ( this.__bitfield44 >> 25 ) & 0x00000001;  }
			set {
				if( value > memo_open_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield44 = ( this.__bitfield44 & 0xfdffffff ) | ( value << 25 );
			}
		}
		/// <summary>
		/// memo_open_3の最大値
		/// </summary>
		public const UInt32 memo_open_3_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ馬場適正表示
		/// </summary>
		public UInt32 memo_open_3 {
			get { return ( this.__bitfield44 >> 26 ) & 0x00000001;  }
			set {
				if( value > memo_open_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield44 = ( this.__bitfield44 & 0xfbffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// memo_open_4の最大値
		/// </summary>
		public const UInt32 memo_open_4_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ重馬場適正表示
		/// </summary>
		public UInt32 memo_open_4 {
			get { return ( this.__bitfield44 >> 27 ) & 0x00000001;  }
			set {
				if( value > memo_open_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield44 = ( this.__bitfield44 & 0xf7ffffff ) | ( value << 27 );
			}
		}
		/// <summary>
		/// padding_440の最大値
		/// </summary>
		public const UInt32 padding_440_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_440
		/// </summary>
		public UInt32 padding_440 {
			get { return ( this.__bitfield44 >> 28 ) & 0x00000001;  }
			set {
				if( value > padding_440_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield44 = ( this.__bitfield44 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// markの最大値
		/// </summary>
		public const UInt32 mark_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// マーク表示 0無印 1春雷 2流星 3暁
		/// </summary>
		public UInt32 mark {
			get { return ( this.__bitfield44 >> 29 ) & 0x00000003;  }
			set {
				if( value > mark_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield44 = ( this.__bitfield44 & 0x9fffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// padding_441の最大値
		/// </summary>
		public const UInt32 padding_441_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_441
		/// </summary>
		public UInt32 padding_441 {
			get { return ( this.__bitfield44 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_441_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield44 = ( this.__bitfield44 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 180 byte data
		[FieldOffset(180)] private UInt32 __bitfield45;
		/// <summary>
		/// memo_open_5の最大値
		/// </summary>
		public const UInt32 memo_open_5_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(小回り)
		/// </summary>
		public UInt32 memo_open_5 {
			get { return ( this.__bitfield45 >> 0 ) & 0x00000001;  }
			set {
				if( value > memo_open_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffffe ) | ( value << 0 );
			}
		}
		/// <summary>
		/// memo_open_6の最大値
		/// </summary>
		public const UInt32 memo_open_6_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(右)
		/// </summary>
		public UInt32 memo_open_6 {
			get { return ( this.__bitfield45 >> 1 ) & 0x00000001;  }
			set {
				if( value > memo_open_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffffd ) | ( value << 1 );
			}
		}
		/// <summary>
		/// memo_open_7の最大値
		/// </summary>
		public const UInt32 memo_open_7_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(左)
		/// </summary>
		public UInt32 memo_open_7 {
			get { return ( this.__bitfield45 >> 2 ) & 0x00000001;  }
			set {
				if( value > memo_open_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffffb ) | ( value << 2 );
			}
		}
		/// <summary>
		/// memo_open_8の最大値
		/// </summary>
		public const UInt32 memo_open_8_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ走法表示
		/// </summary>
		public UInt32 memo_open_8 {
			get { return ( this.__bitfield45 >> 3 ) & 0x00000001;  }
			set {
				if( value > memo_open_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffff7 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// memo_open_9の最大値
		/// </summary>
		public const UInt32 memo_open_9_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(喉なり)
		/// </summary>
		public UInt32 memo_open_9 {
			get { return ( this.__bitfield45 >> 4 ) & 0x00000001;  }
			set {
				if( value > memo_open_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffffef ) | ( value << 4 );
			}
		}
		/// <summary>
		/// memo_open_10の最大値
		/// </summary>
		public const UInt32 memo_open_10_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(脚部不安)
		/// </summary>
		public UInt32 memo_open_10 {
			get { return ( this.__bitfield45 >> 5 ) & 0x00000001;  }
			set {
				if( value > memo_open_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffffdf ) | ( value << 5 );
			}
		}
		/// <summary>
		/// memo_open_11の最大値
		/// </summary>
		public const UInt32 memo_open_11_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(腰甘)
		/// </summary>
		public UInt32 memo_open_11 {
			get { return ( this.__bitfield45 >> 6 ) & 0x00000001;  }
			set {
				if( value > memo_open_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffffbf ) | ( value << 6 );
			}
		}
		/// <summary>
		/// memo_open_12の最大値
		/// </summary>
		public const UInt32 memo_open_12_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモSP表示
		/// </summary>
		public UInt32 memo_open_12 {
			get { return ( this.__bitfield45 >> 7 ) & 0x00000001;  }
			set {
				if( value > memo_open_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffff7f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// memo_open_13の最大値
		/// </summary>
		public const UInt32 memo_open_13_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ勝負根性表示
		/// </summary>
		public UInt32 memo_open_13 {
			get { return ( this.__bitfield45 >> 8 ) & 0x00000001;  }
			set {
				if( value > memo_open_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffeff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// memo_open_14の最大値
		/// </summary>
		public const UInt32 memo_open_14_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ瞬発力表示
		/// </summary>
		public UInt32 memo_open_14 {
			get { return ( this.__bitfield45 >> 9 ) & 0x00000001;  }
			set {
				if( value > memo_open_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffdff ) | ( value << 9 );
			}
		}
		/// <summary>
		/// memo_open_15の最大値
		/// </summary>
		public const UInt32 memo_open_15_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモパワー表示
		/// </summary>
		public UInt32 memo_open_15 {
			get { return ( this.__bitfield45 >> 10 ) & 0x00000001;  }
			set {
				if( value > memo_open_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffffbff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// memo_open_16の最大値
		/// </summary>
		public const UInt32 memo_open_16_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ柔軟性表示
		/// </summary>
		public UInt32 memo_open_16 {
			get { return ( this.__bitfield45 >> 11 ) & 0x00000001;  }
			set {
				if( value > memo_open_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffff7ff ) | ( value << 11 );
			}
		}
		/// <summary>
		/// memo_open_17の最大値
		/// </summary>
		public const UInt32 memo_open_17_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ精神力表示
		/// </summary>
		public UInt32 memo_open_17 {
			get { return ( this.__bitfield45 >> 12 ) & 0x00000001;  }
			set {
				if( value > memo_open_17_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffefff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// memo_open_18の最大値
		/// </summary>
		public const UInt32 memo_open_18_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ賢さ表示
		/// </summary>
		public UInt32 memo_open_18 {
			get { return ( this.__bitfield45 >> 13 ) & 0x00000001;  }
			set {
				if( value > memo_open_18_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffdfff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// memo_open_19の最大値
		/// </summary>
		public const UInt32 memo_open_19_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ健康表示
		/// </summary>
		public UInt32 memo_open_19 {
			get { return ( this.__bitfield45 >> 14 ) & 0x00000001;  }
			set {
				if( value > memo_open_19_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffffbfff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// memo_open_20の最大値
		/// </summary>
		public const UInt32 memo_open_20_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ適正距離表示
		/// </summary>
		public UInt32 memo_open_20 {
			get { return ( this.__bitfield45 >> 15 ) & 0x00000001;  }
			set {
				if( value > memo_open_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffff7fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// memo_open_21の最大値
		/// </summary>
		public const UInt32 memo_open_21_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// スピード成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_21 {
			get { return ( this.__bitfield45 >> 16 ) & 0x00000001;  }
			set {
				if( value > memo_open_21_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffeffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// memo_open_22の最大値
		/// </summary>
		public const UInt32 memo_open_22_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 勝負根性成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_22 {
			get { return ( this.__bitfield45 >> 17 ) & 0x00000001;  }
			set {
				if( value > memo_open_22_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffdffff ) | ( value << 17 );
			}
		}
		/// <summary>
		/// memo_open_23の最大値
		/// </summary>
		public const UInt32 memo_open_23_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 瞬発力成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_23 {
			get { return ( this.__bitfield45 >> 18 ) & 0x00000001;  }
			set {
				if( value > memo_open_23_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfffbffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// memo_open_24の最大値
		/// </summary>
		public const UInt32 memo_open_24_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// パワー成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_24 {
			get { return ( this.__bitfield45 >> 19 ) & 0x00000001;  }
			set {
				if( value > memo_open_24_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xfff7ffff ) | ( value << 19 );
			}
		}
		/// <summary>
		/// memo_open_25の最大値
		/// </summary>
		public const UInt32 memo_open_25_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 柔軟性成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_25 {
			get { return ( this.__bitfield45 >> 20 ) & 0x00000001;  }
			set {
				if( value > memo_open_25_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffefffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// memo_open_26の最大値
		/// </summary>
		public const UInt32 memo_open_26_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 精神力成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_26 {
			get { return ( this.__bitfield45 >> 21 ) & 0x00000001;  }
			set {
				if( value > memo_open_26_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffdfffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// memo_open_27の最大値
		/// </summary>
		public const UInt32 memo_open_27_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 賢さ成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_27 {
			get { return ( this.__bitfield45 >> 22 ) & 0x00000001;  }
			set {
				if( value > memo_open_27_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xffbfffff ) | ( value << 22 );
			}
		}
		/// <summary>
		/// memo_open_28の最大値
		/// </summary>
		public const UInt32 memo_open_28_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 健康成長(表示のみ)
		/// </summary>
		public UInt32 memo_open_28 {
			get { return ( this.__bitfield45 >> 23 ) & 0x00000001;  }
			set {
				if( value > memo_open_28_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xff7fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// padding_450の最大値
		/// </summary>
		public const UInt32 padding_450_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// padding_450
		/// </summary>
		public UInt32 padding_450 {
			get { return ( this.__bitfield45 >> 24 ) & 0x0000000f;  }
			set {
				if( value > padding_450_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield45 = ( this.__bitfield45 & 0xf0ffffff ) | ( value << 24 );
			}
		}
		/// <summary>
		/// memo_open_29の最大値
		/// </summary>
		public const UInt32 memo_open_29_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ脚質表示
		/// </summary>
		public UInt32 memo_open_29 {
			get { return ( this.__bitfield45 >> 28 ) & 0x00000001;  }
			set {
				if( value > memo_open_29_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield45 = ( this.__bitfield45 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// padding_451の最大値
		/// </summary>
		public const UInt32 padding_451_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// padding_451
		/// </summary>
		public UInt32 padding_451 {
			get { return ( this.__bitfield45 >> 29 ) & 0x00000007;  }
			set {
				if( value > padding_451_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield45 = ( this.__bitfield45 & 0x1fffffff ) | ( value << 29 );
			}
		}
		// 184 byte data
		[FieldOffset(184)] private UInt32 __bitfield46;
		/// <summary>
		/// padding_460の最大値
		/// </summary>
		public const UInt32 padding_460_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_460
		/// </summary>
		public UInt32 padding_460 {
			get { return ( this.__bitfield46 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_460_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield46 = ( this.__bitfield46 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 188 byte data
		[FieldOffset(188)] private UInt32 __bitfield47;
		/// <summary>
		/// padding_470の最大値
		/// </summary>
		public const UInt32 padding_470_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_470
		/// </summary>
		public UInt32 padding_470 {
			get { return ( this.__bitfield47 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_470_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield47 = ( this.__bitfield47 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 192 byte data
		[FieldOffset(192)] private UInt32 __bitfield48;
		/// <summary>
		/// padding_480の最大値
		/// </summary>
		public const UInt32 padding_480_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_480
		/// </summary>
		public UInt32 padding_480 {
			get { return ( this.__bitfield48 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_480_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield48 = ( this.__bitfield48 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 196 byte data
		[FieldOffset(196)] private UInt32 __bitfield49;
		/// <summary>
		/// padding_490の最大値
		/// </summary>
		public const UInt32 padding_490_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_490
		/// </summary>
		public UInt32 padding_490 {
			get { return ( this.__bitfield49 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_490_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield49 = ( this.__bitfield49 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 200 byte data
		[FieldOffset(200)] private UInt32 __bitfield50;
		/// <summary>
		/// padding_500の最大値
		/// </summary>
		public const UInt32 padding_500_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_500
		/// </summary>
		public UInt32 padding_500 {
			get { return ( this.__bitfield50 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_500_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield50 = ( this.__bitfield50 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 204 byte data
		[FieldOffset(204)] private UInt32 __bitfield51;
		/// <summary>
		/// padding_510の最大値
		/// </summary>
		public const UInt32 padding_510_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_510
		/// </summary>
		public UInt32 padding_510 {
			get { return ( this.__bitfield51 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_510_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield51 = ( this.__bitfield51 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 208 byte data
		[FieldOffset(208)] private UInt32 __bitfield52;
		/// <summary>
		/// padding_520の最大値
		/// </summary>
		public const UInt32 padding_520_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_520
		/// </summary>
		public UInt32 padding_520 {
			get { return ( this.__bitfield52 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_520_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield52 = ( this.__bitfield52 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 212 byte data
		[FieldOffset(212)] private UInt32 __bitfield53;
		/// <summary>
		/// padding_530の最大値
		/// </summary>
		public const UInt32 padding_530_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_530
		/// </summary>
		public UInt32 padding_530 {
			get { return ( this.__bitfield53 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_530_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield53 = ( this.__bitfield53 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 216 byte data
		[FieldOffset(216)] private UInt32 __bitfield54;
		/// <summary>
		/// padding_540の最大値
		/// </summary>
		public const UInt32 padding_540_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_540
		/// </summary>
		public UInt32 padding_540 {
			get { return ( this.__bitfield54 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_540_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield54 = ( this.__bitfield54 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 220 byte data
		[FieldOffset(220)] private UInt32 __bitfield55;
		/// <summary>
		/// padding_550の最大値
		/// </summary>
		public const UInt32 padding_550_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_550
		/// </summary>
		public UInt32 padding_550 {
			get { return ( this.__bitfield55 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_550_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield55 = ( this.__bitfield55 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 224 byte data
		[FieldOffset(224)] private UInt32 __bitfield56;
		/// <summary>
		/// padding_560の最大値
		/// </summary>
		public const UInt32 padding_560_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_560
		/// </summary>
		public UInt32 padding_560 {
			get { return ( this.__bitfield56 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_560_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield56 = ( this.__bitfield56 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 228 byte data
		[FieldOffset(228)] private UInt32 __bitfield57;
		/// <summary>
		/// padding_570の最大値
		/// </summary>
		public const UInt32 padding_570_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_570
		/// </summary>
		public UInt32 padding_570 {
			get { return ( this.__bitfield57 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_570_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield57 = ( this.__bitfield57 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 232 byte data
		[FieldOffset(232)] private UInt32 __bitfield58;
		/// <summary>
		/// padding_580の最大値
		/// </summary>
		public const UInt32 padding_580_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_580
		/// </summary>
		public UInt32 padding_580 {
			get { return ( this.__bitfield58 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_580_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield58 = ( this.__bitfield58 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 236 byte data
		[FieldOffset(236)] private UInt32 __bitfield59;
		/// <summary>
		/// padding_590の最大値
		/// </summary>
		public const UInt32 padding_590_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_590
		/// </summary>
		public UInt32 padding_590 {
			get { return ( this.__bitfield59 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_590_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield59 = ( this.__bitfield59 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 240 byte data
		[FieldOffset(240)] private UInt32 __bitfield60;
		/// <summary>
		/// padding_600の最大値
		/// </summary>
		public const UInt32 padding_600_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_600
		/// </summary>
		public UInt32 padding_600 {
			get { return ( this.__bitfield60 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_600_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield60 = ( this.__bitfield60 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 244 byte data
		[FieldOffset(244)] private UInt32 __bitfield61;
		/// <summary>
		/// padding_610の最大値
		/// </summary>
		public const UInt32 padding_610_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_610
		/// </summary>
		public UInt32 padding_610 {
			get { return ( this.__bitfield61 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_610_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield61 = ( this.__bitfield61 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 248 byte data
		[FieldOffset(248)] private UInt32 __bitfield62;
		/// <summary>
		/// padding_620の最大値
		/// </summary>
		public const UInt32 padding_620_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_620
		/// </summary>
		public UInt32 padding_620 {
			get { return ( this.__bitfield62 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_620_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield62 = ( this.__bitfield62 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 252 byte data
		[FieldOffset(252)] private UInt32 __bitfield63;
		/// <summary>
		/// padding_630の最大値
		/// </summary>
		public const UInt32 padding_630_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_630
		/// </summary>
		public UInt32 padding_630 {
			get { return ( this.__bitfield63 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_630_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield63 = ( this.__bitfield63 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 256 byte data
		[FieldOffset(256)] private UInt32 __bitfield64;
		/// <summary>
		/// padding_640の最大値
		/// </summary>
		public const UInt32 padding_640_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_640
		/// </summary>
		public UInt32 padding_640 {
			get { return ( this.__bitfield64 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_640_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield64 = ( this.__bitfield64 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 260 byte data
		[FieldOffset(260)] private UInt32 __bitfield65;
		/// <summary>
		/// padding_650の最大値
		/// </summary>
		public const UInt32 padding_650_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_650
		/// </summary>
		public UInt32 padding_650 {
			get { return ( this.__bitfield65 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_650_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield65 = ( this.__bitfield65 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 264 byte data
		[FieldOffset(264)] private UInt32 __bitfield66;
		/// <summary>
		/// padding_660の最大値
		/// </summary>
		public const UInt32 padding_660_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_660
		/// </summary>
		public UInt32 padding_660 {
			get { return ( this.__bitfield66 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_660_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield66 = ( this.__bitfield66 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 268 byte data
		[FieldOffset(268)] private UInt32 __bitfield67;
		/// <summary>
		/// padding_670の最大値
		/// </summary>
		public const UInt32 padding_670_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_670
		/// </summary>
		public UInt32 padding_670 {
			get { return ( this.__bitfield67 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_670_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield67 = ( this.__bitfield67 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 272 byte data
		[FieldOffset(272)] private UInt32 __bitfield68;
		/// <summary>
		/// padding_680の最大値
		/// </summary>
		public const UInt32 padding_680_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_680
		/// </summary>
		public UInt32 padding_680 {
			get { return ( this.__bitfield68 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_680_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield68 = ( this.__bitfield68 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 276 byte data
		[FieldOffset(276)] private UInt32 __bitfield69;
		/// <summary>
		/// padding_690の最大値
		/// </summary>
		public const UInt32 padding_690_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_690
		/// </summary>
		public UInt32 padding_690 {
			get { return ( this.__bitfield69 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_690_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield69 = ( this.__bitfield69 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 280 byte data
		[FieldOffset(280)] private UInt32 __bitfield70;
		/// <summary>
		/// padding_700の最大値
		/// </summary>
		public const UInt32 padding_700_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_700
		/// </summary>
		public UInt32 padding_700 {
			get { return ( this.__bitfield70 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_700_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield70 = ( this.__bitfield70 & 0x00000000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("horse_num"), 14, 16383, "馬番号", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_0"), 18, 262143, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_10"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_20"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_30"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("voice_num"), 16, 65535, "音声番号", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_40"), 16, 65535, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_50"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_60"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_70"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_80"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_90"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_100"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_110"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_120"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_130"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_140"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_150"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_160"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_170"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_180"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_190"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_200"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_210"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_220"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_230"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_240"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_250"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_260"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_270"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_280"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_290"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_300"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_310"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_320"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_2"), 16, 65535, "ローテーション(第2戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_3"), 16, 65535, "ローテーション(第3戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_4"), 16, 65535, "ローテーション(第4戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_5"), 16, 65535, "ローテーション(第5戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_6"), 16, 65535, "ローテーション(第6戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_7"), 16, 65535, "ローテーション(第7戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_8"), 16, 65535, "ローテーション(第8戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_9"), 16, 65535, "ローテーション(第9戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("race_num_10"), 16, 65535, "ローテーション(第10戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_1"), 16, 65535, "騎手(第1戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_2"), 16, 65535, "騎手(第2戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_3"), 16, 65535, "騎手(第3戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_4"), 16, 65535, "騎手(第4戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_5"), 16, 65535, "騎手(第5戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_6"), 16, 65535, "騎手(第6戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_7"), 16, 65535, "騎手(第7戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_8"), 16, 65535, "騎手(第8戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_9"), 16, 65535, "騎手(第9戦)", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("jockey_10"), 16, 65535, "騎手(第10戦)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_420"), 16, 65535, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("training_yellow"), 7, 127, "育成度(黄)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("training_green"), 7, 127, "育成度(緑)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_speed"), 7, 127, "成長(SP)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_konzyou"), 5, 31, "成長(根性)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_syunpatsu"), 5, 31, "成長(瞬発力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_1"), 1, 1, "メモ成長型表示", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_power"), 5, 31, "成長(瞬発力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_zyuunan"), 5, 31, "成長(柔軟性)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_seishin"), 5, 31, "成長(精神力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_kashikosa"), 5, 31, "成長(賢さ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("seichou_health"), 5, 31, "成長(健康)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_2"), 1, 1, "メモ気性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_3"), 1, 1, "メモ馬場適正表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_4"), 1, 1, "メモ重馬場適正表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_440"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("mark"), 2, 3, "マーク表示 0無印 1春雷 2流星 3暁", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_441"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_5"), 1, 1, "メモ回り表示(小回り)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_6"), 1, 1, "メモ回り表示(右)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_7"), 1, 1, "メモ回り表示(左)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_8"), 1, 1, "メモ走法表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_9"), 1, 1, "メモ持病表示(喉なり)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_10"), 1, 1, "メモ持病表示(脚部不安)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_11"), 1, 1, "メモ持病表示(腰甘)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_12"), 1, 1, "メモSP表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_13"), 1, 1, "メモ勝負根性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_14"), 1, 1, "メモ瞬発力表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_15"), 1, 1, "メモパワー表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_16"), 1, 1, "メモ柔軟性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_17"), 1, 1, "メモ精神力表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_18"), 1, 1, "メモ賢さ表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_19"), 1, 1, "メモ健康表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_20"), 1, 1, "メモ適正距離表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_21"), 1, 1, "スピード成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_22"), 1, 1, "勝負根性成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_23"), 1, 1, "瞬発力成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_24"), 1, 1, "パワー成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_25"), 1, 1, "柔軟性成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_26"), 1, 1, "精神力成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_27"), 1, 1, "賢さ成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_28"), 1, 1, "健康成長(表示のみ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_450"), 4, 15, "", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("memo_open_29"), 1, 1, "メモ脚質表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_451"), 3, 7, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_460"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_470"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_480"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_490"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_500"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_510"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_520"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_530"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_540"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_550"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_560"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_570"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_580"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_590"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_600"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_610"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_620"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_630"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_640"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_650"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_660"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_670"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_680"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_690"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipRaceData).GetProperty("padding_700"), 32, 4294967295, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[71];
			data[0] = data[0] | ( this.horse_num << 0 ) ;
			data[0] = data[0] | ( this.padding_0 << 14 ) ;
			data[1] = data[1] | ( this.padding_10 << 0 ) ;
			data[2] = data[2] | ( this.padding_20 << 0 ) ;
			data[3] = data[3] | ( this.padding_30 << 0 ) ;
			data[4] = data[4] | ( this.voice_num << 0 ) ;
			data[4] = data[4] | ( this.padding_40 << 16 ) ;
			data[5] = data[5] | ( this.padding_50 << 0 ) ;
			data[6] = data[6] | ( this.padding_60 << 0 ) ;
			data[7] = data[7] | ( this.padding_70 << 0 ) ;
			data[8] = data[8] | ( this.padding_80 << 0 ) ;
			data[9] = data[9] | ( this.padding_90 << 0 ) ;
			data[10] = data[10] | ( this.padding_100 << 0 ) ;
			data[11] = data[11] | ( this.padding_110 << 0 ) ;
			data[12] = data[12] | ( this.padding_120 << 0 ) ;
			data[13] = data[13] | ( this.padding_130 << 0 ) ;
			data[14] = data[14] | ( this.padding_140 << 0 ) ;
			data[15] = data[15] | ( this.padding_150 << 0 ) ;
			data[16] = data[16] | ( this.padding_160 << 0 ) ;
			data[17] = data[17] | ( this.padding_170 << 0 ) ;
			data[18] = data[18] | ( this.padding_180 << 0 ) ;
			data[19] = data[19] | ( this.padding_190 << 0 ) ;
			data[20] = data[20] | ( this.padding_200 << 0 ) ;
			data[21] = data[21] | ( this.padding_210 << 0 ) ;
			data[22] = data[22] | ( this.padding_220 << 0 ) ;
			data[23] = data[23] | ( this.padding_230 << 0 ) ;
			data[24] = data[24] | ( this.padding_240 << 0 ) ;
			data[25] = data[25] | ( this.padding_250 << 0 ) ;
			data[26] = data[26] | ( this.padding_260 << 0 ) ;
			data[27] = data[27] | ( this.padding_270 << 0 ) ;
			data[28] = data[28] | ( this.padding_280 << 0 ) ;
			data[29] = data[29] | ( this.padding_290 << 0 ) ;
			data[30] = data[30] | ( this.padding_300 << 0 ) ;
			data[31] = data[31] | ( this.padding_310 << 0 ) ;
			data[32] = data[32] | ( this.padding_320 << 0 ) ;
			data[33] = data[33] | ( this.race_num_2 << 0 ) ;
			data[33] = data[33] | ( this.race_num_3 << 16 ) ;
			data[34] = data[34] | ( this.race_num_4 << 0 ) ;
			data[34] = data[34] | ( this.race_num_5 << 16 ) ;
			data[35] = data[35] | ( this.race_num_6 << 0 ) ;
			data[35] = data[35] | ( this.race_num_7 << 16 ) ;
			data[36] = data[36] | ( this.race_num_8 << 0 ) ;
			data[36] = data[36] | ( this.race_num_9 << 16 ) ;
			data[37] = data[37] | ( this.race_num_10 << 0 ) ;
			data[37] = data[37] | ( this.jockey_1 << 16 ) ;
			data[38] = data[38] | ( this.jockey_2 << 0 ) ;
			data[38] = data[38] | ( this.jockey_3 << 16 ) ;
			data[39] = data[39] | ( this.jockey_4 << 0 ) ;
			data[39] = data[39] | ( this.jockey_5 << 16 ) ;
			data[40] = data[40] | ( this.jockey_6 << 0 ) ;
			data[40] = data[40] | ( this.jockey_7 << 16 ) ;
			data[41] = data[41] | ( this.jockey_8 << 0 ) ;
			data[41] = data[41] | ( this.jockey_9 << 16 ) ;
			data[42] = data[42] | ( this.jockey_10 << 0 ) ;
			data[42] = data[42] | ( this.padding_420 << 16 ) ;
			data[43] = data[43] | ( this.training_yellow << 0 ) ;
			data[43] = data[43] | ( this.training_green << 7 ) ;
			data[43] = data[43] | ( this.seichou_speed << 14 ) ;
			data[43] = data[43] | ( this.seichou_konzyou << 21 ) ;
			data[43] = data[43] | ( this.seichou_syunpatsu << 26 ) ;
			data[43] = data[43] | ( this.memo_open_1 << 31 ) ;
			data[44] = data[44] | ( this.seichou_power << 0 ) ;
			data[44] = data[44] | ( this.seichou_zyuunan << 5 ) ;
			data[44] = data[44] | ( this.seichou_seishin << 10 ) ;
			data[44] = data[44] | ( this.seichou_kashikosa << 15 ) ;
			data[44] = data[44] | ( this.seichou_health << 20 ) ;
			data[44] = data[44] | ( this.memo_open_2 << 25 ) ;
			data[44] = data[44] | ( this.memo_open_3 << 26 ) ;
			data[44] = data[44] | ( this.memo_open_4 << 27 ) ;
			data[44] = data[44] | ( this.padding_440 << 28 ) ;
			data[44] = data[44] | ( this.mark << 29 ) ;
			data[44] = data[44] | ( this.padding_441 << 31 ) ;
			data[45] = data[45] | ( this.memo_open_5 << 0 ) ;
			data[45] = data[45] | ( this.memo_open_6 << 1 ) ;
			data[45] = data[45] | ( this.memo_open_7 << 2 ) ;
			data[45] = data[45] | ( this.memo_open_8 << 3 ) ;
			data[45] = data[45] | ( this.memo_open_9 << 4 ) ;
			data[45] = data[45] | ( this.memo_open_10 << 5 ) ;
			data[45] = data[45] | ( this.memo_open_11 << 6 ) ;
			data[45] = data[45] | ( this.memo_open_12 << 7 ) ;
			data[45] = data[45] | ( this.memo_open_13 << 8 ) ;
			data[45] = data[45] | ( this.memo_open_14 << 9 ) ;
			data[45] = data[45] | ( this.memo_open_15 << 10 ) ;
			data[45] = data[45] | ( this.memo_open_16 << 11 ) ;
			data[45] = data[45] | ( this.memo_open_17 << 12 ) ;
			data[45] = data[45] | ( this.memo_open_18 << 13 ) ;
			data[45] = data[45] | ( this.memo_open_19 << 14 ) ;
			data[45] = data[45] | ( this.memo_open_20 << 15 ) ;
			data[45] = data[45] | ( this.memo_open_21 << 16 ) ;
			data[45] = data[45] | ( this.memo_open_22 << 17 ) ;
			data[45] = data[45] | ( this.memo_open_23 << 18 ) ;
			data[45] = data[45] | ( this.memo_open_24 << 19 ) ;
			data[45] = data[45] | ( this.memo_open_25 << 20 ) ;
			data[45] = data[45] | ( this.memo_open_26 << 21 ) ;
			data[45] = data[45] | ( this.memo_open_27 << 22 ) ;
			data[45] = data[45] | ( this.memo_open_28 << 23 ) ;
			data[45] = data[45] | ( this.padding_450 << 24 ) ;
			data[45] = data[45] | ( this.memo_open_29 << 28 ) ;
			data[45] = data[45] | ( this.padding_451 << 29 ) ;
			data[46] = data[46] | ( this.padding_460 << 0 ) ;
			data[47] = data[47] | ( this.padding_470 << 0 ) ;
			data[48] = data[48] | ( this.padding_480 << 0 ) ;
			data[49] = data[49] | ( this.padding_490 << 0 ) ;
			data[50] = data[50] | ( this.padding_500 << 0 ) ;
			data[51] = data[51] | ( this.padding_510 << 0 ) ;
			data[52] = data[52] | ( this.padding_520 << 0 ) ;
			data[53] = data[53] | ( this.padding_530 << 0 ) ;
			data[54] = data[54] | ( this.padding_540 << 0 ) ;
			data[55] = data[55] | ( this.padding_550 << 0 ) ;
			data[56] = data[56] | ( this.padding_560 << 0 ) ;
			data[57] = data[57] | ( this.padding_570 << 0 ) ;
			data[58] = data[58] | ( this.padding_580 << 0 ) ;
			data[59] = data[59] | ( this.padding_590 << 0 ) ;
			data[60] = data[60] | ( this.padding_600 << 0 ) ;
			data[61] = data[61] | ( this.padding_610 << 0 ) ;
			data[62] = data[62] | ( this.padding_620 << 0 ) ;
			data[63] = data[63] | ( this.padding_630 << 0 ) ;
			data[64] = data[64] | ( this.padding_640 << 0 ) ;
			data[65] = data[65] | ( this.padding_650 << 0 ) ;
			data[66] = data[66] | ( this.padding_660 << 0 ) ;
			data[67] = data[67] | ( this.padding_670 << 0 ) ;
			data[68] = data[68] | ( this.padding_680 << 0 ) ;
			data[69] = data[69] | ( this.padding_690 << 0 ) ;
			data[70] = data[70] | ( this.padding_700 << 0 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HOwnershipRaceData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 71 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 71)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
			this.__bitfield5 = data[5];
			this.__bitfield6 = data[6];
			this.__bitfield7 = data[7];
			this.__bitfield8 = data[8];
			this.__bitfield9 = data[9];
			this.__bitfield10 = data[10];
			this.__bitfield11 = data[11];
			this.__bitfield12 = data[12];
			this.__bitfield13 = data[13];
			this.__bitfield14 = data[14];
			this.__bitfield15 = data[15];
			this.__bitfield16 = data[16];
			this.__bitfield17 = data[17];
			this.__bitfield18 = data[18];
			this.__bitfield19 = data[19];
			this.__bitfield20 = data[20];
			this.__bitfield21 = data[21];
			this.__bitfield22 = data[22];
			this.__bitfield23 = data[23];
			this.__bitfield24 = data[24];
			this.__bitfield25 = data[25];
			this.__bitfield26 = data[26];
			this.__bitfield27 = data[27];
			this.__bitfield28 = data[28];
			this.__bitfield29 = data[29];
			this.__bitfield30 = data[30];
			this.__bitfield31 = data[31];
			this.__bitfield32 = data[32];
			this.__bitfield33 = data[33];
			this.__bitfield34 = data[34];
			this.__bitfield35 = data[35];
			this.__bitfield36 = data[36];
			this.__bitfield37 = data[37];
			this.__bitfield38 = data[38];
			this.__bitfield39 = data[39];
			this.__bitfield40 = data[40];
			this.__bitfield41 = data[41];
			this.__bitfield42 = data[42];
			this.__bitfield43 = data[43];
			this.__bitfield44 = data[44];
			this.__bitfield45 = data[45];
			this.__bitfield46 = data[46];
			this.__bitfield47 = data[47];
			this.__bitfield48 = data[48];
			this.__bitfield49 = data[49];
			this.__bitfield50 = data[50];
			this.__bitfield51 = data[51];
			this.__bitfield52 = data[52];
			this.__bitfield53 = data[53];
			this.__bitfield54 = data[54];
			this.__bitfield55 = data[55];
			this.__bitfield56 = data[56];
			this.__bitfield57 = data[57];
			this.__bitfield58 = data[58];
			this.__bitfield59 = data[59];
			this.__bitfield60 = data[60];
			this.__bitfield61 = data[61];
			this.__bitfield62 = data[62];
			this.__bitfield63 = data[63];
			this.__bitfield64 = data[64];
			this.__bitfield65 = data[65];
			this.__bitfield66 = data[66];
			this.__bitfield67 = data[67];
			this.__bitfield68 = data[68];
			this.__bitfield69 = data[69];
			this.__bitfield70 = data[70];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 71;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HOwnershipChildData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// horse_numの最大値
		/// </summary>
		public const UInt32 horse_num_MAXVALUE = 0x00003fff; // 16383
		/// <summary>
		/// 馬番号
		/// </summary>
		public UInt32 horse_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > horse_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// padding_0の最大値
		/// </summary>
		public const UInt32 padding_0_MAXVALUE = 0x0003ffff; // 262143
		/// <summary>
		/// padding_0
		/// </summary>
		public UInt32 padding_0 {
			get { return ( this.__bitfield0 >> 14 ) & 0x0003ffff;  }
			set {
				if( value > padding_0_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-262143)");
				this.__bitfield0 = ( this.__bitfield0 & 0x00003fff ) | ( value << 14 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// training_yellowの最大値
		/// </summary>
		public const UInt32 training_yellow_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 育成度(黄)
		/// </summary>
		public UInt32 training_yellow {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000007f;  }
			set {
				if( value > training_yellow_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffff80 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// training_greenの最大値
		/// </summary>
		public const UInt32 training_green_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 育成度(緑)
		/// </summary>
		public UInt32 training_green {
			get { return ( this.__bitfield1 >> 7 ) & 0x0000007f;  }
			set {
				if( value > training_green_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffc07f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// seichou_speedの最大値
		/// </summary>
		public const UInt32 seichou_speed_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 成長(SP)
		/// </summary>
		public UInt32 seichou_speed {
			get { return ( this.__bitfield1 >> 14 ) & 0x0000007f;  }
			set {
				if( value > seichou_speed_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffe03fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// seichou_konzyouの最大値
		/// </summary>
		public const UInt32 seichou_konzyou_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(根性)
		/// </summary>
		public UInt32 seichou_konzyou {
			get { return ( this.__bitfield1 >> 21 ) & 0x0000001f;  }
			set {
				if( value > seichou_konzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfc1fffff ) | ( value << 21 );
			}
		}
		/// <summary>
		/// seichou_syunpatsuの最大値
		/// </summary>
		public const UInt32 seichou_syunpatsu_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(瞬発力)
		/// </summary>
		public UInt32 seichou_syunpatsu {
			get { return ( this.__bitfield1 >> 26 ) & 0x0000001f;  }
			set {
				if( value > seichou_syunpatsu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0x83ffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// memo_open_1の最大値
		/// </summary>
		public const UInt32 memo_open_1_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ成長型表示
		/// </summary>
		public UInt32 memo_open_1 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > memo_open_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// seichou_powerの最大値
		/// </summary>
		public const UInt32 seichou_power_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(瞬発力)
		/// </summary>
		public UInt32 seichou_power {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000001f;  }
			set {
				if( value > seichou_power_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffffe0 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// seichou_zyuunanの最大値
		/// </summary>
		public const UInt32 seichou_zyuunan_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(柔軟性)
		/// </summary>
		public UInt32 seichou_zyuunan {
			get { return ( this.__bitfield2 >> 5 ) & 0x0000001f;  }
			set {
				if( value > seichou_zyuunan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffc1f ) | ( value << 5 );
			}
		}
		/// <summary>
		/// seichou_seishinの最大値
		/// </summary>
		public const UInt32 seichou_seishin_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(精神力)
		/// </summary>
		public UInt32 seichou_seishin {
			get { return ( this.__bitfield2 >> 10 ) & 0x0000001f;  }
			set {
				if( value > seichou_seishin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff83ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// seichou_kashikosaの最大値
		/// </summary>
		public const UInt32 seichou_kashikosa_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(賢さ)
		/// </summary>
		public UInt32 seichou_kashikosa {
			get { return ( this.__bitfield2 >> 15 ) & 0x0000001f;  }
			set {
				if( value > seichou_kashikosa_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfff07fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// seichou_healthの最大値
		/// </summary>
		public const UInt32 seichou_health_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 成長(健康)
		/// </summary>
		public UInt32 seichou_health {
			get { return ( this.__bitfield2 >> 20 ) & 0x0000001f;  }
			set {
				if( value > seichou_health_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfe0fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// memo_open_2の最大値
		/// </summary>
		public const UInt32 memo_open_2_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ気性表示
		/// </summary>
		public UInt32 memo_open_2 {
			get { return ( this.__bitfield2 >> 25 ) & 0x00000001;  }
			set {
				if( value > memo_open_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfdffffff ) | ( value << 25 );
			}
		}
		/// <summary>
		/// memo_open_3の最大値
		/// </summary>
		public const UInt32 memo_open_3_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ馬場適正表示
		/// </summary>
		public UInt32 memo_open_3 {
			get { return ( this.__bitfield2 >> 26 ) & 0x00000001;  }
			set {
				if( value > memo_open_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfbffffff ) | ( value << 26 );
			}
		}
		/// <summary>
		/// memo_open_4の最大値
		/// </summary>
		public const UInt32 memo_open_4_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ重馬場適正表示
		/// </summary>
		public UInt32 memo_open_4 {
			get { return ( this.__bitfield2 >> 27 ) & 0x00000001;  }
			set {
				if( value > memo_open_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xf7ffffff ) | ( value << 27 );
			}
		}
		/// <summary>
		/// padding_20の最大値
		/// </summary>
		public const UInt32 padding_20_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_20
		/// </summary>
		public UInt32 padding_20 {
			get { return ( this.__bitfield2 >> 28 ) & 0x00000001;  }
			set {
				if( value > padding_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// markの最大値
		/// </summary>
		public const UInt32 mark_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// マーク表示 0無印 1春雷 2流星 3暁
		/// </summary>
		public UInt32 mark {
			get { return ( this.__bitfield2 >> 29 ) & 0x00000003;  }
			set {
				if( value > mark_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x9fffffff ) | ( value << 29 );
			}
		}
		/// <summary>
		/// padding_21の最大値
		/// </summary>
		public const UInt32 padding_21_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// padding_21
		/// </summary>
		public UInt32 padding_21 {
			get { return ( this.__bitfield2 >> 31 ) & 0x00000001;  }
			set {
				if( value > padding_21_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		/// <summary>
		/// memo_open_5の最大値
		/// </summary>
		public const UInt32 memo_open_5_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(小回り)
		/// </summary>
		public UInt32 memo_open_5 {
			get { return ( this.__bitfield3 >> 0 ) & 0x00000001;  }
			set {
				if( value > memo_open_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffffe ) | ( value << 0 );
			}
		}
		/// <summary>
		/// memo_open_6の最大値
		/// </summary>
		public const UInt32 memo_open_6_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(右)
		/// </summary>
		public UInt32 memo_open_6 {
			get { return ( this.__bitfield3 >> 1 ) & 0x00000001;  }
			set {
				if( value > memo_open_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffffd ) | ( value << 1 );
			}
		}
		/// <summary>
		/// memo_open_7の最大値
		/// </summary>
		public const UInt32 memo_open_7_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ回り表示(左)
		/// </summary>
		public UInt32 memo_open_7 {
			get { return ( this.__bitfield3 >> 2 ) & 0x00000001;  }
			set {
				if( value > memo_open_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffffb ) | ( value << 2 );
			}
		}
		/// <summary>
		/// memo_open_8の最大値
		/// </summary>
		public const UInt32 memo_open_8_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ走法表示
		/// </summary>
		public UInt32 memo_open_8 {
			get { return ( this.__bitfield3 >> 3 ) & 0x00000001;  }
			set {
				if( value > memo_open_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffff7 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// memo_open_9の最大値
		/// </summary>
		public const UInt32 memo_open_9_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(喉なり)
		/// </summary>
		public UInt32 memo_open_9 {
			get { return ( this.__bitfield3 >> 4 ) & 0x00000001;  }
			set {
				if( value > memo_open_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffffef ) | ( value << 4 );
			}
		}
		/// <summary>
		/// memo_open_10の最大値
		/// </summary>
		public const UInt32 memo_open_10_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(脚部不安)
		/// </summary>
		public UInt32 memo_open_10 {
			get { return ( this.__bitfield3 >> 5 ) & 0x00000001;  }
			set {
				if( value > memo_open_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffffdf ) | ( value << 5 );
			}
		}
		/// <summary>
		/// memo_open_11の最大値
		/// </summary>
		public const UInt32 memo_open_11_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ持病表示(腰甘)
		/// </summary>
		public UInt32 memo_open_11 {
			get { return ( this.__bitfield3 >> 6 ) & 0x00000001;  }
			set {
				if( value > memo_open_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffffbf ) | ( value << 6 );
			}
		}
		/// <summary>
		/// memo_open_12の最大値
		/// </summary>
		public const UInt32 memo_open_12_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモSP表示
		/// </summary>
		public UInt32 memo_open_12 {
			get { return ( this.__bitfield3 >> 7 ) & 0x00000001;  }
			set {
				if( value > memo_open_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffff7f ) | ( value << 7 );
			}
		}
		/// <summary>
		/// memo_open_13の最大値
		/// </summary>
		public const UInt32 memo_open_13_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ勝負根性表示
		/// </summary>
		public UInt32 memo_open_13 {
			get { return ( this.__bitfield3 >> 8 ) & 0x00000001;  }
			set {
				if( value > memo_open_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffeff ) | ( value << 8 );
			}
		}
		/// <summary>
		/// memo_open_14の最大値
		/// </summary>
		public const UInt32 memo_open_14_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ瞬発力表示
		/// </summary>
		public UInt32 memo_open_14 {
			get { return ( this.__bitfield3 >> 9 ) & 0x00000001;  }
			set {
				if( value > memo_open_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffdff ) | ( value << 9 );
			}
		}
		/// <summary>
		/// memo_open_15の最大値
		/// </summary>
		public const UInt32 memo_open_15_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモパワー表示
		/// </summary>
		public UInt32 memo_open_15 {
			get { return ( this.__bitfield3 >> 10 ) & 0x00000001;  }
			set {
				if( value > memo_open_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffffbff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// memo_open_16の最大値
		/// </summary>
		public const UInt32 memo_open_16_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ柔軟性表示
		/// </summary>
		public UInt32 memo_open_16 {
			get { return ( this.__bitfield3 >> 11 ) & 0x00000001;  }
			set {
				if( value > memo_open_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffff7ff ) | ( value << 11 );
			}
		}
		/// <summary>
		/// memo_open_17の最大値
		/// </summary>
		public const UInt32 memo_open_17_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ精神力表示
		/// </summary>
		public UInt32 memo_open_17 {
			get { return ( this.__bitfield3 >> 12 ) & 0x00000001;  }
			set {
				if( value > memo_open_17_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffefff ) | ( value << 12 );
			}
		}
		/// <summary>
		/// memo_open_18の最大値
		/// </summary>
		public const UInt32 memo_open_18_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ賢さ表示
		/// </summary>
		public UInt32 memo_open_18 {
			get { return ( this.__bitfield3 >> 13 ) & 0x00000001;  }
			set {
				if( value > memo_open_18_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffdfff ) | ( value << 13 );
			}
		}
		/// <summary>
		/// memo_open_19の最大値
		/// </summary>
		public const UInt32 memo_open_19_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ健康表示
		/// </summary>
		public UInt32 memo_open_19 {
			get { return ( this.__bitfield3 >> 14 ) & 0x00000001;  }
			set {
				if( value > memo_open_19_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffbfff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// memo_open_20の最大値
		/// </summary>
		public const UInt32 memo_open_20_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ適正距離表示
		/// </summary>
		public UInt32 memo_open_20 {
			get { return ( this.__bitfield3 >> 15 ) & 0x00000001;  }
			set {
				if( value > memo_open_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffff7fff ) | ( value << 15 );
			}
		}
		/// <summary>
		/// padding_30の最大値
		/// </summary>
		public const UInt32 padding_30_MAXVALUE = 0x00000fff; // 4095
		/// <summary>
		/// padding_30
		/// </summary>
		public UInt32 padding_30 {
			get { return ( this.__bitfield3 >> 16 ) & 0x00000fff;  }
			set {
				if( value > padding_30_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield3 = ( this.__bitfield3 & 0xf000ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// memo_open_29の最大値
		/// </summary>
		public const UInt32 memo_open_29_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// メモ脚質表示
		/// </summary>
		public UInt32 memo_open_29 {
			get { return ( this.__bitfield3 >> 28 ) & 0x00000001;  }
			set {
				if( value > memo_open_29_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield3 = ( this.__bitfield3 & 0xefffffff ) | ( value << 28 );
			}
		}
		/// <summary>
		/// padding_31の最大値
		/// </summary>
		public const UInt32 padding_31_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// padding_31
		/// </summary>
		public UInt32 padding_31 {
			get { return ( this.__bitfield3 >> 29 ) & 0x00000007;  }
			set {
				if( value > padding_31_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield3 = ( this.__bitfield3 & 0x1fffffff ) | ( value << 29 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		/// <summary>
		/// padding_40の最大値
		/// </summary>
		public const UInt32 padding_40_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_40
		/// </summary>
		public UInt32 padding_40 {
			get { return ( this.__bitfield4 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_40_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield4 = ( this.__bitfield4 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		/// <summary>
		/// padding_50の最大値
		/// </summary>
		public const UInt32 padding_50_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_50
		/// </summary>
		public UInt32 padding_50 {
			get { return ( this.__bitfield5 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_50_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield5 = ( this.__bitfield5 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		/// <summary>
		/// padding_60の最大値
		/// </summary>
		public const UInt32 padding_60_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_60
		/// </summary>
		public UInt32 padding_60 {
			get { return ( this.__bitfield6 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_60_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield6 = ( this.__bitfield6 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		/// <summary>
		/// padding_70の最大値
		/// </summary>
		public const UInt32 padding_70_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_70
		/// </summary>
		public UInt32 padding_70 {
			get { return ( this.__bitfield7 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_70_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield7 = ( this.__bitfield7 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		/// <summary>
		/// padding_80の最大値
		/// </summary>
		public const UInt32 padding_80_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_80
		/// </summary>
		public UInt32 padding_80 {
			get { return ( this.__bitfield8 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_80_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield8 = ( this.__bitfield8 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		/// <summary>
		/// padding_90の最大値
		/// </summary>
		public const UInt32 padding_90_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_90
		/// </summary>
		public UInt32 padding_90 {
			get { return ( this.__bitfield9 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_90_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		/// <summary>
		/// padding_100の最大値
		/// </summary>
		public const UInt32 padding_100_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_100
		/// </summary>
		public UInt32 padding_100 {
			get { return ( this.__bitfield10 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_100_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield10 = ( this.__bitfield10 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 44 byte data
		[FieldOffset(44)] private UInt32 __bitfield11;
		/// <summary>
		/// padding_110の最大値
		/// </summary>
		public const UInt32 padding_110_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_110
		/// </summary>
		public UInt32 padding_110 {
			get { return ( this.__bitfield11 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_110_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield11 = ( this.__bitfield11 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 48 byte data
		[FieldOffset(48)] private UInt32 __bitfield12;
		/// <summary>
		/// padding_120の最大値
		/// </summary>
		public const UInt32 padding_120_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_120
		/// </summary>
		public UInt32 padding_120 {
			get { return ( this.__bitfield12 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_120_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield12 = ( this.__bitfield12 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 52 byte data
		[FieldOffset(52)] private UInt32 __bitfield13;
		/// <summary>
		/// padding_130の最大値
		/// </summary>
		public const UInt32 padding_130_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_130
		/// </summary>
		public UInt32 padding_130 {
			get { return ( this.__bitfield13 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_130_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield13 = ( this.__bitfield13 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 56 byte data
		[FieldOffset(56)] private UInt32 __bitfield14;
		/// <summary>
		/// padding_140の最大値
		/// </summary>
		public const UInt32 padding_140_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_140
		/// </summary>
		public UInt32 padding_140 {
			get { return ( this.__bitfield14 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_140_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield14 = ( this.__bitfield14 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 60 byte data
		[FieldOffset(60)] private UInt32 __bitfield15;
		/// <summary>
		/// padding_150の最大値
		/// </summary>
		public const UInt32 padding_150_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_150
		/// </summary>
		public UInt32 padding_150 {
			get { return ( this.__bitfield15 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_150_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield15 = ( this.__bitfield15 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 64 byte data
		[FieldOffset(64)] private UInt32 __bitfield16;
		/// <summary>
		/// padding_160の最大値
		/// </summary>
		public const UInt32 padding_160_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_160
		/// </summary>
		public UInt32 padding_160 {
			get { return ( this.__bitfield16 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_160_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield16 = ( this.__bitfield16 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 68 byte data
		[FieldOffset(68)] private UInt32 __bitfield17;
		/// <summary>
		/// padding_170の最大値
		/// </summary>
		public const UInt32 padding_170_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_170
		/// </summary>
		public UInt32 padding_170 {
			get { return ( this.__bitfield17 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_170_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield17 = ( this.__bitfield17 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 72 byte data
		[FieldOffset(72)] private UInt32 __bitfield18;
		/// <summary>
		/// padding_180の最大値
		/// </summary>
		public const UInt32 padding_180_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_180
		/// </summary>
		public UInt32 padding_180 {
			get { return ( this.__bitfield18 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_180_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield18 = ( this.__bitfield18 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 76 byte data
		[FieldOffset(76)] private UInt32 __bitfield19;
		/// <summary>
		/// padding_190の最大値
		/// </summary>
		public const UInt32 padding_190_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_190
		/// </summary>
		public UInt32 padding_190 {
			get { return ( this.__bitfield19 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_190_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield19 = ( this.__bitfield19 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 80 byte data
		[FieldOffset(80)] private UInt32 __bitfield20;
		/// <summary>
		/// padding_200の最大値
		/// </summary>
		public const UInt32 padding_200_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_200
		/// </summary>
		public UInt32 padding_200 {
			get { return ( this.__bitfield20 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_200_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield20 = ( this.__bitfield20 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 84 byte data
		[FieldOffset(84)] private UInt32 __bitfield21;
		/// <summary>
		/// padding_210の最大値
		/// </summary>
		public const UInt32 padding_210_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_210
		/// </summary>
		public UInt32 padding_210 {
			get { return ( this.__bitfield21 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_210_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield21 = ( this.__bitfield21 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 88 byte data
		[FieldOffset(88)] private UInt32 __bitfield22;
		/// <summary>
		/// padding_220の最大値
		/// </summary>
		public const UInt32 padding_220_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_220
		/// </summary>
		public UInt32 padding_220 {
			get { return ( this.__bitfield22 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_220_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield22 = ( this.__bitfield22 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 92 byte data
		[FieldOffset(92)] private UInt32 __bitfield23;
		/// <summary>
		/// padding_230の最大値
		/// </summary>
		public const UInt32 padding_230_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_230
		/// </summary>
		public UInt32 padding_230 {
			get { return ( this.__bitfield23 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_230_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield23 = ( this.__bitfield23 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 96 byte data
		[FieldOffset(96)] private UInt32 __bitfield24;
		/// <summary>
		/// padding_240の最大値
		/// </summary>
		public const UInt32 padding_240_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_240
		/// </summary>
		public UInt32 padding_240 {
			get { return ( this.__bitfield24 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_240_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield24 = ( this.__bitfield24 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 100 byte data
		[FieldOffset(100)] private UInt32 __bitfield25;
		/// <summary>
		/// padding_250の最大値
		/// </summary>
		public const UInt32 padding_250_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_250
		/// </summary>
		public UInt32 padding_250 {
			get { return ( this.__bitfield25 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_250_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield25 = ( this.__bitfield25 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 104 byte data
		[FieldOffset(104)] private UInt32 __bitfield26;
		/// <summary>
		/// padding_260の最大値
		/// </summary>
		public const UInt32 padding_260_MAXVALUE = 0xffffffff; // 4294967295
		/// <summary>
		/// padding_260
		/// </summary>
		public UInt32 padding_260 {
			get { return ( this.__bitfield26 >> 0 ) & 0xffffffff;  }
			set {
				if( value > padding_260_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield26 = ( this.__bitfield26 & 0x00000000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("horse_num"), 14, 16383, "馬番号", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_0"), 18, 262143, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("training_yellow"), 7, 127, "育成度(黄)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("training_green"), 7, 127, "育成度(緑)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_speed"), 7, 127, "成長(SP)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_konzyou"), 5, 31, "成長(根性)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_syunpatsu"), 5, 31, "成長(瞬発力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_1"), 1, 1, "メモ成長型表示", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_power"), 5, 31, "成長(瞬発力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_zyuunan"), 5, 31, "成長(柔軟性)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_seishin"), 5, 31, "成長(精神力)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_kashikosa"), 5, 31, "成長(賢さ)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("seichou_health"), 5, 31, "成長(健康)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_2"), 1, 1, "メモ気性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_3"), 1, 1, "メモ馬場適正表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_4"), 1, 1, "メモ重馬場適正表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_20"), 1, 1, "", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("mark"), 2, 3, "マーク表示 0無印 1春雷 2流星 3暁", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_21"), 1, 1, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_5"), 1, 1, "メモ回り表示(小回り)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_6"), 1, 1, "メモ回り表示(右)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_7"), 1, 1, "メモ回り表示(左)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_8"), 1, 1, "メモ走法表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_9"), 1, 1, "メモ持病表示(喉なり)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_10"), 1, 1, "メモ持病表示(脚部不安)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_11"), 1, 1, "メモ持病表示(腰甘)", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_12"), 1, 1, "メモSP表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_13"), 1, 1, "メモ勝負根性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_14"), 1, 1, "メモ瞬発力表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_15"), 1, 1, "メモパワー表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_16"), 1, 1, "メモ柔軟性表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_17"), 1, 1, "メモ精神力表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_18"), 1, 1, "メモ賢さ表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_19"), 1, 1, "メモ健康表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_20"), 1, 1, "メモ適正距離表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_30"), 12, 4095, "", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("memo_open_29"), 1, 1, "メモ脚質表示", "" ),
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_31"), 3, 7, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_40"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_50"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_60"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_70"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_80"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_90"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_100"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_110"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_120"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_130"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_140"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_150"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_160"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_170"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_180"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_190"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_200"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_210"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_220"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_230"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_240"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_250"), 32, 4294967295, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(HOwnershipChildData).GetProperty("padding_260"), 32, 4294967295, "", "" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[27];
			data[0] = data[0] | ( this.horse_num << 0 ) ;
			data[0] = data[0] | ( this.padding_0 << 14 ) ;
			data[1] = data[1] | ( this.training_yellow << 0 ) ;
			data[1] = data[1] | ( this.training_green << 7 ) ;
			data[1] = data[1] | ( this.seichou_speed << 14 ) ;
			data[1] = data[1] | ( this.seichou_konzyou << 21 ) ;
			data[1] = data[1] | ( this.seichou_syunpatsu << 26 ) ;
			data[1] = data[1] | ( this.memo_open_1 << 31 ) ;
			data[2] = data[2] | ( this.seichou_power << 0 ) ;
			data[2] = data[2] | ( this.seichou_zyuunan << 5 ) ;
			data[2] = data[2] | ( this.seichou_seishin << 10 ) ;
			data[2] = data[2] | ( this.seichou_kashikosa << 15 ) ;
			data[2] = data[2] | ( this.seichou_health << 20 ) ;
			data[2] = data[2] | ( this.memo_open_2 << 25 ) ;
			data[2] = data[2] | ( this.memo_open_3 << 26 ) ;
			data[2] = data[2] | ( this.memo_open_4 << 27 ) ;
			data[2] = data[2] | ( this.padding_20 << 28 ) ;
			data[2] = data[2] | ( this.mark << 29 ) ;
			data[2] = data[2] | ( this.padding_21 << 31 ) ;
			data[3] = data[3] | ( this.memo_open_5 << 0 ) ;
			data[3] = data[3] | ( this.memo_open_6 << 1 ) ;
			data[3] = data[3] | ( this.memo_open_7 << 2 ) ;
			data[3] = data[3] | ( this.memo_open_8 << 3 ) ;
			data[3] = data[3] | ( this.memo_open_9 << 4 ) ;
			data[3] = data[3] | ( this.memo_open_10 << 5 ) ;
			data[3] = data[3] | ( this.memo_open_11 << 6 ) ;
			data[3] = data[3] | ( this.memo_open_12 << 7 ) ;
			data[3] = data[3] | ( this.memo_open_13 << 8 ) ;
			data[3] = data[3] | ( this.memo_open_14 << 9 ) ;
			data[3] = data[3] | ( this.memo_open_15 << 10 ) ;
			data[3] = data[3] | ( this.memo_open_16 << 11 ) ;
			data[3] = data[3] | ( this.memo_open_17 << 12 ) ;
			data[3] = data[3] | ( this.memo_open_18 << 13 ) ;
			data[3] = data[3] | ( this.memo_open_19 << 14 ) ;
			data[3] = data[3] | ( this.memo_open_20 << 15 ) ;
			data[3] = data[3] | ( this.padding_30 << 16 ) ;
			data[3] = data[3] | ( this.memo_open_29 << 28 ) ;
			data[3] = data[3] | ( this.padding_31 << 29 ) ;
			data[4] = data[4] | ( this.padding_40 << 0 ) ;
			data[5] = data[5] | ( this.padding_50 << 0 ) ;
			data[6] = data[6] | ( this.padding_60 << 0 ) ;
			data[7] = data[7] | ( this.padding_70 << 0 ) ;
			data[8] = data[8] | ( this.padding_80 << 0 ) ;
			data[9] = data[9] | ( this.padding_90 << 0 ) ;
			data[10] = data[10] | ( this.padding_100 << 0 ) ;
			data[11] = data[11] | ( this.padding_110 << 0 ) ;
			data[12] = data[12] | ( this.padding_120 << 0 ) ;
			data[13] = data[13] | ( this.padding_130 << 0 ) ;
			data[14] = data[14] | ( this.padding_140 << 0 ) ;
			data[15] = data[15] | ( this.padding_150 << 0 ) ;
			data[16] = data[16] | ( this.padding_160 << 0 ) ;
			data[17] = data[17] | ( this.padding_170 << 0 ) ;
			data[18] = data[18] | ( this.padding_180 << 0 ) ;
			data[19] = data[19] | ( this.padding_190 << 0 ) ;
			data[20] = data[20] | ( this.padding_200 << 0 ) ;
			data[21] = data[21] | ( this.padding_210 << 0 ) ;
			data[22] = data[22] | ( this.padding_220 << 0 ) ;
			data[23] = data[23] | ( this.padding_230 << 0 ) ;
			data[24] = data[24] | ( this.padding_240 << 0 ) ;
			data[25] = data[25] | ( this.padding_250 << 0 ) ;
			data[26] = data[26] | ( this.padding_260 << 0 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HOwnershipChildData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 27 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 27)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
			this.__bitfield5 = data[5];
			this.__bitfield6 = data[6];
			this.__bitfield7 = data[7];
			this.__bitfield8 = data[8];
			this.__bitfield9 = data[9];
			this.__bitfield10 = data[10];
			this.__bitfield11 = data[11];
			this.__bitfield12 = data[12];
			this.__bitfield13 = data[13];
			this.__bitfield14 = data[14];
			this.__bitfield15 = data[15];
			this.__bitfield16 = data[16];
			this.__bitfield17 = data[17];
			this.__bitfield18 = data[18];
			this.__bitfield19 = data[19];
			this.__bitfield20 = data[20];
			this.__bitfield21 = data[21];
			this.__bitfield22 = data[22];
			this.__bitfield23 = data[23];
			this.__bitfield24 = data[24];
			this.__bitfield25 = data[25];
			this.__bitfield26 = data[26];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 27;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct RRaceData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		/// <summary>
		/// race_name_numの最大値
		/// </summary>
		public const UInt32 race_name_num_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// レース名番号
		/// </summary>
		public UInt32 race_name_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > race_name_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffff0000 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// race_kakuの最大値
		/// </summary>
		public const UInt32 race_kaku_MAXVALUE = 0x0000ffff; // 65535
		/// <summary>
		/// レース格
		/// </summary>
		public UInt32 race_kaku {
			get { return ( this.__bitfield0 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > race_kaku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield0 = ( this.__bitfield0 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		/// <summary>
		/// type_ageの最大値
		/// </summary>
		public const UInt32 type_age_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 馬齢条件
		/// </summary>
		public UInt32 type_age {
			get { return ( this.__bitfield1 >> 0 ) & 0x00000007;  }
			set {
				if( value > type_age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffff8 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// type_genderの最大値
		/// </summary>
		public const UInt32 type_gender_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 性別条件
		/// </summary>
		public UInt32 type_gender {
			get { return ( this.__bitfield1 >> 3 ) & 0x00000007;  }
			set {
				if( value > type_gender_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffc7 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// type_kokusaiの最大値
		/// </summary>
		public const UInt32 type_kokusai_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 出走条件
		/// </summary>
		public UInt32 type_kokusai {
			get { return ( this.__bitfield1 >> 6 ) & 0x00000007;  }
			set {
				if( value > type_kokusai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffe3f ) | ( value << 6 );
			}
		}
		/// <summary>
		/// is_kongouの最大値
		/// </summary>
		public const UInt32 is_kongou_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// 混合？
		/// </summary>
		public UInt32 is_kongou {
			get { return ( this.__bitfield1 >> 9 ) & 0x00000001;  }
			set {
				if( value > is_kongou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffdff ) | ( value << 9 );
			}
		}
		/// <summary>
		/// is_dirtの最大値
		/// </summary>
		public const UInt32 is_dirt_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// ダート？
		/// </summary>
		public UInt32 is_dirt {
			get { return ( this.__bitfield1 >> 10 ) & 0x00000001;  }
			set {
				if( value > is_dirt_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffbff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// distanceの最大値
		/// </summary>
		public const UInt32 distance_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 距離
		/// </summary>
		public UInt32 distance {
			get { return ( this.__bitfield1 >> 11 ) & 0x0000001f;  }
			set {
				if( value > distance_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffff07ff ) | ( value << 11 );
			}
		}
		/// <summary>
		/// gradeの最大値
		/// </summary>
		public const UInt32 grade_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// グレード
		/// </summary>
		public UInt32 grade {
			get { return ( this.__bitfield1 >> 16 ) & 0x0000000f;  }
			set {
				if( value > grade_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfff0ffff ) | ( value << 16 );
			}
		}
		/// <summary>
		/// fullgateの最大値
		/// </summary>
		public const UInt32 fullgate_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// フルゲート
		/// </summary>
		public UInt32 fullgate {
			get { return ( this.__bitfield1 >> 20 ) & 0x00000007;  }
			set {
				if( value > fullgate_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff8fffff ) | ( value << 20 );
			}
		}
		/// <summary>
		/// is_jpnの最大値
		/// </summary>
		public const UInt32 is_jpn_MAXVALUE = 0x00000001; // 1
		/// <summary>
		/// JPN
		/// </summary>
		public UInt32 is_jpn {
			get { return ( this.__bitfield1 >> 23 ) & 0x00000001;  }
			set {
				if( value > is_jpn_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff7fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// padding_20の最大値
		/// </summary>
		public const UInt32 padding_20_MAXVALUE = 0x000000ff; // 255
		/// <summary>
		/// padding_20
		/// </summary>
		public UInt32 padding_20 {
			get { return ( this.__bitfield1 >> 24 ) & 0x000000ff;  }
			set {
				if( value > padding_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		/// <summary>
		/// ticketの最大値
		/// </summary>
		public const UInt32 ticket_MAXVALUE = 0x00000007; // 7
		/// <summary>
		/// 優先出走権
		/// </summary>
		public UInt32 ticket {
			get { return ( this.__bitfield2 >> 0 ) & 0x00000007;  }
			set {
				if( value > ticket_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffff8 ) | ( value << 0 );
			}
		}
		/// <summary>
		/// courseの最大値
		/// </summary>
		public const UInt32 course_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 競馬場
		/// </summary>
		public UInt32 course {
			get { return ( this.__bitfield2 >> 3 ) & 0x0000007f;  }
			set {
				if( value > course_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffc07 ) | ( value << 3 );
			}
		}
		/// <summary>
		/// weightの最大値
		/// </summary>
		public const UInt32 weight_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 基本斤量
		/// </summary>
		public UInt32 weight {
			get { return ( this.__bitfield2 >> 10 ) & 0x0000000f;  }
			set {
				if( value > weight_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffc3ff ) | ( value << 10 );
			}
		}
		/// <summary>
		/// unknown_1の最大値
		/// </summary>
		public const UInt32 unknown_1_MAXVALUE = 0x0000000f; // 15
		/// <summary>
		/// 表示方法？
		/// </summary>
		public UInt32 unknown_1 {
			get { return ( this.__bitfield2 >> 14 ) & 0x0000000f;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffc3fff ) | ( value << 14 );
			}
		}
		/// <summary>
		/// weight_extの最大値
		/// </summary>
		public const UInt32 weight_ext_MAXVALUE = 0x0000001f; // 31
		/// <summary>
		/// 負担重量条件
		/// </summary>
		public UInt32 weight_ext {
			get { return ( this.__bitfield2 >> 18 ) & 0x0000001f;  }
			set {
				if( value > weight_ext_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield2 = ( this.__bitfield2 & 0xff83ffff ) | ( value << 18 );
			}
		}
		/// <summary>
		/// padding_30の最大値
		/// </summary>
		public const UInt32 padding_30_MAXVALUE = 0x00000003; // 3
		/// <summary>
		/// padding_30
		/// </summary>
		public UInt32 padding_30 {
			get { return ( this.__bitfield2 >> 23 ) & 0x00000003;  }
			set {
				if( value > padding_30_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfe7fffff ) | ( value << 23 );
			}
		}
		/// <summary>
		/// syoukinの最大値
		/// </summary>
		public const UInt32 syoukin_MAXVALUE = 0x0000007f; // 127
		/// <summary>
		/// 賞金
		/// </summary>
		public UInt32 syoukin {
			get { return ( this.__bitfield2 >> 25 ) & 0x0000007f;  }
			set {
				if( value > syoukin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0x01ffffff ) | ( value << 25 );
			}
		}
		/// <summary>
		/// プロパティのリスト
		/// </summary>
		public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("race_name_num"), 16, 65535, "レース名番号", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("race_kaku"), 16, 65535, "レース格", "値が小さいほど格が高い" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("type_age"), 3, 7, "馬齢条件", "0=2歳 1=2歳以上 2=3歳 3=3歳以上 4=4歳以上" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("type_gender"), 3, 7, "性別条件", "0=限定無し 1=牡馬限定 2=牝馬限定 3=牡セン 4=牡牝" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("type_kokusai"), 3, 7, "出走条件", "1=国際 2=外国地方招待 3=指定 4=国際指定" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("is_kongou"), 1, 1, "混合？", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("is_dirt"), 1, 1, "ダート？", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("distance"), 5, 31, "距離", "0=1000m, 1=1100m, 2=1150m, 3=1200m, 4=1300m, 5=1400m, 6=1500m, 7=1600m, 8=1700m, 9=1777m, 10=1800m, 11=1850m, 12=1900m, 13=1950m, 14=2000m, 15=2100m, 16=2200m, 17=2300m, 18=2400m, 19=2500m, 20=2600m, 21=2800m, 22=3000m, 23=3100m, 24=3200m, 25=3300m, 26=3400m, 27=3600m, 28=4000m" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("grade"), 4, 15, "グレード", "0=新馬, 1=未勝利, 2=500万下, 3=500万下, 4=1000万下, 5=1000万下, 6=1600万下, 7=オープン, 8=G3, 9=G2, 10=G1" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("fullgate"), 3, 7, "フルゲート", "0=11頭, 1=12頭, 2=13頭, 3=14頭, 4=15頭, 5=16頭, 6=18頭" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("is_jpn"), 1, 1, "JPN", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("padding_20"), 8, 255, "", "" ),
			},
			new DataStructPropertyInfo[]{
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("ticket"), 3, 7, "優先出走権", "1=皐月賞, 2=ダービー, 3=菊花賞, 4=桜花賞, 5=オークス, 6=秋華賞, 7=NHKマイルカップ" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("course"), 7, 127, "競馬場", "0=京都, 1=小倉, 2=札幌, 3=中京, 4=東京, 5=中山, 6=新潟, 7=函館, 8=阪神, 9=福島, 10=アケダクト, 11=アーリントン, 12=ウッドバイン, 13=オークローン, 14=ガルフストリーム, 15=キーンランド, 16=サラトガ, 17=サンタアニタ, 18=ターフウェーパーク, 19=チャーチルダウンズ, 20=デルマー, 21=ハリウッドパーク, 22=ピムリコ, 23=ベルモントパーク, 24=モンマスパーク, 25=ルイジアナダウンズ, 26=ローレルパーク, 27=フェアグラウンズ, 28=シャティン, 29=カラー, 30=レパーズタウン, 31=アスコット, 32=エプソムダウンズ, 33=グッドウッド, 34=サンダウン, 35=ドンカスター, 36=ニューベリ, 37=ニューマーケット, 38=ヘイドックパーク, 39=ヨーク, 40=サンクルー, 41=シャンティイ, 42=ドーヴィル, 43=メゾンラフィット, 44=ロンシャン, 45=バーデンバーデン, 46=ミュールハイム, 47=ハンブルク, 48=クランジ, 49=ムーニーバレー, 50=フレミントン, 51=ナドアルシバ, 52=旭川, 53=浦和, 54=大井, 55=笠松, 56=金沢, 57=川崎, 58=高知, 59=佐賀, 60=高崎, 61=名古屋, 62=船橋, 63=盛岡, 64=門別, 65=園田, 66=上山, 67=宇都宮" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("weight"), 4, 15, "基本斤量", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("unknown_1"), 4, 15, "表示方法？", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("weight_ext"), 5, 31, "負担重量条件", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("padding_30"), 2, 3, "", "" ),
				new DataStructPropertyInfo( typeof(RRaceData).GetProperty("syoukin"), 7, 127, "賞金", "0=390万, 1=400万, 2=440万, 3=500万, 4=510万, 5=540万, 6=600万, 7=650万, 8=700万, 9=750万, 10=800万, 11=900万, 12=1000万, 13=1050万, 14=1150万, 15=1400万, 16=1450万, 17=1500万, 18=1600万, 19=1700万, 20=1800万, 21=1900万, 22=2000万, 23=2200万, 24=2400万, 25=2500万, 26=2700万, 27=3000万, 28=3200万, 29=3500万, 30=3800万, 31=3900万, 32=4000万, 33=4100万, 34=4200万, 35=4300万, 36=4500万, 37=4700万, 38=5000万, 39=5200万, 40=5400万, 41=5500万, 42=5800万, 43=6000万, 44=6400万, 45=6500万, 46=7000万, 47=7500万, 48=8000万, 49=8600万, 50=8900万, 51=9200万, 52=9400万, 53=9700万, 54=10000万, 55=10700万, 56=11200万, 57=12000万, 58=13000万, 59=13200万, 60=14000万, 61=15000万, 62=18000万, 63=25000万, 64=43000万" ),
			},
		};
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にデコードする
		/// </summary>
		public UInt32[] Decode() {
			var data = new UInt32[3];
			data[0] = data[0] | ( this.race_name_num << 0 ) ;
			data[0] = data[0] | ( this.race_kaku << 16 ) ;
			data[1] = data[1] | ( this.type_age << 0 ) ;
			data[1] = data[1] | ( this.type_gender << 3 ) ;
			data[1] = data[1] | ( this.type_kokusai << 6 ) ;
			data[1] = data[1] | ( this.is_kongou << 9 ) ;
			data[1] = data[1] | ( this.is_dirt << 10 ) ;
			data[1] = data[1] | ( this.distance << 11 ) ;
			data[1] = data[1] | ( this.grade << 16 ) ;
			data[1] = data[1] | ( this.fullgate << 20 ) ;
			data[1] = data[1] | ( this.is_jpn << 23 ) ;
			data[1] = data[1] | ( this.padding_20 << 24 ) ;
			data[2] = data[2] | ( this.ticket << 0 ) ;
			data[2] = data[2] | ( this.course << 3 ) ;
			data[2] = data[2] | ( this.weight << 10 ) ;
			data[2] = data[2] | ( this.unknown_1 << 14 ) ;
			data[2] = data[2] | ( this.weight_ext << 18 ) ;
			data[2] = data[2] | ( this.padding_30 << 23 ) ;
			data[2] = data[2] | ( this.syoukin << 25 ) ;
			return data;
		}
		/// <summary>
		/// 構造体をメモリに書き込むためのUInt32配列にする
		/// </summary>
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( RRaceData obj ){
			return obj.ToArray();
		}
		/// <summary>
		/// UInt32配列を構造体にエンコードする
		/// </summary>
		public void Encode( UInt32[] data ) {
			if( data.Length != 3 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 3)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
		}
		/// <summary>
		/// 構造体のサイズ
		/// </summary>
		public const UInt32 __SIZE__ = sizeof(UInt32) * 3;
	}

} // namespace KOEI.WP7_2012.Datastruct

