FROM microsoft/dotnet:latest
FROM postgres:latest
EXPOSE 5432

MAINTAINER Marcin Walczak <info@elitesoftware.eu>
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000"]