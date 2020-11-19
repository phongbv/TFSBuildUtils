[cmdletbinding()]
param
(
   #[Parameter(Mandatory=$true)][string] $profilePath,
   #[Parameter(Mandatory=$true)][string] $deploymentPath,
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
Add-Type -Path "$PSScriptRoot\TFSBuildUtils.dll"
#Write-Host $projectURI
Write-Host "Build.SourceVersion $sourceVersion"
[TFSBuildUtils.BuildUtils]::UpdateReportFile($reportFilePath,$projectURI,$env:Build_BuildId)
