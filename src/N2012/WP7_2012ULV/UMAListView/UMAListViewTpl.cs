using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KOEI.WP7_2012;

namespace WP7_2012ULV.UMAListView
{
	/// <summary>
	/// 馬リストビューの基本クラス
	/// </summary>
	public abstract partial class UMAListViewTpl : UserControl
	{
		private KOEI.WP7_2012.WP7 wp_;

		private ListViewItem[] listView1_virtualItems_;

		/// <summary>
		/// 拡張機能のメインクラス名
		/// </summary>
		public const String EXTENSION_CLASS_NAME  = "WP7_2012ULV_Extension";

		/// <summary>
		/// 拡張機能のメインメソッド名
		/// </summary>
		public const String EXTENSION_METHOD_NAME = "CommandMain";

		/// <summary>
		/// 気数行の背景色
		/// </summary>
		protected System.Drawing.Color OddLineBgColor = System.Drawing.Color.FromArgb( 0xEF, 0xEF, 0xFF );

		/// <summary>
		/// ループのコールバック関数
		/// </summary>
		/// <param name="item_index">アイテムインデックス</param>
		/// <param name="horse_num">馬番号</param>
		protected delegate void SelectedIndicesEachCallback( int item_index, UInt32 horse_num );

		/// <summary>
		/// 初回ソートのデフォルトカラム番号
		/// </summary>
		public int ListViewDefaultSortColumn = 0;


		public KOEI.WP7_2012.WP7 WP7 {
			get {
				return this.wp_;
			}
		}

		public Config ListViewConfig {
			get;
			set;
		}

		protected String ExtensionsDir {
			get;
			set;
		}

		protected WP7_2012ULV.Setting.ExtensionSetting.Command[] Extensions {
			get;
			set;
		}

		protected ContextMenuStrip ListView1_ContextMenuStrip {
			get {
				return this.contextMenuStrip1;
			}
		}

		public abstract int WhiteColorHorseCount {
			get;
		}

		public ListView ListView1 {
			get {
				return this.listView1;	
			}
		}

		protected ListViewItem[] ListView1_VirtualItems { 
			get {
				return this.listView1_virtualItems_;
			}
			set {
				this.listView1_virtualItems_ = value;
			}
		}

		public int ItemsCount {
			get {
				return this.ListView1.Items.Count;
			}
		}

		/// <summary>
		/// 派生クラスで実装するアクセサ
		/// 拡張機能のメイン関数が要求する引数のタイプ
		/// </summary>
		protected abstract Type[] ExtensionArgTypes {
			get;
		}

		/// <summary>
		/// 派生クラスで実装するメソッド
		/// C#の拡張機能を実行する
		/// </summary>
		/// <param name="method">呼び出す拡張機能のメソッド</param>
		protected abstract void ExecCSharpExtension( System.Reflection.MethodInfo method, WP7_2012ULV.Setting.ExtensionSetting.Manifest manifest );

		/// <summary>
		/// 派生クラスで実装するメソッド
		/// リストビューのカラムをセットアップする
		/// </summary>
		protected abstract void ListView1_ColumnSetup();

		/// <summary>
		/// 派生クラスで実装するメソッド
		/// 表示する馬リストを作成する
		/// </summary>
		/// <param name="wp"></param>
		/// <returns></returns>
		protected abstract ListViewItem[] CreateHorseListSub( KOEI.WP7_2012.WP7 wp, object arg );

		/// <summary>
		/// スポイラーALライクな編集を行う
		/// </summary>
		/// <param name="item_index">対象のリストビューのアイテムインデックス</param>
		protected abstract void SpoilerLikeItemEdit( int item_index ); 


		public ReadWriteMode Mode {
			get;
			private set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="config">リストビューの設定</param>
		/// <param name="extensions">拡張機能の配列</param>
		/// <param name="extnensions_dir">拡張機能のファイルパス</param>
		public UMAListViewTpl( UMAListView.Config config, ReadWriteMode mode, WP7_2012ULV.Setting.ExtensionSetting.Command[] extensions, String extnensions_dir )
		{
			this.ListViewConfig = config;
			this.ExtensionsDir = extnensions_dir;
			this.Extensions = extensions;
			this.Mode = mode;

			this.InitializeComponent();
			this.ListView1_Setup();
			this.ContextMenu_Setup();

		}

		/// <summary>
		/// リストビューをセットアップする
		/// </summary>
		private void ListView1_Setup()
		{
			this.ListView1_ColumnSetup();

			this.ListView1.VirtualMode = true;
			this.ListView1.RetrieveVirtualItem += ( obj, e )=> {
				e.Item = this.ListView1_VirtualItems[ e.ItemIndex ];
			};
			this.ListView1.ColumnClick += this.ListView1_ColumnClick;
		}

		/// <summary>
		/// 右クリックメニューをセットアップする
		/// </summary>
		private void ContextMenu_Setup()
		{
			this.contextMenuStrip1.Items.Add( "クリップボードにコピー", null, ( obj, e )=>{
				Clipboard.SetText( this.ToCSVBySelectedIndices() );
				MessageBox.Show("クリップボードにコピーしました");
			});

			if( this.Mode == ReadWriteMode.ReadWrite ) {
				this.contextMenuStrip1.Items.Add( "SpoilerALライク編集(β)", null, ( obj, e )=>{
					if( this.ListView1.SelectedIndices.Count != 1 ) {
						MessageBox.Show( "この機能は複数選択不可です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information );
						return;
					}
#if DEBUG // ---------------------------------------------------------------------------
					this.SpoilerLikeItemEdit( this.ListView1.SelectedIndices[0] );
#else // -------------------------------------------------------------------------------
					try {
						this.SpoilerLikeItemEdit( this.ListView1.SelectedIndices[0] );
					} catch( Exception ex ) {
						MessageBox.Show( "エラーが発生しました - " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
					}
#endif // ------------------------------------------------------------------------------
				});
			}
			this.contextMenuStrip1.Items.Add( new ToolStripSeparator() );

			if( this.Extensions == null ) {
				return;
			}

			foreach( var extension in this.Extensions ) {
				if( extension.Manifest == null ) {
					continue;
				}
				if( this.Mode == ReadWriteMode.ReadWrite || extension.Manifest.Mode == ReadWriteMode.ReadOnly ) {
					if( extension.Type == WP7_2012ULV.Setting.ExtensionSetting.MenuType.SEPARATOR ) {
						this.contextMenuStrip1.Items.Add( new ToolStripSeparator() );
					} else {
						var item = new ToolStripMenuItem() {
							Tag = extension,
							Text = extension.Title,
						};
						item.Click += ContextMenuExtensionItem_ClickHandler;
						this.contextMenuStrip1.Items.Add( item );
					}
				}
			}
		}

		/// <summary>
		/// 右クリックメニューから拡張機能をクリックしたときのイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ContextMenuExtensionItem_ClickHandler( Object sender, EventArgs e )
		{
			var menu = (sender as ToolStripItem);

			if( menu == null ) {
				return;
			}

#if DEBUG // ---------------------------------------------------------------------------
			this.ExecExtensionMain( (WP7_2012ULV.Setting.ExtensionSetting.Command)menu.Tag );
#else // -------------------------------------------------------------------------------
			try {
				this.ExecExtensionMain( (WP7_2012ULV.Setting.ExtensionSetting.Command)menu.Tag );
			} catch( Exception ex ) {
				MessageBox.Show( "エラーが発生しました - " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
#endif // ------------------------------------------------------------------------------
		}


		/// <summary>
		/// 拡張機能をコンパイルして実行するメソッド
		/// </summary>
		/// <param name="extension">実行する拡張機能</param>
		private void ExecExtensionMain( WP7_2012ULV.Setting.ExtensionSetting.Command extension )
		{
			var file = String.Format( "{0}\\{{{1}}}.cs", this.ExtensionsDir, extension.Guid );

			if( !System.IO.File.Exists( file ) ) {
				var message = String.Format( "{0} 拡張機能ファイルが見つかりませんでした", file );
				MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return ;
			}

			if( this.WP7.TransactionWeekNumber != this.WP7.GetCurrentWeekNumber() ) {
				var message = String.Format(
					"データ取得時から週が変わっています({0}→{1})\r\n安全のため書き込みは行いません、再取得してください",
					this.WP7.TransactionWeekNumber,
					this.WP7.GetCurrentWeekNumber()
				);
				MessageBox.Show( message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			var compiler_option = new Dictionary< string, string >() {
				{ "CompilerVersion", "v3.5" }
			};
			var compiler = new Microsoft.CSharp.CSharpCodeProvider( compiler_option );

			var options = new System.CodeDom.Compiler.CompilerParameters();

			options.GenerateInMemory = true;
			options.WarningLevel = 4;
			options.TreatWarningsAsErrors = true;

			options.ReferencedAssemblies.Add("System.dll");
			options.ReferencedAssemblies.Add("System.Data.dll");
			options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			options.ReferencedAssemblies.Add("System.Drawing.dll");
			options.ReferencedAssemblies.Add("KOEI.WP7_2012.dll");

			using( var sr = new System.IO.StreamReader( file, Encoding.UTF8 ) ) {
				var source = sr.ReadToEnd();
				var program = compiler.CompileAssemblyFromSource( options, new[]{ source } );

				if( program.Errors.Count > 0 ) {
					var error_string = "コンパイルエラー\r\n";
					foreach( var error in program.Errors ) {
						error_string += ((System.CodeDom.Compiler.CompilerError)error).ErrorText;
						error_string += "\r\n";
					}
					throw new Exception( error_string );
				}
				Type klass;

				try {
					klass = program.CompiledAssembly.GetType( EXTENSION_CLASS_NAME );
				} catch( Exception ex ) {
					throw new Exception( String.Format( "{0}クラスの取得に失敗 - {1}", EXTENSION_CLASS_NAME, ex.Message ) );
				}

				var method = klass.GetMethod(
					EXTENSION_METHOD_NAME,
					System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
					null,
					ExtensionArgTypes,
					null
				);

				if( method == null ) {
					throw new Exception( String.Format( "{0}メソッドの取得に失敗", EXTENSION_METHOD_NAME ) );
				}
				this.ExecCSharpExtension( method, extension.Manifest );
			}
		}

		/// <summary>
		/// リストビューのアイテムをループ処理するときに使うメソッド
		/// </summary>
		/// <param name="callback"></param>
		protected void SelectedItemsEach( SelectedIndicesEachCallback callback )
		{
			var count = this.ListView1.SelectedIndices.Count;

			if( count == 0 ) {
				return;
			}
			foreach( var index in this.ListView1.SelectedIndices ) {
				var item = this.ListView1.Items[ (int)index ];
				var horse_num = (int)item.SubItems["horse_num"].Tag;
				callback( (int)index, (uint)horse_num );
			}
		}

		/// <summary>
		/// インスタンスを設定クラスに変換する
		/// </summary>
		/// <returns>インスタンスの設定</returns>
		public UMAListView.Setting ToSetting()
		{
			var columns = new List< ListViewColumn >();

			foreach( var o in this.ListView1.Columns ) {
				var column = o as ColumnHeader;
				columns.Add(new ListViewColumn(){
					Name = column.Name,
					Width = column.Width,
					DisplayIndex = column.DisplayIndex,
				});
			}

			return new Setting() {
				Columns = columns.ToArray(),
				Font = new ListViewFont() {
					Name = this.listView1.Font.Name,
					Size = this.listView1.Font.Size,
					Style = this.listView1.Font.Style,
				},
			};
		}

		/// <summary>
		/// 設定を読み込んでインスタンスに反映する
		/// </summary>
		/// <param name="setting">インスタンスの設定</param>
		public void FromSetting( Setting setting )
		{
			if( setting.Columns != null ) {
				var ary = new ListViewColumn[ setting.Columns.Length ];

				foreach( var column in setting.Columns ) {
					if( !this.listView1.Columns.ContainsKey( column.Name ) ) {
						continue;
					}
					this.listView1.Columns[ column.Name ].Width = column.Width <= 0 ? 10 : column.Width;

					// 謎バグ これだとうまくいかないので一旦配列に退避する
//					this.listView1.Columns[ column.Name ].DisplayIndex = column.DisplayIndex;

					var displayIndex = column.DisplayIndex;
					if( displayIndex >= ary.Length ) {
						displayIndex = ary.Length - 1;
					}
					ary[ displayIndex ] = column;
				}

				var i = 0;

				foreach( var column in ary ) {
					this.listView1.Columns[ column.Name ].DisplayIndex = i++;
				}
			}

			if( setting.Font != null ) {
				this.listView1.Font =  new System.Drawing.Font(
					setting.Font.Name,
					setting.Font.Size,
					setting.Font.Style
				);
			} else {
				setting.Font = new ListViewFont() {
					Name  = this.listView1.Font.Name,
					Size  = this.listView1.Font.Size,
					Style = this.listView1.Font.Style,
				};
			}
		}

		/// <summary>
		/// フォントの設定が更新した通知を受け取る
		/// </summary>
		/// <param name="font"></param>
		public void UpdateFontSetting( ListViewFont font )
		{
			this.listView1.Font = new System.Drawing.Font( font.Name, font.Size, font.Style );
		}


		/// <summary>
		/// 馬リストを作る
		/// </summary>
		/// <param name="wp"></param>
		public void CreateHorseList( KOEI.WP7_2012.WP7 wp, object arg )
		{
			this.ListView1.Items.Clear();
			this.wp_ = wp;

			var items = this.CreateHorseListSub( wp, arg );

			var sortOrders = new System.Windows.Forms.SortOrder[ this.ListView1.Columns.Count ];

			for( var i=0; i<sortOrders.Length; ++i ) {
				var mode = (UMAListView.Sorter.ComparerMode)this.ListView1.Columns[i].Tag;
				switch( mode )
				{
				case UMAListView.Sorter.ComparerMode.TAG_STRING:
				case UMAListView.Sorter.ComparerMode.STRING:
				case UMAListView.Sorter.ComparerMode.TAG_DATETIME:
					sortOrders[i] = SortOrder.Ascending;
					break;
				case UMAListView.Sorter.ComparerMode.NUMERIC:
				case UMAListView.Sorter.ComparerMode.TAG_HEXADECIMAL:
				case UMAListView.Sorter.ComparerMode.TAG_NUMERIC:
					sortOrders[i] = SortOrder.Descending;
					break;
				}
			}
			this.ListView1.Tag = sortOrders;
			this.ListViewItemsSort( items, this.ListViewDefaultSortColumn );

			this.ListView1.BeginUpdate();
			this.ListView1_VirtualItems = items;
			this.ListView1.VirtualListSize = items.Length;
			this.ListView1_OddColor();
			this.ListView1.EndUpdate();
		}

		/// <summary>
		/// 馬リストを作る
		/// </summary>
		/// <param name="wp"></param>
		public void CreateHorseList( KOEI.WP7_2012.WP7 wp )
		{
			this.CreateHorseList( wp, null );
		}

		/// <summary>
		/// 奇数行に色をつける
		/// </summary>
		protected void ListView1_OddColor()
		{
			if( this.ListView1_VirtualItems == null ) {
				return;
			}
			for( var i=0; i<this.ListView1.Items.Count; ++i ) {
				this.ListView1.Items[i].BackColor = ( i % 2 == 1 )
					? this.OddLineBgColor : System.Drawing.Color.White;
			}
		}

		/// <summary>
		/// リストのカラムをクリックしたときに発生するイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ListView1_ColumnClick( object sender, ColumnClickEventArgs e )
		{
			this.ListViewItemsSort( this.ListView1_VirtualItems, e.Column );
			this.ListView1_OddColor();
			this.ListView1.Refresh();
		}

		/// <summary>
		/// リストをソートする
		/// </summary>
		/// <param name="n">カラム番号</param>
		protected void ListViewItemsSort( ListViewItem[] items, int column_index )
		{
			var order = (this.ListView1.Tag as SortOrder[])[ column_index ];
			var mode = (UMAListView.Sorter.ComparerMode)this.ListView1.Columns[ column_index ].Tag;

			UMAListView.Sorter.MergeSort.Sort( items, column_index, mode, order );

			if( order == SortOrder.Ascending ) {
				((SortOrder[])this.ListView1.Tag)[ column_index ] = SortOrder.Descending;
			} else if( order == SortOrder.Descending ) {
				((SortOrder[])this.ListView1.Tag)[ column_index ] = SortOrder.Ascending;
			}
		}

		/// <summary>
		/// 選択行をタブ区切りテキストにして出力する
		/// </summary>
		/// <returns>タブ区切りテキスト</returns>
		public String ToCSVBySelectedIndices()
		{
			var csv = new System.IO.StringWriter();
			var line = "";
			var columns = new ColumnHeader[ this.ListView1.Columns.Count ];

			foreach( var obj in this.ListView1.Columns ) {
				var column = ((ColumnHeader)obj);
				columns[ column.DisplayIndex ] = column;
			}

			foreach( var column in columns ) {
				line += column.Text + "\t";
			}
			csv.WriteLine( line );

			this.SelectedItemsEach( ( item_index, horse_num ) => {
				var item = this.ListView1.Items[ item_index ];
				line = "";
				for( var ii=0; ii<item.SubItems.Count; ++ii ) {
					var sub_item = item.SubItems[ columns[ii].Index ];
					line += sub_item.Text + "\t";
				}
				csv.WriteLine( line );
			});
			return csv.ToString();
		}

		/// <summary>
		/// 全行をタブ区切りテキストにして出力する
		/// </summary>
		/// <returns>タブ区切りテキスト</returns>
		public string ToCSV()
		{
			var csv = new System.IO.StringWriter();
			var line = "";
			var columns = new ColumnHeader[ this.ListView1.Columns.Count ];

			foreach( var obj in this.ListView1.Columns ) {
				var column = ((ColumnHeader)obj);
				columns[ column.DisplayIndex ] = column;
			}

			foreach( var column in columns ) {
				line += column.Text + "\t";
			}
			csv.WriteLine( line );

			for( var i=0; i<this.ListView1.Items.Count; ++i ) {
				var item = this.ListView1.Items[i];
				line = "";
				for( var ii=0; ii<item.SubItems.Count; ++ii ) {
					var sub_item = item.SubItems[ columns[ii].Index ];
					line += sub_item.Text + "\t";
				}
				csv.WriteLine( line );
			}
			return csv.ToString();
		}
	}
}
