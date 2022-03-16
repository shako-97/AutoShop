USE [AutoShop]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCar_SP]    Script Date: 16.03.2022 16:23:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteCar_SP]
@ID int
as
	begin
		set nocount on;
		update Cars
		set IsDeleted = 1
		where ID = @ID

		return 0;
	end
GO

