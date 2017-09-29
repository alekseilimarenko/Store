

declare @tmp table (id int, Shortname nvarchar(50), workfrom datetime, workto datetime,
                 intervalfrom datetime,  intervalto datetime )
insert into @tmp (id, Shortname, workfrom, workto,
                 intervalfrom,  intervalto )
select	WorkTime.id,
    ShortName = (select case when  DayNames.id < 5 then 'пн-чт'
	                         when  DayNames.id < 6 then 'пт' else Short_name end 
		            from dbo.pn_daynames as DayNames
					where WorkTime.dayofweek = DayNames.id),
		WorkTime.workfrom, WorkTime.workto, WorkTime.intervalfrom, WorkTime.intervalto 
from dbo.routine as WorkTime
where WorkTime.id = 4052
select * from @tmp
group by ID, ShortName, workfrom,  workto, intervalfrom, intervalto

USE [Store]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[GetSchedule]
		@Id = 4050

SELECT	@return_value as 'Return Value'

GO
