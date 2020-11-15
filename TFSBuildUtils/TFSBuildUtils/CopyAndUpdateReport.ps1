[cmdletbinding()]
param
(
   [Parameter(Mandatory=$true)][string] $profilePath,
   [Parameter(Mandatory=$true)][string] $deploymentPath,
   [Parameter(Mandatory=$true)][string] $reportFilePath
)
 
####################################################################################################
# 1 Auto Configuration
####################################################################################################
 
# Stop the script on error
$ErrorActionPreference = "Stop"
 
# Relative location of nuget.exe to build agent home directory
$nugetExecutableRelativePath = "AgentWorkerToolsnuget.exe"
 
# These variables are provided by TFS
$buildAgentHomeDirectory = $env:AGENT_HOMEDIRECTORY
$buildSourcesDirectory = $Env:BUILD_SOURCESDIRECTORY
$buildStagingDirectory = $Env:BUILD_STAGINGDIRECTORY
$buildPlatform = $Env:BUILDPLATFORM
$buildConfiguration = $Env:BUILDCONFIGURATION
$sourceVersion = $Env:Build_SourceVersion
$projectURI = $env:System_TeamFoundationCollectionUri + "/" + $Env:System_TeamProject
#Write-Host $env:System_TeamFoundationCollectionUri
#Write-Host $Env:System_TeamProject
#Add-Type -Path "$PSScriptRoot\TFSBuildUtils.dll"
#Write-Host $projectURI
Write-Host "Build.SourceVersion $sourceVersion"
#[TFSBuildUtils.BuildUtils]::UpdateReportFile($reportFilePath,$projectURI,$env:Build_BuildId)

#Write-Host $buildAgentHomeDirectory 
#Write-Host $buildSourcesDirectory

#$packagesOutputDirectory = $buildStagingDirectory
# 
## Determine full path of pack target file
$profilePathFullPath = Join-Path -Path $buildSourcesDirectory -ChildPath $profilePath
Write-Host "Profile Path $profilePathFullPath"
$content = Get-Content $profilePathFullPath
$pattern = "<publishUrl>(.*?)</publishUrl>"
$deployDir = [System.Text.RegularExpressions.Regex]::Match($content,$pattern).Groups[1].Value
Write-Host "Profile output path $deployDir"

Write-Host "Rename config file"
Get-ChildItem $deployDir -Filter "*config*" -Recurse | Rename-Item -NewName {$_.name -replace 'config','config.bak' }

Write-Host "Copy deployment files"
Get-ChildItem $deployDir| Copy-Item -Destination $deploymentPath -Force -Recurse
