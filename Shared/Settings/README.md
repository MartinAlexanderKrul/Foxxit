# Setting Environment Variables for Connection String
<p>This is easy manual how to set environment variables on Windows. For macOS and Linux Distributions follow this link: https://www.twilio.com/blog/2017/01/how-to-set-environment-variables.html</p>

## Windows
1. Open Windows Run prompt (Windows + R)
2. Type **sysdm.cpl** into the input field and hit Enter or press Ok. 
<img src="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/img/w1.png" width="500px">
3. Click on the *Advanced tab* and afterwards on the *Environment Variables* button in the bottom right of the window. 
<img src="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/img/w2.png" width="500px"> <img src="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/img/w3.png" width="500px">
4. Add variables with the same format as it is displayed down <a href="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/README.md#format-of-variables">(link)</a>.
<img src="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/img/w4.png" width="500px"> <img src="https://github.com/MartinAlexanderKrul/DevelopingMyself/blob/master/img/w5.png" width="500px">

## Format of variables
<p>You need to add both variables! DbType and MyDbConnection exactly like it is below. </p>

### Using MSSQL
```
Variable name: DbType
Variable value: MSSQL
```
```
Variable name: MyDbConnection
Variable value: Server=(localdb)\MSSQLLocalDB;Database=Foxxit;Trusted_Connection=True;MultipleActiveResultSets=true
```

### Using SQLLite
```
Variable name: DbType
Variable value: SQLite
```
```
Variable name: MyDbConnection
Variable value: Data Source=foxxit.db;Version=3
```

### Using Heroku
```
Variable name: DbType
Variable value: Heroku
```
```
Variable name: MyDbConnection
Variable value: Host=ec2-54-246-87-132.eu-west-1.compute.amazonaws.com;Port=5432;Database=d7r9g36dv1q91n;User ID=kzwcgjmmqlufde;Password=<PUTACTUALPASSWORDHERE>;TrustServerCertificate = true;SSL Mode=Require;Pooling=true
```
