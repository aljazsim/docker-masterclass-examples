# Creating Docker Images

Docker compose file:

## Scenario

1. Run in VS
2. Run in Docker

## Examples

|     | Command                                                                                                      | Comment                            |
| --- | ------------------------------------------------------------------------------------------------------------ | ---------------------------------- |
| 1   | `docker compose --project-name weatherapp --file ./Docker-compose.yaml up --detach --build --force-recreate` | build images and create containers |
| 2   | `docker image ls`                                                                                            |                                    |
| 3   | `docker container ls --all`                                                                                  |                                    |
| 4   | `docker compose --project-name weatherapp --file ./Docker-compose.yaml down --rmi all`                       | remove containers and images       |
| 5   | `docker image ls`                                                                                            |                                    |
| 6   | `docker container ls --all`                                                                                  |                                    |

## Directories

| Directory path                             |
| ------------------------------------------ |
| C:\Development\Data\Docker\weather.api.csv |
| C:\Development\Data\Docker\weather.ui.csv  |

## Clean up

```
docker container stop $(docker container ls --all --quiet)
docker container rm $(docker container ls --all --quiet)
docker image rm -f $(docker image ls -aq)
```
