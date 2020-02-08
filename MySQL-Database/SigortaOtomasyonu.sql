create database if not exists `sigortaotomasyonu`;
create table if not exists `kullanicigiris`(
`kullanici_id` int not null auto_increment primary key,
`kullanici_adi` varchar(45) not null, 
`sifre` varchar(45) not null);
create table if not exists `sgt_tanim`(
`id` int not null auto_increment primary key,
`tanim_kodu` varchar(45) not null unique,
`tanim_aciklamasi` varchar(45),
`tanim_adi` varchar(45)
);
create table if not exists `sgt_tanimdetay`(
`id` int not null auto_increment primary key,
`tanim_id` int not null,
constraint `tanim_id` foreign key tanim_id(tanim_id) references sgt_tanim(`id`),
`Detay1` varchar(45),
`Detay2` varchar(45),
`Detay3` varchar(45),
`Detay4` varchar(45),
`Detay5` varchar(45),
`Detay6` varchar(45),
`Detay7` varchar(45),
`Detay8` varchar(45),
`Detay9` varchar(45),
`Detay10` varchar(45)
);