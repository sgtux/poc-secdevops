FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
RUN apt update -y && \
    apt install -y net-tools wget software-properties-common curl git && \
    wget -q -O - https://pkg.jenkins.io/debian-stable/jenkins.io.key | apt-key add - && \
    sh -c 'echo deb https://pkg.jenkins.io/debian-stable binary/ > /etc/apt/sources.list.d/jenkins.list' && \
    wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt update && \
    apt install -y jenkins dotnet-sdk-3.1 openjdk-8-jdk && \
    apt autoremove -y && \
    apt clean
CMD ["java" "-jar" "/usr/share/jenkins/jenkins.war" "--httpPort=80"]