USE [DB_MedicalExamination]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateMedicalRecord]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Create new medical record
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateMedicalRecord]
	@Detail		NVARCHAR(MAX),
	@CreateDate BIGINT,
	@ReasonToExamination	NVARCHAR(100),
	@MedicalHistory			NVARCHAR(2000),
	@IsGroup	BIT = 0,
	@IsActive	BIT = 0,
	@CustomerId VARCHAR(50),
	@TotalAmount DECIMAL(18,0),
	@CustomerFirstName NVARCHAR(30),
	@CustomerLastName NVARCHAR(70),
	@OrganizationId VARCHAR(50) = NULL,
	@GMExaminationId VARCHAR(50) = NULL,
	@DateCompleted BIGINT = NULL,
	@IsPaid BIT = 0,
	@WasFinishedExamination BIT = 0
AS
BEGIN
	DECLARE @MedicalRecordId VARCHAR(50) = NEWID()
	DECLARE @Message NVARCHAR(200) = 'Lỗi không xác định, hãy liên lạc với Quản trị hệ thống'
	SET @Detail = CASE WHEN TRIM(@Detail) = '' THEN NULL ELSE @Detail END
	SET @CreateDate = CASE WHEN @CreateDate = 0 THEN NULL ELSE @CreateDate END
	SET @OrganizationId = CASE WHEN TRIM(@OrganizationId) = '' THEN NULL ELSE @OrganizationId END
	SET @GMExaminationId = CASE WHEN TRIM(@GMExaminationId) = '' THEN NULL ELSE @GMExaminationId END
	SET @DateCompleted = CASE WHEN @DateCompleted = 0 THEN NULL ELSE @DateCompleted END
	SET @CustomerId = CASE WHEN TRIM(@CustomerId) = '' THEN NULL ELSE @CustomerId END
	SET @TotalAmount = CASE WHEN @TotalAmount = 0 THEN NULL ELSE @TotalAmount END
	SET @CustomerFirstName = CASE WHEN TRIM(@CustomerFirstName) = '' THEN NULL ELSE @CustomerFirstName END
	SET @CustomerLastName = CASE WHEN TRIM(@CustomerLastName) = '' THEN NULL ELSE @CustomerLastName END
	SET @ReasonToExamination = CASE WHEN TRIM(@ReasonToExamination) = '' THEN NULL ELSE @ReasonToExamination END
	SET @MedicalHistory = CASE WHEN TRIM(@MedicalHistory) = '' THEN NULL ELSE @MedicalHistory END

	BEGIN TRAN
	BEGIN TRY
		INSERT INTO [MedicalRecords]
					(
						[MedicalRecordId],
						[Detail],
						[CreateDate],
						[IsGroup],
						[IsActive],
						[OrganizationId],
						[GMExaminationId],
						[DateCompleted],
						[CustomerId],
						[IsPaid],
						[TotalAmount],
						[WasFinishedExamination],
						[CustomerFirstName],
						[CustomerLastName],
						[MedicalHistory],
						[ReasonToExamination]
					)
		VALUES		(
						@MedicalRecordId,
						@Detail,
						@CreateDate,
						@IsGroup,
						@IsActive,
						@OrganizationId,
						@GMExaminationId,
						@DateCompleted,
						@CustomerId,
						@IsPaid,
						@TotalAmount,
						@WasFinishedExamination,
						@CustomerFirstName,
						@CustomerLastName,
						@MedicalHistory,
						@ReasonToExamination
					)
		SET @Message = 'Hồ sơ bệnh án đã được tạo mới thành công'
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		SET @MedicalRecordId = ''
		ROLLBACK TRAN
	END CATCH

	SELECT @MedicalRecordId AS MedicalRecordId, @Message AS [Message]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllActiveAndFinishedExaminationMedicalRecords]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Get All MedicalRecords with status Active and just finished examination
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllActiveAndFinishedExaminationMedicalRecords]

AS
BEGIN
	SELECT
		[MedicalRecordId],
		[CustomerFirstName],
		[CustomerLastName],
		[IsActive],
		[IsPaid]
	FROM MedicalRecords
	WHERE IsActive = 1 AND WasFinishedExamination = 1 AND DateCompleted IS NULL
	ORDER BY CustomerFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllActiveAndNotFinishedExaminationMedicalRecords]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Get All MedicalRecords with status Active and not finished examination
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllActiveAndNotFinishedExaminationMedicalRecords]

AS
BEGIN
	SELECT
		[MedicalRecordId],
		[CustomerFirstName],
		[CustomerLastName],
		[IsActive],
		[IsPaid]
	FROM MedicalRecords
	WHERE IsActive = 1 AND WasFinishedExamination = 0 AND DateCompleted IS NULL
	ORDER BY CustomerFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllInactiveMedicalRecords]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Get All MedicalRecords with is not Active
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllInactiveMedicalRecords]

AS
BEGIN
	SELECT
		[MedicalRecordId],
		[CustomerFirstName],
		[CustomerLastName],
		[IsActive],
		[IsPaid]
	FROM MedicalRecords
	WHERE IsActive = 0
	ORDER BY CustomerFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMedicalRecords]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Get All MedicalRecords
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllMedicalRecords]

AS
BEGIN
	SELECT
		[MedicalRecordId],
		[CustomerFirstName],
		[CustomerLastName],
		[IsActive],
		[IsPaid]
	FROM MedicalRecords
	ORDER BY CustomerFirstName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMedicalRecordById]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Get MedicalRecords by Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMedicalRecordById]
	@MedicalRecordId VARCHAR(50)
AS
BEGIN
	SELECT
		[MedicalRecordId],
		[Detail],
		[CreateDate],
		[IsGroup],
		[IsActive],
		[OrganizationId],
		[GMExaminationId],
		[DateCompleted],
		[CustomerId],
		[IsPaid],
		[TotalAmount],
		[WasFinishedExamination],
		[CustomerFirstName],
		[CustomerLastName]
	FROM MedicalRecords
	WHERE MedicalRecordId = @MedicalRecordId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchMedicalRecordByNameOrIdActiveNotFinishedExamination]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Search MedicalRecords by name or id, active and not finished examination
-- =============================================
CREATE PROCEDURE [dbo].[sp_SearchMedicalRecordByNameOrIdActiveNotFinishedExamination]
	@SearchKey VARCHAR(50)
AS
BEGIN
	SET @SearchKey = CONCAT('%', @SearchKey, '%')
	SELECT
		[MedicalRecordId],
		[CustomerFirstName],
		[CustomerLastName],
		[IsActive],
		[IsPaid]
	FROM MedicalRecords
	WHERE (CONCAT(CustomerLastName, ' ', CustomerFirstName) LIKE @SearchKey OR MedicalRecordId LIKE @SearchKey) AND IsActive = 1 AND WasFinishedExamination = 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateMedicalRecord]    Script Date: 19/04/2021 10:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nhat Tan
-- Create date: 18/04/2021
-- Description:	Update information medical record
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateMedicalRecord]
	@MedicalRecordId		VARCHAR(50),
	@Detail					NVARCHAR(MAX),
	@CreateDate				BIGINT,
	@ReasonToExamination	NVARCHAR(100),
	@MedicalHistory			NVARCHAR(2000),
	@IsGroup				BIT = 0,
	@IsActive				BIT = 0,
	@CustomerId				VARCHAR(50),
	@TotalAmount			DECIMAL(18,0),
	@CustomerFirstName		NVARCHAR(30),
	@CustomerLastName		NVARCHAR(70),
	@OrganizationId			VARCHAR(50) = NULL,
	@GMExaminationId		VARCHAR(50) = NULL,
	@DateCompleted			BIGINT = NULL,
	@IsPaid					BIT = 0,
	@WasFinishedExamination BIT = 0,
	@Message				NVARCHAR(200) OUTPUT
AS
BEGIN
	DECLARE @MedicalRecord TABLE (
									[MedicalRecordId]			VARCHAR(50),
									[Detail]					NVARCHAR(MAX),
									[CreateDate]				BIGINT,
									[IsGroup]					BIT,
									[IsActive]					BIT,
									[OrganizationId]			VARCHAR(50),
									[GMExaminationId]			VARCHAR(50),
									[DateCompleted]				BIGINT,
									[CustomerId]				VARCHAR(50),
									[IsPaid]					BIT,
									[TotalAmount]				DECIMAL(18,2),
									[WasFinishedExamination]	BIT,
									[CustomerFirstName]			NVARCHAR(30),
									[CustomerLastName]			NVARCHAR(70),
									[ReasonToExamination]		NVARCHAR(100),
									[MedicalHistory]			NVARCHAR(2000)
								)
	SET @Message = 'Lỗi không xác định, hãy liên lạc với Quản trị hệ thống'
	INSERT INTO @MedicalRecord EXEC [sp_GetMedicalRecordById] @MedicalRecordId
	SET @Detail = CASE WHEN TRIM(@Detail) = '' THEN NULL ELSE @Detail END
	SET @CreateDate = CASE WHEN @CreateDate = 0 THEN NULL ELSE @CreateDate END
	SET @OrganizationId = CASE WHEN TRIM(@OrganizationId) = '' THEN NULL ELSE @OrganizationId END
	SET @GMExaminationId = CASE WHEN TRIM(@GMExaminationId) = '' THEN NULL ELSE @GMExaminationId END
	SET @DateCompleted = CASE WHEN @DateCompleted = 0 THEN NULL ELSE @DateCompleted END
	SET @CustomerId = CASE WHEN TRIM(@CustomerId) = '' THEN NULL ELSE @CustomerId END
	SET @TotalAmount = CASE WHEN @TotalAmount = 0 THEN NULL ELSE @TotalAmount END
	SET @CustomerFirstName = CASE WHEN TRIM(@CustomerFirstName) = '' THEN NULL ELSE @CustomerFirstName END
	SET @CustomerLastName = CASE WHEN TRIM(@CustomerLastName) = '' THEN NULL ELSE @CustomerLastName END 
	SET @ReasonToExamination = CASE WHEN TRIM(@ReasonToExamination) = '' THEN NULL ELSE @ReasonToExamination END
	SET @MedicalHistory = CASE WHEN TRIM(@MedicalHistory) = '' THEN NULL ELSE @MedicalHistory END

	BEGIN TRAN
	BEGIN TRY
		IF EXISTS (SELECT TOP 1 * FROM @MedicalRecord)
			BEGIN
				UPDATE MedicalRecords
					SET 	[Detail]					= @Detail,
							[CreateDate]				= @CreateDate,
							[IsGroup]					= @IsGroup,
							[IsActive]					= @IsActive,
							[OrganizationId]			= @OrganizationId,
							[GMExaminationId]			= @GMExaminationId,
							[DateCompleted]				= @DateCompleted,
							[CustomerId]				= @CustomerId,
							[IsPaid]					= @IsPaid,
							[TotalAmount]				= @TotalAmount,
							[WasFinishedExamination]	= @WasFinishedExamination,
							[CustomerFirstName]			= @CustomerFirstName,
							[CustomerLastName]			= @CustomerLastName,
							[MedicalHistory]			= @MedicalHistory,
							[ReasonToExamination]		= @ReasonToExamination
				WHERE MedicalRecordId = @MedicalRecordId
				SET @Message = 'Hồ sơ bệnh án đã được cập nhật'
			END
		ELSE
			BEGIN
				SET @MedicalRecordId = ''
				SET @Message = 'Hồ sơ bệnh án không tồn tại'
			END
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		SET @MedicalRecordId = ''
		ROLLBACK TRAN
	END CATCH

	SELECT TOP 1 * FROM @MedicalRecord
END
GO
