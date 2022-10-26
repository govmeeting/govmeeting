# Temporary code for removing large files from repo
# It uses BFG.
# Run this inside a Git Bash shell

# examples of using BFG
# java -jar bfg.jar --no-blob-protection --delete-files "*.{pdf,cdr,eps,jpg}" "${name}.git" &&
# java -jar bfg.jar --no-blob-protection --delete-files "{ui-settings.xml,libkrtp.so}" "${name}.git" &&
# java -jar bfg.jar -- delete-files {*.config,*.xml} your-git-repo.git

# This exit is to protect the script from being run accidentally. We only want to run this script ONCE!
exit 1

alias bfg="java -jar /c/govmeeting/bfg-1.14.0.jar"

# DELETE1="{*.css.map,*.js.map,*.ogg,*.webm,app.js,BigBuck*.mp4,bootstrap*.css,bootstrap*.js,canvg*.js,jquery*.js,jquery*.map,jquery*.ts,main.bundle.js,main-es*.js,pdfmake-es*.js,polyfills-es*.js,shims.js,styles-es*.js,vendor-bundle.js,vendor-es*.js,WinSCP.exe,WinSCPnet.dll,google-translate-attribution.zip,itextsharp.dll,iTextSharp.xml}"
# cd /c/govmeeting/_sourcecode_mirror
# bfg -D $DELETE1
# git reflog expire --expire=now --all && git gc --prune=now --aggressive

# DELETE2="{*.mp4,*.flac,Maine_Acadia_National_Park.png}"
# cd /c/govmeeting/_sourcecode_mirror_copy
# bfg -D $DELETE2
# git reflog expire --expire=now --all && git gc --prune=now --aggressive

# Combination of DELETE1 & DELETE2
DELETE="{*0.mp4,*4.mp4,*s.mp4,*x.mp4,*).mp4,*o.mp4,*5.mp4,*9.mp4,*.flac,*.css.map,*.js.map,*.ogg,*.webm,app.js,bootstrap*.css,bootstrap*.js,canvg*.js,jquery*.js,jquery*.map,jquery*.ts,main.bundle.js,main-es*.js,pdfmake-es*.js,polyfills-es*.js,shims.js,styles-es*.js,vendor-bundle.js,vendor-es*.js,WinSCP.exe,WinSCPnet.dll,google-translate-attribution.zip,itextsharp.dll,iTextSharp.xml}"
cd /c/govmeeting/SOURCECODE_MIRROR_NO_PRIVATE_REFS/tmp.seC9sJ2Jkh
bfg -D $DELETE
git reflog expire --expire=now --all && git gc --prune=now --aggressive

# This is the blob id for the Maine_Acadia_National_Park.png which is 8.3 MiB.
DELETE_BLOBS="8942cb2c55d1"


# java -jar bfg-1.14.0.jar -D $DELETE _SOURCECODE_MIRROR



# java -jar bfg-1.14.0.jar -D *.js.map

# cd C:\GOVMEETING\WORKAREA\RemoveLargeFileFromGit
# cd C:/GOVMEETING/WORKAREA/RemoveLargeFileFromGit
# C:/GOVMEETING/_SOURCECODE/Utilities/BashScripts/git-show-big-files.sh