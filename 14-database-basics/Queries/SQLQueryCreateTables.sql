use [PersonsAndRewards];

/* 
 *  ƒл€ реализации отношени€ "многие ко многим"
 *  использую промежуточную таблицу IntermLinkTable
 */

 /* 
  *  primary key identity(1,1) 
  *  seed - значение, присваиваемое самой первой строке, загружаемой в таблицу.
  *  increment - значение приращени€, которое прибавл€етс€ к значению идентификатора предыдущей загруженной строки.
  */

  /* –абота с таблицей Persons */
create table Persons 
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Name]			varchar(50)		NOT NULL,
	[LastName]		varchar(50)		NOT NULL,
	[Birthdate]		date			NOT NULL,
	[Age]			int				NOT NULL
)

insert into Persons values (N'Peter', N'Parker', '2002-10-08', 19);
insert into Persons values (N'Tony', N'Stark', '1970-05-29', 51);

  /* –абота с таблицей Rewards */
create table Rewards
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Title]			varchar(50)		NOT NULL,
	[Descr]			varchar(250)	NOT NULL
)

insert into Rewards values ('Frendliest neighbour', 'Catch over 100 criminals without revealing your identity');
insert into Rewards values ('I am Iron Man!', 'Flip the gauntlet of infinity');
insert into Rewards values ('Most cool guy', '');

  /* –абота с таблицей IntermLinkTable */
create table IntermLinkTable
(
	[ID]			int				NOT NULL	primary key identity(1,1),
	[Person_ID]		int				NOT NULL,
	[Reward_ID]		int				NOT NULL,
	FOREIGN KEY ([Person_ID]) REFERENCES Persons(ID) ON DELETE CASCADE,
	FOREIGN KEY ([Reward_ID]) REFERENCES Rewards(ID) ON DELETE CASCADE
)

insert into IntermLinkTable values (1,1), (1,3), (2,2);


  /* ’ранимые процедуры */