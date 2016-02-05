FROM node:slim

COPY . /app
WORKDIR /app
RUN ["npm", "update"]

EXPOSE 3000/tcp

ENTRYPOINT npm start
