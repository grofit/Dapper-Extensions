﻿CREATE TABLE FOOTABLE (
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1, NO CACHE) PRIMARY KEY,
    FIRSTNAME NVARCHAR(50),
    LASTNAME NVARCHAR(50),
    DATEOFBIRTH DATE
);