FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5001

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM node:16.10-alpine as client
WORKDIR /app
COPY ClientApp/package*.json ./
RUN npm config set unsafe-perm true
RUN npm install
RUN npm install -g @angular/cli@9.0.0
COPY ClientApp ./
RUN npm run-script publish

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["./JRovnyBlogManagement.csproj", "src/"]
RUN dotnet restore "src/JRovnyBlogManagement.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "JRovnyBlogManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JRovnyBlogManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client app/dist dist/
ENV ASPNETCORE_URLS http://*:5001
ENTRYPOINT ["dotnet", "JRovnyBlogManagement.dll"]
