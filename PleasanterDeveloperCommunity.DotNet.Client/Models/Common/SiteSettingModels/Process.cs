using Newtonsoft.Json;
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
        [JsonProperty("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [JsonProperty("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// 表示名
        /// </summary>
        [JsonProperty("DisplayName")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// 確認種類
        /// </summary>
        [JsonProperty("ConfirmationType")]
        public int? ConfirmationType { get; set; }

        /// <summary>
        /// 確認メッセージ
        /// </summary>
        [JsonProperty("ConfirmationMessage")]
        public string? ConfirmationMessage { get; set; }

        /// <summary>
        /// 成功メッセージ
        /// </summary>
        [JsonProperty("SuccessMessage")]
        public string? SuccessMessage { get; set; }

        /// <summary>
        /// 画面表示種類
        /// </summary>
        [JsonProperty("ScreenType")]
        public int? ScreenType { get; set; }

        /// <summary>
        /// 現在のステータス
        /// </summary>
        [JsonProperty("CurrentStatus")]
        public int? CurrentStatus { get; set; }

        /// <summary>
        /// 変更ステータス
        /// </summary>
        [JsonProperty("ChangedStatus")]
        public int? ChangedStatus { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [JsonProperty("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// ツールチップ
        /// </summary>
        [JsonProperty("Tooltip")]
        public string? Tooltip { get; set; }

        /// <summary>
        /// OnClick
        /// </summary>
        [JsonProperty("OnClick")]
        public string? OnClick { get; set; }

        /// <summary>
        /// 実行種類
        /// </summary>
        [JsonProperty("ExecutionType")]
        public int? ExecutionType { get; set; }

        /// <summary>
        /// アクション種類
        /// </summary>
        [JsonProperty("ActionType")]
        public int? ActionType { get; set; }

        /// <summary>
        /// 一括処理を許可
        /// </summary>
        [JsonProperty("AllowBulkProcessing")]
        public bool? AllowBulkProcessing { get; set; }

        /// <summary>
        /// 入力検証
        /// </summary>
        [JsonProperty("ValidateInputs")]
        public List<ProcessValidateInput>? ValidateInputs { get; set; }

        /// <summary>
        /// データ変更
        /// </summary>
        [JsonProperty("DataChanges")]
        public List<ProcessDataChange>? DataChanges { get; set; }

        /// <summary>
        /// 権限種類
        /// </summary>
        [JsonProperty("PermissionType")]
        public long? PermissionType { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [JsonProperty("Condition")]
        public int? Condition { get; set; }

        /// <summary>
        /// 自動番号付与フィールド
        /// </summary>
        [JsonProperty("AutoNumberingField")]
        public string? AutoNumberingField { get; set; }

        /// <summary>
        /// 無効
        /// </summary>
        [JsonProperty("Disabled")]
        public bool? Disabled { get; set; }
    }
}
