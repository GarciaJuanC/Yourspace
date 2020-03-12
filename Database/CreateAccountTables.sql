-- Create Account table
CREATE TABLE Account
(
    AccountID	INT IDENTITY NOT NULL,
	Email		NVARCHAR(255) NOT NULL,
	SaltValue	NVARCHAR(16) NOT NULL,
	HashedPass	NVARCHAR(255) NOT NULL,
	CONSTRAINT Account_pk PRIMARY KEY (AccountID)
)

CREATE TABLE UserAccount
(
	AccountID	INT NOT NULL,
	FirstName	NVARCHAR(128) NOT NULL,
    LastName	NVARCHAR(128) NOT NULL,
	DateOfBirth DATE,
	PhoneNumber NVARCHAR(15),
	PhotoPath	NVARCHAR(100),
	CONSTRAINT UserAccount_pk PRIMARY KEY(AccountID),
	CONSTRAINT UserAccount_fk FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
)

CREATE TABLE AdminAccount
(
	AccountID 	INT NOT NULL,
	AccessLevel INT,
	CONSTRAINT AdminAcount_pk PRIMARY KEY(AccountID),
	CONSTRAINT AdminAccount_fk FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
)
