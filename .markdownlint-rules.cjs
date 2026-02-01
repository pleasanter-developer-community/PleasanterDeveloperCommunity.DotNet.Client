// @ts-check

const fs = require("fs");

/**
 * カスタムmarkdownlintルール: H1と「## 目次」に<!-- omit in toc -->を必須にする
 *
 * 注: markdownlint v0.35.0以降では、params.lines および token.line のHTMLコメント内容が
 *     マスクされて渡される（例: <!-- omit in toc --> → <!-- .... .. ... -->）
 *     そのため、ファイルを直接読み込んで元の内容をチェックする
 *
 * fixInfo を提供することで、markdownlint-cli2 --fix で自動修正が可能
 */

/**
 * ファイルの元の行を取得する（キャッシュ付き）
 * @type {Map<string, string[]>}
 */
const fileCache = new Map();

/**
 * ファイルの元の行を取得する
 * @param {string} filePath - ファイルパス
 * @returns {string[]} - 行の配列
 */
function getRawLines(filePath) {
    if (!fileCache.has(filePath)) {
        try {
            const content = fs.readFileSync(filePath, "utf8");
            fileCache.set(filePath, content.split(/\r?\n/));
        } catch {
            return [];
        }
    }
    return fileCache.get(filePath) || [];
}

/** @type {string} */
const OMIT_COMMENT = " <!-- omit in toc -->";

module.exports = [
    {
        names: ["omit-in-toc-h1"],
        description: "H1 headings must include <!-- omit in toc -->",
        tags: ["headings", "toc"],
        function: function rule(params, onError) {
            const rawLines = getRawLines(params.name);
            if (rawLines.length === 0) {
                return;
            }

            params.tokens
                .filter((token) => token.type === "heading_open" && token.tag === "h1")
                .forEach((token) => {
                    const lineNumber = token.lineNumber;
                    const line = rawLines[lineNumber - 1];
                    if (line && !line.includes("<!-- omit in toc -->")) {
                        onError({
                            lineNumber: lineNumber,
                            detail: "H1 heading must include '<!-- omit in toc -->'",
                            context: line.trim(),
                            fixInfo: {
                                insertText: OMIT_COMMENT,
                                editColumn: line.length + 1
                            }
                        });
                    }
                });
        }
    },
    {
        names: ["omit-in-toc-toc"],
        description: "「## 目次」heading must include <!-- omit in toc -->",
        tags: ["headings", "toc"],
        function: function rule(params, onError) {
            const rawLines = getRawLines(params.name);
            if (rawLines.length === 0) {
                return;
            }

            params.tokens
                .filter((token) => token.type === "heading_open" && token.tag === "h2")
                .forEach((token) => {
                    const lineNumber = token.lineNumber;
                    const line = rawLines[lineNumber - 1];
                    if (line && line.includes("## 目次") && !line.includes("<!-- omit in toc -->")) {
                        onError({
                            lineNumber: lineNumber,
                            detail: "「## 目次」heading must include '<!-- omit in toc -->'",
                            context: line.trim(),
                            fixInfo: {
                                insertText: OMIT_COMMENT,
                                editColumn: line.length + 1
                            }
                        });
                    }
                });
        }
    }
];
