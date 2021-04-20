USE [DB_MedicalExamination]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RolePriority] [tinyint] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](70) NOT NULL,
	[DateOfBirth] [bigint] NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Titles] [nvarchar](40) NULL,
	[IsActive] [bit] NOT NULL,
	[DepartmentId] [nvarchar](50) NULL,
	[Avatar] [nvarchar](200) NULL,
	[Signature] [nvarchar](200) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [varchar](50) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](70) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Email] [varchar](100) NULL,
	[Adress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[IdentityNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomersOrganizations]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersOrganizations](
	[CustomerId] [varchar](50) NOT NULL,
	[OrganizationId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CustomersOrganizations] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [nvarchar](50) NOT NULL,
	[DepartmentName] [nvarchar](200) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupMedicalExaminations]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMedicalExaminations](
	[GMExaminationId] [varchar](50) NOT NULL,
	[DateStart] [bigint] NOT NULL,
	[DateEnd] [bigint] NOT NULL,
	[Advances] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 2) NULL,
	[OrganizationId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GroupMedicalExaminations] PRIMARY KEY CLUSTERED 
(
	[GMExaminationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecords]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecords](
	[MedicalRecordId] [varchar](50) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[CreateDate] [bigint] NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[OrganizationId] [varchar](50) NULL,
	[GMExaminationId] [varchar](50) NULL,
	[DateCompleted] [bigint] NULL,
	[CustomerId] [varchar](50) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[TotalAmount] [decimal](18, 0) NOT NULL,
	[WasFinishedExamination] [bit] NOT NULL,
 CONSTRAINT [PK_MedicalRecords] PRIMARY KEY CLUSTERED 
(
	[MedicalRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalServices]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalServices](
	[MServiceId] [varchar](50) NOT NULL,
	[MServiceName] [nvarchar](150) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[IsActive] [bit] NULL,
	[DepartmentId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MedicalServices] PRIMARY KEY CLUSTERED 
(
	[MServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 15/04/2021 9:34:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrganizationId] [varchar](50) NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[OrganizationPhoneNumber] [varchar](20) NULL,
	[OrganizationEmail] [varchar](50) NULL,
	[OrganizationAddress] [varchar](200) NOT NULL,
	[PersonContact] [nvarchar](100) NOT NULL,
	[PhoneContact] [varchar](20) NOT NULL,
	[EmailContact] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [IsActive], [RolePriority], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8dd36636-b4d8-4010-8594-caebfbe55991', 1, 1, N'Quản trị viên hệ thống', N'QUẢN TRỊ VIÊN HỆ THỐNG', N'8710f235-fa4a-411a-b6f8-b0e90931c394')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'84572bc3-25fc-4ef8-9056-67c4da04069b', N'8dd36636-b4d8-4010-8594-caebfbe55991')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [DateOfBirth], [Address], [Titles], [IsActive], [DepartmentId], [Avatar], [Signature], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'84572bc3-25fc-4ef8-9056-67c4da04069b', N'Administrator', N'System', 0, NULL, NULL, 1, NULL, N'noavatar.png', N'', N'admin', N'ADMIN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAECo5guC3W9oDZk4T7SlsdgPfB/cNE8kQE4CG7YadbwwzawwJjWAfSEgFR8njtkLZFw==', N'5c724094-d2cb-4d9a-af57-ff9a59088971', N'c46384a8-c156-487c-8c06-cebdfcfe0d50', N'0911345992', 1, 0, NULL, 0, 0)
ALTER TABLE [dbo].[GroupMedicalExaminations] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[MedicalRecords] ADD  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[MedicalRecords] ADD  DEFAULT ((0)) FOR [WasFinishedExamination]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomersOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_CustomersOrganizations_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomersOrganizations] CHECK CONSTRAINT [FK_CustomersOrganizations_Customers]
GO
ALTER TABLE [dbo].[CustomersOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_CustomersOrganizations_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([OrganizationId])
GO
ALTER TABLE [dbo].[CustomersOrganizations] CHECK CONSTRAINT [FK_CustomersOrganizations_Organizations]
GO
ALTER TABLE [dbo].[GroupMedicalExaminations]  WITH CHECK ADD  CONSTRAINT [FK_GroupMedicalExaminations_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([OrganizationId])
GO
ALTER TABLE [dbo].[GroupMedicalExaminations] CHECK CONSTRAINT [FK_GroupMedicalExaminations_Organizations]
GO
ALTER TABLE [dbo].[MedicalRecords]  WITH CHECK ADD  CONSTRAINT [FK_MedicalRecords_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[MedicalRecords] CHECK CONSTRAINT [FK_MedicalRecords_Customers]
GO
ALTER TABLE [dbo].[MedicalServices]  WITH CHECK ADD  CONSTRAINT [FK_MedicalServices_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[MedicalServices] CHECK CONSTRAINT [FK_MedicalServices_Departments]
GO
ALTER TABLE [dbo].[GroupMedicalExaminations]  WITH CHECK ADD  CONSTRAINT [CHK_Discount] CHECK  (([Discount]>=(0) AND [Discount]<=(1)))
GO
ALTER TABLE [dbo].[GroupMedicalExaminations] CHECK CONSTRAINT [CHK_Discount]
GO
