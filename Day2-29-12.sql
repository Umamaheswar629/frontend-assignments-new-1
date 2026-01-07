
create table Customers(CustomerID int primary key,FirstName text,LastName text,DateOfBirth date,Phone varchar(20),Email varchar(20));
select * from Customers;
create table Policies (
    PolicyID int primary key,
    PolicyName varchar(50) not null,
    PolicyType varchar(20) not null,
    PremiumAmount decimal(10,2) not null,
    DurationYears int check (DurationYears > 0)
);
create table Agents (
    AgentID int primary key,
    AgentName varchar(50) not null,
    Phone varchar(20) not null,
    City varchar(50) not null
);


create table PolicyAssignments (
    AssignmentID int primary key,
    CustomerID int,
    PolicyID int,
    AgentID int,
    StartDate date,
    EndDate date,

    constraint fk_customer
        foreign key (CustomerID)
        references Customers(CustomerID),

    constraint fk_policy
        foreign key (PolicyID)
        references Policies(PolicyID),
    constraint fk_agentid
        foreign key (AgentID)
        references Agents(AgentID)
);
create table Claims (
    ClaimID int primary key,
    AssignmentID int,
    ClaimDate date,
    ClaimAmount money,
    ClaimStatus varchar(50),

    constraint fk_assignments
        foreign key (AssignmentID)
        references PolicyAssignments(AssignmentID)
);


--Insertion Customers--
insert into Customers (customerID, FirstName, LastName, DateOfBirth, phone, Email)
values
(1,'Ravi','Kumar','1995-04-12','9876543210','ravi@gmail.com'),
(2,'Anita','Sharma','1992-09-23','9123456780','anita@yahoo.com'),
(3,'Suresh','Reddy','1988-01-15','9988776655','suresh@outlook'),
(4,'Priya','Verma','1997-06-30','9090909090','priya@gmail.com'),
(5,'Amit','Patel','1990-11-05','9567891234','amit@gmail.com');
select * from customers;


--Insertion into policies---
insert into policies (policyid, policyname, policytype, premiumamount, durationyears)
values
(201, 'LifeSecure', 'Life', 50000, 20),
(202, 'HealthPlus', 'Health', 30000, 10),
(203, 'CarProtect', 'Vehicle', 15000, 5),
(204, 'HomeShield', 'Property', 40000, 15),
(205, 'TravelSafe', 'Travel', 10000, 2);

--Insertion into agents--
insert into agents (agentid, agentname, phone, city)
values
(1, 'RahulSharma', '9876543210', 'Delhi'),
(2, 'AnitaVerma', '9123456789', 'Mumbai'),
(3, 'SureshReddy', '9988776655', 'Hyderabad'),
(4, 'PriyaPatel', '9090909090', 'Ahmedabad'),
(5, 'AmitKumar', '9567891234', 'Bangalore');


--insertion into policyAssignments---
insert into policyassignments
(assignmentid, customerid, policyid, agentid, startdate, enddate)
values
(1, 1, 201, 1, '2023-01-01', '2043-01-01'),
(2, 2, 202, 2, '2022-06-15', '2032-06-15'),
(3, 3, 203, 3, '2021-03-10', '2026-03-10'),
(4, 4, 204, 4, '2020-09-05', '2035-09-05'),
(5, 5, 205, 5, '2024-01-20', '2026-01-20');
select * from PolicyAssignments;

--Insertion to claims---
insert into claims
(claimid,AssignmentID, claimdate, claimamount, claimstatus)
values
(1, 1, '2024-02-10', 15000, 'Approved'),
(2, 2, '2023-08-05', 20000, 'Pending'),
(3, 3, '2022-11-18', 12000, 'Rejected'),
(4, 4, '2024-01-25', 30000, 'Approved'),
(5, 5, '2024-06-12', 8000, 'Pending');
select* from Policies where PremiumAmount=(select max(PremiumAmount) from Policies);



select c.customerid,c.firstname,c.lastname,p.policytype
from customers c
join PolicyAssignments pa on pa.customerid=c.customerid
join Policies as p on p.policyid=pa.PolicyID
where policytype is null;

select p.policyid,p.policyname,p.policytype,p.premiumamount,p.durationyears,cl.claimamount from policies p
join PolicyAssignments pa on pa.policyid=p.policyid
join Claims cl on cl.AssignmentID=pa.AssignmentID;

--
select p.policytype,sum(cl.claimamount) as total
from Policies p
join PolicyAssignments pa on pa.PolicyID=p.PolicyID
join Claims cl on cl.AssignmentID=pa.AssignmentID
group by p.PolicyType;

select c.customerid,c.firstname,c.lastname,p.policyname,p.PremiumAmount from customers c
join PolicyAssignments pa  on pa.CustomerID=c.CustomerID
join Policies p on p.PolicyID=pa.PolicyID
where p.PremiumAmount>(select avg(PremiumAmount) from Policies;

--customer with no claims
select c.customerid,c.firstname,c.lastname
from customers c 
left join PolicyAssignments pa on pa.CustomerID=c.CustomerID
left join Claims cl on cl.AssignmentID=pa.AssignmentID
where cl.ClaimID is null;

--polcies taken by more than one customer
select p.policyid,p.policytype,p.policyname,
count(distinct pa.CustomerID) as custcount
from Policies p join PolicyAssignments pa on pa.PolicyID=p.PolicyID
group by p.policyid,p.PolicyName,p.PolicyType having count(distinct pa.CustomerID)>1;

--cust with maximum total premium
select top 1
    c.CustomerID,
    cast(c.FirstName as varchar(50)) + ' ' + cast(c.LastName as varchar(50)) as CustomerName,-- cast is used beacuse text in group by is not allowed
    sum(p.PremiumAmount) as TotalPremium
from Customers c
join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
join Policies p
    on pa.PolicyID = p.PolicyID
group by
    c.CustomerID,
    cast(c.FirstName as varchar(50)),
    cast(c.LastName as varchar(50))
order by TotalPremium desc;
--policies with no assignmnets




















select * from customers;
select CustomerID, PolicyId, StartDate,EndDate from policyassignments;
select * from policies where policytype='Health';
select * from policies where premiumamount>10000 and durationyears=1;
select distinct city from agents;
select * from policies where policytype='Health' or policytype='Motor';
select * from policies where policytype in ('Health','Motor');
select * from customers where DateOfBirth>='2001-01-01' and DateOfBirth<='2020-12-31';
select * from customers where DateOfBirth between '2001-01-01' and '2020-12-31';
select * from claims where claimstatus='Rejected';
select * from agents where city  like '_a%';
select max(claimamount) as max_amount,min(claimamount) as min_amount from claims;
select top 1 * from claims
order by claimdate desc;
update policies set premiumamount=premiumamount*1.10 where policytype='Health';
delete from policyassignments where enddate<getdate();
select count(*) as countOfRejected from claims where claimstatus='Rejected';
select
    PolicyID,
    PolicyName,
    PremiumAmount,
    round(PremiumAmount * 0.06, 2) as localTaxes,
    round(PremiumAmount + (PremiumAmount * 0.06), 2) as AmountWithTax,
    round(PremiumAmount / 12.0, 2) as MonthP
from Policies;
alter table customers add Address varchar(100),city varchar(50);
select * from customers;
alter table agents add DevelopmentOfficerId int;
select * from agents;
--joins
alter table agents add constraint fk_devofcId foreign key(DevelopmentOfficerId) references agents(agentid);
select p.PolicyID,p.PolicyName,pa.StartDate,pa.EndDate
from PolicyAssignments pa join Policies p on pa.PolicyID = p.PolicyID
where pa.CustomerID = 5;
select c.CustomerID,c.FirstName,c.LastName,p.PolicyID,p.PolicyName,p.PolicyType,p.PremiumAmount
from Customers c
join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
join Policies p
    on pa.PolicyID = p.PolicyID;

select cl.ClaimID, cl.ClaimDate,cl.ClaimAmount,cl.ClaimStatus,c.CustomerID,c.FirstName,c.LastName
from Claims cl
join PolicyAssignments pa
    on cl.AssignmentID = pa.AssignmentID
join Customers c
    on pa.CustomerID = c.CustomerID;

select c.FirstName, p.PolicyName, a.AgentName, pa.StartDate, pa.EndDate
from Customers c
join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
join Policies p
    on pa.PolicyID = p.PolicyID
join Agents a
    on pa.AgentID = a.AgentID;

select c.FirstName, p.PolicyName, cl.ClaimAmount, cl.ClaimStatus, cl.ClaimDate
from Claims cl
join PolicyAssignments pa
    on cl.AssignmentID = pa.AssignmentID
join Customers c
    on pa.CustomerID = c.CustomerID
join Policies p
    on pa.PolicyID = p.PolicyID;

select c.CustomerID, c.FirstName, c.LastName, p.PolicyID, p.PolicyName
from Customers c
left join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
left join Policies p
    on pa.PolicyID = p.PolicyID;

select c.CustomerID, c.FirstName, c.LastName
from Customers c
left join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
left join Claims cl
    on pa.AssignmentID = cl.AssignmentID
where cl.ClaimID is null;

select c.CustomerID,cast(c.FirstName as varchar(50)) + ' ' + cast(c.LastName as varchar(50)) as CustomerName,
    sum(cl.ClaimAmount) as TotalClaimAmount
from Customers c
join PolicyAssignments pa
    on c.CustomerID = pa.CustomerID
join Claims cl
    on pa.AssignmentID = cl.AssignmentID
group by
    c.CustomerID,
    cast(c.FirstName as varchar(50)),
    cast(c.LastName as varchar(50))
     having sum(cl.ClaimAmount) > 50000;

select a.AgentID,a.AgentName,count(pa.PolicyID) as PolicyCount
from Agents a
left join PolicyAssignments pa
    on a.AgentID = pa.AgentID
group by a.AgentID,a.AgentName;

