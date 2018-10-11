/****** Object:  LinkedServer [FAMOUS]    Script Date: 12/04/2012 09:47:44 ******/
EXEC master.dbo.sp_addlinkedserver @server = N'FAMOUS', @srvproduct=N'FAMOUS', @provider=N'OraOLEDB.Oracle', @datasrc=N'FAMOUS', @provstr=N'MSDORA'
 /* For security reasons the linked server remote logins password is changed with ######## */
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'FAMOUS',@useself=N'False',@locallogin=NULL,@rmtuser=N'company_1_rpt',@rmtpassword='########'
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'FAMOUS',@useself=N'False',@locallogin=N'PANDOL\Administrator',@rmtuser=N'COMPANY_1_RPT',@rmtpassword='########'

GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'collation compatible', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'rpc', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'rpc out', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'FAMOUS', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO


