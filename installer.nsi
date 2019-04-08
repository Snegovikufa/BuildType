; BuildType.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of BuildType.nsi
; there. 

;--------------------------------

; The name of the installer
Name "BuildType"

; The file to write
OutFile "BuildType.exe"

; The default installation directory
InstallDir $ProgramFiles\BuildType

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "BuildType\bin\Release\BuildType.exe"
  File "BuildType\bin\Release\BuildType.exe.config"

  WriteRegStr HKCR "*\shell\Open with BuildType\command" '' 'C:\\Program Files (x86)\\BuildType\\BuildType.exe \"%1\"'

SectionEnd ; end the section
