#!/usr/bin/env pwsh 
param([string]$CommitMessageFile) 
$pattern = '^(feat|fix|chore|docs|style|refactor|perf|test|build|ci)(\(.+\))?!?: .+' 
$commitMsg = Get-Content $CommitMessageFile -Raw 
if ($commitMsg -notmatch $pattern) { 
    Write-Host "Commit inválido! Use Conventional Commits." 
    exit 1 
}