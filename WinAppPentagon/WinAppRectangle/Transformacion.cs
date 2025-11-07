using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppRectangle
{
    public class Punto
    {
        public double x;
        public double y;
    }
    class Transformacion
    {
        
        public void Rotation(float tetha)
        {

        }

        public void Traslation()
        {

        }

        public float Scale(float radio, int escala)
        {
            float factor = escala / 50f;
            float scaleMultiplier = 1.0f + (factor * 0.5f);
            return radio * scaleMultiplier;
        }
    }
}
