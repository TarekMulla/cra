/* lenovo*/ 
use master;
alter database scctest set single_user with rollback immediate
RESTORE DATABASE scctest
from DISK = N'c:\scc\scc.bak'
   WITH MOVE 'SCC' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\scctest.mdf',
   MOVE 'SCC_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\scctest_log.LDF',replace; 
alter database scctest set multi_user