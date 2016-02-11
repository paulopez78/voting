#!/bin/bash
cd ./Voting.Admin
docker build -t paulopez/voting-admin:latest .
docker push paulopez/voting-admin

cd ../Voting.Api
docker build -t paulopez/voting-api:latest .
docker push paulopez/voting-api

cd ../voting-ui
docker build -t paulopez/voting-ui:latest .
docker push paulopez/voting-ui
