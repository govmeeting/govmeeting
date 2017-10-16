GOV="/C/GOVMEETING/_SOURCECODE"
GOV_SER="${GOV}/src/Server/WebApp"
GOV_CLI="${GOV}/src/Client/BrowserApp"

PUBLISH="${GOV_SER}/bin/Release/PublishOutput"

cd ${GOV_CLI}
echo "Run production build of BrowserApp"
npm run build.prod

cd ${GOV_CLI}/dist/prod
echo "Move css files to ${PUBLISH}/wwwroot/css"
cp -f css/main.css ${PUBLISH}/wwwroot/css
echo "Move js files to ${PUBLISH}/wwwroot/css"
cp -f js/app.js    ${PUBLISH}/wwwroot/js
cp -f js/shims.js  ${PUBLISH}/wwwroot/js

echo "Move appsettings.Production.json to ${PUBLISH}"
cd ${GOV}/../_SECRETS
cp appsettings.Production.json ${PUBLISH}