BEGIN TRY 
BEGIN TRANSACTION
    use TestCrudApi
/*Создаем справочники*/
/*Создание таблицы RefCurrency*/
IF EXISTS( 
    SELECT * FROM sys.objects WHERE name = N'Ref_Education' and TYPE = 'U' AND schema_id = 1
) 
BEGIN 
    Print('Таблица Ref_Education уже существует')
END
ELSE BEGIN 
    CREATE TABLE Ref_Education (
        [Id] int identity not null,
        [Name] nvarchar(100) not null,
        CONSTRAINT PK_Ref_Education PRIMARY KEY CLUSTERED ([Id])
    )
/* Описания столбцов и самой таблицы */
    exec sp_addextendedproperty @name = N'Name', @value = N'Название образования', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'Ref_Education'
END
     
/*Создание таблицы Doc_InternalTransactionSolar*/
IF EXISTS( SELECT * FROM sys.objects WHERE name = N'Doc_Person' and TYPE = 'U' AND schema_id = 1
) 
BEGIN 
    Print('Таблица Doc_Person уже существует')
END
ELSE BEGIN 
    CREATE TABLE Doc_Person (
        [Id] bigint identity not null,
        [FirstName] nvarchar(50) not null,
        [LastName] nvarchar(50) not null,
        [Age] tinyint not null,
        CONSTRAINT PK_Doc_Person PRIMARY KEY CLUSTERED ([Id])
    )   
/* Описания столбцов и самой таблицы */

exec sp_addextendedproperty @name = N'FirstName',@value = N'Имя',@level0type = N'Schema',@level0name = 'dbo',@level1type = N'Table',@level1name = 'Doc_Person' 
exec sp_addextendedproperty @name = N'LastName',@value = N'Имя',@level0type = N'Schema',@level0name = 'dbo',@level1type = N'Table',@level1name = 'Doc_Person' 
exec sp_addextendedproperty @name = N'Age',@value = N'Возраст',@level0type = N'Schema',@level0name = 'dbo',@level1type = N'Table',@level1name = 'Doc_Person' 
END

IF EXISTS( SELECT * FROM sys.objects WHERE name = N'Doc_EducationLine' and TYPE = 'U' AND schema_id = 1
) 
BEGIN 
    Print('Таблица Doc_EducationLine уже существует')
END
ELSE BEGIN 
    CREATE TABLE Doc_EducationLine (
        [Id] bigint identity not null,
        [PersonId] bigint not null references Doc_Person ([Id]),
        [EducationId] int not null references Ref_Education ([Id]),
        CONSTRAINT PK_Doc_EducationLine PRIMARY KEY CLUSTERED ([Id])
    )   
/* Описания столбцов и самой таблицы */

exec sp_addextendedproperty @name = N'PersonId',@value = N'Id человека',@level0type = N'Schema',@level0name = 'dbo',@level1type = N'Table',@level1name = 'Doc_EducationLine' 
exec sp_addextendedproperty @name = N'EducationId',@value = N'Id образования',@level0type = N'Schema',@level0name = 'dbo',@level1type = N'Table',@level1name = 'Doc_EducationLine' 
END
     
COMMIT TRANSACTION
END TRY 
BEGIN CATCH 
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
THROW
END CATCH