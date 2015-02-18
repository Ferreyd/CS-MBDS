using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCM.BuisinessLayer
{
    public partial class QCM
    {
        public QCM(string nom)
        {
            this.Nom = nom;
            this.Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public HashSet<Question> Questions { get; set; }


        /// <summary>
        /// Exemple de substitution de méthode, car ToString est déjà défini dans la classe Objet
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder strbld = new StringBuilder();
            strbld.AppendLine(this.Nom);
            foreach (var item in this.Questions)
            {
                strbld.AppendLine(item.Phrase);
            };
            return strbld.ToString();
        }
    }

    public partial class Question
    {
        public Question()
        {
            this.Propositions = new HashSet<Proposition>();
        }

        public int Id { get; set; }
        public string Phrase { get; set; }
        public int IdQcm { get; set; }

        public HashSet<Proposition> Propositions { get; set; }
    }

    public partial class Proposition
    {

        public int Id { get; set; }
        public string Phrase { get; set; }
        public bool EstJuste { get; set; }
        public int IdQuestion { get; set; }
        public Reponse Reponse { get; set; }
    }

    public partial class Reponse
    {
        public int Id { get; set; }
        public int IdProposition { get; set; }
        public bool EstJuste { get; set; }
    }



}
