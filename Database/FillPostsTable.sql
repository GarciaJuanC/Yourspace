INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(1, NULL, 'Juan Post 1', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(1, NULL, 'Juan Post 2', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(1, NULL, 'Juan Post 3', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(22, NULL, 'Dan Post 1', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(22, NULL, 'Dan Post 2', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(22, NULL, 'Dan Post 3', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(29, NULL, 'Jocelyn Post 1', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(29, NULL, 'Jocelyn Post 2', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(29, NULL, 'Jocelyn Post 3', CURRENT_TIMESTAMP);

-- Query to get all of a user's posts
SELECT UserAccount.FirstName, UserAccount.LastName, UserAccount.AccountID, textPost
FROM UserAccount
INNER JOIN Posts 
ON UserAccount.AccountID = Posts.AccountID;

-- Query all rows and columns from Posts
SELECT *
FROM Posts

-- Query all rows and columns from UserAccount
SELECT *
FROM UserAccount