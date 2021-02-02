-- Table for a User Account
CREATE TABLE ACCOUNT (
account_id INT NOT NULL,
account_firstname VARCHAR(30) NOT NULL,
account_lastname VARCHAR(30) NOT NULL,
account_username VARCHAR(30) NOT NULL,
account_password VARCHAR(30) NOT NULL,
account_email VARCHAR(30) NOT NULL,

CONSTRAINT account_pk PRIMARY KEY (account_id),
CONSTRAINT account_uk01 UNIQUE KEY (account_username),
CONSTRAINT account_uk02 UNIQUE KEY (account_email)
);

-- Table for Community Engagement page
CREATE TABLE DISCUSSION (
discussion_id INT NOT NULL,
discussion_title VARCHAR(30) NOT NULL,
discussion_description VARCHAR(300) NOT NULL,
discussion_picture BLOB,
account_id INT NOT NULL,
account_username VARCHAR(30) NOT NULL,

CONSTRAINT discussion_pk PRIMARY KEY (discussion_ID),
CONSTRAINT discussion_fk01 FOREIGN KEY (account_id) REFERENCES ACCOUNT (account_id),
CONSTRAINT discussion_fk02 FOREIGN KEY (account_username) REFERENCES ACCOUNT (account_username)
);

-- Table for User Feedback page
CREATE TABLE ISSUE (
issue_id INT NOT NULL,
issue_title VARCHAR(30) NOT NULL,
issue_description VARCHAR(300) NOT NULL,
issue_picture BLOB,
account_id INT NOT NULL,
account_username VARCHAR(30) NOT NULL,

CONSTRAINT issue_pk PRIMARY KEY (issue_ID),
CONSTRAINT issue_fk01 FOREIGN KEY (account_id) REFERENCES ACCOUNT (account_id),
CONSTRAINT issue_fk02 FOREIGN KEY (account_username) REFERENCES ACCOUNT (account_username)
);




-- CREATE TABLE SETTINGS (
-- TextMessageReminders BOOL,
-- PushNotifications BOOL,
-- VoiceShortcuts BOOL,
-- EmailValidation BOOL,
-- Email VARCHAR(30) NOT NULL,

-- CONSTRAINT settings_fk FOREIGN KEY (Email) REFERENCES ACCOUNT (Email)
-- );

-- CREATE TABLE PARKINGSPOT (
-- StreetAddress VARCHAR(30) NOT NULL,
-- Latitude VARCHAR(30) NOT NULL,
-- Longitude VARCHAR(30) NOT NULL,
-- DaysAvailable VARCHAR(30) NOT NULL,
-- TimesAvailable VARCHAR(30) NOT NULL,
-- Favorites BOOL,

-- CONSTRAINT parkingspot_pk PRIMARY KEY (Latitude, Longitude)
-- );
