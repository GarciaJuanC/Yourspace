-- Create Account table
CREATE TABLE Account
(
    AccountID	INT IDENTITY UNIQUE NOT NULL,
	Email		NVARCHAR(255) UNIQUE NOT NULL,
	SaltValue	NVARCHAR(16) NOT NULL,
	HashedPass	NVARCHAR(255) NOT NULL,
	CONSTRAINT Account_pk PRIMARY KEY (AccountID)
)

CREATE TABLE UserAccount
(
	AccountID	INT UNIQUE NOT NULL,
	FirstName	NVARCHAR(128) NOT NULL,
	MiddleName	NVARCHAR(128),
    LastName	NVARCHAR(128) NOT NULL,
	DateOfBirth DATE,
	PhoneNumber NVARCHAR(15),
	PhotoPath	NVARCHAR(100),
	Biography	NVARCHAR(255),
	uLocation	NVARCHAR(50),
	Occupation	NVARCHAR(70),
	FriendsList NVARCHAR(MAX),
	CONSTRAINT UserAccount_pk PRIMARY KEY(AccountID),
	CONSTRAINT UserAccount_fk FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
)

CREATE TABLE AdminAccount
(
	AccountID 	INT UNIQUE NOT NULL,
	AccessLevel INT,
	CONSTRAINT AdminAcount_pk PRIMARY KEY(AccountID),
	CONSTRAINT AdminAccount_fk FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
)
