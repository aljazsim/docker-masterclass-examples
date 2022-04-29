# build
FROM node:16-alpine3.14 AS builder
WORKDIR /app
COPY . .
RUN npm install -g npm@8.8.0
RUN npm install
RUN npm run build

# serve
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /app/dist .
ENTRYPOINT ["nginx", "-g", "daemon off;"]