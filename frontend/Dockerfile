FROM node:23 as build-stage

WORKDIR /frontend

COPY . .

RUN npm install

EXPOSE 5173

CMD ["npm", "run", "dev"]