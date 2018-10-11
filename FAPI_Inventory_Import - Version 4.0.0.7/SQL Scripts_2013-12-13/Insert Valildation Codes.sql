USE [ApplicationSettings]
GO

DELETE FROM ValidationTable

INSERT INTO ValidationTable

SELECT 'Variety', [Description], [Code], NULL
From Variety_Codes

INSERT INTO ValidationTable

SELECT 'Style_Size', [Style_Size_Description]
      ,[Style_Size_Code], NULL
From Style_Size_Codes

INSERT INTO ValidationTable

SELECT 'Style', [Style_Description]
      ,[Code], NULL
From Style_Codes

INSERT INTO ValidationTable

SELECT 'Size', [Size_Description]
      ,[Code], NULL
From Size_Codes

INSERT INTO ValidationTable

SELECT 'Grade', [Grade_Description]
      ,[Code], NULL
From Grade_Codes

INSERT INTO ValidationTable

SELECT 'Label', [Label_Description]
      ,[Code], NULL
From Label_Codes

INSERT INTO ValidationTable

SELECT 'Color', [Color_Description]
      ,[Code], NULL
From Color_Codes