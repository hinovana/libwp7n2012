 namespace KOEI.WP7.M2008.Datastruct {
 	using System;
 	using System.Runtime.InteropServices;
	[StructLayout(LayoutKind.Explicit)]
	public struct HBloodData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 father_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 father_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00007fff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffff8000 ) | ( value << 0 );
			}
		}
		public const UInt32 mother_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 15 ) & 0x00007fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xc0007fff ) | ( value << 15 );
			}
		}
		public const UInt32 unknown_1_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_1 {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 display_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 unknown_2_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_2 {
			get { return ( this.__bitfield1 >> 0 ) & 0x00000001;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffffe ) | ( value << 0 );
			}
		}
		public const UInt32 family_line_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 family_line_num {
			get { return ( this.__bitfield1 >> 1 ) & 0x000000ff;  }
			set {
				if( value > family_line_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffe01 ) | ( value << 1 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x00007fff; // 32767
		public UInt32 unknown_3 {
			get { return ( this.__bitfield1 >> 9 ) & 0x00007fff;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff0001ff ) | ( value << 9 );
			}
		}
		public const UInt32 factor_left_MAXVALUE = 0x0000000f; // 15
		public UInt32 factor_left {
			get { return ( this.__bitfield1 >> 24 ) & 0x0000000f;  }
			set {
				if( value > factor_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf0ffffff ) | ( value << 24 );
			}
		}
		public const UInt32 factor_right_MAXVALUE = 0x0000000f; // 15
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
		public const UInt32 name_left_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 name_left {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > name_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff0000 ) | ( value << 0 );
			}
		}
		public const UInt32 name_right_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 name_right {
			get { return ( this.__bitfield2 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > name_right_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield2 = ( this.__bitfield2 & 0x0000ffff ) | ( value << 16 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[3];
			data[0] = data[0] | ( this.father_num << 0 ) ;
			data[0] = data[0] | ( this.mother_num << 15 ) ;
			data[0] = data[0] | ( this.unknown_1 << 30 ) ;
			data[0] = data[0] | ( this.display << 31 ) ;
			data[1] = data[1] | ( this.unknown_2 << 0 ) ;
			data[1] = data[1] | ( this.family_line_num << 1 ) ;
			data[1] = data[1] | ( this.unknown_3 << 9 ) ;
			data[1] = data[1] | ( this.factor_left << 24 ) ;
			data[1] = data[1] | ( this.factor_right << 28 ) ;
			data[2] = data[2] | ( this.name_left << 0 ) ;
			data[2] = data[2] | ( this.name_right << 16 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HBloodData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 3 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 3)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 3;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HFamilyLineData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 family_line_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 family_line_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x000000ff;  }
			set {
				if( value > family_line_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 attr_speed_MAXVALUE = 0x00000001; // 1
		public UInt32 attr_speed {
			get { return ( this.__bitfield0 >> 8 ) & 0x00000001;  }
			set {
				if( value > attr_speed_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffeff ) | ( value << 8 );
			}
		}
		public const UInt32 attr_stamina_MAXVALUE = 0x00000001; // 1
		public UInt32 attr_stamina {
			get { return ( this.__bitfield0 >> 9 ) & 0x00000001;  }
			set {
				if( value > attr_stamina_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffdff ) | ( value << 9 );
			}
		}
		public const UInt32 influence_MAXVALUE = 0x00000001; // 1
		public UInt32 influence {
			get { return ( this.__bitfield0 >> 10 ) & 0x00000001;  }
			set {
				if( value > influence_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffbff ) | ( value << 10 );
			}
		}
		public const UInt32 bms_O_MAXVALUE = 0x00000001; // 1
		public UInt32 bms_O {
			get { return ( this.__bitfield0 >> 11 ) & 0x00000001;  }
			set {
				if( value > bms_O_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffff7ff ) | ( value << 11 );
			}
		}
		public const UInt32 unknown_1_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_1 {
			get { return ( this.__bitfield0 >> 12 ) & 0x00000001;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffefff ) | ( value << 12 );
			}
		}
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 blood_num {
			get { return ( this.__bitfield0 >> 13 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf0001fff ) | ( value << 13 );
			}
		}
		public const UInt32 unknown_2_MAXVALUE = 0x0000000f; // 15
		public UInt32 unknown_2 {
			get { return ( this.__bitfield0 >> 28 ) & 0x0000000f;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield0 = ( this.__bitfield0 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		public const UInt32 share_J_MAXVALUE = 0x000003ff; // 1023
		public UInt32 share_J {
			get { return ( this.__bitfield1 >> 0 ) & 0x000003ff;  }
			set {
				if( value > share_J_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		public const UInt32 share_U_MAXVALUE = 0x000003ff; // 1023
		public UInt32 share_U {
			get { return ( this.__bitfield1 >> 10 ) & 0x000003ff;  }
			set {
				if( value > share_U_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfff003ff ) | ( value << 10 );
			}
		}
		public const UInt32 share_E_MAXVALUE = 0x000003ff; // 1023
		public UInt32 share_E {
			get { return ( this.__bitfield1 >> 20 ) & 0x000003ff;  }
			set {
				if( value > share_E_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield1 = ( this.__bitfield1 & 0xc00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_3 {
			get { return ( this.__bitfield1 >> 30 ) & 0x00000003;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		public const UInt32 nicks_1_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_1_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_1_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 nicks_1_share_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_1_share {
			get { return ( this.__bitfield2 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_1_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 nicks_2_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_2_num {
			get { return ( this.__bitfield2 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_2_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield2 = ( this.__bitfield2 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 nicks_2_share_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 nicks_3_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_3_num {
			get { return ( this.__bitfield3 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_3_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 nicks_3_share_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_3_share {
			get { return ( this.__bitfield3 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_3_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 nicks_4_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_4_num {
			get { return ( this.__bitfield3 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_4_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 nicks_4_share_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 nicks_5_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_5_num {
			get { return ( this.__bitfield4 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_5_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 nicks_5_share_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_5_share {
			get { return ( this.__bitfield4 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_5_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 nicks_6_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_6_num {
			get { return ( this.__bitfield4 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_6_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 nicks_6_share_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 nicks_7_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_7_num {
			get { return ( this.__bitfield5 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_7_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 nicks_7_share_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_7_share {
			get { return ( this.__bitfield5 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_7_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 nicks_8_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_8_num {
			get { return ( this.__bitfield5 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_8_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield5 = ( this.__bitfield5 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 nicks_8_share_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 nicks_9_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_9_num {
			get { return ( this.__bitfield6 >> 0 ) & 0x000000ff;  }
			set {
				if( value > nicks_9_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 nicks_9_share_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_9_share {
			get { return ( this.__bitfield6 >> 8 ) & 0x000000ff;  }
			set {
				if( value > nicks_9_share_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 nicks_10_num_MAXVALUE = 0x000000ff; // 255
		public UInt32 nicks_10_num {
			get { return ( this.__bitfield6 >> 16 ) & 0x000000ff;  }
			set {
				if( value > nicks_10_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 nicks_10_share_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 name_1_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_1 {
			get { return ( this.__bitfield7 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 name_2_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_2 {
			get { return ( this.__bitfield7 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 name_3_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_3 {
			get { return ( this.__bitfield7 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield7 = ( this.__bitfield7 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 name_4_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 name_5_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_5 {
			get { return ( this.__bitfield8 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 name_6_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_6 {
			get { return ( this.__bitfield8 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 name_7_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_7 {
			get { return ( this.__bitfield8 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 name_8_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 name_9_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_9 {
			get { return ( this.__bitfield9 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 name_10_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_10 {
			get { return ( this.__bitfield9 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 name_11_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_11 {
			get { return ( this.__bitfield9 >> 16 ) & 0x000000ff;  }
			set {
				if( value > name_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield9 = ( this.__bitfield9 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 name_12_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 name_13_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_13 {
			get { return ( this.__bitfield10 >> 0 ) & 0x000000ff;  }
			set {
				if( value > name_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield10 = ( this.__bitfield10 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 name_14_MAXVALUE = 0x000000ff; // 255
		public UInt32 name_14 {
			get { return ( this.__bitfield10 >> 8 ) & 0x000000ff;  }
			set {
				if( value > name_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield10 = ( this.__bitfield10 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 unknown_4_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 unknown_4 {
			get { return ( this.__bitfield10 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > unknown_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield10 = ( this.__bitfield10 & 0x0000ffff ) | ( value << 16 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[11];
			data[0] = data[0] | ( this.family_line_num << 0 ) ;
			data[0] = data[0] | ( this.attr_speed << 8 ) ;
			data[0] = data[0] | ( this.attr_stamina << 9 ) ;
			data[0] = data[0] | ( this.influence << 10 ) ;
			data[0] = data[0] | ( this.bms_O << 11 ) ;
			data[0] = data[0] | ( this.unknown_1 << 12 ) ;
			data[0] = data[0] | ( this.blood_num << 13 ) ;
			data[0] = data[0] | ( this.unknown_2 << 28 ) ;
			data[1] = data[1] | ( this.share_J << 0 ) ;
			data[1] = data[1] | ( this.share_U << 10 ) ;
			data[1] = data[1] | ( this.share_E << 20 ) ;
			data[1] = data[1] | ( this.unknown_3 << 30 ) ;
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
			data[10] = data[10] | ( this.unknown_4 << 16 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HFamilyLineData obj ){
			return obj.ToArray();
		}
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
		public const UInt32 __SIZE__ = sizeof(UInt32) * 11;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HAblData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 speed_MAXVALUE = 0x0000007f; // 127
		public UInt32 speed {
			get { return ( this.__bitfield0 >> 0 ) & 0x0000007f;  }
			set {
				if( value > speed_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffff80 ) | ( value << 0 );
			}
		}
		public const UInt32 stamina_MAXVALUE = 0x0000007f; // 127
		public UInt32 stamina {
			get { return ( this.__bitfield0 >> 7 ) & 0x0000007f;  }
			set {
				if( value > stamina_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc07f ) | ( value << 7 );
			}
		}
		public const UInt32 health_MAXVALUE = 0x00000003; // 3
		public UInt32 health {
			get { return ( this.__bitfield0 >> 14 ) & 0x00000003;  }
			set {
				if( value > health_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffff3fff ) | ( value << 14 );
			}
		}
		public const UInt32 kodashi_MAXVALUE = 0x0000000f; // 15
		public UInt32 kodashi {
			get { return ( this.__bitfield0 >> 16 ) & 0x0000000f;  }
			set {
				if( value > kodashi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfff0ffff ) | ( value << 16 );
			}
		}
		public const UInt32 taikou_MAXVALUE = 0x00000003; // 3
		public UInt32 taikou {
			get { return ( this.__bitfield0 >> 20 ) & 0x00000003;  }
			set {
				if( value > taikou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffcfffff ) | ( value << 20 );
			}
		}
		public const UInt32 power_MAXVALUE = 0x00000003; // 3
		public UInt32 power {
			get { return ( this.__bitfield0 >> 22 ) & 0x00000003;  }
			set {
				if( value > power_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xff3fffff ) | ( value << 22 );
			}
		}
		public const UInt32 zyuunan_MAXVALUE = 0x00000003; // 3
		public UInt32 zyuunan {
			get { return ( this.__bitfield0 >> 24 ) & 0x00000003;  }
			set {
				if( value > zyuunan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfcffffff ) | ( value << 24 );
			}
		}
		public const UInt32 syunpatsu_MAXVALUE = 0x00000003; // 3
		public UInt32 syunpatsu {
			get { return ( this.__bitfield0 >> 26 ) & 0x00000003;  }
			set {
				if( value > syunpatsu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf3ffffff ) | ( value << 26 );
			}
		}
		public const UInt32 konzyou_MAXVALUE = 0x00000003; // 3
		public UInt32 konzyou {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000003;  }
			set {
				if( value > konzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xcfffffff ) | ( value << 28 );
			}
		}
		public const UInt32 kashikosa_MAXVALUE = 0x00000003; // 3
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
		public const UInt32 babatekisei_MAXVALUE = 0x00000003; // 3
		public UInt32 babatekisei {
			get { return ( this.__bitfield1 >> 0 ) & 0x00000003;  }
			set {
				if( value > babatekisei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffffc ) | ( value << 0 );
			}
		}
		public const UInt32 bokuzyou_MAXVALUE = 0x000000ff; // 255
		public UInt32 bokuzyou {
			get { return ( this.__bitfield1 >> 2 ) & 0x000000ff;  }
			set {
				if( value > bokuzyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc03 ) | ( value << 2 );
			}
		}
		public const UInt32 zenchou_MAXVALUE = 0x00000003; // 3
		public UInt32 zenchou {
			get { return ( this.__bitfield1 >> 10 ) & 0x00000003;  }
			set {
				if( value > zenchou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffff3ff ) | ( value << 10 );
			}
		}
		public const UInt32 keiro_MAXVALUE = 0x0000000f; // 15
		public UInt32 keiro {
			get { return ( this.__bitfield1 >> 12 ) & 0x0000000f;  }
			set {
				if( value > keiro_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffff0fff ) | ( value << 12 );
			}
		}
		public const UInt32 ryuusei_MAXVALUE = 0x0000001f; // 31
		public UInt32 ryuusei {
			get { return ( this.__bitfield1 >> 16 ) & 0x0000001f;  }
			set {
				if( value > ryuusei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffe0ffff ) | ( value << 16 );
			}
		}
		public const UInt32 seishin_MAXVALUE = 0x00000003; // 3
		public UInt32 seishin {
			get { return ( this.__bitfield1 >> 21 ) & 0x00000003;  }
			set {
				if( value > seishin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff9fffff ) | ( value << 21 );
			}
		}
		public const UInt32 seichougata_MAXVALUE = 0x00000007; // 7
		public UInt32 seichougata {
			get { return ( this.__bitfield1 >> 23 ) & 0x00000007;  }
			set {
				if( value > seichougata_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfc7fffff ) | ( value << 23 );
			}
		}
		public const UInt32 seichouryoku_MAXVALUE = 0x00000003; // 3
		public UInt32 seichouryoku {
			get { return ( this.__bitfield1 >> 26 ) & 0x00000003;  }
			set {
				if( value > seichouryoku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf3ffffff ) | ( value << 26 );
			}
		}
		public const UInt32 kisyou_MAXVALUE = 0x00000007; // 7
		public UInt32 kisyou {
			get { return ( this.__bitfield1 >> 28 ) & 0x00000007;  }
			set {
				if( value > kisyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0x8fffffff ) | ( value << 28 );
			}
		}
		public const UInt32 unknown_1_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_1 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		public const UInt32 seisankoku_MAXVALUE = 0x0000000f; // 15
		public UInt32 seisankoku {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000000f;  }
			set {
				if( value > seisankoku_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffff0 ) | ( value << 0 );
			}
		}
		public const UInt32 right_flont_MAXVALUE = 0x00000003; // 3
		public UInt32 right_flont {
			get { return ( this.__bitfield2 >> 4 ) & 0x00000003;  }
			set {
				if( value > right_flont_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffffcf ) | ( value << 4 );
			}
		}
		public const UInt32 left_flont_MAXVALUE = 0x00000003; // 3
		public UInt32 left_flont {
			get { return ( this.__bitfield2 >> 6 ) & 0x00000003;  }
			set {
				if( value > left_flont_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff3f ) | ( value << 6 );
			}
		}
		public const UInt32 right_hind_MAXVALUE = 0x00000003; // 3
		public UInt32 right_hind {
			get { return ( this.__bitfield2 >> 8 ) & 0x00000003;  }
			set {
				if( value > right_hind_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffcff ) | ( value << 8 );
			}
		}
		public const UInt32 left_hinde_MAXVALUE = 0x00000003; // 3
		public UInt32 left_hinde {
			get { return ( this.__bitfield2 >> 10 ) & 0x00000003;  }
			set {
				if( value > left_hinde_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffff3ff ) | ( value << 10 );
			}
		}
		public const UInt32 senpou_MAXVALUE = 0x00000007; // 7
		public UInt32 senpou {
			get { return ( this.__bitfield2 >> 12 ) & 0x00000007;  }
			set {
				if( value > senpou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8fff ) | ( value << 12 );
			}
		}
		public const UInt32 komawari_X_MAXVALUE = 0x00000001; // 1
		public UInt32 komawari_X {
			get { return ( this.__bitfield2 >> 15 ) & 0x00000001;  }
			set {
				if( value > komawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff7fff ) | ( value << 15 );
			}
		}
		public const UInt32 tokusei_1_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_1 {
			get { return ( this.__bitfield2 >> 16 ) & 0x00000001;  }
			set {
				if( value > tokusei_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffeffff ) | ( value << 16 );
			}
		}
		public const UInt32 tokusei_2_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_2 {
			get { return ( this.__bitfield2 >> 17 ) & 0x00000001;  }
			set {
				if( value > tokusei_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffdffff ) | ( value << 17 );
			}
		}
		public const UInt32 tokusei_3_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_3 {
			get { return ( this.__bitfield2 >> 18 ) & 0x00000001;  }
			set {
				if( value > tokusei_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffbffff ) | ( value << 18 );
			}
		}
		public const UInt32 tokusei_4_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_4 {
			get { return ( this.__bitfield2 >> 19 ) & 0x00000001;  }
			set {
				if( value > tokusei_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfff7ffff ) | ( value << 19 );
			}
		}
		public const UInt32 tokusei_5_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_5 {
			get { return ( this.__bitfield2 >> 20 ) & 0x00000001;  }
			set {
				if( value > tokusei_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffefffff ) | ( value << 20 );
			}
		}
		public const UInt32 tokusei_6_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_6 {
			get { return ( this.__bitfield2 >> 21 ) & 0x00000001;  }
			set {
				if( value > tokusei_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffdfffff ) | ( value << 21 );
			}
		}
		public const UInt32 tokusei_7_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_7 {
			get { return ( this.__bitfield2 >> 22 ) & 0x00000001;  }
			set {
				if( value > tokusei_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffbfffff ) | ( value << 22 );
			}
		}
		public const UInt32 tokusei_8_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_8 {
			get { return ( this.__bitfield2 >> 23 ) & 0x00000001;  }
			set {
				if( value > tokusei_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xff7fffff ) | ( value << 23 );
			}
		}
		public const UInt32 tokusei_9_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_9 {
			get { return ( this.__bitfield2 >> 24 ) & 0x00000001;  }
			set {
				if( value > tokusei_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfeffffff ) | ( value << 24 );
			}
		}
		public const UInt32 tokusei_10_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_10 {
			get { return ( this.__bitfield2 >> 25 ) & 0x00000001;  }
			set {
				if( value > tokusei_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfdffffff ) | ( value << 25 );
			}
		}
		public const UInt32 tokusei_11_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_11 {
			get { return ( this.__bitfield2 >> 26 ) & 0x00000001;  }
			set {
				if( value > tokusei_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfbffffff ) | ( value << 26 );
			}
		}
		public const UInt32 tokusei_12_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_12 {
			get { return ( this.__bitfield2 >> 27 ) & 0x00000001;  }
			set {
				if( value > tokusei_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xf7ffffff ) | ( value << 27 );
			}
		}
		public const UInt32 tokusei_13_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_13 {
			get { return ( this.__bitfield2 >> 28 ) & 0x00000001;  }
			set {
				if( value > tokusei_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xefffffff ) | ( value << 28 );
			}
		}
		public const UInt32 tokusei_14_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_14 {
			get { return ( this.__bitfield2 >> 29 ) & 0x00000001;  }
			set {
				if( value > tokusei_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xdfffffff ) | ( value << 29 );
			}
		}
		public const UInt32 tokusei_15_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_15 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000001;  }
			set {
				if( value > tokusei_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 tokusei_16_MAXVALUE = 0x00000001; // 1
		public UInt32 tokusei_16 {
			get { return ( this.__bitfield2 >> 31 ) & 0x00000001;  }
			set {
				if( value > tokusei_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield2 = ( this.__bitfield2 & 0x7fffffff ) | ( value << 31 );
			}
		}
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
			data[1] = data[1] | ( this.unknown_1 << 31 ) ;
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
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HAblData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 3 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 3)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 3;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HDamData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 price_MAXVALUE = 0x000003ff; // 1023
		public UInt32 price {
			get { return ( this.__bitfield0 >> 0 ) & 0x000003ff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		public const UInt32 tanetsuke_sire_MAXVALUE = 0x000007ff; // 2047
		public UInt32 tanetsuke_sire {
			get { return ( this.__bitfield0 >> 10 ) & 0x000007ff;  }
			set {
				if( value > tanetsuke_sire_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffe003ff ) | ( value << 10 );
			}
		}
		public const UInt32 unknown_1_MAXVALUE = 0x0000007f; // 127
		public UInt32 unknown_1 {
			get { return ( this.__bitfield0 >> 21 ) & 0x0000007f;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf01fffff ) | ( value << 21 );
			}
		}
		public const UInt32 fuda_color_MAXVALUE = 0x00000007; // 7
		public UInt32 fuda_color {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000007;  }
			set {
				if( value > fuda_color_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield0 = ( this.__bitfield0 & 0x8fffffff ) | ( value << 28 );
			}
		}
		public const UInt32 unknown_2_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_2 {
			get { return ( this.__bitfield0 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		public const UInt32 career_years_MAXVALUE = 0x0000001f; // 31
		public UInt32 career_years {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000001f;  }
			set {
				if( value > career_years_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffe0 ) | ( value << 0 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x0000001f; // 31
		public UInt32 unknown_3 {
			get { return ( this.__bitfield1 >> 5 ) & 0x0000001f;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffc1f ) | ( value << 5 );
			}
		}
		public const UInt32 career_count_MAXVALUE = 0x0000000f; // 15
		public UInt32 career_count {
			get { return ( this.__bitfield1 >> 10 ) & 0x0000000f;  }
			set {
				if( value > career_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffc3ff ) | ( value << 10 );
			}
		}
		public const UInt32 status_MAXVALUE = 0x00000003; // 3
		public UInt32 status {
			get { return ( this.__bitfield1 >> 14 ) & 0x00000003;  }
			set {
				if( value > status_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffff3fff ) | ( value << 14 );
			}
		}
		public const UInt32 intai_MAXVALUE = 0x00000001; // 1
		public UInt32 intai {
			get { return ( this.__bitfield1 >> 16 ) & 0x00000001;  }
			set {
				if( value > intai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffeffff ) | ( value << 16 );
			}
		}
		public const UInt32 unknown_4_MAXVALUE = 0x000001ff; // 511
		public UInt32 unknown_4 {
			get { return ( this.__bitfield1 >> 17 ) & 0x000001ff;  }
			set {
				if( value > unknown_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfc01ffff ) | ( value << 17 );
			}
		}
		public const UInt32 age_MAXVALUE = 0x0000001f; // 31
		public UInt32 age {
			get { return ( this.__bitfield1 >> 26 ) & 0x0000001f;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield1 = ( this.__bitfield1 & 0x83ffffff ) | ( value << 26 );
			}
		}
		public const UInt32 unknown_5_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_5 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 abl_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8000 ) | ( value << 0 );
			}
		}
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 blood_num {
			get { return ( this.__bitfield2 >> 15 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc0007fff ) | ( value << 15 );
			}
		}
		public const UInt32 unknown_6_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_6 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > unknown_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		public const UInt32 kachikura_MAXVALUE = 0x00000fff; // 4095
		public UInt32 kachikura {
			get { return ( this.__bitfield3 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfffff000 ) | ( value << 0 );
			}
		}
		public const UInt32 record_len_MAXVALUE = 0x000000ff; // 255
		public UInt32 record_len {
			get { return ( this.__bitfield3 >> 12 ) & 0x000000ff;  }
			set {
				if( value > record_len_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfff00fff ) | ( value << 12 );
			}
		}
		public const UInt32 record_win_MAXVALUE = 0x000000ff; // 255
		public UInt32 record_win {
			get { return ( this.__bitfield3 >> 20 ) & 0x000000ff;  }
			set {
				if( value > record_win_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0xf00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_7_MAXVALUE = 0x0000000f; // 15
		public UInt32 unknown_7 {
			get { return ( this.__bitfield3 >> 28 ) & 0x0000000f;  }
			set {
				if( value > unknown_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield3 = ( this.__bitfield3 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		public const UInt32 unknown_8_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_8 {
			get { return ( this.__bitfield4 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield4 = ( this.__bitfield4 & 0x00000000 ) | ( value << 0 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[5];
			data[0] = data[0] | ( this.price << 0 ) ;
			data[0] = data[0] | ( this.tanetsuke_sire << 10 ) ;
			data[0] = data[0] | ( this.unknown_1 << 21 ) ;
			data[0] = data[0] | ( this.fuda_color << 28 ) ;
			data[0] = data[0] | ( this.unknown_2 << 31 ) ;
			data[1] = data[1] | ( this.career_years << 0 ) ;
			data[1] = data[1] | ( this.unknown_3 << 5 ) ;
			data[1] = data[1] | ( this.career_count << 10 ) ;
			data[1] = data[1] | ( this.status << 14 ) ;
			data[1] = data[1] | ( this.intai << 16 ) ;
			data[1] = data[1] | ( this.unknown_4 << 17 ) ;
			data[1] = data[1] | ( this.age << 26 ) ;
			data[1] = data[1] | ( this.unknown_5 << 31 ) ;
			data[2] = data[2] | ( this.abl_num << 0 ) ;
			data[2] = data[2] | ( this.blood_num << 15 ) ;
			data[2] = data[2] | ( this.unknown_6 << 30 ) ;
			data[3] = data[3] | ( this.kachikura << 0 ) ;
			data[3] = data[3] | ( this.record_len << 12 ) ;
			data[3] = data[3] | ( this.record_win << 20 ) ;
			data[3] = data[3] | ( this.unknown_7 << 28 ) ;
			data[4] = data[4] | ( this.unknown_8 << 0 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HDamData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 5 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 5)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 5;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HSireData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 win_grade_count_MAXVALUE = 0x000003ff; // 1023
		public UInt32 win_grade_count {
			get { return ( this.__bitfield0 >> 0 ) & 0x000003ff;  }
			set {
				if( value > win_grade_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		public const UInt32 win_g1_count_MAXVALUE = 0x000003ff; // 1023
		public UInt32 win_g1_count {
			get { return ( this.__bitfield0 >> 10 ) & 0x000003ff;  }
			set {
				if( value > win_g1_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfff003ff ) | ( value << 10 );
			}
		}
		public const UInt32 tanetsuke_MAXVALUE = 0x0000007f; // 127
		public UInt32 tanetsuke {
			get { return ( this.__bitfield0 >> 20 ) & 0x0000007f;  }
			set {
				if( value > tanetsuke_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf80fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_1_MAXVALUE = 0x0000001f; // 31
		public UInt32 unknown_1 {
			get { return ( this.__bitfield0 >> 27 ) & 0x0000001f;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-31)");
				this.__bitfield0 = ( this.__bitfield0 & 0x07ffffff ) | ( value << 27 );
			}
		}
		// 4 byte data
		[FieldOffset(4)] private UInt32 __bitfield1;
		public const UInt32 unknown_2_MAXVALUE = 0x007fffff; // 8388607
		public UInt32 unknown_2 {
			get { return ( this.__bitfield1 >> 0 ) & 0x007fffff;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8388607)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff800000 ) | ( value << 0 );
			}
		}
		public const UInt32 syussou_count_MAXVALUE = 0x000000ff; // 255
		public UInt32 syussou_count {
			get { return ( this.__bitfield1 >> 23 ) & 0x000000ff;  }
			set {
				if( value > syussou_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0x807fffff ) | ( value << 23 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_3 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 abl_num {
			get { return ( this.__bitfield2 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffff8000 ) | ( value << 0 );
			}
		}
		public const UInt32 blood_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 blood_num {
			get { return ( this.__bitfield2 >> 15 ) & 0x00007fff;  }
			set {
				if( value > blood_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc0007fff ) | ( value << 15 );
			}
		}
		public const UInt32 intai_MAXVALUE = 0x00000003; // 3
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
		public const UInt32 syoukin_MAXVALUE = 0x000fffff; // 1048575
		public UInt32 syoukin {
			get { return ( this.__bitfield3 >> 0 ) & 0x000fffff;  }
			set {
				if( value > syoukin_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfff00000 ) | ( value << 0 );
			}
		}
		public const UInt32 age_MAXVALUE = 0x0000003f; // 63
		public UInt32 age {
			get { return ( this.__bitfield3 >> 20 ) & 0x0000003f;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0xfc0fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_4_MAXVALUE = 0x0000003f; // 63
		public UInt32 unknown_4 {
			get { return ( this.__bitfield3 >> 26 ) & 0x0000003f;  }
			set {
				if( value > unknown_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0x03ffffff ) | ( value << 26 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		public const UInt32 unknown_5_MAXVALUE = 0x000fffff; // 1048575
		public UInt32 unknown_5 {
			get { return ( this.__bitfield4 >> 0 ) & 0x000fffff;  }
			set {
				if( value > unknown_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfff00000 ) | ( value << 0 );
			}
		}
		public const UInt32 win_count_MAXVALUE = 0x000000ff; // 255
		public UInt32 win_count {
			get { return ( this.__bitfield4 >> 20 ) & 0x000000ff;  }
			set {
				if( value > win_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xf00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_6_MAXVALUE = 0x0000000f; // 15
		public UInt32 unknown_6 {
			get { return ( this.__bitfield4 >> 28 ) & 0x0000000f;  }
			set {
				if( value > unknown_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield4 = ( this.__bitfield4 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 20 byte data
		[FieldOffset(20)] private UInt32 __bitfield5;
		public const UInt32 unknown_7_MAXVALUE = 0x0fffffff; // 268435455
		public UInt32 unknown_7 {
			get { return ( this.__bitfield5 >> 0 ) & 0x0fffffff;  }
			set {
				if( value > unknown_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-268435455)");
				this.__bitfield5 = ( this.__bitfield5 & 0xf0000000 ) | ( value << 0 );
			}
		}
		public const UInt32 bookfull_MAXVALUE = 0x00000001; // 1
		public UInt32 bookfull {
			get { return ( this.__bitfield5 >> 28 ) & 0x00000001;  }
			set {
				if( value > bookfull_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield5 = ( this.__bitfield5 & 0xefffffff ) | ( value << 28 );
			}
		}
		public const UInt32 syndicate_MAXVALUE = 0x00000001; // 1
		public UInt32 syndicate {
			get { return ( this.__bitfield5 >> 29 ) & 0x00000001;  }
			set {
				if( value > syndicate_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield5 = ( this.__bitfield5 & 0xdfffffff ) | ( value << 29 );
			}
		}
		public const UInt32 unknown_8_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_8 {
			get { return ( this.__bitfield5 >> 30 ) & 0x00000003;  }
			set {
				if( value > unknown_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield5 = ( this.__bitfield5 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 24 byte data
		[FieldOffset(24)] private UInt32 __bitfield6;
		public const UInt32 unknown_9_MAXVALUE = 0x000fffff; // 1048575
		public UInt32 unknown_9 {
			get { return ( this.__bitfield6 >> 0 ) & 0x000fffff;  }
			set {
				if( value > unknown_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield6 = ( this.__bitfield6 & 0xfff00000 ) | ( value << 0 );
			}
		}
		public const UInt32 tanetsuke_count_MAXVALUE = 0x000000ff; // 255
		public UInt32 tanetsuke_count {
			get { return ( this.__bitfield6 >> 20 ) & 0x000000ff;  }
			set {
				if( value > tanetsuke_count_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield6 = ( this.__bitfield6 & 0xf00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_10_MAXVALUE = 0x0000000f; // 15
		public UInt32 unknown_10 {
			get { return ( this.__bitfield6 >> 28 ) & 0x0000000f;  }
			set {
				if( value > unknown_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield6 = ( this.__bitfield6 & 0x0fffffff ) | ( value << 28 );
			}
		}
		// 28 byte data
		[FieldOffset(28)] private UInt32 __bitfield7;
		public const UInt32 unknown_11_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_11 {
			get { return ( this.__bitfield7 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield7 = ( this.__bitfield7 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		public const UInt32 kachikura_LT_MAXVALUE = 0x00000fff; // 4095
		public UInt32 kachikura_LT {
			get { return ( this.__bitfield8 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_LT_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield8 = ( this.__bitfield8 & 0xfffff000 ) | ( value << 0 );
			}
		}
		public const UInt32 kachikura_LB_MAXVALUE = 0x00000fff; // 4095
		public UInt32 kachikura_LB {
			get { return ( this.__bitfield8 >> 12 ) & 0x00000fff;  }
			set {
				if( value > kachikura_LB_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield8 = ( this.__bitfield8 & 0xff000fff ) | ( value << 12 );
			}
		}
		public const UInt32 unknown_12_MAXVALUE = 0x000000ff; // 255
		public UInt32 unknown_12 {
			get { return ( this.__bitfield8 >> 24 ) & 0x000000ff;  }
			set {
				if( value > unknown_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield8 = ( this.__bitfield8 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 36 byte data
		[FieldOffset(36)] private UInt32 __bitfield9;
		public const UInt32 kachikura_RT_MAXVALUE = 0x00000fff; // 4095
		public UInt32 kachikura_RT {
			get { return ( this.__bitfield9 >> 0 ) & 0x00000fff;  }
			set {
				if( value > kachikura_RT_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield9 = ( this.__bitfield9 & 0xfffff000 ) | ( value << 0 );
			}
		}
		public const UInt32 kachikura_RB_MAXVALUE = 0x00000fff; // 4095
		public UInt32 kachikura_RB {
			get { return ( this.__bitfield9 >> 12 ) & 0x00000fff;  }
			set {
				if( value > kachikura_RB_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield9 = ( this.__bitfield9 & 0xff000fff ) | ( value << 12 );
			}
		}
		public const UInt32 youku1_count_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 daihyousan_w1_MAXVALUE = 0x00000fff; // 4095
		public UInt32 daihyousan_w1 {
			get { return ( this.__bitfield10 >> 0 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield10 = ( this.__bitfield10 & 0xfffff000 ) | ( value << 0 );
			}
		}
		public const UInt32 daihyousan_w2_MAXVALUE = 0x00000fff; // 4095
		public UInt32 daihyousan_w2 {
			get { return ( this.__bitfield10 >> 12 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield10 = ( this.__bitfield10 & 0xff000fff ) | ( value << 12 );
			}
		}
		public const UInt32 geneki_count_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 daihyousan_w3_MAXVALUE = 0x00000fff; // 4095
		public UInt32 daihyousan_w3 {
			get { return ( this.__bitfield11 >> 0 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfffff000 ) | ( value << 0 );
			}
		}
		public const UInt32 daihyousan_w4_MAXVALUE = 0x00000fff; // 4095
		public UInt32 daihyousan_w4 {
			get { return ( this.__bitfield11 >> 12 ) & 0x00000fff;  }
			set {
				if( value > daihyousan_w4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield11 = ( this.__bitfield11 & 0xff000fff ) | ( value << 12 );
			}
		}
		public const UInt32 rank_5_ago_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 daihyousan_1_MAXVALUE = 0xffffffff; // 4294967295
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
		public const UInt32 daihyousan_2_MAXVALUE = 0xffffffff; // 4294967295
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
		public const UInt32 daihyousan_3_MAXVALUE = 0xffffffff; // 4294967295
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
		public const UInt32 daihyousan_4_MAXVALUE = 0xffffffff; // 4294967295
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
		public const UInt32 rank_1_ago_MAXVALUE = 0x000000ff; // 255
		public UInt32 rank_1_ago {
			get { return ( this.__bitfield16 >> 0 ) & 0x000000ff;  }
			set {
				if( value > rank_1_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 rank_2_ago_MAXVALUE = 0x000000ff; // 255
		public UInt32 rank_2_ago {
			get { return ( this.__bitfield16 >> 8 ) & 0x000000ff;  }
			set {
				if( value > rank_2_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 rank_3_ago_MAXVALUE = 0x000000ff; // 255
		public UInt32 rank_3_ago {
			get { return ( this.__bitfield16 >> 16 ) & 0x000000ff;  }
			set {
				if( value > rank_3_ago_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield16 = ( this.__bitfield16 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 rank_4_ago_MAXVALUE = 0x000000ff; // 255
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
		public const UInt32 unknown_13_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_13 {
			get { return ( this.__bitfield17 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield17 = ( this.__bitfield17 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 72 byte data
		[FieldOffset(72)] private UInt32 __bitfield18;
		public const UInt32 unknown_14_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_14 {
			get { return ( this.__bitfield18 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield18 = ( this.__bitfield18 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 76 byte data
		[FieldOffset(76)] private UInt32 __bitfield19;
		public const UInt32 unknown_15_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_15 {
			get { return ( this.__bitfield19 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield19 = ( this.__bitfield19 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 80 byte data
		[FieldOffset(80)] private UInt32 __bitfield20;
		public const UInt32 unknown_16_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_16 {
			get { return ( this.__bitfield20 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_16_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield20 = ( this.__bitfield20 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 84 byte data
		[FieldOffset(84)] private UInt32 __bitfield21;
		public const UInt32 unknown_17_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_17 {
			get { return ( this.__bitfield21 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_17_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield21 = ( this.__bitfield21 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 88 byte data
		[FieldOffset(88)] private UInt32 __bitfield22;
		public const UInt32 unknown_18_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_18 {
			get { return ( this.__bitfield22 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_18_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield22 = ( this.__bitfield22 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 92 byte data
		[FieldOffset(92)] private UInt32 __bitfield23;
		public const UInt32 unknown_19_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_19 {
			get { return ( this.__bitfield23 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_19_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield23 = ( this.__bitfield23 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 96 byte data
		[FieldOffset(96)] private UInt32 __bitfield24;
		public const UInt32 unknown_20_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_20 {
			get { return ( this.__bitfield24 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_20_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield24 = ( this.__bitfield24 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 100 byte data
		[FieldOffset(100)] private UInt32 __bitfield25;
		public const UInt32 unknown_21_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_21 {
			get { return ( this.__bitfield25 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_21_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield25 = ( this.__bitfield25 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 104 byte data
		[FieldOffset(104)] private UInt32 __bitfield26;
		public const UInt32 unknown_22_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_22 {
			get { return ( this.__bitfield26 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_22_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield26 = ( this.__bitfield26 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 108 byte data
		[FieldOffset(108)] private UInt32 __bitfield27;
		public const UInt32 unknown_23_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_23 {
			get { return ( this.__bitfield27 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_23_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield27 = ( this.__bitfield27 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 112 byte data
		[FieldOffset(112)] private UInt32 __bitfield28;
		public const UInt32 unknown_24_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_24 {
			get { return ( this.__bitfield28 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_24_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield28 = ( this.__bitfield28 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 116 byte data
		[FieldOffset(116)] private UInt32 __bitfield29;
		public const UInt32 unknown_25_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_25 {
			get { return ( this.__bitfield29 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_25_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield29 = ( this.__bitfield29 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 120 byte data
		[FieldOffset(120)] private UInt32 __bitfield30;
		public const UInt32 unknown_26_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_26 {
			get { return ( this.__bitfield30 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_26_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield30 = ( this.__bitfield30 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 124 byte data
		[FieldOffset(124)] private UInt32 __bitfield31;
		public const UInt32 unknown_27_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_27 {
			get { return ( this.__bitfield31 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_27_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield31 = ( this.__bitfield31 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 128 byte data
		[FieldOffset(128)] private UInt32 __bitfield32;
		public const UInt32 unknown_28_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_28 {
			get { return ( this.__bitfield32 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_28_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield32 = ( this.__bitfield32 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 132 byte data
		[FieldOffset(132)] private UInt32 __bitfield33;
		public const UInt32 unknown_29_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_29 {
			get { return ( this.__bitfield33 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_29_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield33 = ( this.__bitfield33 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 136 byte data
		[FieldOffset(136)] private UInt32 __bitfield34;
		public const UInt32 unknown_30_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_30 {
			get { return ( this.__bitfield34 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_30_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield34 = ( this.__bitfield34 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 140 byte data
		[FieldOffset(140)] private UInt32 __bitfield35;
		public const UInt32 unknown_31_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_31 {
			get { return ( this.__bitfield35 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_31_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield35 = ( this.__bitfield35 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 144 byte data
		[FieldOffset(144)] private UInt32 __bitfield36;
		public const UInt32 unknown_32_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_32 {
			get { return ( this.__bitfield36 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_32_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield36 = ( this.__bitfield36 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 148 byte data
		[FieldOffset(148)] private UInt32 __bitfield37;
		public const UInt32 unknown_33_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_33 {
			get { return ( this.__bitfield37 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_33_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield37 = ( this.__bitfield37 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 152 byte data
		[FieldOffset(152)] private UInt32 __bitfield38;
		public const UInt32 unknown_34_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_34 {
			get { return ( this.__bitfield38 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_34_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield38 = ( this.__bitfield38 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 156 byte data
		[FieldOffset(156)] private UInt32 __bitfield39;
		public const UInt32 unknown_35_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_35 {
			get { return ( this.__bitfield39 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_35_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield39 = ( this.__bitfield39 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 160 byte data
		[FieldOffset(160)] private UInt32 __bitfield40;
		public const UInt32 unknown_36_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_36 {
			get { return ( this.__bitfield40 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_36_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield40 = ( this.__bitfield40 & 0x00000000 ) | ( value << 0 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[41];
			data[0] = data[0] | ( this.win_grade_count << 0 ) ;
			data[0] = data[0] | ( this.win_g1_count << 10 ) ;
			data[0] = data[0] | ( this.tanetsuke << 20 ) ;
			data[0] = data[0] | ( this.unknown_1 << 27 ) ;
			data[1] = data[1] | ( this.unknown_2 << 0 ) ;
			data[1] = data[1] | ( this.syussou_count << 23 ) ;
			data[1] = data[1] | ( this.unknown_3 << 31 ) ;
			data[2] = data[2] | ( this.abl_num << 0 ) ;
			data[2] = data[2] | ( this.blood_num << 15 ) ;
			data[2] = data[2] | ( this.intai << 30 ) ;
			data[3] = data[3] | ( this.syoukin << 0 ) ;
			data[3] = data[3] | ( this.age << 20 ) ;
			data[3] = data[3] | ( this.unknown_4 << 26 ) ;
			data[4] = data[4] | ( this.unknown_5 << 0 ) ;
			data[4] = data[4] | ( this.win_count << 20 ) ;
			data[4] = data[4] | ( this.unknown_6 << 28 ) ;
			data[5] = data[5] | ( this.unknown_7 << 0 ) ;
			data[5] = data[5] | ( this.bookfull << 28 ) ;
			data[5] = data[5] | ( this.syndicate << 29 ) ;
			data[5] = data[5] | ( this.unknown_8 << 30 ) ;
			data[6] = data[6] | ( this.unknown_9 << 0 ) ;
			data[6] = data[6] | ( this.tanetsuke_count << 20 ) ;
			data[6] = data[6] | ( this.unknown_10 << 28 ) ;
			data[7] = data[7] | ( this.unknown_11 << 0 ) ;
			data[8] = data[8] | ( this.kachikura_LT << 0 ) ;
			data[8] = data[8] | ( this.kachikura_LB << 12 ) ;
			data[8] = data[8] | ( this.unknown_12 << 24 ) ;
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
			data[17] = data[17] | ( this.unknown_13 << 0 ) ;
			data[18] = data[18] | ( this.unknown_14 << 0 ) ;
			data[19] = data[19] | ( this.unknown_15 << 0 ) ;
			data[20] = data[20] | ( this.unknown_16 << 0 ) ;
			data[21] = data[21] | ( this.unknown_17 << 0 ) ;
			data[22] = data[22] | ( this.unknown_18 << 0 ) ;
			data[23] = data[23] | ( this.unknown_19 << 0 ) ;
			data[24] = data[24] | ( this.unknown_20 << 0 ) ;
			data[25] = data[25] | ( this.unknown_21 << 0 ) ;
			data[26] = data[26] | ( this.unknown_22 << 0 ) ;
			data[27] = data[27] | ( this.unknown_23 << 0 ) ;
			data[28] = data[28] | ( this.unknown_24 << 0 ) ;
			data[29] = data[29] | ( this.unknown_25 << 0 ) ;
			data[30] = data[30] | ( this.unknown_26 << 0 ) ;
			data[31] = data[31] | ( this.unknown_27 << 0 ) ;
			data[32] = data[32] | ( this.unknown_28 << 0 ) ;
			data[33] = data[33] | ( this.unknown_29 << 0 ) ;
			data[34] = data[34] | ( this.unknown_30 << 0 ) ;
			data[35] = data[35] | ( this.unknown_31 << 0 ) ;
			data[36] = data[36] | ( this.unknown_32 << 0 ) ;
			data[37] = data[37] | ( this.unknown_33 << 0 ) ;
			data[38] = data[38] | ( this.unknown_34 << 0 ) ;
			data[39] = data[39] | ( this.unknown_35 << 0 ) ;
			data[40] = data[40] | ( this.unknown_36 << 0 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HSireData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 41 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 41)",data.Length));
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
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 41;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HChildData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 price_MAXVALUE = 0x00003fff; // 16383
		public UInt32 price {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		public const UInt32 mother_num_MAXVALUE = 0x00003fff; // 16383
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 14 ) & 0x00003fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xf0003fff ) | ( value << 14 );
			}
		}
		public const UInt32 weak_point_3_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_3 {
			get { return ( this.__bitfield0 >> 28 ) & 0x00000003;  }
			set {
				if( value > weak_point_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xcfffffff ) | ( value << 28 );
			}
		}
		public const UInt32 age_MAXVALUE = 0x00000001; // 1
		public UInt32 age {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 gender_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 unknown_1_MAXVALUE = 0x0000007f; // 127
		public UInt32 unknown_1 {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000007f;  }
			set {
				if( value > unknown_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffff80 ) | ( value << 0 );
			}
		}
		public const UInt32 weak_point_1_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_1 {
			get { return ( this.__bitfield1 >> 7 ) & 0x00000003;  }
			set {
				if( value > weak_point_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffe7f ) | ( value << 7 );
			}
		}
		public const UInt32 breeder_MAXVALUE = 0x000000ff; // 255
		public UInt32 breeder {
			get { return ( this.__bitfield1 >> 9 ) & 0x000000ff;  }
			set {
				if( value > breeder_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffe01ff ) | ( value << 9 );
			}
		}
		public const UInt32 unknown_2_MAXVALUE = 0x0000007f; // 127
		public UInt32 unknown_2 {
			get { return ( this.__bitfield1 >> 17 ) & 0x0000007f;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xff01ffff ) | ( value << 17 );
			}
		}
		public const UInt32 zyumyou_MAXVALUE = 0x0000007f; // 127
		public UInt32 zyumyou {
			get { return ( this.__bitfield1 >> 24 ) & 0x0000007f;  }
			set {
				if( value > zyumyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0x80ffffff ) | ( value << 24 );
			}
		}
		public const UInt32 migimawari_X_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 price2_MAXVALUE = 0x000003ff; // 1023
		public UInt32 price2 {
			get { return ( this.__bitfield2 >> 0 ) & 0x000003ff;  }
			set {
				if( value > price2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1023)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffffc00 ) | ( value << 0 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x0000007f; // 127
		public UInt32 unknown_3 {
			get { return ( this.__bitfield2 >> 10 ) & 0x0000007f;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfffe03ff ) | ( value << 10 );
			}
		}
		public const UInt32 weak_point_2_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_2 {
			get { return ( this.__bitfield2 >> 17 ) & 0x00000003;  }
			set {
				if( value > weak_point_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0xfff9ffff ) | ( value << 17 );
			}
		}
		public const UInt32 father_num_MAXVALUE = 0x000007ff; // 2047
		public UInt32 father_num {
			get { return ( this.__bitfield2 >> 19 ) & 0x000007ff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc007ffff ) | ( value << 19 );
			}
		}
		public const UInt32 unknown_4_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_4 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > unknown_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 abl_num {
			get { return ( this.__bitfield3 >> 0 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffff8000 ) | ( value << 0 );
			}
		}
		public const UInt32 owner_MAXVALUE = 0x00000fff; // 4095
		public UInt32 owner {
			get { return ( this.__bitfield3 >> 15 ) & 0x00000fff;  }
			set {
				if( value > owner_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4095)");
				this.__bitfield3 = ( this.__bitfield3 & 0xf8007fff ) | ( value << 15 );
			}
		}
		public const UInt32 seigen_MAXVALUE = 0x0000000f; // 15
		public UInt32 seigen {
			get { return ( this.__bitfield3 >> 27 ) & 0x0000000f;  }
			set {
				if( value > seigen_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield3 = ( this.__bitfield3 & 0x87ffffff ) | ( value << 27 );
			}
		}
		public const UInt32 hidarimawari_X_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 name_number_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 name_number {
			get { return ( this.__bitfield4 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > name_number_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff0000 ) | ( value << 0 );
			}
		}
		public const UInt32 unknown_5_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_5 {
			get { return ( this.__bitfield4 >> 16 ) & 0x00000003;  }
			set {
				if( value > unknown_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffcffff ) | ( value << 16 );
			}
		}
		public const UInt32 fuda_color_MAXVALUE = 0x00000007; // 7
		public UInt32 fuda_color {
			get { return ( this.__bitfield4 >> 18 ) & 0x00000007;  }
			set {
				if( value > fuda_color_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffe3ffff ) | ( value << 18 );
			}
		}
		public const UInt32 unknown_6_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_6 {
			get { return ( this.__bitfield4 >> 21 ) & 0x00000001;  }
			set {
				if( value > unknown_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffdfffff ) | ( value << 21 );
			}
		}
		public const UInt32 torihiki_MAXVALUE = 0x00000007; // 7
		public UInt32 torihiki {
			get { return ( this.__bitfield4 >> 22 ) & 0x00000007;  }
			set {
				if( value > torihiki_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfe3fffff ) | ( value << 22 );
			}
		}
		public const UInt32 unknown_7_MAXVALUE = 0x0000007f; // 127
		public UInt32 unknown_7 {
			get { return ( this.__bitfield4 >> 25 ) & 0x0000007f;  }
			set {
				if( value > unknown_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield4 = ( this.__bitfield4 & 0x01ffffff ) | ( value << 25 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[5];
			data[0] = data[0] | ( this.price << 0 ) ;
			data[0] = data[0] | ( this.mother_num << 14 ) ;
			data[0] = data[0] | ( this.weak_point_3 << 28 ) ;
			data[0] = data[0] | ( this.age << 30 ) ;
			data[0] = data[0] | ( this.gender << 31 ) ;
			data[1] = data[1] | ( this.unknown_1 << 0 ) ;
			data[1] = data[1] | ( this.weak_point_1 << 7 ) ;
			data[1] = data[1] | ( this.breeder << 9 ) ;
			data[1] = data[1] | ( this.unknown_2 << 17 ) ;
			data[1] = data[1] | ( this.zyumyou << 24 ) ;
			data[1] = data[1] | ( this.migimawari_X << 31 ) ;
			data[2] = data[2] | ( this.price2 << 0 ) ;
			data[2] = data[2] | ( this.unknown_3 << 10 ) ;
			data[2] = data[2] | ( this.weak_point_2 << 17 ) ;
			data[2] = data[2] | ( this.father_num << 19 ) ;
			data[2] = data[2] | ( this.unknown_4 << 30 ) ;
			data[3] = data[3] | ( this.abl_num << 0 ) ;
			data[3] = data[3] | ( this.owner << 15 ) ;
			data[3] = data[3] | ( this.seigen << 27 ) ;
			data[3] = data[3] | ( this.hidarimawari_X << 31 ) ;
			data[4] = data[4] | ( this.name_number << 0 ) ;
			data[4] = data[4] | ( this.unknown_5 << 16 ) ;
			data[4] = data[4] | ( this.fuda_color << 18 ) ;
			data[4] = data[4] | ( this.unknown_6 << 21 ) ;
			data[4] = data[4] | ( this.torihiki << 22 ) ;
			data[4] = data[4] | ( this.unknown_7 << 25 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HChildData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 5 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 5)",data.Length));
			this.__bitfield0 = data[0];
			this.__bitfield1 = data[1];
			this.__bitfield2 = data[2];
			this.__bitfield3 = data[3];
			this.__bitfield4 = data[4];
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 5;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct HRaceData : DatastructInterface {
		// 0 byte data
		[FieldOffset(0)] private UInt32 __bitfield0;
		public const UInt32 mother_num_MAXVALUE = 0x00003fff; // 16383
		public UInt32 mother_num {
			get { return ( this.__bitfield0 >> 0 ) & 0x00003fff;  }
			set {
				if( value > mother_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffc000 ) | ( value << 0 );
			}
		}
		public const UInt32 maruchihou_MAXVALUE = 0x00000001; // 1
		public UInt32 maruchihou {
			get { return ( this.__bitfield0 >> 14 ) & 0x00000001;  }
			set {
				if( value > maruchihou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffffbfff ) | ( value << 14 );
			}
		}
		public const UInt32 unknown_2_MAXVALUE = 0x00000007; // 7
		public UInt32 unknown_2 {
			get { return ( this.__bitfield0 >> 15 ) & 0x00000007;  }
			set {
				if( value > unknown_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffc7fff ) | ( value << 15 );
			}
		}
		public const UInt32 hidarimawari_X_MAXVALUE = 0x00000001; // 1
		public UInt32 hidarimawari_X {
			get { return ( this.__bitfield0 >> 18 ) & 0x00000001;  }
			set {
				if( value > hidarimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xfffbffff ) | ( value << 18 );
			}
		}
		public const UInt32 unknown_3_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_3 {
			get { return ( this.__bitfield0 >> 19 ) & 0x00000003;  }
			set {
				if( value > unknown_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield0 = ( this.__bitfield0 & 0xffe7ffff ) | ( value << 19 );
			}
		}
		public const UInt32 shusen_jk_num_MAXVALUE = 0x000001ff; // 511
		public UInt32 shusen_jk_num {
			get { return ( this.__bitfield0 >> 21 ) & 0x000001ff;  }
			set {
				if( value > shusen_jk_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield0 = ( this.__bitfield0 & 0xc01fffff ) | ( value << 21 );
			}
		}
		public const UInt32 unknown_4_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_4 {
			get { return ( this.__bitfield0 >> 30 ) & 0x00000001;  }
			set {
				if( value > unknown_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield0 = ( this.__bitfield0 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 gender_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 houbokuchuu_MAXVALUE = 0x0000000f; // 15
		public UInt32 houbokuchuu {
			get { return ( this.__bitfield1 >> 0 ) & 0x0000000f;  }
			set {
				if( value > houbokuchuu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield1 = ( this.__bitfield1 & 0xfffffff0 ) | ( value << 0 );
			}
		}
		public const UInt32 unknown_5_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_5 {
			get { return ( this.__bitfield1 >> 4 ) & 0x00000003;  }
			set {
				if( value > unknown_5_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffcf ) | ( value << 4 );
			}
		}
		public const UInt32 kansen_MAXVALUE = 0x00000001; // 1
		public UInt32 kansen {
			get { return ( this.__bitfield1 >> 6 ) & 0x00000001;  }
			set {
				if( value > kansen_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffffbf ) | ( value << 6 );
			}
		}
		public const UInt32 weight_best_MAXVALUE = 0x0000007f; // 127
		public UInt32 weight_best {
			get { return ( this.__bitfield1 >> 7 ) & 0x0000007f;  }
			set {
				if( value > weight_best_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffffc07f ) | ( value << 7 );
			}
		}
		public const UInt32 weight_now_MAXVALUE = 0x0000007f; // 127
		public UInt32 weight_now {
			get { return ( this.__bitfield1 >> 14 ) & 0x0000007f;  }
			set {
				if( value > weight_now_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xffe03fff ) | ( value << 14 );
			}
		}
		public const UInt32 zyumyou_MAXVALUE = 0x0000007f; // 127
		public UInt32 zyumyou {
			get { return ( this.__bitfield1 >> 21 ) & 0x0000007f;  }
			set {
				if( value > zyumyou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield1 = ( this.__bitfield1 & 0xf01fffff ) | ( value << 21 );
			}
		}
		public const UInt32 age_MAXVALUE = 0x00000007; // 7
		public UInt32 age {
			get { return ( this.__bitfield1 >> 28 ) & 0x00000007;  }
			set {
				if( value > age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield1 = ( this.__bitfield1 & 0x8fffffff ) | ( value << 28 );
			}
		}
		public const UInt32 unknown_6_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_6 {
			get { return ( this.__bitfield1 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_6_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield1 = ( this.__bitfield1 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 8 byte data
		[FieldOffset(8)] private UInt32 __bitfield2;
		public const UInt32 seichou_MAXVALUE = 0x0000007f; // 127
		public UInt32 seichou {
			get { return ( this.__bitfield2 >> 0 ) & 0x0000007f;  }
			set {
				if( value > seichou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffff80 ) | ( value << 0 );
			}
		}
		public const UInt32 keikenchi_MAXVALUE = 0x0000007f; // 127
		public UInt32 keikenchi {
			get { return ( this.__bitfield2 >> 7 ) & 0x0000007f;  }
			set {
				if( value > keikenchi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffffc07f ) | ( value << 7 );
			}
		}
		public const UInt32 race_kan_MAXVALUE = 0x0000007f; // 127
		public UInt32 race_kan {
			get { return ( this.__bitfield2 >> 14 ) & 0x0000007f;  }
			set {
				if( value > race_kan_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield2 = ( this.__bitfield2 & 0xffe03fff ) | ( value << 14 );
			}
		}
		public const UInt32 choushi_MAXVALUE = 0x0000003f; // 63
		public UInt32 choushi {
			get { return ( this.__bitfield2 >> 21 ) & 0x0000003f;  }
			set {
				if( value > choushi_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield2 = ( this.__bitfield2 & 0xf81fffff ) | ( value << 21 );
			}
		}
		public const UInt32 klass_MAXVALUE = 0x00000007; // 7
		public UInt32 klass {
			get { return ( this.__bitfield2 >> 27 ) & 0x00000007;  }
			set {
				if( value > klass_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield2 = ( this.__bitfield2 & 0xc7ffffff ) | ( value << 27 );
			}
		}
		public const UInt32 unknonw_7_MAXVALUE = 0x00000003; // 3
		public UInt32 unknonw_7 {
			get { return ( this.__bitfield2 >> 30 ) & 0x00000003;  }
			set {
				if( value > unknonw_7_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield2 = ( this.__bitfield2 & 0x3fffffff ) | ( value << 30 );
			}
		}
		// 12 byte data
		[FieldOffset(12)] private UInt32 __bitfield3;
		public const UInt32 hirou_MAXVALUE = 0x0000007f; // 127
		public UInt32 hirou {
			get { return ( this.__bitfield3 >> 0 ) & 0x0000007f;  }
			set {
				if( value > hirou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-127)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffff80 ) | ( value << 0 );
			}
		}
		public const UInt32 houboku_len_MAXVALUE = 0x0000003f; // 63
		public UInt32 houboku_len {
			get { return ( this.__bitfield3 >> 7 ) & 0x0000003f;  }
			set {
				if( value > houboku_len_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield3 = ( this.__bitfield3 & 0xffffe07f ) | ( value << 7 );
			}
		}
		public const UInt32 father_num_MAXVALUE = 0x000007ff; // 2047
		public UInt32 father_num {
			get { return ( this.__bitfield3 >> 13 ) & 0x000007ff;  }
			set {
				if( value > father_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-2047)");
				this.__bitfield3 = ( this.__bitfield3 & 0xff001fff ) | ( value << 13 );
			}
		}
		public const UInt32 unknown_8_MAXVALUE = 0x000000ff; // 255
		public UInt32 unknown_8 {
			get { return ( this.__bitfield3 >> 24 ) & 0x000000ff;  }
			set {
				if( value > unknown_8_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield3 = ( this.__bitfield3 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 16 byte data
		[FieldOffset(16)] private UInt32 __bitfield4;
		public const UInt32 unknown_9_MAXVALUE = 0x00000003; // 3
		public UInt32 unknown_9 {
			get { return ( this.__bitfield4 >> 0 ) & 0x00000003;  }
			set {
				if( value > unknown_9_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffffffc ) | ( value << 0 );
			}
		}
		public const UInt32 intai_MAXVALUE = 0x00000001; // 1
		public UInt32 intai {
			get { return ( this.__bitfield4 >> 2 ) & 0x00000001;  }
			set {
				if( value > intai_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffffffb ) | ( value << 2 );
			}
		}
		public const UInt32 unknown_10_MAXVALUE = 0x000001ff; // 511
		public UInt32 unknown_10 {
			get { return ( this.__bitfield4 >> 3 ) & 0x000001ff;  }
			set {
				if( value > unknown_10_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffff007 ) | ( value << 3 );
			}
		}
		public const UInt32 souhou_MAXVALUE = 0x00000003; // 3
		public UInt32 souhou {
			get { return ( this.__bitfield4 >> 12 ) & 0x00000003;  }
			set {
				if( value > souhou_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffffcfff ) | ( value << 12 );
			}
		}
		public const UInt32 weak_point_1_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_1 {
			get { return ( this.__bitfield4 >> 14 ) & 0x00000003;  }
			set {
				if( value > weak_point_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xffff3fff ) | ( value << 14 );
			}
		}
		public const UInt32 weak_point_2_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_2 {
			get { return ( this.__bitfield4 >> 16 ) & 0x00000003;  }
			set {
				if( value > weak_point_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfffcffff ) | ( value << 16 );
			}
		}
		public const UInt32 weak_point_3_MAXVALUE = 0x00000003; // 3
		public UInt32 weak_point_3 {
			get { return ( this.__bitfield4 >> 18 ) & 0x00000003;  }
			set {
				if( value > weak_point_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield4 = ( this.__bitfield4 & 0xfff3ffff ) | ( value << 18 );
			}
		}
		public const UInt32 breeder_MAXVALUE = 0x000000ff; // 255
		public UInt32 breeder {
			get { return ( this.__bitfield4 >> 20 ) & 0x000000ff;  }
			set {
				if( value > breeder_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield4 = ( this.__bitfield4 & 0xf00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 seigen_MAXVALUE = 0x0000000f; // 15
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
		public const UInt32 price_MAXVALUE = 0x00003fff; // 16383
		public UInt32 price {
			get { return ( this.__bitfield5 >> 0 ) & 0x00003fff;  }
			set {
				if( value > price_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-16383)");
				this.__bitfield5 = ( this.__bitfield5 & 0xffffc000 ) | ( value << 0 );
			}
		}
		public const UInt32 abl_num_MAXVALUE = 0x00007fff; // 32767
		public UInt32 abl_num {
			get { return ( this.__bitfield5 >> 14 ) & 0x00007fff;  }
			set {
				if( value > abl_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-32767)");
				this.__bitfield5 = ( this.__bitfield5 & 0xe0003fff ) | ( value << 14 );
			}
		}
		public const UInt32 torihiki_MAXVALUE = 0x00000007; // 7
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
		public const UInt32 earning_hon_MAXVALUE = 0x000fffff; // 1048575
		public UInt32 earning_hon {
			get { return ( this.__bitfield6 >> 0 ) & 0x000fffff;  }
			set {
				if( value > earning_hon_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield6 = ( this.__bitfield6 & 0xfff00000 ) | ( value << 0 );
			}
		}
		public const UInt32 owner_MAXVALUE = 0x00000fff; // 4095
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
		public const UInt32 earning_all_MAXVALUE = 0x000fffff; // 1048575
		public UInt32 earning_all {
			get { return ( this.__bitfield7 >> 0 ) & 0x000fffff;  }
			set {
				if( value > earning_all_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1048575)");
				this.__bitfield7 = ( this.__bitfield7 & 0xfff00000 ) | ( value << 0 );
			}
		}
		public const UInt32 trainer_MAXVALUE = 0x000001ff; // 511
		public UInt32 trainer {
			get { return ( this.__bitfield7 >> 20 ) & 0x000001ff;  }
			set {
				if( value > trainer_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-511)");
				this.__bitfield7 = ( this.__bitfield7 & 0xe00fffff ) | ( value << 20 );
			}
		}
		public const UInt32 unknown_11_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_11 {
			get { return ( this.__bitfield7 >> 29 ) & 0x00000001;  }
			set {
				if( value > unknown_11_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0xdfffffff ) | ( value << 29 );
			}
		}
		public const UInt32 nyuukyuu_MAXVALUE = 0x00000001; // 1
		public UInt32 nyuukyuu {
			get { return ( this.__bitfield7 >> 30 ) & 0x00000001;  }
			set {
				if( value > nyuukyuu_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 unknown_12_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_12 {
			get { return ( this.__bitfield7 >> 31 ) & 0x00000001;  }
			set {
				if( value > unknown_12_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield7 = ( this.__bitfield7 & 0x7fffffff ) | ( value << 31 );
			}
		}
		// 32 byte data
		[FieldOffset(32)] private UInt32 __bitfield8;
		public const UInt32 sizitsu_num_MAXVALUE = 0x00001fff; // 8191
		public UInt32 sizitsu_num {
			get { return ( this.__bitfield8 >> 0 ) & 0x00001fff;  }
			set {
				if( value > sizitsu_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield8 = ( this.__bitfield8 & 0xffffe000 ) | ( value << 0 );
			}
		}
		public const UInt32 unknown_13_MAXVALUE = 0x00001fff; // 8191
		public UInt32 unknown_13 {
			get { return ( this.__bitfield8 >> 13 ) & 0x00001fff;  }
			set {
				if( value > unknown_13_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-8191)");
				this.__bitfield8 = ( this.__bitfield8 & 0xfc001fff ) | ( value << 13 );
			}
		}
		public const UInt32 ensei_MAXVALUE = 0x00000007; // 7
		public UInt32 ensei {
			get { return ( this.__bitfield8 >> 26 ) & 0x00000007;  }
			set {
				if( value > ensei_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield8 = ( this.__bitfield8 & 0xe3ffffff ) | ( value << 26 );
			}
		}
		public const UInt32 unknown_14_MAXVALUE = 0x00000001; // 1
		public UInt32 unknown_14 {
			get { return ( this.__bitfield8 >> 29 ) & 0x00000001;  }
			set {
				if( value > unknown_14_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield8 = ( this.__bitfield8 & 0xdfffffff ) | ( value << 29 );
			}
		}
		public const UInt32 migimawari_X_MAXVALUE = 0x00000001; // 1
		public UInt32 migimawari_X {
			get { return ( this.__bitfield8 >> 30 ) & 0x00000001;  }
			set {
				if( value > migimawari_X_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield8 = ( this.__bitfield8 & 0xbfffffff ) | ( value << 30 );
			}
		}
		public const UInt32 senba_MAXVALUE = 0x00000001; // 1
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
		public const UInt32 unknown_15_MAXVALUE = 0xffffffff; // 4294967295
		public UInt32 unknown_15 {
			get { return ( this.__bitfield9 >> 0 ) & 0xffffffff;  }
			set {
				if( value > unknown_15_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-4294967295)");
				this.__bitfield9 = ( this.__bitfield9 & 0x00000000 ) | ( value << 0 );
			}
		}
		// 40 byte data
		[FieldOffset(40)] private UInt32 __bitfield10;
		public const UInt32 name_left_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 name_left {
			get { return ( this.__bitfield10 >> 0 ) & 0x0000ffff;  }
			set {
				if( value > name_left_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield10 = ( this.__bitfield10 & 0xffff0000 ) | ( value << 0 );
			}
		}
		public const UInt32 name_right_MAXVALUE = 0x0000ffff; // 65535
		public UInt32 name_right {
			get { return ( this.__bitfield10 >> 16 ) & 0x0000ffff;  }
			set {
				if( value > name_right_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-65535)");
				this.__bitfield10 = ( this.__bitfield10 & 0x0000ffff ) | ( value << 16 );
			}
		}
		// 44 byte data
		[FieldOffset(44)] private UInt32 __bitfield11;
		public const UInt32 race_next_age_MAXVALUE = 0x00000007; // 7
		public UInt32 race_next_age {
			get { return ( this.__bitfield11 >> 0 ) & 0x00000007;  }
			set {
				if( value > race_next_age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfffffff8 ) | ( value << 0 );
			}
		}
		public const UInt32 rase_next_location_MAXVALUE = 0x00000003; // 3
		public UInt32 rase_next_location {
			get { return ( this.__bitfield11 >> 3 ) & 0x00000003;  }
			set {
				if( value > rase_next_location_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield11 = ( this.__bitfield11 & 0xffffffe7 ) | ( value << 3 );
			}
		}
		public const UInt32 rase_next_sunday_MAXVALUE = 0x00000001; // 1
		public UInt32 rase_next_sunday {
			get { return ( this.__bitfield11 >> 5 ) & 0x00000001;  }
			set {
				if( value > rase_next_sunday_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield11 = ( this.__bitfield11 & 0xffffffdf ) | ( value << 5 );
			}
		}
		public const UInt32 rase_next_num_MAXVALUE = 0x0000000f; // 15
		public UInt32 rase_next_num {
			get { return ( this.__bitfield11 >> 6 ) & 0x0000000f;  }
			set {
				if( value > rase_next_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfffffc3f ) | ( value << 6 );
			}
		}
		public const UInt32 rase_next_week_MAXVALUE = 0x0000003f; // 63
		public UInt32 rase_next_week {
			get { return ( this.__bitfield11 >> 10 ) & 0x0000003f;  }
			set {
				if( value > rase_next_week_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield11 = ( this.__bitfield11 & 0xffff03ff ) | ( value << 10 );
			}
		}
		public const UInt32 race_last_age_MAXVALUE = 0x00000007; // 7
		public UInt32 race_last_age {
			get { return ( this.__bitfield11 >> 16 ) & 0x00000007;  }
			set {
				if( value > race_last_age_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-7)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfff8ffff ) | ( value << 16 );
			}
		}
		public const UInt32 rase_last_location_MAXVALUE = 0x00000003; // 3
		public UInt32 rase_last_location {
			get { return ( this.__bitfield11 >> 19 ) & 0x00000003;  }
			set {
				if( value > rase_last_location_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-3)");
				this.__bitfield11 = ( this.__bitfield11 & 0xffe7ffff ) | ( value << 19 );
			}
		}
		public const UInt32 rase_last_sunday_MAXVALUE = 0x00000001; // 1
		public UInt32 rase_last_sunday {
			get { return ( this.__bitfield11 >> 21 ) & 0x00000001;  }
			set {
				if( value > rase_last_sunday_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-1)");
				this.__bitfield11 = ( this.__bitfield11 & 0xffdfffff ) | ( value << 21 );
			}
		}
		public const UInt32 rase_last_num_MAXVALUE = 0x0000000f; // 15
		public UInt32 rase_last_num {
			get { return ( this.__bitfield11 >> 22 ) & 0x0000000f;  }
			set {
				if( value > rase_last_num_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-15)");
				this.__bitfield11 = ( this.__bitfield11 & 0xfc3fffff ) | ( value << 22 );
			}
		}
		public const UInt32 rase_last_week_MAXVALUE = 0x0000003f; // 63
		public UInt32 rase_last_week {
			get { return ( this.__bitfield11 >> 26 ) & 0x0000003f;  }
			set {
				if( value > rase_last_week_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-63)");
				this.__bitfield11 = ( this.__bitfield11 & 0x03ffffff ) | ( value << 26 );
			}
		}
		// 48 byte data
		[FieldOffset(48)] private UInt32 __bitfield12;
		public const UInt32 career_shiba_1_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_shiba_1 {
			get { return ( this.__bitfield12 >> 0 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield12 = ( this.__bitfield12 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 career_shiba_2_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_shiba_2 {
			get { return ( this.__bitfield12 >> 8 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield12 = ( this.__bitfield12 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 career_shiba_3_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_shiba_3 {
			get { return ( this.__bitfield12 >> 16 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield12 = ( this.__bitfield12 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 career_shiba_4_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_shiba_4 {
			get { return ( this.__bitfield12 >> 24 ) & 0x000000ff;  }
			set {
				if( value > career_shiba_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield12 = ( this.__bitfield12 & 0x00ffffff ) | ( value << 24 );
			}
		}
		// 52 byte data
		[FieldOffset(52)] private UInt32 __bitfield13;
		public const UInt32 career_dirt_1_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_dirt_1 {
			get { return ( this.__bitfield13 >> 0 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_1_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffffff00 ) | ( value << 0 );
			}
		}
		public const UInt32 career_dirt_2_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_dirt_2 {
			get { return ( this.__bitfield13 >> 8 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_2_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield13 = ( this.__bitfield13 & 0xffff00ff ) | ( value << 8 );
			}
		}
		public const UInt32 career_dirt_3_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_dirt_3 {
			get { return ( this.__bitfield13 >> 16 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_3_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield13 = ( this.__bitfield13 & 0xff00ffff ) | ( value << 16 );
			}
		}
		public const UInt32 career_dirt_4_MAXVALUE = 0x000000ff; // 255
		public UInt32 career_dirt_4 {
			get { return ( this.__bitfield13 >> 24 ) & 0x000000ff;  }
			set {
				if( value > career_dirt_4_MAXVALUE )
					throw new ArgumentException("最大値を超えてます(0-255)");
				this.__bitfield13 = ( this.__bitfield13 & 0x00ffffff ) | ( value << 24 );
			}
		}
		public UInt32[] Decode() {
			var data = new UInt32[14];
			data[0] = data[0] | ( this.mother_num << 0 ) ;
			data[0] = data[0] | ( this.maruchihou << 14 ) ;
			data[0] = data[0] | ( this.unknown_2 << 15 ) ;
			data[0] = data[0] | ( this.hidarimawari_X << 18 ) ;
			data[0] = data[0] | ( this.unknown_3 << 19 ) ;
			data[0] = data[0] | ( this.shusen_jk_num << 21 ) ;
			data[0] = data[0] | ( this.unknown_4 << 30 ) ;
			data[0] = data[0] | ( this.gender << 31 ) ;
			data[1] = data[1] | ( this.houbokuchuu << 0 ) ;
			data[1] = data[1] | ( this.unknown_5 << 4 ) ;
			data[1] = data[1] | ( this.kansen << 6 ) ;
			data[1] = data[1] | ( this.weight_best << 7 ) ;
			data[1] = data[1] | ( this.weight_now << 14 ) ;
			data[1] = data[1] | ( this.zyumyou << 21 ) ;
			data[1] = data[1] | ( this.age << 28 ) ;
			data[1] = data[1] | ( this.unknown_6 << 31 ) ;
			data[2] = data[2] | ( this.seichou << 0 ) ;
			data[2] = data[2] | ( this.keikenchi << 7 ) ;
			data[2] = data[2] | ( this.race_kan << 14 ) ;
			data[2] = data[2] | ( this.choushi << 21 ) ;
			data[2] = data[2] | ( this.klass << 27 ) ;
			data[2] = data[2] | ( this.unknonw_7 << 30 ) ;
			data[3] = data[3] | ( this.hirou << 0 ) ;
			data[3] = data[3] | ( this.houboku_len << 7 ) ;
			data[3] = data[3] | ( this.father_num << 13 ) ;
			data[3] = data[3] | ( this.unknown_8 << 24 ) ;
			data[4] = data[4] | ( this.unknown_9 << 0 ) ;
			data[4] = data[4] | ( this.intai << 2 ) ;
			data[4] = data[4] | ( this.unknown_10 << 3 ) ;
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
			data[7] = data[7] | ( this.unknown_11 << 29 ) ;
			data[7] = data[7] | ( this.nyuukyuu << 30 ) ;
			data[7] = data[7] | ( this.unknown_12 << 31 ) ;
			data[8] = data[8] | ( this.sizitsu_num << 0 ) ;
			data[8] = data[8] | ( this.unknown_13 << 13 ) ;
			data[8] = data[8] | ( this.ensei << 26 ) ;
			data[8] = data[8] | ( this.unknown_14 << 29 ) ;
			data[8] = data[8] | ( this.migimawari_X << 30 ) ;
			data[8] = data[8] | ( this.senba << 31 ) ;
			data[9] = data[9] | ( this.unknown_15 << 0 ) ;
			data[10] = data[10] | ( this.name_left << 0 ) ;
			data[10] = data[10] | ( this.name_right << 16 ) ;
			data[11] = data[11] | ( this.race_next_age << 0 ) ;
			data[11] = data[11] | ( this.rase_next_location << 3 ) ;
			data[11] = data[11] | ( this.rase_next_sunday << 5 ) ;
			data[11] = data[11] | ( this.rase_next_num << 6 ) ;
			data[11] = data[11] | ( this.rase_next_week << 10 ) ;
			data[11] = data[11] | ( this.race_last_age << 16 ) ;
			data[11] = data[11] | ( this.rase_last_location << 19 ) ;
			data[11] = data[11] | ( this.rase_last_sunday << 21 ) ;
			data[11] = data[11] | ( this.rase_last_num << 22 ) ;
			data[11] = data[11] | ( this.rase_last_week << 26 ) ;
			data[12] = data[12] | ( this.career_shiba_1 << 0 ) ;
			data[12] = data[12] | ( this.career_shiba_2 << 8 ) ;
			data[12] = data[12] | ( this.career_shiba_3 << 16 ) ;
			data[12] = data[12] | ( this.career_shiba_4 << 24 ) ;
			data[13] = data[13] | ( this.career_dirt_1 << 0 ) ;
			data[13] = data[13] | ( this.career_dirt_2 << 8 ) ;
			data[13] = data[13] | ( this.career_dirt_3 << 16 ) ;
			data[13] = data[13] | ( this.career_dirt_4 << 24 ) ;
			return data;
		}
		public UInt32[] ToArray(){
			return this.Decode();
		}
		public static explicit operator UInt32[]( HRaceData obj ){
			return obj.ToArray();
		}
		public void Encode( UInt32[] data ) {
			if( data.Length != 14 )
				throw new ArgumentException(String.Format("期待するサイズと異なるサイズの配列です({0} for 14)",data.Length));
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
		}
		public const UInt32 __SIZE__ = sizeof(UInt32) * 14;
	}
 }
