#Installation Manuel

after each installation is a restart required!

1.[Install Docker](https://docs.docker.com/desktop/install/windows-install/)

2.download the [image mariadb](https://mariadb.com/kb/en/installing-and-using-mariadb-via-docker/)

3.create ca container from the docker image(with root password: admin) 
cmd:(docker run --name zoo -e MYSQL_ROOT_PASSWORD=admin -p 3306:3306 -d docker.io/library/mariadb:10.4)

4.[install .net7](https://dotnet.microsoft.com/en-us/download)

5.[install nodejs](https://nodejs.org/en/download)

6.open in rider the repository (aufgabe-5-zoo-applikation-felix368)
/alternative VScode

7.change the current branch to work

8.run the container ()

9.connect rider with your database to 
/ alternative open cmd and connect to running database (docker exec -it zoodb mariadb --user root -padmin)

10.execute all create and Insert commands from the createDB.sql file

11.start the program.cs file with http
/ alternative navigate to the folder with the file Program.cs and type (dotnet run)

12.open the terminal and navigate to the frontend folder

13.execute npm install 

14.then enter the command npm Run Dev

15.Now Open The website

