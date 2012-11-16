using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace UMAListView
{
	partial class MainForm
	{
		private enum Country : int
		{
			JAPAN = 1,
			USA,
			EURO,
			UNKNOWN,
		}

		private void CreateHorseList()
		{
			var config = new KOEI.WP7.M2008.Configuration.V101();

			using( var wp = new KOEI.WP7.M2008.WP7( config.ProcessName, config ) )
			{
				this.listView1.Items.Clear();

				var type = HorseType.UNKNOWN;

				foreach( var o in this.groupBox5.Controls ) {
					var radio = o as RadioButton;
					if( radio.Checked ) {
						type = (HorseType)radio.Tag;
					}
				}

				ListViewItem[] items = null;

				switch( type ) {
				case HorseType.CHILD:
					items = this.CreateChildHorseList( wp );
					break;

				case HorseType.RACE:
					items = this.CreateRaceHorseList( wp );
					break;

				case HorseType.DAM:
					return;

				case HorseType.SIRE:
					return;

				default:
					MessageBox.Show("[BUG]");
					return;
				}

				this.listView1.Items.AddRange( items );
				this.listView1_Sorter.Column = 0;
				this.listView1_Sorter.Order = SortOrder.Ascending;
				this.listView1.Sort();
				this.listView1_OddColor();
			}
		}

		private ListViewItem[] CreateChildHorseList( KOEI.WP7.M2008.WP7 wp )
		{
			// .NET Frameworkの構造体は値渡しなのでサイズの大きな構造体を扱うときは
			// 上手く扱わないとオーバーヘッドが大きくなる
			// ここではスタックと参照を使って高速化を図る
			var data = new KOEI.WP7.M2008.Datastruct.HChildData();
			var abl_data = new KOEI.WP7.M2008.Datastruct.HAblData();
			var father_data = new KOEI.WP7.M2008.Datastruct.HSireData();
			var mother_data = new KOEI.WP7.M2008.Datastruct.HDamData();
			var father_blood_data = new KOEI.WP7.M2008.Datastruct.HBloodData();
			var mother_blood_data = new KOEI.WP7.M2008.Datastruct.HBloodData();
			var father_family_line_data = new KOEI.WP7.M2008.Datastruct.HFamilyLineData();

			var items = new List< ListViewItem >();

			for( var i=0; i<wp.Config.HorseChildTable.RecordMaxLength; ++i )
			{
				wp.HChildTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HChildData >( i, ref data );

				if( data.abl_num == wp.Config.NullAbilityNumber ) { 
					continue;
				}

				switch( data.age )
				{
				case 0:
					if( !this.checkBox1.Checked )
						continue;
					break;
				case 1:
					if( !this.checkBox2.Checked )
						continue;
					break;
				default:
					throw new Exception("[BUG]");
				}		

				if( checkBox11.Checked || checkBox12.Checked || checkBox13.Checked ) {
					switch( data.owner )
					{
					case 41:
						if( !checkBox11.Checked )
							continue;
						break;
					case 42:
						if( !checkBox12.Checked )
							continue;
						break;
					default:
						continue;
					}
				}

				wp.HAblTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HAblData >( data.abl_num, ref abl_data );

				var country = Country.UNKNOWN;

				if( abl_data.bokuzyou < 214 && abl_data.bokuzyou != 27 && abl_data.bokuzyou != 28 ) {
					country = Country.JAPAN;
				} else if( abl_data.bokuzyou < 233 && abl_data.bokuzyou != 28 ) {
					country = Country.USA;
				} else {
					country = Country.EURO;
				}

				switch( country )
				{
				case Country.JAPAN:
					if( !checkBox6.Checked )
						continue;
					break;
				case Country.USA:
					if( !checkBox7.Checked )
						continue;
					break;
				case Country.EURO:
					if( !checkBox8.Checked )
						continue;
					break;
				default:
					throw new Exception("[BUG]");
				}

				wp.HSireTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HSireData >( data.father_num, ref father_data );
				wp.HDamTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HDamData >( data.mother_num, ref mother_data );
				wp.HBloodTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HBloodData >( father_data.blood_num, ref father_blood_data );
				wp.HBloodTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HBloodData >( mother_data.blood_num, ref mother_blood_data );
				wp.HFamilyLineTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HFamilyLineData >( father_blood_data.family_line_num, ref father_family_line_data );

				var father_name = wp.馬名( father_blood_data.name_left, father_blood_data.name_right );
				var mother_name = wp.馬名( mother_blood_data.name_left, mother_blood_data.name_right );

				var name = String.Format( "{0}の{1}歳", mother_name, data.age );
				var age_value = data.age;
				var seichou_value = 0;
				var horse_num = i;
				var subpara_total = abl_data.power + abl_data.syunpatsu + abl_data.konzyou + abl_data.zyuunan + abl_data.seishin + abl_data.kashikosa + abl_data.health;

				var item = new ListViewItem();

				item.Text = name;
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = age_value.ToString(),
					Tag = (int)age_value,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.gender.性別(),
					Tag = (int)data.gender,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.speed.ToString(),
					Tag = (int)abl_data.speed,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.stamina.ToString(),
					Tag = (int)abl_data.stamina,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.power.サブパラ(),
					Tag = (int)abl_data.power,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.syunpatsu.サブパラ(),
					Tag = (int)abl_data.syunpatsu,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.konzyou.サブパラ(),
					Tag = (int)abl_data.konzyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.zyuunan.サブパラ(),
					Tag = (int)abl_data.zyuunan,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seishin.サブパラ(),
					Tag = (int)abl_data.seishin,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kashikosa.サブパラ(),
					Tag = (int)abl_data.kashikosa,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.health.サブパラ(),
					Tag = (int)abl_data.health,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = subpara_total.ToString(),
					Tag = subpara_total,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.babatekisei.馬場適正().Substring(0,1),
					Tag = (int)abl_data.babatekisei,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seichougata.成長型(),
					Tag = (int)abl_data.seichougata,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seichouryoku.成長力(),
					Tag = (int)abl_data.seichouryoku,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = seichou_value.ToString(),
					Tag = (int)seichou_value,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = ( 100 + data.seigen ).ToString(),
					Tag = (int)data.seigen,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.zyumyou.ToString(),
					Tag = (int)data.zyumyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kodashi.ToString(),
					Tag = (int)abl_data.kodashi,
				});			
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kisyou.気性().Substring(0,1),
					Tag = (int)abl_data.kisyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.keiro.毛色(),
					Tag = (int)abl_data.keiro,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.komawari_X.苦手(),
					Tag = (int)abl_data.komawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.hidarimawari_X.苦手(),
					Tag = (int)data.hidarimawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.migimawari_X.苦手(),
					Tag = (int)data.migimawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_1.持病(),
					Tag = (int)data.weak_point_1,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_2.持病(),
					Tag = (int)data.weak_point_2,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_3.持病(),
					Tag = (int)data.weak_point_3,
				});

				item.SubItems.Add( father_name );
				item.SubItems.Add( father_family_line_data.系統名() + "系" );
				item.SubItems.Add( mother_name );

				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = "",
					Tag = (int)0,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "0x{0:X4}", data.abl_num ),
					Tag = (int)data.abl_num,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "0x{0:X4}", horse_num ),
					Tag = horse_num,
				});
				items.Add( item );
			}

			return items.ToArray();
		}	

		private ListViewItem[] CreateRaceHorseList( KOEI.WP7.M2008.WP7 wp )
		{
			// .NET Frameworkの構造体は値渡しなのでサイズの大きな構造体を扱うときは
			// 上手く扱わないとオーバーヘッドが大きくなる
			// ここではスタックと参照を使って高速化を図る
			var data = new KOEI.WP7.M2008.Datastruct.HRaceData();
			var abl_data = new KOEI.WP7.M2008.Datastruct.HAblData();
			var father_data = new KOEI.WP7.M2008.Datastruct.HSireData();
			var mother_data = new KOEI.WP7.M2008.Datastruct.HDamData();
			var father_blood_data = new KOEI.WP7.M2008.Datastruct.HBloodData();
			var mother_blood_data = new KOEI.WP7.M2008.Datastruct.HBloodData();
			var father_family_line_data = new KOEI.WP7.M2008.Datastruct.HFamilyLineData();

			var items = new List< ListViewItem >();

			for( var i=0; i<  wp.Config.HorseRaceTable.RecordMaxLength; ++i )
			{
				wp.HRaceTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HRaceData >( i, ref data );

				switch( data.age + 2 ) {
				case 2:
					if( !checkBox3.Checked )
						continue;
					break;
				case 3:
					if( !checkBox4.Checked )
						continue;
					break;
				default:
					if( !checkBox5.Checked )
						continue;
					break;
				}

				switch( i <= 0xb3f ? Country.JAPAN : i <= 0xe4b ? Country.USA : Country.EURO ) {
				case Country.JAPAN:
					if( !checkBox6.Checked )
						continue;
					break;
				case Country.USA:
					if( !checkBox7.Checked )
						continue;
					break;
				case Country.EURO:
					if( !checkBox8.Checked )
						continue;
					break;
				}

				switch( data.intai ) {
				case 0:
					if( !checkBox9.Checked ) 
						continue;
					break;
				default:
					if( !checkBox10.Checked ) 
						continue;
					break;
				}

				if( checkBox11.Checked || checkBox12.Checked || checkBox13.Checked ) {
					switch( data.owner )
					{
					case 41:
						if( !checkBox11.Checked )
							continue;
						break;
					case 42:
						if( !checkBox12.Checked )
							continue;
						break;
					default:
						continue;
					}
				}

				var item = new ListViewItem();

				wp.HAblTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HAblData >( data.abl_num, ref abl_data );

				wp.HSireTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HSireData >( data.father_num, ref father_data );
				wp.HDamTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HDamData >( data.mother_num, ref mother_data );
				wp.HBloodTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HBloodData >( father_data.blood_num, ref father_blood_data );
				wp.HBloodTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HBloodData >( mother_data.blood_num, ref mother_blood_data );
				wp.HFamilyLineTable.GetDatastruct< KOEI.WP7.M2008.Datastruct.HFamilyLineData >( father_blood_data.family_line_num, ref father_family_line_data );
			
				var name = wp.馬名( data.name_left, data.name_right );
				var father_name = wp.馬名( father_blood_data.name_left, father_blood_data.name_right );
				var mother_name = wp.馬名( mother_blood_data.name_left, mother_blood_data.name_right );
				var age_value = data.age + 2;
				var subpara_total = abl_data.power + abl_data.syunpatsu + abl_data.konzyou + abl_data.zyuunan + abl_data.seishin + abl_data.kashikosa + abl_data.health;

				item.Text = name;
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = age_value.ToString(),
					Tag = (int)age_value,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.gender.性別(),
					Tag = (int)data.gender,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.speed.ToString(),
					Tag = (int)abl_data.speed,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.stamina.ToString(),
					Tag = (int)abl_data.stamina,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.power.サブパラ(),
					Tag = (int)abl_data.power,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.syunpatsu.サブパラ(),
					Tag = (int)abl_data.syunpatsu,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.konzyou.サブパラ(),
					Tag = (int)abl_data.konzyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.zyuunan.サブパラ(),
					Tag = (int)abl_data.zyuunan,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seishin.サブパラ(),
					Tag = (int)abl_data.seishin,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kashikosa.サブパラ(),
					Tag = (int)abl_data.kashikosa,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.health.サブパラ(),
					Tag = (int)abl_data.health,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = subpara_total.ToString(),
					Tag = subpara_total,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.babatekisei.馬場適正().Substring(0,1),
					Tag = (int)abl_data.babatekisei,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seichougata.成長型(),
					Tag = (int)abl_data.seichougata,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.seichouryoku.成長力(),
					Tag = (int)abl_data.seichouryoku,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.seichou.ToString(),
					Tag = (int)data.seichou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = ( 100 + data.seigen ).ToString(),
					Tag = (int)data.seigen,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.zyumyou.ToString(),
					Tag = (int)data.zyumyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kodashi.ToString(),
					Tag = (int)abl_data.kodashi,
				});			
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.kisyou.気性().Substring(0,1),
					Tag = (int)abl_data.kisyou,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.keiro.毛色(),
					Tag = (int)abl_data.keiro,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = abl_data.komawari_X.苦手(),
					Tag = (int)abl_data.komawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.hidarimawari_X.苦手(),
					Tag = (int)data.hidarimawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.migimawari_X.苦手(),
					Tag = (int)data.migimawari_X,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_1.持病(),
					Tag = (int)data.weak_point_1,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_2.持病(),
					Tag = (int)data.weak_point_2,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.weak_point_3.持病(),
					Tag = (int)data.weak_point_3,
				});

				item.SubItems.Add( father_name );
				item.SubItems.Add( father_family_line_data.系統名() + "系" );
				item.SubItems.Add( mother_name );

				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = data.sizitsu_num != 6500 ? "○" : "",
					Tag = data.sizitsu_num != 6500 ? 1 : 0,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "0x{0:X4}", data.abl_num ),
					Tag = (int)data.abl_num,
				});
				item.SubItems.Add( new ListViewItem.ListViewSubItem() {
					Text = String.Format( "0x{0:X4}", i ),
					Tag = i,
				});

				items.Add( item );
			}

			return items.ToArray();
		}

		private void listView1_ExecSort( int n )
		{
			this.listView1_Sorter.Column = n;
			this.listView1.Sort();
		}


	}
}
