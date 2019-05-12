USE Ogl

CREATE TABLE Category (
	CategoryId uniqueidentifier primary key not null,
	Name nvarchar(100) not null,
	AdvertisementId uniqueidentifier not null,
	CONSTRAINT [FK_dbo.Advertisement] FOREIGN KEY (AdvertisementId) REFERENCES [dbo].[Advertisement] ([AdvertisementId]) ON DELETE CASCADE
)


SELECT * FROM Category;

DELETE FROM Category; 