#!/bin/bash
cd ./Voting.Admin
dnu restore
dnu publish

cd ../Voting.Api
dnu restore
dnu publish

cd ../voting-ui
npm update
bower update

cd ..
docker-compose build
docker-compose up
