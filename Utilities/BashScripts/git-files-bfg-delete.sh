# Temporary code for removing large files from repo
# Run inside a Git Bash shell

# examples
# java -jar bfg.jar --no-blob-protection --delete-files "*.{pdf,cdr,eps,jpg}" "${name}.git" &&
# java -jar bfg.jar --no-blob-protection --delete-files "{ui-settings.xml,libkrtp.so}" "${name}.git" &&
# java -jar bfg.jar -- delete-files {*.config,*.xml} your-git-repo.git

# This exit is to protect the script from being run accidentally. We only want to run this script ONCE!
exit 1

DELETE="{*.css.map,*.js.map,*.ogg,*.webm,app.js,BigBuck*.mp4,bootstrap*.css,bootstrap*.js,canvg*.js,jquery*.js,jquery*.map,jquery*.ts,main.bundle.js,main-es*.js,pdfmake-es*.js,polyfills-es*.js,shims.js,styles-es*.js,vendor-bundle.js,vendor-es*.js,WinSCP.exe,WinSCPnet.dll,google-translate-attribution.zip,itextsharp.dll,iTextSharp.xml}"

cd /c/govmeeting/_sourcecode_mirror
alias bfg="java -jar /c/govmeeting/bfg-1.14.0.jar"
bfg -D $DELETE
git reflog expire --expire=now --all && git gc --prune=now --aggressive


# $IDS = ""


# java -jar bfg-1.14.0.jar -D $DELETE _SOURCECODE_MIRROR



# java -jar bfg-1.14.0.jar -D *.js.map

# cd C:\GOVMEETING\WORKAREA\RemoveLargeFileFromGit
# cd C:/GOVMEETING/WORKAREA/RemoveLargeFileFromGit
# C:/GOVMEETING/_SOURCECODE/Utilities/BashScripts/git-show-big-files.sh