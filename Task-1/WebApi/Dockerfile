FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS builder
ARG PUBLISH_PROFILE
ARG SOLUTION

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY $SOLUTION ./
COPY WebApi ./WebApi
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/out $SOLUTION /p:PublishProfile=$PUBLISH_PROFILE
RUN ls -la

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

WORKDIR /app

COPY --from=builder /app/out .