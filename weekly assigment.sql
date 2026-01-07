CREATE TABLE CLIENT_MASTER (
    CLIENTNO VARCHAR(6)
    CONSTRAINT PK_CLIENT PRIMARY KEY
    CONSTRAINT CK_CLIENTNO CHECK (CLIENTNO LIKE 'C%'),
    NAME  VARCHAR(20) NOT NULL,
    ADDRESS1 VARCHAR(30),
    ADDRESS2 VARCHAR(30),
    CITY VARCHAR(15),
    PINCODE int,
    STATE VARCHAR(15),
    BALDUE decimal(10,2)
);

CREATE TABLE PRODUCT_MASTER (
    PRODUCTNO   VARCHAR(6)
    CONSTRAINT PK_PRODUCT PRIMARY KEY
    CONSTRAINT CK_PRODUCTNO CHECK (PRODUCTNO LIKE 'P%'),
    DESCRIPTION VARCHAR(15) NOT NULL,
    PROFITPERC  decimal(4,2) NOT NULL,
    UNITMEASURE VARCHAR(10) NOT NULL,
    QTYONHAND   decimal(8) NOT NULL,
    REORDERLVL  decimal(8) NOT NULL,
    SELLPRICE  decimal(8,2) NOT NULL
    CONSTRAINT CK_SELLPRICE CHECK (SELLPRICE <> 0),
    COSTPRICE  decimal(8,2) NOT NULL
    CONSTRAINT CK_COSTPRICE CHECK (COSTPRICE <> 0)
);

CREATE TABLE SALESMAN_MASTER (
    SALESMANNO   VARCHAR(6)
    CONSTRAINT PK_SALESMAN PRIMARY KEY
    CONSTRAINT CK_SALESMANNO CHECK (SALESMANNO LIKE 'S%'),
    SALESMANNAME VARCHAR(20) NOT NULL,
    ADDRESS1 VARCHAR(30) NOT NULL,
    ADDRESS2 VARCHAR(30),
    CITY VARCHAR(20),
    PINCODE      int,
    STATE VARCHAR(20),
    SALAMT decimal(8,2) NOT NULL
    CONSTRAINT CK_SALAMT CHECK (SALAMT <> 0),
    TGTTOGET     decimal(6,2) NOT NULL,
    YTDSALES     decimal(6,2) NOT NULL,
    REMARKS      VARCHAR(60)
);

CREATE TABLE SALES_ORDER (
    ORDERNO VARCHAR(6) PRIMARY KEY
    CHECK (ORDERNO LIKE 'O%'),
    CLIENTNO VARCHAR(6),
    ORDERDATE DATE,
    DELYADDR VARCHAR(25),
    SALESMANNO VARCHAR(6),
    DELYTYPE CHAR(1)
    CHECK (DELYTYPE IN ('P','F')),
    BILLEDYN CHAR(1)
    CHECK (BILLEDYN IN ('Y','N')),
    DELYDATE DATE,
    ORDERSTATUS VARCHAR(10)
    CHECK (ORDERSTATUS IN ('In Process','Fulfilled','Backorder','Cancelled')),
    FOREIGN KEY (CLIENTNO) REFERENCES CLIENT_MASTER(CLIENTNO),
    FOREIGN KEY (SALESMANNO) REFERENCES SALESMAN_MASTER(SALESMANNO)
);

CREATE TABLE SALES_ORDER_DETAILS (
    ORDERNO VARCHAR(6),
    PRODUCTNO VARCHAR(6),
    QTYORDERED  INT,
    QTYDISP INT,
    PRODUCTRATE DECIMAL,
    PRIMARY KEY (ORDERNO, PRODUCTNO),
    FOREIGN KEY (ORDERNO) REFERENCES SALES_ORDER(ORDERNO),
    FOREIGN KEY (PRODUCTNO) REFERENCES PRODUCT_MASTER(PRODUCTNO)
);

INSERT INTO CLIENT_MASTER VALUES 
('C00001', 'Ivan Bayross', 'A/14 Worli', 'Near Park', 'Mumbai', 400054, 'Maharashtra', 15000),
('C00002', 'Sanjay Mehta', 'B/10 Connaught', 'Block A', 'Delhi', 110001, 'Delhi', 12000),
('C00003', 'Nisha Kaur', 'C/22 FC Road', 'Opp Mall', 'Pune', 411001, 'Maharashtra', 9000),
('C00004', 'Rohit Sharma', 'D/50 MG Road', 'HSR Layout', 'Bangalore', 560001, 'Karnataka', 18000),
('C00005', 'Aarti Shah', 'E/5 Anna Nagar', '2nd Street', 'Chennai', 600001, 'Tamil Nadu', 14000);

INSERT INTO PRODUCT_MASTER VALUES
('P00001', 'T-Shirt', 5.5, 'Piece', 200, 50, 350.00, 250.00),
('P00002', 'Jeans', 8.0, 'Piece', 150, 40, 900.00, 700.00),
('P00003', 'Trousers', 6.0, 'Piece', 300, 60, 750.00, 500.00),
('P00004', 'Pull Overs', 7.5, 'Piece', 100, 30, 1100.00, 850.00),
('P00005', '1.44 MB Drive', 4.5, 'Piece', 50, 20, 1500.00, 1200.00);
INSERT INTO SALESMAN_MASTER VALUES
('S00001', 'Aman', 'A/14', 'Worli', 'Mumbai', 400002, 'Maharashtra', 3000.00, 100.00, 50.00, 'Good'),
('S00002', 'Ravi Kumar', 'B/22', 'Andheri', 'Mumbai', 400053, 'Maharashtra', 5000.00, 150.00, 80.00, 'Average'),
('S00003', 'Sneha Iyer', 'C/10', 'Baner', 'Pune', 411045, 'Maharashtra', 4500.00, 120.00, 90.00, 'Excellent'),
('S00004', 'Vikas Rao', 'D/18', 'HSR', 'Bangalore', 560102, 'Karnataka', 3500.00, 80.00, 60.00, 'Good'),
('S00005', 'Neha Singh', 'E/55', 'T Nagar', 'Chennai', 600017, 'Tamil Nadu', 3200.00, 90.00, 70.00, 'Very Good');
INSERT INTO SALES_ORDER VALUES
('O19001', 'C00001', '2002-07-12', 'Mumbai', 'S00001', 'F', 'N', '2002-07-20', 'In Process'),
('O19002', 'C00002', '2002-08-10', 'Delhi', 'S00002', 'P', 'Y', '2002-08-15', 'Fulfilled'),
('O19003', 'C00003', '2002-09-05', 'Pune', 'S00003', 'F', 'N', '2002-09-12', 'Backorder'),
('O19004', 'C00004', '2002-07-22', 'Bangalore', 'S00004', 'P', 'Y', '2002-07-28', 'Cancelled'),
('O19005', 'C00005', '2002-10-02', 'Chennai', 'S00005', 'F', 'N', '2002-10-10', 'In Process');
INSERT INTO SALES_ORDER_DETAILS VALUES
('O19001', 'P00001', 10, 8, 350.00),
('O19001', 'P00003', 5, 5, 750.00),
('O19002', 'P00004', 3, 3, 1100.00),
('O19003', 'P00003', 7, 6, 750.00),
('O19005', 'P00004', 2, 1, 1100.00);
--selects
select name from CLIENT_MASTER;
select name from CLIENT_MASTER where CITY='Mumbai';
SELECT * from product_master where sellprice > 2000 AND sellprice < 5000;

SELECT name, city, state
FROM client_master
WHERE state !='Maharashtra';

SELECT * from client_master where clientno IN ('C0001','C0002');
UPDATE product_master set sellprice = 1150.50 where description = '1.44 MB Drive';
select * from PRODUCT_MASTER;
DELETE FROM client_master WHERE clientno = 'C0005';

SELECT * from client_master where city LIKE '_a%';

SELECT COUNT(*) AS product_count from product_master where sellprice >= 1500;

SELECT qtyordered,qtydisp,(qtyordered - qtydisp) AS balancedqty from sales_order_details;
--2
ALTER TABLE client_master ADD CONSTRAINT pk_clientno PRIMARY KEY (clientno);

alter table client_master add phone_no varchar(30);
select * from CLIENT_MASTER;

ALTER TABLE product_master ALTER COLUMN description varcahr(15) NOT NULL;
ALTER TABLE product_mastern ALTER COLUMN profitperc DECIMAL(4,2) NOT NULL;
ALTER TABLE product_master ALTER COLUMN sellprice DECIMAL(8,2) NOT NULL;
ALTER TABLE product_master ALTER COLUMN costprice DECIMAL(8,2) NOT NULL;

ALTER TABLE client_master ALTER COLUMN name varchar(60);
ALTER TABLE client_master DROP COLUMN pincode;
--joins:
select distinct  p.description from CLIENT_MASTER c
join  sales_order s
  ON c.clientno = s.clientno
join SALES_ORDER_DETAILS sd on sd.ORDERNO=s.ORDERNO
join product_master p
 ON sd.productno = p.productno
 where c.NAME='Ivan Bayross';

select  p.description,sd.qtyordered from SALES_ORDER s 
join sales_order_details sd on s.orderno=sd.orderno 
join PRODUCT_MASTER p on p.PRODUCTNO=sd.productno
where MONTH(s.ORDERDATE)=MONTH(getdate());

select p.PRODUCTNO,P.description from PRODUCT_MASTER p
join SALES_ORDER_DETAILS sd on sd.PRODUCTNO=p.PRODUCTNO
group by p.PRODUCTNO,p.DESCRIPTION 
having count(sd.ORDERNO)>1;

select c.NAME from CLIENT_MASTER c
join SALES_ORDER s on s.CLIENTNO=c.CLIENTNO
join SALES_ORDER_DETAILS sd on sd.ORDERNO=s.ORDERNO
join PRODUCT_MASTER p on p.PRODUCTNO=sd.PRODUCTNO
where p.DESCRIPTION='Trousers';

select s.orderno,p.productno,p.description,sd.qtyordered from sales_order s
join SALES_ORDER_DETAILS sd on sd.ORDERNO=s.ORDERNO
join PRODUCT_MASTER p on p.PRODUCTNO=sd.PRODUCTNO
where p.DESCRIPTION='Pull Overs' and sd.QTYORDERED<5;

--subquery

select productno,description
from PRODUCT_MASTER
where PRODUCTNO not in(select PRODUCTNO from SALES_ORDER_DETAILS);

select name,address1,address2,city,state from client_master
where clientno = (select clientno from sales_order where orderno='O19001');

select name from client_master where clientno IN (select clientno from sales_order where orderdate<'2002-05-01');
--genaral
select datename(weekday,'2012-02-11')+','+
datename(month,'2012-02-11')+','+
cast(day('2012-02-11') as varchar) +','+
cast(year('2012-02-11') as varchar) as system_date;

select format(baldue,'$99,999.99') as balance_due from client_master;

select 'Salesman Aman sold goods of 50 while given target was 100.' as message;

select datediff(year,'2005-04-11',GETDATE()) as age;


