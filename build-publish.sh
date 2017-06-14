cd C:/GOVMEETING/_SOURCECODE/src/Client/BrowserApp
npm run build.prod
cp -f dist/prod/css/main.css ../../Server/WebApp/bin/Release/PublishOutput/wwwroot/css
cp -f dist/prod/js/app.js ../../Server/WebApp/bin/Release/PublishOutput/wwwroot/js
cp -f dist/prod/js/shims.js ../../Server/WebApp/bin/Release/PublishOutput/wwwroot/js
cp ../../../../_SECRETS/appsettings.Production.json ../../Server/WebApp/bin/Release/PublishOutput


