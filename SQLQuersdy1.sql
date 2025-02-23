CREATE TABLE Users (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Email]       NVARCHAR(70)   NOT NULL,
    [Phone]       NVARCHAR(50)   NOT NULL,
    [Surname]     NVARCHAR(50)   NOT NULL,
    [PasswordHash] NVARCHAR(1000) NOT NULL,
    [UpdatedBy]   INT            NULL,
    [CreatedBy]   INT            NULL,
    [DeletedBy]   INT            NULL,
    [CreatedDate] DATETIME2 (7)  default GETDATE(),
    [DeletedDate] DATETIME2 (7)  NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            default 0
);