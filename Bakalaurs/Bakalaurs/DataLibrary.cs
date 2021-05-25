using Bakalaurs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Bakalaurs
{
    public class DataLibrary
    {
        // Design FilePath Storage
        private static string designFilePath;
        public static string DesignFilePath
        {
            get { return designFilePath; }
            set { designFilePath = value; }
        }

        public void setDesignFilePath(string filePath)
        {
            DesignFilePath = filePath;
        }

        public string getDesignFilePath()
        {
            return DesignFilePath;
        }

        // Element Storage
        private static string element;
        public static string Element
        {
            get { return element; }
            set { element = value; }
        }

        public void setElement(string element)
        {
            Element = element;
        }

        public string getElement()
        {
            return Element;
        }

        // Line Storage
        private static Line savedLine;
        public static Line SavedLine
        {
            get { return savedLine; }
            set { savedLine = value; }
        }

        public void drawLine(int x1, int y1, int x2, int y2, Canvas canvas)
        {
            Line line = new Line();
            Brush brush = new SolidColorBrush(Colors.Red);

            line.Stroke = brush;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = 1;
            line.SnapsToDevicePixels = true;
            line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            canvas.Children.Add(line);

            SavedLine = line;
        }

        // Best Position Storage
        private static int bestPosition;
        public static int BestPosition
        {
            get { return bestPosition; }
            set { bestPosition = value; }
        }
        public double calculateLocationTime(List<Vertice> verticeList, Rectangle rectangle, Canvas canvas)
        {
            BestPosition = getBestPosition(verticeList);
            switch (verticeList[BestPosition].Location)
            {
                case "Top-Left":
                    drawLine(verticeList[BestPosition].X, verticeList[BestPosition].Y, verticeList[3].X, verticeList[3].Y, canvas);
                    break;
                case "Top-Right":
                    drawLine(verticeList[BestPosition].X, verticeList[BestPosition].Y, verticeList[2].X, verticeList[2].Y, canvas);
                    break;
                default:
                    break;
            }

            double averageTime = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        averageTime += calculateTimeToBestPosition((int)Canvas.GetLeft(rectangle), (int)Canvas.GetTop(rectangle), verticeList);
                        break;
                    case 1:
                        averageTime += calculateTimeToBestPosition((int)Canvas.GetRight(rectangle), (int)Canvas.GetTop(rectangle), verticeList);
                        break;
                    case 2:
                        averageTime += calculateTimeToBestPosition((int)Canvas.GetLeft(rectangle), (int)Canvas.GetBottom(rectangle) , verticeList);
                        break;
                    case 3:
                        averageTime += calculateTimeToBestPosition((int)Canvas.GetRight(rectangle), (int)Canvas.GetBottom(rectangle), verticeList);
                        break;
                }
            }

            return averageTime/4;
        }

        private int getBestPosition(List<Vertice> vertices)
        {
            int bestPosition = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].ReactionTime < vertices[bestPosition].ReactionTime) bestPosition = i;
            }

            return bestPosition;
        }

        private double calculateTimeToBestPosition(int verticeX, int verticeY, List<Vertice> vertice)
        {
            switch (vertice[BestPosition].Location)
            {
                case "Top-Left":
                    return 0.0;
                case "Top-Right":
                    int topConnectionPixels = vertice[1].X - vertice[0].X;
                    int A = vertice[1].X - verticeX;
                    int AConnectionPixels = vertice[1].X - A;

                    double Y = (AConnectionPixels * vertice[0].ReactionTime) / topConnectionPixels;

                    int diagonalConnectionPixels = (int) Math.Sqrt(Math.Pow(vertice[1].Y - vertice[2].Y, 2) + Math.Pow(vertice[1].X - vertice[2].X, 2));

                    int BYCoordinate = 0;
                    int yStorage = verticeY;
                    bool onLine = false;
                    int cross = 0;

                    int dxc = verticeX - vertice[2].X;
                    int dyc = verticeY - vertice[2].Y;

                    int dxl = vertice[1].X - vertice[2].X;
                    int dyl = vertice[1].Y - vertice[2].Y;

                    while (onLine == false)
                    {
                        cross = dxc * dyl - dyc * dxl;

                        if (cross == 0 || yStorage > 720)
                        {
                            BYCoordinate = yStorage;
                            onLine = true;
                        } else
                        {
                            yStorage++;
                        }
                    }

                    int BConnectionPixels = (int)Math.Sqrt(Math.Pow(vertice[1].Y - BYCoordinate, 2) + Math.Pow(vertice[1].X - A, 2));

                    double Z = (BConnectionPixels * vertice[2].ReactionTime) / diagonalConnectionPixels;

                    double W = Math.Sqrt(Math.Pow(Z, 2) - Math.Pow(Y, 2));
                    int ABConnectionPixels = BYCoordinate - vertice[1].Y;

                    int cornerConnectionPixels = verticeY - vertice[1].Y;
                    double Q = (cornerConnectionPixels * W) / ABConnectionPixels;

                    double X = Math.Sqrt(Math.Pow(Y, 2) + Math.Pow(Q, 2));

                    return X;
                default:
                    return 0.0;
            }
        }
    }
}
