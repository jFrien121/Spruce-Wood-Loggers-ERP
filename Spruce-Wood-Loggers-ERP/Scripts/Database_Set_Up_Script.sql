INSERT INTO "CutLengths" (length)
VALUES
    (4),
    (4.5),
	(6),
    (7),
	(8),
    (9),
	(10),
    (12),
	(14),
    (16)
ON CONFLICT (length) DO NOTHING;

INSERT INTO "CutSizes" (thickness, width)
VALUES
	(1,3),
	(1,4),
	(1,6),
	(1,8),
	(1,10),
	(2,3),
	(2,4),
	(2,6),
	(2,8),
	(2,10),
	(3,3),
	(3,4),
	(3,6),
	(3,8),
	(3,10),
	(4,4),
	(4,6),
	(4,8),
	(4,10),
	(8,8)
ON CONFLICT (thickness, width) DO NOTHING;

select * from "StandardNumPieces"

INSERT INTO "StandardNumPieces" ("numPieces")
VALUES
	(64),
	(96),
	(120),
	(180),
	(192),
	(225),
	(240),
	(360)
ON CONFLICT ("numPieces") DO NOTHING;

INSERT INTO "StandardSizeRelationships" ("StandardNumPiecesId", "CutSizeId")
VALUES
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 360), (SELECT id FROM "CutSizes" WHERE thickness = 1 AND width = 4)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 240), (SELECT id FROM "CutSizes" WHERE thickness = 1 AND width = 6)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 225), (SELECT id FROM "CutSizes" WHERE thickness = 2 AND width = 3)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 192), (SELECT id FROM "CutSizes" WHERE thickness = 2 AND width = 4)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 180), (SELECT id FROM "CutSizes" WHERE thickness = 2 AND width = 4)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 180), (SELECT id FROM "CutSizes" WHERE thickness = 3 AND width = 3)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 120), (SELECT id FROM "CutSizes" WHERE thickness = 2 AND width = 6)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 120), (SELECT id FROM "CutSizes" WHERE thickness = 3 AND width = 4)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 96), (SELECT id FROM "CutSizes" WHERE thickness = 4 AND width = 4)),
	((SELECT id FROM "StandardNumPieces" WHERE "numPieces" = 64), (SELECT id FROM "CutSizes" WHERE thickness = 4 AND width = 6))
ON CONFLICT ("StandardNumPiecesId", "CutSizeId") DO NOTHING;