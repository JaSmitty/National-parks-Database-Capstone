Begin transaction

--Get all Parks
Select * 
from park
order by name

--Select park and get list of availible campgrounds
Select *
From campground
Join park on park.park_id = campground.park_id
Where park.park_id = 1

--Select campground by availibilty date
Select *
From campground
Join park on park.park_id = campground.park_id
Where park.park_id = 1 and campground.open_from_mm < 5 and campground.open_to_mm > 5

--Select all reservations availible  (if none are returned it is availible)
Select *
From Site
Join campground on site.campground_id = campground.campground_id
Join park on park.park_id = campground.park_id
Join reservation on reservation.site_id = site.site_id
Where from_date >= '2020-06-20' and to_date <= '2020-07-10' and site.site_id = 30

--

Rollback transaction