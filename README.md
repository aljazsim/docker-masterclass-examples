# Working with Docker images

## Exercise

1. Pull an image from [Docker Hub](https://hub.docker.com/)
2. List images
3. Remove image

## Reference

Commands: https://docs.docker.com/engine/reference/commandline/image/

| Description       | Command                                     | Arguments                                    |
| ----------------- | ------------------------------------------- | -------------------------------------------- |
| List images       | `docker image ls`                           | --quiet (only ids)                           |
| Pull image        | `docker image pull IMAGE_NAME `             |                                              |
| Remove image      | `docker image rm IMAGE_ID `                 | --force (even it it has a stopped container) |
| Remove all images | `docker image rm -f $(docker image ls -aq)` |                                              |
