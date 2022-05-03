# Creating Docker Images

Docker compose file:

## Scenario

1. Show `/Source/WebApi/Dockerfile`
2. Show `/Source/WebUi/Dockerfile`
   1. Buid
      1. ARG
      2. RUN sed
3. Show `/Source/Docker-compose.yaml`
   1. seq
      1. volumes
      2. restart policy
   2. weather.api
      1. context
      2. dockerfile
      3. depends on
      4. environment (how seq is referenced internally)
   3. weather.ui
      1. context
      2. dockerfile
      3. args
4. Run docker compose up
5. Show apps (UI, API, SEQ)
6. Show images, containers
7. Run docker compose down
8. Show images, containers

## Examples

|     | Command                                                                                                      | Comment                            |
| --- | ------------------------------------------------------------------------------------------------------------ | ---------------------------------- |
| 1   | `docker compose --project-name weatherapp --file ./Docker-compose.yaml up --detach --build --force-recreate` | build images and create containers |
| 2   | `docker image ls`                                                                                            |                                    |
| 3   | `docker container ls --all`                                                                                  |                                    |
| 4   | `docker compose --project-name weatherapp --file ./Docker-compose.yaml down --rmi all`                       | remove containers and images       |
| 5   | `docker image ls`                                                                                            |                                    |
| 6   | `docker container ls --all`                                                                                  |                                    |

## Links

| Container   | URL                    |
| ----------- | ---------------------- |
| SEQ         | http://localhost:5340/ |
| Weather API | http://localhost:9991/ |
| Weather UI  | http://localhost:9992/ |

## Clean up

```
docker container stop $(docker container ls --all --quiet)
docker container rm $(docker container ls --all --quiet)
docker image rm -f $(docker image ls -aq)
```
