-- Active: 1666715598134@@SG-kiwi-myrtle-9554-6832-mysql-master.servers.mongodirector.com@3306@stuff

CREATE TABLE
    IF NOT EXISTS favorites(
        id VARCHAR(255) NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id),
        FOREIGN KEY (recipeId) REFERENCES recipes(id)
    ) default charset utf8 COMMENT '';