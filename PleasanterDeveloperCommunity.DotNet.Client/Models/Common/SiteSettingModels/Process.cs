using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Common.SiteSettingModels
{
    /// <summary>
    /// プロセス設定を表すクラスです。
    /// </summary>
    public class Process
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 表示名
        /// </summary>
        [JsonPropertyName("DisplayName")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// 確認種類
        /// </summary>
        [JsonPropertyName("ConfirmationType")]
        public int? ConfirmationType { get; set; }

        /// <summary>
        /// 確認メッセージ
        /// </summary>
        [JsonPropertyName("ConfirmationMessage")]
        public string? ConfirmationMessage { get; set; }

        /// <summary>
        /// 成功メッセージ
        /// </summary>
        [JsonPropertyName("SuccessMessage")]
        public string? SuccessMessage { get; set; }

        /// <summary>
        /// 画面表示種類
        /// </summary>
        [JsonPropertyName("ScreenType")]
        public int? ScreenType { get; set; }

        /// <summary>
        /// 現在のステータス
        /// </summary>
        [JsonPropertyName("CurrentStatus")]
        public int? CurrentStatus { get; set; }

        /// <summary>
        /// 変更ステータス
        /// </summary>
        [JsonPropertyName("ChangedStatus")]
        public int? ChangedStatus { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// ツールチップ
        /// </summary>
        [JsonPropertyName("Tooltip")]
        public string? Tooltip { get; set; }

        /// <summary>
        /// OnClick
        /// </summary>
        [JsonPropertyName("OnClick")]
        public string? OnClick { get; set; }

        /// <summary>
        /// 実行種類
        /// </summary>
        [JsonPropertyName("ExecutionType")]
        public int? ExecutionType { get; set; }

        /// <summary>
        /// アクション種類
        /// </summary>
        [JsonPropertyName("ActionType")]
        public int? ActionType { get; set; }

        /// <summary>
        /// 一括処理を許可
        /// </summary>
        [JsonPropertyName("AllowBulkProcessing")]
        public bool? AllowBulkProcessing { get; set; }

        /// <summary>
        /// 入力検証
        /// </summary>
        [JsonPropertyName("ValidateInputs")]
        public List<ProcessValidateInput>? ValidateInputs { get; set; }

        /// <summary>
        /// データ変更
        /// </summary>
        [JsonPropertyName("DataChanges")]
        public List<ProcessDataChange>? DataChanges { get; set; }

        /// <summary>
        /// 権限種類
        /// </summary>
        [JsonPropertyName("PermissionType")]
        public long? PermissionType { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonPropertyName("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 自動番号付与フィールド
        /// </summary>
        [JsonPropertyName("AutoNumberingField")]
        public string? AutoNumberingField { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonPropertyName("Disabled")]
        public bool? Disabled { get; set; }
    }
}
