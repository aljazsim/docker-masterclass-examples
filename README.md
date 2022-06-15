# Working with Docker images

## Exercise

1. Pull `datalust/seq` image
2. Create container
3. List containers
4. Start container
5. Attach to a container
6. Stop container
7. Delete container
8. Remove image

## Reference

### Image Commands

Commands: https://docs.docker.com/engine/reference/commandline/image/

| Description       | Command                                     | Arguments                                    |
| ----------------- | ------------------------------------------- | -------------------------------------------- |
| List images       | `docker image ls`                           | --quiet (only ids)                           |
| Pull image        | `docker image pull IMAGE_NAME `             |                                              |
| Remove image      | `docker image rm IMAGE_ID `                 | --force (even it it has a stopped container) |
| Remove all images | `docker image rm -f $(docker image ls -aq)` |                                              |

### Container Commands

Commands: https://docs.docker.com/engine/reference/commandline/container/

| Description     | Command                         | Arguments |
| --------------- | ------------------------------- | --------- |
| List containers | `docker container ls [OPTIONS]` |           |
