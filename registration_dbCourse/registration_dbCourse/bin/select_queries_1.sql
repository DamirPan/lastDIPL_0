USE [businessDB_VS_1]

SELECT * FROM dbo.Inform;


/*
SELECT id_worker, surname, name_worker, middleName, post_name_W, company_name_W, isDismissed FROM dbo.Workers WHERE surname = 'Соболь' OR id_worker = 6 OR id_worker = 7;
SELECT id_worker, surname, name_worker, middleName, post_name_W, company_name_W, isDismissed FROM dbo.Workers WHERE isDismissed = 0;
*/
/*
SELECT * FROM dbo.Posts ORDER BY post_name;
SELECT * FROM dbo.Departments ORDER BY department_name
*/
-- SELECT * FROM dbo.Workers;



DECLARE @comp_name_bot NVARCHAR(90);
SET @comp_name_bot = 'Филиал в Аргентинской Республике';
SELECT Companies.id_company FROM Companies JOIN Workers ON Companies.company_name = Workers.company_name_W  WHERE Workers.company_name_W = @comp_name_bot;

-- SELECT id_post FROM dbo.Posts JOIN dbo.Workers ON post_name = dbo.Workers.post_name_W
SELECT id_company FROM dbo.Companies  JOIN Workers ON Workers.company_name_W = Companies.company_name







--SELECT Companies.id_company FROM Companies JOIN Workers ON Companies.company_name = Workers.company_name_W WHERE Workers.company_name_W = @comp_name_bot;





-- JOIN dbo.Posts ON dbo.Workers.id_post_wf = Posts.id_post JOIN dbo.Companies ON dbo.Workers.id_company_wf = dbo.Companies.id_company ;



   
/*
INSERT INTO Workers 
([id_worker], [surname], [name_worker], [middleName],  [post_name_W],  [department_name_W],  [company_name_W], [isDismissed])  -- 

VALUES
	( 4, N'n4', N'n4', N'n4',  'Главный инженер',  N'Отдел организации и контроля строительных работ',    N'ООО "БН-ЭнергоСервис"',  0); -- 0==false    --   'COMP 1', 'DEP 1', 'POST 1',
*/
--  UPDATE Workers JOIN dbo.Companies ON Workers.company_name_W = Companies.company_name SET surname, name_worker, middleName, id_company_wf = @id_company_wf, company_name_W, id_post_wf, post_name_W, id_department_wf, department_name_W, isDismissed WHERE id_worker = @id_worker";
/*
SELECT id_company FROM dbo.Companies LEFT JOIN Workers ON Workers.company_name_W = Companies.company_name WHERE id_worker = 2;


SELECT * FROM dbo.Workers;
                                                     --**********                                           --************* 
SELECT id_worker, surname, name_worker, middleName, id_company, company_name_W, id_post_wf, post_name_W, id_department, department_name_W, isDismissed 
	FROM dbo.Workers LEFT JOIN Companies ON   (Workers.company_name_W = Companies.company_name) 
						LEFT JOIN Departments ON (Workers.department_name_W = Departments.department_name) ;

SELECT id_exWorker, id_worker_exF, surname_ex, name_ex, middleName_ex, id_company_Fex, company_name_W_ex, id_post_Fex, post_name_W_ex, id_department_Fex, department_name_W_ex 
	FROM dbo.ExWorkwers, Companies WHERE (ExWorkwers.id_company_Fex = Companies.id_company) AND (ExWorkwers.company_name_W_ex = Companies.company_name) ;



/* LEFT JOIN dbo.Companies ON Companies.company_name = Workers.company_name_W
							 LEFT JOIN dbo.Departments ON Departments.department_name = Workers.department_name_W
							 LEFT JOIN dbo.Posts ON Posts.post_name = Workers.post_name_W*/
							 ;

*/

/*

delete from dbo.Users;
INSERT INTO dbo.Users 
	([id_user],[login_user], [password_user])
VALUES
	( 1, N'Admin', N'14c7ac7c0f68c28c4542867669259877e580287df53b910390f2483849bc4f490') -- Password Admin

select * from dbo.Users;
*/

/*


DELETE FROM dbo.Workers;
SELECT surname, name_worker, middleName FROM Workers LEFT JOIN Companies ON (Workers.id_company_wf = Companies.id_company) LEFT JOIN Posts ON (Workers.id_post_wf = Posts.id_post) LEFT JOIN Departments ON Workers.id_department_wf = Departments.id_department;
INSERT INTO dbo.Workers (id_worker, surname, name_worker, middleName, id_company_wf, id_post_wf, id_department_wf, isDismissed) 
	VALUES (10, 'AA', 'BB', 'CC', 1, 2, 3, 0);
--	WHERE dbo.Workers.id_company_wf = dbo.Companies.id_company;

SELECT surname_ex, name_ex, middleName_ex, id_company_Fex, id_post_Fex, id_department_Fex 
					FROM dbo.ExWorkwers, dbo.Workers 
										WHERE dbo.ExWorkwers.surname_ex = dbo.Workers.surname AND 
										name_ex = dbo.Workers.name_worker AND
										middleName_ex = dbo.Workers.middleName AND
										id_company_Fex = dbo.Workers.id_company_wf AND 
										id_post_Fex = dbo.Workers.id_post_wf AND 
										id_department_Fex = dbo.Workers.id_department_wf;
/*
DELETE dbo.Workers  --[id_worker], [surname], [name_worker], [middleName], [id_company_wf], [id_post_wf], [id_department_wf], [isDismissed]  
	FROM dbo.Workers LEFT JOIN dbo.ExWorkwers ON  (dbo.Workers.id_worker = dbo.ExWorkwers.id_worker_exF) 
	WHERE
	dbo.Workers.surname = dbo.ExWorkwers.surname_ex  AND
	dbo.Workers.name_worker = dbo.ExWorkwers.name_ex AND  
	dbo.Workers.middleName = dbo.ExWorkwers.middleName_ex AND 
	dbo.Workers.id_company_wf = dbo.ExWorkwers.id_company_Fex AND 
	dbo.Workers.id_post_wf = dbo.ExWorkwers.id_post_Fex AND 
	dbo.Workers.id_department_wf = dbo.ExWorkwers.id_department_Fex ;
*/	

										--if (dbo.Workers.isDismissed == 0) 


SELECT surname, name_worker, middleName, post_name, department_name, company_name, isDismissed  FROM 
										(dbo.Workers LEFT JOIN dbo.Posts ON dbo.Workers.id_post_wf = dbo.Posts.id_post) 
										LEFT JOIN dbo.Departments ON (dbo.Workers.id_department_wf = dbo.Departments.id_department) 
										LEFT JOIN  dbo.Companies ON dbo.Workers.id_company_wf = dbo.Companies.id_company ;
		

-- SELECT * FROM dbo.Posts;
-- SELECT * FROM dbo.Departments;
-- SELECT * FROM dbo.Companies; 
-- SELECT * FROM dbo.Users;
-- SELECT * FROM dbo.Workers;
-- SELECT * FROM dbo.ExWorkwers; 
-- SELECT * FROM dbo.Inform; 
*/