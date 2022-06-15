# Working with Docker images

## Exercise

1. List images
2. Pull **datalust/seq** image
3. List images
4. Create container (see SEQ image configuration reference on Docker Hub)
5. List containers (note: only running containers are displayed by default)
6. Start container
7. List containers
8. Verify SEQ is accessible in a browser
9. View container logs
10. Stop container
11. List containers
12. Verify SEQ is no longer accessible in a browser
13. Remove container
14. List containers
15. Remove image
16. List images

## Reference

### Image Commands

Commands: <https://docs.docker.com/engine/reference/commandline/image/>

| Description       | Command                                     | Arguments                                    |
| ----------------- | ------------------------------------------- | -------------------------------------------- |
| List images       | `docker image ls`                           | --quiet (only image ids)                     |
| Pull image        | `docker image pull IMAGE_NAME`              |                                              |
| Remove image      | `docker image rm IMAGE_ID`                  | --force (even it it has a stopped container) |
| Remove all images | `docker image rm -f $(docker image ls -aq)` |                                              |

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
