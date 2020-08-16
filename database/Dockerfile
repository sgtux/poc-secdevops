FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
RUN apt install -y postgresql-12 && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 123) vwat && \
  cp /root/pg_hba.conf /etc/postgresql/12/main/pg_hba.conf && \
  cp /root/postgresql.conf /etc/postgresql/12/main/postgresql.conf && \
  cp /root/pre-script.sql /var/lib/postgresql && \
  service postgresql start && \
  runuser -l postgres -c "psql -f /var/lib/postgresql/pre-script.sql" && \
  cp /root/script.sql /home/vwat && \
  runuser -l vwat -c "psql -f /home/vwat/script.sql"
RUN chmod +x /root/init.sh
CMD [ "/root/init.sh" ]