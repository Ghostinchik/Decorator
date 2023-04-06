using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Декоратор
{
    internal class Decorator
    {
        public abstract class CardComponentBase
        {
            public abstract int Width { get; }
            public abstract int Height { get; }

            public abstract void Draw(Graphics graphics);
        }

        public class CardComponent : CardComponentBase
        {
            public override int Width { get; }
            public override int Height { get; }

            public CardComponent(int width, int height)
            {
                Width = width;
                Height = height;
            }

            public override void Draw(Graphics graphics)
            {
                // Draw a basic card with white background
                graphics.FillRectangle(Brushes.White, 0, 0, Width, Height);
                graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            }
        }

        public abstract class CardDecorator : CardComponentBase
        {
            protected CardComponentBase _card;

            public CardDecorator(CardComponentBase card)
            {
                _card = card;
            }
        }

        public class BorderDecorator : CardDecorator
        {
            private Color _borderColor;
            private int _borderWidth;

            public BorderDecorator(CardComponentBase card, Color borderColor, int borderWidth) : base(card)
            {
                _borderColor = borderColor;
                _borderWidth = borderWidth;
            }

            public override int Width
            {
                get { return _card.Width + _borderWidth * 2; }
            }

            public override int Height
            {
                get { return _card.Height + _borderWidth * 2; }
            }

            public override void Draw(Graphics graphics)
            {
                // Draw the border
                graphics.FillRectangle(new SolidBrush(_borderColor), 0, 0, Width, Height);

                // Draw the decorated card inside the border
                _card.Draw(graphics);
            }
        }

        public class ImageDecorator : CardDecorator
        {
            private Image _image;

            public ImageDecorator(CardComponentBase card, Image image) : base(card)
            {
                _image = image;
            }

            public override int Width
            {
                get { return _card.Width; }
            }

            public override int Height
            {
                get { return _card.Height; }
            }

            public override void Draw(Graphics graphics)
            {
                // Draw the decorated card first
                _card.Draw(graphics);

                // Draw the image on top of the card
                graphics.DrawImage(_image, 0, 0, Width, Height);
            }
        }
    }
}
