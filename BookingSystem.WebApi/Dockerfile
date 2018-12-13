#FROM microsoft/dotnet:sdk AS build-env
#WORKDIR /app
#
## Copy and restore
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy remaining and build
#COPY . ./
#RUN dotnet publish -c Debug -o out
#
## Build new image for runtime, copy from prior image
#FROM microsoft/dotnet:aspnetcore-runtime
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]