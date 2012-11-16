using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

namespace UMAListView
{
	public partial class MainForm : Form
	{
		private ListViewItemComparer listView1_Sorter;

		private enum HorseType {
			CHILD,
			RACE,
			DAM,
			SIRE,
			UNKNOWN,
		}

		public MainForm()
		{
			this.InitializeComponent();
			this.ControlsSetup();
		}

		private void ControlsSetup()
		{
			this.listView1_Setup();

			foreach( var _column in this.listView1.Columns )
			{
				var column = (_column as ColumnHeader);
				var text = column.Text;
				var button = new ToolStripMenuItem() {
					Text = text,
					Checked = true,
					Tag = column.Name,
				};

				button.Click += ( obj, e )=> {
					var b = ( obj as ToolStripMenuItem );
					var c = this.listView1.Columns[ (String)b.Tag ];
					if( b.Checked ) {
						c.Width = 0;
						b.Checked = false;
					} else {
						c.Width = (int)c.Tag;
						b.Checked = true;
					}				
				};
				contextMenuStrip1.Items.Add( button );
				column.Tag = column.Width;
			}

			this.radioButton1.Tag = HorseType.CHILD;
			this.radioButton2.Tag = HorseType.RACE;
			this.radioButton3.Tag = HorseType.DAM;
			this.radioButton4.Tag = HorseType.SIRE;

			this.checkBox1.Checked = true;
			this.checkBox2.Checked = true;
			this.checkBox3.Checked = true;
			this.checkBox4.Checked = true;
			this.checkBox5.Checked = true;

			this.checkBox6.Checked = true;
			this.checkBox7.Checked = true;
			this.checkBox8.Checked = true;

			this.checkBox9.Checked = true;
			this.checkBox10.Checked = true;

			this.radioButton2.Checked = true;

			this.toolStripStatusLabel1.Text = "";
			this.toolStripStatusLabel2.Text = "";
			this.toolStripStatusLabel3.Text = "";

			this.timer1.Tick += ( obj, e )=> {
				Invoke( (MethodInvoker)delegate {
					this.toolStripStatusLabel1.Text =
						String.Format( "{0:f2}(MB)", GC.GetTotalMemory( false ) / 1024.0 / 1024.0 );
				});
			};
			this.timer1.Interval = 1000;
			this.timer1.Start();
		}

		private void listView1_Setup()
		{
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "馬名",
				Name = "name",
				TextAlign = HorizontalAlignment.Left,
				Width = 200,
				Tag = ListViewItemComparer.ComparerMode.STRING,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "年",
				Name = "age",
				TextAlign = HorizontalAlignment.Right,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "性",
				Name = "gender",
				TextAlign = HorizontalAlignment.Right,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "SP",
				Name = "speed",
				TextAlign = HorizontalAlignment.Right,
				Width = 60,			
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "ST",
				Name = "stamina",
				TextAlign = HorizontalAlignment.Right,
				Width = 35,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "力",
				Name = "power",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "瞬",
				Name = "syunpatsu",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "勝",
				Name = "konzyou",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "柔",
				Name = "zyuunan",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "精",
				Name = "seishin",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "賢",
				Name = "kashikosa",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "健",
				Name = "health",
				TextAlign = HorizontalAlignment.Right,
				Width = 45,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "サ",
				Name = "subpara",
				TextAlign = HorizontalAlignment.Right,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "場",
				Name = "babatekisei",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "成型",
				Name = "seichougata",
				TextAlign = HorizontalAlignment.Left,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "成力",
				Name = "seichouryoku",
				TextAlign = HorizontalAlignment.Left,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "成度",
				Name = "seichou",
				TextAlign = HorizontalAlignment.Right,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "成限",
				Name = "seigen",
				TextAlign = HorizontalAlignment.Right,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "寿命",
				Name = "zyumyou",
				TextAlign = HorizontalAlignment.Right,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "子出",
				Name = "kodashi",
				TextAlign = HorizontalAlignment.Right,
				Width = 40,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "気",
				Name = "kisyou",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "毛色",
				Name = "keiro",
				TextAlign = HorizontalAlignment.Left,
				Width = 60,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "小",
				Name = "komawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "左",
				Name = "hidarimawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "右",
				Name = "migimawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "脚",
				Name = "migimawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "喉",
				Name = "migimawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "腰",
				Name = "migimawari_X",
				TextAlign = HorizontalAlignment.Left,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});

			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "父馬",
				Name = "father",
				TextAlign = HorizontalAlignment.Left,
				Width = 200,
				Tag = ListViewItemComparer.ComparerMode.STRING,
			});

			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "父系",
				Name = "family_line",
				TextAlign = HorizontalAlignment.Left,
				Width = 200,
				Tag = ListViewItemComparer.ComparerMode.STRING,
			});

			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "母馬",
				Name = "mother",
				TextAlign = HorizontalAlignment.Left,
				Width = 200,
				Tag = ListViewItemComparer.ComparerMode.STRING,
			});

			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "史",
				Name = "sizitsu_num",
				TextAlign = HorizontalAlignment.Right,
				Width = 30,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "能力番号",
				Name = "abl_num",
				TextAlign = HorizontalAlignment.Right,
				Width = 80,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});
			this.listView1.Columns.Add( new ColumnHeader() {
				Text = "馬番号",
				Name = "id",
				TextAlign = HorizontalAlignment.Right,
				Width = 80,
				Tag = ListViewItemComparer.ComparerMode.TAG_NUMERIC,
			});

			var list = new ListViewItemComparer.ComparerMode[ this.listView1.Columns.Count ];
			for( var i=0; i<list.Length; ++i ) {
				list[i] = (ListViewItemComparer.ComparerMode)this.listView1.Columns[i].Tag;
			}
			this.listView1_Sorter = new ListViewItemComparer() {
				ColumnModes = list,
			};
			this.listView1.ListViewItemSorter = this.listView1_Sorter;
		}


		private void button1_Click(object sender, EventArgs e)
		{
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

#if DEBUG
			this.CreateHorseList();
#else
			try {
				this.CreateHorseList();
			} catch( Exception ex ) {
				MessageBox.Show( "エラーが発生しました - " + ex.Message );
			}
#endif
			sw.Stop();

			this.toolStripStatusLabel2.Text = String.Format( "{0}(ms)", sw.ElapsedMilliseconds );
			this.toolStripStatusLabel3.Text = String.Format( "{0}(line)", this.listView1.Items.Count );

			GC.Collect();
		}

		private void listView1_OddColor()
		{
			for( var i=0; i<this.listView1.Items.Count; ++i ) {
				this.listView1.Items[i].BackColor = ( i % 2 == 1 )
					? System.Drawing.Color.FromArgb( 0xef, 0xef, 0xff )
					: System.Drawing.Color.White;
			}
		}

		private void listView1_ColumnClick( object sender, ColumnClickEventArgs e )
		{
			this.listView1_ExecSort( e.Column );
			this.listView1_OddColor();
		}

		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
		}
	}
}
