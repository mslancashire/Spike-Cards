using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public class LayoutSettings
    {
        public LayoutSettings()
            : this(80, 5)
        { }

        public LayoutSettings(Int32 numberOfCharactersPerLine, Int32 numberOfCardsPerLine)
        {
            this.numberOfCharactersPerLine = numberOfCharactersPerLine;
            this.numberOfCardsPerLine = numberOfCardsPerLine;
            this.startOfLine = '#';
            this.endOfLine = '#';
            this.cardBorderTop = '=';
            this.cardBorderBottom = '=';
            this.cardBorderLeft = '|';
            this.cardBorderRight = '|';
            this.cardBorderTopLeft = '=';
            this.cardBorderTopRight = '=';
            this.cardBorderBottomLeft = '=';
            this.cardBorderBottomRight = '=';
            this.cardWhitespace = ' ';
        }

        public static LayoutSettings GetDefaultLayout()
        {
            return GetDefaultLayout(80, 5);
        }

        public static LayoutSettings GetDefaultLayout(Int32 numberOfCharactersPerLine, Int32 numberOfCardsPerLine)
        {
            return new LayoutSettings(numberOfCharactersPerLine, numberOfCardsPerLine);
        }

        public static LayoutSettings GetBoxedLayout()
        {
            return GetBoxedLayout(80, 5);
        }

        public static LayoutSettings GetBoxedLayout(Int32 numberOfCharactersPerLine, Int32 numberOfCardsPerLine)
        {
            return new LayoutSettings
            {
                NumberOfCharactersPerLine = numberOfCharactersPerLine,
                NumberOfCardsPerLine = numberOfCardsPerLine,
                CardBorderTop = '─',
                CardBorderBottom = '─',
                CardBorderLeft = '│',
                CardBorderRight = '│',
                CardBorderTopLeft = '┌',
                CardBorderTopRight = '┐',
                CardBorderBottomLeft = '└',
                CardBorderBottomRight = '┘'
            };
        }

        public static LayoutSettings GetDoubleBoxedLayout()
        {
            return GetDoubleBoxedLayout(80, 5);
        }

        public static LayoutSettings GetDoubleBoxedLayout(Int32 numberOfCharactersPerLine, Int32 numberOfCardsPerLine)
        {
            return new LayoutSettings
            {
                NumberOfCharactersPerLine = numberOfCharactersPerLine,
                NumberOfCardsPerLine = numberOfCardsPerLine,
                CardBorderTop = '═',
                CardBorderBottom = '═',
                CardBorderLeft = '║',
                CardBorderRight = '║',
                CardBorderTopLeft = '╔',
                CardBorderTopRight = '╗',
                CardBorderBottomLeft = '╚',
                CardBorderBottomRight = '╝'
            };
        }

        private Int32 numberOfCharactersPerLine;
        private Int32 numberOfCardsPerLine;
        private Char startOfLine;
        private Char endOfLine;
        private Char cardBorderTop;
        private Char cardBorderBottom;
        private Char cardBorderLeft;
        private Char cardBorderRight;
        private Char cardBorderTopLeft;
        private Char cardBorderTopRight;
        private Char cardBorderBottomLeft;
        private Char cardBorderBottomRight;
        private Char cardWhitespace;

        public Int32 NumberOfCharactersPerLine
        {
            get { return this.numberOfCharactersPerLine; }
            set { this.numberOfCharactersPerLine = value; }
        }

        public Int32 NumberOfCardsPerLine
        {
            get { return this.numberOfCardsPerLine; }
            set { this.numberOfCardsPerLine = value; }
        }

        public Int32 NumberOfCharactersPerCard
        {
            get { return this.NumberOfCharactersPerLine / this.NumberOfCardsPerLine; }
        }

        public Int32 NumberOfCharactersInternalToCard
        {
            get { return this.NumberOfCharactersPerCard - 2; }
        }

        public Char StartOfLine
        {
            get { return this.startOfLine; }
            set { this.startOfLine = value; }
        }

        public Char EndOfLine
        {
            get { return this.endOfLine; }
            set { this.startOfLine = value; }
        }

        public Char CardBorderTop
        {
            get { return this.cardBorderTop; }
            set { this.cardBorderTop = value; }
        }

        public Char CardBorderBottom
        {
            get { return this.cardBorderBottom; }
            set { this.cardBorderBottom = value; }
        }

        public Char CardBorderLeft
        {
            get { return this.cardBorderLeft; }
            set { this.cardBorderLeft = value; }
        }

        public Char CardBorderRight
        {
            get { return this.cardBorderRight; }
            set { this.cardBorderRight = value; }
        }

        public Char CardBorderTopLeft
        {
            get { return this.cardBorderTopLeft; }
            set { this.cardBorderTopLeft = value; }
        }

        public Char CardBorderTopRight
        {
            get { return this.cardBorderTopRight; }
            set { this.cardBorderTopRight = value; }
        }

        public Char CardBorderBottomLeft
        {
            get { return this.cardBorderBottomLeft; }
            set { this.cardBorderBottomLeft = value; }
        }

        public Char CardBorderBottomRight
        {
            get { return this.cardBorderBottomRight; }
            set { this.cardBorderBottomRight = value; }
        }

        public Char CardWhitespace
        {
            get { return this.cardWhitespace; }
            set { this.cardWhitespace = value; }
        }
    }
}
