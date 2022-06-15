Set-Location $PSScriptRoot

Set-Location -Path "./Source"

# list images
docker image ls

# list containers
docker container ls --all

# docker compose up (pull/build images, start containers)
docker compose --project-name "weatherapp" --file "./Docker-compose.yaml" up --detach --build --force-recreate

# list images
docker image ls

# list containers
docker container ls --all

# verify "web api" container is accessible from browser
Start-Process "http://localhost:9991/weather"

# verify "web ui" container is accessible from browser
Start-Process "http://localhost:9992/"

# verify "seq" container is accessible from browser
Start-Process "http://localhost:5340/"

# list container performance logs
Get-ChildItem -Path "C:\Development\Data\Docker"

# show weather api performance log
Get-Content -Path "C:\Development\Data\Docker\weather.api.csv" | select -First 10

# show weather ui performance log
Get-Content -Path "C:\Development\Data\Docker\weather.ui.csv" -Wait | select -First 10

# docker compose down (stop and remove containers, remove images)
docker compose --project-name "weatherapp" --file "./Docker-compose.yaml" down --rmi all --volumes

# list containers
docker container ls --all

# list images
docker image ls