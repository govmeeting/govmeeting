Set-Location C:\GOVMEETING\_SOURCECODE\src\WebUI
docker build . -t govmeeting/web -f Dockerfile
docker create -p 8080:80 -name webbox govmeeting/web
docker start webbox

docker build . -t govmeeting/server -f Dockerfile-server
docker create -p 8080:80 -name serverbox govmeeting/server
docker start serverbox
