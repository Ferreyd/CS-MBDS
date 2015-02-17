using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCM.BuisinessLayer
{
    public class QCM
    {
        /// <summary>
        /// Propriété pour la liste de questions
        /// </summary>
        public List<Question> Questions { get; set; }
        public int id { get; set; }
        public String Nom { get; set; }

        /// <summary>
        /// Constructeur de la classe QCM
        /// </summary>
        /// <param name="nom">Nom du QCM</param>
        /// <param name="questions">Liste de questions</param>
        public QCM(String nom)
        {
            this.Nom = nom;
            this.Questions = new List<Question>();
        }

        public String ToString()
        {
            return "QCM : id = " + this.id + " Nom = " + this.Nom + " NBQuestions = " +this.Questions.Count;
        }
    }

    public class Question
    {
        public List<Proposition> Propositions { get; set; }
        public int Id { get; set; }

        public QCM Qcm { get; set; }

        public String Phrase { get; set; }

        public Question()
        {
            this.Propositions = new List<Proposition>();
        }
    }

    public class Proposition
    {
        public List<Reponse> Reponses { get; set; }
        public Boolean EstJuste { get; set; }
        public int Id { get; set; }
        public Question Question { get; set; }
        public String Phrase { get; set; }

        public Proposition()
        {
            this.Reponses = new List<Reponse>();
        }

    }

    public class Reponse
    {
        public Boolean EstJuste { get; set; }
        public int Id { get; set; }
        public Proposition Proposition { get; set; }
    }



}
