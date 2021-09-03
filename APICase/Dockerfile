FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG source
WORKDIR /app
COPY ${source:-./obj/docker/publish} .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "APICase.dll"]