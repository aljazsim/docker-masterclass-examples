# Working with Docker Compose

## Exercise

1. check there is no images
2. check there is no containers
3. run docker compose up
4. verify web api is accessible form browser
5. verify web ui is accessible form browser
6. verify seq is accessible from browser
7. run docker compose down
8. check there is no images
9. check there is no containers

## Reference

### Image Commands

Commands: <https://docs.docker.com/engine/reference/commandline/image/>

| Description       | Command                                      | Options                                                                      |
| ----------------- | -------------------------------------------- | ---------------------------------------------------------------------------- |
| List images       | `docker image ls`                            | --quiet (only image ids)                                                     |
| Pull image        | `docker image pull IMAGE_NAME`               |                                                                              |
| Remove image      | `docker image rm IMAGE_ID`                   | --force (even it it has a stopped container)                                 |
| Remove all images | `docker image rm -f $(docker image ls -aq)`  |                                                                              |
| Build image       | `docker image build [OPTIONS] PATH`          | --file (Dockerfile file path; defaults to "Dockerfile" in current directory) |
|                   |                                              | --tag tag (name or tag the image)                                            |
| Push image        | `docker image push [OPTIONS] NAME[:TAG]`     |                                                                              |
| Export image      | `docker image save –output ./image_name.tgz` |                                                                              |
| Import image      | `docker load –input ./image_name.tgz`        |                                                                              |

### Container Commands

Commands: <https://docs.docker.com/engine/reference/commandline/container/>

| Description           | Command                                                   | Options                                                                  |
| --------------------- | --------------------------------------------------------- | ------------------------------------------------------------------------ |
| List containers       | `docker container ls [OPTIONS]`                           | --all (all containers, not just running ones)                            |
|                       |                                                           | --quiet (only container ids)                                             |
| Create container      | `docker container create [OPTIONS] IMAGE`                 | --name (container name)                                                  |
|                       |                                                           | --env key=value (set environment variable)                               |
|                       |                                                           | --publish external_port:internal_port (expose listening port)            |
|                       |                                                           | --volume external_volume:internal_volume (expose volume)                 |
|                       |                                                           | --network=network_name (expose volume)                                   |
|                       |                                                           | --memory memory_limit (container memory limit, e.g. 1g)                  |
|                       |                                                           | --restart restart_policy (container restart policy; e.g. unless-stopped) |
| Start container       | `docker container start [OPTIONS] CONTAINER`              |                                                                          |
| Run container         | `docker container run [OPTIONS] IMAGE [COMMAND] [ARG...]` | same options as creating container                                       |
|                       |                                                           | --detach (run in detached mode)                                          |
| View container logs   | `docker logs [OPTIONS] CONTAINER`                         | --follow (keep updating output with new log entries)                     |
| Stop container        | `docker container stop [OPTIONS] CONTAINER`               | --time seconds (delay stopping the container)                            |
| Stop all containers   | `docker container stop $(docker container ls -aq)`        |                                                                          |
| Remove container      | `docker container rm [OPTIONS] CONTAINER`                 | --force (stop first if running)                                          |
| Remove all containers | `docker container rm $(docker container ls -aq)`          |                                                                          |

### Docker Compose Commands

Commands: <https://docs.docker.com/engine/reference/commandline/container/>

| Description         | Command                                     | Arguments                                        | Options                                                   |
| ------------------- | ------------------------------------------- | ------------------------------------------------ | --------------------------------------------------------- |
| Docker Compose up   | `docker-compose [ARGUMENTS] up [OPTIONS]`   | --project_name name (groups all containers)      | --detach (run containers in detached mode)                |
|                     |                                             | --file file_path (docker-compose.yaml file path) | --build (builds images)                                   |
|                     |                                             |                                                  | --force-recreate (re-pulls and re-builds existing images) |
| Docker Compose down | `docker-compose [ARGUMENTS] down [OPTIONS]` | --project_name name (groups all containers)      | --rmi all (removes referenced images)                     |
|                     |                                             | --file file_path (docker-compose.yaml file path) | --volumes (removes volumes)                               |

## Links

| Container   | URL                    |
| ----------- | ---------------------- |
| SEQ         | http://localhost:5340/ |
| Weather API | http://localhost:9991/ |
| Weather UI  | http://localhost:9992/ |
