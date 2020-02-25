SET IDENTITY_INSERT Account ON

--data for accounts
INSERT INTO Account(AccountID, Email, SaltValue, HashedPass) VALUES
	(001, 'bruce.wayne@gmail.com', 'abcdefghijklmnop', 'pass'),
	(002, 'calrk.kent@dailyplanet.net', 'abcdefghijklmnop', 'word'),
	(006, 'juan.garcia@student.csulb.edu', 'abcdefghijklmnop', 'securitydoesntmatter'),
	(007, 'daniel.flores03@student.csulb.edu', 'abcdefghijklmnop', 'qwerty!@#');

--data for users
INSERT INTO UserAccount(AccountID, FirstName, LastName, DateOfBirth, PhoneNumber) VALUES
	(001, 'Bruce', 'Wayne', '1938-03-20', 454532287),
	(002, 'Clark', 'Kent', '1938-04-18', 44283539),
	(006, 'Juan', 'Garcia', '1999-12-31', 8675309);

INSERT INTO AdminAccount(AccountID, AccessLevel) VALUES
	(007, 1);

SET IDENTITY_INSERT Account OFF