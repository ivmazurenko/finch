#!/bin/bash

container_name="postgres_mock_container"
image_name="postgres_mock_image"

if docker ps -a | grep -q "$container_name"; then
  echo "Stopping and removing existing container: $container_name"
  docker stop "$container_name"
  docker rm "$container_name"
fi

docker build -t $image_name .
docker run -d --name "$container_name" -p 5432:5432  $image_name
