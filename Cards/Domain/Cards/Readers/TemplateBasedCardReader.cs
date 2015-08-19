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
        public TemplateBasedCardReader(List<Card> cardsToRead, LayoutSettings layoutSetting, String templateFileName)
            : base(cardsToRead, layoutSetting)
        {
            this.SetTemplate(templateFileName);
            this.outputLines = new Dictionary<Int32, String>();
        }

        private String cardTemplate;
        private Dictionary<Int32, String> outputLines;

        public String ForceTextLength(Int32 number)
        {
            return this.ForceTextLength(number.ToString(), 2, '0', false);
        }

        public String ForceTextLength(String text, Int32 textLength)
        {
            return this.ForceTextLength(text, textLength, this.LayoutSettings.CardWhitespace, true);
        }

        public String ForceTextLength(String text, Int32 textLength, char pad, Boolean padRight)
        {
            String outputText = "";

            if (text.Length > textLength)
            {
                outputText = text.Substring(0, textLength);
            }
            else
            {
                if (padRight)
                {
                    outputText = text.PadRight(textLength, pad);
                }
                else
                {
                    outputText = text.PadLeft(textLength, pad);
                }
            }

            return outputText;
        }

        public String ReadCard(Card card)
        {
            String cardOutput = this.CardTemplate;
            cardOutput = cardOutput.Replace("{Name}", this.ForceTextLength(card.Name, this.LayoutSettings.NumberOfCharactersInternalToCard - 3));
            cardOutput = cardOutput.Replace("{Cost}", this.ForceTextLength(card.Cost));
            cardOutput = cardOutput.Replace("{Health}", this.ForceTextLength(card.Health));
            cardOutput = cardOutput.Replace("{Attack}", this.ForceTextLength(card.Attack));
            cardOutput = cardOutput.Replace("{Middle}", this.CreateCardMiddle(card));

            return cardOutput;
        }

        public void AddCardToOuputBatch(String cardOutput, List<String> outputBatch)
        {
            if (cardOutput == null)
            {
                throw new ArgumentNullException("cardOutput");
            }
            if (outputBatch == null)
            {
                throw new ArgumentNullException("outputBatch");
            }

            using (StringReader outputReader = new StringReader(cardOutput))
            {
                Int32 lineIndex = 0;

                while (true)
                {
                    String outputLine = outputReader.ReadLine();
                    if (outputLine == null)
                    {
                        break;
                    }

                    if (outputBatch.Count <= lineIndex)
                    {
                        outputBatch.Add("");
                    }

                    outputBatch[lineIndex] += outputLine;

                    lineIndex++;
                }
            }
        }

        public override String DisplayCards()
        {
            Dictionary<Int32, List<String>> cardsInBacthes = new Dictionary<Int32, List<String>>();
            var batchNumber = 1;
            var cardNumber = 1;

            // read cards to list
            foreach (Card card in this.CardsToRead)
            {
                // create the card output
                String cardOutput = this.ReadCard(card);

                // check if batch exsits
                if (!cardsInBacthes.ContainsKey(batchNumber))
                {
                    cardsInBacthes[batchNumber] = new List<String>();
                }

                // add card to batch
                this.AddCardToOuputBatch(cardOutput, cardsInBacthes[batchNumber]);

                // do we need to push the batch number on
                if (cardNumber % this.LayoutSettings.NumberOfCardsPerLine == 0)
                {
                    batchNumber++;
                }

                cardNumber++;
            }

            var cardOutputBuilder = new StringBuilder();
            foreach (List<String> cardOutputBatch in cardsInBacthes.Values)
            {
                foreach (String cardLine in cardOutputBatch)
                {
                    cardOutputBuilder.AppendLine(cardLine);
                }
            }            

            return cardOutputBuilder.ToString();
        }

        public String CreateCardMiddle(Card card)
        {
            Int32 numberOfMiddleLines = 6;
            Int32 currentLineNumber = 1;
            String middleText = card.Description;
            String middleOfCard = "";

            while (true)
            {
                if (currentLineNumber > numberOfMiddleLines)
                {
                    break;
                }

                middleOfCard += this.LayoutSettings.CardBorderLeft;

                // if we have no text then create a blank middle line.
                if (middleText.Length == 0)
                {
                    middleOfCard += this.ForceTextLength("", this.LayoutSettings.NumberOfCharactersInternalToCard);

                }
                else
                {
                    middleOfCard += this.ForceTextLength(middleText, this.LayoutSettings.NumberOfCharactersInternalToCard);
                    Int32 chopAt = this.LayoutSettings.NumberOfCharactersInternalToCard;
                    chopAt = (chopAt > middleText.Length) ? middleText.Length : chopAt;
                    middleText = middleText.Remove(0, chopAt);
                }

                middleOfCard += this.LayoutSettings.CardBorderRight;

                if (currentLineNumber < numberOfMiddleLines)
                {
                    middleOfCard += Environment.NewLine;
                }

                currentLineNumber++;
            }

            return middleOfCard;
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
