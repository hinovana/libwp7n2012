libwp7n2012
===========

バイナリダウンロードはGoogle Codeから
-----------
[libwp7n2012 - Winning Post 7 2012 Cheat Library - Google Project Hosting](http://code.google.com/p/libwp7n2012/)



Winning Post 7 2012 Cheat Library
-----------

 libwp7n2012はWinning Post 7 2012(Windows版)をハックするためのC#で書かれたライブラリです

.NET Frameworkアセンブリ(DLL)なので
PythonやRubyなどの人気言語でスクリプティングすることも可能です

* [IronPython](http://ironpython.codeplex.com/)
* [IronRuby](http://ironruby.net/)


Example
-----------

### 自牧場(日本)に繋養されている繁殖牝馬の子出しを10にセットする(Ruby)

```ruby
require 'KOEI.WP7_2012'
require 'KOEI.WP7_2012.Configuration.V100'

include KOEI::WP7_2012

## トランザクション開始
config = Configuration::V100.new
wp = WP7.new(config.ProcessName, config)

wp.HDamTable.RecordCount.times do |horse_num|
  ## 繁殖牝馬テーブルからレコードを取得する
  dam_data = wp.HDamTable.GetData(horse_num, Datastruct::HDamData.new)
  
  ## 能力データテーブルからレコードを取得する
  abl_data = wp.HAblTable.GetData(dam_data.abl_num, Datastruct::HAblData.new)
  
  ## 自牧場以外なら次のレコードに
  next if abl_data.bokuzyou != 25
  
  ## 子出しを10にセットする
  abl_data.kodashi = 10
  
  ## テーブルにセットする(Commitするまでは実際にはプロセスメモリに書き込まれない)
  wp.HAblTable.SetData(dam_data.abl_num, abl_data)
end

## テーブルをプロセスメモリに書き込む
wp.HAblTable.Commit
```

### 所有している競走馬の能力チャートのメモを全て開ける(Ruby)

```ruby
require 'KOEI.WP7_2012'
require 'KOEI.WP7_2012.Configuration.V100'

include KOEI::WP7_2012

## トランザクション開始
config = Configuration::V100.new
wp = WP7.new(config.ProcessName, config)

wp.HOwnershipRaceTable.RecordCount.times do |num|
  ## 所有競走馬テーブルからレコードを取得する
  data = wp.HOwnershipRaceTable.GetData(num, Datastruct::HOwnershipRaceData.new)
  
  ## 空きを示す所有競走馬の番号なら次に
  next if num == wp.config.NullOwnershipRaceHorseNumber
  
  ## メモ1～29までを開ける
  (1..29).each do |i|
    data.method("memo_open_#{i}=").call(1)
  end
  
  ## テーブルにセットする(Commitするまでは実際にはプロセスメモリに書き込まれない)
  wp.HOwnershipRaceTable.SetData(num, data)
end

## テーブルをプロセスメモリに書き込む
wp.HOwnershipRaceTable.Commit
```


実装例
-----------

### WP7_2012ULV(馬リストビュー)

<img src="https://camo.githubusercontent.com/bba22162319660ae3c1b8703bef77e085061116c/687474703a2f2f7777772e73656e676f6b752e636e2f6262732f646174612f6174746163686d656e742f666f72756d2f70772f4d6f6e5f313230342f32315f39303532315f3532663236613033633539303930622e676966" />

