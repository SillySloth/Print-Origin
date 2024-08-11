using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Origin.Model
{
    public class Position
    {              
        public enum Placement
        {
            UpperLeft, Upper, UpperRight, Left, Center, Right, LowerLeft, Lower, LowerRight, Custom
        }       

        public static Parameters.OriginPoints SetPosition(double[] dimensions, Placement placement)
        {
            // [0] == Stock width, [1] == Stock Height, [2] == Print width, [3] == Print height, [4] == Print height, [5] == Print height  

            double horizontal = 0, vertical = 0;

            switch (placement)
            {
                case Placement.UpperLeft:
                    horizontal = (dimensions[0] - dimensions[2]);
                    vertical = (dimensions[1] - dimensions[3]);
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.Upper:
                    horizontal = (dimensions[0] - dimensions[2]) / 2;
                    vertical = (dimensions[1] - dimensions[3]);
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.UpperRight:
                    horizontal = 0;
                    vertical = (dimensions[1] - dimensions[3]);
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.Left:
                    horizontal = (dimensions[0] - dimensions[2]);
                    vertical = (dimensions[1] - dimensions[3]) / 2;
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.Center:
                    horizontal = (dimensions[0] - dimensions[2]) / 2;
                    vertical = (dimensions[1] - dimensions[3]) / 2;
                    return new Parameters.OriginPoints(horizontal, vertical);                    

                case Placement.Right:
                    horizontal = 0;
                    vertical = (dimensions[1] - dimensions[3]) / 2;
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.LowerLeft:
                    horizontal = (dimensions[0] - dimensions[2]);
                    vertical = 0;
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.Lower:
                    horizontal = (dimensions[0] - dimensions[2]) / 2;
                    vertical = 0;
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.LowerRight:
                    horizontal = 0;
                    vertical = 0;
                    return new Parameters.OriginPoints(horizontal, vertical);

                case Placement.Custom:                    
                    return new Parameters.OriginPoints(dimensions[4], dimensions[5]);
            }          

            return new Parameters.OriginPoints(0, 0);

        }

    }
}
