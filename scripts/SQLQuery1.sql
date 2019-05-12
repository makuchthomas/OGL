USE Ogl

CREATE TABLE Users (
	UserId uniqueidentifier primary key not null,
	Email nvarchar(100) not null,
    Password nvarchar(200) not null,
    Salt nvarchar(200) not null,
	Role nvarchar(10),
    Username nvarchar(100) not null,
	CreatedAt datetime not null,
    UpdatedAt datetime not null,
	AdvertisementId uniqueidentifier not null,
	CONSTRAINT [FK_dbo.Advertisement] FOREIGN KEY (AdvertisementId) REFERENCES [dbo].[Advertisement] ([AdvertisementId]) ON DELETE CASCADE
)

SELECT * FROM Users;

DELETE FROM Users;