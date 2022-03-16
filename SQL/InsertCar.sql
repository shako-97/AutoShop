USE [AutoShop]
GO

/****** Object:  StoredProcedure [dbo].[InsertCar_SP]    Script Date: 16.03.2022 16:23:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertCar_SP]
@ModelID int,
@ABS bit,
@PowerWindows bit,
@Bluetooth bit,
@Signalling bit,
@NavigationSystem bit,
@Price money

as 
begin 
Insert into Cars(ModelID,ABS,PowerWindows,Bluetooth,Signalling,NavigationSystem,Price,IsDeleted) values(@ModelID,@ABS,@PowerWindows,@Bluetooth,@Signalling,@NavigationSystem,@Price,0)
return 0

end
GO

