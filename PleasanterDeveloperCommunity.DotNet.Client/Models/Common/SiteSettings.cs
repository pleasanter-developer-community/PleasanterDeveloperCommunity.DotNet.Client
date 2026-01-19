using Newtonsoft.Json;
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
        [JsonProperty("Version")]
        public decimal? Version { get; set; }

        #region 一般設定

        /// <summary>
        /// 近く完了する期限（前）の日数
        /// </summary>
        [JsonProperty("NearCompletionTimeBeforeDays")]
        public decimal? NearCompletionTimeBeforeDays { get; set; }

        /// <summary>
        /// 近く完了する期限（後）の日数
        /// </summary>
        [JsonProperty("NearCompletionTimeAfterDays")]
        public decimal? NearCompletionTimeAfterDays { get; set; }

        /// <summary>
        /// 一覧のページサイズ
        /// </summary>
        [JsonProperty("GridPageSize")]
        public int? GridPageSize { get; set; }

        /// <summary>
        /// 一覧のビューID
        /// </summary>
        [JsonProperty("GridView")]
        public int? GridView { get; set; }

        /// <summary>
        /// ビューリセットを許可
        /// </summary>
        [JsonProperty("AllowViewReset")]
        public bool? AllowViewReset { get; set; }

        /// <summary>
        /// 一覧のエディタの種類
        /// </summary>
        [JsonProperty("GridEditorType")]
        public int? GridEditorType { get; set; }

        /// <summary>
        /// 履歴を一覧に表示
        /// </summary>
        [JsonProperty("HistoryOnGrid")]
        public bool? HistoryOnGrid { get; set; }

        /// <summary>
        /// 常に検索条件をリクエスト
        /// </summary>
        [JsonProperty("AlwaysRequestSearchCondition")]
        public bool? AlwaysRequestSearchCondition { get; set; }

        /// <summary>
        /// 編集リンクを無効化
        /// </summary>
        [JsonProperty("DisableLinkToEdit")]
        public bool? DisableLinkToEdit { get; set; }

        /// <summary>
        /// 編集を新しいタブで開く
        /// </summary>
        [JsonProperty("OpenEditInNewTab")]
        public bool? OpenEditInNewTab { get; set; }

        /// <summary>
        /// 週の開始日
        /// </summary>
        [JsonProperty("FirstDayOfWeek")]
        public int? FirstDayOfWeek { get; set; }

        /// <summary>
        /// 年度開始月
        /// </summary>
        [JsonProperty("FirstMonth")]
        public int? FirstMonth { get; set; }

        /// <summary>
        /// 自動バージョンアップの種類
        /// </summary>
        [JsonProperty("AutoVerUpType")]
        public int? AutoVerUpType { get; set; }

        /// <summary>
        /// コメント編集を許可
        /// </summary>
        [JsonProperty("AllowEditingComments")]
        public bool? AllowEditingComments { get; set; }

        /// <summary>
        /// コピーを許可
        /// </summary>
        [JsonProperty("AllowCopy")]
        public bool? AllowCopy { get; set; }

        /// <summary>
        /// 参照コピーを許可
        /// </summary>
        [JsonProperty("AllowReferenceCopy")]
        public bool? AllowReferenceCopy { get; set; }

        /// <summary>
        /// コピー時に追加する文字
        /// </summary>
        [JsonProperty("CharToAddWhenCopying")]
        public string? CharToAddWhenCopying { get; set; }

        /// <summary>
        /// 分割を許可
        /// </summary>
        [JsonProperty("AllowSeparate")]
        public bool? AllowSeparate { get; set; }

        /// <summary>
        /// テーブルロックを許可
        /// </summary>
        [JsonProperty("AllowLockTable")]
        public bool? AllowLockTable { get; set; }

        /// <summary>
        /// 履歴の復元を許可
        /// </summary>
        [JsonProperty("AllowRestoreHistories")]
        public bool? AllowRestoreHistories { get; set; }

        /// <summary>
        /// 履歴の物理削除を許可
        /// </summary>
        [JsonProperty("AllowPhysicalDeleteHistories")]
        public bool? AllowPhysicalDeleteHistories { get; set; }

        /// <summary>
        /// リンクを非表示
        /// </summary>
        [JsonProperty("HideLink")]
        public bool? HideLink { get; set; }

        /// <summary>
        /// Ajaxでレコードを切り替え
        /// </summary>
        [JsonProperty("SwitchRecordWithAjax")]
        public bool? SwitchRecordWithAjax { get; set; }

        /// <summary>
        /// 削除時に画像を削除
        /// </summary>
        [JsonProperty("DeleteImageWhenDeleting")]
        public bool? DeleteImageWhenDeleting { get; set; }

        #endregion

        #region 列設定

        /// <summary>
        /// 一覧に表示する列
        /// </summary>
        [JsonProperty("GridColumns")]
        public List<string>? GridColumns { get; set; }

        /// <summary>
        /// フィルタに表示する列
        /// </summary>
        [JsonProperty("FilterColumns")]
        public List<string>? FilterColumns { get; set; }

        /// <summary>
        /// エディタに表示する列（タブごと）
        /// </summary>
        [JsonProperty("EditorColumnHash")]
        public Dictionary<string, List<string>>? EditorColumnHash { get; set; }

        /// <summary>
        /// タイトルに使用する列
        /// </summary>
        [JsonProperty("TitleColumns")]
        public List<string>? TitleColumns { get; set; }

        /// <summary>
        /// リンクに表示する列
        /// </summary>
        [JsonProperty("LinkColumns")]
        public List<string>? LinkColumns { get; set; }

        /// <summary>
        /// 履歴に表示する列
        /// </summary>
        [JsonProperty("HistoryColumns")]
        public List<string>? HistoryColumns { get; set; }

        /// <summary>
        /// 移動先
        /// </summary>
        [JsonProperty("MoveTargets")]
        public List<long>? MoveTargets { get; set; }

        /// <summary>
        /// 列の詳細設定
        /// </summary>
        [JsonProperty("Columns")]
        public List<SiteSettingsColumn>? Columns { get; set; }

        /// <summary>
        /// タイトルの区切り文字
        /// </summary>
        [JsonProperty("TitleSeparator")]
        public string? TitleSeparator { get; set; }

        #endregion

        #region タブ・セクション設定

        /// <summary>
        /// 一般タブのラベルテキスト
        /// </summary>
        [JsonProperty("GeneralTabLabelText")]
        public string? GeneralTabLabelText { get; set; }

        /// <summary>
        /// タブの最新ID
        /// </summary>
        [JsonProperty("TabLatestId")]
        public int? TabLatestId { get; set; }

        /// <summary>
        /// タブ設定
        /// </summary>
        [JsonProperty("Tabs")]
        public List<Tab>? Tabs { get; set; }

        /// <summary>
        /// セクションの最新ID
        /// </summary>
        [JsonProperty("SectionLatestId")]
        public int? SectionLatestId { get; set; }

        /// <summary>
        /// セクション設定
        /// </summary>
        [JsonProperty("Sections")]
        public List<Section>? Sections { get; set; }

        #endregion

        #region 集計・リンク・サマリ設定

        /// <summary>
        /// 集計設定
        /// </summary>
        [JsonProperty("Aggregations")]
        public List<Aggregation>? Aggregations { get; set; }

        /// <summary>
        /// リンク設定
        /// </summary>
        [JsonProperty("Links")]
        public List<Link>? Links { get; set; }

        /// <summary>
        /// サマリ設定
        /// </summary>
        [JsonProperty("Summaries")]
        public List<Summary>? Summaries { get; set; }

        /// <summary>
        /// 計算式設定
        /// </summary>
        [JsonProperty("Formulas")]
        public List<FormulaSet>? Formulas { get; set; }

        #endregion

        #region ビュー設定

        /// <summary>
        /// ビューの最新ID
        /// </summary>
        [JsonProperty("ViewLatestId")]
        public int? ViewLatestId { get; set; }

        /// <summary>
        /// ビュー設定
        /// </summary>
        [JsonProperty("Views")]
        public List<SiteSettingsView>? Views { get; set; }

        /// <summary>
        /// ビューの保存方法
        /// </summary>
        [JsonProperty("SaveViewType")]
        public int? SaveViewType { get; set; }

        #endregion

        #region 通知・リマインダ設定

        /// <summary>
        /// 通知設定
        /// </summary>
        [JsonProperty("Notifications")]
        public List<Notification>? Notifications { get; set; }

        /// <summary>
        /// リマインダ設定
        /// </summary>
        [JsonProperty("Reminders")]
        public List<Reminder>? Reminders { get; set; }

        #endregion

        #region インポート・エクスポート設定

        /// <summary>
        /// インポートのエンコーディング
        /// </summary>
        [JsonProperty("ImportEncoding")]
        public string? ImportEncoding { get; set; }

        /// <summary>
        /// 更新可能なインポート
        /// </summary>
        [JsonProperty("UpdatableImport")]
        public bool? UpdatableImport { get; set; }

        /// <summary>
        /// デフォルトのインポートキー
        /// </summary>
        [JsonProperty("DefaultImportKey")]
        public string? DefaultImportKey { get; set; }

        /// <summary>
        /// null値のインポートを拒否
        /// </summary>
        [JsonProperty("RejectNullImport")]
        public bool? RejectNullImport { get; set; }

        /// <summary>
        /// エクスポート設定
        /// </summary>
        [JsonProperty("Exports")]
        public List<Export>? Exports { get; set; }

        /// <summary>
        /// 標準エクスポートを許可
        /// </summary>
        [JsonProperty("AllowStandardExport")]
        public bool? AllowStandardExport { get; set; }

        #endregion

        #region 表示機能の有効/無効

        /// <summary>
        /// カレンダーを有効にする
        /// </summary>
        [JsonProperty("EnableCalendar")]
        public bool? EnableCalendar { get; set; }

        /// <summary>
        /// カレンダーの種類
        /// </summary>
        [JsonProperty("CalendarType")]
        public int? CalendarType { get; set; }

        /// <summary>
        /// クロス集計を有効にする
        /// </summary>
        [JsonProperty("EnableCrosstab")]
        public bool? EnableCrosstab { get; set; }

        /// <summary>
        /// クロス集計グラフを非表示
        /// </summary>
        [JsonProperty("NoDisplayCrosstabGraph")]
        public bool? NoDisplayCrosstabGraph { get; set; }

        /// <summary>
        /// ガントチャートを有効にする
        /// </summary>
        [JsonProperty("EnableGantt")]
        public bool? EnableGantt { get; set; }

        /// <summary>
        /// ガントチャートに進捗率を表示
        /// </summary>
        [JsonProperty("ShowGanttProgressRate")]
        public bool? ShowGanttProgressRate { get; set; }

        /// <summary>
        /// バーンダウンチャートを有効にする
        /// </summary>
        [JsonProperty("EnableBurnDown")]
        public bool? EnableBurnDown { get; set; }

        /// <summary>
        /// 時系列チャートを有効にする
        /// </summary>
        [JsonProperty("EnableTimeSeries")]
        public bool? EnableTimeSeries { get; set; }

        /// <summary>
        /// 分析を有効にする
        /// </summary>
        [JsonProperty("EnableAnaly")]
        public bool? EnableAnaly { get; set; }

        /// <summary>
        /// カンバンを有効にする
        /// </summary>
        [JsonProperty("EnableKamban")]
        public bool? EnableKamban { get; set; }

        /// <summary>
        /// 画像ライブラリを有効にする
        /// </summary>
        [JsonProperty("EnableImageLib")]
        public bool? EnableImageLib { get; set; }

        /// <summary>
        /// 画像ライブラリのページサイズ
        /// </summary>
        [JsonProperty("ImageLibPageSize")]
        public int? ImageLibPageSize { get; set; }

        #endregion

        #region フィルタ設定

        /// <summary>
        /// フィルタボタンを使用
        /// </summary>
        [JsonProperty("UseFilterButton")]
        public bool? UseFilterButton { get; set; }

        /// <summary>
        /// フィルタエリアを使用
        /// </summary>
        [JsonProperty("UseFiltersArea")]
        public bool? UseFiltersArea { get; set; }

        /// <summary>
        /// 一覧ヘッダフィルタを使用
        /// </summary>
        [JsonProperty("UseGridHeaderFilters")]
        public bool? UseGridHeaderFilters { get; set; }

        /// <summary>
        /// 否定フィルタを使用
        /// </summary>
        [JsonProperty("UseNegativeFilters")]
        public bool? UseNegativeFilters { get; set; }

        /// <summary>
        /// 関連列フィルタを使用
        /// </summary>
        [JsonProperty("UseRelatingColumnsOnFilter")]
        public bool? UseRelatingColumnsOnFilter { get; set; }

        /// <summary>
        /// 未完了フィルタを使用
        /// </summary>
        [JsonProperty("UseIncompleteFilter")]
        public bool? UseIncompleteFilter { get; set; }

        /// <summary>
        /// 自分のフィルタを使用
        /// </summary>
        [JsonProperty("UseOwnFilter")]
        public bool? UseOwnFilter { get; set; }

        /// <summary>
        /// 近く完了フィルタを使用
        /// </summary>
        [JsonProperty("UseNearCompletionTimeFilter")]
        public bool? UseNearCompletionTimeFilter { get; set; }

        /// <summary>
        /// 遅延フィルタを使用
        /// </summary>
        [JsonProperty("UseDelayFilter")]
        public bool? UseDelayFilter { get; set; }

        /// <summary>
        /// 期限超過フィルタを使用
        /// </summary>
        [JsonProperty("UseOverdueFilter")]
        public bool? UseOverdueFilter { get; set; }

        /// <summary>
        /// 検索フィルタを使用
        /// </summary>
        [JsonProperty("UseSearchFilter")]
        public bool? UseSearchFilter { get; set; }

        #endregion

        #region 検索設定

        /// <summary>
        /// 検索の種類
        /// </summary>
        [JsonProperty("SearchType")]
        public int? SearchType { get; set; }

        /// <summary>
        /// 全文検索にパンくずリストを含める
        /// </summary>
        [JsonProperty("FullTextIncludeBreadcrumb")]
        public bool? FullTextIncludeBreadcrumb { get; set; }

        /// <summary>
        /// 全文検索にサイトIDを含める
        /// </summary>
        [JsonProperty("FullTextIncludeSiteId")]
        public bool? FullTextIncludeSiteId { get; set; }

        /// <summary>
        /// 全文検索にサイトタイトルを含める
        /// </summary>
        [JsonProperty("FullTextIncludeSiteTitle")]
        public bool? FullTextIncludeSiteTitle { get; set; }

        /// <summary>
        /// 全文検索に含めるメール数
        /// </summary>
        [JsonProperty("FullTextNumberOfMails")]
        public int? FullTextNumberOfMails { get; set; }

        #endregion

        #region スタイル・スクリプト・HTML設定

        /// <summary>
        /// スタイル設定
        /// </summary>
        [JsonProperty("Styles")]
        public List<Style>? Styles { get; set; }

        /// <summary>
        /// スクリプト設定
        /// </summary>
        [JsonProperty("Scripts")]
        public List<Script>? Scripts { get; set; }

        /// <summary>
        /// HTML設定
        /// </summary>
        [JsonProperty("Htmls")]
        public List<Html>? Htmls { get; set; }

        /// <summary>
        /// サーバスクリプト設定
        /// </summary>
        [JsonProperty("ServerScripts")]
        public List<ServerScript>? ServerScripts { get; set; }

        /// <summary>
        /// スタイルを全て無効化
        /// </summary>
        [JsonProperty("StylesAllDisabled")]
        public bool? StylesAllDisabled { get; set; }

        /// <summary>
        /// スクリプトを全て無効化
        /// </summary>
        [JsonProperty("ScriptsAllDisabled")]
        public bool? ScriptsAllDisabled { get; set; }

        /// <summary>
        /// HTMLを全て無効化
        /// </summary>
        [JsonProperty("HtmlsAllDisabled")]
        public bool? HtmlsAllDisabled { get; set; }

        /// <summary>
        /// サーバスクリプトを全て無効化
        /// </summary>
        [JsonProperty("ServerScriptsAllDisabled")]
        public bool? ServerScriptsAllDisabled { get; set; }

        /// <summary>
        /// 拡張ヘッダ
        /// </summary>
        [JsonProperty("ExtendedHeader")]
        public string? ExtendedHeader { get; set; }

        #endregion

        #region プロセス設定

        /// <summary>
        /// プロセス設定
        /// </summary>
        [JsonProperty("Processes")]
        public List<Process>? Processes { get; set; }

        /// <summary>
        /// ステータスコントロール設定
        /// </summary>
        [JsonProperty("StatusControls")]
        public List<StatusControl>? StatusControls { get; set; }

        /// <summary>
        /// 計算式ログを出力
        /// </summary>
        [JsonProperty("OutputFormulaLogs")]
        public bool? OutputFormulaLogs { get; set; }

        /// <summary>
        /// プロセス計算式ログを出力
        /// </summary>
        [JsonProperty("ProcessOutputFormulaLogs")]
        public bool? ProcessOutputFormulaLogs { get; set; }

        #endregion

        #region 一括更新・関連列設定

        /// <summary>
        /// 一括更新列設定
        /// </summary>
        [JsonProperty("BulkUpdateColumns")]
        public List<BulkUpdateColumn>? BulkUpdateColumns { get; set; }

        /// <summary>
        /// 関連列設定
        /// </summary>
        [JsonProperty("RelatingColumns")]
        public List<RelatingColumn>? RelatingColumns { get; set; }

        #endregion

        #region メール設定

        /// <summary>
        /// アドレス帳
        /// </summary>
        [JsonProperty("AddressBook")]
        public string? AddressBook { get; set; }

        /// <summary>
        /// デフォルトの宛先
        /// </summary>
        [JsonProperty("MailToDefault")]
        public string? MailToDefault { get; set; }

        /// <summary>
        /// デフォルトのCC
        /// </summary>
        [JsonProperty("MailCcDefault")]
        public string? MailCcDefault { get; set; }

        /// <summary>
        /// デフォルトのBCC
        /// </summary>
        [JsonProperty("MailBccDefault")]
        public string? MailBccDefault { get; set; }

        #endregion

        #region 権限設定

        /// <summary>
        /// 作成時の権限
        /// </summary>
        [JsonProperty("PermissionForCreating")]
        public Dictionary<string, long>? PermissionForCreating { get; set; }

        /// <summary>
        /// 更新時の権限
        /// </summary>
        [JsonProperty("PermissionForUpdating")]
        public Dictionary<string, long>? PermissionForUpdating { get; set; }

        /// <summary>
        /// 作成時の列アクセス制御
        /// </summary>
        [JsonProperty("CreateColumnAccessControls")]
        public List<ColumnAccessControl>? CreateColumnAccessControls { get; set; }

        /// <summary>
        /// 読取時の列アクセス制御
        /// </summary>
        [JsonProperty("ReadColumnAccessControls")]
        public List<ColumnAccessControl>? ReadColumnAccessControls { get; set; }

        /// <summary>
        /// 更新時の列アクセス制御
        /// </summary>
        [JsonProperty("UpdateColumnAccessControls")]
        public List<ColumnAccessControl>? UpdateColumnAccessControls { get; set; }

        /// <summary>
        /// 読取専用時に非表示
        /// </summary>
        [JsonProperty("NoDisplayIfReadOnly")]
        public bool? NoDisplayIfReadOnly { get; set; }

        /// <summary>
        /// サイト作成時に権限を継承しない
        /// </summary>
        [JsonProperty("NotInheritPermissionsWhenCreatingSite")]
        public bool? NotInheritPermissionsWhenCreatingSite { get; set; }

        #endregion

        #region サイト統合設定

        /// <summary>
        /// 統合サイト
        /// </summary>
        [JsonProperty("IntegratedSites")]
        public List<long>? IntegratedSites { get; set; }

        #endregion

        #region レスポンシブ・ダッシュボード設定

        /// <summary>
        /// レスポンシブ対応
        /// </summary>
        [JsonProperty("Responsive")]
        public bool? Responsive { get; set; }

        /// <summary>
        /// ダッシュボードパーツの非同期読み込み
        /// </summary>
        [JsonProperty("DashboardPartsAsynchronousLoading")]
        public bool? DashboardPartsAsynchronousLoading { get; set; }

        /// <summary>
        /// ダッシュボードパーツ設定
        /// </summary>
        [JsonProperty("DashboardParts")]
        public List<DashboardPart>? DashboardParts { get; set; }

        #endregion

        #region フォーム設定

        /// <summary>
        /// フォーム開始日時
        /// </summary>
        [JsonProperty("FormStartDateTime")]
        public string? FormStartDateTime { get; set; }

        /// <summary>
        /// フォーム終了日時
        /// </summary>
        [JsonProperty("FormEndDateTime")]
        public string? FormEndDateTime { get; set; }

        /// <summary>
        /// フォーム利用不可メッセージ
        /// </summary>
        [JsonProperty("FormUnavailableMessage")]
        public string? FormUnavailableMessage { get; set; }

        /// <summary>
        /// フォーム完了メッセージ
        /// </summary>
        [JsonProperty("FormThanksMessage")]
        public string? FormThanksMessage { get; set; }

        #endregion

        #region ガイド設定

        /// <summary>
        /// サイト条件を無効化
        /// </summary>
        [JsonProperty("DisableSiteConditions")]
        public bool? DisableSiteConditions { get; set; }

        /// <summary>
        /// ガイドの展開を許可
        /// </summary>
        [JsonProperty("GuideAllowExpand")]
        public bool? GuideAllowExpand { get; set; }

        /// <summary>
        /// ガイド展開設定
        /// </summary>
        [JsonProperty("GuideExpand")]
        public string? GuideExpand { get; set; }

        #endregion

        #region リンク設定

        /// <summary>
        /// リンクパス展開を有効化
        /// </summary>
        [JsonProperty("EnableExpandLinkPath")]
        public bool? EnableExpandLinkPath { get; set; }

        /// <summary>
        /// リンクテーブルビュー
        /// </summary>
        [JsonProperty("LinkTableView")]
        public int? LinkTableView { get; set; }

        /// <summary>
        /// リンクページサイズ
        /// </summary>
        [JsonProperty("LinkPageSize")]
        public int? LinkPageSize { get; set; }

        #endregion

        #region 作成・更新後のアクション

        /// <summary>
        /// 作成後のアクション種類
        /// </summary>
        [JsonProperty("AfterCreateActionType")]
        public int? AfterCreateActionType { get; set; }

        /// <summary>
        /// 更新後のアクション種類
        /// </summary>
        [JsonProperty("AfterUpdateActionType")]
        public int? AfterUpdateActionType { get; set; }

        #endregion
    }
}
