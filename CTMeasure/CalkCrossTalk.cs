using OpenCvSharp;

namespace CTMeasure
{
    internal class CalkCrossTalk
    {
        public class CTRresults
        {
            public double ave_b { get; set; }
            public double ave_w { get; set; }
            public double ave_bw { get; set; }
            public double ctr { get; set; }
        }

        public CalkCrossTalk()
        {
        }

        public CTRresults calcCTR(Rect _roi, Mat _black, Mat _white, Mat _bw) 
        {
            double px_v_b = 0, px_v_w = 0, px_v_bw = 0;
            int px_num = 0;

            for (int y = _roi.Top; y < _roi.Bottom; y++)
            {
                for (int x = _roi.Left; x < _roi.Right; x++)
                {
                    px_v_b += _black.At<byte>(y, x);
                    px_v_w += _white.At<byte>(y, x);
                    px_v_bw += _bw.At<byte>(y, x);
                    px_num++;
                }
            }

            double _ctr = 0;

            double b = px_v_b / px_num;
            double w = px_v_w / px_num;
            double bw = px_v_bw / px_num;

            if (px_v_w != px_v_b)
                _ctr = (bw - b) / (w - b) * 100.0;

            return new CTRresults
            {
                ave_b = b,
                ave_w = w,
                ave_bw = bw,
                ctr = _ctr
            };
        }   
    }
}
