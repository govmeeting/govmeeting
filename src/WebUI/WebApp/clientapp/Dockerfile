# Stage 1
FROM node:14-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build:staging

# Stage 2
FROM nginx:alpine
# Serve index.html for all deep-link paths
COPY config/nginx.conf /etc/nginx/nginx.conf
# Remove prior default
RUN rm /etc/nginx/conf.d/default.conf
# Copy clientapp distribution files
COPY --from=build /usr/src/app/dist /usr/share/nginx/html
