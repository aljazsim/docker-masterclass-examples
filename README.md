# Working with Docker containers

Docker Hub reference: https://hub.docker.com/r/datalust/seq

|     | Description         | Command                                                                                                           | Comments                                     |
| --- | ------------------- | ----------------------------------------------------------------------------------------------------------------- | -------------------------------------------- |
| 1.  | List images         | docker image ls                                                                                                   |                                              |
| 2.  | Pull image          | docker image pull datalust/seq                                                                                    |                                              |
| 3.  | Create container    | docker container create --name mycontainer --interactive --tty --env ACCEPT_EULA=Y --publish 5341:80 datalust/seq |                                              |
| 4.  | List containers     | docker container list --all                                                                                       | Must use --all (container is stopped)        |
| 5.  | Start container     | docker start mycontainer                                                                                          |                                              |
| 6.  | List containers     | docker container list --all                                                                                       |                                              |
| 8.  | Attach to container | docker container attach --detach-keys="ctrl-d" mycontainer                                                        | Use Ctrl+d to exit                           |
| 9.  | Stop container      | docker container stop mycontainer                                                                                 |                                              |
| 10. | List containers     | docker container list --all                                                                                       |                                              |
| 11. | Run container       | docker container run --name mycontainer --env ACCEPT_EULA=Y --publish 5341:80 datalust/seq                        | Running in attached mode, use Ctrl+c to kill |
| 12. | List containers     | docker container list --all                                                                                       |                                              |
| 13. | Remove containers   | docker container stop $(docker container ls --all --quiet)                                                        |                                              |
| 14. | List containers     | docker container list --all                                                                                       |                                              |
| 15. | List images         | docker image ls                                                                                                   |                                              |
| 16. | Remove images       | docker image rm -f $(docker image ls -aq)                                                                         |                                              |
| 17. | List images         | docker image ls                                                                                                   |                                              |
