# FaraBotModerator

Twitch用BOTです。まだ開発中なのでいろいろ動かない箇所があります。

画面はWPFで作成しています。使用するAPIは[Twitch Developers](https://dev.twitch.tv/), [TwitchLib](https://github.com/TwitchLib/TwitchLib)
を使用しています。

## メイン機能

![image](https://github.com/fara1991/FaraBotModerator/assets/69506848/10e34a0c-a2c6-4322-9726-f64a6a5e549c)

* ### Client

Get Tokenボタンを押すとWebView画面にToken取得用の画面になるので、そこでTwitchのログイン情報を入れ、Connectを押すとoauth
tokenを取得できます。

取得したtokenをAccessTokenに入力します。

```
UserName: Twitchチャンネルのログイン時の名前
AccessToken: 上記のAccessToken
```

これを入力しておくことで、Twitchに接続後のチャット内容、Raid通知、Gift通知、Subscription通知等を取得できるようになります。

* ### API

チャット通知者のアイコン画像や、接続するTwitchのIDを取得するのに使用します。IDはTwitch PubSubの機能で使用します。

Twitch Developersで事前にアプリケーション登録をする必要があります。https://dev.twitch.tv/console

![image](https://github.com/fara1991/FaraBotModerator/assets/69506848/62e93213-935f-4f9f-91eb-1be1812db307)

```
clientId: 画像の赤枠内のクライアントID
clientSecret: 画像の赤枠内のSecret
```

Authorizeボタンを押すとAPI Tokenを取得します。有効期限は短く設定しており、有効期限切れ状態では赤文字の警告を表示します。

警告中は再度Authorizeボタンを押すことで再度token取得を行います。(いずれrefresh
tokenを使うようにし、自動で更新できるように実装します。)

* ### PubSub

Twitch配信中のFollow通知、Bits通知、チャンネルポイント通知等を取得します。

直接アプリケーションで設定する項目はなく、APIで入力した内容を使用します。

* ### BouyomiChan

BouyomiChanConnectにチェックを入れている場合、Connectボタンで接続時に棒読みちゃんとも連携します。

棒読みちゃん側でHTTP連携をTrueにし、ポート番号を5008にする必要があります。

![image](https://github.com/fara1991/FaraBotModerator/assets/69506848/c6faf23b-b0c8-479d-91a1-c35594ad9e22)

これらを設定後、Connectボタンを押すとTwitchに接続、Disconnectボタンを押すとTwitch接続解除します。

## Twitch Event機能

![image](https://github.com/fara1991/FaraBotModerator/assets/69506848/662bdbba-ff93-42be-b3da-c7584e793f5f)

TwitchのFoolow, Raid, Subscription, Bits, Gift,
ChannelPointのそれぞれのイベントが発火したときにTwitch接続中であれば、設定したチャットをTwitchのチャットに表示できるようになります。

name等`{}`で囲った文字については、下の内容でそれぞれ置き換わります。

## Bot追加機能

![image](https://github.com/fara1991/FaraBotModerator/assets/69506848/a47a9db4-38ff-47a7-9a6f-b7be8f54114c)

* ### Translate

DeepL翻訳機能です。DeepL APIの認証キーを入力すると、Twitchでチャットされた後翻訳チャットも表示します。

* ### Timer

定期的に入力したチャットを表示する機能と、指定の日時にチャットを表示する機能の2種類あります。

何かしら宣伝したい時用に使用します。
