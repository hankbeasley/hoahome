Create TRIGGER [dbo].[createGeometry]
ON [dbo].[Neighborhood]
FOR INSERT, UPDATE
AS
IF UPDATE(KML)
    UPDATE Neighborhood
    set Geo = geography::STPolyFromText(inserted.KML, 4326)
    FROM Neighborhood
    INNER JOIN inserted ON Neighborhood.Id = inserted.Id