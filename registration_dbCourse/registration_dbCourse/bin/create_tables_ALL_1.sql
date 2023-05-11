USE [businessDB_VS_1]

DROP TABLE IF EXISTS dbo.Posts;
DROP TABLE IF EXISTS dbo.Departments;
DROP TABLE IF EXISTS dbo.Companies;
DROP TABLE IF EXISTS dbo.Users;
DROP TABLE IF EXISTS dbo.Workers;
DROP TABLE IF EXISTS dbo.ExWorkwers;
DROP TABLE IF EXISTS dbo.Inform;

-- 1
CREATE TABLE dbo.Posts(           -- ****************************
	id_post INT PRIMARY KEY,
	post_name [NVARCHAR](90), 
	id_worker_f INT --foreign key
);

-- 2
CREATE TABLE dbo.Departments(        -- ********************
	id_department INT PRIMARY KEY, 
	department_name [NVARCHAR](150) , 

	id_post_f INT --foreign key
);

-- 3 
CREATE TABLE dbo.Companies(        -- ****************************
	id_company INT PRIMARY KEY, 
	company_name [NVARCHAR](150),

	id_department_f INT --foreign key
); 

-- 4 
CREATE TABLE dbo.Users(            -- ***********************
	id_user INT PRIMARY KEY, 
	login_user [NVARCHAR](50), 
	password_user [CHAR](300)
); 

-- 5 
CREATE TABLE dbo.Workers(      -- *********************************
	id_worker INT PRIMARY KEY,  -- PRIMARY KEY, 
	surname [NVARCHAR](50),
	name_worker [NVARCHAR](50),
	middleName [NVARCHAR](50), 

	id_company_wf INT, --foreign key
	company_name_W [NVARCHAR](150), 
	id_post_wf INT, --foreign key
	post_name_W [NVARCHAR](90), 
	id_department_wf INT, --foreign key
	department_name_W [NVARCHAR](150), 

	isDismissed [BIT]  --  BIT = Boolean ==>  0 is FALSE, 1 is TRUE
); 

-- 6 
CREATE TABLE dbo.ExWorkwers(
	id_exWorker INT PRIMARY KEY, 

	id_worker_exF INT,  --foreign key

	surname_ex [NVARCHAR](50),
	name_ex [NVARCHAR](50),
	middleName_ex [NVARCHAR](50), 

	id_company_Fex INT, --foreign key
	company_name_W_ex [NVARCHAR](150), 
	id_post_Fex INT, --foreign key
	post_name_W_ex [NVARCHAR](50), 
	id_department_Fex INT, --foreign key
	department_name_W_ex [NVARCHAR](150), 

/*	
	company_name_ex [NVARCHAR](50), 
	post_name_ex [NVARCHAR](50), 
	department_name_ex [NVARCHAR](50)
*/
);

-- 7 
CREATE TABLE dbo.Inform(
	id_inf INT PRIMARY KEY,
	num_ [TEXT], -- №командировочного удостоверения K-00001 или K-A-00001
	surname_ [NVARCHAR](50),
	name_ [NVARCHAR](50),
	middleName_ [NVARCHAR](50),
	post_ [NVARCHAR](50),
	company_ [NVARCHAR](50),
	date_doc_ [TEXT],   -- ГОД-МЕСЯЦ-ДЕНЬ
	days_in_ [INT], 
	date_go_ [TEXT],
	place1_from_ [NVARCHAR](50),
	place2_in_ [NVARCHAR](50),
	place_finish_ [NVARCHAR](50),	
	purpose_ [NVARCHAR](100),

	id_worker_Finf INT --foreign key
);