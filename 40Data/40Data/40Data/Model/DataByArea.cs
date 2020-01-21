using System;
using System.Collections.Generic;
using System.Text;

namespace _40Data.Model
{
    public class DataByArea
    {
        public string Area_Code { get; set; }
        public string CWT { get; set; }
        public string CWT_NAME { get; set; }
        public string AMP { get; set; }
        public string AMP_NAME { get; set; }
        public string TAM { get; set; }
        public string TAM_NAME { get; set; }
        public string REG { get; set; }
        public string REG_NAME { get; set; }
        public double CountGroundWaterS11 { get; set; }
        public double CountGroundWaterS22 { get; set; }
        public double WaterSourcesS11 { get; set; }
        public double WaterSourcesS22 { get; set; }
        public double CubicMeterGroundWaterForAgriculture { get; set; }
        public double CubicMeterGroundWaterForService { get; set; }
        public double CubicMeterGroundWaterForProduct { get; set; }
        public double CubicMeterGroundWaterForDrink { get; set; }
        public double CubicMeterPlumbingForAgriculture { get; set; }
        public double CubicMeterPlumbingForService { get; set; }
        public double CubicMeterPlumbingForProduct { get; set; }
        public double CubicMeterPlumbingForDrink { get; set; }
        public double CubicMeterSurfaceForAgriculture { get; set; }
        public double CubicMeterSurfaceForService { get; set; }
        public double CubicMeterSurfaceForProduct { get; set; }
        public double CubicMeterSurfaceForDrink { get; set; }
        public double CubicMeterGroundWaterForUse { get; set; }
    }
}
