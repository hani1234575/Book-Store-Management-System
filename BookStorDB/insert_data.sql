-- SQL INSERT Statements for BookStorDB
-- Generated for realistic data population

USE [BookStorDB]
GO
Alter Table EMployee
Select * from Employee
-- 1. Insert Roles
SET IDENTITY_INSERT [dbo].[Role] ON;
INSERT INTO [dbo].[Role] ([Role_ID], [Role_Name], [Date_Given]) VALUES 
(400, 'Author', '2026-01-01'),
(410, 'Employee', '2026-01-01'),
(420, 'Admin', '2026-01-01'),
(430, 'Customer', '2026-01-01')
SET IDENTITY_INSERT [dbo].[Role] OFF;
GO

-- 2. Insert Categories
SET IDENTITY_INSERT [dbo].[Categories] ON;
INSERT INTO [dbo].[Categories] ([Category_Id], [Category_Name], [Description]) VALUES 
(1, N'Science', N'Math, Physics, Chemistry, Biology, etc.'),
(2, N'Technology', N'Programming, Algorithms, Networking, AI, etc.'),
(3, N'Literature', N'Stories, Novels, Poetry, etc.'),
(4, N'History', N'World History, Ancient Civilizations, War History.'),
(5, N'Business', N'Marketing, Management, Finance, Economics.'),
(6, N'Self Development', N'Success, Confidence, Life Skills, Psychology.'),
(7, N'Religion', N'Theology, Spirituality, Religious Texts.'),
(8, N'Art & Design', N'Painting, Architecture, Graphic Design.'),
(9, N'Cooking', N'Recipes, Culinary Arts, Nutrition.'),
(10, N'Travel', N'Guides, Travelogues, Geography.');
SET IDENTITY_INSERT [dbo].[Categories] OFF;
GO

-- 3. Insert Publishers
SET IDENTITY_INSERT [dbo].[Publishers] ON;
INSERT INTO [dbo].[Publishers] ([Publisher_Id], [Publisher_Name], [Publisher_Contact], [Publisher_Address]) VALUES 
(1, N'Oxford University Press', N'+44 1865 556767', N'Great Clarendon Street, Oxford, UK'),
(2, N'Penguin Random House', N'+1 212 782 9000', N'1745 Broadway, New York, NY, USA'),
(3, N'HarperCollins', N'+1 212 207 7000', N'195 Broadway, New York, NY, USA'),
(4, N'O''Reilly Media', N'+1 707 827 7000', N'1005 Gravenstein Highway North, Sebastopol, CA'),
(5, N'Springer Nature', N'+49 6221 487 0', N'Heidelberger Platz 3, Berlin, Germany'),
(6, N'Pearson Education', N'+44 20 7010 2000', N'80 Strand, London, UK'),
(7, N'Hachette Livre', N'+33 1 43 92 30 00', N'58 rue Jean Bleuzen, Vanves, France'),
(8, N'Macmillan Publishers', N'+1 646 307 5151', N'120 Broadway, New York, NY, USA'),
(9, N'Scholastic', N'+1 212 343 6100', N'557 Broadway, New York, NY, USA'),
(10, N'Wiley', N'+1 201 748 6000', N'111 River Street, Hoboken, NJ, USA');
SET IDENTITY_INSERT [dbo].[Publishers] OFF;
GO

-- 4. Insert Authors
SET IDENTITY_INSERT [dbo].[Authors] ON;
INSERT INTO [dbo].[Authors] ([Author_Id], [Author_Name], [Author_Email], [Role_ID], [Author_Password]) VALUES 
(100, N'Robert C. Martin', N'unclebob@cleancode.com', 400, N'p@ssword123'),
(101, N'J.K. Rowling', N'jkrowling@pottermore.com', 400, N'magic_pwd'),
(102, N'Stephen King', N'sking@horror.com', 400, N'redrum99'),
(103, N'Yuval Noah Harari', N'yuval@sapiens.com', 400, N'history_man'),
(104, N'Simon Sinek', N'simon@startwithwhy.com', 400, N'why_leader'),
(105, N'Martin Fowler', N'mfowler@thoughtworks.com', 400, N'refactor_pro'),
(106, N'Malcolm Gladwell', N'malcolm@gladwell.com', 400, N'outliers10k'),
(107, N'Agatha Christie', N'agatha@mystery.co.uk', 400, N'poirot_detective'),
(108, N'George Orwell', N'george@1984.com', 400, N'bigbrother_is_watching'),
(109, N'Dale Carnegie', N'dale@friends.com', 400, N'influence_people');
SET IDENTITY_INSERT [dbo].[Authors] OFF;
GO

-- 5. Insert Books
SET IDENTITY_INSERT [dbo].[Books] ON;
INSERT INTO [dbo].[Books] ([Book_Id], [Book_Title], [Book_ISBN], [CopiesAvailable], [Author_Id], [Publisher_Id], [Category_Id]) VALUES 
(1, N'Clean Code', N'978-0132350884', 15, 100, 6, 2),
(2, N'Harry Potter and the Sorcerer''s Stone', N'978-0439708180', 25, 101, 9, 3),
(3, N'The Shining', N'978-0307743657', 10, 102, 2, 3),
(4, N'Sapiens: A Brief History of Humankind', N'978-0062316097', 20, 103, 3, 4),
(5, N'Start with Why', N'978-1591846444', 12, 104, 2, 5),
(6, N'Refactoring', N'978-0134757599', 8, 105, 6, 2),
(7, N'Outliers: The Story of Success', N'978-0316017930', 14, 106, 2, 6),
(8, N'Murder on the Orient Express', N'978-0062693655', 18, 107, 3, 3),
(9, N'1984', N'978-0451524935', 30, 108, 2, 3),
(10, N'How to Win Friends and Influence People', N'978-0671027032', 22, 109, 10, 6),
(11, N'The Pragmatic Programmer', N'978-0135957059', 10, 100, 6, 2),
(12, N'A Brief History of Time', N'978-0553380163', 15, 103, 1, 1),
(13, N'Thinking, Fast and Slow', N'978-0374533557', 12, 106, 2, 6),
(14, N'The Lean Startup', N'978-0307887894', 20, 104, 2, 5),
(15, N'Deep Learning', N'978-0262035613', 5, 105, 4, 2);
SET IDENTITY_INSERT [dbo].[Books] OFF;
GO

-- 6. Insert Customers
SET IDENTITY_INSERT [dbo].[Customers] ON;
INSERT INTO [dbo].[Customers] ([Customer_ID], [Customer_Name], [Customer_Email], [Role_ID], [Customer_Password]) VALUES 
(500, N'John Doe', N'john.doe@email.com', 430, N'customer123'),
(510, N'Jane Smith', N'jane.smith@gmail.com', 430, N'securePass!'),
(520, N'Michael Brown', N'mbrown@outlook.com', 430, N'mike_pwd'),
(530, N'Emily Davis', N'emily.d@yahoo.com', 430, N'emily_pass'),
(540, N'David Wilson', N'dwilson@gmail.com', 430, N'david1990'),
(550, N'Sarah Miller', N'smiller@protonmail.com', 430, N'sarah_secure'),
(560, N'Chris Evans', N'cevans@marvel.com', 430, N'avengers_assemble'),
(570, N'Emma Watson', N'ewatson@hogwarts.com', 430, N'hermione_granger'),
(580, N'Robert Downey', N'rdowney@stark.com', 430, N'ironman_rocks'),
(590, N'Scarlett Johansson', N'scarlett@blackwidow.com', 430, N'widow_bite');
SET IDENTITY_INSERT [dbo].[Customers] OFF;
GO

-- 7. Insert Employees
SET IDENTITY_INSERT [dbo].[Employee] ON;
INSERT INTO [dbo].[Employee] ([Employee_Id], [Employee_FullName], [Employee_Email], [Employee_Address], [Employee_Gender], [Employee_Phone], [Employee_JoinDate], [Role_ID], [Employee_Password]) VALUES 
(200, N'Alice Johnson', N'alice.j@bookstore.com', N'123 Library St, New York', 0, N'555-0101', '2024-05-15', 420, N'admin_alice'),
(210, N'Bob Thompson', N'bob.t@bookstore.com', N'456 Reading Rd, Boston', 1, N'555-0102', '2024-06-20', 410, N'bob_staff'),
(220, N'Charlie Parker', N'charlie.p@bookstore.com', N'789 Novel Ave, Chicago', 1, N'555-0103', '2024-08-10', 410, N'charlie_staff'),
(230, N'Diana Prince', N'diana.p@bookstore.com', N'101 Wonder Blvd, Seattle', 0, N'555-0104', '2025-01-05', 410, N'mana_diana'),
(240, N'Edward Norton', N'edward.n@bookstore.com', N'202 Cinema Dr, Los Angeles', 1, N'555-0105', '2025-03-12', 410, N'ed_staff');
SET IDENTITY_INSERT [dbo].[Employee] OFF;
GO

-- 8. Insert Rentals
SET IDENTITY_INSERT [dbo].[Rentals] ON;
INSERT INTO [dbo].[Rentals] ([Rental_Id], [Customer_ID], [Book_Id], [Rent_Date], [Return_Date]) VALUES 
(300, 500, 1, '2026-04-01', '2026-04-15'),
(310, 510, 2, '2026-04-05', '2026-04-19'),
(320, 520, 3, '2026-04-10', '2026-04-24'),
(330, 530, 4, '2026-04-12', '2026-04-26'),
(340, 540, 5, '2026-04-15', '2026-04-29'),
(350, 550, 6, '2026-04-18', '2026-05-02'),
(360, 560, 7, '2026-04-20', '2026-05-04'),
(370, 570, 8, '2026-04-21', '2026-05-05'),
(380, 580, 9, '2026-04-22', '2026-05-06'),
(390, 590, 10, '2026-04-23', '2026-05-07');
SET IDENTITY_INSERT [dbo].[Rentals] OFF;
GO

Select* from Authors