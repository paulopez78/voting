FROM node:slim

COPY . /app
WORKDIR /app

RUN npm install
RUN npm install bower -g
RUN bower --allow-root install

EXPOSE 3000/tcp

ENTRYPOINT npm start
