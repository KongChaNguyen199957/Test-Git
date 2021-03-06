	USE MASTER
	GO
	IF EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME='AngularAPI')
		DROP DATABASE AngularAPI
	GO
	CREATE DATABASE AngularAPI
	GO
	USE AngularAPI
	GO
	/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[__EFMigrationsHistory](
		[MigrationId] [nvarchar](150) NOT NULL,
		[ProductVersion] [nvarchar](32) NOT NULL,
	 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
	(
		[MigrationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Attendances]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Attendances](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[StudentId] [int] NULL,
		[Present] [bit] NULL,
		[Absent] [bit] NULL,
		[Reason] [nvarchar](max) NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Attendances] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Classes]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Classes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ClassCode] [varchar](50) NULL,
		[ClassName] [nvarchar](50) NULL,
		[DepartmentId] [int] NULL,
		[TeacherId] [int] NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Classes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Departments]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Departments](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[DepartmentCode] [varchar](50) NULL,
		[DepartmentName] [nvarchar](50) NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Departments] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Schedules]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Schedules](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[TeacherId] [int] NULL,
		[SubjectId] [int] NULL,
		[ClassId] [int] NULL,
		[StartDate] [datetime] NULL,
		[EndDate] [datetime] NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Schedules] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Sections](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[SectionCode] [varchar](50) NULL,
		[SectionName] [nvarchar](50) NULL,
		[NumberOfSession] [int] NULL,
		[DepartmentId] [int] NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Sections] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Students]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Students](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[StudentCode] [varchar](50) NULL,
		[StudentName] [nvarchar](50) NULL,
		[StudentEmail] [varchar](50) NULL,
		[StudentPhone] [varchar](50) NULL,
		[StudentGender] [nvarchar](50) NULL,
		[StudentImage] [varchar](50) NULL,
		[ClassId] [int] NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Students] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_StudentSubject]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_StudentSubject](
		[StudentSubjectCode] [int] IDENTITY(1,1) NOT NULL,
		[SubjectId] [int] NULL,
		[StudentId] [int] NULL,
		[CreateDate] [datetime] NULL,
		[OrderNumber] [int] NULL,
	 CONSTRAINT [PK_Tbl_StudentSubject] PRIMARY KEY CLUSTERED 
	(
		[StudentSubjectCode] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Subjects]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Subjects](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[SubjectCode] [varchar](50) NULL,
		[SubjectName] [nvarchar](50) NULL,
		[NumberOfPeriod] [int] NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Subjects] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[Tbl_Teachers]    Script Date: 9/9/2021 4:10:46 PM ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Tbl_Teachers](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[TeacherCode] [varchar](50) NULL,
		[TeacherName] [nvarchar](50) NULL,
		[TeacherEmail] [varchar](50) NULL,
		[TeacherPhone] [varchar](50) NULL,
		[TeacherGender] [nvarchar](50) NULL,
		[TeacherImage] [varchar](50) NULL,
		[OrderNumber] [int] NULL,
		[CreateDate] [datetime] NULL,
	 CONSTRAINT [PK_Tbl_Teachers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	ALTER TABLE [dbo].[Tbl_Attendances] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Classes] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Departments] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Schedules] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Sections] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Students] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_StudentSubject] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Subjects] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Teachers] ADD  DEFAULT (getdate()) FOR [CreateDate]
	GO
	ALTER TABLE [dbo].[Tbl_Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Attendances_Tbl_Students] FOREIGN KEY([StudentId])
	REFERENCES [dbo].[Tbl_Students] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Attendances] CHECK CONSTRAINT [FK_Tbl_Attendances_Tbl_Students]
	GO
	ALTER TABLE [dbo].[Tbl_Classes]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Classes_Tbl_Departments] FOREIGN KEY([DepartmentId])
	REFERENCES [dbo].[Tbl_Departments] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Classes] CHECK CONSTRAINT [FK_Tbl_Classes_Tbl_Departments]
	GO
	ALTER TABLE [dbo].[Tbl_Classes]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Classes_Tbl_Teachers] FOREIGN KEY([TeacherId])
	REFERENCES [dbo].[Tbl_Teachers] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Classes] CHECK CONSTRAINT [FK_Tbl_Classes_Tbl_Teachers]
	GO
	ALTER TABLE [dbo].[Tbl_Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Schedules_Tbl_Classes] FOREIGN KEY([ClassId])
	REFERENCES [dbo].[Tbl_Classes] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Schedules] CHECK CONSTRAINT [FK_Tbl_Schedules_Tbl_Classes]
	GO
	ALTER TABLE [dbo].[Tbl_Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Schedules_Tbl_Subjects] FOREIGN KEY([SubjectId])
	REFERENCES [dbo].[Tbl_Subjects] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Schedules] CHECK CONSTRAINT [FK_Tbl_Schedules_Tbl_Subjects]
	GO
	ALTER TABLE [dbo].[Tbl_Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Schedules_Tbl_Teachers] FOREIGN KEY([TeacherId])
	REFERENCES [dbo].[Tbl_Teachers] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Schedules] CHECK CONSTRAINT [FK_Tbl_Schedules_Tbl_Teachers]
	GO
	ALTER TABLE [dbo].[Tbl_Sections]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Sections_Tbl_Departments] FOREIGN KEY([DepartmentId])
	REFERENCES [dbo].[Tbl_Departments] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Sections] CHECK CONSTRAINT [FK_Tbl_Sections_Tbl_Departments]
	GO
	ALTER TABLE [dbo].[Tbl_Students]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Students_Tbl_Classes] FOREIGN KEY([ClassId])
	REFERENCES [dbo].[Tbl_Classes] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_Students] CHECK CONSTRAINT [FK_Tbl_Students_Tbl_Classes]
	GO
	ALTER TABLE [dbo].[Tbl_StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Students_Tbl_StudentSubject] FOREIGN KEY([StudentId])
	REFERENCES [dbo].[Tbl_Students] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_StudentSubject] CHECK CONSTRAINT [FK_Tbl_Students_Tbl_StudentSubject]
	GO
	ALTER TABLE [dbo].[Tbl_StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Subjects_Tbl_StudentSubject] FOREIGN KEY([SubjectId])
	REFERENCES [dbo].[Tbl_Subjects] ([Id])
	GO
	ALTER TABLE [dbo].[Tbl_StudentSubject] CHECK CONSTRAINT [FK_Tbl_Subjects_Tbl_StudentSubject]
	GO
