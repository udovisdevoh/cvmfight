using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CvmFight
{
    class RayTracer
    {
        #region Fields
        private int fov;

        private int howManyColumn;

        private double rayDistanceResolution = 0.01;

        private List<RayTracerPoint> pointList;

        private Optics optics = new Optics();
        #endregion

        #region Constructor
        public RayTracer(int howManyColumn, int fov)
        {
            this.fov = fov;
            this.howManyColumn = howManyColumn;
            pointList = new List<RayTracerPoint>(this.howManyColumn);
            for (int i = 0; i < howManyColumn; i++)
                pointList.Add(new RayTracerPoint());
        }
        #endregion

        #region Public Methods
        public List<RayTracerPoint> Trace(AbstractSprite viewerSprite, AbstractMap map)
        {
            double startAngle = viewerSprite.AngleDegree - fov / 2;
            double endAngle = viewerSprite.AngleDegree + fov / 2;
            double angleResolution = fov / howManyColumn;

            startAngle = optics.FixAngleDegree(startAngle);
            endAngle = optics.FixAngleDegree(endAngle);

            int pointCounter = 0;
            for (double angle = startAngle; pointCounter < howManyColumn; angle += angleResolution)
            {
                angle = optics.FixAngleDegree(angle);

                pointList[pointCounter].Trace(viewerSprite, angle, rayDistanceResolution, map);

                pointCounter++;
            }

            return pointList;
        }
        #endregion
    }
}
