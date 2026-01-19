using System.Text.Json.Serialization;

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
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        /// <summary>
        /// ラベルテキスト
        /// </summary>
        [JsonPropertyName("LabelText")]
        public string? LabelText { get; set; }

        /// <summary>
        /// 一覧用ラベルテキスト
        /// </summary>
        [JsonPropertyName("GridLabelText")]
        public string? GridLabelText { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// 入力ガイド
        /// </summary>
        [JsonPropertyName("InputGuide")]
        public string? InputGuide { get; set; }

        /// <summary>
        /// 選択肢テキスト
        /// </summary>
        [JsonPropertyName("ChoicesText")]
        public string? ChoicesText { get; set; }

        /// <summary>
        /// 検索を使用
        /// </summary>
        [JsonPropertyName("UseSearch")]
        public bool? UseSearch { get; set; }

        /// <summary>
        /// 複数選択
        /// </summary>
        [JsonPropertyName("MultipleSelections")]
        public bool? MultipleSelections { get; set; }

        /// <summary>
        /// 空白選択肢を挿入しない
        /// </summary>
        [JsonPropertyName("NotInsertBlankChoice")]
        public bool? NotInsertBlankChoice { get; set; }

        /// <summary>
        /// デフォルト入力値
        /// </summary>
        [JsonPropertyName("DefaultInput")]
        public string? DefaultInput { get; set; }

        /// <summary>
        /// インポートキー
        /// </summary>
        [JsonPropertyName("ImportKey")]
        public bool? ImportKey { get; set; }

        /// <summary>
        /// 一覧フォーマット
        /// </summary>
        [JsonPropertyName("GridFormat")]
        public string? GridFormat { get; set; }

        /// <summary>
        /// エディタフォーマット
        /// </summary>
        [JsonPropertyName("EditorFormat")]
        public string? EditorFormat { get; set; }

        /// <summary>
        /// エクスポートフォーマット
        /// </summary>
        [JsonPropertyName("ExportFormat")]
        public string? ExportFormat { get; set; }

        /// <summary>
        /// コントロールの種類
        /// </summary>
        [JsonPropertyName("ControlType")]
        public string? ControlType { get; set; }

        /// <summary>
        /// 選択肢コントロールの種類
        /// </summary>
        [JsonPropertyName("ChoicesControlType")]
        public string? ChoicesControlType { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        [JsonPropertyName("Format")]
        public string? Format { get; set; }

        /// <summary>
        /// 折り返しなし
        /// </summary>
        [JsonPropertyName("NoWrap")]
        public bool? NoWrap { get; set; }

        /// <summary>
        /// 非表示
        /// </summary>
        [JsonPropertyName("Hide")]
        public bool? Hide { get; set; }

        /// <summary>
        /// 自動採番フォーマット
        /// </summary>
        [JsonPropertyName("AutoNumberingFormat")]
        public string? AutoNumberingFormat { get; set; }

        /// <summary>
        /// 自動採番リセット種類
        /// </summary>
        [JsonPropertyName("AutoNumberingResetType")]
        public int? AutoNumberingResetType { get; set; }

        /// <summary>
        /// 自動採番のデフォルト値
        /// </summary>
        [JsonPropertyName("AutoNumberingDefault")]
        public int? AutoNumberingDefault { get; set; }

        /// <summary>
        /// 自動採番のステップ
        /// </summary>
        [JsonPropertyName("AutoNumberingStep")]
        public int? AutoNumberingStep { get; set; }

        /// <summary>
        /// 拡張セルCSS
        /// </summary>
        [JsonPropertyName("ExtendedCellCss")]
        public string? ExtendedCellCss { get; set; }

        /// <summary>
        /// 拡張フィールドCSS
        /// </summary>
        [JsonPropertyName("ExtendedFieldCss")]
        public string? ExtendedFieldCss { get; set; }

        /// <summary>
        /// 拡張コントロールCSS
        /// </summary>
        [JsonPropertyName("ExtendedControlCss")]
        public string? ExtendedControlCss { get; set; }

        /// <summary>
        /// セクション
        /// </summary>
        [JsonPropertyName("Section")]
        public string? Section { get; set; }

        /// <summary>
        /// セル固定
        /// </summary>
        [JsonPropertyName("CellSticky")]
        public bool? CellSticky { get; set; }

        /// <summary>
        /// セル幅
        /// </summary>
        [JsonPropertyName("CellWidth")]
        public int? CellWidth { get; set; }

        /// <summary>
        /// セル折り返し
        /// </summary>
        [JsonPropertyName("CellWordWrap")]
        public bool? CellWordWrap { get; set; }

        /// <summary>
        /// 一覧デザイン
        /// </summary>
        [JsonPropertyName("GridDesign")]
        public string? GridDesign { get; set; }

        /// <summary>
        /// 必須入力の検証
        /// </summary>
        [JsonPropertyName("ValidateRequired")]
        public bool? ValidateRequired { get; set; }

        /// <summary>
        /// 数値の検証
        /// </summary>
        [JsonPropertyName("ValidateNumber")]
        public bool? ValidateNumber { get; set; }

        /// <summary>
        /// 日付の検証
        /// </summary>
        [JsonPropertyName("ValidateDate")]
        public bool? ValidateDate { get; set; }

        /// <summary>
        /// メールの検証
        /// </summary>
        [JsonPropertyName("ValidateEmail")]
        public bool? ValidateEmail { get; set; }

        /// <summary>
        /// 一致の検証対象
        /// </summary>
        [JsonPropertyName("ValidateEqualTo")]
        public string? ValidateEqualTo { get; set; }

        /// <summary>
        /// 最大長の検証
        /// </summary>
        [JsonPropertyName("ValidateMaxLength")]
        public int? ValidateMaxLength { get; set; }

        /// <summary>
        /// 最大長
        /// </summary>
        [JsonPropertyName("MaxLength")]
        public decimal? MaxLength { get; set; }

        /// <summary>
        /// クライアント正規表現検証
        /// </summary>
        [JsonPropertyName("ClientRegexValidation")]
        public string? ClientRegexValidation { get; set; }

        /// <summary>
        /// サーバ正規表現検証
        /// </summary>
        [JsonPropertyName("ServerRegexValidation")]
        public string? ServerRegexValidation { get; set; }

        /// <summary>
        /// 正規表現検証メッセージ
        /// </summary>
        [JsonPropertyName("RegexValidationMessage")]
        public string? RegexValidationMessage { get; set; }

        /// <summary>
        /// フィールド前の拡張HTML
        /// </summary>
        [JsonPropertyName("ExtendedHtmlBeforeField")]
        public string? ExtendedHtmlBeforeField { get; set; }

        /// <summary>
        /// ラベル前の拡張HTML
        /// </summary>
        [JsonPropertyName("ExtendedHtmlBeforeLabel")]
        public string? ExtendedHtmlBeforeLabel { get; set; }

        /// <summary>
        /// ラベルとコントロール間の拡張HTML
        /// </summary>
        [JsonPropertyName("ExtendedHtmlBetweenLabelAndControl")]
        public string? ExtendedHtmlBetweenLabelAndControl { get; set; }

        /// <summary>
        /// コントロール後の拡張HTML
        /// </summary>
        [JsonPropertyName("ExtendedHtmlAfterControl")]
        public string? ExtendedHtmlAfterControl { get; set; }

        /// <summary>
        /// フィールド後の拡張HTML
        /// </summary>
        [JsonPropertyName("ExtendedHtmlAfterField")]
        public string? ExtendedHtmlAfterField { get; set; }

        /// <summary>
        /// 多言語ラベルテキスト
        /// </summary>
        [JsonPropertyName("MultilingualLabelText")]
        public string? MultilingualLabelText { get; set; }

        /// <summary>
        /// NULL許容
        /// </summary>
        [JsonPropertyName("Nullable")]
        public bool? Nullable { get; set; }

        /// <summary>
        /// 単位
        /// </summary>
        [JsonPropertyName("Unit")]
        public string? Unit { get; set; }

        /// <summary>
        /// 小数点以下桁数
        /// </summary>
        [JsonPropertyName("DecimalPlaces")]
        public int? DecimalPlaces { get; set; }

        /// <summary>
        /// 丸め種類
        /// </summary>
        [JsonPropertyName("RoundingType")]
        public int? RoundingType { get; set; }

        /// <summary>
        /// 最小値
        /// </summary>
        [JsonPropertyName("Min")]
        public decimal? Min { get; set; }

        /// <summary>
        /// 最大値
        /// </summary>
        [JsonPropertyName("Max")]
        public decimal? Max { get; set; }

        /// <summary>
        /// ステップ
        /// </summary>
        [JsonPropertyName("Step")]
        public decimal? Step { get; set; }

        /// <summary>
        /// 重複禁止
        /// </summary>
        [JsonPropertyName("NoDuplication")]
        public bool? NoDuplication { get; set; }

        /// <summary>
        /// 重複時のメッセージ
        /// </summary>
        [JsonPropertyName("MessageWhenDuplicated")]
        public string? MessageWhenDuplicated { get; set; }

        /// <summary>
        /// デフォルトでコピー
        /// </summary>
        [JsonPropertyName("CopyByDefault")]
        public bool? CopyByDefault { get; set; }

        /// <summary>
        /// エディタ読取専用
        /// </summary>
        [JsonPropertyName("EditorReadOnly")]
        public bool? EditorReadOnly { get; set; }

        /// <summary>
        /// 自動ポストバック
        /// </summary>
        [JsonPropertyName("AutoPostBack")]
        public bool? AutoPostBack { get; set; }

        /// <summary>
        /// 自動ポストバック時に返却する列
        /// </summary>
        [JsonPropertyName("ColumnsReturnedWhenAutomaticPostback")]
        public string? ColumnsReturnedWhenAutomaticPostback { get; set; }

        /// <summary>
        /// 一括更新を許可
        /// </summary>
        [JsonPropertyName("AllowBulkUpdate")]
        public bool? AllowBulkUpdate { get; set; }

        /// <summary>
        /// 添付ファイルの削除を許可
        /// </summary>
        [JsonPropertyName("AllowDeleteAttachments")]
        public bool? AllowDeleteAttachments { get; set; }

        /// <summary>
        /// 既存履歴を削除しない
        /// </summary>
        [JsonPropertyName("NotDeleteExistHistory")]
        public bool? NotDeleteExistHistory { get; set; }

        /// <summary>
        /// 画像を許可
        /// </summary>
        [JsonPropertyName("AllowImage")]
        public bool? AllowImage { get; set; }

        /// <summary>
        /// サムネイル制限サイズ
        /// </summary>
        [JsonPropertyName("ThumbnailLimitSize")]
        public decimal? ThumbnailLimitSize { get; set; }

        /// <summary>
        /// フィールドCSS
        /// </summary>
        [JsonPropertyName("FieldCss")]
        public string? FieldCss { get; set; }

        /// <summary>
        /// ビューア切替種類
        /// </summary>
        [JsonPropertyName("ViewerSwitchingType")]
        public int? ViewerSwitchingType { get; set; }

        /// <summary>
        /// テキスト配置
        /// </summary>
        [JsonPropertyName("TextAlign")]
        public int? TextAlign { get; set; }

        /// <summary>
        /// リンク
        /// </summary>
        [JsonPropertyName("Link")]
        public bool? Link { get; set; }

        /// <summary>
        /// チェックフィルタコントロール種類
        /// </summary>
        [JsonPropertyName("CheckFilterControlType")]
        public int? CheckFilterControlType { get; set; }

        /// <summary>
        /// 数値フィルタ最小値
        /// </summary>
        [JsonPropertyName("NumFilterMin")]
        public decimal? NumFilterMin { get; set; }

        /// <summary>
        /// 数値フィルタ最大値
        /// </summary>
        [JsonPropertyName("NumFilterMax")]
        public decimal? NumFilterMax { get; set; }

        /// <summary>
        /// 数値フィルタステップ
        /// </summary>
        [JsonPropertyName("NumFilterStep")]
        public decimal? NumFilterStep { get; set; }

        /// <summary>
        /// 日付フィルタ設定モード
        /// </summary>
        [JsonPropertyName("DateFilterSetMode")]
        public int? DateFilterSetMode { get; set; }

        /// <summary>
        /// 検索種類
        /// </summary>
        [JsonPropertyName("SearchType")]
        public int? SearchType { get; set; }

        /// <summary>
        /// 全文検索種類
        /// </summary>
        [JsonPropertyName("FullTextType")]
        public int? FullTextType { get; set; }

        /// <summary>
        /// 日付フィルタ最小スパン
        /// </summary>
        [JsonPropertyName("DateFilterMinSpan")]
        public int? DateFilterMinSpan { get; set; }

        /// <summary>
        /// 日付フィルタ最大スパン
        /// </summary>
        [JsonPropertyName("DateFilterMaxSpan")]
        public int? DateFilterMaxSpan { get; set; }

        /// <summary>
        /// 日付フィルタ年度
        /// </summary>
        [JsonPropertyName("DateFilterFy")]
        public bool? DateFilterFy { get; set; }

        /// <summary>
        /// 日付フィルタ半期
        /// </summary>
        [JsonPropertyName("DateFilterHalf")]
        public bool? DateFilterHalf { get; set; }

        /// <summary>
        /// 日付フィルタ四半期
        /// </summary>
        [JsonPropertyName("DateFilterQuarter")]
        public bool? DateFilterQuarter { get; set; }

        /// <summary>
        /// 日付フィルタ月
        /// </summary>
        [JsonPropertyName("DateFilterMonth")]
        public bool? DateFilterMonth { get; set; }

        /// <summary>
        /// 同名ファイルを上書き
        /// </summary>
        [JsonPropertyName("OverwriteSameFileName")]
        public bool? OverwriteSameFileName { get; set; }

        /// <summary>
        /// 添付ファイル数制限
        /// </summary>
        [JsonPropertyName("LimitQuantity")]
        public decimal? LimitQuantity { get; set; }

        /// <summary>
        /// ファイルサイズ制限
        /// </summary>
        [JsonPropertyName("LimitSize")]
        public decimal? LimitSize { get; set; }

        /// <summary>
        /// 合計ファイルサイズ制限
        /// </summary>
        [JsonPropertyName("TotalLimitSize")]
        public decimal? TotalLimitSize { get; set; }

        /// <summary>
        /// ローカルフォルダサイズ制限
        /// </summary>
        [JsonPropertyName("LocalFolderLimitSize")]
        public decimal? LocalFolderLimitSize { get; set; }

        /// <summary>
        /// ローカルフォルダ合計サイズ制限
        /// </summary>
        [JsonPropertyName("LocalFolderTotalLimitSize")]
        public decimal? LocalFolderTotalLimitSize { get; set; }

        /// <summary>
        /// バイナリストレージプロバイダ
        /// </summary>
        [JsonPropertyName("BinaryStorageProvider")]
        public string? BinaryStorageProvider { get; set; }

        /// <summary>
        /// 日時ステップ
        /// </summary>
        [JsonPropertyName("DateTimeStep")]
        public int? DateTimeStep { get; set; }

        /// <summary>
        /// アンカー
        /// </summary>
        [JsonPropertyName("Anchor")]
        public bool? Anchor { get; set; }

        /// <summary>
        /// アンカーを新しいタブで開く
        /// </summary>
        [JsonPropertyName("OpenAnchorNewTab")]
        public bool? OpenAnchorNewTab { get; set; }

        /// <summary>
        /// アンカーフォーマット
        /// </summary>
        [JsonPropertyName("AnchorFormat")]
        public string? AnchorFormat { get; set; }
    }
}
