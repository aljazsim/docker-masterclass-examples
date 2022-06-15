Set-Location $PSScriptRoot

# list images
docker image ls

# pull image
docker image pull datalust/seq

# list images
docker image ls

# pull image
docker image pull node

# list images
docker image ls

# pull image
docker image pull rabbitmq

# list images
docker image ls

# list image ids
docker image ls -aq

# remove image
docker image rm node

# list images
docker image ls

# remove all images
docker image rm -f $(docker image ls -aq)

# list images
docker image ls