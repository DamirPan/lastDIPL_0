USE [businessDB_VS_1]

DELETE FROM dbo.Posts;
DELETE FROM dbo.Departments;
DELETE FROM dbo.Companies;
DELETE FROM dbo.Users;
DELETE FROM dbo.ExWorkwers; 
DELETE FROM dbo.Workers;
DELETE FROM dbo.Inform;

-- 1 
INSERT INTO dbo.Posts
	([id_post], [post_name])
VALUES 
	(1, '��������� ����������'),
	(2, '����������� ���������� �� ��� ������������������������'),
	(3, '������ ����������� ���������� - ������� �������'),
	(4, '����������� ���������� �� ����������������� � ������������'),
	
	(5, '��������'),
	(6, '������� �������'),
	(7, '������� ��� ��'),
	(8, '������� �� �� � ��'),
	(9, '������� ���'),
	(10, '�������-�����������'),
	(11, '��������� �� ������'),
	(12, '��������� ������'),
	(13, '���������� �� ��������� �����'),
	(14, '����������� ����������� �������'),
	(15, '���������'),
	(16, '��������� �� �����'),
	(17, '�������� ����������'),
	(18, '������� �����'),
	(19, '��������� �������������'),
	(20, '���������� �� �������������� ������������'),
	(21, '������� ������� �� �������������� �����������'),
	(22, '���������')


-- 2 
INSERT INTO dbo.Departments
	([id_department],[department_name])
VALUES
	( 1, N'����� �������������� ������'),
	( 2, N'����� ��������������-������������� ����������� ���'),
	( 3, N'����� ����������� ��������������� ������'),
	( 4, N'����� ��� ��'),
	( 5, N'����� ������������ ������������ ��� � ��� ���'),
	
	( 6, N'������ �������������� ������������'),
	( 7, N'����� ����������, ���������� � ������������ ��'),
	( 8, N'����� ��������������, ������������� � ������������ ��'),
	( 9, N'����� ��������������� ����������� � ������� ��������������'),
	( 10, N'����� ��������� � ��������� ������������� EAP-�������'),
	
	( 11, N'������ �� �� � ��'),
	( 12, N'���������������� �����������'),
	( 13, N'������ �� �������� �� ���������������'),
	( 14, N'����� ���. ������������ �������������� �������, ���������������� � ������ ������'),
	( 15, N'����� ������������ ������� � ������ ����������'),
	( 16, N'����� ������������ ����������'),
	
	( 17, N'������� ��� �����������'),
	( 18, N'������ �� ������ � ����������'),
	( 19, N'������������� �����'),
	( 20, N'�����������')

-- 3
INSERT INTO dbo.Companies
	([id_company],[company_name])
VALUES
	( 1, N'����������� �������'),
	( 2, N'���� "�����������"'),
	( 3, N'����'), 
	( 4, N'�� "�����������������"'), 
	( 5, N'������������'),
	( 6, N'�������'),
	( 7, N'����'),
	( 8, N'�� "��������������"'), 
	( 9, N'���. ������. "������������-����������"'),
	( 10, N'�� "��������������"'), 
	( 11, N'���'),
	( 12, N'���'),
	( 13, N'�� "�����������������"'),
	( 14, N'����'), 
	( 15, N'����'),
	( 16, N'���'),
	( 17, N'����������� ����������'),
	( 18, N'����'), 
	( 19, N'�������������� ����������'),
	( 20, N'���. ������. "��-��������������"'),
	( 21, N'����������������� � ���������'),
	( 22, N'������ � ���������� �������'),
	( 23, N'��� "�� "������������"'), 
	( 24, N'��� "������������-��������������������"'), 
	( 25, N'��� "������������-����������������������"'),
	( 26, N'��� "����������������"'),
	( 27, N'��� "������������-���������������������"'),
	( 28, N'��� "������������-������"'), 
	( 29, N'��� "�������������"'),
	( 30, N'��� "������������-�������"'), 
	( 31, N'��� "������������-��������������������"'),
	( 32, N'��� "������������-�����������������"'),
	( 33, N'��� "������������-���������������������"'),
	( 34, N'��� "������������-����������������������"'), 
	( 35, N'��� "��-������������"'),
	( 36, N'��� "��-���������"'),
	( 37, N'���. ������. "������������-�����"'),
	( 38, N'��� "��������������������"'), 
	( 39, N'��� "������ ���"'),
	( 40, N'������������ ����������� ����������� ���'),
	( 41, N'��� "�������� �������� "������"'),
	( 42, N'������ � ������������ ����������')

-- 4 
INSERT INTO dbo.Users 
	([id_user],[login_user], [password_user])
VALUES
	( 1, N'Admin', N'14c7ac7c0f68c28c4542867669259877e580287df53b910390f2483849bc4f490') -- Password Admin

-- 5 
INSERT INTO dbo.Workers
	([id_worker], [surname], [name_worker], [middleName], [id_post_wf], [post_name_W], [id_department_wf], [department_name_W], [id_company_wf], [company_name_W], [isDismissed])  -- 
VALUES
	( 1, N'������', N'����', N'��������', 10, '�������-�����������', 1,  N'����� �������������� ������',  4, N'�� "�����������������"',  0) -- 0==false    --   'COMP 1', 'DEP 1', 'POST 1',
--	( 2, N'DELI', N'D2', N'DD3', 1, '������� �������', 1, N'����� ����������� � �������� ������������ �����',    40, N'������������ ����������� ����������� ���',  1), -- 1==true 
--	( 3,  N'������', N'����', N'��������',  1, '������� �������', 1, N'����� ����������� � �������� ������������ �����', 11, N'���',  1)

-- 6 
INSERT INTO dbo.ExWorkwers
	([id_exWorker], [id_worker_exF], [surname_ex], [name_ex], [middleName_ex], [id_post_Fex], [post_name_W_ex],  [id_department_Fex], [department_name_W_ex], [id_company_Fex], [company_name_W_ex] ) -- [id_worker_exF]) --    
VALUES 
	--(1, 1)
	(1, 2, N'DELI', N'D2', N'DD3',  1, N'����� ����������� � �������� ������������ �����', 1, '������� �������', 40, N'������������ ����������� ����������� ���'),
	(2, 3,  N'������', N'����', N'��������',  1, N'����� ����������� � �������� ������������ �����', 1, '������� �������', 11, N'���')
-- 7 
INSERT INTO dbo.Inform
	([id_inf], [num_], [surname_], [name_], [middleName_], [post_],
	[company_], [date_doc_], [days_in_], [date_go_],
	[place1_from_], [place2_in_], [place_finish_],
	[purpose_])--,
--	[id_worker], [id_company_in] )
VALUES
	(1, 'K-00001', '������', '����', '��������', '�������-�����������', 
	 '����������� �������', '�����������, 20 ������ 2022 �.', '1', '�����������, 22 ������ 2022 �.',
	 '����������� �������', '���� "�����������"', '����������� �������',
	 '��������� ������������') 


