CREATE DATABASE MSSQLlocalDB;
GO

USE MSSQLlocalDB;
GO

CREATE TABLE [dbo].[buyers] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [Surname]     NVARCHAR (20) NOT NULL,
    [Name]        NVARCHAR (20) NOT NULL,
    [Patomic]     NVARCHAR (20) NOT NULL,
    [PhoneNumber] NVARCHAR (20) NULL,
    [Email]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[goods_order] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [Email_User]   NVARCHAR (20) NOT NULL,
    [item_number]  INT           NOT NULL,
    [product_name] NVARCHAR (20) NOT NULL,
    FOREIGN KEY ([Email_User]) REFERENCES [dbo].[buyers] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[registre] (
    [id]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (20)  NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL
);

insert into registre  ([UserName], [Password]) values ('admin', '78a41fb9315f6e22a9983e141f58534d');

SET IDENTITY_INSERT [dbo].[buyers] ON
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [PhoneNumber], [Email]) VALUES (1, N'Владимирова', N'Александра', N'Дмитривна', '+7 (957) 921-51-34', 'marianna@yandex')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [Email]) VALUES (2, N'Смирнов', N'Ярослав', N'Максимович', 'marfa@yandex')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [PhoneNumber], [Email]) VALUES (3, N'Голубев', N'Егор', N'Игоривич', '+7 (970) 958-25-28', 'aleksey@hotmail')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [PhoneNumber], [Email]) VALUES (4, N'Баранова', N'Татьяна', N'Ивановна', '+7 (952) 654-79-57', 'irina@outlook.co')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [Email]) VALUES (5, N'Ширяева', N'Ева', N'Алексеивна', 'anjela@outlook')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [PhoneNumber], [Email]) VALUES (6, N'Филипенко', N'Вадим', N'Андреивич', '+7 (967) 785-39-81', 'fility@mail')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [Email]) VALUES (7, N'Губеров', N'Антон', N'Антонович', 'marianna@yandex')
INSERT INTO [dbo].[buyers] ([id], [Surname], [Name], [Patomic], [Email]) VALUES (8, N'Владоренко', N'Ирина', N'Денисовна', 'nnioper@yandex')
SET IDENTITY_INSERT [dbo].[buyers] OFF;

SET IDENTITY_INSERT [dbo].[goods_order] ON
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (1, 'marianna@yandex', 123, 'sony bravia')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (2, 'marianna@yandex', 435, 'Iphone 10')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (3, 'marfa@yandex', 3456, N'Ноутбук')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (4, 'marfa@yandex', 4567, N'монитор')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (5, 'aleksey@hotmail', 4567, N'Стиральная машина')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (6, 'aleksey@hotmail', 7684, N'настольная лампа')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (7, 'irina@outlook.co', 4567, N'флешка')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (8, 'anjela@outlook', 987, N'плеер cd')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (9, 'fility@mail', 23124, N'Мягкая игрушка')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (10, 'fility@mail', 213, N'Наушники')
INSERT INTO [dbo].[goods_order] ([id], [Email_User], [item_number], [product_name]) VALUES (11, 'fility@mail', 1234, N'TV приставка')
SET IDENTITY_INSERT [dbo].[goods_order] OFF;