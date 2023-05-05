DROP TABLE IF EXISTS users;
CREATE TABLE users(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT UNIQUE 
);

DROP TABLE IF EXISTS applications;
CREATE TABLE applications(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT UNIQUE
);

DROP TABLE IF EXISTS information;
CREATE TABLE information(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    userName TEXT,
    appName TEXT,
    comment TEXT,
    FOREIGN KEY (appName) REFERENCES applications(name) ON DELETE CASCADE,
    FOREIGN KEY (userName) REFERENCES users(name) ON DELETE CASCADE
);

INSERT INTO users(name) VALUES ('Vasya');
INSERT INTO users(name) VALUES ('Vova');

INSERT INTO applications(name) VALUES ('Roblox');
INSERT INTO applications(name) VALUES ('Minecraft');

INSERT INTO information(userName, appName, comment) VALUES ('Vasya', 'Minecraft', 'Vasya make Minecraft');
INSERT INTO information(userName, appName, comment) VALUES ('Vova', 'Roblox', 'Vova make Roblox');

