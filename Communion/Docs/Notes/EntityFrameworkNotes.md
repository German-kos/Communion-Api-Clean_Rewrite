# Some Person's EF Rules of Thumb I Liked

1) Understand that call to database made only when the actual records are required. all the operations are just used to make the query (SQL) so try to fetch only a piece of data rather then requesting a large number of records. Trim the fetch size as much as possible
</br>
2) Yes, (In some cases stored procedures are a better choice, they are not that evil as some make you believe), you should use stored procedures where necessary. Import them into your model and have function imports for them. You can also call them directly ExecuteStoreCommand(), ExecuteStoreQuery(). Same goes for functions and views but EF has a really odd way of calling functions "SELECT dbo.blah(@id)".
</br>
3) EF performs slower when it has to populate an Entity with deep hierarchy. be extremely careful with entities with deep hierarchy
</br>
4) Sometimes when you are requesting records and you are not required to modify them you should tell EF not to watch the property changes (AutoDetectChanges). that way record retrieval is much faster
</br>
5) Indexing of database is good but in case of EF it becomes very important. The columns you use for retrieval and sorting should be properly indexed.
</br>
6) When you model is large, VS2010/VS2012 Model designer gets real crazy. so break your model into medium sized models. There is a limitation that the Entities from different models cannot be shared even though they may be pointing to the same table in the database.
</br>
7) When you have to make changes in the same entity at different places, use the same entity, make changes and save it only once. The point is to AVOID retrieving the same record, make changes & save it multiple times. (Real performance gain tip).
</br>
8) When you need the info in only one or two columns try not to fetch the full entity. you can either execute your sql directly or have a mini entity something. You may need to cache some frequently used data in your application also.
</br>
9) Transactions are slow. be careful with them.
</br>
10) SQL Profiler or any query profiler is your friend. Run it when developing your application to see what does EF sends to database. When you perform a join using LINQ or Lambda expression in ur application, EF usually generates a Select-Where-In-Select style query which may not always perform well. If u find any such case, roll up ur sleeves, perform the join on DB and have EF retrieve results. (I forgot this one, the most important one!)
