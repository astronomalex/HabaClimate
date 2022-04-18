﻿COMMIT;

START TRANSACTION;

ALTER TABLE "Good" DROP CONSTRAINT "FK_Good_brands_BrandId";

ALTER TABLE brands DROP CONSTRAINT "PK_brands";

ALTER TABLE brands RENAME TO "Brands";

ALTER TABLE "Brands" ADD CONSTRAINT "PK_Brands" PRIMARY KEY ("Id");

CREATE TABLE "CartItems" (
                             "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                             "AirConditionerId" integer NULL,
                             "Price" numeric NOT NULL,
                             "ShopCartId" text NULL,
                             CONSTRAINT "PK_CartItems" PRIMARY KEY ("Id"),
                             CONSTRAINT "FK_CartItems_Good_AirConditionerId" FOREIGN KEY ("AirConditionerId") REFERENCES "Good" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_CartItems_AirConditionerId" ON "CartItems" ("AirConditionerId");

ALTER TABLE "Good" ADD CONSTRAINT "FK_Good_Brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Brands" ("Id") ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220402231548_AddShopCart', '5.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE "CartItems" DROP CONSTRAINT "FK_CartItems_Good_AirConditionerId";

ALTER TABLE "CartItems" RENAME COLUMN "AirConditionerId" TO "GoodId";

ALTER INDEX "IX_CartItems_AirConditionerId" RENAME TO "IX_CartItems_GoodId";

ALTER TABLE "CartItems" ADD CONSTRAINT "FK_CartItems_Good_GoodId" FOREIGN KEY ("GoodId") REFERENCES "Good" ("Id") ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220405093912_fix', '5.0.15');

COMMIT;

START TRANSACTION;

CREATE TABLE "Orders" (
                          "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                          "Name" text NULL,
                          "Surname" text NULL,
                          "Phone" text NULL,
                          "OrderTime" timestamp without time zone NOT NULL,
                          CONSTRAINT "PK_Orders" PRIMARY KEY ("Id")
);

CREATE TABLE "OrderDetails" (
                                "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                                "OrderId" integer NOT NULL,
                                "GoodId" integer NOT NULL,
                                "Price" numeric NOT NULL,
                                CONSTRAINT "PK_OrderDetails" PRIMARY KEY ("Id"),
                                CONSTRAINT "FK_OrderDetails_Good_GoodId" FOREIGN KEY ("GoodId") REFERENCES "Good" ("Id") ON DELETE CASCADE,
                                CONSTRAINT "FK_OrderDetails_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_OrderDetails_GoodId" ON "OrderDetails" ("GoodId");

CREATE INDEX "IX_OrderDetails_OrderId" ON "OrderDetails" ("OrderId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220407223024_Order', '5.0.15');

COMMIT;