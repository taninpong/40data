using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NSOFunction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _40Data.Model
{
    [BsonIgnoreExtraElements]
    public class DataProcessed
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public Source Source { get; set; }
        public string SampleId { get; set; }
        public string SampleType { get; set; }
        public string EA { get; set; }
        public string Area_Code { get; set; }
        //public StatusProcessed Status { get; set; }

        #region GroundWater
        /// <summary>
        /// จำนวนบ่อบาดาลทั้งหมดในตำบล
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// ปริมาณน้ำ ลบ.ม./เดือน 
        /// </summary>
        public string CubicMeterPerMonth { get; set; }

        /// <summary>
        /// ค่าน้ำ
        /// </summary>
        public string WaterBill { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำ
        /// </summary>
        public string PumpCount { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำอัตโนมัติ
        /// </summary>
        public string PumpAuto { get; set; }

        /// <summary>
        /// ขุ่น/ตะกอน  
        /// </summary>
        public string TurbidWater { get; set; }

        /// <summary>
        /// เค็ม/กร่อย  
        /// </summary>
        public string SaltWater { get; set; }

        /// <summary>
        /// มีกลิ่น
        /// /// </summary>
        public string Smell { get; set; }

        /// <summary>
        /// คราบมัน
        /// </summary>
        public string FilmOfOil { get; set; }

        /// <summary>
        /// ฝ้าขาว
        /// </summary>
        public string FogWater { get; set; }

        /// <summary>
        /// น้ำกระด้าง
        /// </summary>
        public string HardWater { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการเกษตร
        /// </summary>
        public string Agriculture { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการบริการ
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุตสาหกรรม
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุปโภคบริโภค
        /// </summary>
        public string Drink { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย
        /// </summary>
        public string Plant { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการทำนา
        /// </summary>
        public string Farm { get; set; }

        /// <summary>
        /// ปริมาณน้ำซื้อที่ใช้เพื่อการเกษตร
        /// </summary>
        /// <value></value>
        public string CubicMeterBuyingForAgriculture { get; set; }

        /// <summary>
        /// ปริมาณน้ำซื้อที่ใช้เพื่อการบริการ
        /// </summary>
        /// <value></value>
        public string CubicMeterBuyingForService { get; set; }

        /// <summary>
        /// ปริมาณน้ำซื้อที่ใช้เพื่อการอุตสาหกรรม
        /// </summary>
        /// /// <value></value>
        public string CubicMeterBuyingForProduct { get; set; }

        /// <summary>
        /// ปริมาณน้ำซื้อที่ใช้เพื่อการอุปโภคบริโภค
        /// </summary>
        /// <value></value>
        public string CubicMeterBuyingForDrink { get; set; }
        #endregion

        #region Plumbing
        /// <summary>
        /// ใช้น้ำประปานครหลวง
        /// </summary>
        public string DoingMWA { get; set; }

        /// <summary>
        /// ปริมาณน้ำประปานครหลวง ลบ.ม./เดือน 
        /// </summary>
        public string CubicMeterPerMonthMWA { get; set; }

        /// <summary>
        /// ค่าน้้าประปานครหลวง
        /// </summary>
        public string WaterBillMWA { get; set; }

        /// <summary>
        /// ขุ่น/ตะกอน ประปานครหลวง
        /// </summary>
        public string TurbidWaterMWA { get; set; }

        /// <summary>
        /// เค็ม/กร่อย ประปานครหลวง
        /// </summary>
        public string SaltWaterMWA { get; set; }

        /// <summary>
        /// มีกลิ่น ประปานครหลวง
        /// </summary>
        public string SmellMWA { get; set; }

        /// <summary>
        /// คราบมัน ประปานครหลวง
        /// </summary>
        public string FilmOfOilMWA { get; set; }

        /// <summary>
        /// ฝ้าขาว ประปานครหลวง
        /// </summary>
        public string FogWaterMWA { get; set; }

        /// <summary>
        /// น้ำกระด้าง ประปานครหลวง
        /// </summary>
        public string HardWaterMWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการเกษตร ประปานครหลวง
        /// </summary>
        public string AgricultureMWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการบริการ ประปานครหลวง
        /// </summary>
        public string ServiceMWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุตสาหกรรม ประปานครหลวง
        /// </summary>
        public string ProductMWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุปโภคบริโภค ประปานครหลวง
        /// </summary>
        public string DrinkMWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย ประปานครหลวง
        /// </summary>
        public string PlantMWA { get; set; }

        /// <summary>
        /// ใช้น้ำประปาส่วนภูมิภาค
        /// </summary>
        public string DoingPWA { get; set; }

        /// <summary>
        /// ปริมาณน้ำประปาส่วนภูมิภาค ลบ.ม./เดือน 
        /// </summary>
        public string CubicMeterPerMonthPWA { get; set; }

        /// <summary>
        /// ค่าน้้าประปาส่วนภูมิภาค
        /// </summary>
        public string WaterBillPWA { get; set; }

        /// <summary>
        /// ขุ่น/ตะกอน ประปาส่วนภูมิภาค
        /// </summary>
        public string TurbidWaterPWA { get; set; }

        /// <summary>
        /// เค็ม/กร่อย ประปาส่วนภูมิภาค
        /// </summary>
        public string SaltWaterPWA { get; set; }

        /// <summary>
        /// มีกลิ่น ประปาส่วนภูมิภาค
        /// </summary>
        public string SmellPWA { get; set; }

        /// <summary>
        /// คราบมัน ประปาส่วนภูมิภาค
        /// </summary>
        public string FilmOfOilPWA { get; set; }

        /// <summary>
        /// ฝ้าขาว ประปาส่วนภูมิภาค
        /// </summary>
        public string FogWaterPWA { get; set; }

        /// <summary>
        /// น้ำกระด้าง ประปาส่วนภูมิภาค
        /// </summary>
        public string HardWaterPWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการเกษตร ประปาส่วนภูมิภาค
        /// </summary>
        public string AgriculturePWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการบริการ ประปาส่วนภูมิภาค
        /// </summary>
        public string ServicePWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุตสาหกรรม ประปาส่วนภูมิภาค
        /// </summary>
        public string ProductPWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุปโภคบริโภค ประปาส่วนภูมิภาค
        /// </summary>
        public string DrinkPWA { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย ประปาส่วนภูมิภาค
        /// </summary>
        public string PlantPWA { get; set; }

        /// <summary>
        /// ใช้น้ำประปาอื่น ๆ
        /// </summary>
        public string DoingOther { get; set; }

        /// <summary>
        /// ปริมาณน้ำประปาอื่น ๆ ลบ.ม./เดือน 
        /// </summary>
        public string CubicMeterPerMonthOther { get; set; }

        /// <summary>
        /// ค่าน้้าประปาอื่น ๆ
        /// </summary>
        public string WaterBillOther { get; set; }

        /// <summary>
        /// ขุ่น/ตะกอน ประปาอื่น ๆ
        /// </summary>
        public string TurbidWaterOther { get; set; }

        /// <summary>
        /// เค็ม/กร่อย ประปาอื่น ๆ
        /// </summary>
        public string SaltWaterOther { get; set; }

        /// <summary>
        /// มีกลิ่น ประปาอื่น ๆ
        /// </summary>
        public string SmellOther { get; set; }

        /// <summary>
        /// คราบมัน ประปาอื่น ๆ
        /// </summary>
        public string FilmOfOilOther { get; set; }

        /// <summary>
        /// ฝ้าขาว ประปาอื่น ๆ
        /// </summary>
        public string FogWaterOther { get; set; }

        /// <summary>
        /// น้ำกระด้าง ประปาอื่น ๆ
        /// </summary>
        public string HardWaterOther { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการเกษตร ประปาอื่น ๆ
        /// </summary>
        public string AgricultureOther { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการบริการ ประปาอื่น ๆ
        /// </summary>
        public string ServiceOther { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุตสาหกรรม ประปาอื่น ๆ
        /// </summary>
        public string ProductOther { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อการอุปโภคบริโภค ประปาอื่น ๆ
        /// </summary>
        public string DrinkOther { get; set; }

        /// <summary>
        /// สัดส่วนเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย ประปาอื่น ๆ
        /// </summary>
        public string PlantOther { get; set; }

        /// <summary>
        ///  ค่าเช่ามิเตอร์คิดเดือนละเท่าไร  
        /// </summary>
        public string MeterRentalFee { get; set; }

        /// <summary>
        /// น้้าประปาราคาขายหน่วยละเท่าไร 
        /// </summary>
        public string PlumbingPrice { get; set; }
        #endregion

        #region Surface
        /// <summary>
        /// จำนวนสระน้ำทั้งหมด
        /// </summary>
        public string PoolCount { get; set; }

        /// <summary>
        /// จำนวนสระน้ำในตำบล
        /// </summary>
        public string WaterResourceCount { get; set; }

        /// <summary>
        /// ปริมาณน้ำสระน้ำ ลบ.ม./เดือน 
        /// </summary>
        public string CubicMeterPerMonthPool { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำสำหรับสระน้ำ
        /// </summary>
        public string PumpCountPool { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำอัตโนมัติสำหรับสระน้ำ
        /// </summary>
        public string PumpAutoPool { get; set; }

        /// <summary>
        /// สระน้ำ เค็ม/กร่อย  
        /// </summary>
        public string SaltWaterPool { get; set; }

        /// <summary>
        /// สระน้ำ มีกลิ่น
        /// /// </summary>
        public string SmellPool { get; set; }

        /// <summary>
        /// สระน้ำ คราบมัน
        /// </summary>
        public string FilmOfOilPool { get; set; }

        /// <summary>
        /// สระน้ำ ฝ้าขาว
        /// </summary>
        public string FogWaterPool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อการเกษตร
        /// </summary>
        public string AgriculturePool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อการบริการ
        /// </summary>
        public string ServicePool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อการอุตสาหกรรม
        /// </summary>
        public string ProductPool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อการอุปโภคบริโภค
        /// </summary>
        public string DrinkPool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย
        /// </summary>
        public string PlantPool { get; set; }

        /// <summary>
        /// สัดส่วนสระน้ำเพื่อการทำนา
        /// </summary>
        public string FarmPool { get; set; }

        /// <summary>
        /// ปริมาณน้ำชลประทาน ลบ.ม./เดือน
        /// </summary>
        public string CubicMeterPerMonthIrrigation { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำสำหรับชลประทาน
        /// </summary>
        public string PumpCountIrrigation { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำอัตโนมัติสำหรับชลประทาน
        /// </summary>
        public string PumpAutoIrrigation { get; set; }

        /// <summary>
        /// ชลประทาน เค็ม/กร่อย  
        /// </summary>
        public string SaltWaterIrrigation { get; set; }

        /// <summary>
        /// ชลประทาน มีกลิ่น
        /// </summary>
        public string SmellIrrigation { get; set; }

        /// <summary>
        /// ชลประทาน คราบมัน
        /// </summary>
        public string FilmOfOilIrrigation { get; set; }

        /// <summary>
        /// ชลประทาน ฝ้าขาว
        /// </summary>
        public string FogWaterIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อการเกษตร
        /// </summary>
        public string AgricultureIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อการบริการ
        /// </summary>
        public string ServiceIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อการอุตสาหกรรม
        /// </summary>
        public string ProductIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อการอุปโภคบริโภค
        /// </summary>
        public string DrinkIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย
        /// </summary>
        public string PlantIrrigation { get; set; }

        /// <summary>
        /// สัดส่วนชลประทานเพื่อการทำนา
        /// </summary>
        public string FarmIrrigation { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำสำหรับแม่น้ำ
        /// </summary>
        public string PumpCountRiver { get; set; }

        /// <summary>
        /// จำนวนเครื่องสูบน้ำอัตโนมัติสำหรับแม่น้ำ
        /// </summary>
        public string PumpAutoRiver { get; set; }

        /// <summary>
        /// แม่น้ำ เค็ม/กร่อย  
        /// </summary>
        public string SaltWaterRiver { get; set; }

        /// <summary>
        /// แม่น้ำ มีกลิ่น
        /// </summary>
        public string SmellRiver { get; set; }

        /// <summary>
        /// แม่น้ำ คราบมัน
        /// </summary>
        public string FilmOfOilRiver { get; set; }

        /// <summary>
        /// แม่น้ำ ฝ้าขาว
        /// </summary>
        public string FogWaterRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อการเกษตร
        /// </summary>
        public string AgricultureRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อการบริการ
        /// </summary>
        public string ServiceRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อการอุตสาหกรรม
        /// </summary>
        public string ProductRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อการอุปโภคบริโภค
        /// </summary>
        public string DrinkRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย
        /// </summary>
        public string PlantRiver { get; set; }

        /// <summary>
        /// สัดส่วนแม่น้ำเพื่อการทำนา
        /// </summary>
        public string FarmRiver { get; set; }

        /// <summary>
        /// สัดส่วนน้ำฝนกักเก็บเพื่อการเกษตร
        /// </summary>
        public string AgricultureRain { get; set; }

        /// <summary>
        /// สัดส่วนน้ำฝนกักเก็บเพื่อการบริการ
        /// </summary>
        public string ServiceRain { get; set; }

        /// <summary>
        /// สัดส่วนน้ำฝนกักเก็บเพื่อการอุตสาหกรรม
        /// </summary>
        public string ProductRain { get; set; }

        /// <summary>
        /// สัดส่วนน้ำฝนกักเก็บเพื่อการอุปโภคบริโภค
        /// </summary>
        public string DrinkRain { get; set; }

        /// <summary>
        /// สัดส่วนน้ำฝนกักเก็บเพื่อรดน้้าพืชในบริเวณที่อยู่อาศัย
        /// </summary>
        public string PlantRain { get; set; }
        #endregion

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำบาดาลเพื่อการเกษตรได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterGroundWaterForAgriculture { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำบาดาลเพื่อการบริการได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterGroundWaterForService { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำบาดาลเพื่อการอุตสาหกรรมได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterGroundWaterForProduct { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำบาดาลเพื่อการอุปโภคบริโภคได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterGroundWaterForDrink { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำประปาเพื่อการเกษตรได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterPlumbingForAgriculture { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำประปาเพื่อการบริการได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterPlumbingForService { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำประปาเพื่อการอุตสาหกรรมได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterPlumbingForProduct { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำประปาเพื่อการอุปโภคบริโภคได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterPlumbingForDrink { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำผิวดินเพื่อการเกษตรได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterSurfaceForAgriculture { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำผิวดินเพื่อการบริการได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterSurfaceForService { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำผิวดินเพื่อการอุตสาหกรรมได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterSurfaceForProduct { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำผิวดินเพื่อการอุปโภคบริโภคได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterSurfaceForDrink { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำบาดาลที่พัฒนามาใช้ได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterGroundWaterForUse { get; set; }

        /// <summary>
        /// คำนวณปริมาณการใช้น้ำเพื่อการอุปโภคบริโภคได้
        /// </summary>
        public StatusCompute CanComputeCubicMeterForDrink { get; set; }

        /// <summary>
        /// 1.ครัวเรือนเกษตรกรรม
        /// </summary>
        public double IsAgriculture { get; set; }

        /// <summary>
        /// 2.ครัวเรือนทั้งหมด
        /// </summary>
        public double IsHouseHold { get; set; }

        /// <summary>
        /// 3.ครัวเรือนที่มีน้ำประปาคุณภาพดี 
        /// </summary>
        public double IsHouseHoldGoodPlumbing { get; set; }

        /// <summary>
        /// 4.ครัวเรือนที่มีพื้นที่เกษตรกรรมในพื้นที่ชลประทาน
        /// </summary>
        public double IsAgricultureHasIrrigationField { get; set; }

        /// <summary>
        /// 5.ครัวเรือนในเขตเมืองที่มีน้ำประปาใช้ (ในเขตเทศบาล)
        /// </summary>
        public double IsHouseHoldHasPlumbingDistrict { get; set; }

        /// <summary>
        /// 6.ครัวเรือนในชนบทที่มีน้ำประปาใช้ (นอกเขตเทศบาล)
        /// </summary>
        public double IsHouseHoldHasPlumbingCountryside { get; set; }

        /// <summary>
        /// 7.คุณภาพน้ำที่ใช้ในการผลิต (น้ำประปา ผิวดิน น้ำบาดาล)
        /// </summary>
        public double IsFactorialWaterQuality { get; set; }

        /// <summary>
        /// 8.คุณภาพน้ำที่ใช้ในภาคบริการ (น้ำประปา ผิวดิน น้ำบาดาล)
        /// </summary>
        public double IsCommercialWaterQuality { get; set; }

        /// <summary>
        /// 9.จำนวนบ่อน้ำบาดาล
        /// </summary>
        public double CountGroundWater { get; set; }

        /// <summary>
        /// 10.จำนวนประชากรทั้งหมด
        /// </summary>
        public double CountPopulation { get; set; }

        /// <summary>
        /// 11.จำนวนประชากรวัยทำงาน
        /// </summary>
        public double CountWorkingAge { get; set; }

        /// <summary>
        /// 12.โรงงานอุตสาหกรรมทั้งหมด
        /// </summary>
        public double IsFactorial { get; set; }

        /// <summary>
        /// 13.โรงงานอุตสาหกรรมที่มีระบบบำบัดน้ำเสีย
        /// </summary>
        public double IsFactorialWaterTreatment { get; set; }

        /// <summary>
        /// 14.หมู่บ้านที่มีระบบบำบัดน้ำเสีย
        /// </summary>
        public double IsCommunityWaterManagementHasWaterTreatment { get; set; }

        /// <summary>
        /// 15.พื้นที่ชลประทาน
        /// </summary>
        public double FieldCommunity { get; set; }

        /// <summary>
        /// 16.ระดับความลึกของน้ำท่วม (ในเขตที่อยู่อาศัย)
        /// </summary>
        public double AvgWaterHeightCm { get; set; }

        /// <summary>
        /// 17.ระยะเวลาที่น้ำท่วมขัง (ในเขตที่อยู่อาศัย)
        /// </summary>
        public double TimeWaterHeightCm { get; set; }

        /// <summary>
        /// 18.ระยะเวลาที่มีน้ำประปาใช้ (เดือน) 
        /// </summary>
        public double HasntPlumbing { get; set; }

        /// <summary>
        /// 19.สถานที่ราชการทั้งหมด
        /// </summary>
        public double IsGovernment { get; set; }

        /// <summary>
        /// 20.สถานที่ราชการที่มีน้ำประปาใช้
        /// </summary>
        public double IsGovernmentUsage { get; set; }

        /// <summary>
        /// 21.สถานที่ราชการที่มีน้ำประปาที่มีคุณภาพมาตรฐาน
        /// </summary>
        public double IsGovernmentWaterQuality { get; set; }

        /// <summary>
        /// 22.หมู่บ้านในพื้นที่น้ำท่วมซ้ำซากที่มีการเตือนภัยและมาตรการช่วยเหลือ
        /// </summary>
        public double CommunityNatureDisaster { get; set; }

        /// <summary>
        /// 23.แหล่งน้ำขนาดใหญ่ กลาง และเล็ก
        /// </summary>
        public double WaterSources { get; set; }

        /// <summary>
        /// 24.จำนวนโรงงานอุตสาหกรรมที่มีน้ำเสียจากระบบ
        /// </summary>
        public double IndustryHasWasteWaterTreatment { get; set; }

        /// <summary>
        /// 25.ประชากรที่อาศัยในครัวเรือนที่มีน้ำท่วม 
        /// </summary>
        public double PeopleInFloodedArea { get; set; }

        /// <summary>
        /// 26.ปริมาณการใช้น้ำบาดาลเพื่อการเกษตร(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public double CubicMeterGroundWaterForAgriculture { get; set; }

        /// <summary>
        /// 27.ปริมาณการใช้น้ำบาดาลเพื่อการบริการ(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public double CubicMeterGroundWaterForService { get; set; }

        /// <summary>
        /// 28.ปริมาณการใช้น้ำบาดาลเพื่อการอุตสาหกรรม(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public double CubicMeterGroundWaterForProduct { get; set; }

        /// <summary>
        /// 29.ปริมาณการใช้น้ำบาดาลเพื่อการอุปโภคบริโภค(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public double CubicMeterGroundWaterForDrink { get; set; }

        /// <summary>
        /// 30.ปริมาณการใช้น้ำประปาเพื่อการเกษตร
        /// </summary>
        public double CubicMeterPlumbingForAgriculture { get; set; }

        /// <summary>
        /// 31.ปริมาณการใช้น้ำประปาเพื่อการบริการ
        /// </summary>
        public double CubicMeterPlumbingForService { get; set; }

        /// <summary>
        /// 32.ปริมาณการใช้น้ำประปาเพื่อการอุตสาหกรรม
        /// </summary>
        public double CubicMeterPlumbingForProduct { get; set; }

        /// <summary>
        /// 33.ปริมาณการใช้น้ำประปาเพื่อการอุปโภคบริโภค 
        /// </summary>
        public double CubicMeterPlumbingForDrink { get; set; }

        /// <summary>
        /// 34.ปริมาณการใช้น้ำผิวดินเพื่อการเกษตร (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public double CubicMeterSurfaceForAgriculture { get; set; }

        /// <summary>
        /// 35.ปริมาณการใช้น้ำผิวดินเพื่อการบริการ (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public double CubicMeterSurfaceForService { get; set; }

        /// <summary>
        /// 36.ปริมาณการใช้น้ำผิวดินเพื่อการอุตสาหกรรม (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public double CubicMeterSurfaceForProduct { get; set; }

        /// <summary>
        /// 37.ปริมาณการใช้น้ำผิวดินเพื่อการอุปโภคบริโภค (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public double CubicMeterSurfaceForDrink { get; set; }

        /// <summary>
        /// 38.ปริมาณน้ำบาดาลที่พัฒนามาใช้ (ปริมาณน้ำจากรายการ 26-29)
        /// </summary>
        public double CubicMeterGroundWaterForUse { get; set; }

        /// <summary>
        /// 39.จำนวนหมู่บ้าน/ชุมชนทั้งหมด
        /// </summary>
        public double CountCommunity { get; set; }

        /// <summary>
        /// 40.จำนวนหมู่บ้าน/ชุมชนที่มีอุทกภัย ดินโคลนถล่ม
        /// </summary>
        public double CountCommunityHasDisaster { get; set; }

        /// <summary>
        /// 41.ครัวเรือนในชนบททั้งหมด
        /// </summary>
        public double IsAllHouseHoldCountryside { get; set; }

        /// <summary>
        /// 42.ครัวเรือนในเขตเมืองทั้งหมด
        /// </summary>
        public double IsAllHouseHoldDistrict { get; set; }

        /// <summary>
        /// 43.สถานประกอบการผลิตทั้งหมด
        /// </summary>
        public double IsAllFactorial { get; set; }

        /// <summary>
        /// 44.สถานประกอบการบริการทั้งหมด
        /// </summary>
        public double IsAllCommercial { get; set; }

        /// <summary>
        /// ปริมาณการใช้น้ำเพื่อการอุปโภคบริโภค
        /// </summary>
        public string CubicMeterForDrink { get; set; }

        /// <summary>
        /// ข้อมูลตัวซ้ำ
        /// </summary>
        public string Duplicate { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 26.ปริมาณการใช้น้ำบาดาลเพื่อการเกษตร(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public string AdjustedCubicMeterGroundWaterForAgriculture { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 27.ปริมาณการใช้น้ำบาดาลเพื่อการบริการ(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public string AdjustedCubicMeterGroundWaterForService { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 28.ปริมาณการใช้น้ำบาดาลเพื่อการอุตสาหกรรม(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public string AdjustedCubicMeterGroundWaterForProduct { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 29.ปริมาณการใช้น้ำบาดาลเพื่อการอุปโภคบริโภค(น้ำบาดาล น้ำซื้อ)
        /// </summary>
        public string AdjustedCubicMeterGroundWaterForDrink { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 34.ปริมาณการใช้น้ำผิวดินเพื่อการเกษตร (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public string AdjustedCubicMeterSurfaceForAgriculture { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 35.ปริมาณการใช้น้ำผิวดินเพื่อการบริการ (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public string AdjustedCubicMeterSurfaceForService { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 36.ปริมาณการใช้น้ำผิวดินเพื่อการอุตสาหกรรม (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public string AdjustedCubicMeterSurfaceForProduct { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 37.ปริมาณการใช้น้ำผิวดินเพื่อการอุปโภคบริโภค (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)
        /// </summary>
        public string AdjustedCubicMeterSurfaceForDrink { get; set; }

        /// <summary>
        /// ค่าปรับแต่ง 38.ปริมาณน้ำบาดาลที่พัฒนามาใช้ (ปริมาณน้ำจากรายการ 26-29)
        /// </summary>
        public string AdjustedCubicMeterGroundWaterForUse { get; set; }
    }
    public class Source
    {
        public string Name { get; set; }
    }
}
