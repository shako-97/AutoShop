USE [AutoShop]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCars_SP]    Script Date: 16.03.2022 16:24:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateCars_SP]
@ID int,
@ModelID	int ,
@ABS bit ,
@PowerWindows bit,
@Bluetooth bit,
@Signalling bit ,
@NavigationSystem bit ,
@Price money 
as
begin
 
UPDATE Cars 
set
ModelID=@ModelID,
ABS=@ABS,
PowerWindows=@PowerWindows,
Bluetooth=@Bluetooth,
Signalling=@Signalling,
NavigationSystem=@NavigationSystem,
Price=@Price where ID=@ID

return 0
end
GO

