--RESTORE FILELISTONLY FROM DISK = 'C:\scc.bak'

-- EXEC sp_helpdb scctest

/* MAC */ 
use master;
alter database scctest set single_user with rollback immediate
RESTORE DATABASE scctest
from DISK = N'c:\scc.bak'
   WITH MOVE 'SCC' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\sccTest.mdf',
   MOVE 'SCC_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\sccTest_log.ldf',replace; 
alter database scctest set multi_user
go
use scctest
go
   
/* lenovo*/ 
use master;
alter database scctest set single_user with rollback immediate
RESTORE DATABASE scctest
from DISK = N'c:\scc.bak'
   WITH MOVE 'SCC' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.SQL2008\MSSQL\DATA\scctest.mdf',
   MOVE 'SCC_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.SQL2008\MSSQL\DATA\scctest_log.LDF',replace; 
alter database scctest set multi_user