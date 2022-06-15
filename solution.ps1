Set-Location $PSScriptRoot

# create Dockerfile in VS

# copy Dockerfile to parent directory
Set-Location -Path "./Source"
Copy-Item -Path "./WeatherApi/Dockerfile" -Destination "./Dockerfile"

# list images
docker image ls

# build image
docker image build --tag weatherapi:latest .

# list images
docker image ls

# list containers
docker container ls --all

# create "brisbane" container
docker container create --publish 9991:80 --name weatherapibrisbane weatherapi

# list containers
docker container ls --all

# start "brisbane" container
docker container start weatherapibrisbane

# list containers
docker container ls --all

# verify "brisbane" container is accessible from browser
Start-Process "http://localhost:9991/weather"

# create "melbourne" container
docker container create --publish 9992:80 --env "Weather:City=Melbourne" --name weatherapimelbourne weatherapi

# list containers
docker container ls --all

# start "melbourne" container
docker container start weatherapimelbourne

# list containers
docker container ls --all

# verify "melbourne" container is accessible from browser
Start-Process "http://localhost:9992/weather"

# stop all containers
docker container stop $(docker container ls -aq)

# list containers
docker container ls --all

# remove all containers
docker container rm $(docker container ls -aq)

# list containers
docker container ls --all

# remove all images
docker image rm -f $(docker image ls -aq)

# list images
docker image ls