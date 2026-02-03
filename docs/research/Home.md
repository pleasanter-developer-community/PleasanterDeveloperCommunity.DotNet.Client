# 実装調査ドキュメント

このディレクトリには、プリザンター本体やその他の関連システムの実装調査に関するドキュメントを格納しています。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [目的](#目的)
- [ドキュメント一覧](#ドキュメント一覧)
- [注意事項](#注意事項)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## 目的

- PleasanterDeveloperCommunity.DotNet.Client の開発に必要な、プリザンター本体の内部実装に関する知見を蓄積する
- API の動作仕様や制約事項を明確にする
- 既知の問題点や注意事項を文書化する

## ドキュメント一覧

| ドキュメント                                                               | 説明                                              | 調査日     |
| -------------------------------------------------------------------------- | ------------------------------------------------- | ---------- |
| [pleasanter-upsert-implementation.md](pleasanter-upsert-implementation.md) | Upsert API の実装調査（レースコンディション問題） | 2026-02-03 |
| [pleasanter-session-api-retention.md](pleasanter-session-api-retention.md) | Sessions API のセッション有効期間調査             | 2026-02-03 |
| [pleasanter-site-setting-history.md](pleasanter-site-setting-history.md)   | SiteSetting 更新時の変更履歴記録調査              | 2026-02-03 |

## 注意事項

- これらのドキュメントは特定バージョンのプリザンターを対象とした調査結果です
- プリザンターのバージョンアップにより、実装が変更される可能性があります
- 最新の動作については、プリザンター本体のソースコードを確認してください
