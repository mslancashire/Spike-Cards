using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public class TemplateBasedCardReader : BaseCardReader
    {
        public TemplateBasedCardReader(List<Card> cardsToRead, String templateFileName)
            : base(cardsToRead)
        {
            this.SetTemplate(templateFileName);
        }

        private String cardTemplate;

        public override String DisplayCards()
        {
            throw new NotImplementedException();
        }

        public String CardTemplate
        {
            get { return this.cardTemplate; }
            protected set { this.cardTemplate = value; }
        }

        public void SetTemplate(String templateFileName)
        {
            String resourceTemplate = "Domain.Cards.LayoutTemplates." + templateFileName;

            using (Stream templateStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceTemplate))
            using (StreamReader templateReader = new StreamReader(templateStream))
            {
                this.cardTemplate = templateReader.ReadToEnd();
            }
        }
    }
}
