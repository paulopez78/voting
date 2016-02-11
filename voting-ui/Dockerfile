FROM node:slim

RUN apt-get update && apt-get install git -y

COPY . /app
WORKDIR /app

RUN npm update && npm install -g bower
RUN bower --allow-root install

EXPOSE 3000/tcp

ENTRYPOINT npm start
