CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE recipes (
  id INT AUTO_INCREMENT PRIMARY KEY, 
  title VARCHAR(100) NOT NULL, 
  img VARCHAR(500) NOT NULL, 
  category ENUM('Cheese', 'Italian', 'Soup', 'Mexican', 'Specialty Coffee'), 
  instructions VARCHAR(1000), 
  creatorId VARCHAR(255) NOT NULL, 
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';

INSERT INTO recipes 
(title, img, category, instructions, creatorId)
VALUES 
("Blueberry Pancakes", "https://plus.unsplash.com/premium_photo-1663858367001-89e5c92d1e0e?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Zm9vZHxlbnwwfHwwfHx8MA%3D%3D", "Cheese", "Do A B C",  "65ac39b912abc318fc85f239");
-- ("Banana Pancakes", "https://images.unsplash.com/photo-1567620905732-2d1ec7ab7445?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Zm9vZHxlbnwwfHwwfHx8MA%3D%3D", "Specialty Coffee", "Do Q B R",  "65aa1b150bd492577f788478");
-- ("Blueberry French Toast", "https://images.unsplash.com/photo-1484723091739-30a097e8f929?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGZvb2R8ZW58MHx8MHx8fDA%3D", "Italian", "Do L M N",  "65a85c5a9f08f4f32d87ceef");

SELECT * FROM recipes;