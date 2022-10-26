# DELETE="{*0.mp4,*4.mp4,*s.mp4,*x.mp4,*).mp4,*o.mp4,*5.mp4,*9.mp4,*.flac,*.css.map,*.js.map,*.ogg,*.webm,app.js,BigBuck*.mp4,bootstrap*.css,bootstrap*.js,canvg*.js,jquery*.js,jquery*.map,jquery*.ts,main.bundle.js,main-es*.js,pdfmake-es*.js,polyfills-es*.js,shims.js,styles-es*.js,vendor-bundle.js,vendor-es*.js,WinSCP.exe,WinSCPnet.dll,google-translate-attribution.zip,itextsharp.dll,iTextSharp.xml}"

DELETE=(a b)
for x in $DELETE
do
    echo $x
done