--Start a transaction
--Begin transaction

-- Remove data from the db
	Delete from reservation
	Delete from site
	Delete from campground
	Delete from park
	
-- Insert some test parks
insert into park (name, location, establish_date, area, visitors, description)
values ('Test Park1', 'Nowhere', '1900-01-01', 20000, 1000, 'A Park That Is Nowhere')
declare @TestParkId1 int
Select @TestParkId1 = @@IDENTITY

insert into park (name, location, establish_date, area, visitors, description)
values ('Test Park2', 'Somewhere', '1901-12-12', 40000, 10000, 'A Park That Is Somewhere')
declare @TestParkId2 int
Select @TestParkId2 = @@IDENTITY

-- Insert some test campground
insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)
values (@TestParkId1, 'Whatever1', 1, 12, 35.00)
declare @TestCampground1 int
Select @TestCampground1 = @@IDENTITY

insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)
values (@TestParkId2, 'Whatever3', 4, 6, 100.00)
declare @TestCampground2 int
Select @TestCampground2 = @@IDENTITY


-- Insert some sites
insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
values (@TestCampground1, 12, 10, 1, 20, 1)
declare @TestSite1 int 
Select @TestSite1 = @@IDENTITY

insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
values (@TestCampground2, 5, 16, 0, 25, 0)
declare @TestSite2 int 
Select @TestSite2 = @@IDENTITY


--Insert some reservations
insert into reservation (site_id, name, from_date, to_date, create_date)
values (@TestSite1, 'TestFamilyZ', '2020-06-06', '2020-06-08', GETDATE())
declare @TestReservation1 int
Select @TestReservation1 = @@IDENTITY

insert into reservation (site_id, name, from_date, to_date, create_date)
values (@TestSite2, 'TestFamilyA', '2020-07-06', '2020-08-08', GETDATE())
declare @TestReservation2 int
Select @TestReservation2 = @@IDENTITY



-- For now, run some queries to show our test data
--select * from park
--select * from campground
--select * from site
--select * from reservation

--Return some data to the caller to be used during tresting
Select @TestParkId1 As TestParkId1, @TestParkId2 as TestParkId2, @TestCampground1 as TestCampground1, @TestCampground2 as TestCampground2,
@TestSite1 as TestSite1, @TestSite2 as TestSite2, @TestReservation1 as TestReservation1, @TestReservation2 as TestReservation2

-- Rollback transaction
--Rollback transaction