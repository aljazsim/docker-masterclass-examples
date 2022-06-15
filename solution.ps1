Set-Location $PSScriptRoot

# list images
docker image ls

# pull image
docker image pull datalust/seq

# list images
docker image ls

# create container
docker container create --name mycontainer --interactive --tty --env ACCEPT_EULA=Y --publish 5341:80 datalust/seq

# list containers
docker container ls --all

#start container
docker start mycontainer

# list containers
docker container ls --all

# verify seq container is accessible from browser
Start-Process "http://localhost:5341/"

# show container log
docker logs mycontainer

# stop container
docker container stop mycontainer

# try to create container with same name (docker cannot have 2 containers with same name)
docker container create --name mycontainer --interactive --tty --env ACCEPT_EULA=Y --publish 5341:80 datalust/seq

# remove container
docker container rm mycontainer

# list containers
docker container ls --all

# verify seq container is no longer accessible from browser
Start-Process "http://localhost:5341/"

# run container
docker container run --name mycontainer --tty --env ACCEPT_EULA=Y --publish 5341:80 --detach datalust/seq

# list containers
docker container ls --all

# verify seq container is accessible from browser
Start-Process "http://localhost:5341/"

# stop all containers
docker container stop $(docker container ls --all --quiet)

# list containers
docker container ls --all

# remove container
docker container rm $(docker container ls --all --quiet)

# list containers
docker container ls --all

# list images
docker image ls

# remove all images
docker image rm -f $(docker image ls -aq)

# list images
docker image ls