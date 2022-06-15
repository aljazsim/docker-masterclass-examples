# Working with Docker images

## Exercise

1. Pull an image from [Docker Hub](https://hub.docker.com/)
2. List images
3. Remove image

## Reference

Commands: https://docs.docker.com/engine/reference/commandline/image/

| Description       | Command                                     |
| ----------------- | ------------------------------------------- |
| List images       | `docker image ls`                           |
| Pull image        | `docker image pull IMAGE_NAME `             |
| List image IDs    | `docker image ls --quiet `                  |
| Remove image      | `docker image rm IMAGE_ID `                 |
| Remove all images | `docker image rm -f $(docker image ls -aq)` |
