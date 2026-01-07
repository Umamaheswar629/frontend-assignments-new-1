create table Customer (
    CustomerID int primary key,
    CustomerName varchar(50),
    City varchar(30)
);

create table Product (
    ProductID int primary key,
    ProductName varchar(50),
    Price int
);

create table Orders (
    OrderID int primary key,
    CustomerID int,
    ProductID int,
    Quantity int,

    constraint fk_customer
        foreign key (CustomerID)
        references Customer(CustomerID),

    constraint fk_product
        foreign key (ProductID)
        references Product(ProductID)
);

insert into Customer values
(1, 'Amit', 'Delhi'),
(2, 'Neha', 'Mumbai'),
(3, 'Rohit', 'Pune'),
(4, 'Karan', 'Delhi');

insert into Product values
(101, 'Laptop', 40000),
(102, 'Mobile', 15000),
(103, 'Headphones', 3000),
(104, 'Keyboard', 2000);

insert into Orders values
(1, 1, 103, 2),
(2, 1, 104, 1),
(3, 2, 102, 1),
(4, 2, 103, 2),
(5, 3, 104, 2),
(6, 4, 101, 1);

select c.customerid,c.customername,
sum(p.price*o.Quantity) as total
from customer c
join orders o on o.CustomerID=c.CustomerID
join Product p on p.ProductID=p.ProductID
group by c.CustomerID,c.CustomerName;

select c.customerid,c.customername,
sum(p.price*o.Quantity) as total,
CASE
    when sum(p.price*o.Quantity)<10000 then 'Regular'
    when sum(p.price*o.Quantity) between 10000 and 25000 then 'Silver'
    else 'Gold'
end as catogery
from customer c
join orders o on o.CustomerID=c.CustomerID
join Product p on p.ProductID=o.ProductID
group by c.CustomerID,c.CustomerName;




