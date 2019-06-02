Add-Type -AssemblyName System.IO.Compression.FileSystem

function Unzip
{
    param([string]$zipfile, [string]$outpath)

    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

$remoteZipName = "uk-500.zip"
$remoteCsvName = "uk-500.csv"
$localCsvName = "UK email list.csv"
$url = "https://www.briandunning.com/sample-data/" + $remoteZipName

$wc = New-Object System.Net.WebClient
$wc.DownloadFile($url, $remoteZipName)

Unzip $remoteZipName "."

Remove-Item –path $remoteZipName

New-Item "Data" -type directory

Rename-Item $remoteCsvName $localCsvName

Move-Item $localCsvName  "Data\"