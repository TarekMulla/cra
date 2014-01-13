use master;
alter database scc set single_user with rollback immediate
RESTORE DATABASE scc
from DISK = N'C:\Scc\BranchCoti\AlterTableInserts\CotizacionesIndirectas\BK_SCC\bk_scc'
   WITH MOVE 'SCC' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\scc.mdf',
   MOVE 'SCC_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\scc_log.LDF',replace; 
alter database scctest set multi_user
