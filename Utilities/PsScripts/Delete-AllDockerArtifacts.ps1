# Stop & Delete all containers
docker stop $(docker ps -aq)
docker rm $(docker ps -a -q)

# Delete volumes
docker volume prune -f

# Delete all images
docker rmi -f $(docker images -q) 

