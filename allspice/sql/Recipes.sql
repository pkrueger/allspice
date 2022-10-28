-- Active: 1666715598134@@SG-kiwi-myrtle-9554-6832-mysql-master.servers.mongodirector.com@3306@stuff

CREATE TABLE
    IF NOT EXISTS recipes (
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title VARCHAR(255) NOT NULL,
        img VARCHAR(255) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';