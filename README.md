# ATG

Tech Stack used in this project:

.Net core 3.1, EntityFramework Core, Autofac(DI container) , SQLServer, Repository Pattern
Test:Nunit and MOQ

Created seperate db context files for the three dbs , tried to use single one, assumed that there might be some schema differences between these 3 dbs , so added 3 different dbcontexts.

I assumed that, the Failover lots list will be picking up from db, so taken this route, If the failover history has been picking up from HAG , then need to get the data from HAG history query.
