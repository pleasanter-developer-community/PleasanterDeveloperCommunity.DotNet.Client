/**
 * 単一ファイルに対してdoctoc + decode-tocを実行するラッパースクリプト
 * RunOnSave から呼び出す想定。シェル依存を避けるためNode.jsで完結させる。
 *
 * 使用方法:
 *   node docs/script/toc-single.js <file>
 */

const { execFileSync } = require("child_process");
const path = require("path");

const file = process.argv[2];
if (!file) {
    console.error("Usage: node docs/script/toc-single.js <file>");
    process.exit(1);
}

const resolved = path.resolve(file);
const rootDir = path.join(__dirname, "..", "..");

// 1. doctoc でTOC生成
execFileSync(process.execPath, [
    path.join(rootDir, "node_modules", "doctoc", "doctoc.js"),
    resolved, "--github", "--maxlevel", "3", "--notitle"
], {
    stdio: "inherit",
    cwd: rootDir,
});

// 2. decode-toc.js で後処理（H1除去・デコード等）
execFileSync(process.execPath, [
    path.join(__dirname, "decode-toc.js"), resolved
], {
    stdio: "inherit",
    cwd: rootDir,
});
