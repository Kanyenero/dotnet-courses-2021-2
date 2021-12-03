USE master
IF(db_id(N'PersonsAndAwards')) IS NOT NULL DROP DATABASE PersonsAndAwards;

CREATE DATABASE PersonsAndAwards;
GO
use PersonsAndAwards;

/* 
 *  Для реализации отношения "многие ко многим"
 *  использую промежуточную таблицу [Relations]
 */

 /* 
  *  primary key identity(1,1) 
  *  seed - значение, присваиваемое самой первой строке, загружаемой в таблицу.
  *  increment - значение приращения, которое прибавляется к значению идентификатора 
  *              предыдущей загруженной строки.
  */

  /* Работа с таблицей [Persons] */
create table Persons
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Name]			nvarchar(50)	NOT NULL,
	[LastName]		nvarchar(50)	NOT NULL,
	[Birthdate]		date			NOT NULL
)

insert into [Persons] values (N'Peter', N'Parker', '2002-10-08');
insert into [Persons] values (N'Tony', N'Stark', '1970-05-29');

  /* Работа с таблицей [Awards] */
create table Awards
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Title]			nvarchar(50)	NOT NULL,
	[Descr]			nvarchar(250)	NOT NULL
)

insert into [Awards] values ('Frendliest neighbour', 'Catch over 100 criminals without revealing your identity');
insert into [Awards] values ('I am Iron Man!', 'Flip the gauntlet of infinity');
insert into [Awards] values ('Most cool guy', '');

  /* Работа с таблицей [Relations] */
create table Relations
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Person_ID]		int				NOT NULL,
	[Award_ID]		int				NOT NULL,
	FOREIGN KEY ([Person_ID]) REFERENCES [Persons](ID) ON delete CASCADE,
	FOREIGN KEY ([Award_ID]) REFERENCES [Awards](ID) ON delete CASCADE
)

insert into [Relations] values (1,1), (1,3), (2,2);


  /*
   *  
   *  Типы данных и переменные 
   *
   */
create type AwardsIDs as table(ID int);


  /* 
   *
   *  Хранимые процедуры 
   *
   */

--
-- [Awards]
--
GO
create procedure AwardAdd(@title nvarchar(50), @description nvarchar(250)) as
	insert into [Awards] values(@title, @description);

GO
create procedure AwardRemove(@awardID int) as
begin
	-- При удалении награды из таблицы наград
	-- производится обновление таблицы зависимостей

	delete from [Relations] where Award_ID = @awardID;
	delete from [Awards] where ID = @awardID;
end


	-- Сделать один общий запрос
GO
create procedure AwardSetData(@awardID int, @new_title nvarchar(50), @new_descr nvarchar(250)) as
	update [Awards] set Title = @new_title, Descr = @new_descr where ID = @awardID;

GO
create procedure AwardGetAll as 
	return select * from [Awards];

GO
create procedure AwardGetByID(@awardID int) as
	return select * from [Awards] where ID = @awardID;

GO
create procedure AwardGetIDByName(@title nvarchar(50)) as
	return select ID from [Awards] where Title = @title;



--
-- [Persons]
--
GO
create procedure PersonAdd(@name nvarchar(50), @lastname nvarchar(50), @birthdate date) as
	insert into [Persons] values(@name, @lastname, @birthdate);

--GO 
--alter procedure PersonAdd(@name nvarchar(50), @lastname nvarchar(50), @birthdate date, 
--						  @awardIDs as [Awards]IDs readonly) as
--begin
--
--	declare @personIDs as table(id int);
--
--	insert into [Persons] output inserted.ID into @personIDs values(@name, @lastname, @birthdate);
--	insert into [Relations] select [@personIDs].ID, [@awardIDs].ID from @awardIDs, @personIDs;
--end


-- Объединить в один запрос!

GO
create procedure PersonSetData(
		@personID int, 
		@new_name nvarchar(50), 
		@new_lastname nvarchar(50),
		@new_birthdate date) as
	update [Persons] set Name = @new_name, 
						 LastName = @new_lastname, 
						 Birthdate = @new_birthdate  where ID = @personID;

GO
create procedure PersonSetAward(@personID int, @awardID int) as
begin

	-- Если взаимосвязь не существует, добавить её
	if not exists(select 1 from [Relations] where Person_ID = @personID AND Award_ID = @awardID)
		insert into [Relations] values (@personID, @awardID);

end

GO
create procedure PersonAddAwards(@personID int, @awardIDs as AwardsIDs readonly) as
	insert into [Relations] select @personID, ID FROM @awardIDs;

GO
create procedure PersonRemoveAward(@personID int, @awardID int) as
begin

	-- Если взаимосвязь существует, удалить её
	if exists(select 1 from [Relations] where Person_ID = @personID AND Award_ID = @awardID)
		delete from [Relations] where Person_ID = @personID AND Award_ID = @awardID;

end

GO
create procedure PersonRemove(@personID int) as
begin
	-- При удалении персоны из таблицы персон
	-- производится обновление таблицы зависимостей

	delete from [Relations] where Person_ID = @personID;
	delete from [Persons] where ID = @personID;
end

GO
create procedure PersonGetAll as 
	return select * from [Persons];

GO
create procedure PersonGetByID(@personID int) as
	return select * from [Persons] where ID = @personID;

GO
create procedure PersonGetAwards(@personID int) as
	select * from [Awards] inner join [Relations] 
		on [Awards].ID = [Relations].Award_ID 
		where Person_ID = @personID;
