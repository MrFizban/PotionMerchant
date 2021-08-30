#!/bin/bash

docker stop PotionMongo PotionStore

docker network create potionNetwork



docker run -d --rm --name PotionMongo -p 27017:27017 -v mongobdata:/data/db \
    -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass \
    --network=potionNetwork mongo


docker build -t mrfizban/potion:test .

docker run -it --rm -p 8081:80 --name PotionStore \
    -e MongoDbSettings:Host=PotionMongo -e MongoDbSettings:Password=Pass \
    --network=potionNetwork mrfizban/potion:test
