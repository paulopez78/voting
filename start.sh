#!/bin/bash
docker build -t paulopez/voting-api:latest -f ./DockerfileVotingApi .
docker build -t paulopez/voting-admin:latest -f ./DockerfileVotingAdmin .

docker-compose up
