using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class Optics
    {
        public double FixAngleDegree(double angle)
        {
	        while (angle > 360)
		        angle -= 360;
	        while (angle < 0)
		        angle += 360;
        		
	        return angle;
        }
    }
}
