#!/bin/bash
docker build -t paulopez/voting-api:latest -f ./DockerfileVotingApi .
docker push paulopez/voting-api

docker build -t paulopez/voting-admin:latest -f ./DockerfileVotingAdmin .
docker push paulopez/voting-admin
