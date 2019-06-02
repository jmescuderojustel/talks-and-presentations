Add-Type -AssemblyName System.IO.Compression.FileSystem

function Unzip
{
    param([string]$zipfile, [string]$outpath)

    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

$zipFile = "uk-500.zip"
$url = "https://www.briandunning.com/sample-data/" + $zipFile

$wc = New-Object System.Net.WebClient
$wc.DownloadFile($url, $zipFile)

Unzip $zipFile "."

Remove-Item –path $zipFile