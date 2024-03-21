using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
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

    #endregion

    public class Thesis
    {
        #region THESIS ATTRIBUTES

        private string idThesis;
        private string topic;
        private EField field;
        private ELevel level;
        private int maxMembers;
        private string description;
        private string reference;
        private DateTime publishDate;
        private string technology;
        private string functions;
        private string requirements;
        private string idCreator;
        private bool isFavorite;
        private int numPending;
        private int numAccepted;
        private int numCompleted;

        #endregion

        #region THESIS CONTRUCTOR

        public Thesis()
        {
            this.idThesis = "xxx";
            this.topic = string.Empty;
            this.field = EField.SoftwareDevelopment;
            this.level = ELevel.Easy;
            this.maxMembers = 0;
            this.description = string.Empty;
            this.reference = string.Empty;
            this.publishDate = DateTime.Now;
            this.technology = string.Empty;
            this.functions = string.Empty;
            this.requirements = string.Empty;
            this.idCreator = string.Empty;
            this.isFavorite = false;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
        }

        public Thesis(string topic, EField field, ELevel level, int maxMembers, string desciption, string reference,
                        DateTime publishDate, string technology, string functions, string requirements)
        {
            this.idThesis = MyProcess.GenIDClassify(EClassify.Thesis);
            this.topic = topic;
            this.field = field;
            this.level = level;
            this.maxMembers = maxMembers;
            this.description = desciption;
            this.reference = reference;
            this.publishDate = publishDate;
            this.technology = technology;
            this.functions = functions;
            this.requirements = requirements;
            this.idCreator = string.Empty;
            this.isFavorite = false;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
        }

        public Thesis(string idThesis, string topic, EField field, ELevel level, int maxMembers, string desciption, string reference,
                        DateTime publishDate, string technology, string functions, string requirements,
                        string idCreator, bool isFavorite, int numPending, int numAccepted, int numCompleted)
        {
            this.idThesis = idThesis;
            this.topic = topic;
            this.field = field;
            this.level = level;
            this.maxMembers = maxMembers;
            this.description = desciption;
            this.reference = reference;
            this.publishDate = publishDate;
            this.technology = technology;
            this.functions = functions;
            this.requirements = requirements;
            this.idCreator = idCreator;
            this.isFavorite = isFavorite;
            this.numPending = numPending;
            this.numAccepted = numAccepted;
            this.numCompleted = numCompleted;
        }

        #endregion

        #region THESIS PROPERTIES

        public string IdThesis
        {
            get { return this.idThesis; }
        }
        public string Topic
        {
            get { return this.topic; }
        }
        public EField Field
        {
            get { return this.field; }
        }
        public ELevel Level
        {
            get { return this.level; }
        }
        public int MaxMembers
        {
            get { return this.maxMembers; }
        }
        public string Description
        {
            get { return this.description; }
        }
        public string Reference
        {
            get { return this.reference; }
        }
        public DateTime PublishDate
        {
            get { return this.publishDate; }
        }
        public string Technology
        {
            get { return this.technology; }
        }
        public string Functions
        {
            get { return this.functions; }
        }
        public string Requirements
        {
            get { return this.requirements; }
        }
        public string IdCreator
        {
            get { return this.idCreator; }
        }
        public bool IsFavorite
        {
            get { return this.isFavorite; }
            set { this.isFavorite = value; }
        }
        public int NumPending
        {
            get { return this.numPending; }
        }
        public int NumAccepted
        {
            get { return this.numAccepted; }
        }
        public int NumCompleted
        {
            get { return this.numCompleted; }
        }

        #endregion


    }
}
