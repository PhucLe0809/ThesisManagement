-- CREATE DATABASE
-- create database ThesisManagement
-- go

-- Data Source=DESKTOP-4FIVTNT\SQLEXPRESS;Initial Catalog=ThesisManagement;Integrated Security=True;Encrypt=False
use ThesisManagement
go

drop table Account, Team, Thesis, ThesisStatus, Technology

-- CREATE TABLE ACCOUNT
create table Account (
    idaccount nvarchar(10) primary key not null,
    fullname nvarchar(50) not null,
    citizencode nvarchar(15) not null,
    birthday datetime not null,
    gender nvarchar(10) not null,
    email nvarchar(50) not null,
    phonenumber nvarchar(15) not null,
    handle nvarchar(50) not null,
    role nvarchar(10) not null,
    university nvarchar(100) not null,
    faculty nvarchar(50) not null,
    workcode nvarchar(20) not null,
    password nvarchar(50) not null,
    avatarname varchar(30) not null,
);

-- CREATE TABLE THESIS
create table Thesis (
    idthesis nvarchar(10) primary key not null,
    topic text not null,
    field nvarchar(50) not null,
    tslevel nvarchar(10) not null,
    maxmembers int not null,
    description text not null,
    publishdate datetime not null,
    technology text not null,
    functions text not null,
    requirements text not null,
    idcreator nvarchar(10) not null,
    isfavorite bit not null default 0,
    status nvarchar(10) not null,
	idinstructor nvarchar(10) not null,
);

-- CREATE TABLE TEAM
create table Team
(
    idteam nvarchar(10) not null,
    idaccount nvarchar(10) not null,
    name nvarchar(50) not null,	
    created datetime not null,
    avatarname varchar(50) not null,
);

-- CREATE TABLE THESISREGISTER
create table ThesisStatus
(
	idteam nvarchar(10) not null,
	idthesis nvarchar(10) not null,
	status nvarchar(10) not null,
);

-- CREATE TABLE TECHNOLOGY
create table Technology
(
	field nvarchar(50) not null,
	tech nvarchar(70) not null,
);

-- Lecture 1 - 10
INSERT INTO Account
VALUES 
    ('242200001', 'David Lee', '072352117212', '1995-03-15', 'Male', 'david', '0375676599', 'DavidL', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5373538693', 'abc', 'PicAvatarOne'),
    ('242200002', 'Alice Johnson', '095216398243', '1994-08-22', 'Female', 'alice@gmail.com', '0652145893', 'AliceJ', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236492347', 'abc', 'PicAvatarTwo'),
    ('242200003', 'John Smith', '093578641325', '1996-12-10', 'Male', 'john@gmail.com', '0845763214', 'JohnS', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325678942', 'abc', 'PicAvatarThree'),
    ('242200004', 'Emily Brown', '086547932156', '1993-05-29', 'Female', 'emily@gmail.com', '0213546879', 'EmilyB', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287651293', 'abc', 'PicAvatarDemoUser'),
    ('242200005', 'Michael Davis', '073859216843', '1997-09-17', 'Male', 'michael@gmail.com', '0397546821', 'MichaelD', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'abc', 'PicAvatarFive'),
    ('242200006', 'Sophia Taylor', '094621837595', '1992-11-05', 'Female', 'sophia@gmail.com', '0874651239', 'SophiaT', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'abc', 'PicAvatarSix'),
    ('242200007', 'William Clark', '085239614780', '1998-02-25', 'Male', 'william@gmail.com', '0987543210', 'WilliamC', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abc', 'PicAvatarSeven'),
    ('242200008', 'Olivia Martinez', '092763514789', '1991-07-08', 'Female', 'olivia@gmail.com', '0239654781', 'OliviaM', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'abc', 'PicAvatarEight'),
    ('242200009', 'Daniel Anderson', '083715932641', '1999-04-12', 'Male', 'daniel@gmail.com', '0946582713', 'DanielA', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc', 'PicAvatarNine'),
    ('242200010', 'Isabella Wilson', '096347812530', '1990-10-03', 'Female', 'isabella@gmail.com', '0357894216', 'IsabellaW', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'abc', 'PicAvatarTen');
	 
-- INSERT Student
-- delete from Account where role = 'Student'
-- update Account set password = '123abc' where role = 'Student'

-- Student 1 - 10
INSERT INTO Account
VALUES 
    ('243300001', 'Emma Watson', '093482139832', '2003-03-15', 'Female', 'emma@gmail.com', '0976523421', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'abc', 'PicAvatarOne'),
    ('243300002', 'Chris Evans', '096321587439', '2002-08-22', 'Male', 'chris', '0654321987', 'ChrisE', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'abc', 'PicAvatarFive'),
    ('243300003', 'Scarlett Johansson', '093654827615', '2004-12-10', 'Female', 'scarlett@gmail.com', '0845672310', 'ScarlettJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'abc', 'PicAvatarTwo'),
    ('243300004', 'Tom Holland', '096527384519', '2003-05-29', 'Male', 'tom@gmail.com', '0213546789', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'abc', 'PicAvatarThree'),
    ('243300005', 'Zendaya', '093741258639', '2003-09-17', 'Female', 'zendaya@gmail.com', '0397546821', 'Zendaya', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'abc', 'PicAvatarDemoUser'),
    ('243300006', 'Robert Downey Jr.', '096374815236', '2002-11-05', 'Male', 'robert@gmail.com', '0874651239', 'RobertDJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'abc', 'PicAvatarSix'),
    ('243300007', 'Gal Gadot', '095261398712', '2004-02-25', 'Female', 'gal@gmail.com', '0987543210', 'GalG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abc', 'PicAvatarSeven'),
    ('243300008', 'Chris Pratt', '093658274916', '2001-07-08', 'Male', 'chrisp@gmail.com', '0239654781', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'abc', 'PicAvatarEight'),
    ('243300009', 'Brie Larson', '096347819520', '2003-04-12', 'Female', 'brie@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc', 'PicAvatarNine'),
    ('243300010', 'Tom Hiddleston', '096347812530', '2002-10-03', 'Male', 'tomh@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'abc', 'PicAvatarTen');
	 
-- Student 11 - 20
INSERT INTO Account
VALUES 
    ('243300011', 'Natalie Portman', '093482139832', '2000-03-15', 'Female', 'natalie.portman@gmail.com', '0976523421', 'NatalieP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'abc', 'PicAvatarOne'),
    ('243300012', 'Brad Pitt', '096321587439', '2001-08-22', 'Male', 'brad.pitt@gmail.com', '0654321987', 'BradP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'abc', 'PicAvatarTwo'),
    ('243300013', 'Angelina Jolie', '093654827615', '2003-12-10', 'Female', 'angelina.jolie@gmail.com', '0845672310', 'AngelinaJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'abc', 'PicAvatarTen'),
    ('243300014', 'Leonardo DiCaprio', '096527384519', '2000-05-29', 'Male', 'leonardo.dicaprio@gmail.com', '0213546789', 'LeonardoD', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'abc', 'PicAvatarThree'),
    ('243300015', 'Emma Watson', '093741258639', '2000-09-17', 'Female', 'emma.watson@gmail.com', '0397546821', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'abc', 'PicAvatarDemoUser'),
    ('243300016', 'Chris Hemsworth', '096374815236', '2001-11-05', 'Male', 'chris.hemsworth@gmail.com', '0874651239', 'ChrisH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'abc', 'PicAvatarFive'),
    ('243300017', 'Jennifer Lawrence', '095261398712', '2003-02-25', 'Female', 'jennifer.lawrence@gmail.com', '0987543210', 'JenniferL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abc', 'PicAvatarSix'),
    ('243300018', 'Matthew McConaughey', '093658274916', '2002-07-08', 'Male', 'matthew.mcconaughey@gmail.com', '0239654781', 'MatthewMc', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'abc', 'PicAvatarSeven'),
    ('243300019', 'Brie Larson', '096347819520', '2001-04-12', 'Female', 'brie.larson@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc', 'PicAvatarEight'),
    ('243300020', 'Tom Hiddleston', '096347812530', '2000-10-03', 'Male', 'tom.hiddleston@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'abc', 'PicAvatarNine');

-- INSERT TABLE Thesis

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
		'242200001', 1, 'Registered', '242200001');

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
		'242200001', 0, 'Registered', '242200001');

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
		'242200001', 1, 'Registered', '242200001');

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
		'242200001', 0, 'Processing', '242200001');

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
		'242200001', 1, 'Processing', '242200001');

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
		'242200001', 0, 'Completed', '242200001');

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
		'242200001', 1, 'Published', '242200001');

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
		'242200001', 0, 'Published', '242200001');

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
		'242200001', 1, 'Published', '242200001');

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
		'242200001', 0, 'Published', '242200001');

-- INSERT TABLE Team

INSERT INTO Team
VALUES 
('245500001', '243300001', 'Code Crusaders', '2024-03-25', 'PicAvatarOne'),
('245500001', '243300002', 'Code Crusaders', '2024-03-25', 'PicAvatarOne'),
('245500001', '243300003', 'Code Crusaders', '2024-03-25', 'PicAvatarOne'),
('245500001', '243300004', 'Code Crusaders', '2024-03-25', 'PicAvatarOne'),
('245500001', '243300005', 'Code Crusaders', '2024-03-25', 'PicAvatarOne'),
('245500002', '243300006', 'Digital Dynamos', '2024-03-26', 'PicAvatarTwo'),
('245500002', '243300007', 'Digital Dynamos', '2024-03-26', 'PicAvatarTwo'),
('245500002', '243300008', 'Digital Dynamos', '2024-03-26', 'PicAvatarTwo'),
('245500003', '243300009', 'Byte Busters', '2024-03-27', 'PicAvatarThree'),
('245500003', '243300010', 'Byte Busters', '2024-03-27', 'PicAvatarThree'),
('245500004', '243300011', 'Tech Titans', '2024-03-28', 'PicAvatarDemoUser'),
('245500004', '243300012', 'Tech Titans', '2024-03-28', 'PicAvatarDemoUser'),
('245500005', '243300013', 'Cyber Savants', '2024-03-20', 'PicAvatarFive'),
('245500005', '243300014', 'Cyber Savants', '2024-03-20', 'PicAvatarFive'),
('245500006', '243300015', 'Data Wizards', '2024-03-21', 'PicAvatarSix'),
('245500006', '243300016', 'Data Wizards', '2024-03-22', 'PicAvatarSix'),
('245500007', '243300017', 'Innovation Squad', '2024-03-23', 'PicAvatarSeven'),
('245500008', '243300018', 'Network Ninjas', '2024-03-24', 'PicAvatarSeven'),
('245500009', '243300019', 'Digital Mavericks', '2024-03-25', 'PicAvatarSix'),
('245500010', '243300020', 'Pixel Pioneers', '2024-03-26', 'PicAvatarTen');

-- INSERT TABLE ThesisStatus

INSERT INTO ThesisStatus
VALUES 
('245500001', '244400001', 'Registered'),
('245500002', '244400002', 'Registered'),
('245500003', '244400001', 'Registered'),
('245500004', '244400002', 'Registered'),
('245500005', '244400001', 'Registered'),
('245500006', '244400003', 'Registered'),
('245500007', '244400003', 'Registered'),
('245500008', '244400004', 'Processing'),
('245500009', '244400005', 'Processing'),
('245500010', '244400006', 'Completed');

-- INSERT TABLE Technology

INSERT INTO Technology
VALUES
    ('SoftwareDevelopment', 'Spring (Java)'),
    ('SoftwareDevelopment', 'Django (Python)'),
    ('SoftwareDevelopment', 'Flask (Python)'),
    ('SoftwareDevelopment', 'React.js (JavaScript)'),
    ('SoftwareDevelopment', 'Angular (JavaScript/TypeScript)'),
    ('SoftwareDevelopment', 'Vue.js (JavaScript)'),
    ('SoftwareDevelopment', '.NET Framework (C#)'),
    ('SoftwareDevelopment', 'Ruby on Rails (Ruby)'),
    ('SoftwareDevelopment', 'Laravel (PHP)'),
    ('SoftwareDevelopment', 'Symfony (PHP)'),
    ('SoftwareDevelopment', 'SwiftUI (Swift)'),
    ('SoftwareDevelopment', 'Express.js (JavaScript)');

INSERT INTO Technology
VALUES
    ('Cybersecurity', 'Metasploit Framework'),
    ('Cybersecurity', 'Wireshark'),
    ('Cybersecurity', 'Snort'),
    ('Cybersecurity', 'Bro'),
    ('Cybersecurity', 'Suricata'),
    ('Cybersecurity', 'Nmap'),
    ('Cybersecurity', 'OpenVAS'),
    ('Cybersecurity', 'OSSEC'),
    ('Cybersecurity', 'YARA'),
    ('Cybersecurity', 'Burp Suite'),
    ('Cybersecurity', 'OWASP ZAP (Zed Attack Proxy)'),
    ('Cybersecurity', 'ModSecurity'),
    ('Cybersecurity', 'Security Onion'),
    ('Cybersecurity', 'SELinux (Security-Enhanced Linux)'),
    ('Cybersecurity', 'AppArmor'),
    ('Cybersecurity', 'Bro/Zeek'),
    ('Cybersecurity', 'Cuckoo Sandbox'),
    ('Cybersecurity', 'Hashcat'),
    ('Cybersecurity', 'Volatility Framework'),
    ('Cybersecurity', 'GRR Rapid Response'),
    ('Cybersecurity', 'MISP (Malware Information Sharing Platform & Threat Sharing)'),
    ('Cybersecurity', 'CyberChef'),
    ('Cybersecurity', 'BloodHound'),
    ('Cybersecurity', 'Sysmon');

INSERT INTO Technology
VALUES
    ('DataScienceAndAnalytics', 'Python (Python)'),
    ('DataScienceAndAnalytics', 'R (R)'),
    ('DataScienceAndAnalytics', 'SQL (Structured Query Language)'),
    ('DataScienceAndAnalytics', 'Apache Hadoop (Java)'),
    ('DataScienceAndAnalytics', 'Apache Spark (Scala, Python, R)'),
    ('DataScienceAndAnalytics', 'Apache Kafka (Scala)'),
    ('DataScienceAndAnalytics', 'Tableau'),
    ('DataScienceAndAnalytics', 'Power BI'),
    ('DataScienceAndAnalytics', 'Jupyter Notebook (Python, R)'),
    ('DataScienceAndAnalytics', 'Apache Flink (Java, Scala)'),
    ('DataScienceAndAnalytics', 'scikit-learn (Python)'),
    ('DataScienceAndAnalytics', 'TensorFlow (Python)'),
    ('DataScienceAndAnalytics', 'PyTorch (Python)'),
    ('DataScienceAndAnalytics', 'Apache Mahout (Java)'),
    ('DataScienceAndAnalytics', 'SAS'),
    ('DataScienceAndAnalytics', 'Microsoft Excel (VBA)');

INSERT INTO Technology
VALUES
    ('ArtificialIntelligenceAndMachineLearning', 'TensorFlow (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'PyTorch (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Keras (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'scikit-learn (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Apache Spark MLlib (Scala, Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Microsoft Cognitive Toolkit (CNTK) (C++, C#, Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'OpenAI Gym (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'IBM Watson (C++, Java, Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Amazon SageMaker (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Google Cloud AI Platform (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Microsoft Azure Machine Learning (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'H2O.ai (Java, R, Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Caffe (C++, Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'MXNet (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Theano (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Deeplearning4j (Java, Scala)'),
    ('ArtificialIntelligenceAndMachineLearning', 'FastAI (Python)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Accord.NET (C#, F#)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Apache Mahout (Java)'),
    ('ArtificialIntelligenceAndMachineLearning', 'Weka (Java)');

INSERT INTO Technology
VALUES
    ('CloudComputing', 'Amazon Web Services (AWS)'),
    ('CloudComputing', 'Microsoft Azure'),
    ('CloudComputing', 'Google Cloud Platform (GCP)'),
    ('CloudComputing', 'IBM Cloud'),
    ('CloudComputing', 'Oracle Cloud'),
    ('CloudComputing', 'Alibaba Cloud'),
    ('CloudComputing', 'VMware Cloud'),
    ('CloudComputing', 'OpenStack'),
    ('CloudComputing', 'Docker'),
    ('CloudComputing', 'Kubernetes'),
    ('CloudComputing', 'Apache Mesos'),
    ('CloudComputing', 'Terraform'),
    ('CloudComputing', 'Ansible'),
    ('CloudComputing', 'Chef'),
    ('CloudComputing', 'Puppet'),
    ('CloudComputing', 'Apache Hadoop'),
    ('CloudComputing', 'Apache Spark'),
    ('CloudComputing', 'Apache Kafka'),
    ('CloudComputing', 'Apache Cassandra'),
    ('CloudComputing', 'Apache ZooKeeper'),
    ('CloudComputing', 'Microsoft Hyper-V'),
    ('CloudComputing', 'VMware vSphere');

INSERT INTO Technology
VALUES
    ('InternetOfThings', 'MQTT (Message Queuing Telemetry Transport)'),
    ('InternetOfThings', 'CoAP (Constrained Application Protocol)'),
    ('InternetOfThings', 'AMQP (Advanced Message Queuing Protocol)'),
    ('InternetOfThings', 'HTTP/HTTPS'),
    ('InternetOfThings', 'LoRa (Long Range)'),
    ('InternetOfThings', 'Zigbee'),
    ('InternetOfThings', 'Bluetooth Low Energy (BLE)'),
    ('InternetOfThings', 'Wi-Fi'),
    ('InternetOfThings', 'RFID (Radio-Frequency Identification)'),
    ('InternetOfThings', 'NFC (Near Field Communication)'),
    ('InternetOfThings', 'MQTT-SN (MQTT for Sensor Networks)'),
    ('InternetOfThings', 'AllJoyn'),
    ('InternetOfThings', 'HomeKit'),
    ('InternetOfThings', 'OpenThread'),
    ('InternetOfThings', 'Z-Wave'),
    ('InternetOfThings', 'Thread'),
    ('InternetOfThings', 'Sigfox'),
    ('InternetOfThings', 'NB-IoT (Narrowband IoT)'),
    ('InternetOfThings', 'LTE-M (Long-Term Evolution for Machines)'),
    ('InternetOfThings', 'MQTT over WebSocket'),
    ('InternetOfThings', 'Lightweight M2M (LwM2M)'),
    ('InternetOfThings', 'Contiki OS'),
    ('InternetOfThings', 'RIOT OS'),
    ('InternetOfThings', 'FreeRTOS'),
    ('InternetOfThings', 'Arduino'),
    ('InternetOfThings', 'Raspberry Pi'),
    ('InternetOfThings', 'ESP8266/ESP32'),
    ('InternetOfThings', 'Particle (formerly known as Spark)'),
    ('InternetOfThings', 'Microsoft Azure IoT Suite'),
    ('InternetOfThings', 'Google Cloud IoT Core'),
    ('InternetOfThings', 'AWS IoT Core'),
    ('InternetOfThings', 'IBM Watson IoT Platform');

INSERT INTO Technology
VALUES
    ('MobileDevelopment', 'Android SDK (Java, Kotlin)'),
    ('MobileDevelopment', 'iOS SDK (Swift, Objective-C)'),
    ('MobileDevelopment', 'React Native (JavaScript)'),
    ('MobileDevelopment', 'Flutter (Dart)'),
    ('MobileDevelopment', 'Xamarin (C#, .NET)'),
    ('MobileDevelopment', 'Ionic Framework (JavaScript, Angular, React)'),
    ('MobileDevelopment', 'Apache Cordova/PhoneGap (HTML, CSS, JavaScript)'),
    ('MobileDevelopment', 'Unity (C#, UnityScript)'),
    ('MobileDevelopment', 'NativeScript (JavaScript, TypeScript)'),
    ('MobileDevelopment', 'Appcelerator Titanium (JavaScript)'),
    ('MobileDevelopment', 'Corona SDK (Lua)'),
    ('MobileDevelopment', 'Qt (C++, QML)'),
    ('MobileDevelopment', 'Sencha Touch (JavaScript)'),
    ('MobileDevelopment', 'jQuery Mobile (JavaScript)'),
    ('MobileDevelopment', 'Kivy (Python)'),
    ('MobileDevelopment', 'Onsen UI (JavaScript)'),
    ('MobileDevelopment', 'Framework7 (HTML, CSS, JavaScript)'),
    ('MobileDevelopment', 'Firebase (BaaS - Backend as a Service)'),
    ('MobileDevelopment', 'Parse (BaaS - Backend as a Service)'),
    ('MobileDevelopment', 'AWS Mobile SDK (Amazon Web Services)'),
    ('MobileDevelopment', 'Microsoft Xamarin.Forms');

INSERT INTO Technology
VALUES
    ('WebDevelopment', 'HTML (Hypertext Markup Language)'),
    ('WebDevelopment', 'CSS (Cascading Style Sheets)'),
    ('WebDevelopment', 'JavaScript'),
    ('WebDevelopment', 'React.js'),
    ('WebDevelopment', 'Angular'),
    ('WebDevelopment', 'Vue.js'),
    ('WebDevelopment', 'jQuery'),
    ('WebDevelopment', 'Bootstrap'),
    ('WebDevelopment', 'Sass (Syntactically Awesome Stylesheets)'),
    ('WebDevelopment', 'LESS'),
    ('WebDevelopment', 'Node.js'),
    ('WebDevelopment', 'Express.js'),
    ('WebDevelopment', 'Django (Python)'),
    ('WebDevelopment', 'Flask (Python)'),
    ('WebDevelopment', 'Ruby on Rails (Ruby)'),
    ('WebDevelopment', 'Laravel (PHP)'),
    ('WebDevelopment', 'Symfony (PHP)'),
    ('WebDevelopment', 'ASP.NET (C#)'),
    ('WebDevelopment', 'Spring (Java)'),
    ('WebDevelopment', 'WordPress (PHP)'),
    ('WebDevelopment', 'Drupal (PHP)'),
    ('WebDevelopment', 'Joomla (PHP)'),
    ('WebDevelopment', 'Shopify (Ruby)'),
    ('WebDevelopment', 'Magento (PHP)'),
    ('WebDevelopment', 'MEAN stack (MongoDB, Express.js, Angular, Node.js)'),
    ('WebDevelopment', 'MERN stack (MongoDB, Express.js, React.js, Node.js)'),
    ('WebDevelopment', 'LAMP stack (Linux, Apache, MySQL, PHP)'),
    ('WebDevelopment', 'WAMP stack (Windows, Apache, MySQL, PHP)'),
    ('WebDevelopment', 'XAMPP stack (Cross-Platform, Apache, MySQL, PHP, Perl)'),
    ('WebDevelopment', 'Serverless Framework'),
    ('WebDevelopment', 'Flask (Python)'),
    ('WebDevelopment', 'Pyramid (Python)'),
    ('WebDevelopment', 'ASP.NET MVC (C#)'),
    ('WebDevelopment', 'Ruby on Rails (Ruby)'),
    ('WebDevelopment', 'Laravel (PHP)'),
    ('WebDevelopment', 'Django (Python)'),
    ('WebDevelopment', 'Express.js (JavaScript)'),
    ('WebDevelopment', 'Next.js (JavaScript)'),
    ('WebDevelopment', 'Nuxt.js (JavaScript)'),
    ('WebDevelopment', 'Gatsby (JavaScript)'),
    ('WebDevelopment', 'Svelte (JavaScript)'),
    ('WebDevelopment', 'Strapi (JavaScript)'),
    ('WebDevelopment', 'FastAPI (Python)'),
    ('WebDevelopment', 'Falcon (Python)'),
    ('WebDevelopment', 'Hapi.js (JavaScript)'),
    ('WebDevelopment', 'NestJS (JavaScript/TypeScript)'),
    ('WebDevelopment', 'Bottle (Python)'),
    ('WebDevelopment', 'CherryPy (Python)'),
    ('WebDevelopment', 'Zend Framework (PHP)'),
    ('WebDevelopment', 'CakePHP (PHP)'),
    ('WebDevelopment', 'CodeIgniter (PHP)'),
    ('WebDevelopment', 'Symfony (PHP)'),
    ('WebDevelopment', 'Yii (PHP)'),
    ('WebDevelopment', 'Play Framework (Java)'),
    ('WebDevelopment', 'Grails (Groovy)'),
    ('WebDevelopment', 'Dropwizard (Java)'),
    ('WebDevelopment', 'Spark (Java)'),
    ('WebDevelopment', 'Flask (Python)'),
    ('WebDevelopment', 'Pyramid (Python)');

INSERT INTO Technology
VALUES
    ('BlockchainTechnology', 'Ethereum'),
    ('BlockchainTechnology', 'Hyperledger Fabric'),
    ('BlockchainTechnology', 'Corda'),
    ('BlockchainTechnology', 'Stellar'),
    ('BlockchainTechnology', 'Ripple'),
    ('BlockchainTechnology', 'Truffle Framework'),
    ('BlockchainTechnology', 'Ganache'),
    ('BlockchainTechnology', 'Web3.js'),
    ('BlockchainTechnology', 'Solidity'),
    ('BlockchainTechnology', 'Remix IDE'),
    ('BlockchainTechnology', 'Geth (Go Ethereum)'),
    ('BlockchainTechnology', 'Parity Ethereum'),
    ('BlockchainTechnology', 'Quorum'),
    ('BlockchainTechnology', 'EOS.IO'),
    ('BlockchainTechnology', 'NEO'),
    ('BlockchainTechnology', 'Monero'),
    ('BlockchainTechnology', 'Tezos'),
    ('BlockchainTechnology', 'Zcash'),
    ('BlockchainTechnology', 'Bitcoin Core'),
    ('BlockchainTechnology', 'BitcoinJ'),
    ('BlockchainTechnology', 'EOS Smart Contract Development Kit (EOS SDK)'),
    ('BlockchainTechnology', 'Hyperledger Composer'),
    ('BlockchainTechnology', 'MultiChain'),
    ('BlockchainTechnology', 'BigchainDB'),
    ('BlockchainTechnology', 'Sawtooth Lake (Hyperledger Sawtooth)'),
    ('BlockchainTechnology', 'IOTA'),
    ('BlockchainTechnology', 'Waves Platform'),
    ('BlockchainTechnology', 'Cardano'),
    ('BlockchainTechnology', 'Ontology'),
    ('BlockchainTechnology', 'VeChainThor'),
    ('BlockchainTechnology', 'NEM'),
    ('BlockchainTechnology', 'Avalanche'),
    ('BlockchainTechnology', 'AvalancheGo'),
    ('BlockchainTechnology', 'AvalancheJS'),
    ('BlockchainTechnology', 'Avalanche Web3'),
    ('BlockchainTechnology', 'Avalanche Explorer'),
    ('BlockchainTechnology', 'Avalanche Wallet'),
    ('BlockchainTechnology', 'AvalancheIPFS');

INSERT INTO Technology
VALUES
    ('HumanComputerInteraction', 'HTML (Hypertext Markup Language)'),
    ('HumanComputerInteraction', 'CSS (Cascading Style Sheets)'),
    ('HumanComputerInteraction', 'JavaScript'),
    ('HumanComputerInteraction', 'React.js'),
    ('HumanComputerInteraction', 'Angular'),
    ('HumanComputerInteraction', 'Vue.js'),
    ('HumanComputerInteraction', 'jQuery'),
    ('HumanComputerInteraction', 'Bootstrap'),
    ('HumanComputerInteraction', 'Sass (Syntactically Awesome Stylesheets)'),
    ('HumanComputerInteraction', 'LESS'),
    ('HumanComputerInteraction', 'Node.js'),
    ('HumanComputerInteraction', 'Electron'),
    ('HumanComputerInteraction', 'Flutter'),
    ('HumanComputerInteraction', 'Xamarin'),
    ('HumanComputerInteraction', 'Unity'),
    ('HumanComputerInteraction', 'Unreal Engine'),
    ('HumanComputerInteraction', 'OpenGL'),
    ('HumanComputerInteraction', 'DirectX'),
    ('HumanComputerInteraction', 'Three.js'),
    ('HumanComputerInteraction', 'A-Frame (WebVR framework)'),
    ('HumanComputerInteraction', 'ARKit (Apple Augmented Reality framework)'),
    ('HumanComputerInteraction', 'ARCore (Google Augmented Reality framework)'),
    ('HumanComputerInteraction', 'Oculus SDK'),
    ('HumanComputerInteraction', 'HTC Vive SDK'),
    ('HumanComputerInteraction', 'Windows Mixed Reality SDK'),
    ('HumanComputerInteraction', 'Leap Motion SDK'),
    ('HumanComputerInteraction', 'Kinect SDK'),
    ('HumanComputerInteraction', 'Framer'),
    ('HumanComputerInteraction', 'Adobe XD'),
    ('HumanComputerInteraction', 'Sketch'),
    ('HumanComputerInteraction', 'Figma'),
    ('HumanComputerInteraction', 'InVision'),
    ('HumanComputerInteraction', 'Balsamiq Mockups'),
    ('HumanComputerInteraction', 'Axure RP'),
    ('HumanComputerInteraction', 'Usability Testing'),
    ('HumanComputerInteraction', 'User Interviews'),
    ('HumanComputerInteraction', 'Surveys'),
    ('HumanComputerInteraction', 'Eye Tracking'),
    ('HumanComputerInteraction', 'A/B Testing'),
    ('HumanComputerInteraction', 'Heatmaps'),
    ('HumanComputerInteraction', 'Click Maps'),
    ('HumanComputerInteraction', 'Scroll Maps'),
    ('HumanComputerInteraction', 'Interaction Design Patterns');



