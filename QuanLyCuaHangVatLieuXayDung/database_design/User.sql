CREATE LOGIN ChuCuaHang
WITH PASSWORD = 'ChuCuaHang123';
GO

USE CuaHangXayDung;
CREATE USER ChuCuaHang FOR LOGIN ChuCuaHang;

GO
USE CuaHangXayDung;
ALTER ROLE db_owner ADD MEMBER ChuCuaHang;