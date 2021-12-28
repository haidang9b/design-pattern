-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2021 at 04:41 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quanlycuahang`
--
CREATE DATABASE IF NOT EXISTS `quanlycuahang` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `quanlycuahang`;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `ID` int(11) NOT NULL,
  `USERNAME` char(50) NOT NULL,
  `PASSWORD` char(200) DEFAULT NULL,
  `TYPE` int(11) NOT NULL DEFAULT 0,
  `FULLNAME` varchar(100) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`ID`, `USERNAME`, `PASSWORD`, `TYPE`, `FULLNAME`) VALUES
(1, 'admin', '123456', 0, 'Quản lý 1'),
(5, 'user1', '1234', 1, 'Người dùng 1');

-- --------------------------------------------------------

--
-- Stand-in structure for view `billview`
-- (See below for the actual view)
--
CREATE TABLE `billview` (
`MAHD` int(11)
,`TENKH` varchar(50)
,`SDTKH` char(11)
,`TGMUA` date
,`TONGTIEN` int(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `chitiethoadon`
--

CREATE TABLE `chitiethoadon` (
  `ID` int(11) NOT NULL,
  `MAHD` int(11) DEFAULT NULL,
  `MASP` int(11) DEFAULT NULL,
  `SL` int(11) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `chitiethoadon`
--

INSERT INTO `chitiethoadon` (`ID`, `MAHD`, `MASP`, `SL`) VALUES
(1, 1, 1, 11),
(2, 1, 3, 1),
(3, 2, 5, 6),
(4, 3, 5, 2),
(5, 4, 5, 4),
(6, 4, 3, 4),
(7, 5, 5, 2),
(8, 6, 3, 4),
(9, 6, 5, 8),
(10, 6, 2, 4),
(11, 7, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `hoadon`
--

CREATE TABLE `hoadon` (
  `MAHD` int(11) NOT NULL,
  `MAKH` int(11) NOT NULL,
  `NVBAN` varchar(200) DEFAULT NULL,
  `TGMUA` date NOT NULL DEFAULT current_timestamp(3),
  `TONGTIEN` int(11) DEFAULT NULL,
  `STATUS` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `hoadon`
--

INSERT INTO `hoadon` (`MAHD`, `MAKH`, `NVBAN`, `TGMUA`, `TONGTIEN`, `STATUS`) VALUES
(1, 1, 'Quản lý 1', '2021-12-03', 4444, 1),
(2, 2, 'Quản lý 1', '2021-12-03', 88915632, 1),
(3, 1, 'Quản lý 1', '2021-12-03', 4444, 1),
(4, 3, 'Quản lý 1', '2021-12-03', 22224242, 1),
(5, 1, 'Quản lý 1', '2021-12-08', 4444, 1),
(6, 2, 'Quản lý 1', '2021-12-26', 88915632, 1),
(7, 3, 'Quản lý 1', '2021-12-27', 22224242, 1);

-- --------------------------------------------------------

--
-- Table structure for table `khachhang`
--

CREATE TABLE `khachhang` (
  `MAKH` int(11) NOT NULL,
  `TENKH` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `SDTKH` char(11) DEFAULT NULL,
  `DIACHI` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `TONGTIEN` int(11) DEFAULT 0,
  `email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `khachhang`
--

INSERT INTO `khachhang` (`MAKH`, `TENKH`, `SDTKH`, `DIACHI`, `TONGTIEN`, `email`) VALUES
(1, 'Tôny Hải Đăng', '0326889240', 'Quân 7', 11310, 'linhhaiyen1182@gmail.com '),
(2, 'Tôny Hải Đăng', '0326889240', 'Quân 7', 88928964, 'cunkul35@gmail.com'),
(3, 'TOnny Đăng', '0326555555', 'aaaaa', 22234018, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `loaisp`
--

CREATE TABLE `loaisp` (
  `MALOAI` int(11) NOT NULL,
  `TENLOAI` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `loaisp`
--

INSERT INTO `loaisp` (`MALOAI`, `TENLOAI`) VALUES
(1, 'Loại 1'),
(2, 'Loại 2'),
(3, 'Loại 3');

-- --------------------------------------------------------

--
-- Table structure for table `sanpham`
--

CREATE TABLE `sanpham` (
  `MASP` int(11) NOT NULL,
  `TENSP` varchar(100) DEFAULT NULL,
  `LOAISP` int(11) NOT NULL,
  `SOLUONGTON` int(11) DEFAULT NULL,
  `DONGIA` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sanpham`
--

INSERT INTO `sanpham` (`MASP`, `TENSP`, `LOAISP`, `SOLUONGTON`, `DONGIA`) VALUES
(1, 'Sản phẩm 1222', 3, 999, 999999),
(2, 'Sản phẩm 1', 2, 23223227, 22224242),
(3, 'Sản phẩm 1222', 2, 217, 222),
(5, 'assddd', 2, 99991, 2222);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewbillinfo`
-- (See below for the actual view)
--
CREATE TABLE `viewbillinfo` (
`TENSP` varchar(100)
,`SL` int(11)
,`DONGIA` int(11)
,`TONGGIA` bigint(21)
);

-- --------------------------------------------------------

--
-- Structure for view `billview`
--
DROP TABLE IF EXISTS `billview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `billview`  AS SELECT `hd`.`MAHD` AS `MAHD`, `kh`.`TENKH` AS `TENKH`, `kh`.`SDTKH` AS `SDTKH`, `hd`.`TGMUA` AS `TGMUA`, `hd`.`TONGTIEN` AS `TONGTIEN` FROM (`hoadon` `hd` join `khachhang` `kh` on(`kh`.`MAKH` = `hd`.`MAKH`)) ;

-- --------------------------------------------------------

--
-- Structure for view `viewbillinfo`
--
DROP TABLE IF EXISTS `viewbillinfo`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewbillinfo`  AS SELECT `sanpham`.`TENSP` AS `TENSP`, `ct`.`SL` AS `SL`, `sanpham`.`DONGIA` AS `DONGIA`, cast(`sanpham`.`DONGIA` * `ct`.`SL` as signed) AS `TONGGIA` FROM (((`chitiethoadon` `ct` join `sanpham` on(`sanpham`.`MASP` = `ct`.`MASP`)) join `hoadon` on(`hoadon`.`MAHD` = `ct`.`MAHD`)) join `khachhang` on(`hoadon`.`MAKH` = `khachhang`.`MAKH`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `MAHD` (`MAHD`),
  ADD KEY `MASP` (`MASP`);

--
-- Indexes for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MAHD`),
  ADD KEY `MAKH` (`MAKH`);

--
-- Indexes for table `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MAKH`);

--
-- Indexes for table `loaisp`
--
ALTER TABLE `loaisp`
  ADD PRIMARY KEY (`MALOAI`),
  ADD UNIQUE KEY `MALOAI` (`MALOAI`);

--
-- Indexes for table `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MASP`),
  ADD KEY `LOAISP` (`LOAISP`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `MAHD` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `MAKH` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `loaisp`
--
ALTER TABLE `loaisp`
  MODIFY `MALOAI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MASP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD CONSTRAINT `chitiethoadon_ibfk_1` FOREIGN KEY (`MAHD`) REFERENCES `hoadon` (`MAHD`),
  ADD CONSTRAINT `chitiethoadon_ibfk_2` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`);

--
-- Constraints for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MAKH`) REFERENCES `khachhang` (`MAKH`);

--
-- Constraints for table `sanpham`
--
ALTER TABLE `sanpham`
  ADD CONSTRAINT `sanpham_ibfk_1` FOREIGN KEY (`LOAISP`) REFERENCES `loaisp` (`MALOAI`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;