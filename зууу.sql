USE [Zoo_Pr6]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 27.11.2024 14:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[id_animal] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[age] [int] NULL,
	[gender] [nvarchar](50) NULL,
	[id_medcard] [int] NULL,
	[type] [nvarchar](50) NULL,
	[id_cell] [int] NULL,
 CONSTRAINT [PK_Animal] PRIMARY KEY CLUSTERED 
(
	[id_animal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cell]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cell](
	[id_cell] [int] NOT NULL,
	[name_cell] [nvarchar](50) NULL,
	[type_cell] [nvarchar](50) NULL,
	[square_m] [int] NULL,
	[max_count_animal] [int] NULL,
 CONSTRAINT [PK_Cell] PRIMARY KEY CLUSTERED 
(
	[id_cell] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Custom_Services]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Custom_Services](
	[id_custom] [int] NOT NULL,
	[id_service] [int] NULL,
	[id_ticket] [int] NULL,
 CONSTRAINT [PK_Custom_Services] PRIMARY KEY CLUSTERED 
(
	[id_custom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id_employee] [int] NOT NULL,
	[full_name] [nvarchar](50) NULL,
	[number_phone] [nvarchar](12) NULL,
	[date_birth] [date] NULL,
	[position] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id_employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[id_event] [int] NOT NULL,
	[name_event] [nvarchar](50) NULL,
	[description] [nvarchar](300) NULL,
	[id_cell] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[id_event] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[number_feedback] [int] IDENTITY(1,1) NOT NULL,
	[id_visitor] [int] NULL,
	[description] [nvarchar](300) NULL,
	[score] [int] NULL,
	[date_feed] [date] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[number_feedback] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History_Family_Tree]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History_Family_Tree](
	[id_history] [int] NOT NULL,
	[name_family_tree] [nvarchar](50) NULL,
	[count_animal] [int] NULL,
	[date_start_family] [date] NULL,
 CONSTRAINT [PK_History_Family_Tree] PRIMARY KEY CLUSTERED 
(
	[id_history] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History_Traffic]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History_Traffic](
	[id_history_traffic] [int] NOT NULL,
	[date_traffic] [date] NULL,
	[count_visitor] [int] NULL,
	[id_event] [int] NULL,
 CONSTRAINT [PK_History_Traffic] PRIMARY KEY CLUSTERED 
(
	[id_history_traffic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[List_Family_Tree]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List_Family_Tree](
	[id_list_family] [int] NOT NULL,
	[id_history] [int] NULL,
	[id_animal_father] [int] NULL,
	[id_animal_mother] [int] NULL,
	[id_animal_child] [int] NULL,
 CONSTRAINT [PK_List_Family_Tree] PRIMARY KEY CLUSTERED 
(
	[id_list_family] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](20) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loyalty_Program]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loyalty_Program](
	[id_loyalty_program] [int] NOT NULL,
	[name_loyalty_programm] [nvarchar](50) NULL,
	[description] [nvarchar](300) NULL,
 CONSTRAINT [PK_Loyalty_Program] PRIMARY KEY CLUSTERED 
(
	[id_loyalty_program] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Med_History]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Med_History](
	[id_med_history] [int] NOT NULL,
	[id_medcard] [int] NULL,
	[condition] [nvarchar](50) NULL,
	[description] [nvarchar](300) NULL,
	[date_start_heal] [date] NOT NULL,
	[date_end_heal] [date] NULL,
	[id_med_procedure] [int] NULL,
	[id_employee] [int] NULL,
 CONSTRAINT [PK_Med_History] PRIMARY KEY CLUSTERED 
(
	[id_med_history] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Med_Procedure]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Med_Procedure](
	[id_med_procedure] [int] NOT NULL,
	[name_procedure] [nvarchar](50) NULL,
	[type_procedure] [nvarchar](50) NULL,
 CONSTRAINT [PK_Med_Procedure] PRIMARY KEY CLUSTERED 
(
	[id_med_procedure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedCard]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedCard](
	[id_medcard] [int] NOT NULL,
	[id_animal] [int] NULL,
	[date_start_account] [date] NULL,
 CONSTRAINT [PK_MedCard] PRIMARY KEY CLUSTERED 
(
	[id_medcard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report_Finance]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_Finance](
	[id_report_finance] [int] NOT NULL,
	[id_history_traffic] [int] NULL,
	[profit] [nchar](10) NULL,
 CONSTRAINT [PK_Report_Finance] PRIMARY KEY CLUSTERED 
(
	[id_report_finance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id_role] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id_service] [int] NOT NULL,
	[description_service] [nvarchar](50) NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[id_ticket] [int] NOT NULL,
	[id_visitor] [int] NULL,
	[id_event] [int] NULL,
	[price_ticket] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[id_ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[id_role] [int] NULL,
	[count_visit] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitor]    Script Date: 27.11.2024 14:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitor](
	[id_visitor] [int] NOT NULL,
	[full_name] [nvarchar](50) NULL,
	[number_phone] [nvarchar](12) NULL,
	[Regular_Customer] [bit] NULL,
	[id_loyalty_program] [int] NULL,
	[kod_friend] [int] NULL,
	[card_zoo] [int] NULL,
 CONSTRAINT [PK_Visitor] PRIMARY KEY CLUSTERED 
(
	[id_visitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (1, N'Бурый Миша', 13, N'МУЖ', 9, N'Бурый Медведь', 4)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (2, N'Дикий Джек', 5, N'ЖЕН', 3, N'Обезьяна', 7)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (3, N'Резвый Питер', 15, N'МУЖ', 4, N'Горилла', 3)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (4, N'Спокойный Сэм', 8, N'МУЖ', 1, N'Верблюд', 8)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (5, N'Кеша', 6, N'МУЖ', 2, N'Попугай', 1)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (6, N'Арлан', 15, N'ЖЕН', 10, N'Сокол', 1)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (7, N'Пугливый Марио', 7, N'ЖЕН', 6, N'Страус', 1)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (8, N'Белоснежка', 14, N'ЖЕН', 5, N'Белый медведь', 5)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (9, N'Скрытый Дио', 12, N'МУЖ', 7, N'Змея', 6)
INSERT [dbo].[Animal] ([id_animal], [name], [age], [gender], [id_medcard], [type], [id_cell]) VALUES (10, N'Шустрый Остап', 5, N'МУЖ', 8, N'Гепард', 2)
GO
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (1, N'Птичье гнездо', N'Открытая большая клетка, с сеткой', 50, 10)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (2, N'Вольер гепардов', N'Закрытая решеткой', 100, 5)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (3, N'Джунгли горилл', N'Закрытая стеклом', 350, 7)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (4, N'Медвежья', N'Одиночная закрытая клетка', 75, 1)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (5, N'Медвежья общая', N'Закрытый вольер', 200, 4)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (6, N'Змеиная клетка', N'Маленькая стеклянная клетка', 10, 10)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (7, N'Обезьяньи тропики', N'Большая клетка, среди тропиков', 200, 15)
INSERT [dbo].[Cell] ([id_cell], [name_cell], [type_cell], [square_m], [max_count_animal]) VALUES (8, N'Пустынная сахара', N'Большое поле с песком', 300, 7)
GO
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (1, N'Иванов Алексей Сергеевич', N'79123456789', CAST(N'1997-10-19' AS Date), N'Зоолог')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (2, N'Петрова Екатерина Викторовна', N'79134567890', CAST(N'1999-12-21' AS Date), N'Ветеринар-Фельдшер')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (3, N'Смирнов Дмитрий Александрович', N'79145678901', CAST(N'2001-04-25' AS Date), N'Зоопсихолог')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (4, N'Кузнецова Мария Игоревна', N'79156789012', CAST(N'1972-01-19' AS Date), N'Орнитолог')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (5, N'Сидоров Николай Павлович', N'79167890123', CAST(N'1989-07-29' AS Date), N'Кормилец')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (6, N'Васильева Анна Сергеевна', N'79178901234', CAST(N'1992-04-25' AS Date), N'Ветеринар-Врач')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (7, N'Михайлов Андрей Николаевич', N'79189012345', CAST(N'1973-03-21' AS Date), N'Администратор')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (8, N'Попова Светлана Васильевна', N'79190123456', CAST(N'1992-02-01' AS Date), N'Зоолог')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (9, N'Фёдоров Владимир Юрьевич', N'79201234567', CAST(N'1989-05-15' AS Date), N'Кормилец')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (10, N'Орлова Ольга Дмитриевна', N'79212345678', CAST(N'1976-07-19' AS Date), N'Зоопсихолог')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (11, N'Петров Алексей Игнатович', N'79222355878', CAST(N'1988-01-12' AS Date), N'Ветеринар-Хирург')
INSERT [dbo].[Employee] ([id_employee], [full_name], [number_phone], [date_birth], [position]) VALUES (21, N'hghghgh', N'757575', CAST(N'1999-01-02' AS Date), N'директор')
GO
INSERT [dbo].[Event] ([id_event], [name_event], [description], [id_cell], [date]) VALUES (1, N'Выступление фениксов', N'В представлении мероприятия, участвуют множество различных видов птиц, по типу фламинго, попугаи и т.д', 1, CAST(N'2020-12-12' AS Date))
INSERT [dbo].[Event] ([id_event], [name_event], [description], [id_cell], [date]) VALUES (2, N'Медведи на велосипедах', N'В представлении мероприятии, участвует группа медведей, вступающая на велосипедах', 5, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Event] ([id_event], [name_event], [description], [id_cell], [date]) VALUES (3, N'Гориллы паркуристы', N'В представлении мероприятия, участвуют гориллы взбирающиеся на возвышенности', 3, CAST(N'0111-01-01' AS Date))
INSERT [dbo].[Event] ([id_event], [name_event], [description], [id_cell], [date]) VALUES (4, N'Обезьяны жонглеры', N'В представлении мероприятия, участвуют обезьяны жонглирующие разными предметами', 7, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Event] ([id_event], [name_event], [description], [id_cell], [date]) VALUES (5, N'Индийские заклинания', N'Душить змея', 6, CAST(N'2024-11-28' AS Date))
GO
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (1, N'Гориллы', 15, CAST(N'2017-01-01' AS Date))
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (2, N'Обезьяны', 23, CAST(N'2014-05-23' AS Date))
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (3, N'Дельфины', 12, CAST(N'2019-02-28' AS Date))
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (4, N'Страусы', 4, CAST(N'2020-01-19' AS Date))
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (5, N'Львы', 7, CAST(N'2021-04-30' AS Date))
INSERT [dbo].[History_Family_Tree] ([id_history], [name_family_tree], [count_animal], [date_start_family]) VALUES (6, N'Медведи', 3, CAST(N'2017-03-18' AS Date))
GO
INSERT [dbo].[Login] ([login], [password]) VALUES (N'000', N'000')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'1', N'1')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'111', N'111')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'1111', N'1111')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'12', N'12')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'13', N'13')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'14', N'14')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'143535353', N'354654757')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'15', N'15')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'2', N'2')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'222205', N'AACC25')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'222208', N'AACC25')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'222209', N'AACC25')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'222210', N'AACC25')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'222211', N'AACC25')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'3', N'3')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'3354675757', N'5465757557')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'46464646', N'54646464')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'6557575', N'5686786474')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'75755', N'567575757')
INSERT [dbo].[Login] ([login], [password]) VALUES (N'Rasim', N'AACC25')
GO
INSERT [dbo].[Loyalty_Program] ([id_loyalty_program], [name_loyalty_programm], [description]) VALUES (1, N'Первое посещение', N'Первое посещение скидка 15%')
INSERT [dbo].[Loyalty_Program] ([id_loyalty_program], [name_loyalty_programm], [description]) VALUES (2, N'Постоянный клиент', N'Скидка 5%')
INSERT [dbo].[Loyalty_Program] ([id_loyalty_program], [name_loyalty_programm], [description]) VALUES (3, N'Приглашение друга', N'При приглашении друга, скидка на одно посещение 30%')
INSERT [dbo].[Loyalty_Program] ([id_loyalty_program], [name_loyalty_programm], [description]) VALUES (4, N'Карта зоопарка', N'При наличии карты зоопарка, скидка 10%')
GO
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (1, 2, N'Стабильное', N'Плохое настроение, не желание что-либо делать', CAST(N'2024-03-04' AS Date), CAST(N'2024-03-07' AS Date), 2, 2)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (2, 5, N'Критическое', N'Постоянные крики в вольере, резкое побаливание в области живота (операция)', CAST(N'2024-04-19' AS Date), CAST(N'2024-04-27' AS Date), 1, 6)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (3, 5, N'Стабильное', N'Операция, удаление злокачественных образовании', CAST(N'2024-04-27' AS Date), CAST(N'2024-06-19' AS Date), 5, 11)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (4, 3, N'Отрицательное', N'Ободранная кожа на лапках, необходимо обработать и бинтовать', CAST(N'2024-05-23' AS Date), CAST(N'2024-05-28' AS Date), 6, 1)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (5, 7, N'Стабильное', N'Змея прячется от людей, ранее такого не было', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-29' AS Date), 7, 3)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (6, 3, N'Стабильное', N'Повторная обработка ран, на коже лапках', CAST(N'2024-05-28' AS Date), CAST(N'2024-05-29' AS Date), 6, 8)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (7, 2, N'Отрицательное', N'Сломано левое крыло, необходимо прописать курс лечения', CAST(N'2024-07-02' AS Date), CAST(N'2024-09-18' AS Date), 5, 11)
INSERT [dbo].[Med_History] ([id_med_history], [id_medcard], [condition], [description], [date_start_heal], [date_end_heal], [id_med_procedure], [id_employee]) VALUES (8, 4, N'Критическое', N'Побои от других горилл, синяки и атрофированные мышцы', CAST(N'2024-11-21' AS Date), CAST(N'2025-02-28' AS Date), 8, 6)
GO
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (1, N'Лабораторные анализы', N'Анализ')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (2, N'Фармакология', N'Лечение')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (3, N'Физиотерапия', N'Лечение')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (4, N'УЗИ', N'Анализ')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (5, N'Хирургическая операция', N'Лечение')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (6, N'Обработка ран (бинтование)', N'Лечение')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (7, N'Курс психологии', N'Псих.Лечение')
INSERT [dbo].[Med_Procedure] ([id_med_procedure], [name_procedure], [type_procedure]) VALUES (8, N'Назначение мазей', N'Лечение')
GO
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (1, 4, CAST(N'2017-02-04' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (2, 5, CAST(N'2017-03-08' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (3, 2, CAST(N'2019-09-21' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (4, 3, CAST(N'2019-10-30' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (5, 8, CAST(N'2020-02-28' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (6, 7, CAST(N'2020-05-07' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (7, 9, CAST(N'2020-08-09' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (8, 10, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (9, 1, CAST(N'2021-12-30' AS Date))
INSERT [dbo].[MedCard] ([id_medcard], [id_animal], [date_start_account]) VALUES (10, 6, CAST(N'2022-01-01' AS Date))
GO
INSERT [dbo].[role] ([id_role], [name]) VALUES (1, N'Администратор')
INSERT [dbo].[role] ([id_role], [name]) VALUES (2, N'Пользователь')
INSERT [dbo].[role] ([id_role], [name]) VALUES (3, N'Сотрудник')
GO
INSERT [dbo].[Service] ([id_service], [description_service], [price]) VALUES (1, N'Фотография со анакондой на шее', 1500)
INSERT [dbo].[Service] ([id_service], [description_service], [price]) VALUES (2, N'Доступ к контактному зоопарку', 3000)
INSERT [dbo].[Service] ([id_service], [description_service], [price]) VALUES (3, N'Фотография с попугаем', 1000)
INSERT [dbo].[Service] ([id_service], [description_service], [price]) VALUES (4, N'Кормление верблюд', 350)
INSERT [dbo].[Service] ([id_service], [description_service], [price]) VALUES (5, N'Катание верхом на верблюде', 2500)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (2, N'Rasim', N'222205', 1, 3)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (3, N'Kamil', N'222209', 2, 3)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (4, N'Erik', N'222208', 2, 5)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (6, N'Ejik', N'222210', 2, 1)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (7, N'RASIM', N'222211', 2, 6)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (8, N'1', N'1', 1, 16)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (18, N'Введите имя', N'Rasim', 2, 1)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (19, N'2', N'2', 2, 8)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (21, N'3', N'3', 3, 12)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (22, N'Введите имяgfgfg', N'75755', 2, 2)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (23, N'Введите имя', N'6557575', 2, 2)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (24, N'Введите имя', N'143535353', 2, 3)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (26, N'000', N'000', 2, 1)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (27, N'000', N'000', 2, 0)
INSERT [dbo].[User] ([id_user], [name], [login], [id_role], [count_visit]) VALUES (28, N'Введите имя', N'3354675757', 2, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[Visitor] ([id_visitor], [full_name], [number_phone], [Regular_Customer], [id_loyalty_program], [kod_friend], [card_zoo]) VALUES (1, N'Гизатуллин Расим Рафисович', N'89506670657', 1, NULL, NULL, NULL)
INSERT [dbo].[Visitor] ([id_visitor], [full_name], [number_phone], [Regular_Customer], [id_loyalty_program], [kod_friend], [card_zoo]) VALUES (2, N'Ишкеев Камиль Робертович', N'85789643335', 1, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD  CONSTRAINT [FK_Animal_Cell] FOREIGN KEY([id_cell])
REFERENCES [dbo].[Cell] ([id_cell])
GO
ALTER TABLE [dbo].[Animal] CHECK CONSTRAINT [FK_Animal_Cell]
GO
ALTER TABLE [dbo].[Custom_Services]  WITH CHECK ADD  CONSTRAINT [FK_Custom_Services_Service] FOREIGN KEY([id_service])
REFERENCES [dbo].[Service] ([id_service])
GO
ALTER TABLE [dbo].[Custom_Services] CHECK CONSTRAINT [FK_Custom_Services_Service]
GO
ALTER TABLE [dbo].[Custom_Services]  WITH CHECK ADD  CONSTRAINT [FK_Custom_Services_Ticket] FOREIGN KEY([id_ticket])
REFERENCES [dbo].[Ticket] ([id_ticket])
GO
ALTER TABLE [dbo].[Custom_Services] CHECK CONSTRAINT [FK_Custom_Services_Ticket]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Cell] FOREIGN KEY([id_cell])
REFERENCES [dbo].[Cell] ([id_cell])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Cell]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Visitor] FOREIGN KEY([id_visitor])
REFERENCES [dbo].[Visitor] ([id_visitor])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Visitor]
GO
ALTER TABLE [dbo].[History_Traffic]  WITH CHECK ADD  CONSTRAINT [FK_History_Traffic_Event] FOREIGN KEY([id_event])
REFERENCES [dbo].[Event] ([id_event])
GO
ALTER TABLE [dbo].[History_Traffic] CHECK CONSTRAINT [FK_History_Traffic_Event]
GO
ALTER TABLE [dbo].[List_Family_Tree]  WITH CHECK ADD  CONSTRAINT [FK_List_Family_Tree_Animal] FOREIGN KEY([id_animal_mother])
REFERENCES [dbo].[Animal] ([id_animal])
GO
ALTER TABLE [dbo].[List_Family_Tree] CHECK CONSTRAINT [FK_List_Family_Tree_Animal]
GO
ALTER TABLE [dbo].[List_Family_Tree]  WITH CHECK ADD  CONSTRAINT [FK_List_Family_Tree_Animal1] FOREIGN KEY([id_animal_father])
REFERENCES [dbo].[Animal] ([id_animal])
GO
ALTER TABLE [dbo].[List_Family_Tree] CHECK CONSTRAINT [FK_List_Family_Tree_Animal1]
GO
ALTER TABLE [dbo].[List_Family_Tree]  WITH CHECK ADD  CONSTRAINT [FK_List_Family_Tree_Animal2] FOREIGN KEY([id_animal_child])
REFERENCES [dbo].[Animal] ([id_animal])
GO
ALTER TABLE [dbo].[List_Family_Tree] CHECK CONSTRAINT [FK_List_Family_Tree_Animal2]
GO
ALTER TABLE [dbo].[List_Family_Tree]  WITH CHECK ADD  CONSTRAINT [FK_List_Family_Tree_History_Family_Tree] FOREIGN KEY([id_history])
REFERENCES [dbo].[History_Family_Tree] ([id_history])
GO
ALTER TABLE [dbo].[List_Family_Tree] CHECK CONSTRAINT [FK_List_Family_Tree_History_Family_Tree]
GO
ALTER TABLE [dbo].[Med_History]  WITH CHECK ADD  CONSTRAINT [FK_Med_History_Employee] FOREIGN KEY([id_employee])
REFERENCES [dbo].[Employee] ([id_employee])
GO
ALTER TABLE [dbo].[Med_History] CHECK CONSTRAINT [FK_Med_History_Employee]
GO
ALTER TABLE [dbo].[Med_History]  WITH CHECK ADD  CONSTRAINT [FK_Med_History_Med_Procedure] FOREIGN KEY([id_med_procedure])
REFERENCES [dbo].[Med_Procedure] ([id_med_procedure])
GO
ALTER TABLE [dbo].[Med_History] CHECK CONSTRAINT [FK_Med_History_Med_Procedure]
GO
ALTER TABLE [dbo].[Med_History]  WITH CHECK ADD  CONSTRAINT [FK_Med_History_MedCard] FOREIGN KEY([id_medcard])
REFERENCES [dbo].[MedCard] ([id_medcard])
GO
ALTER TABLE [dbo].[Med_History] CHECK CONSTRAINT [FK_Med_History_MedCard]
GO
ALTER TABLE [dbo].[MedCard]  WITH CHECK ADD  CONSTRAINT [FK_MedCard_Animal] FOREIGN KEY([id_animal])
REFERENCES [dbo].[Animal] ([id_animal])
GO
ALTER TABLE [dbo].[MedCard] CHECK CONSTRAINT [FK_MedCard_Animal]
GO
ALTER TABLE [dbo].[Report_Finance]  WITH CHECK ADD  CONSTRAINT [FK_Report_Finance_History_Traffic] FOREIGN KEY([id_history_traffic])
REFERENCES [dbo].[History_Traffic] ([id_history_traffic])
GO
ALTER TABLE [dbo].[Report_Finance] CHECK CONSTRAINT [FK_Report_Finance_History_Traffic]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Event] FOREIGN KEY([id_event])
REFERENCES [dbo].[Event] ([id_event])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Event]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Visitor] FOREIGN KEY([id_visitor])
REFERENCES [dbo].[Visitor] ([id_visitor])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Visitor]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Login] FOREIGN KEY([login])
REFERENCES [dbo].[Login] ([login])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Login]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_role] FOREIGN KEY([id_role])
REFERENCES [dbo].[role] ([id_role])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_role]
GO
ALTER TABLE [dbo].[Visitor]  WITH CHECK ADD  CONSTRAINT [FK_Visitor_Loyalty_Program] FOREIGN KEY([id_loyalty_program])
REFERENCES [dbo].[Loyalty_Program] ([id_loyalty_program])
GO
ALTER TABLE [dbo].[Visitor] CHECK CONSTRAINT [FK_Visitor_Loyalty_Program]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback] CHECK  (([score]<=(5)))
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback]
GO
