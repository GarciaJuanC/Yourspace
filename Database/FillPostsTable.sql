INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(20, NULL, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Vivamus fringilla feugiat velit.', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(20, NULL, 'Lorem Fusce facilisis vel sem et semper.
                    Donec tempus tortor sed ultricies mollis.', CURRENT_TIMESTAMP);

INSERT INTO Posts(AccountID, photoPath, textPost, postTime) VALUES
		(20, NULL, 'In hac habitasse platea dictumst. Phasellus sit amet risus in ligula imperdiet
                     tincidunt ut in diam.', CURRENT_TIMESTAMP);


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