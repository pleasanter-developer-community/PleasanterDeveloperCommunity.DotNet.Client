using System.Text.Json.Serialization;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common
{
    /// <summary>
    /// サイト設定を表すクラスです。
    /// プリザンターのSiteSettingsクラスのシリアライズ可能なプロパティを定義しています。
    /// </summary>
    public class SiteSettings
    {
        /// <summary>
        /// サイト設定のバージョン
        /// </summary>
        [JsonPropertyName("Version")]
        public decimal? Version { get; set; }

        #region 一般設定

        /// <summary>
        /// 近く完了する期限（前）の日数
        /// </summary>
        [JsonPropertyName("NearCompletionTimeBeforeDays")]
        public decimal? NearCompletionTimeBeforeDays { get; set; }

        /// <summary>
        /// 近く完了する期限（後）の日数
        /// </summary>
        [JsonPropertyName("NearCompletionTimeAfterDays")]
        public decimal? NearCompletionTimeAfterDays { get; set; }

        /// <summary>
        /// 一覧のページサイズ
        /// </summary>
        [JsonPropertyName("GridPageSize")]
        public int? GridPageSize { get; set; }

        /// <summary>
        /// 一覧のビューID
        /// </summary>
        [JsonPropertyName("GridView")]
        public int? GridView { get; set; }

        /// <summary>
        /// ビューリセットを許可
        /// </summary>
        [JsonPropertyName("AllowViewReset")]
        public bool? AllowViewReset { get; set; }

        /// <summary>
        /// 一覧のエディタの種類
        /// </summary>
        [JsonPropertyName("GridEditorType")]
        public int? GridEditorType { get; set; }

        /// <summary>
        /// 履歴を一覧に表示
        /// </summary>
        [JsonPropertyName("HistoryOnGrid")]
        public bool? HistoryOnGrid { get; set; }

        /// <summary>
        /// 常に検索条件をリクエスト
        /// </summary>
        [JsonPropertyName("AlwaysRequestSearchCondition")]
        public bool? AlwaysRequestSearchCondition { get; set; }

        /// <summary>
        /// 編集リンクを無効化
        /// </summary>
        [JsonPropertyName("DisableLinkToEdit")]
        public bool? DisableLinkToEdit { get; set; }

        /// <summary>
        /// 編集を新しいタブで開く
        /// </summary>
        [JsonPropertyName("OpenEditInNewTab")]
        public bool? OpenEditInNewTab { get; set; }

        /// <summary>
        /// 週の開始日
        /// </summary>
        [JsonPropertyName("FirstDayOfWeek")]
        public int? FirstDayOfWeek { get; set; }

        /// <summary>
        /// 年度開始月
        /// </summary>
        [JsonPropertyName("FirstMonth")]
        public int? FirstMonth { get; set; }

        /// <summary>
        /// 自動バージョンアップの種類
        /// </summary>
        [JsonPropertyName("AutoVerUpType")]
        public int? AutoVerUpType { get; set; }

        /// <summary>
        /// コメント編集を許可
        /// </summary>
        [JsonPropertyName("AllowEditingComments")]
        public bool? AllowEditingComments { get; set; }

        /// <summary>
        /// コピーを許可
        /// </summary>
        [JsonPropertyName("AllowCopy")]
        public bool? AllowCopy { get; set; }

        /// <summary>
        /// 参照コピーを許可
        /// </summary>
        [JsonPropertyName("AllowReferenceCopy")]
        public bool? AllowReferenceCopy { get; set; }

        /// <summary>
        /// コピー時に追加する文字
        /// </summary>
        [JsonPropertyName("CharToAddWhenCopying")]
        public string? CharToAddWhenCopying { get; set; }

        /// <summary>
        /// 分割を許可
        /// </summary>
        [JsonPropertyName("AllowSeparate")]
        public bool? AllowSeparate { get; set; }

        /// <summary>
        /// テーブルロックを許可
        /// </summary>
        [JsonPropertyName("AllowLockTable")]
        public bool? AllowLockTable { get; set; }

        /// <summary>
        /// 履歴の復元を許可
        /// </summary>
        [JsonPropertyName("AllowRestoreHistories")]
        public bool? AllowRestoreHistories { get; set; }

        /// <summary>
        /// 履歴の物理削除を許可
        /// </summary>
        [JsonPropertyName("AllowPhysicalDeleteHistories")]
        public bool? AllowPhysicalDeleteHistories { get; set; }

        /// <summary>
        /// リンクを非表示
        /// </summary>
        [JsonPropertyName("HideLink")]
        public bool? HideLink { get; set; }

        /// <summary>
        /// Ajaxでレコードを切り替え
        /// </summary>
        [JsonPropertyName("SwitchRecordWithAjax")]
        public bool? SwitchRecordWithAjax { get; set; }

        /// <summary>
        /// 削除時に画像を削除
        /// </summary>
        [JsonPropertyName("DeleteImageWhenDeleting")]
        public bool? DeleteImageWhenDeleting { get; set; }

        #endregion

        #region 列設定

        /// <summary>
        /// 一覧に表示する列
        /// </summary>
        [JsonPropertyName("GridColumns")]
        public List<string>? GridColumns { get; set; }

        /// <summary>
        /// フィルタに表示する列
        /// </summary>
        [JsonPropertyName("FilterColumns")]
        public List<string>? FilterColumns { get; set; }

        /// <summary>
        /// エディタに表示する列（タブごと）
        /// </summary>
        [JsonPropertyName("EditorColumnHash")]
        public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

        /// <summary>
        /// タイトルに使用する列
        /// </summary>
        [JsonPropertyName("TitleColumns")]
        public List<string>? TitleColumns { get; set; }

        /// <summary>
        /// リンクに表示する列
        /// </summary>
        [JsonPropertyName("LinkColumns")]
        public List<string>? LinkColumns { get; set; }

        /// <summary>
        /// 履歴に表示する列
        /// </summary>
        [JsonPropertyName("HistoryColumns")]
        public List<string>? HistoryColumns { get; set; }

        /// <summary>
        /// 移動先
        /// </summary>
        [JsonPropertyName("MoveTargets")]
        public List<long>? MoveTargets { get; set; }

        /// <summary>
        /// 列の詳細設定
        /// </summary>
        [JsonPropertyName("Columns")]
        public List<SiteSettingsColumn>? Columns { get; set; }

        /// <summary>
        /// タイトルの区切り文字
        /// </summary>
        [JsonPropertyName("TitleSeparator")]
        public string? TitleSeparator { get; set; }

        #endregion

        #region タブ・セクション設定

        /// <summary>
        /// 一般タブのラベルテキスト
        /// </summary>
        [JsonPropertyName("GeneralTabLabelText")]
        public string? GeneralTabLabelText { get; set; }

        /// <summary>
        /// タブの最新ID
        /// </summary>
        [JsonPropertyName("TabLatestId")]
        public int? TabLatestId { get; set; }

        /// <summary>
        /// タブ設定
        /// </summary>
        [JsonPropertyName("Tabs")]
        public List<Tab>? Tabs { get; set; }

        /// <summary>
        /// セクションの最新ID
        /// </summary>
        [JsonPropertyName("SectionLatestId")]
        public int? SectionLatestId { get; set; }

        /// <summary>
        /// セクション設定
        /// </summary>
        [JsonPropertyName("Sections")]
        public List<Section>? Sections { get; set; }

        #endregion

        #region 集計・リンク・サマリ設定

        /// <summary>
        /// 集計設定
        /// </summary>
        [JsonPropertyName("Aggregations")]
        public List<Aggregation>? Aggregations { get; set; }

        /// <summary>
        /// リンク設定
        /// </summary>
        [JsonPropertyName("Links")]
        public List<Link>? Links { get; set; }

        /// <summary>
        /// サマリ設定
        /// </summary>
        [JsonPropertyName("Summaries")]
        public List<Summary>? Summaries { get; set; }

        /// <summary>
        /// 計算式設定
        /// </summary>
        [JsonPropertyName("Formulas")]
        public List<FormulaSet>? Formulas { get; set; }

        #endregion

        #region ビュー設定

        /// <summary>
        /// ビューの最新ID
        /// </summary>
        [JsonPropertyName("ViewLatestId")]
        public int? ViewLatestId { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonPropertyName("Views")]
        public List<SiteSettingsView>? Views { get; set; }

        /// <summary>
        /// ビューの保存方法
        /// </summary>
        [JsonPropertyName("SaveViewType")]
        public int? SaveViewType { get; set; }

        #endregion

        #region 通知・リマインダ設定

        /// <summary>
        /// 通知設定
        /// </summary>
        [JsonPropertyName("Notifications")]
        public List<Notification>? Notifications { get; set; }

        /// <summary>
        /// リマインダ設定
        /// </summary>
        [JsonPropertyName("Reminders")]
        public List<Reminder>? Reminders { get; set; }

        #endregion

        #region インポート・エクスポート設定

        /// <summary>
        /// インポートのエンコーディング
        /// </summary>
        [JsonPropertyName("ImportEncoding")]
        public string? ImportEncoding { get; set; }

        /// <summary>
        /// 更新可能なインポート
        /// </summary>
        [JsonPropertyName("UpdatableImport")]
        public bool? UpdatableImport { get; set; }

        /// <summary>
        /// デフォルトのインポートキー
        /// </summary>
        [JsonPropertyName("DefaultImportKey")]
        public string? DefaultImportKey { get; set; }

        /// <summary>
        /// null値のインポートを拒否
        /// </summary>
        [JsonPropertyName("RejectNullImport")]
        public bool? RejectNullImport { get; set; }

        /// <summary>
        /// エクスポート設定
        /// </summary>
        [JsonPropertyName("Exports")]
        public List<Export>? Exports { get; set; }

        /// <summary>
        /// 標準エクスポートを許可
        /// </summary>
        [JsonPropertyName("AllowStandardExport")]
        public bool? AllowStandardExport { get; set; }

        #endregion

        #region 表示機能の有効/無効

        /// <summary>
        /// カレンダーを有効にする
        /// </summary>
        [JsonPropertyName("EnableCalendar")]
        public bool? EnableCalendar { get; set; }

        /// <summary>
        /// カレンダーの種類
        /// </summary>
        [JsonPropertyName("CalendarType")]
        public int? CalendarType { get; set; }

        /// <summary>
        /// クロス集計を有効にする
        /// </summary>
        [JsonPropertyName("EnableCrosstab")]
        public bool? EnableCrosstab { get; set; }

        /// <summary>
        /// クロス集計グラフを非表示
        /// </summary>
        [JsonPropertyName("NoDisplayCrosstabGraph")]
        public bool? NoDisplayCrosstabGraph { get; set; }

        /// <summary>
        /// ガントチャートを有効にする
        /// </summary>
        [JsonPropertyName("EnableGantt")]
        public bool? EnableGantt { get; set; }

        /// <summary>
        /// ガントチャートに進捗率を表示
        /// </summary>
        [JsonPropertyName("ShowGanttProgressRate")]
        public bool? ShowGanttProgressRate { get; set; }

        /// <summary>
        /// バーンダウンチャートを有効にする
        /// </summary>
        [JsonPropertyName("EnableBurnDown")]
        public bool? EnableBurnDown { get; set; }

        /// <summary>
        /// 時系列チャートを有効にする
        /// </summary>
        [JsonPropertyName("EnableTimeSeries")]
        public bool? EnableTimeSeries { get; set; }

        /// <summary>
        /// 分析を有効にする
        /// </summary>
        [JsonPropertyName("EnableAnaly")]
        public bool? EnableAnaly { get; set; }

        /// <summary>
        /// カンバンを有効にする
        /// </summary>
        [JsonPropertyName("EnableKamban")]
        public bool? EnableKamban { get; set; }

        /// <summary>
        /// 画像ライブラリを有効にする
        /// </summary>
        [JsonPropertyName("EnableImageLib")]
        public bool? EnableImageLib { get; set; }

        /// <summary>
        /// 画像ライブラリのページサイズ
        /// </summary>
        [JsonPropertyName("ImageLibPageSize")]
        public int? ImageLibPageSize { get; set; }

        #endregion

        #region フィルタ設定

        /// <summary>
        /// フィルタボタンを使用
        /// </summary>
        [JsonPropertyName("UseFilterButton")]
        public bool? UseFilterButton { get; set; }

        /// <summary>
        /// フィルタエリアを使用
        /// </summary>
        [JsonPropertyName("UseFiltersArea")]
        public bool? UseFiltersArea { get; set; }

        /// <summary>
        /// 一覧ヘッダフィルタを使用
        /// </summary>
        [JsonPropertyName("UseGridHeaderFilters")]
        public bool? UseGridHeaderFilters { get; set; }

        /// <summary>
        /// 否定フィルタを使用
        /// </summary>
        [JsonPropertyName("UseNegativeFilters")]
        public bool? UseNegativeFilters { get; set; }

        /// <summary>
        /// 関連列フィルタを使用
        /// </summary>
        [JsonPropertyName("UseRelatingColumnsOnFilter")]
        public bool? UseRelatingColumnsOnFilter { get; set; }

        /// <summary>
        /// 未完了フィルタを使用
        /// </summary>
        [JsonPropertyName("UseIncompleteFilter")]
        public bool? UseIncompleteFilter { get; set; }

        /// <summary>
        /// 自分のフィルタを使用
        /// </summary>
        [JsonPropertyName("UseOwnFilter")]
        public bool? UseOwnFilter { get; set; }

        /// <summary>
        /// 近く完了フィルタを使用
        /// </summary>
        [JsonPropertyName("UseNearCompletionTimeFilter")]
        public bool? UseNearCompletionTimeFilter { get; set; }

        /// <summary>
        /// 遅延フィルタを使用
        /// </summary>
        [JsonPropertyName("UseDelayFilter")]
        public bool? UseDelayFilter { get; set; }

        /// <summary>
        /// 期限超過フィルタを使用
        /// </summary>
        [JsonPropertyName("UseOverdueFilter")]
        public bool? UseOverdueFilter { get; set; }

        /// <summary>
        /// 検索フィルタを使用
        /// </summary>
        [JsonPropertyName("UseSearchFilter")]
        public bool? UseSearchFilter { get; set; }

        #endregion

        #region 検索設定

        /// <summary>
        /// 検索の種類
        /// </summary>
        [JsonPropertyName("SearchType")]
        public int? SearchType { get; set; }

        /// <summary>
        /// 全文検索にパンくずリストを含める
        /// </summary>
        [JsonPropertyName("FullTextIncludeBreadcrumb")]
        public bool? FullTextIncludeBreadcrumb { get; set; }

        /// <summary>
        /// 全文検索にサイトIDを含める
        /// </summary>
        [JsonPropertyName("FullTextIncludeSiteId")]
        public bool? FullTextIncludeSiteId { get; set; }

        /// <summary>
        /// 全文検索にサイトタイトルを含める
        /// </summary>
        [JsonPropertyName("FullTextIncludeSiteTitle")]
        public bool? FullTextIncludeSiteTitle { get; set; }

        /// <summary>
        /// 全文検索に含めるメール数
        /// </summary>
        [JsonPropertyName("FullTextNumberOfMails")]
        public int? FullTextNumberOfMails { get; set; }

        #endregion

        #region スタイル・スクリプト・HTML設定

        /// <summary>
        /// スタイル設定
        /// </summary>
        [JsonPropertyName("Styles")]
        public List<Style>? Styles { get; set; }

        /// <summary>
        /// スクリプト設定
        /// </summary>
        [JsonPropertyName("Scripts")]
        public List<Script>? Scripts { get; set; }

        /// <summary>
        /// HTML設定
        /// </summary>
        [JsonPropertyName("Htmls")]
        public List<Html>? Htmls { get; set; }

        /// <summary>
        /// サーバスクリプト設定
        /// </summary>
        [JsonPropertyName("ServerScripts")]
        public List<ServerScript>? ServerScripts { get; set; }

        /// <summary>
        /// スタイルを全て無効化
        /// </summary>
        [JsonPropertyName("StylesAllDisabled")]
        public bool? StylesAllDisabled { get; set; }

        /// <summary>
        /// スクリプトを全て無効化
        /// </summary>
        [JsonPropertyName("ScriptsAllDisabled")]
        public bool? ScriptsAllDisabled { get; set; }

        /// <summary>
        /// HTMLを全て無効化
        /// </summary>
        [JsonPropertyName("HtmlsAllDisabled")]
        public bool? HtmlsAllDisabled { get; set; }

        /// <summary>
        /// サーバスクリプトを全て無効化
        /// </summary>
        [JsonPropertyName("ServerScriptsAllDisabled")]
        public bool? ServerScriptsAllDisabled { get; set; }

        /// <summary>
        /// 拡張ヘッダ
        /// </summary>
        [JsonPropertyName("ExtendedHeader")]
        public string? ExtendedHeader { get; set; }

        #endregion

        #region プロセス設定

        /// <summary>
        /// プロセス設定
        /// </summary>
        [JsonPropertyName("Processes")]
        public List<Process>? Processes { get; set; }

        /// <summary>
        /// ステータスコントロール設定
        /// </summary>
        [JsonPropertyName("StatusControls")]
        public List<StatusControl>? StatusControls { get; set; }

        /// <summary>
        /// 計算式ログを出力
        /// </summary>
        [JsonPropertyName("OutputFormulaLogs")]
        public bool? OutputFormulaLogs { get; set; }

        /// <summary>
        /// プロセス計算式ログを出力
        /// </summary>
        [JsonPropertyName("ProcessOutputFormulaLogs")]
        public bool? ProcessOutputFormulaLogs { get; set; }

        #endregion

        #region 一括更新・関連列設定

        /// <summary>
        /// 一括更新列設定
        /// </summary>
        [JsonPropertyName("BulkUpdateColumns")]
        public List<BulkUpdateColumn>? BulkUpdateColumns { get; set; }

        /// <summary>
        /// 関連列設定
        /// </summary>
        [JsonPropertyName("RelatingColumns")]
        public List<RelatingColumn>? RelatingColumns { get; set; }

        #endregion

        #region メール設定

        /// <summary>
        /// アドレス帳
        /// </summary>
        [JsonPropertyName("AddressBook")]
        public string? AddressBook { get; set; }

        /// <summary>
        /// デフォルトの宛先
        /// </summary>
        [JsonPropertyName("MailToDefault")]
        public string? MailToDefault { get; set; }

        /// <summary>
        /// デフォルトのCC
        /// </summary>
        [JsonPropertyName("MailCcDefault")]
        public string? MailCcDefault { get; set; }

        /// <summary>
        /// デフォルトのBCC
        /// </summary>
        [JsonPropertyName("MailBccDefault")]
        public string? MailBccDefault { get; set; }

        #endregion

        #region 権限設定

        /// <summary>
        /// 作成時の権限
        /// </summary>
        [JsonPropertyName("PermissionForCreating")]
        public Dictionary<string, long>? PermissionForCreating { get; set; }

        /// <summary>
        /// 更新時の権限
        /// </summary>
        [JsonPropertyName("PermissionForUpdating")]
        public Dictionary<string, long>? PermissionForUpdating { get; set; }

        /// <summary>
        /// 作成時の列アクセス制御
        /// </summary>
        [JsonPropertyName("CreateColumnAccessControls")]
        public List<ColumnAccessControl>? CreateColumnAccessControls { get; set; }

        /// <summary>
        /// 読取時の列アクセス制御
        /// </summary>
        [JsonPropertyName("ReadColumnAccessControls")]
        public List<ColumnAccessControl>? ReadColumnAccessControls { get; set; }

        /// <summary>
        /// 更新時の列アクセス制御
        /// </summary>
        [JsonPropertyName("UpdateColumnAccessControls")]
        public List<ColumnAccessControl>? UpdateColumnAccessControls { get; set; }

        /// <summary>
        /// 読取専用時に非表示
        /// </summary>
        [JsonPropertyName("NoDisplayIfReadOnly")]
        public bool? NoDisplayIfReadOnly { get; set; }

        /// <summary>
        /// サイト作成時に権限を継承しない
        /// </summary>
        [JsonPropertyName("NotInheritPermissionsWhenCreatingSite")]
        public bool? NotInheritPermissionsWhenCreatingSite { get; set; }

        #endregion

        #region サイト統合設定

        /// <summary>
        /// 統合サイト
        /// </summary>
        [JsonPropertyName("IntegratedSites")]
        public List<long>? IntegratedSites { get; set; }

        #endregion

        #region レスポンシブ・ダッシュボード設定

        /// <summary>
        /// レスポンシブ対応
        /// </summary>
        [JsonPropertyName("Responsive")]
        public bool? Responsive { get; set; }

        /// <summary>
        /// ダッシュボードパーツの非同期読み込み
        /// </summary>
        [JsonPropertyName("DashboardPartsAsynchronousLoading")]
        public bool? DashboardPartsAsynchronousLoading { get; set; }

        /// <summary>
        /// ダッシュボードパーツ設定
        /// </summary>
        [JsonPropertyName("DashboardParts")]
        public List<DashboardPart>? DashboardParts { get; set; }

        #endregion

        #region フォーム設定

        /// <summary>
        /// フォーム開始日時
        /// </summary>
        [JsonPropertyName("FormStartDateTime")]
        public string? FormStartDateTime { get; set; }

        /// <summary>
        /// フォーム終了日時
        /// </summary>
        [JsonPropertyName("FormEndDateTime")]
        public string? FormEndDateTime { get; set; }

        /// <summary>
        /// フォーム利用不可メッセージ
        /// </summary>
        [JsonPropertyName("FormUnavailableMessage")]
        public string? FormUnavailableMessage { get; set; }

        /// <summary>
        /// フォーム完了メッセージ
        /// </summary>
        [JsonPropertyName("FormThanksMessage")]
        public string? FormThanksMessage { get; set; }

        #endregion

        #region ガイド設定

        /// <summary>
        /// サイト条件を無効化
        /// </summary>
        [JsonPropertyName("DisableSiteConditions")]
        public bool? DisableSiteConditions { get; set; }

        /// <summary>
        /// ガイドの展開を許可
        /// </summary>
        [JsonPropertyName("GuideAllowExpand")]
        public bool? GuideAllowExpand { get; set; }

        /// <summary>
        /// ガイド展開設定
        /// </summary>
        [JsonPropertyName("GuideExpand")]
        public string? GuideExpand { get; set; }

        #endregion

        #region リンク設定

        /// <summary>
        /// リンクパス展開を有効化
        /// </summary>
        [JsonPropertyName("EnableExpandLinkPath")]
        public bool? EnableExpandLinkPath { get; set; }

        /// <summary>
        /// リンクテーブルビュー
        /// </summary>
        [JsonPropertyName("LinkTableView")]
        public int? LinkTableView { get; set; }

        /// <summary>
        /// リンクページサイズ
        /// </summary>
        [JsonPropertyName("LinkPageSize")]
        public int? LinkPageSize { get; set; }

        #endregion

        #region 作成・更新後のアクション

        /// <summary>
        /// 作成後のアクション種類
        /// </summary>
        [JsonPropertyName("AfterCreateActionType")]
        public int? AfterCreateActionType { get; set; }

        /// <summary>
        /// 更新後のアクション種類
        /// </summary>
        [JsonPropertyName("AfterUpdateActionType")]
        public int? AfterUpdateActionType { get; set; }

        #endregion
    }
}
