using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

using KOEI.WP7_2012;

namespace WP7_2012ULV
{
	public partial class MainForm : Form
	{
		private KOEI.WP7_2012.WP7 wp_ = null;

		private Setting.ProgramSetting setting_;
		private Setting.ExtensionSetting.Setting extension_setting_;
		private Setting.WPVersionConfig version_setting_;

		private UMAListView.UMAListViewTpl umaListView_;
		private UMAListView.Config umaListView_Config_;

		private Enums.HorseType currentHorseType_ = Enums.HorseType.UNKNOWN;

		private System.Collections.Generic.List< Breeding.BreedingForm >
			BreedingFormList = new System.Collections.Generic.List<WP7_2012ULV.Breeding.BreedingForm>();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			this.InitializeComponent();
			this.ControlsSetup();
			this.SettingSetup();
			this.MainMenuSetup();
			this.UpdateFormTitle();
		}

		/// <summary>
		/// 拡張機能ディレクトリパスを取得する
		/// </summary>
		private String ExtenstionsDir {
			get {
				return this.setting_.ExtensionDir;
			}
		}

		/// <summary>
		/// 不要なメモリをfreeする
		/// </summary>
		private void GC_Collect()
		{
			this.toolStripStatusLabel1.Text = "GC Collect";
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
		}

		/// <summary>
		/// フォームのコントロールをセットアップする
		/// </summary>
		private void ControlsSetup()
		{
			this.Text = Program.AssemblyName;

			this.Size = new Size( 1090, 600 );

			this.FormClosing += ( obj, e )=> {
				this.setting_.MainFormSetting = this.ToSetting();
				this.UpdateUMAListViewSetting();
				
				WP7_2012ULV.Setting.ProgramSetting.SaveToFile( this.setting_, Program.SettingFileName );
			};

			this.Shown += ( obj, e )=> {
				if( this.setting_.MainFormSetting != null ) {
					this.Location = new Point( this.setting_.MainFormSetting.Left, this.setting_.MainFormSetting.Top );
				}
				this.timer1.Tick += ( _obj, _e )=> {
					Invoke( (MethodInvoker)delegate {
						this.toolStripStatusLabel1.Text = String.Format( "{0:f2}(MB)", GC.GetTotalMemory( false ) / 1024.0 / 1024.0 );
					});
				};
				this.timer1.Interval = 1000;
				this.timer1.Start();
			};

			this.pictureBox1.Top = 3;
			this.pictureBox1.Left = this.tabControl1.TabCount * 90 + 5;

			this.tabControl1.SelectedIndexChanged += this.tabControl1_SelectedIndexChangedHandler;

			this.tabPage1.Tag = Enums.HorseType.RACE;
			this.tabPage2.Tag = Enums.HorseType.CHILD;
			this.tabPage3.Tag = Enums.HorseType.DAM;
			this.tabPage4.Tag = Enums.HorseType.SIRE;

			this.checkBox1.Checked = true;
			this.checkBox2.Checked = true;
			this.checkBox3.Checked = true;
			this.checkBox4.Checked = true;
			this.checkBox5.Checked = true;
			this.checkBox6.Checked = true;
			this.checkBox7.Checked = true;
			this.checkBox8.Checked = true;
			this.checkBox9.Checked = true;
			this.checkBox10.Checked = false;
			this.checkBox11.Checked = false;
			this.checkBox12.Checked = false;
			this.checkBox13.Checked = false;

			this.checkBox1.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Age_0 = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox2.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Age_1 = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox3.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Age_2 = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox4.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Age_3 = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox5.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Age_ETC = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox6.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Country_JAPAN = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox7.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Country_USA = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox8.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Country_EURO = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox9.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Status_Geneki = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox10.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.Status_Intai = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox11.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.OwnerHorse = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox12.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.ClubHorse = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox13.CheckedChanged += ( obj, e )=>{
				this.umaListView_Config_.SaleHorse = ((CheckBox)obj).Checked;
				this.checkBox1.Enabled = !this.checkBox13.Checked;
				this.checkBox2.Enabled = !this.checkBox13.Checked;
				this.checkBox6.Enabled = !this.checkBox13.Checked;
				this.checkBox7.Enabled = !this.checkBox13.Checked;
				this.checkBox8.Enabled = !this.checkBox13.Checked;
				this.checkBox11.Enabled = !this.checkBox13.Checked;
				this.checkBox12.Enabled = !this.checkBox13.Checked;
				this.DispHorseList();
			};
			this.checkBox14.CheckedChanged += (obj, e)=> {
				this.checkBox11.Enabled = !((CheckBox)obj).Checked;
				this.checkBox12.Enabled = !((CheckBox)obj).Checked;
				this.checkBox15.Enabled = !((CheckBox)obj).Checked;
				this.umaListView_Config_.WatchHorse = ((CheckBox)obj).Checked;
				this.DispHorseList();
			};
			this.checkBox15.CheckedChanged += (obj, e)=> {
				this.checkBox11.Enabled = !((CheckBox)obj).Checked;
				this.checkBox12.Enabled = !((CheckBox)obj).Checked;
				if( this.tabControl1.SelectedIndex == 0 ) {
					this.checkBox14.Enabled = !((CheckBox)obj).Checked;
				}
				this.umaListView_Config_.CurrentHorse = ((CheckBox)obj).Checked;
				try {
					this.DispHorseList();
				} catch( Exception ex ) {
					var message = String.Format( "エラーが発生しました - {0}", ex.Message );
					MessageBox.Show( message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error );
					this.umaListView_Config_.CurrentHorse = false;
					this.checkBox15.Checked = false;
				}
			};

			this.toolStripStatusLabel1.Text = "";
			this.toolStripStatusLabel2.Text = "";
			this.toolStripStatusLabel3.Text = "";
			this.toolStripStatusLabel4.Text = "";

			this.umaListView_Config_ = new UMAListView.Config() {
				Age_0         = this.checkBox1.Checked,
				Age_1         = this.checkBox2.Checked,
				Age_2         = this.checkBox3.Checked,
				Age_3         = this.checkBox4.Checked,
				Age_ETC       = this.checkBox5.Checked,
				Country_JAPAN = this.checkBox6.Checked,
				Country_USA   = this.checkBox7.Checked,
				Country_EURO  = this.checkBox8.Checked,
				Status_Geneki = this.checkBox9.Checked,	
				Status_Intai  = this.checkBox10.Checked,
				OwnerHorse    = this.checkBox11.Checked,
				ClubHorse     = this.checkBox12.Checked,
				SaleHorse     = this.checkBox13.Checked,
				WatchHorse    = this.checkBox14.Checked,
				CurrentHorse  = this.checkBox15.Checked,
			};
			this.tabControl1_SelectedIndexChangedHandler( this.tabControl1, null );
		}

		/// <summary>
		/// 設定ファイルを読み込んでプログラムをセットアップする
		/// </summary>
		private void SettingSetup()
		{
			try {
				if( System.IO.File.Exists( Program.SettingFileName ) ) {
					this.setting_ = WP7_2012ULV.Setting.ProgramSetting.LoadFromFile( Program.SettingFileName );
				} else {
					this.setting_ = WP7_2012ULV.Setting.ProgramSetting.DefaultSetting;
				}
			} catch {
				MessageBox.Show( "設定の読み込みに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
				this.setting_ = WP7_2012ULV.Setting.ProgramSetting.DefaultSetting;
			}

			try {
				var file_name = String.Format( "{0}\\{1}", this.ExtenstionsDir, Program.EXTENSIONS_SETTING_FILE_NAME );

				if( System.IO.File.Exists( file_name ) ) {
					this.extension_setting_ = WP7_2012ULV.Setting.ExtensionSetting.Setting.LoadFromFile( file_name );
				} else {
					this.extension_setting_ = WP7_2012ULV.Setting.ExtensionSetting.Setting.DefaultExtensionSetting;
				}
			} catch {
				MessageBox.Show( "拡張機能設定の読み込みに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
				this.extension_setting_ = WP7_2012ULV.Setting.ExtensionSetting.Setting.DefaultExtensionSetting;
			}

			try {
				if( !System.IO.File.Exists( Program.VersionSettingFileName ) ) {
					MessageBox.Show( "バージョン情報設定ファイルがありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
					this.version_setting_ = WP7_2012ULV.Setting.WPVersionConfig.DefaultExtensionSetting;
				} else {
					this.version_setting_ = WP7_2012ULV.Setting.WPVersionConfig.LoadFromFile( Program.VersionSettingFileName );
				}
			}  catch {
				MessageBox.Show( "バージョン設定の読み込みに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}

			this.FromSetting( this.setting_.MainFormSetting );
		}


		/// <summary>
		/// メインメニューをセットアップする
		/// </summary>
		private void MainMenuSetup()
		{
			this.pictureBox1.Image = global::WP7_2012ULV.Properties.Resources.SettingIcon;
			this.pictureBox1.Click += ( obj, e )=> {
				this.contextMenuStrip1.Visible = !this.contextMenuStrip1.Visible;
				this.contextMenuStrip1.Top  = this.DesktopLocation.Y + this.pictureBox1.Top + ( this.pictureBox1.Height * 2 ) + 5;
				this.contextMenuStrip1.Left = this.DesktopLocation.X + this.pictureBox1.Left + 8;
			};

			this.contextMenuStrip1.VisibleChanged += ( obj, e )=> {
				this.pictureBox1.BorderStyle = this.contextMenuStrip1.Visible ? BorderStyle.FixedSingle : BorderStyle.None;
				this.contextMenuStrip1.Items["Wp7BreedingItem"].Enabled = this.wp_ != null ;
			};

			var toolStripItems = new ToolStripItem[] {
				new ToolStripMenuItem( "配合支援", null, 
					new EventHandler((obj, e)=>{
						if( this.wp_ == null ) {
							MessageBox.Show( "未取得です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
							return ;
						}
						var form = new Breeding.BreedingForm(
							this.wp_,
							this.setting_.DispNameType,
							this.setting_.HorseSireSetting,
							this.setting_.HorseDamSetting,
							this.setting_.BreedingToSireSetting,
							this.setting_.BreedingToDamSetting
						);
						form.Show();
						this.BreedingFormList.Add( form );
					})
				){
					Name = "Wp7BreedingItem",
				},
				new ToolStripSeparator(),
				new ToolStripMenuItem( "コピー(&C)", null,
					new EventHandler((obj, e)=>{
						if( this.umaListView_ != null ) {
							var csv = this.umaListView_.ToCSV();
							Clipboard.SetText( csv );
							MessageBox.Show( "クリップボードにコピーしました", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information );
							csv = "";
							this.GC_Collect();
						}	
					})
				),
				new ToolStripMenuItem( "ファイルに保存する(&S)", null,
					new EventHandler((obj, e)=>{
						if( this.umaListView_ == null ) {
							return ;
						}
						this.saveFileDialog1.Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";
						this.saveFileDialog1.FileName = this.Text + ".txt";

						if( this.saveFileDialog1.ShowDialog() == DialogResult.OK ) {
							var csv = this.umaListView_.ToCSV();
							using( var sw = new System.IO.StreamWriter( this.saveFileDialog1.FileName, false, System.Text.Encoding.Default ) ) {
								sw.Write( csv );
							}
							this.GC_Collect();
						}	
					})
				),
				new ToolStripSeparator(),
				new ToolStripMenuItem( "WP7バージョン設定", null,
					new EventHandler((obj, e)=>{
						// pass
					})
				){
					Name = "VersionConfigDropDown",	
					Enabled = false,			
				},
				new ToolStripMenuItem( "観覧専用モード", null,
					new EventHandler((obj, e)=>{
						var item = obj as ToolStripMenuItem;
						item.Checked = !item.Checked;
						this.setting_.Mode = item.Checked 
							? KOEI.WP7_2012.ReadWriteMode.ReadOnly
							: KOEI.WP7_2012.ReadWriteMode.ReadWrite;
						if( this.umaListView_ != null ) {
							this.umaListView_.Dispose();
							this.umaListView_ = null;
							this.wp_.Dispose();
							this.wp_ = null;
						}
					})
				) {
					Name = "ReadOnlyModeItem",
				},
				new ToolStripMenuItem( "カナ表示", null,
					new EventHandler((obj, e)=>{
						var ctr = ( obj as ToolStripMenuItem );
						if( ctr == null ) {
							return;
						}
						ctr.Checked = !ctr.Checked;
						this.setting_.DispNameType = ctr.Checked ? WP7_2012ULV.Enums.NameType.KANA : WP7_2012ULV.Enums.NameType.ENGLISH;
					})
				){
					Name = "FontChangeOptionItem",
				},
				new ToolStripMenuItem( "常に最前面に表示", null,
					new EventHandler((obj, e)=>{
						var ctr = ( obj as ToolStripMenuItem );
						if( ctr == null ) {
							return;
						}
						ctr.Checked = !ctr.Checked;
						this.TopMost = ctr.Checked;
					})
				){
					Checked = false,	
				},
				new ToolStripMenuItem( "フォント設定(&O)", null,
					new EventHandler((obj, e)=>{
						if( this.setting_.HorseRaceSetting.Font != null ) {
							this.fontDialog1.Font = new Font( 
								this.setting_.HorseRaceSetting.Font.Name,
								this.setting_.HorseRaceSetting.Font.Size,
								this.setting_.HorseRaceSetting.Font.Style
							);
						}
						if( this.fontDialog1.ShowDialog() == DialogResult.OK ) {
							var ary = new [] {
								this.setting_.HorseChildSetting,
								this.setting_.HorseDamSetting,
								this.setting_.HorseRaceSetting,
								this.setting_.HorseSireSetting,
								this.setting_.BreedingToSireSetting,
								this.setting_.BreedingToDamSetting,
							};

							foreach( var setting in ary ) {
								setting.Font = new UMAListView.ListViewFont() {
									Name  = this.fontDialog1.Font.Name,
									Size  = this.fontDialog1.Font.Size,
									Style = this.fontDialog1.Font.Style,
								};
							}
							if( this.umaListView_ != null ) {
								this.umaListView_.UpdateFontSetting( new UMAListView.ListViewFont() {
									Name  = this.fontDialog1.Font.Name,
									Size  = this.fontDialog1.Font.Size,
									Style = this.fontDialog1.Font.Style,
								});
							}
						}
					})
				),
				new ToolStripSeparator(),
				new ToolStripMenuItem( "最新版をチェック", null,
					new EventHandler((obj, e)=>{
						System.Diagnostics.Process.Start( Program.WEBSITE_URL );
					})
				),
				new ToolStripMenuItem( "バージョン情報(&V)", null,
					new EventHandler((obj, e)=>{
						MessageBox.Show( String.Format("{0} - {1}",
							Program.AssemblyName, Program.AssemblyVersion ),
							"バージョン情報",
							MessageBoxButtons.OK,
							MessageBoxIcon.None
						);
					})
				),
				new ToolStripMenuItem( "終了(&X)", null,
					new EventHandler((obj, e)=>{
						this.Close();
					})
				),
			};

			foreach( var item in toolStripItems ) {
				this.contextMenuStrip1.Items.Add( item );
			}

			 ((ToolStripMenuItem) this.contextMenuStrip1.Items["ReadOnlyModeItem"]).Checked = this.setting_.Mode == ReadWriteMode.ReadOnly;
			 ((ToolStripMenuItem) this.contextMenuStrip1.Items["FontChangeOptionItem"]).Checked = this.setting_.DispNameType == WP7_2012ULV.Enums.NameType.KANA;
			
			var versionItems = (ToolStripMenuItem) this.contextMenuStrip1.Items["VersionConfigDropDown"];
			if( this.version_setting_ != null ) {
				foreach( var config in this.version_setting_.VersionConfigList ) {
					var radioButton = new ToolStripRadioButtonMenuItem( config.AssemblyString, null, (obj, e)=>{
						var self = obj as ToolStripMenuItem;
						if( self == null || !self.Checked ) {
							return;
						}
						this.setting_.VersionConfigAssembly = (WP7_2012ULV.Setting.WPVersionConfig.Assembly)self.Tag;
						this.UpdateFormTitle();
					}){
						Name = config.AssemblyString,
						Tag = new WP7_2012ULV.Setting.WPVersionConfig.Assembly() {
							AssemblyName = config.AssemblyName,
							ClassName = config.ClassName,
							AssemblyString = config.AssemblyString,
						},
						Checked = this.setting_.VersionConfigAssembly.AssemblyString == config.AssemblyString
					};
					versionItems.Enabled = true;
					versionItems.DropDownItems.Add( radioButton );
				}
			}
		}

		/// <summary>
		/// フォームを設定クラスにエクスポートする
		/// </summary>
		/// <returns>フォームの設定</returns>
		public Setting.MainFormSetting ToSetting()
		{
			return new Setting.MainFormSetting() {
				Top    = this.WindowState == FormWindowState.Normal ? this.Top    : this.setting_.MainFormSetting.Top,
				Left   = this.WindowState == FormWindowState.Normal ? this.Left   : this.setting_.MainFormSetting.Left,
				Width  = this.WindowState == FormWindowState.Normal ? this.Width  : this.setting_.MainFormSetting.Width,
				Height = this.WindowState == FormWindowState.Normal ? this.Height : this.setting_.MainFormSetting.Height,
			};
		}

		/// <summary>
		/// 設定を読み込んでフォームに反映する
		/// </summary>
		/// <param name="form_setting">フォームの設定</param>
		public void FromSetting( Setting.MainFormSetting form_setting )
		{
			if( form_setting == null ) {
				return ;
			}
			this.Top = form_setting.Top;
			this.Left = form_setting.Left;

			if( form_setting.Width > 100 ) {
				this.Width = form_setting.Width;
			}
			if( form_setting.Height > 100 ) {
				this.Height = form_setting.Height;
			}
		}

		/// <summary>
		/// 配合支援リストの設定を更新する
		/// </summary>
		/// <param name="setting"></param>
		public void UpdateBreedingSetting( UMAListView.Setting listViewSetting )
		{

		}

		/// <summary>
		/// UMAListViewの設定を更新する
		/// </summary>
		private void UpdateUMAListViewSetting()
		{
			if( this.currentHorseType_ == Enums.HorseType.UNKNOWN || this.umaListView_ == null ) {
				return ;
			}

			switch( this.currentHorseType_ )
			{
			case Enums.HorseType.CHILD:
				this.setting_.HorseChildSetting = this.umaListView_.ToSetting();
				break;
			case Enums.HorseType.RACE:
				this.setting_.HorseRaceSetting = this.umaListView_.ToSetting();
				break;
			case Enums.HorseType.DAM:
				this.setting_.HorseDamSetting = this.umaListView_.ToSetting();
				break;
			case Enums.HorseType.SIRE:
				this.setting_.HorseSireSetting = this.umaListView_.ToSetting();
				break;
			}
		}

		/// <summary>
		/// フォームのタイトルを更新する
		/// </summary>
		private void UpdateFormTitle()
		{
			if( this.setting_.VersionConfigAssembly == null ) {
				this.button1.Enabled = false;
				this.Text = String.Format( "{0}({1})", Program.AssemblyName, "バージョン情報が不明です" );
				return;
			}

			if( this.wp_ == null ) {
				this.Text = String.Format( "{0}({1})", Program.AssemblyName, this.setting_.VersionConfigAssembly.AssemblyString );
				return;
			}
			this.Text = String.Format( "{0}{1}({2}) - {3}",
				this.setting_.Mode == ReadWriteMode.ReadOnly ? "[読専]" : "",
				Program.AssemblyName,
				this.setting_.VersionConfigAssembly.AssemblyString,
				this.wp_.月週( this.wp_.GetCurrentWeekNumber() ) );
		}

		/// <summary>
		/// 馬リストをフォームに表示する
		/// </summary>
		private void DispHorseList()
		{
			if( this.wp_ == null ) {
				return;
			}
			this.UpdateFormTitle();

			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

			var horse_type = (Enums.HorseType) this.tabControl1.TabPages[ this.tabControl1.SelectedIndex ].Tag;

			this.umaListView_Config_.DispNameType = this.setting_.DispNameType;

			if( this.umaListView_ != null && this.currentHorseType_ == horse_type ) {
				this.umaListView_.CreateHorseList( this.wp_ );
			} else {
				UMAListView.UMAListViewTpl uma_listview;
				UMAListView.Setting uma_listview_setting;

				this.UpdateUMAListViewSetting();

				switch( horse_type )
				{
				case Enums.HorseType.CHILD:
					uma_listview = new HorseChildListView( this.umaListView_Config_, this.setting_.Mode, this.extension_setting_.HorseChildExtensions, this.ExtenstionsDir );
					uma_listview_setting = this.setting_.HorseChildSetting;
					break;
				case Enums.HorseType.RACE:
					uma_listview = new HorseRaceListView( this.umaListView_Config_, this.setting_.Mode, this.extension_setting_.HorseRaceExtensions, this.ExtenstionsDir );
					uma_listview_setting = this.setting_.HorseRaceSetting;
					break;
				case Enums.HorseType.DAM:
					uma_listview = new HorseDamListView( this.umaListView_Config_, this.setting_.Mode, this.extension_setting_.HorseDamExtensions, this.ExtenstionsDir );
					uma_listview_setting = this.setting_.HorseDamSetting;
					break;
				case Enums.HorseType.SIRE:
					uma_listview = new HorseSireListView( this.umaListView_Config_, this.setting_.Mode, this.extension_setting_.HorseSireExtensions, this.ExtenstionsDir );
					uma_listview_setting = this.setting_.HorseSireSetting;
					break;
				default:
					MessageBox.Show("[BUG]");
					return;
				}

				if( this.mainPanel.Controls.Count != 0 ) {
					this.umaListView_.Dispose();
					this.mainPanel.Controls.Clear();
					this.umaListView_ = null;
				}
				this.umaListView_ = uma_listview;
				this.umaListView_.Dock = DockStyle.Fill;
				this.umaListView_.FromSetting( uma_listview_setting );
				this.umaListView_.CreateHorseList( this.wp_ );
				this.mainPanel.Controls.Add( this.umaListView_ );
				this.currentHorseType_ = horse_type;
			}

			sw.Stop();

			this.toolStripStatusLabel2.Text = String.Format( "{0}(ms)", sw.ElapsedMilliseconds );
			this.toolStripStatusLabel3.Text = String.Format( "{0}(line)", this.umaListView_.ItemsCount );
			this.toolStripStatusLabel4.Text = String.Format( "白毛:{0}(頭)", this.umaListView_.WhiteColorHorseCount );		

			this.GC_Collect();
		}
	
		/// <summary>
		/// タブを切り替えたときに発生するイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl1_SelectedIndexChangedHandler( Object sender, EventArgs e )
		{
			var ti = this.tabControl1.SelectedIndex;

			if( ti == -1 ) {
				return;
			}

			var tp = this.tabControl1.TabPages[ ti ];

			tp.Controls.AddRange(new Control[]{
				this.mainPanel,
				this.panel1,
			});

			switch( (Enums.HorseType)tp.Tag )
			{
			case Enums.HorseType.RACE:
				this.checkBox1.Enabled = false;
				this.checkBox2.Enabled = false;
				this.checkBox3.Enabled = true;
				this.checkBox4.Enabled = true;
				this.checkBox5.Enabled = true;
				this.checkBox6.Enabled = true;
				this.checkBox7.Enabled = true;
				this.checkBox8.Enabled = true;
				this.checkBox9.Enabled = true;
				this.checkBox10.Enabled = true;
				this.checkBox11.Enabled = true;
				this.checkBox12.Enabled = true;
				this.checkBox13.Enabled = false;
				this.checkBox14.Enabled = true;
				break;

			case Enums.HorseType.CHILD:
				//this.checkBox1.Enabled = true;
				//this.checkBox2.Enabled = true;
				this.checkBox3.Enabled = false;
				this.checkBox4.Enabled = false;
				this.checkBox5.Enabled = false;
				this.checkBox9.Enabled = false;
				this.checkBox10.Enabled = false;
				this.checkBox13.Enabled = true;
				this.checkBox1.Enabled = !this.checkBox13.Checked;
				this.checkBox2.Enabled = !this.checkBox13.Checked;
				this.checkBox6.Enabled = !this.checkBox13.Checked;
				this.checkBox7.Enabled = !this.checkBox13.Checked;
				this.checkBox8.Enabled = !this.checkBox13.Checked;
				this.checkBox11.Enabled = !this.checkBox13.Checked;
				this.checkBox12.Enabled = !this.checkBox13.Checked;
				this.checkBox14.Enabled = false;
				break;

			case Enums.HorseType.DAM:
				this.checkBox1.Enabled = false;
				this.checkBox2.Enabled = false;
				this.checkBox3.Enabled = false;
				this.checkBox4.Enabled = false;
				this.checkBox5.Enabled = false;
				this.checkBox6.Enabled = true;
				this.checkBox7.Enabled = true;
				this.checkBox8.Enabled = true;
				this.checkBox9.Enabled = true;
				this.checkBox10.Enabled = true;
				this.checkBox11.Enabled = true;
				this.checkBox12.Enabled = true;
				this.checkBox13.Enabled = false;
				this.checkBox14.Enabled = false;
				break;

			case Enums.HorseType.SIRE:
				this.checkBox1.Enabled = false;
				this.checkBox2.Enabled = false;
				this.checkBox3.Enabled = false;
				this.checkBox4.Enabled = false;
				this.checkBox5.Enabled = false;
				this.checkBox6.Enabled = true;
				this.checkBox7.Enabled = true;
				this.checkBox8.Enabled = true;
				this.checkBox9.Enabled = true;
				this.checkBox10.Enabled = true;
				this.checkBox11.Enabled = true;
				this.checkBox12.Enabled = true;
				this.checkBox13.Enabled = false;
				this.checkBox14.Enabled = false;
				break;
			}

			try {
				this.DispHorseList();
			} catch( Exception ex ) {
				this.currentHorseType_ = WP7_2012ULV.Enums.HorseType.UNKNOWN;
				var message = String.Format( "エラーが発生しました - {0}", ex.Message );
				MessageBox.Show( message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		/// <summary>
		/// 取得ボタンを押したときのイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			if( this.wp_ != null ) {
				this.wp_.Dispose();
				this.wp_ = null;
			}

			if( this.BreedingFormList.Count > 0 ) {
				foreach( var form in this.BreedingFormList ) {
					form.Close();
					form.Dispose();
				}
				this.BreedingFormList.Clear();
			}

#if DEBUG // --------------------------------------------------------------
			var asm = System.Reflection.Assembly.Load( this.setting_.VersionConfigAssembly.AssemblyName );
			var config = (KOEI.WP7_2012.ConfigurationInterface)Activator.CreateInstance( asm.GetType( this.setting_.VersionConfigAssembly.ClassName ) );
			this.wp_ = new KOEI.WP7_2012.WP7( config.ProcessName, config, this.setting_.Mode );
			this.DispHorseList();
#else // ------------------------------------------------------------------
			try {
				var asm = System.Reflection.Assembly.Load( this.setting_.VersionConfigAssembly.AssemblyName );
				var config = (KOEI.WP7_2012.ConfigurationInterface)Activator.CreateInstance( asm.GetType( this.setting_.VersionConfigAssembly.ClassName ) );
				this.wp_ = new KOEI.WP7_2012.WP7( config.ProcessName, config, this.setting_.Mode );
				this.DispHorseList();
			} catch( Exception ex ) {
				this.currentHorseType_ = WP7_2012ULV.Enums.HorseType.UNKNOWN;
				var message = String.Format( "エラーが発生しました - {0}", ex.Message );
				MessageBox.Show( message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
#endif // -----------------------------------------------------------------
		}

		/// <summary>
		/// 使用メモリをダブルクリックしたときのイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripStatusLabel1_DoubleClick(object sender, EventArgs e)
		{
			this.GC_Collect();
		}
	}
}
