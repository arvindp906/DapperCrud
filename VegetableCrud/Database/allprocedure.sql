use test
go

drop table Vegetables
go

create table Vegetables
(
	Id int primary key identity(1,1) not null,
	Name nvarchar(50) not null,
	Type nvarchar(50) not null,
	PricePerTon int not null,
	FarmerName nvarchar(50) not null, 
	ProductionState nvarchar(50) not null
)
go

drop proc [dbo].[Vegetables_Create]
go

create proc [dbo].[Vegetables_Create]
	@Id int,
	@Name nvarchar(50),
	@Type nvarchar(50),
	@PricePerTon int,
	@FarmerName varchar(50),
	@ProductionState varchar(50)	 
as begin
	insert into Vegetables
	(
		Name,
		Type,
		PricePerTon,
		FarmerName,
		ProductionState
	)
    values
	(
		@Name,
		@Type,
		@PricePerTon,
		@FarmerName,
		@ProductionState  
	)

	select SCOPE_IDENTITY() InsertedId
end
go

drop proc [dbo].[Vegetables_GetAll]
go

create proc [dbo].[Vegetables_GetAll]
	@Id int = null,
	@Search nvarchar(50) = null,
	@OrderBy varchar(100) = 'name',
	@IsDescending bit = 0
as begin
	select 
		Id,
		Name,
		Type,
		PricePerTon,
		FarmerName,
		ProductionState
	from 
		Vegetables
	where
		Id = coalesce(@Id, Id)
		and
		(
			(@Search is null or @Search = '')
			or
			(
				@Search is not null
				and
				(
					Name like '%' + @Search + '%'
					or
					Type like '%' + @Search + '%'
					or
					FarmerName like '%' + @Search + '%'
					or
					ProductionState like '%' + @Search + '%'
				)
			)
		)
	order by
		case when @OrderBy = 'name' and @IsDescending = 0 then Name end asc
		, case when @OrderBy = 'name' and @IsDescending = 1 then Name end desc
		, case when @OrderBy = 'type' and @IsDescending = 0 then type end asc
		, case when @OrderBy = 'type' and @IsDescending = 1 then type end desc
		, case when @OrderBy = 'priceperton' and @IsDescending = 0 then priceperton end asc
		, case when @OrderBy = 'priceperton' and @IsDescending = 1 then priceperton end desc
		, case when @OrderBy = 'farmername' and @IsDescending = 0 then farmername end asc
		, case when @OrderBy = 'farmername' and @IsDescending = 1 then farmername end desc
		, case when @OrderBy = 'ProductionState' and @IsDescending = 0 then ProductionState end asc
		, case when @OrderBy = 'ProductionState' and @IsDescending = 1 then ProductionState end desc
end
go

SET IDENTITY_INSERT [dbo].[Vegetables] ON 
GO
INSERT [dbo].[Vegetables] ([Id], [Name], [Type], [PricePerTon], [FarmerName], [ProductionState]) VALUES (1, N'Tomato', N'Plant', 1000, N'Arvind', N'Maharashtra')
GO
INSERT [dbo].[Vegetables] ([Id], [Name], [Type], [PricePerTon], [FarmerName], [ProductionState]) VALUES (2, N'Potato', N'Root', 1000, N'Kajal', N'Chennai')
GO
INSERT [dbo].[Vegetables] ([Id], [Name], [Type], [PricePerTon], [FarmerName], [ProductionState]) VALUES (3, N'Orange', N'Plant', 1000, N'Abcd', N'Kashmir')
GO
INSERT [dbo].[Vegetables] ([Id], [Name], [Type], [PricePerTon], [FarmerName], [ProductionState]) VALUES (4, N'Cucumber', N'Plant', 1000, N'Abcd', N'Kerala')
GO
SET IDENTITY_INSERT [dbo].[Vegetables] OFF
GO

drop proc [dbo].[Vegetables_Get]
go

create proc [dbo].[Vegetables_Get]
	@Id int
as begin
	select 
		Id,
		Name,
		Type,
		PricePerTon,
		FarmerName,
		ProductionState
	from 
		Vegetables
	where 
		Id = @Id
end
go

drop proc [dbo].[Vegetables_Update]
go

create proc [dbo].[Vegetables_Update]
	@Id int,
	@Name nvarchar(50),
	@Type nvarchar(50),
	@PricePerTon int,
	@FarmerName varchar(50),
	@ProductionState varchar(50)
as begin
	update 
		Vegetables
	set
		Name = @Name,
		Type = @Type,
		PricePerTon = @PricePerTon,
		FarmerName = @FarmerName,
		productionState = @productionState
	where 
		Id=@Id
end
go

drop proc [dbo].[Vegetables_Delete]
go

create proc [dbo].[Vegetables_Delete]
	@Id int
as begin
	delete 
	from 
		Vegetables
	where 
		Id = @Id
end
go
