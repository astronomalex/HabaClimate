﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
    );

START TRANSACTION;

CREATE TABLE brands (
                        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                        "Name" text NULL,
                        "ShortDesc" text NULL,
                        "LongDesc" text NULL,
                        "Img" text NULL,
                        CONSTRAINT "PK_brands" PRIMARY KEY ("Id")
);

CREATE TABLE "Categories" (
                              "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                              "CategoryName" text NULL,
                              "Desc" text NULL,
                              CONSTRAINT "PK_categories" PRIMARY KEY ("Id")
);

CREATE TABLE "Good" (
                        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
                        "Name" text NULL,
                        "ShortDesc" text NULL,
                        "LongDesc" text NULL,
                        "Img" text NULL,
                        "Price" numeric NOT NULL,
                        "Available" boolean NOT NULL,
                        "IsFavorite" boolean NOT NULL,
                        "CategoryId" integer NOT NULL,
                        "BrandId" integer NULL,
                        "Discriminator" text NOT NULL,
                        "IsInverter" boolean NULL,
                        "EnergyEfficiencyClass" text NULL,
                        "SquareRoom" integer NULL,
                        CONSTRAINT "PK_Good" PRIMARY KEY ("Id"),
                        CONSTRAINT "FK_Good_brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES brands ("Id") ON DELETE RESTRICT,
                        CONSTRAINT "FK_Good_categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Good_BrandId" ON "Good" ("BrandId");

CREATE INDEX "IX_Good_CategoryId" ON "Good" ("CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220402191610_Initial', '5.0.15');

COMMIT;

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
