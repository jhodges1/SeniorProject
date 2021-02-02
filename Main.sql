CREATE TABLE ACCOUNT (
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Email VARCHAR(30) NOT NULL,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(30) NOT NULL,

CONSTRAINT account_pk PRIMARY KEY (Email),
CONSTRAINT account_uk UNIQUE KEY (Username)
);

CREATE TABLE SETTINGS (
TextMessageReminders BOOL,
PushNotifications BOOL,
VoiceShortcuts BOOL,
EmailValidation BOOL,
Email VARCHAR(30) NOT NULL,

CONSTRAINT settings_fk FOREIGN KEY (Email) REFERENCES ACCOUNT (Email)
);

CREATE TABLE PARKINGSPOT (
StreetAddress VARCHAR(30) NOT NULL,
Latitude VARCHAR(30) NOT NULL,
Longitude VARCHAR(30) NOT NULL,
DaysAvailable VARCHAR(30) NOT NULL,
TimesAvailable VARCHAR(30) NOT NULL,
Favorites BOOL,

CONSTRAINT parkingspot_pk PRIMARY KEY (Latitude, Longitude)
);

-- Table for User Feedback page
CREATE TABLE ISSUE (
issue_id INT(10) NOT NULL,
issue_title VARCHAR(30) NOT NULL,
issue_description VARCHAR(300) NOT NULL,
issue_picture BLOB,
Username VARCHAR(30) NOT NULL,

CONSTRAINT issue_pk PRIMARY KEY (issue_ID),
CONSTRAINT issue_fk FOREIGN KEY (Username) REFERENCES ACCOUNT (Username)
);

-- Table for Community Engagement page
CREATE TABLE DISCUSSION (
discussion_id INT(10) NOT NULL,
discussion_title VARCHAR(30) NOT NULL,
discussion_description VARCHAR(300) NOT NULL,
discussion_picture BLOB,
Username VARCHAR(30) NOT NULL,

CONSTRAINT discussion_pk PRIMARY KEY (discussion_ID),
CONSTRAINT discussion_fk FOREIGN KEY (Username) REFERENCES ACCOUNT (Username)
);
