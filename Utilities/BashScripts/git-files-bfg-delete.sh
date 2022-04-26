# Temporary code for removing large files from repo

$DELETE = "*.js.map
 main-es5*.js
main-es2015*.js
pdfmake-es2015*.js
pdfmake-es5*.js
xlsx-es5*.js
xlsx-es215*.js"

# java -jar bfg-1.14.0.jar -D $DELETE

# java -jar bfg-1.14.0.jar -D *.js.map

# cd C:\GOVMEETING\WORKAREA\RemoveLargeFileFromGit
# cd C:/GOVMEETING/WORKAREA/RemoveLargeFileFromGit
# C:/GOVMEETING/_SOURCECODE/Utilities/BashScripts/git-show-big-files.sh