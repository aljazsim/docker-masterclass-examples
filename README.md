# Creating Docker Images

|     | Command                                                                                                        | Comment                                       |
| --- | -------------------------------------------------------------------------------------------------------------- | --------------------------------------------- |
| 1   | create Dockerfile                                                                                              | right click on project / add / docker support |
| 5   | docker image build --tag weatherapi:latest .                                                                   |                                               |
| 6   | docker image ls                                                                                                |                                               |
| 7   | docker container ls --all                                                                                      |                                               |
| 8   | docker container create --publish 9991:80 --name weatherapibrisbane weatherapi                                 |                                               |
| 9   | docker container start weatherapibrisbane                                                                      |                                               |
| 10  | docker container ls --all                                                                                      |                                               |
| 11  | docker container create --publish 9992:80 --env "Weather:City=Melbourne" --name weatherapimelbourne weatherapi |                                               |
| 12  | docker container start weatherapimelbourne                                                                     |                                               |
| 13  | docker container ls --all                                                                                      |                                               |
| 14  | docker container attach weatherapimelbourne                                                                    |                                               |

## Clean up

```
docker container stop $(docker container ls --all --quiet)
docker container rm $(docker container ls --all --quiet)
docker image rm -f $(docker image ls -aq)
```
