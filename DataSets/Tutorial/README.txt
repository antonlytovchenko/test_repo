If you want to deploy your mongodb using replica set you have to use command:
	mongod --port <port of your host> --dbpath <where you will save your data> --replSet <name of replica set>
Example in Linux (warning command not tested!!! may be errors!!!):
	mongod --port 27001 --dbpath /home/DataBase --replSet MyReplicaSet
Example int windows:
	"C:\Program Files\MongoDB 2.6 Standard\bin\mongod.exe" --port 27001 --dbpath D:\DB\db1 --replSet MyReplicaSet
	
Using this command we run one daemon (service), to create more replication instances use the same command:
If you run on one machine use commands that I take after (the name of replicaset must be the same for every replication instance):
	"C:\Program Files\MongoDB 2.6 Standard\bin\mongod.exe" --port 27001 --dbpath D:\DB\db1 --replSet MyReplicaSet
	"C:\Program Files\MongoDB 2.6 Standard\bin\mongod.exe" --port 27002 --dbpath D:\DB\db2 --replSet MyReplicaSet
	"C:\Program Files\MongoDB 2.6 Standard\bin\mongod.exe" --port 27003 --dbpath D:\DB\db3 --replSet MyReplicaSet
	
After try to connect to db using command 
	"C:\Program Files\MongoDB 2.6 Standard\bin\mongo.exe" --port 27001
	
rs.initiate()
rs.add("xan-PC:27002")
rs.add("xan-PC:27003")
rs.status()
db.newDB.insert({name:"San",surname:"Ivanov",age:15})
db.newDB.insert({name:"Vova",surname:"ZiLvova",age:22})
db.newDB.insert({name:"Oleg",surname:"Petrov",age:23})