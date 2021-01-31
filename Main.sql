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


