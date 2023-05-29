# Etapa de construcción
FROM node:14.16.1-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

# Etapa de producción
FROM nginx:1.21.3-alpine
COPY --from=build /app/dist/TaskManagement-Front /usr/share/nginx/html
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]