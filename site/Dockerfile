FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
COPY files /root/app
RUN apt update && \
  apt install -y wget && \
  wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
  dpkg -i packages-microsoft-prod.deb && \
  apt update && \
  apt install -y aspnetcore-runtime-3.1 dotnet-sdk-3.1 && \
  dotnet publish -o /root/publish /root/app/ && \
  mv /root/app/wwwroot /root/publish/wwwroot && \
  apt remove dotnet-sdk-3.1 -y && \
  rm -rf app .nuget .local && \
  apt autoremove -y && \
  apt clean
WORKDIR /root/publish
CMD [ "/usr/bin/dotnet", "/root/publish/VWAT.dll", "--urls=http://*" ]