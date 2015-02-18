using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCM.BuisinessLayer.Correcteurs;

namespace QCM.BuisinessLayer
{
    namespace Correcteurs
    {
        public interface ICorrecteur
        {
            decimal Noter(QCM qcm);
        }

        public abstract class CorrecteurBase : ICorrecteur
        {

            public abstract decimal Noter(QCM qcm);


        }
        public class CorrecteurCalculMoyenne : CorrecteurBase
        {
            public override decimal Noter(QCM qcm)
            {
                if (qcm.Questions == null || qcm.Questions.Count == 0)
                {
                    throw new CorrectionImpossibleException("Le Qcm ne contient pas de questions!");
                }

                var poidsGlobal = 0;
                var poidsReussite = 0;
                foreach (var question in qcm.Questions)
                {
                    foreach (var proposition in question.Propositions)
                    {
                        poidsGlobal++;
                        if (proposition.Reponse != null)
                        {
                            if (proposition.EstJuste == proposition.Reponse.EstJuste)
                            {
                                poidsReussite++;
                            }
                        }
                    }
                };
                return poidsReussite / poidsGlobal;
            }
        }

        public class CorrecteurToutRien : CorrecteurBase
        {
            public override decimal Noter(QCM qcm)
            {
                if (qcm.Questions == null || qcm.Questions.Count == 0)
                {
                    throw new CorrectionImpossibleException("Le Qcm ne contient pas de questions!");
                }

                var poidsGlobal = 0;
                var poidsReussite = 0;
                foreach (var question in qcm.Questions)
                {
                    poidsGlobal++;
                    var toutJuste = true;
                    foreach (var proposition in question.Propositions)
                    {
                        if (proposition.Reponse != null)
                        {
                            if (proposition.EstJuste != proposition.Reponse.EstJuste)
                            {
                                //A la premiere erreur on sort de la boucle
                                toutJuste = false;
                                break;
                            }
                        }
                    }
                    if (toutJuste) poidsReussite++;
                };
                return poidsReussite / poidsGlobal;
            }


        }
        public class CorrectionImpossibleException : ApplicationException
        {
            public CorrectionImpossibleException(string message)
                : base(message)
            { }
        }
    }

   
   
}
