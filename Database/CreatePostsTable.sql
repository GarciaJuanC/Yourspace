-- Create Posts Table
CREATE TABLE Posts
(
	AccountID	INT NOT NULL,
	photoPath	NVARCHAR(25),
	textPost	NVARCHAR(150),
	postTime	DATETIME NOT NULL,
	CONSTRAINT Post_pk PRIMARY KEY(AccountID, postTime),
	CONSTRAINT chk_null CHECK (photoPath IS NOT NULL OR textPost IS NOT NULL),
	CONSTRAINT Posts_fk FOREIGN KEY (AccountID) REFERENCES UserAccount(AccountID)
)

