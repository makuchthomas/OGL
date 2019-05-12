USE Ogl

CREATE TABLE Advertisement (
	AdvertisementId uniqueidentifier primary key not null,
	Title nvarchar(100) not null,
	Content nvarchar(4000) not null,
	CreatedAt datetime not null,
    UpdatedAt datetime not null,
	UserId uniqueidentifier not null,
	CategoryId uniqueidentifier not null,
    CONSTRAINT [FK_dbo.Users] FOREIGN KEY (UserId) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Category] FOREIGN KEY (CategoryId) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE
)

SELECT * FROM Advertisement;

DELETE FROM Advertisement;