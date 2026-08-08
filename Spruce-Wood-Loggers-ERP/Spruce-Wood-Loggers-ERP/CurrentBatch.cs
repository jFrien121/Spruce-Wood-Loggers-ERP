using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP
{
    static class CurrentBatch
    {
        private static Batch currentBatch;
        private static int batchLiftHeight;
        private static int batchLiftWidth;
        public static bool customPieceNumber;

        public static void InitializeBatch()
        {
            currentBatch = new Batch();
            customPieceNumber = false;
        }

        public static void setThickness(double thickness)
        {
            currentBatch.thickness = thickness;
        }

        public static void setWidth(double width)
        {
            currentBatch.width = width;
        }

        public static void setLength(double length)
        {
            currentBatch.length = length;
        }

        public static void setGrade(Grade grade)
        {
            currentBatch.grade = GradeToString(grade);
        }

        public static void setNumPieces(int numPieces)
        {
            currentBatch.numPieces = numPieces;
        }

        public static void setLiftHeight(int height)
        {
            batchLiftHeight = height;
            customPieceNumber = true;
        }

        public static void setLiftWidth(int width)
        {
            batchLiftWidth = width;
            customPieceNumber = true;
        }

        private static string GradeToString(Grade grade)
        {
            switch (grade)
            {
                case Grade.UNGRADED: return "Ungraded";
                case Grade.ONE: return "#1";
                case Grade.TWO: return "#2";
                case Grade.THREE: return "#3";
            }

            return "Ungraded";
        }

        public static double getThickness()
        {
            return currentBatch.thickness;
        }

        public static double getWidth()
        {
            return currentBatch.width;
        }

        public static double getLength()
        {
            return currentBatch.length;
        }

        public static string getGrade()
        {
            return currentBatch.grade;
        }

        public static string getLiftHeight()
        {
            return batchLiftHeight.ToString();
        }

        public static string getLiftWidth()
        {
            return batchLiftWidth.ToString();
        }

        public static int getNumPieces()
        {
            if (customPieceNumber)
            {
                return batchLiftHeight * batchLiftWidth;
            }

            return currentBatch.numPieces;
        }
    }
}
