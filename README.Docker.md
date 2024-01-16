# RUN INFRA

docker compose -f docker-compose.infra.yml stop && docker-compose -f docker-compose.infra.yml rm -f && docker compose -f docker-compose.infra.yml up --build

docker-compose -f docker-compose.api.yml stop && docker-compose -f docker-compose.api.yml rm -f && docker-compose -f docker-compose.api.yml up --build -d
