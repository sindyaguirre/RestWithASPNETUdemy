CREATE TABLE PERSONS (
    Id INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(200) NULL DEFAULT NULL,
    LastName VARCHAR(200) NULL DEFAULT NULL,
    Address VARCHAR(200) NULL DEFAULT NULL,
    Gender VARCHAR(50) NULL DEFAULT NULL
)  ENGINE=INNODB
;