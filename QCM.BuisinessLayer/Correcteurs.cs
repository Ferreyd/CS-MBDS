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

        abstract public class CorrecteurBase : ICorrecteur
        {
            public decimal Noter(QCM qcm)
            {
                int nbRepJustes = 0;
                int nbPropositions = 0;
                decimal res = -1;
                try
                {
                    foreach (Question q in qcm.Questions)
                    {
                        foreach (Proposition p in q.Propositions)
                        {
                            if (p.EstJuste)
                            {
                                nbRepJustes++;
                            }
                            nbPropositions++;
                        }
                        res = nbRepJustes / nbPropositions;
                    }
                }
                catch (ApplicationException e)
                {
                    Console.WriteLine(e.Source);
                    Console.WriteLine("Le QCM est vide il n'y a pas de réponses.");
                }
           
                return res;
            }
        }

        public class CorrecteurCalculMoyenne : CorrecteurBase
        {
            public CorrecteurCalculMoyenne() { }
            decimal Noter(QCM qcm)
            {
                int nbRepJustes = 0;
                int nbPropositions = 0;
                foreach (Question q in qcm.Questions)
                {
                    foreach (Proposition p in q.Propositions)
                    {
                        if (p.EstJuste)
                        {
                            nbRepJustes++;
                        }
                        nbPropositions++;
                    }
                }

                return nbRepJustes / nbPropositions;
            }
        }
    }

   
   
}
