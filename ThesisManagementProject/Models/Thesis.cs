using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject.Models
{
    #region THESIS ENUM

    public enum EField
    {
        [Display(Name = "SoftwareDevelopment")]
        SoftwareDevelopment,
        [Display(Name = "Cybersecurity")]
        Cybersecurity,
        [Display(Name = "DataScienceAndAnalytics")]
        DataScienceAndAnalytics,
        [Display(Name = "ArtificialIntelligenceAndMachineLearning")]
        ArtificialIntelligenceAndMachineLearning,
        [Display(Name = "CloudComputing")]
        CloudComputing,
        [Display(Name = "InternetOfThings")]
        InternetOfThings,
        [Display(Name = "MobileDevelopment")]
        MobileDevelopment,
        [Display(Name = "WebDevelopment")]
        WebDevelopment,
        [Display(Name = "ComputerNetworking")]
        ComputerNetworking,
        [Display(Name = "VirtualRealityAndAugmentedReality")]
        VirtualRealityAndAugmentedReality,
        [Display(Name = "BigData")]
        BigData,
        [Display(Name = "BlockchainTechnology")]
        BlockchainTechnology,
        [Display(Name = "HumanComputerInteraction")]
        HumanComputerInteraction,
        [Display(Name = "QuantumComputing")]
        QuantumComputing,
        [Display(Name = "Bioinformatics")]
        Bioinformatics
    }
    public enum ELevel
    {
        [Display(Name = "Easy")]
        Easy,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "Difficult")]
        Difficult
    }
    public enum EThesisStatus
    {
        [Display(Name = "Published")]
        Published,
        [Display(Name = "Registered")]
        Registered,
        [Display(Name = "Processing")]
        Processing,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "NotCompleted")]
        NotCompleted
    }

    #endregion

    public class Thesis
    {
        private MyProcess myProcess = new MyProcess();

        #region THESIS ATTRIBUTES

        private string idThesis;
        private string topic;
        private string field;
        private EField tsfield;
        private string level;
        private ELevel tslevel;
        private int maxMembers;
        private string description;
        private DateTime publishDate;
        private string technology;
        private string functions;
        private string requirements;
        private string idCreator;
        private bool isFavorite;
        private string status;
        private EThesisStatus tsstatus;
        private string idInstructor;

        #endregion

        #region THESIS CONTRUCTOR

        public Thesis()
        {
            this.idThesis = string.Empty;
            this.topic = string.Empty;
            this.field = string.Empty;
            this.tsfield = EField.SoftwareDevelopment;
            this.level = string.Empty;
            this.tslevel = ELevel.Easy;
            this.maxMembers = 0;
            this.description = string.Empty;
            this.publishDate = DateTime.Now;
            this.technology = string.Empty;
            this.functions = string.Empty;
            this.requirements = string.Empty;
            this.idCreator = string.Empty;
            this.isFavorite = false;
            this.status = string.Empty;
            this.tsstatus = EThesisStatus.Published;
            this.idInstructor = string.Empty;
        }
        public Thesis(string topic, EField field, ELevel level, int maxMembers, string desciption,
                        DateTime publishDate, string technology, string functions, string requirements, string idCreator, string idInstructor)
        {
            this.idThesis = myProcess.GenIDClassify(EClassify.Thesis);
            this.topic = topic;
            this.tsfield = field;
            this.field = tsfield.ToString();
            this.tslevel = level;
            this.level = tslevel.ToString();
            this.maxMembers = maxMembers;
            this.description = desciption;
            this.publishDate = publishDate;
            this.technology = technology;
            this.functions = functions;
            this.requirements = requirements;
            this.idCreator = idCreator;
            this.isFavorite = false;
            this.tsstatus = EThesisStatus.Published;
            this.status = tsstatus.ToString();
            this.idInstructor = idInstructor;
        }
        public Thesis(string idThesis, string topic, EField field, ELevel level, int maxMembers, string desciption, DateTime publishDate, 
                        string technology, string functions, string requirements, string idCreator, bool isFavorite, EThesisStatus status, string idInstructor)
        {
            this.idThesis = idThesis;
            this.topic = topic;
            this.tsfield = field;
            this.field = tsfield.ToString();
            this.tslevel = level;
            this.level = tslevel.ToString();
            this.maxMembers = maxMembers;
            this.description = desciption;
            this.publishDate = publishDate;
            this.technology = technology;
            this.functions = functions;
            this.requirements = requirements;
            this.idCreator = idCreator;
            this.isFavorite = isFavorite;
            this.tsstatus = status;
            this.status = tsstatus.ToString();
            this.idInstructor = idInstructor;
        }

        #endregion

        #region THESIS PROPERTIES

        [Key]
        public string IdThesis
        {
            get { return idThesis; }
            set { idThesis = value; }
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public string Field
        {
            get { return field; }
            set 
            { 
                field = value;
                tsfield = myProcess.GetEnumFromDisplayName<EField>(field);
            }
        }
        [NotMapped]
        public EField OnField
        {
            get { return tsfield; }
            set 
            { 
                tsfield = value; 
                field = tsfield.ToString(); 
            }
        }
        public string Level
        {
            get { return level; }
            set 
            { 
                level = value;
                tslevel = myProcess.GetEnumFromDisplayName<ELevel>(level);
            }
        }
        [NotMapped]
        public ELevel OnLevel
        {
            get { return tslevel; }
            set 
            { 
                tslevel = value;
                level = tslevel.ToString();
            }
        }
        public int MaxMembers
        {
            get { return maxMembers; }
            set { maxMembers = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        public string Technology
        {
            get { return technology; }
            set { technology = value; }
        }
        public string Functions
        {
            get { return functions; }
            set { functions = value; }
        }
        public string Requirements
        {
            get { return requirements; }
            set { requirements = value; }
        }
        public string IdCreator
        {
            get { return idCreator; }
            set { idCreator = value; }
        }
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; }
        }
        public string Status
        {
            get { return status; }
            set 
            { 
                status = value;
                tsstatus = myProcess.GetEnumFromDisplayName<EThesisStatus>(status);
            }
        }
        [NotMapped]
        public EThesisStatus OnStatus
        {
            get { return tsstatus; }
            set 
            { 
                tsstatus = value;
                status = tsstatus.ToString();
            }
        }
        public string IdInstructor
        {
            get { return idInstructor; }
            set { idInstructor = value; }
        }

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckTopic()
        {
            return this.topic != string.Empty;
        }
        public bool CheckDesription()
        {
            return this.description != string.Empty;
        }
        public bool CheckTechnology()
        {
            return this.technology != string.Empty;
        }
        public bool CheckFunctions()
        {
            return this.functions != string.Empty;
        }
        public bool CheckRequirements()
        {
            return this.requirements != string.Empty;
        }
        public bool CheckInstructor()
        {
            return this.idInstructor != string.Empty;
        }

        #endregion

        #region FUNCTIONS

        public Color GetStatusColor()
        {
            switch (this.tsstatus)
            {
                case EThesisStatus.Registered:
                    return Color.FromArgb(255, 87, 87);
                case EThesisStatus.Processing:
                    return Color.FromArgb(94, 148, 255);
                case EThesisStatus.Completed:
                    return Color.FromArgb(45, 237, 55);
                case EThesisStatus.NotCompleted:
                    return Color.FromArgb(255, 87, 87);
                default:
                    return Color.Gray;
            }
        }
        public int GetPriority()
        {
            switch (this.tsstatus)
            {
                case EThesisStatus.Registered:
                    return 0;
                case EThesisStatus.Processing:
                    return 1;
                case EThesisStatus.Published:
                    return 2;
                case EThesisStatus.Completed:
                    return 3;
                default:
                    return int.MaxValue;
            }
        }

        #endregion

    }
}
