-- CREATE DATABASE
create database ThesisManagement
go
-- Data Source=DESKTOP-4FIVTNT\SQLEXPRESS;Initial Catalog=ThesisManagement;Integrated Security=True;Encrypt=False
use ThesisManagement
go

-- CREATE TABLE
create table Account (
    idaccount nvarchar(50) primary key not null,
    fullname nvarchar(100) not null,
    citizencode nvarchar(20) not null,
    birthday datetime not null,
    gender nvarchar(10) not null,
    email nvarchar(100) not null,
    phonenumber nvarchar(20) not null,
    handle nvarchar(50) not null,
    role nvarchar(20) not null,
    university nvarchar(100) not null,
    faculty nvarchar(100) not null,
    workcode nvarchar(20) not null,
    password nvarchar(100) not null,
	avatarname varchar(50) not null,
);
-- drop table Account

create table Thesis (
    idthesis nvarchar(50) primary key not null,
    topic text not null,
    field nvarchar(100) not null,
    tslevel nvarchar(20) not null,
    maxmembers int not null,
    description text not null,
    publishdate datetime not null,
    technology text not null,
    functions text not null,
    requirements text not null,
	idcreator nvarchar(50) not null default '221100001',
	isfavorite bit not null default 0,
	pending int not null default 0,
	accepted int not null default 0,
	completed int not null default 0
);

create table ThesisStatus
(
	idaccount nvarchar(50) not null,
	idthesis nvarchar(50) not null,
	sta nvarchar(20) not null
)

-- RENAME COLUM
-- EXEC sp_rename 'Thesis.level', 'tslevel', 'COLUMN';

-- DELETE ALL RECORD
-- delete from Account
-- drop table Account

-- INSERT Lecture
-- delete from Account
-- update Account set password = 'abc123' where role = 'Lecture'

-- Lecture 1 - 10
INSERT INTO Account
VALUES 
    ('242200001', 'David Lee', '072352117212', '1995-03-15', 'Male', 'david', '0375676599', 'DavidL', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5373538693', 'abc123', 'PicAvatarOne'),
    ('242200002', 'Alice Johnson', '095216398243', '1994-08-22', 'Female', 'alice@gmail.com', '0652145893', 'AliceJ', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236492347', 'xyz456', 'PicAvatarDemoUser'),
    ('242200003', 'John Smith', '093578641325', '1996-12-10', 'Male', 'john@gmail.com', '0845763214', 'JohnS', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325678942', 'qwerty', 'PicAvatarDemoUser'),
    ('242200004', 'Emily Brown', '086547932156', '1993-05-29', 'Female', 'emily@gmail.com', '0213546879', 'EmilyB', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287651293', 'pass123', 'PicAvatarDemoUser'),
    ('242200005', 'Michael Davis', '073859216843', '1997-09-17', 'Male', 'michael@gmail.com', '0397546821', 'MichaelD', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'secure789', 'PicAvatarDemoUser'),
    ('242200006', 'Sophia Taylor', '094621837595', '1992-11-05', 'Female', 'sophia@gmail.com', '0874651239', 'SophiaT', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'passpass', 'PicAvatarDemoUser'),
    ('242200007', 'William Clark', '085239614780', '1998-02-25', 'Male', 'william@gmail.com', '0987543210', 'WilliamC', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz', 'PicAvatarDemoUser'),
    ('242200008', 'Olivia Martinez', '092763514789', '1991-07-08', 'Female', 'olivia@gmail.com', '0239654781', 'OliviaM', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password', 'PicAvatarDemoUser'),
    ('242200009', 'Daniel Anderson', '083715932641', '1999-04-12', 'Male', 'daniel@gmail.com', '0946582713', 'DanielA', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz', 'PicAvatarDemoUser'),
    ('242200010', 'Isabella Wilson', '096347812530', '1990-10-03', 'Female', 'isabella@gmail.com', '0357894216', 'IsabellaW', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123', 'PicAvatarDemoUser');
	 
-- INSERT Student
-- delete from Account where role = 'Student'
-- update Account set password = '123abc' where role = 'Student'

-- Student 1 - 10
INSERT INTO Account
VALUES 
    ('243300001', 'Emma Watson', '093482139832', '2003-03-15', 'Female', 'emma@gmail.com', '0976523421', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123', 'PicAvatarDemoUser'),
    ('243300002', 'Chris Evans', '096321587439', '2002-08-22', 'Male', 'chris', '0654321987', 'ChrisE', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456', 'PicAvatarFive'),
    ('243300003', 'Scarlett Johansson', '093654827615', '2004-12-10', 'Female', 'scarlett@gmail.com', '0845672310', 'ScarlettJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty', 'PicAvatarDemoUser'),
    ('243300004', 'Tom Holland', '096527384519', '2003-05-29', 'Male', 'tom@gmail.com', '0213546789', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789', 'PicAvatarDemoUser'),
    ('243300005', 'Zendaya', '093741258639', '2003-09-17', 'Female', 'zendaya@gmail.com', '0397546821', 'Zendaya', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass', 'PicAvatarDemoUser'),
    ('243300006', 'Robert Downey Jr.', '096374815236', '2002-11-05', 'Male', 'robert@gmail.com', '0874651239', 'RobertDJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123', 'PicAvatarDemoUser'),
    ('243300007', 'Gal Gadot', '095261398712', '2004-02-25', 'Female', 'gal@gmail.com', '0987543210', 'GalG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz', 'PicAvatarDemoUser'),
    ('243300008', 'Chris Pratt', '093658274916', '2001-07-08', 'Male', 'chrisp@gmail.com', '0239654781', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password', 'PicAvatarDemoUser'),
    ('243300009', 'Brie Larson', '096347819520', '2003-04-12', 'Female', 'brie@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz', 'PicAvatarDemoUser'),
    ('243300010', 'Tom Hiddleston', '096347812530', '2002-10-03', 'Male', 'tomh@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123', 'PicAvatarDemoUser');

-- INSERT Thesis
-- delete from Thesis
-- update Thesis set maxmembers = 5 where ...

-- Thesis 1
INSERT INTO Thesis 
VALUES ('244400001', 
        'Building a model for applying information technology to serve the development of agriculture and rural industry', 
        'SoftwareDevelopment', 
        'Medium', 
        5, 
        'Building an information technology model to optimize agricultural management and development, enhancing production efficiency, service provision, and sustainable development in rural areas.', 
        '2024-03-15 19:30:45', 
        'Technologies include Artificial Intelligence, IoT, Blockchain, Big Data, and Machine Learning for production processes and resource management.', 
        'Functions include weather monitoring, crop management, sensor data recording, yield prediction, schedule and resource management, and farmer-market connectivity.', 
        'Requirements: Agricultural knowledge, programming skills, understanding of AI and data analysis, logical thinking, and creativity in technology application in agriculture.',
		'241100001', 1, 0, 0, 0);

-- Thesis 2
INSERT INTO Thesis 
VALUES ('244400002', 
        'Developing an AI-powered system for cybersecurity threat detection and prevention', 
        'Cybersecurity', 
        'Difficult', 
        7, 
        'Creating an advanced AI system to detect and prevent cybersecurity threats in real-time, providing robust protection for sensitive data and networks.', 
        '2024-03-14 14:45:30', 
        'Technologies include Machine Learning, Deep Learning, Natural Language Processing, and Pattern Recognition for analyzing network traffic and identifying potential threats.', 
        'Functions include anomaly detection, intrusion detection, malware analysis, threat intelligence integration, and automated response mechanisms.', 
        'Requirements: Strong understanding of cybersecurity principles, programming expertise in Python or Java, familiarity with network protocols and security tools, and analytical skills.',
		'241100001', 0, 0, 0, 0);

-- Thesis 3
INSERT INTO Thesis 
VALUES ('244400003', 
        'Utilizing data science techniques for predictive maintenance in manufacturing industries', 
        'DataScienceAndAnalytics', 
        'Medium', 
        4, 
        'Implementing data science methods to predict machinery failures and optimize maintenance schedules in manufacturing plants, reducing downtime and improving productivity.', 
        '2024-03-13 10:20:15', 
        'Technologies include Predictive Analytics, Machine Learning, Data Visualization, and Time Series Analysis for analyzing equipment sensor data and predicting maintenance needs.', 
        'Functions include data preprocessing, model training, feature selection, anomaly detection, and maintenance schedule optimization.', 
        'Requirements: Understanding of manufacturing processes, proficiency in data analysis tools like Python or R, knowledge of statistical techniques, and familiarity with industrial sensors and IoT.',
		'241100001', 1, 0, 0, 0);

-- Thesis 4
INSERT INTO Thesis 
VALUES ('244400004', 
        'Developing a chatbot using artificial intelligence for customer service', 
        'ArtificialIntelligenceAndMachineLearning', 
        'Easy', 
        3, 
        'Creating an AI-powered chatbot to handle customer inquiries, provide assistance, and streamline customer service operations for businesses.', 
        '2024-03-12 08:55:10', 
        'Technologies include Natural Language Processing, Machine Learning algorithms, and Chatbot frameworks for understanding user queries and generating appropriate responses.', 
        'Functions include intent recognition, context handling, response generation, and integration with backend systems.', 
        'Requirements: Proficiency in NLP libraries like NLTK or spaCy, experience in building chatbots using frameworks like Dialogflow or Rasa, and knowledge of RESTful APIs for backend integration.',
		'241100001', 0, 0, 0, 0);

-- Thesis 5
INSERT INTO Thesis 
VALUES ('244400005', 
        'Implementing cloud computing solutions for efficient data storage and processing', 
        'CloudComputing', 
        'Medium', 
        6, 
        'Deploying cloud-based infrastructure for storing and processing large volumes of data, ensuring scalability, reliability, and cost-effectiveness for businesses.', 
        '2024-03-11 12:30:25', 
        'Technologies include AWS, Azure, Google Cloud Platform, and Kubernetes for building scalable and resilient cloud architectures.', 
        'Functions include data migration, cluster management, performance optimization, security configuration, and cost monitoring.', 
        'Requirements: Familiarity with cloud platforms, experience in deploying and managing cloud services, understanding of networking and security principles, and knowledge of DevOps practices.',
		'241100001', 1, 0, 0, 0);

-- Thesis 6
INSERT INTO Thesis 
VALUES ('244400006', 
        'Creating IoT applications for smart energy management in buildings', 
        'InternetOfThings', 
        'Medium', 
        5, 
        'Developing IoT-based solutions to optimize energy consumption, monitor equipment performance, and automate energy-saving processes in residential and commercial buildings.', 
        '2024-03-10 15:20:40', 
        'Technologies include Arduino, Raspberry Pi, MQTT, and Zigbee for building IoT devices and communication protocols.', 
        'Functions include sensor integration, real-time data processing, energy usage analysis, automated control systems, and user interface design for energy monitoring.', 
        'Requirements: Knowledge of IoT protocols and platforms, proficiency in hardware programming, experience in energy management systems, and understanding of building automation principles.',
		'241100001', 0, 0, 0, 0);

-- Thesis 7
INSERT INTO Thesis 
VALUES ('244400007', 
        'Developing mobile applications for remote healthcare monitoring', 
        'MobileDevelopment', 
        'Medium', 
        4, 
        'Designing mobile apps to remotely monitor patients health status, track medication adherence, and facilitate communication between healthcare providers and patients.', 
        '2024-03-09 18:10:55', 
        'Technologies include Android Studio, Swift, Firebase, and HealthKit for building cross-platform mobile applications with health monitoring features.', 
        'Functions include user authentication, data encryption, real-time health data synchronization, medication reminders, and emergency alert systems.', 
        'Requirements: Proficiency in mobile app development frameworks, knowledge of healthcare regulations, experience in HIPAA compliance, and understanding of medical data privacy.',
		'241100001', 1, 0, 0, 0);

-- Thesis 8
INSERT INTO Thesis 
VALUES ('244400008', 
        'Developing responsive web interfaces for online education platforms', 
        'WebDevelopment', 
        'Medium', 
        6, 
        'Creating user-friendly web interfaces for online learning platforms, ensuring accessibility, interactivity, and engagement for learners of all ages.', 
        '2024-03-08 09:40:20', 
        'Technologies include HTML5, CSS3, JavaScript, React, and Node.js for building modern, responsive web interfaces and interactive learning modules.', 
        'Functions include frontend development, UI/UX design, content management, gamification features, and integration with learning management systems.', 
        'Requirements: Proficiency in web development technologies, understanding of educational principles, experience in UX/UI design, and familiarity with e-learning standards.',
		'241100001', 0, 0, 0, 0);

-- Thesis 9
INSERT INTO Thesis 
VALUES ('244400009', 
        'Exploring the potential of blockchain technology for supply chain transparency', 
        'BlockchainTechnology', 
        'Difficult', 
        8, 
        'Investigating how blockchain can enhance supply chain transparency, traceability, and accountability, improving trust and efficiency in global supply networks.', 
        '2024-03-07 11:50:35', 
        'Technologies include Ethereum, Hyperledger Fabric, and Solidity for building decentralized applications and smart contracts to track and verify supply chain transactions.', 
        'Functions include blockchain architecture design, smart contract development, consensus mechanism implementation, and integration with existing supply chain systems.', 
        'Requirements: Understanding of blockchain principles, proficiency in smart contract programming, knowledge of supply chain management, and familiarity with cryptographic techniques.',
		'241100001', 1, 0, 0, 0);

-- Thesis 10
INSERT INTO Thesis 
VALUES ('244400010', 
        'Advancing human-computer interaction through augmented reality interfaces', 
        'HumanComputerInteraction', 
        'Medium', 
        5, 
        'Exploring novel ways to interact with computers using augmented reality interfaces, enhancing user experience and productivity in various domains such as gaming, education, and healthcare.', 
        '2024-03-06 14:25:50', 
        'Technologies include Unity3D, ARKit, ARCore, and Vuforia for developing immersive AR experiences and intuitive user interfaces for AR applications.', 
        'Functions include gesture recognition, object tracking, spatial mapping, user feedback analysis, and usability testing for AR interfaces.', 
        'Requirements: Proficiency in AR development frameworks, understanding of human-centered design principles, experience in UI/UX design, and creativity in AR content creation.',
		'241100001', 0, 0, 0, 0);

-- INSERT ThesisStatus
-- delete from ThesisStatus

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400001', 'Pending'),
('243300002', '244400002', 'Accepted'),
('243300003', '244400003', 'Completed'),
('243300004', '244400004', 'Pending'),
('243300005', '244400005', 'Accepted'),
('243300006', '244400006', 'Completed'),
('243300007', '244400007', 'Pending'),
('243300008', '244400008', 'Accepted'),
('243300009', '244400009', 'Completed'),
('243300010', '244400010', 'Pending');

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400004', 'Pending'),
('243300002', '244400003', 'Accepted'),
('243300003', '244400005', 'Completed'),
('243300004', '244400009', 'Pending'),
('243300005', '244400010', 'Accepted'),
('243300006', '244400007', 'Completed'),
('243300007', '244400006', 'Pending'),
('243300008', '244400001', 'Accepted'),
('243300009', '244400002', 'Completed'),
('243300010', '244400008', 'Pending');

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400007', 'Pending'),
('243300002', '244400001', 'Accepted'),
('243300003', '244400009', 'Completed'),
('243300004', '244400003', 'Pending'),
('243300005', '244400004', 'Accepted'),
('243300006', '244400008', 'Completed'),
('243300007', '244400002', 'Pending'),
('243300008', '244400006', 'Accepted'),
('243300009', '244400010', 'Completed'),
('243300010', '244400005', 'Pending');

---

---










