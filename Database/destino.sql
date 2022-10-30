create database destino;

use destino;

CREATE TABLE destinos (
  id int NOT NULL,
  cidadeNome varchar(100) NOT NULL,
  pais varchar(5) NOT NULL,
  PRIMARY KEY (id),
);

/*drop database destino;*/
select * from destinos;

INSERT INTO `destinos` (`id`, `cidadeNome`, `pais`) VALUES
(2, 'Mountain View', 'USA'),
(1, 'Beijing','CHN'),
(3, 'Ackworth','USA'),
(5, 'Los Angeles', 5, 'USA', 34.04, -118.25),
(13, 'Far Rockaway','USA'),
(14, 'Hebei','CHN'),
(16, 'Nanjing','CHN'),
(18, 'Sunnyvale','USA'),
(20, 'Newark','USA');
(1288, 'Piracicaba', 'BRA'),
(1291, 'Porto Alegre','BRA'),
(1293, 'Nogent-le-roi', 'FRA');