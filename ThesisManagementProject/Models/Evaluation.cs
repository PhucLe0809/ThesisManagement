using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Evaluation
    {
        private MyProcess myProcess = new MyProcess();

        #region EVALUATION ATTRIBUTES

        private string idEvaluation;
        private string idTask;
        private string idPeople;
        private string content;
        private int contribute;
        private float scores;
        private DateTime created;
        private bool isEvaluated;

        #endregion

        #region EVALUATION CONTRUCTOR

        public Evaluation()
        {
            this.idEvaluation = string.Empty;
            this.idTask = string.Empty;
            this.idPeople = string.Empty;
            this.content = string.Empty;
            this.scores = 0;
            this.scores = 0.0F;
            this.created = DateTime.Now;
            this.isEvaluated = false;
        }
        public Evaluation(string idEvaluation, string idTask, string idPeople, string content, int contribute, float scores, 
                            DateTime created, bool isEvaluated)
        {
            this.idEvaluation = idEvaluation;
            this.idTask = idTask;
            this.idPeople = idPeople;
            this.content = content;
            this.contribute = contribute;
            this.scores = scores;
            this.created = created;
            this.isEvaluated = isEvaluated;
        }
        public Evaluation(string idTask, string idPeople, string content, int contribute, float scores, DateTime created, bool isEvaluated)
        {
            this.idEvaluation = myProcess.GenIDClassify(EClassify.Evaluation);
            this.idTask = idTask;
            this.idPeople = idPeople;
            this.content = content;
            this.contribute = contribute;
            this.scores = scores;
            this.created = created;
            this.isEvaluated = isEvaluated;
        }

        #endregion

        #region EVALUATION PROPERTIES

        public string IdEvaluation
        {
            get { return this.idEvaluation; }
        }
        public string IdTask
        { 
            get { return this.idTask; } 
        }
        public string IdPeople
        { 
            get { return this.idPeople; } 
        }
        public string Content
        {
            get { return this.content; } 
            set { this.content = value; }
        }
        public int Contribute
        { 
            get { return this.contribute; }
            set { this.contribute = value; }
        }
        public float Scores
        { 
            get { return this.scores; } 
            set { this.scores = value; }
        }
        public DateTime Created
        {
            get { return this.created; }
        }
        public bool IsEvaluated
        {
            get { return this.isEvaluated; }
        }

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckContent()
        {
            return this.content != string.Empty;
        }
        public bool CheckContribute()
        {
            return this.contribute >= 0 && this.contribute <= 100;
        }
        public bool CheckScores()
        {
            return this.scores >= 0.0F && this.scores <= 10.0F;
        }

        #endregion

        #region FUNCTIONS

        public Color GetStatusColor()
        {
            if (this.isEvaluated) return Color.FromArgb(45, 237, 55);
            else return Color.Gray;
        }

        #endregion

    }
}
