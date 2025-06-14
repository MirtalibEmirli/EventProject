CREATE TABLE [dbo].[Logs] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,          -- Unikal ID
    [Logged] DATETIME NOT NULL,                          -- Log yazılma tarixi
    [Level] NVARCHAR(50) NOT NULL,                       -- Log səviyyəsi (məsələn, Info, Error, Warning)
    [Message] NVARCHAR(MAX) NOT NULL,                    -- Log mesajı
    [Exception] NVARCHAR(MAX) NULL,                      -- Xətaların təsviri (əgər varsa)
    [Logger] NVARCHAR(255) NULL,                         -- Hansi logger istifadə edilib
    [Callsite] NVARCHAR(255) NULL,                       -- Logun gəldiyi metod və ya fayl
    [MachineName] NVARCHAR(255) NULL,                    -- Əməliyyatın keçirildiyi maşının adı
    [Thread] NVARCHAR(50) NULL,                          -- Hangi thread-in işlədiyi
    [UserName] NVARCHAR(255) NULL,                       -- Sistemdəki istifadəçi adı
    [Application] NVARCHAR(255) NULL                     -- Tətbiqin adı (məsələn, web tətbiqi)
);
