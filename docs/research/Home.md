<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [実装調査ドキュメント](#%E5%AE%9F%E8%A3%85%E8%AA%BF%E6%9F%BB%E3%83%89%E3%82%AD%E3%83%A5%E3%83%A1%E3%83%B3%E3%83%88)
    - [目的](#%E7%9B%AE%E7%9A%84)
    - [ドキュメント一覧](#%E3%83%89%E3%82%AD%E3%83%A5%E3%83%A1%E3%83%B3%E3%83%88%E4%B8%80%E8%A6%A7)
    - [注意事項](#%E6%B3%A8%E6%84%8F%E4%BA%8B%E9%A0%85)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 実装調査ドキュメント

このディレクトリには、プリザンター本体やその他の関連システムの実装調査に関するドキュメントを格納しています。

## 目的

- PleasanterDeveloperCommunity.DotNet.Client の開発に必要な、プリザンター本体の内部実装に関する知見を蓄積する
- API の動作仕様や制約事項を明確にする
- 既知の問題点や注意事項を文書化する

## ドキュメント一覧

| ドキュメント                                                               | 説明                                              | 調査日     |
| -------------------------------------------------------------------------- | ------------------------------------------------- | ---------- |
| [pleasanter-upsert-implementation.md](pleasanter-upsert-implementation.md) | Upsert API の実装調査（レースコンディション問題） | 2026-02-03 |

## 注意事項

- これらのドキュメントは特定バージョンのプリザンターを対象とした調査結果です
- プリザンターのバージョンアップにより、実装が変更される可能性があります
- 最新の動作については、プリザンター本体のソースコードを確認してください
