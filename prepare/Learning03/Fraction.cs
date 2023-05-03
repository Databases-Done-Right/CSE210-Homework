public class Fraction {
        private int _top = 1;
        private int _bottom = 1;

        public Fraction() {
        }
        public Fraction(int wholeNumber) {
            _top = wholeNumber;
            _bottom = 1;
        }
        public Fraction(int top, int bottom) {
            _top = top;
            _bottom = bottom;
        }

        public int GetBottom() {
            return _bottom;
        }

        public double GetDecimalValue() {
            double tbr = (double)_top / (double)_bottom;
            return tbr;
        }

        public string GetFraction() {
            string tbr = _top + " / " + _bottom;
            return tbr;
        }

        public int GetTop() {
            return _top;
        }

        public void SetBottom(int bottom) {
            _bottom = bottom;
        }

        public void SetTop(int top) {
            _top = top;
        }

    }