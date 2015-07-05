using System;

public class Size
{
    private double width, height;
    
    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public static Size GetRotatedSize(Size size, double angleThatTheFigureWillBeRotaed)
    {
        var rotatedFigureWidth = 
            (Math.Abs(Math.Cos(angleThatTheFigureWillBeRotaed)) * size.width) + 
            (Math.Abs(Math.Sin(angleThatTheFigureWillBeRotaed)) * size.height);

        var rotatedFigureHeight = 
            (Math.Abs(Math.Sin(angleThatTheFigureWillBeRotaed)) * size.width) + 
            (Math.Abs(Math.Cos(angleThatTheFigureWillBeRotaed)) * size.height);

        return new Size(rotatedFigureWidth, rotatedFigureHeight);
    }
}