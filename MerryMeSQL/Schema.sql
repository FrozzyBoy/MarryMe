USE [MerryMeSQL]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 6/9/2015 8:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[HolidayId] [int] IDENTITY(1,1) NOT NULL,
	[StartDay] [datetime2](7) NULL,
	[EndDay] [datetime2](7) NULL,
	[Information] [nchar](1024) NULL,
 CONSTRAINT [PK_Holidays] PRIMARY KEY CLUSTERED 
(
	[HolidayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Залы]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Залы](
	[Код] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](50) NULL,
	[Начало_работы] [time](7) NULL,
	[Окончание_работы] [time](7) NULL,
	[Норма_времени_на_регистрацию] [time](7) NULL,
	[Понедельник] [bit] NULL,
	[Вторник] [bit] NULL,
	[Среда] [bit] NULL,
	[Четверг] [bit] NULL,
	[Пятница] [bit] NULL,
	[Суббота] [bit] NULL,
	[Воскресенье] [bit] NULL,
	[Информация] [nvarchar](1000) NULL,
	[Цена] [int] NOT NULL CONSTRAINT [DF_Залы_Цена]  DEFAULT ((0)),
 CONSTRAINT [PK_Залы] PRIMARY KEY CLUSTERED 
(
	[Код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Имена]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Имена](
	[Имя] [nvarchar](50) NULL,
	[Пол] [nvarchar](1) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Место регистрации]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Место регистрации](
	[Код] [int] NULL,
	[Наименование] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Обращения]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Обращения](
	[Код] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](30) NULL,
 CONSTRAINT [PK_Обращения] PRIMARY KEY CLUSTERED 
(
	[Код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Общие]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Общие](
	[Счетчик] [int] IDENTITY(1,1) NOT NULL,
	[Название_учреждения] [nvarchar](100) NULL,
	[Должность_подписывающего] [nvarchar](100) NULL,
	[ФИО_подписывающего] [nvarchar](50) NULL,
 CONSTRAINT [PK_Общие] PRIMARY KEY CLUSTERED 
(
	[Счетчик] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Отчества]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Отчества](
	[Отчество] [nvarchar](50) NULL,
	[Пол] [nvarchar](1) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Песочница]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Песочница](
	[Счетчик] [int] IDENTITY(1,1) NOT NULL,
	[Дата_обращения] [datetime2](7) NULL,
	[Код_зала] [int] NULL,
	[Код_обращения] [int] NULL,
	[Код_места_регистрации] [int] NULL,
	[Код_специалиста] [int] NULL,
	[Фамилия_жениха] [nvarchar](50) NULL,
	[Имя_жениха] [nvarchar](50) NULL,
	[Отчество_жениха] [nvarchar](50) NULL,
	[Идентификационный_номер_жениха] [nvarchar](14) NULL,
	[Номер_телефона_жениха] [nvarchar](20) NULL,
	[Фамилия_невесты] [nvarchar](50) NULL,
	[Имя_невесты] [nvarchar](50) NULL,
	[Отчество_невесты] [nvarchar](50) NULL,
	[Идентификационный_номер_невесты] [nvarchar](14) NULL,
	[Номер_телефона_невесты] [nvarchar](20) NULL,
	[Дата_регистрации_брака] [datetime2](7) NULL,
	[Время_регистрации_брака] [datetime2](7) NULL,
	[Подано_заявление] [bit] NULL,
	[Примечание] [nvarchar](255) NULL,
	[email] [nvarchar](250) NULL,
	[Спланировано] [bit] NULL,
	[Token] [nvarchar](50) NULL,
 CONSTRAINT [PK_Песочница] PRIMARY KEY CLUSTERED 
(
	[Счетчик] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[По умолчанию]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[По умолчанию](
	[Код_обращения] [int] NULL,
	[Код_места_регистрации] [int] NULL,
	[Код_специалиста] [int] NULL,
	[Все] [bit] NULL,
	[Автосохранение] [bit] NULL,
	[Количество_автосохранений] [tinyint] NULL,
	[Путь_для_автосохранения] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Регистрация]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Регистрация](
	[Регистрационный_номер] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Регистрация браков]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Регистрация браков](
	[Счетчик] [int] IDENTITY(1,1) NOT NULL,
	[Дата_обращения] [datetime2](7) NULL,
	[Код_зала] [int] NULL,
	[Код_обращения] [int] NULL,
	[Код_места_регистрации] [int] NULL,
	[Код_специалиста] [int] NULL,
	[Фамилия_жениха] [nvarchar](50) NULL,
	[Имя_жениха] [nvarchar](50) NULL,
	[Отчество_жениха] [nvarchar](50) NULL,
	[Идентификационный_номер_жениха] [nvarchar](14) NULL,
	[Номер_телефона_жениха] [nvarchar](20) NULL,
	[Фамилия_невесты] [nvarchar](50) NULL,
	[Имя_невесты] [nvarchar](50) NULL,
	[Отчество_невесты] [nvarchar](50) NULL,
	[Идентификационный_номер_невесты] [nvarchar](14) NULL,
	[Номер_телефона_невесты] [nvarchar](20) NULL,
	[Дата_регистрации_брака] [datetime2](7) NULL,
	[Время_регистрации_брака] [datetime2](7) NULL,
	[Подано_заявление] [bit] NULL,
	[Примечание] [nvarchar](255) NULL,
	[email] [nvarchar](250) NULL,
	[Спланировано] [bit] NULL,
 CONSTRAINT [PK_Регистрация браков] PRIMARY KEY CLUSTERED 
(
	[Счетчик] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Специалисты]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Специалисты](
	[Код] [int] NULL,
	[Специалист] [nvarchar](50) NULL,
	[Должность] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Учетные записи]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Учетные записи](
	[Код] [int] IDENTITY(1,1) NOT NULL,
	[Учетная_запись] [nvarchar](50) NULL,
	[Пароль] [nvarchar](50) NULL,
	[Подтверждение_пароля] [nvarchar](50) NULL,
	[Код_специалиста] [int] NULL,
	[ФИО] [nvarchar](50) NULL,
	[Дата_рождения] [datetime] NULL,
	[Тип_учетной_записи] [nvarchar](15) NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Room]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Room]
AS
SELECT        Код AS Id, Наименование AS Name, Информация AS Information, Цена AS Cost
FROM            dbo.Залы

GO
/****** Object:  StoredProcedure [dbo].[ApproveRegistration]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 5/25/2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[ApproveRegistration] 
	-- Add the parameters for the stored procedure here
	@token nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN tr

	declare @submitDate DateTime
	declare @roomId int = 0
	declare @mName nvarchar(50) = ''
	declare @mLastName nvarchar(50) = ''
	declare @mMidleName nvarchar(50) = ''
	declare @mTelNum nvarchar(20) = ''
	declare @mPassportId nvarchar(14) = ''
	declare @mEmail nvarchar(50) = ''
	declare @wName nvarchar(50) = ''
	declare @wLastName nvarchar(50) = ''
	declare @wMidleName nvarchar(50) = ''
	declare @wTelNum nvarchar(20) = ''
	declare @wPassportId nvarchar(14) = ''
	declare @email nvarchar(50) = ''
	
	declare @regTime time;
	declare @regDate date;

	declare @regId int;
		
	if (@token is null or @token = '') 
	begin
		ROLLBACK TRAN;
		THROW  50000, N'Ошибка передачи данных.', 1;
	end

	if (not exists(select * from dbo.Песочница where Token = @token))
	begin
		ROLLBACK TRAN;
		THROW  50000, N'Ошибка данных. Пройдите регистрацию повторно.', 1;
	end

	select 
			@regDate = convert(date,[Дата_регистрации_брака])
			,@regTime = convert(time,[Время_регистрации_брака])
			,@roomId = [Код_зала]
			,@email = email
	from dbo.Песочница
	where Token = @token;

	select 
		@regID = Счетчик 
		,@submitDate = getdate()
		
		,@mLastName = [Фамилия_жениха] 
		,@mName = [Имя_жениха] 
		,@mMidleName = [Отчество_жениха]
		,@mTelNum = [Номер_телефона_жениха]
		,@mPassportId =[Идентификационный_номер_жениха]

		,@wLastName = [Фамилия_невесты]
		,@wName = [Имя_невесты]
		,@wMidleName = [Отчество_невесты]
		,@wTelNum = [Номер_телефона_невесты]
		,@wPassportId = [Идентификационный_номер_невесты]
							
	from [dbo].[Регистрация браков] 
							where
								 [Дата_обращения] is null
								 and convert(date, [Дата_регистрации_брака]) = @regDate
								 and convert(time, [Время_регистрации_брака]) = @regTime
								 and @roomId = @roomId

	if (@regId is null)
	begin
		
		delete dbo.Песочница where Token = @token;

		ROLLBACK TRAN;
		THROW  50000, N'Ваше время было занято. Пройдите регистрацию повторно.', 1;
	end

	UPDATE [dbo].[Регистрация браков]
	SET
		[Дата_обращения] = @submitDate
		,[Код_обращения] = 5--ссылка на таблицу Обращения
		,[Код_места_регистрации] = 1--ссылка на таблицу Место регистрации

		,[Фамилия_жениха] = @mLastName
		,[Имя_жениха] = @mName
		,[Отчество_жениха] = @mMidleName
		,[Номер_телефона_жениха] = @mTelNum
		,[Идентификационный_номер_жениха] = @mPassportId

		,[Фамилия_невесты] = @wLastName
		,[Имя_невесты] = @wName
		,[Отчество_невесты] = @wMidleName
		,[Номер_телефона_невесты] = @wTelNum
		,[Идентификационный_номер_невесты] =@wPassportId
		,[email] = @email

	WHERE [Счетчик] = @regID;

	COMMIT TRAN tr;

END


GO
/****** Object:  StoredProcedure [dbo].[GetAllRooms]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 26,04,2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetAllRooms] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select *
	FROM [MerryMeSQL].[dbo].[Room] with (nolock)
	 
END






GO
/****** Object:  StoredProcedure [dbo].[GetFreeTime]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 4/18/2015
-- Description:	Select free time for room by date
-- =============================================
CREATE PROCEDURE [dbo].[GetFreeTime] 
	-- Add the parameters for the stored procedure here
	@date varchar(20) = null, 
	@roomId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT convert(time, [Время_регистрации_брака]) as FreeTime
	FROM [MerryMeSQL].[dbo].[Регистрация браков] with(nolock)
	WHERE convert(date, [Дата_регистрации_брака]) = @date
	AND [Код_зала] = @roomId
	AND [Дата_обращения] is null

END






GO
/****** Object:  StoredProcedure [dbo].[GetHolidaysForMonth]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 2015/04/21
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetHolidaysForMonth] 
	-- Add the parameters for the stored procedure here
	@year int = 0, 
	@month int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	from [MerryMeSQL].[dbo].[Holiday] with(nolock)
	where
	MONTH([EndDay]) = @month
	or @month between MONTH([StartDay]) and MONTH([EndDay])
END






GO
/****** Object:  StoredProcedure [dbo].[GetRoomById]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 26.04.2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetRoomById] 
	-- Add the parameters for the stored procedure here
	@roomId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select *
	FROM [MerryMeSQL].[dbo].[Room] with (nolock)
	where id = @roomId

END






GO
/****** Object:  StoredProcedure [dbo].[GetSheduleRoom]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 4/19/2015
-- Description:	Get shedule for room
-- =============================================
CREATE PROCEDURE [dbo].[GetSheduleRoom] 
	-- Add the parameters for the stored procedure here
	@roomId int = 0, 
	@date varchar(20) = null
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [Время_регистрации_брака] as RegisterTime,  
	(CASE 
		WHEN [Дата_обращения] is null THEN convert(bit, 0) ELSE convert(bit,1)
	END) as IsFree
	FROM [MerryMeSQL].[dbo].[Регистрация браков]
	WHERE convert(date, [Дата_регистрации_брака]) = @date
	AND [Код_зала] = @roomId
END






GO
/****** Object:  StoredProcedure [dbo].[GetStatistic]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 2015/04/20
-- Description:	Select statistic for period
-- =============================================
CREATE PROCEDURE [dbo].[GetStatistic] 
	-- Add the parameters for the stored procedure here
	@startDate date = null, 
	@endDate date = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN tr

	declare @validDays int;
	declare @allDays int;
	declare @retVal int;

	set @allDays = (select count(*)
	from [MerryMeSQL].[dbo].[Регистрация браков]
	where convert(date, [Дата_регистрации_брака]) between @startDate and @endDate)

	set @validDays =(select count(*)
	from [MerryMeSQL].[dbo].[Регистрация браков]
	where convert(date, [Дата_регистрации_брака]) between @startDate and @endDate
	and [Дата_обращения] is null)

	if (@allDays = 0)
	begin
		set @retVal = -1;
	end
	else
	begin
		set @retVal = (@validDays * 100 / @allDays);	
	end
	
	COMMIT TRAN tr
	
	RETURN @retVal;
	
END






GO
/****** Object:  StoredProcedure [dbo].[GetStatisticForAllDaysInMonth]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 4/27/2015
-- Description:	Statistic for all days in moth
-- =============================================
CREATE PROCEDURE [dbo].[GetStatisticForAllDaysInMonth] 
	-- Add the parameters for the stored procedure here
	@firstDayOfMoth date = null	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN TR

	declare @lastDayOfMoth date;
	declare @index date;
	declare @nextIndex date;
	declare @statistic table
	(
		ForDate date,
		Counted int
	)

	set @index = @firstDayOfMoth;
	set @lastDayOfMoth = DATEADD(month, 1, @firstDayOfMoth);
	DECLARE	@mothStat int;

	While(DATEDIFF (day, @index , 	@lastDayOfMoth) > 0)
	Begin
		
		set @nextIndex = dateadd(day, 1, @index);

		EXEC	@mothStat = [dbo].[GetStatistic]
		@startDate = @index,
		@endDate = @nextIndex

		insert into @statistic(ForDate,Counted )
		values (@index, @mothStat);

		set @index = @nextIndex;

	End
	
	select Counted as statistic
	from @statistic;

	COMMIT TRAN TR

END






GO
/****** Object:  StoredProcedure [dbo].[GetStatisticForMonthInYear]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 4/27/2015
-- Description:	Statistic for all month in year
-- =============================================
CREATE PROCEDURE [dbo].[GetStatisticForMonthInYear]
	-- Add the parameters for the stored procedure here
	@firstDayOfMoth date = null	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN TR

	declare @lastDayOfMoth date;
	declare @index date;
	declare @nextIndex date;
	declare @statistic table
	(
		ForDate date,
		Counted int
	)

	set @index = @firstDayOfMoth;
	set @lastDayOfMoth = DATEADD(year, 1, @firstDayOfMoth);
	DECLARE	@mothStat int;

	While(DATEDIFF (month, @index , 	@lastDayOfMoth) > 0)
	Begin
		
		set @nextIndex = dateadd(month, 1, @index);

		EXEC	@mothStat = [dbo].[GetStatistic]
		@startDate = @index,
		@endDate = @nextIndex

		insert into @statistic(ForDate,Counted )
		values (@index, @mothStat);

		set @index = @nextIndex;

	End

	select Counted as statistic
	from @statistic;

	COMMIT TRAN TR

END






GO
/****** Object:  StoredProcedure [dbo].[RegisterMarriage]    Script Date: 6/9/2015 8:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Artsiom Marozau
-- Create date: 2015-04-20
-- Update date: 2015-05-30
-- Description:	Register marriage
-- =============================================
CREATE PROCEDURE [dbo].[RegisterMarriage] 
	-- Add the parameters for the stored procedure here
	@regDateTime DateTime
	,@roomId int = 0
	,@mName nvarchar(50) = ''
	,@mLastName nvarchar(50) = ''
	,@mMidleName nvarchar(50) = ''
	,@mTelNum nvarchar(20) = ''
	,@mPassportId nvarchar(14) = ''
	,@mEmail nvarchar(250) = ''
	,@wName nvarchar(50) = ''
	,@wLastName nvarchar(50) = ''
	,@wMidleName nvarchar(50) = ''
	,@wTelNum nvarchar(20) = ''
	,@wPassportId nvarchar(14) = ''
	,@wEmail nvarchar(50) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @submitDate datetime;
	set @submitDate = getdate();

	DECLARE @regDate date;
	DECLARE @regTime time;

	DECLARE @token nvarchar(50);

	set @regDate = convert(date, @regDateTime);
	set @regTime = convert(time, @regDateTime);

	declare @idMarriage int;
	
	BEGIN TRAN tr

	if (@mEmail is null)
	begin
		ROLLBACK TRAN;
		THROW  50000, N'Укажите контактную электронную почту, чтобы подтвердить регистрацию.', 1;		
	end

	if (exists(select * from [dbo].[Регистрация браков] where email = @mEmail and [Дата_регистрации_брака] > @submitDate))
	begin
		ROLLBACK TRAN;
		THROW  50000, N'Вы уже зарегестрированы.', 1;
	end

	if (exists(select * from [dbo].[Песочница] 
			where (email = @mEmail 
						or ([Идентификационный_номер_жениха] is not null and [Идентификационный_номер_жениха] = @mPassportId)
						or ([Идентификационный_номер_невесты] is not null and [Идентификационный_номер_невесты] = @mPassportId)
						  )
			and [Дата_регистрации_брака] > @submitDate))
	begin
		ROLLBACK TRAN;
		THROW  50000, N'Вы уже подали заявку.', 1;
	end

	if @wPassportId is not null 
	AND exists (select [Идентификационный_номер_невесты]
	from [dbo].[Регистрация браков]
	where 
	[Идентификационный_номер_невесты] = @wPassportId
	AND [Дата_регистрации_брака] > @submitDate)
	BEGIN
		ROLLBACK TRAN;
		THROW  50000, N'Вы уже заригестрированы.', 1;		
	END

	if @mPassportId is not null
	and exists (select [Идентификационный_номер_жениха]
	from [dbo].[Регистрация браков]
	where 
	([Идентификационный_номер_жениха] = @mPassportId)
	AND [Дата_регистрации_брака] > @submitDate)
	BEGIN
		ROLLBACK TRAN;
		THROW  50000, N'Вы уже заригестрированы.', 1;		
	END

	if (@mPassportId is null 
	AND @wPassportId is null)
	Begin
		ROLLBACK TRAN;
		THROW  50000, N'Нужно указать паспортные данные хотя бы одного брачующегося.', 1;		
	End

	select @idMarriage = [Счетчик]
	from [dbo].[Регистрация браков]
	where 
	[Дата_обращения] is null
	AND [Код_зала] = @roomId
	AND convert(date, [Дата_регистрации_брака]) = @regDate
	AND convert(time, [Время_регистрации_брака]) = @regTime;

	IF (@idMarriage is null)
	BEGIN
		ROLLBACK TRAN;
		THROW  50000, N'Извините, но это время успели занять.', 1;
	END

	set @token = NEWID();
	insert dbo.Песочница(
		 [Дата_обращения]
		,[Код_обращения]
		,[Код_места_регистрации]

		,[Код_зала]

		,[Дата_регистрации_брака]
		,[Время_регистрации_брака]

		,[Фамилия_жениха]
		,[Имя_жениха]
		,[Отчество_жениха]
		,[Номер_телефона_жениха]
		,[Идентификационный_номер_жениха]

		,[Фамилия_невесты]
		,[Имя_невесты]
		,[Отчество_невесты]
		,[Номер_телефона_невесты]

		,[Идентификационный_номер_невесты]

		,email
		,Token)
	values(
		@submitDate
		,5--ссылка на таблицу Обращения
		,1--ссылка на таблицу Место регистрации

		,@roomId

		,@regDate
		,@regTime

		,@mLastName
		,@mName
		,@mMidleName
		,@mTelNum
		,@mPassportId

		,@wLastName
		,@wName
		,@wMidleName
		,@wTelNum
		,@wPassportId

		,@mEmail
		,@token);

	select @token as [Token];

	COMMIT TRAN tr

END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[27] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Залы"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 314
            End
            DisplayFlags = 280
            TopColumn = 10
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Room'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Room'
GO
