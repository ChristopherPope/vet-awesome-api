USE [VET-AWESOME-DEV]
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Secretary')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Vetranarian')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Owner')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (4, N'None')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Name], [RoleId]) VALUES (1, N'Sara Johnson', 1)
GO
INSERT [dbo].[User] ([Id], [Name], [RoleId]) VALUES (2, N'William Edwards', 2)
GO
INSERT [dbo].[User] ([Id], [Name], [RoleId]) VALUES (3, N'Vivan DeChosa', 2)
GO
INSERT [dbo].[User] ([Id], [Name], [RoleId]) VALUES (4, N'Bugs Bunny', 3)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
