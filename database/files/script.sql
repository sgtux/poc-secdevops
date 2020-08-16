CREATE TABLE "Comment" (
  "Id" SERIAL, 
  "Description" VARCHAR, 
  "Date" TIMESTAMP
);

CREATE TABLE "User" (
  "Id" SERIAL, 
  "Name" VARCHAR, 
  "Email" VARCHAR, 
  "Password" VARCHAR
);

INSERT INTO "User"
  ("Name", "Email", "Password") 
VALUES 
  ('admin', 'admin@mail.com', 'admin123'),
  ('contact', 'contact@mail.com', 'contact123');