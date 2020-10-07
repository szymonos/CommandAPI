<#
.SYNOPSIS
PowerShell profile light.
.EXAMPLE
code -r $Profile.CurrentUserAllHosts
Install-Module PSReadLine -AllowPrerelease -Force
Set-PSReadLineOption -PredictionSource History
#>
$OutputEncoding = [Console]::InputEncoding = [Console]::OutputEncoding = New-Object System.Text.UTF8Encoding
Set-PSReadLineOption -PredictionSource History
function Prompt {
    filter repl { $_ -replace ('{0}' -f $env:HOME), '~' }
    if ((Get-History).Count -gt 0) {
        $executionTime = ((Get-History)[-1].EndExecutionTime - (Get-History)[-1].StartExecutionTime).Totalmilliseconds
    } else {
        $executionTime = 0
    }
    $promptPath = $PWD | repl
    [Console]::Write(
        "`e[92m`u{250C}`u{2500} `e[93m[`e[38;5;147m{0:N1}ms`e[93m] `e[1m`e[34m$promptPath",
        $executionTime
    )
    if ($branch = git rev-parse --abbrev-ref HEAD 2>$null) {
        [Console]::Write(" `e[96m(`e[91m$branch")
        if (git diff --raw) {
            [Console]::Write(" `e[93m`u{2717}")
        }
        [Console]::Write("`e[96m)")
    }
    return "`n`e[92m`u{2514}$('>' * ($nestedPromptLevel + 1))`e[0m "
}
$4 = $PWD
Clear-Host
Write-Output ('PowerShell ' + $PSVersionTable.PSVersion.ToString())
Write-Output ('BootUp: ' + (Get-Uptime -Since).ToString() + ' | Uptime: ' + (Get-Uptime).ToString())
