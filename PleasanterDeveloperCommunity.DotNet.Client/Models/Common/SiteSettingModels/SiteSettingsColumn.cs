using Newtonsoft.Json;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// サイト設定の列定義を表すクラスです。
    /// </summary>
    public class SiteSettingsColumn
    {
        /// <summary>
        /// 列名
        /// </summary>
        [JsonProperty("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonProperty("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 一覧用ラベルテキスト
        /// </summary>
        [JsonProperty("GridLabelText")]
        public string? GridLabelText { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [JsonProperty("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// 入力ガイド
        /// </summary>
        [JsonProperty("InputGuide")]
        public string? InputGuide { get; set; }

        /// <summary>
        /// 選択肢テキスト
        /// </summary>
        [JsonProperty("ChoicesText")]
        public string? ChoicesText { get; set; }

        /// <summary>
        /// 検索を使用
        /// </summary>
        [JsonProperty("UseSearch")]
        public bool? UseSearch { get; set; }

        /// <summary>
        /// 複数選択
        /// </summary>
        [JsonProperty("MultipleSelections")]
        public bool? MultipleSelections { get; set; }

        /// <summary>
        /// 空白選択肢を挿入しない
        /// </summary>
        [JsonProperty("NotInsertBlankChoice")]
        public bool? NotInsertBlankChoice { get; set; }

        /// <summary>
        /// デフォルト入力値
        /// </summary>
        [JsonProperty("DefaultInput")]
        public string? DefaultInput { get; set; }

        /// <summary>
        /// インポートキー
        /// </summary>
        [JsonProperty("ImportKey")]
        public bool? ImportKey { get; set; }

        /// <summary>
        /// 一覧フォーマット
        /// </summary>
        [JsonProperty("GridFormat")]
        public string? GridFormat { get; set; }

        /// <summary>
        /// エディタフォーマット
        /// </summary>
        [JsonProperty("EditorFormat")]
        public string? EditorFormat { get; set; }

        /// <summary>
        /// エクスポートフォーマット
        /// </summary>
        [JsonProperty("ExportFormat")]
        public string? ExportFormat { get; set; }

        /// <summary>
        /// コントロールの種類
        /// </summary>
        [JsonProperty("ControlType")]
        public string? ControlType { get; set; }

        /// <summary>
        /// 選択肢コントロールの種類
        /// </summary>
        [JsonProperty("ChoicesControlType")]
        public string? ChoicesControlType { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        [JsonProperty("Format")]
        public string? Format { get; set; }

        /// <summary>
        /// 折り返しなし
        /// </summary>
        [JsonProperty("NoWrap")]
        public bool? NoWrap { get; set; }

        /// <summary>
        /// 非表示
        /// </summary>
        [JsonProperty("Hide")]
        public bool? Hide { get; set; }

        /// <summary>
        /// 自動採番フォーマット
        /// </summary>
        [JsonProperty("AutoNumberingFormat")]
        public string? AutoNumberingFormat { get; set; }

        /// <summary>
        /// 自動採番リセット種類
        /// </summary>
        [JsonProperty("AutoNumberingResetType")]
        public int? AutoNumberingResetType { get; set; }

        /// <summary>
        /// 自動採番のデフォルト値
        /// </summary>
        [JsonProperty("AutoNumberingDefault")]
        public int? AutoNumberingDefault { get; set; }

        /// <summary>
        /// 自動採番のステップ
        /// </summary>
        [JsonProperty("AutoNumberingStep")]
        public int? AutoNumberingStep { get; set; }

        /// <summary>
        /// 拡張セルCSS
        /// </summary>
        [JsonProperty("ExtendedCellCss")]
        public string? ExtendedCellCss { get; set; }

        /// <summary>
        /// 拡張フィールドCSS
        /// </summary>
        [JsonProperty("ExtendedFieldCss")]
        public string? ExtendedFieldCss { get; set; }

        /// <summary>
        /// 拡張コントロールCSS
        /// </summary>
        [JsonProperty("ExtendedControlCss")]
        public string? ExtendedControlCss { get; set; }

        /// <summary>
        /// セクション
        /// </summary>
        [JsonProperty("Section")]
        public string? Section { get; set; }

        /// <summary>
        /// セル固定
        /// </summary>
        [JsonProperty("CellSticky")]
        public bool? CellSticky { get; set; }

        /// <summary>
        /// セル幅
        /// </summary>
        [JsonProperty("CellWidth")]
        public int? CellWidth { get; set; }

        /// <summary>
        /// セル折り返し
        /// </summary>
        [JsonProperty("CellWordWrap")]
        public bool? CellWordWrap { get; set; }

        /// <summary>
        /// 一覧デザイン
        /// </summary>
        [JsonProperty("GridDesign")]
        public string? GridDesign { get; set; }

        /// <summary>
        /// 必須入力の検証
        /// </summary>
        [JsonProperty("ValidateRequired")]
        public bool? ValidateRequired { get; set; }

        /// <summary>
        /// 数値の検証
        /// </summary>
        [JsonProperty("ValidateNumber")]
        public bool? ValidateNumber { get; set; }

        /// <summary>
        /// 日付の検証
        /// </summary>
        [JsonProperty("ValidateDate")]
        public bool? ValidateDate { get; set; }

        /// <summary>
        /// メールの検証
        /// </summary>
        [JsonProperty("ValidateEmail")]
        public bool? ValidateEmail { get; set; }

        /// <summary>
        /// 一致の検証対象
        /// </summary>
        [JsonProperty("ValidateEqualTo")]
        public string? ValidateEqualTo { get; set; }

        /// <summary>
        /// 最大長の検証
        /// </summary>
        [JsonProperty("ValidateMaxLength")]
        public int? ValidateMaxLength { get; set; }

        /// <summary>
        /// 最大長
        /// </summary>
        [JsonProperty("MaxLength")]
        public decimal? MaxLength { get; set; }

        /// <summary>
        /// クライアント正規表現検証
        /// </summary>
        [JsonProperty("ClientRegexValidation")]
        public string? ClientRegexValidation { get; set; }

        /// <summary>
        /// サーバ正規表現検証
        /// </summary>
        [JsonProperty("ServerRegexValidation")]
        public string? ServerRegexValidation { get; set; }

        /// <summary>
        /// 正規表現検証メッセージ
        /// </summary>
        [JsonProperty("RegexValidationMessage")]
        public string? RegexValidationMessage { get; set; }

        /// <summary>
        /// フィールド前の拡張HTML
        /// </summary>
        [JsonProperty("ExtendedHtmlBeforeField")]
        public string? ExtendedHtmlBeforeField { get; set; }

        /// <summary>
        /// ラベル前の拡張HTML
        /// </summary>
        [JsonProperty("ExtendedHtmlBeforeLabel")]
        public string? ExtendedHtmlBeforeLabel { get; set; }

        /// <summary>
        /// ラベルとコントロール間の拡張HTML
        /// </summary>
        [JsonProperty("ExtendedHtmlBetweenLabelAndControl")]
        public string? ExtendedHtmlBetweenLabelAndControl { get; set; }

        /// <summary>
        /// コントロール後の拡張HTML
        /// </summary>
        [JsonProperty("ExtendedHtmlAfterControl")]
        public string? ExtendedHtmlAfterControl { get; set; }

        /// <summary>
        /// フィールド後の拡張HTML
        /// </summary>
        [JsonProperty("ExtendedHtmlAfterField")]
        public string? ExtendedHtmlAfterField { get; set; }

        /// <summary>
        /// 多言語ラベルテキスト
        /// </summary>
        [JsonProperty("MultilingualLabelText")]
        public string? MultilingualLabelText { get; set; }

        /// <summary>
        /// NULL許容
        /// </summary>
        [JsonProperty("Nullable")]
        public bool? Nullable { get; set; }

        /// <summary>
        /// 単位
        /// </summary>
        [JsonProperty("Unit")]
        public string? Unit { get; set; }

        /// <summary>
        /// 小数点以下桁数
        /// </summary>
        [JsonProperty("DecimalPlaces")]
        public int? DecimalPlaces { get; set; }

        /// <summary>
        /// 丸め種類
        /// </summary>
        [JsonProperty("RoundingType")]
        public int? RoundingType { get; set; }

        /// <summary>
        /// 最小値
        /// </summary>
        [JsonProperty("Min")]
        public decimal? Min { get; set; }

        /// <summary>
        /// 最大値
        /// </summary>
        [JsonProperty("Max")]
        public decimal? Max { get; set; }

        /// <summary>
        /// ステップ
        /// </summary>
        [JsonProperty("Step")]
        public decimal? Step { get; set; }

        /// <summary>
        /// 重複禁止
        /// </summary>
        [JsonProperty("NoDuplication")]
        public bool? NoDuplication { get; set; }

        /// <summary>
        /// 重複時のメッセージ
        /// </summary>
        [JsonProperty("MessageWhenDuplicated")]
        public string? MessageWhenDuplicated { get; set; }

        /// <summary>
        /// デフォルトでコピー
        /// </summary>
        [JsonProperty("CopyByDefault")]
        public bool? CopyByDefault { get; set; }

        /// <summary>
        /// エディタ読取専用
        /// </summary>
        [JsonProperty("EditorReadOnly")]
        public bool? EditorReadOnly { get; set; }

        /// <summary>
        /// 自動ポストバック
        /// </summary>
        [JsonProperty("AutoPostBack")]
        public bool? AutoPostBack { get; set; }

        /// <summary>
        /// 自動ポストバック時に返却する列
        /// </summary>
        [JsonProperty("ColumnsReturnedWhenAutomaticPostback")]
        public string? ColumnsReturnedWhenAutomaticPostback { get; set; }

        /// <summary>
        /// 一括更新を許可
        /// </summary>
        [JsonProperty("AllowBulkUpdate")]
        public bool? AllowBulkUpdate { get; set; }

        /// <summary>
        /// 添付ファイルの削除を許可
        /// </summary>
        [JsonProperty("AllowDeleteAttachments")]
        public bool? AllowDeleteAttachments { get; set; }

        /// <summary>
        /// 既存履歴を削除しない
        /// </summary>
        [JsonProperty("NotDeleteExistHistory")]
        public bool? NotDeleteExistHistory { get; set; }

        /// <summary>
        /// 画像を許可
        /// </summary>
        [JsonProperty("AllowImage")]
        public bool? AllowImage { get; set; }

        /// <summary>
        /// サムネイル制限サイズ
        /// </summary>
        [JsonProperty("ThumbnailLimitSize")]
        public decimal? ThumbnailLimitSize { get; set; }

        /// <summary>
        /// フィールドCSS
        /// </summary>
        [JsonProperty("FieldCss")]
        public string? FieldCss { get; set; }

        /// <summary>
        /// ビューア切替種類
        /// </summary>
        [JsonProperty("ViewerSwitchingType")]
        public int? ViewerSwitchingType { get; set; }

        /// <summary>
        /// テキスト配置
        /// </summary>
        [JsonProperty("TextAlign")]
        public int? TextAlign { get; set; }

        /// <summary>
        /// リンク
        /// </summary>
        [JsonProperty("Link")]
        public bool? Link { get; set; }

        /// <summary>
        /// チェックフィルタコントロール種類
        /// </summary>
        [JsonProperty("CheckFilterControlType")]
        public int? CheckFilterControlType { get; set; }

        /// <summary>
        /// 数値フィルタ最小値
        /// </summary>
        [JsonProperty("NumFilterMin")]
        public decimal? NumFilterMin { get; set; }

        /// <summary>
        /// 数値フィルタ最大値
        /// </summary>
        [JsonProperty("NumFilterMax")]
        public decimal? NumFilterMax { get; set; }

        /// <summary>
        /// 数値フィルタステップ
        /// </summary>
        [JsonProperty("NumFilterStep")]
        public decimal? NumFilterStep { get; set; }

        /// <summary>
        /// 日付フィルタ設定モード
        /// </summary>
        [JsonProperty("DateFilterSetMode")]
        public int? DateFilterSetMode { get; set; }

        /// <summary>
        /// 検索種類
        /// </summary>
        [JsonProperty("SearchType")]
        public int? SearchType { get; set; }

        /// <summary>
        /// 全文検索種類
        /// </summary>
        [JsonProperty("FullTextType")]
        public int? FullTextType { get; set; }

        /// <summary>
        /// 日付フィルタ最小スパン
        /// </summary>
        [JsonProperty("DateFilterMinSpan")]
        public int? DateFilterMinSpan { get; set; }

        /// <summary>
        /// 日付フィルタ最大スパン
        /// </summary>
        [JsonProperty("DateFilterMaxSpan")]
        public int? DateFilterMaxSpan { get; set; }

        /// <summary>
        /// 日付フィルタ年度
        /// </summary>
        [JsonProperty("DateFilterFy")]
        public bool? DateFilterFy { get; set; }

        /// <summary>
        /// 日付フィルタ半期
        /// </summary>
        [JsonProperty("DateFilterHalf")]
        public bool? DateFilterHalf { get; set; }

        /// <summary>
        /// 日付フィルタ四半期
        /// </summary>
        [JsonProperty("DateFilterQuarter")]
        public bool? DateFilterQuarter { get; set; }

        /// <summary>
        /// 日付フィルタ月
        /// </summary>
        [JsonProperty("DateFilterMonth")]
        public bool? DateFilterMonth { get; set; }

        /// <summary>
        /// 同名ファイルを上書き
        /// </summary>
        [JsonProperty("OverwriteSameFileName")]
        public bool? OverwriteSameFileName { get; set; }

        /// <summary>
        /// 添付ファイル数制限
        /// </summary>
        [JsonProperty("LimitQuantity")]
        public decimal? LimitQuantity { get; set; }

        /// <summary>
        /// ファイルサイズ制限
        /// </summary>
        [JsonProperty("LimitSize")]
        public decimal? LimitSize { get; set; }

        /// <summary>
        /// 合計ファイルサイズ制限
        /// </summary>
        [JsonProperty("TotalLimitSize")]
        public decimal? TotalLimitSize { get; set; }

        /// <summary>
        /// ローカルフォルダサイズ制限
        /// </summary>
        [JsonProperty("LocalFolderLimitSize")]
        public decimal? LocalFolderLimitSize { get; set; }

        /// <summary>
        /// ローカルフォルダ合計サイズ制限
        /// </summary>
        [JsonProperty("LocalFolderTotalLimitSize")]
        public decimal? LocalFolderTotalLimitSize { get; set; }

        /// <summary>
        /// バイナリストレージプロバイダ
        /// </summary>
        [JsonProperty("BinaryStorageProvider")]
        public string? BinaryStorageProvider { get; set; }

        /// <summary>
        /// 日時ステップ
        /// </summary>
        [JsonProperty("DateTimeStep")]
        public int? DateTimeStep { get; set; }

        /// <summary>
        /// アンカー
        /// </summary>
        [JsonProperty("Anchor")]
        public bool? Anchor { get; set; }

        /// <summary>
        /// アンカーを新しいタブで開く
        /// </summary>
        [JsonProperty("OpenAnchorNewTab")]
        public bool? OpenAnchorNewTab { get; set; }

        /// <summary>
        /// アンカーフォーマット
        /// </summary>
        [JsonProperty("AnchorFormat")]
        public string? AnchorFormat { get; set; }
    }
}
