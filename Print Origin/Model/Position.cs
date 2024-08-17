namespace Print_Origin.Model
{
    public class Position
    {              
        public enum Placement
        {
            AlignUpperLeft, 
            AlignUpper, 
            AlignUpperRight, 
            AlignLeft, 
            AlignCenter, 
            AlignRight, 
            AlignLowerLeft, 
            AlignLower, 
            AlignLowerRight, 
            CustomAlignment
        }       

        public static Parameters.OriginPoints SetPosition(double[] dimensions, Placement placement)
        {
            // [0] == Stock width, [1] == Stock Height, [2] == Print width, [3] == Print height, [4] == Horizontal, [5] == Vertical, [6] == Offset
            
            switch (placement)
            {
                case Placement.AlignUpperLeft:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) - dimensions[6], 
                        (dimensions[1] - dimensions[3]) - dimensions[6]
                        );

                case Placement.AlignUpper:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) / 2, 
                        dimensions[1] - dimensions[3] - dimensions[6]
                        );

                case Placement.AlignUpperRight:
                    return new Parameters.OriginPoints(
                        dimensions[6], 
                        (dimensions[1] - dimensions[3]) - dimensions[6]
                        );

                case Placement.AlignLeft:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) - dimensions[6], 
                        (dimensions[1] - dimensions[3]) / 2
                        );

                case Placement.AlignCenter:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) / 2, 
                        (dimensions[1] - dimensions[3]) / 2
                        );                    

                case Placement.AlignRight:                   
                    return new Parameters.OriginPoints(
                        dimensions[6], 
                        (dimensions[1] - dimensions[3]) / 2
                        );

                case Placement.AlignLowerLeft:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) - dimensions[6],
                        dimensions[6]
                        );

                case Placement.AlignLower:                    
                    return new Parameters.OriginPoints(
                        (dimensions[0] - dimensions[2]) / 2,
                        dimensions[6]
                        );

                case Placement.AlignLowerRight:                    
                    return new Parameters.OriginPoints(
                        dimensions[6], 
                        dimensions[6]
                        );

                case Placement.CustomAlignment:                    
                    return new Parameters.OriginPoints(
                        dimensions[4], 
                        dimensions[5]
                        );

                default:
                    return new Parameters.OriginPoints(
                        dimensions[6], 
                        dimensions[6]
                        );
            }       
        }     
    }
}
