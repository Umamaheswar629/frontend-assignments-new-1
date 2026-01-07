CREATE TABLE air_passenger_profile (
    PROFILE_ID INT IDENTITY(1,1) PRIMARY KEY,
    PASSWORD VARCHAR(10) NOT NULL,
    FIRST_NAME VARCHAR(10) NOT NULL,
    LAST_NAME VARCHAR(10) NOT NULL,
    ADDRESS VARCHAR(100) NULL,
    MOBILE_NUMBER BIGINT NOT NULL,
    EMAIL_ID VARCHAR(30) NULL
);

INSERT INTO air_passenger_profile 
(PASSWORD, FIRST_NAME, LAST_NAME, ADDRESS, MOBILE_NUMBER, EMAIL_ID)
VALUES
('pass01','Rahul','Sharma','Delhi',9876543210,'rahul@gmail.com'),
('pass02','Anita','Verma','Mumbai',9876543211,'anita@gmail.com'),
('pass03','Suresh','Reddy','Hyderabad',9876543212,'suresh@gmail.com'),
('pass04','Priya','Singh','Chennai',9876543213,'priya@gmail.com'),
('pass05','Amit','Kumar','Bangalore',9876543214,'amit@gmail.com');

CREATE TABLE air_flight (
    FLIGHT_ID INT IDENTITY(1,1) PRIMARY KEY,
    AIRLINE_ID VARCHAR(10) NOT NULL,
    AIRLINE_NAME VARCHAR(30) NOT NULL,
    FROM_LOCATION VARCHAR(20) NOT NULL,
    TO_LOCATION VARCHAR(20) NOT NULL,
    DEPARTURE_TIME TIME NOT NULL,
    ARRIVAL_TIME TIME NOT NULL,
    DURATION TIME NULL,
    TOTAL_SEATS INT NOT NULL
);
INSERT INTO air_flight
(AIRLINE_ID, AIRLINE_NAME, FROM_LOCATION, TO_LOCATION,
 DEPARTURE_TIME, ARRIVAL_TIME, DURATION, TOTAL_SEATS)
VALUES
('AI01','Air India','Delhi','Mumbai','08:00','10:00','02:00',180),
('IN02','Indigo','Hyderabad','Chennai','09:30','10:45','01:15',150),
('SP03','SpiceJet','Bangalore','Delhi','06:00','08:45','02:45',160),
('VI04','Vistara','Mumbai','Kolkata','11:00','13:30','02:30',170),
('GO05','GoAir','Pune','Hyderabad','14:00','15:30','01:30',140);

CREATE TABLE air_flight_details (
    FLIGHT_DETAIL_ID INT IDENTITY(1,1) PRIMARY KEY,
    FLIGHT_ID INT NOT NULL,
    FLIGHT_DEPARTURE_DATE DATE NOT NULL,
    PRICE DECIMAL(8,2) NOT NULL,
    AVAILABLE_SEATS INT NULL,
    FOREIGN KEY (FLIGHT_ID) REFERENCES air_flight(FLIGHT_ID)
);
INSERT INTO air_flight_details
(FLIGHT_ID, FLIGHT_DEPARTURE_DATE, PRICE, AVAILABLE_SEATS)
VALUES
(1,'2025-01-10',5500,120),
(2,'2025-01-12',4200,100),
(3,'2025-01-15',6200,90),
(4,'2025-01-18',5800,110),
(5,'2025-01-20',4000,95);

CREATE TABLE air_ticket_info (
    TICKET_ID INT IDENTITY(1,1) PRIMARY KEY,
    PROFILE_ID INT NOT NULL,
    FLIGHT_ID INT NOT NULL,
    FLIGHT_DEPARTURE_DATE DATE NOT NULL,
    STATUS VARCHAR(10) NULL,
    FOREIGN KEY (PROFILE_ID) REFERENCES air_passenger_profile(PROFILE_ID),
    FOREIGN KEY (FLIGHT_ID) REFERENCES air_flight(FLIGHT_ID)
);
INSERT INTO air_ticket_info
(PROFILE_ID, FLIGHT_ID, FLIGHT_DEPARTURE_DATE, STATUS)
VALUES
(1,1,'2025-01-10','Booked'),
(2,2,'2025-01-12','Booked'),
(3,3,'2025-01-15','Cancelled'),
(4,4,'2025-01-18','Booked'),
(5,5,'2025-01-20','Booked');

CREATE TABLE air_credit_card_details (
    CARD_ID INT IDENTITY(1,1) PRIMARY KEY,
    PROFILE_ID INT NOT NULL,
    CARD_NUMBER BIGINT NOT NULL,
    CARD_TYPE VARCHAR(10) NOT NULL,
    EXPIRATION_MONTH INT NOT NULL,
    EXPIRATION_YEAR INT NOT NULL,
    FOREIGN KEY (PROFILE_ID) REFERENCES air_passenger_profile(PROFILE_ID)
);
INSERT INTO air_credit_card_details
(PROFILE_ID, CARD_NUMBER, CARD_TYPE, EXPIRATION_MONTH, EXPIRATION_YEAR)
VALUES
(1,4111222233334444,'VISA',12,2026),
(2,5111222233334445,'MASTER',11,2025),
(3,6111222233334446,'RUPAY',10,2027),
(4,7111222233334447,'VISA',9,2026),
(5,8111222233334448,'MASTER',8,2025);

---Queries--
select af.flight_id,af.from_location,af.to_location,datename(month, ati.flight_departure_date) as month_name,avg(afd.price) avg_price
from air_ticket_info ati join air_flight af on ati.FLIGHT_ID=af.FLIGHT_ID 
join air_flight_details afd on afd.FLIGHT_ID=af.FLIGHT_ID
group by af.FLIGHT_ID,af.FROM_LOCATION,af.TO_LOCATION,datename(month,ati.flight_departure_date),MONTH(ati.flight_departure_date)
order by af.FLIGHT_ID,MONTH(ati.flight_departure_date);


--1.2 and 1.4:
select ap.PROFILE_ID,ap.FIRST_NAME,ap.address,count(ati.ticket_id) as no_of_tic
from air_passenger_profile ap
join air_ticket_info ati  on ati.PROFILE_ID=ap.PROFILE_ID
group by ap.PROFILE_ID,ap.FIRST_NAME,ap.ADDRESS
having   count(ati.ticket_id) = (
        select max(ticket_count)
        from (
            select count(ticket_id) as ticket_count
            from air_ticket_info
            group by profile_id
        ) t
    )
    order by ap.FIRST_NAME;
--1.3:
select
    af.from_location,
    af.to_location,
    datename(month, ati.flight_departure_date) as month_name,
    count(ati.flight_departure_date) as no_of_services
from air_ticket_info ati
join air_flight af
    on ati.flight_id = af.flight_id
group by
    af.from_location,
    af.to_location,
    datename(month, ati.flight_departure_date),
    month(ati.flight_departure_date)
order by
    af.from_location asc,
    af.to_location asc,
    month(ati.flight_departure_date) asc;
--1.5:
select
    app.profile_id,
    app.first_name,
    app.last_name,
    af.flight_id,
    ati.flight_departure_date as departure_date,
    count(ati.ticket_id) as no_of_tickets
from air_ticket_info ati
join air_passenger_profile app
    on ati.profile_id = app.profile_id
join air_flight af
    on ati.flight_id = af.flight_id
where
    af.from_location = 'Chennai'
    and af.to_location = 'Hyderabad'
group by
    app.profile_id,
    app.first_name,
    app.last_name,
    af.flight_id,
    ati.flight_departure_date
order by
    app.profile_id asc,
    af.flight_id asc,
    ati.flight_departure_date asc;
