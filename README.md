## C# Bank Ledger  
Author: Adam Stabenow  
For: Incubator Program  
___
 **Description:** You have been tasked with writing the world’s greatest banking ledger. Please code a solution that can perform the following workflows through a console application (accessed via the command line): 
#### Tasks
- [x] Create a new account 
- [x] Login
- [x] Record a deposit
- [x] Record a withdrawal
- [x] Check balance
- [x] See transaction history
- [x] Log out
___

### Initial Thoughts
I have to admit that I was a little discouraged when I read that C# was required. I come from a JavaScript background and up to this point, I had never even thought about C#. My first instict was to ask if I could use Node, but I figured that if you wanted it done in Node you would have asked for it. Instead, I jumped on Google and started reading.
___
### Process
**Create new account:** Prompt user for input, create a new user object and save it to an object list.  

**Login:** Get username and pin check list for a match. If a match is found, log them in.  

**Withdrawal and deposit:** When a user adds or removes funds, update their balance to reflect changes.  

**Record transactions:**  After each transaction, create a new transaction record and save it to a list that is stored in the current user’s object.  

**Check balance:** Retrieve and display balance in terminal.  

**See transaction history:** Loop through transaction list and display each one in the terminal.  

**Logout:** Clear current user and return to the main menu.  
___
### Final Thoughts
I feel good that I was able to get the application up and running. It may not be ideal as a real-world application, but I am confident that with a little more time I will be able to build practical software with C#.
