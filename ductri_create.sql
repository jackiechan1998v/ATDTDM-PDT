-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2020-12-04 14:31:51.611
create database ductri1
use ductri1
go
-- tables
-- Table: Detail_HD
CREATE TABLE Detail_HD (
    SoHD char(255)  NOT NULL,
    MASP char(255)  NOT NULL,
    SL int  NOT NULL,
    CONSTRAINT Detail_HD_pk PRIMARY KEY  (SoHD)
);

-- Table: Hoadon
CREATE TABLE Hoadon (
    SoHD char(255)  NOT NULL,
    MAKH int  NOT NULL,
    Ngaymua date  NOT NULL,
    CONSTRAINT Hoadon_pk PRIMARY KEY  (SoHD)
);

-- Table: Khachhang
CREATE TABLE Khachhang (
    MAKH int  NOT NULL,
    TENKH varchar(255)  NOT NULL,
    Address varchar(255)  NOT NULL,
    Phone int  NOT NULL,
    Email varchar(255)  NOT NULL,
    CONSTRAINT Khachhang_pk PRIMARY KEY  (MAKH)
);

-- Table: Loaisanpham
CREATE TABLE Loaisanpham (
    MALOAI char(255)  NOT NULL,
    TENLOAI varchar(255)  NOT NULL,
    CONSTRAINT Loaisanpham_pk PRIMARY KEY  (MALOAI)
);

-- Table: Sanpham
CREATE TABLE Sanpham (
    MASP char(255)  NOT NULL,
    TENSP varchar(255)  NOT NULL,
    GIA int  NOT NULL,
    MALOAI char(255)  NOT NULL,
    CONSTRAINT Sanpham_pk PRIMARY KEY  (MASP)
);

-- foreign keys
-- Reference: Detail_HD_Hoadon (table: Detail_HD)
ALTER TABLE Detail_HD ADD CONSTRAINT Detail_HD_Hoadon
    FOREIGN KEY (SoHD)
    REFERENCES Hoadon (SoHD);

-- Reference: Detail_HD_Sanpham (table: Detail_HD)
ALTER TABLE Detail_HD ADD CONSTRAINT Detail_HD_Sanpham
    FOREIGN KEY (MASP)
    REFERENCES Sanpham (MASP);

-- Reference: Hoadon_Khachhang (table: Hoadon)
ALTER TABLE Hoadon ADD CONSTRAINT Hoadon_Khachhang
    FOREIGN KEY (MAKH)
    REFERENCES Khachhang (MAKH);

-- Reference: Sanpham_Loaisanpham (table: Sanpham)
ALTER TABLE Sanpham ADD CONSTRAINT Sanpham_Loaisanpham
    FOREIGN KEY (MALOAI)
    REFERENCES Loaisanpham (MALOAI);

-- End of file.

INSERT INTO Khachhang VALUES('001','Phan Duc Tri','17A Cong Hoa','0123456789','phanductri@at13.vn');
INSERT INTO Khachhang VALUES('002','Nguyen Trung Hieu','17A Cong Hoa','0123456789','nguyentrunghieu@at13.vn');
INSERT INTO Khachhang VALUES('003','Ho Van Diem','17A Cong Hoa','0123456789','hovandiem@at13.vn');
INSERT INTO Khachhang VALUES('004','Duong Thi Huyen Trang','17A Cong Hoa','0123456789','duongthihuyentrang@at13.vn');
INSERT INTO Khachhang VALUES('005','Nguyen Kien Cuong','17A Cong Hoa','0123456789','nguyenkiencuong@at13.vn');
INSERT INTO Detail_HD VALUES('HD01','A01','20');
INSERT INTO Detail_HD VALUES('HD02','A03','30');
INSERT INTO Detail_HD VALUES('HD03','B01','20');
INSERT INTO Detail_HD VALUES('HD04','N01','10');
INSERT INTO Detail_HD VALUES('HD05','G01','15');
INSERT INTO Hoadon VALUES('HD01','001','11/29/2020');
INSERT INTO Hoadon VALUES('HD02','002','11/29/2020');
INSERT INTO Hoadon VALUES('HD03','003','12/1/2020');
INSERT INTO Hoadon VALUES('HD04','004','12/2/2020');
INSERT INTO Hoadon VALUES('HD05','005','12/1/2020');
INSERT INTO Loaisanpham VALUES('L01','Ao');
INSERT INTO Loaisanpham VALUES('L02','Quan');
INSERT INTO Loaisanpham VALUES('L03','Giay');
INSERT INTO Loaisanpham VALUES('L04','Non');
INSERT INTO Loaisanpham VALUES('L05','Balo');

INSERT INTO Sanpham VALUES('A01','Ao somi tay dai','250','L01');
INSERT INTO Sanpham VALUES('A02','Ao somi tay ngan','240','L01');
INSERT INTO Sanpham VALUES('A03','Ao somi body','200','L01');


INSERT INTO Sanpham VALUES('Q01','Quan dai','200','L02');
INSERT INTO Sanpham VALUES('Q02','Quan ngan','250','L02');
INSERT INTO Sanpham VALUES('Q03','Quan tay','300','L02');

INSERT INTO Sanpham VALUES('G01','giay bata','200','L03');


INSERT INTO Sanpham VALUES('N01','Non luoi trai','200','L04');
INSERT INTO Sanpham VALUES('N02','Non tai beo','200','L04');


INSERT INTO Sanpham VALUES('B01','balo yami','200','L05');
INSERT INTO Sanpham VALUES('B02','Balo chelsea','200','L05');
