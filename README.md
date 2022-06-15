# Creating Docker images

## Exercise

1. Open solution in VS
2. Create Dockerfile in VS
3. Move Dockerfile to parent directory
4. List images
5. Build image
6. List images
7. List containers
8. Create container from image (--publish 9991:80 --name weatherapibrisbane)
9. List containers
10. Start container
11. List containers
12. Verify container is accessible in browser
13. Create second container on different port, with different name for different city
14. Start second container
15. Verify second container is accessible in browser
16. List containers
17. Stop all containers
18. List containers
19. Stop all images
20. List all images

## Reference

### Image Commands

Commands: <https://docs.docker.com/engine/reference/commandline/image/>

| Description       | Command                                      | Arguments                                                                    |
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

| Description           | Command                                                   | Arguments                                                                |
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
