using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class DeskQuote
    {
        // get from user
        public int ID { get; set; }
        [Display(Name = "Customer Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-z\s]*$")]
        public string CustomerName { get; set; }

        [Display(Name = "Shipping Days")]
        public int DaysShip { get; set; }
        [Range(24, 96)]
        public int Width { get; set; }
        [Range(12, 48)]
        public int Depth { get; set; }
        [Display(Name = "Drawers")]
        [Range(0, 9)]
        public int DrawersNumber { get; set; }
        [Display(Name = "Surface Material")]
        public string surfaceMaterial { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime quoteDate { get; set; }

        public readonly Dictionary<string, int> surfaceMaterials =
        new Dictionary<string, int>
        {
            {"Laminate", 100},
            {"Oak", 200},
            {"Rosewood", 300},
            {"Veneer", 125},
            {"Pine", 50}
        };


        public const int BasePrice = 200;
        public const int CostPerIn = 1;
        public const int CostPerDrawer = 50;
        public int[,] RushPrice = new int[3, 3];

        // calculate
        public int ShipPrice;
        public int SurfaceMaterialPrice;
        public int SurfaceAreaPrice;
        public int DrawerCost;
        public int FinalPrice;
        public int SurfaceArea;

        public DeskQuote(string customerName, int daysShip, int width, int depth, int drawersNumber, string surfaceMaterial, DateTime quoteDate)
        {
            CustomerName = customerName;
            DaysShip = daysShip;
            Width = width;
            Depth = depth;
            DrawersNumber = drawersNumber;
            this.surfaceMaterial = surfaceMaterial;
            this.quoteDate = quoteDate;
            CalcTotalPrice();
        }
        public DeskQuote(int iD, string customerName, int daysShip, int width, int depth, int drawersNumber, string surfaceMaterial, DateTime quoteDate, Dictionary<string, int> surfaceMaterials, int[,] rushPrice, int shipPrice, int surfaceMaterialPrice, int surfaceAreaPrice, int drawerCost, int finalPrice, int surfaceArea)
        {
            ID = iD;
            CustomerName = customerName;
            DaysShip = daysShip;
            Width = width;
            Depth = depth;
            DrawersNumber = drawersNumber;
            this.surfaceMaterial = surfaceMaterial;
            this.quoteDate = quoteDate;
            this.surfaceMaterials = surfaceMaterials;
            RushPrice = rushPrice;
            ShipPrice = shipPrice;
            SurfaceMaterialPrice = surfaceMaterialPrice;
            SurfaceAreaPrice = surfaceAreaPrice;
            DrawerCost = drawerCost;
            FinalPrice = finalPrice;
            SurfaceArea = surfaceArea;
        }

        // calculate shipping cost
        public void CalcShippingCost()
        {
            int row = 0;
            int column = 0;

            RushPrice = new int[3, 3] { { 60, 70, 80 }, { 40, 50, 60 }, { 30, 35, 40 } };


            // check base shipping cost by day
            // check for surface area cost added

            // 7 day shipping
            if (DaysShip == 7)
            {
                row = 2;
            }

            // 5 day shipping
            else if (DaysShip == 5)
            {
                row = 1;
            }

            // 3 day shipping
            else if (DaysShip == 3)
            {
                row = 0;
            }

            // take surface area  into account
            if (SurfaceArea > 2000)
            {
                column = 2;
            }
            else if (SurfaceArea >= 1000)
            {
                column = 1;
            }
            else
            {
                column = 0;
            }

            // output shipping price
            if (DaysShip == 14)
            {
                ShipPrice = 0;
            }
            else
            {
                ShipPrice = RushPrice[row, column];
            }
        }
        public void CalcSurfaceArea()
        {
            SurfaceArea = Width * Depth;
        }

        // calc surface cost
        public void CalcSurfacePrice()
        {
            SurfaceMaterialPrice = surfaceMaterials[surfaceMaterial];
        }

        // Calc Drawer Price
        public void CalcDrawerPrice()
        {
            DrawerCost = CostPerDrawer * DrawersNumber;
        }

        // Calc price per square in.
        public void CalcSquarePrice()
        {
            if (SurfaceArea > 1000)
            {
                SurfaceAreaPrice = (SurfaceArea - 1000) * CostPerIn;
            }
            else
            {
                SurfaceAreaPrice = 0;
            }
        }

        // Calc total Price
        public void CalcTotalPrice()
        {
            // run to get surface area
            CalcSurfaceArea();

            // calculate all costs
            CalcShippingCost();
            CalcSurfacePrice();
            CalcDrawerPrice();
            CalcSquarePrice();

            // calc total or final cost
            FinalPrice = BasePrice + ShipPrice + SurfaceMaterialPrice + DrawerCost + SurfaceAreaPrice;
        }

        public override string ToString()
        {
            // choose any format that suits you and display what you like
            return $"Name: {CustomerName} - Total: {FinalPrice} - Date: {quoteDate}";
        }
    }
}
