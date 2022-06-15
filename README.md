# Creating Docker Images

Docker compose file:

## Scenario

1. check there is no images
2. check there is no containers
3. run docker compose up
4. verify web api is accessible form browser
5. verify web ui is accessible form browser
6. verify seq is accessible from browser
7. run docker compose down
8. check there is no images
9. check there is no containers

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
