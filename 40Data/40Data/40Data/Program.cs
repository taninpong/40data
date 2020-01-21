using _40Data.Model;
using MongoDB.Driver;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using WebManageAPI.Models;

namespace _40Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GroupEA("38");
        }
        public static void GroupEA(string filename)
        {
            Console.WriteLine("Hello World!");
            var partFile = $@"D:\{{filename}}.xlsx";
            var client = new MongoClient("mongodb://firstclass:Th35F1rstCla55@mongodbproykgte5e7lvm7y-vm0.southeastasia.cloudapp.azure.com/pdata");
            var database = client.GetDatabase("pdata");
            var collectionData = database.GetCollection<DataProcessed>("c0");


            var client2 = new MongoClient("mongodb://dbagent:Nso4Passw0rd5@mongodbproykgte5e7lvm7y-vm0.southeastasia.cloudapp.azure.com/nso");
            var database2 = client2.GetDatabase("nso");
            var collectionReport = database2.GetCollection<ReportEaInfo>("reporteainfo");


            var countCells = 4;
            var count = 1;

            //var ollectionData.(it => it.SampleType == "c" && it.EA == p.Key).ToList().Sum(it => it.CountGroundWater)
            var qry = collectionData.Aggregate().Group(it => it.Source.Name, p => new DataByEA
            {
                EaSourse = p.Key,
                IsAgriculture = p.Sum(it => it.IsAgriculture),
                IsHouseHold = p.Sum(it => it.IsHouseHold),
                IsHouseHoldGoodPlumbing = p.Sum(it => it.IsHouseHoldGoodPlumbing),
                IsAgricultureHasIrrigationField = p.Sum(it => it.IsAgricultureHasIrrigationField),
                IsHouseHoldHasPlumbingDistrict = p.Sum(it => it.IsHouseHoldHasPlumbingDistrict),
                IsHouseHoldHasPlumbingCountryside = p.Sum(it => it.IsHouseHoldHasPlumbingCountryside),
                IsFactorialWaterQuality = p.Sum(it => it.IsFactorialWaterQuality),
                IsCommercialWaterQuality = p.Sum(it => it.IsCommercialWaterQuality),
                //CountGroundWaters11 = collectionData.(it => it.SampleType == "c" && it.EA == p.Key).ToList().Sum(it => it.CountGroundWater),//s11
                //CountGroundWaters22 = p.Sum(x=>x.SampleType == "c"&& x.CountGroundWater),
                //p.Sum(it => it.),//s22
                CountPopulation = p.Sum(it => it.CountPopulation),
                CountWorkingAge = p.Sum(it => it.CountWorkingAge),
                IsFactorial = p.Sum(it => it.IsFactorial),
                IsFactorialWaterTreatment = p.Sum(it => it.IsFactorialWaterTreatment),
                IsCommunityWaterManagementHasWaterTreatment = p.Sum(it => it.IsCommunityWaterManagementHasWaterTreatment),
                FieldCommunity = p.Sum(it => it.FieldCommunity),
                AvgWaterHeightCm = p.Average(it => it.AvgWaterHeightCm),
                TimeWaterHeightCm = p.Average(it => it.TimeWaterHeightCm),
                HasntPlumbing = p.Average(it => it.HasntPlumbing),
                IsGovernment = p.Sum(it => it.IsGovernment),
                IsGovernmentUsage = p.Sum(it => it.IsGovernmentUsage),
                IsGovernmentWaterQuality = p.Sum(it => it.IsGovernmentWaterQuality),
                CommunityNatureDisaster = p.Sum(it => it.CommunityNatureDisaster),
                //WaterSourcess11 = p.Sum(it => it.WaterSources),//S11
                //WaterSourcess22 = p.Sum(it => it.WaterSources),//S11
                IndustryHasWasteWaterTreatment = p.Sum(it => it.IndustryHasWasteWaterTreatment),
                PeopleInFloodedArea = p.Sum(it => it.PeopleInFloodedArea),
                CountCommunity = p.Sum(it => it.CountCommunity),
                CountCommunityHasDisaster = p.Sum(it => it.CountCommunityHasDisaster),
                HouseHoldInCity = p.Sum(it => it.IsAllHouseHoldDistrict),
                HouseHoldOutCity = p.Sum(it => it.IsAllHouseHoldCountryside),
                HouseHoldFac = p.Sum(it => it.IsAllFactorial),
                HouseHoldCom = p.Sum(it => it.IsAllCommercial)
            }).ToList();
            var countqry = 0;
            foreach (var item in qry)
            {
                var ea = item.EaSourse.Split(".");
                //item.
                // Create Model 40 EA
                var r = collectionReport.Find(it => it._id == ea[0]).FirstOrDefault();
                item.EA = r._id ?? "";
                item.CWT = r.CWT ?? "";
                item.CWT_NAME = r.CWT_NAME ?? "";
                item.AMP = r.AMP ?? "";
                item.AMP_NAME = r.AMP_NAME ?? "";
                item.TAM = r.TAM ?? "";
                item.TAM_NAME = r.TAM_NAME ?? "";
                item.REG = r.REG ?? "";
                item.REG_NAME = r.REG_NAME ?? "";

                var x = collectionData.Find(it => it.SampleType == "u" && it.EA == item.EA).ToList();
                item.SumGroundWaters11 = collectionData.Find(it => it.SampleType == "u" && it.EA == item.EA).ToList().Sum(it => it.CountGroundWater);
                item.SumGroundWaters22 = collectionData.Find(it => it.SampleType == "c" && it.EA == item.EA).ToList().Sum(it => it.CountGroundWater);
                item.SumWaterSourcess11 = collectionData.Find(it => it.SampleType == "u" && it.EA == item.EA).ToList().Sum(it => it.WaterSources);
                item.SumWaterSourcess22 = collectionData.Find(it => it.SampleType == "c" && it.EA == item.EA).ToList().Sum(it => it.WaterSources);
                countqry++;
                Console.WriteLine("Sum" + (countqry) + "/" + qry.Count());
            }
            //Excel
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add($"EA Report");

                using (ExcelRange range = worksheet.Cells["A1:AQ3"])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.WrapText = true;
                    range.Style.Font.Bold = true;
                }
                using (ExcelRange range = worksheet.Cells["A3:AQ3"])
                {
                    range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                }

                worksheet.Cells["A1:A2"].Merge = true;
                worksheet.Cells["A1:A2"].Value = "EA";
                worksheet.Cells["A1:A2"].Merge = true;
                worksheet.Cells["B1:B2"].Value = "รหัส";
                worksheet.Cells["B1:B2"].Merge = true;
                worksheet.Cells["C1"].Value = "รหัสตำบล";
                worksheet.Cells["C1:C2"].Merge = true;
                worksheet.Cells["D1"].Value = "ตำบล";
                worksheet.Cells["D1:D2"].Merge = true;
                worksheet.Cells["E1"].Value = "รหัสอำเภอ";
                worksheet.Cells["E1:E2"].Merge = true;
                worksheet.Cells["F1"].Value = "อำเภอ";
                worksheet.Cells["F1:F2"].Merge = true;
                worksheet.Cells["G1"].Value = "รหัสจังหวัด";
                worksheet.Cells["G1:G2"].Merge = true;
                worksheet.Cells["H1"].Value = "จังหวัด";
                worksheet.Cells["H1:H2"].Merge = true;
                worksheet.Cells["I1"].Value = "รหัสภูมิภาค";
                worksheet.Cells["I1:I2"].Merge = true;
                worksheet.Cells["J1"].Value = "ภูมิภาค";
                worksheet.Cells["J1:J2"].Merge = true;
                worksheet.Cells["K1"].Value = "1.ครัวเรือนเกษตรกรรม";
                worksheet.Cells["K2"].Value = "IsAgriculture";
                worksheet.Cells["L1"].Value = "2.ครัวเรือนทั้งหมด";
                worksheet.Cells["L2"].Value = "IsHouseHold";
                worksheet.Cells["M1"].Value = "3.ครัวเรือนที่มีน้ำประปาคุณภาพดี ";
                worksheet.Cells["M2"].Value = "IsHouseHoldGoodPlumbing";
                worksheet.Cells["N1"].Value = "4.ครัวเรือนที่มีพื้นที่เกษตรกรรมในพื้นที่ชลประทาน";
                worksheet.Cells["N2"].Value = "IsAgricultureHasIrrigationField";
                worksheet.Cells["O1"].Value = "5.ครัวเรือนในเขตเมืองที่มีน้ำประปาใช้ (ในเขตเทศบาล)";
                worksheet.Cells["O2"].Value = "IsHouseHoldHasPlumbingDistrict";
                worksheet.Cells["P1"].Value = "6.ครัวเรือนในชนบทที่มีน้ำประปาใช้ (นอกเขตเทศบาล)";
                worksheet.Cells["P2"].Value = "IsHouseHoldHasPlumbingCountryside";
                worksheet.Cells["Q1"].Value = "7.คุณภาพน้ำที่ใช้ในการผลิต (น้ำประปา ผิวดิน น้ำบาดาล)";
                worksheet.Cells["Q2"].Value = "IsFactorialWaterQuality";
                worksheet.Cells["R1"].Value = "8.คุณภาพน้ำที่ใช้ในภาคบริการ (น้ำประปา ผิวดิน น้ำบาดาล)";
                worksheet.Cells["R2"].Value = "IsCommercialWaterQuality";
                worksheet.Cells["S1"].Value = "สน.1 9.จำนวนบ่อน้ำบาดาล";
                worksheet.Cells["S2"].Value = "CountGroundWater";
                worksheet.Cells["T1"].Value = "สน.2   9.จำนวนบ่อน้ำบาดาล";
                worksheet.Cells["T2"].Value = "CountGroundWater";
                worksheet.Cells["U1"].Value = "10.จำนวนประชากร";
                worksheet.Cells["U2"].Value = "CountPopulation";
                worksheet.Cells["V1"].Value = "11.จำนวนประชากรวัยทำงาน";
                worksheet.Cells["V2"].Value = "CountWorkingAge";
                worksheet.Cells["W1"].Value = "12.โรงงานอุตสาหกรรมทั้งหมด";
                worksheet.Cells["W2"].Value = "IsFactorial";
                worksheet.Cells["X1"].Value = "13.โรงงานอุตสาหกรรมที่มีระบบบำบัดน้ำเสีย";
                worksheet.Cells["X2"].Value = "IsFactorialWaterTreatment";
                worksheet.Cells["Y1"].Value = "14.หมู่บ้านที่มีระบบบำบัดน้ำเสีย";
                worksheet.Cells["Y2"].Value = "IsCommunityWaterManagementHasWaterTreatment";
                worksheet.Cells["Z1"].Value = "15.พื้นที่ชลประทาน";
                worksheet.Cells["Z2"].Value = "FieldCommunity";
                worksheet.Cells["AA1"].Value = "16.ระดับความลึกของน้ำท่วม (ในเขตที่อยู่อาศัย)";
                worksheet.Cells["AA2"].Value = "AvgWaterHeightCm";
                worksheet.Cells["AB1"].Value = "17.ระยะเวลาที่น้ำท่วมขัง (ในเขตที่อยู่อาศัย)";
                worksheet.Cells["AB2"].Value = "TimeWaterHeightCm";
                worksheet.Cells["AC1"].Value = "18.ระยะเวลาที่มีน้ำประปาใช้ (เดือน) ";
                worksheet.Cells["AC2"].Value = "HasntPlumbing";
                worksheet.Cells["AD1"].Value = "19.สถานที่ราชการทั้งหมด";
                worksheet.Cells["AD2"].Value = "IsGovernment";
                worksheet.Cells["AE1"].Value = "20.สถานที่ราชการที่มีน้ำประปาใช้";
                worksheet.Cells["AE2"].Value = "IsGovernmentUsage";
                worksheet.Cells["AF1"].Value = "21.สถานที่ราชการที่มีน้ำประปาที่มีคุณภาพมาตรฐาน";
                worksheet.Cells["AF2"].Value = "IsGovernmentWaterQuality";
                worksheet.Cells["AG1"].Value = "22.หมู่บ้านในพื้นที่น้ำท่วมซ้ำซากที่มีการเตือนภัยและมาตรการช่วยเหลือ";
                worksheet.Cells["AG2"].Value = "CommunityNatureDisaster";
                worksheet.Cells["AH1"].Value = "สน.1  23.แหล่งน้ำขนาดใหญ่ กลาง และเล็ก";
                worksheet.Cells["AH2"].Value = "WaterSources";
                worksheet.Cells["AI1"].Value = "สน.2 23.แหล่งน้ำขนาดใหญ่ กลาง และเล็ก";
                worksheet.Cells["AI2"].Value = "WaterSources";
                worksheet.Cells["AJ1"].Value = "24.จำนวนโรงงานอุตสาหกรรมที่มีน้ำเสียจากระบบ";
                worksheet.Cells["AJ2"].Value = "IndustryHasWasteWaterTreatment";
                worksheet.Cells["AK1"].Value = "25.ประชากรที่อาศัยในครัวเรือนที่มีน้ำท่วม ";
                worksheet.Cells["AK2"].Value = "PeopleInFloodedArea";
                worksheet.Cells["AL1"].Value = "39.จำนวนหมู่บ้าน/ชุมชนทั้งหมด";
                worksheet.Cells["AL2"].Value = "CountCommunity";
                worksheet.Cells["AM1"].Value = "40.จำนวนหมู่บ้าน/ชุมชนที่มีอุทกภัย ดินโคลนถล่ม";
                worksheet.Cells["AM2"].Value = "CountCommunityHasDisaster";
                worksheet.Cells["AN1"].Value = "41.ครัวเรือนในชนบททั้งหมด";
                worksheet.Cells["AN2"].Value = "ต้องเป็นครัวเรือน/สถานประกอบการที่มีกิจกรรมการใช้น้ำเพื่อการอุปโภคบริโภค (G1) +อยู่ในเขตเทศบาล";
                worksheet.Cells["AO1"].Value = "42.ครัวเรือนในเขตเมืองทั้งหมด";
                worksheet.Cells["AO2"].Value = "ต้องเป็นครัวเรือน/สถานประกอบการที่มีกิจกรรมการใช้น้ำเพื่อการอุปโภคบริโภค (G1) +อยู่นอกเขตเทศบาล";
                worksheet.Cells["AP1"].Value = "43.สถานประกอบการผลิตทั้งหมด";
                worksheet.Cells["AP2"].Value = "ต้องเป็นครัวเรือน/สถานประกอบการที่มีกิจกรรมการใช้น้ำเพื่อการผลิต (G3)";
                worksheet.Cells["AQ1"].Value = "44.สถานประกอบการบริการทั้งหมด";
                worksheet.Cells["AQ2"].Value = "ต้องเป็นครัวเรือน/สถานประกอบการที่มีกิจกรรมการใช้น้ำเพื่อการบริการ (G4)";

                // Print Excel
                foreach (var item in qry)
                {

                    worksheet.Cells[countCells, 1].Value = item.EA;
                    worksheet.Cells[countCells, 2].Value = "-";
                    worksheet.Cells[countCells, 3].Value = item.CWT;
                    worksheet.Cells[countCells, 4].Value = item.CWT_NAME;
                    worksheet.Cells[countCells, 5].Value = item.AMP;
                    worksheet.Cells[countCells, 6].Value = item.AMP_NAME;
                    worksheet.Cells[countCells, 7].Value = item.TAM;
                    worksheet.Cells[countCells, 8].Value = item.TAM_NAME;
                    worksheet.Cells[countCells, 9].Value = item.REG;
                    worksheet.Cells[countCells, 10].Value = item.REG_NAME;
                    worksheet.Cells[countCells, 11].Value = item.IsAgriculture;
                    worksheet.Cells[countCells, 12].Value = item.IsHouseHold;
                    worksheet.Cells[countCells, 13].Value = item.IsHouseHoldGoodPlumbing;
                    worksheet.Cells[countCells, 14].Value = item.IsAgricultureHasIrrigationField;
                    worksheet.Cells[countCells, 15].Value = item.IsHouseHoldHasPlumbingDistrict;
                    worksheet.Cells[countCells, 16].Value = item.IsHouseHoldHasPlumbingCountryside;
                    worksheet.Cells[countCells, 17].Value = item.IsFactorialWaterQuality;
                    worksheet.Cells[countCells, 18].Value = item.IsCommercialWaterQuality;
                    worksheet.Cells[countCells, 19].Value = item.SumGroundWaters11;
                    worksheet.Cells[countCells, 20].Value = item.SumGroundWaters22;
                    worksheet.Cells[countCells, 21].Value = item.CountPopulation;
                    worksheet.Cells[countCells, 22].Value = item.CountWorkingAge;
                    worksheet.Cells[countCells, 23].Value = item.IsFactorial;
                    worksheet.Cells[countCells, 24].Value = item.IsFactorialWaterTreatment;
                    worksheet.Cells[countCells, 25].Value = item.IsCommunityWaterManagementHasWaterTreatment;
                    worksheet.Cells[countCells, 26].Value = item.FieldCommunity;
                    worksheet.Cells[countCells, 27].Value = item.AvgWaterHeightCm;
                    worksheet.Cells[countCells, 28].Value = item.TimeWaterHeightCm;
                    worksheet.Cells[countCells, 29].Value = item.HasntPlumbing;
                    worksheet.Cells[countCells, 30].Value = item.IsGovernment;
                    worksheet.Cells[countCells, 31].Value = item.IsGovernmentUsage;
                    worksheet.Cells[countCells, 32].Value = item.IsGovernmentWaterQuality;
                    worksheet.Cells[countCells, 33].Value = item.CommunityNatureDisaster;
                    worksheet.Cells[countCells, 34].Value = item.SumWaterSourcess11;
                    worksheet.Cells[countCells, 35].Value = item.SumWaterSourcess22;
                    worksheet.Cells[countCells, 36].Value = item.IndustryHasWasteWaterTreatment;
                    worksheet.Cells[countCells, 37].Value = item.PeopleInFloodedArea;
                    worksheet.Cells[countCells, 38].Value = item.CountCommunity;
                    worksheet.Cells[countCells, 39].Value = item.CountCommunityHasDisaster;
                    worksheet.Cells[countCells, 40].Value = item.HouseHoldInCity;
                    worksheet.Cells[countCells, 41].Value = item.HouseHoldOutCity;
                    worksheet.Cells[countCells, 42].Value = item.HouseHoldFac;
                    worksheet.Cells[countCells, 43].Value = item.HouseHoldCom;
                }

                //worksheet.Cells[countCells, 44].Value = "";
                //worksheet.Cells[countCells, 45].Value = "";
                //worksheet.Cells[countCells, 46].Value = "";
                //worksheet.Cells[countCells, 47].Value = "";
                //worksheet.Cells[countCells, 48].Value = "";
                //worksheet.Cells[countCells, 49].Value = "";
                //worksheet.Cells[countCells, 50].Value = "";
                //worksheet.Cells[countCells, 51].Value = "";
                //worksheet.Cells[countCells, 52].Value = "";
                //worksheet.Cells[countCells, 53].Value = "";
                //worksheet.Cells[countCells, 54].Value = "";
                //worksheet.Cells[countCells, 55].Value = "";
                Console.Write($"{count} : ");
                Console.WriteLine($"{count} Complete !!");
                countCells++;
                excelPackage.SaveAs(new FileInfo(partFile));
            }
        }
        //Areaaaaaa
        public static void GroupArea(string filename)
        {
            Console.WriteLine("Hello World!");
            var partFile = $@"D:\{{filename}}.xlsx";
            var client = new MongoClient("mongodb://firstclass:Th35F1rstCla55@mongodbproykgte5e7lvm7y-vm0.southeastasia.cloudapp.azure.com/pdata");
            var database = client.GetDatabase("nso");
            var collectionData = database.GetCollection<DataProcessed>("q2");


            var client2 = new MongoClient("mongodb://dbagent:Nso4Passw0rd5@mongodbproykgte5e7lvm7y-vm0.southeastasia.cloudapp.azure.com/nso");
            var database2 = client.GetDatabase("nso");
            var collectionReport = database.GetCollection<ReportEaInfo>("reporteainfo");
            var countCells = 4;
            var count = 1;
            var qrysub = collectionReport.Aggregate().Group(it => it.Area_Code, p => new DataByArea
            {
                //40data
            }).ToList();

            foreach (var item in qrysub)
            {
                // Create Model 40 Area_code
                var r = collectionReport.Find(it => it.TAM == item.Area_Code).FirstOrDefault();
                //item.CWT = r.CWT
            }

            //Excel
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add($"EA Report");

                using (ExcelRange range = worksheet.Cells["A1:AQ3"])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.WrapText = true;
                    range.Style.Font.Bold = true;
                }
                using (ExcelRange range = worksheet.Cells["A3:AQ3"])
                {
                    range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                }

                worksheet.Cells["A1:A2"].Merge = true;
                worksheet.Cells["A1:A2"].Value = "EA";
                worksheet.Cells["A1:A2"].Merge = true;
                worksheet.Cells["B1:B2"].Value = "รหัส";
                worksheet.Cells["B1:B2"].Merge = true;
                worksheet.Cells["C1"].Value = "รหัสตำบล";
                worksheet.Cells["C1:C2"].Merge = true;
                worksheet.Cells["D1"].Value = "ตำบล";
                worksheet.Cells["D1:D2"].Merge = true;
                worksheet.Cells["E1"].Value = "รหัสอำเภอ";
                worksheet.Cells["E1:E2"].Merge = true;
                worksheet.Cells["F1"].Value = "อำเภอ";
                worksheet.Cells["F1:F2"].Merge = true;
                worksheet.Cells["G1"].Value = "รหัสจังหวัด";
                worksheet.Cells["G1:G2"].Merge = true;
                worksheet.Cells["H1"].Value = "จังหวัด";
                worksheet.Cells["H1:H2"].Merge = true;
                worksheet.Cells["I1"].Value = "รหัสภูมิภาค";
                worksheet.Cells["I1:I2"].Merge = true;
                worksheet.Cells["J1"].Value = "ภูมิภาค";
                worksheet.Cells["J1:J2"].Merge = true;
                worksheet.Cells["K1"].Value = "สน.1 9.จำนวนบ่อน้ำบาดาล";
                worksheet.Cells["K2"].Value = "CountGroundWater";
                worksheet.Cells["L1"].Value = "สน.2 9.จำนวนบ่อน้ำบาดาล";
                worksheet.Cells["L2"].Value = "CountGroundWater";
                worksheet.Cells["M1"].Value = "สน.1 23.แหล่งน้ำขนาดใหญ่ กลาง และเล็ก";
                worksheet.Cells["M2"].Value = "WaterSources";
                worksheet.Cells["N1"].Value = "สน.2 23.แหล่งน้ำขนาดใหญ่ กลาง และเล็ก";
                worksheet.Cells["N2"].Value = "WaterSources";
                worksheet.Cells["O1"].Value = "26.ปริมาณการใช้น้ำบาดาลเพื่อการเกษตร(น้ำบาดาล น้ำซื้อ)";
                worksheet.Cells["O2"].Value = "CubicMeterGroundWaterForAgriculture";
                worksheet.Cells["P1"].Value = "27.ปริมาณการใช้น้ำบาดาลเพื่อการบริการ(น้ำบาดาล น้ำซื้อ)";
                worksheet.Cells["P2"].Value = "CubicMeterGroundWaterForService";
                worksheet.Cells["Q1"].Value = "28.ปริมาณการใช้น้ำบาดาลเพื่อการอุตสาหกรรม(น้ำบาดาล น้ำซื้อ)";
                worksheet.Cells["Q2"].Value = "CubicMeterGroundWaterForProduct";
                worksheet.Cells["R1"].Value = "29.ปริมาณการใช้น้ำบาดาลเพื่อการอุปโภคบริโภค(น้ำบาดาล น้ำซื้อ)";
                worksheet.Cells["R2"].Value = "CubicMeterGroundWaterForDrink";
                worksheet.Cells["S1"].Value = "30.ปริมาณการใช้น้ำประปาเพื่อการเกษตร";
                worksheet.Cells["S2"].Value = "CubicMeterPlumbingForAgriculture";
                worksheet.Cells["T1"].Value = "31.ปริมาณการใช้น้ำประปาเพื่อการบริการ";
                worksheet.Cells["T2"].Value = "CubicMeterPlumbingForService";
                worksheet.Cells["U1"].Value = "32.ปริมาณการใช้น้ำประปาเพื่อการอุตสาหกรรม";
                worksheet.Cells["U2"].Value = "CubicMeterPlumbingForProduct";
                worksheet.Cells["V1"].Value = "33.ปริมาณการใช้น้ำประปาเพื่อการอุปโภคบริโภค ";
                worksheet.Cells["V2"].Value = "CubicMeterPlumbingForDrink";
                worksheet.Cells["W1"].Value = "34.ปริมาณการใช้น้ำผิวดินเพื่อการเกษตร (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)";
                worksheet.Cells["W2"].Value = "CubicMeterSurfaceForAgriculture";
                worksheet.Cells["X1"].Value = "35.ปริมาณการใช้น้ำผิวดินเพื่อการบริการ (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)";
                worksheet.Cells["X2"].Value = "CubicMeterSurfaceForService";
                worksheet.Cells["Y1"].Value = "36.ปริมาณการใช้น้ำผิวดินเพื่อการอุตสาหกรรม (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)";
                worksheet.Cells["Y2"].Value = "CubicMeterSurfaceForProduct";
                worksheet.Cells["Z1"].Value = "37.ปริมาณการใช้น้ำผิวดินเพื่อการอุปโภคบริโภค (สระน้ำ แม่น้ำ ชลประทาน น้ำฝนกักเก็บ)";
                worksheet.Cells["Z2"].Value = "CubicMeterSurfaceForDrink";
                worksheet.Cells["AA1"].Value = "38.ปริมาณน้ำบาดาลที่พัฒนามาใช้ (ปริมาณน้ำจากรายการ 26-29)";
                worksheet.Cells["AA2"].Value = "CubicMeterGroundWaterForUse";
                //worksheet.Cells["AB1"].Value ="";
                //worksheet.Cells["AB2"].Value ="";
                //worksheet.Cells["AC1"].Value ="";
                //worksheet.Cells["AC2"].Value ="";
                //worksheet.Cells["AD1"].Value ="";
                //worksheet.Cells["AD2"].Value ="";
                //worksheet.Cells["AE1"].Value ="";
                //worksheet.Cells["AE2"].Value ="";
                //worksheet.Cells["AF1"].Value ="";
                //worksheet.Cells["AF2"].Value ="";
                //worksheet.Cells["AG1"].Value ="";
                //worksheet.Cells["AG2"].Value ="";
                //worksheet.Cells["AH1"].Value ="";
                //worksheet.Cells["AH2"].Value ="";
                //worksheet.Cells["AI1"].Value ="";
                //worksheet.Cells["AI2"].Value ="";
                //worksheet.Cells["AJ1"].Value ="";
                //worksheet.Cells["AJ2"].Value ="";
                //worksheet.Cells["AK1"].Value ="";
                //worksheet.Cells["AK2"].Value ="";
                //worksheet.Cells["AL1"].Value ="";
                //worksheet.Cells["AL2"].Value ="";
                //worksheet.Cells["AM1"].Value ="";
                //worksheet.Cells["AM2"].Value ="";
                //worksheet.Cells["AN1"].Value ="";
                //worksheet.Cells["AN2"].Value ="";
                //worksheet.Cells["AO1"].Value ="";
                //worksheet.Cells["AO2"].Value ="";
                //worksheet.Cells["AP1"].Value ="";
                //worksheet.Cells["AP2"].Value ="";
                //worksheet.Cells["AQ1"].Value ="";
                //worksheet.Cells["AQ2"].Value ="";

                // Print Excel
                worksheet.Cells[countCells, 1].Value = "";
                worksheet.Cells[countCells, 2].Value = "";
                worksheet.Cells[countCells, 3].Value = "";
                worksheet.Cells[countCells, 4].Value = "";
                worksheet.Cells[countCells, 5].Value = "";
                worksheet.Cells[countCells, 6].Value = "";
                worksheet.Cells[countCells, 7].Value = "";
                worksheet.Cells[countCells, 8].Value = "";
                worksheet.Cells[countCells, 9].Value = "";
                worksheet.Cells[countCells, 10].Value = "";
                worksheet.Cells[countCells, 11].Value = "";
                worksheet.Cells[countCells, 12].Value = "";
                worksheet.Cells[countCells, 13].Value = "";
                worksheet.Cells[countCells, 14].Value = "";
                worksheet.Cells[countCells, 15].Value = "";
                worksheet.Cells[countCells, 16].Value = "";
                worksheet.Cells[countCells, 17].Value = "";
                worksheet.Cells[countCells, 18].Value = "";
                worksheet.Cells[countCells, 19].Value = "";
                worksheet.Cells[countCells, 20].Value = "";
                worksheet.Cells[countCells, 21].Value = "";
                worksheet.Cells[countCells, 22].Value = "";
                worksheet.Cells[countCells, 23].Value = "";
                worksheet.Cells[countCells, 24].Value = "";
                worksheet.Cells[countCells, 25].Value = "";
                worksheet.Cells[countCells, 26].Value = "";
                worksheet.Cells[countCells, 27].Value = "";
                //worksheet.Cells[countCells, 28].Value = "";
                //worksheet.Cells[countCells, 29].Value = "";
                //worksheet.Cells[countCells, 30].Value = "";
                //worksheet.Cells[countCells, 31].Value = "";
                //worksheet.Cells[countCells, 32].Value = "";
                //worksheet.Cells[countCells, 33].Value = "";
                //worksheet.Cells[countCells, 34].Value = "";
                //worksheet.Cells[countCells, 35].Value = "";
                //worksheet.Cells[countCells, 36].Value = "";
                //worksheet.Cells[countCells, 37].Value = "";
                //worksheet.Cells[countCells, 38].Value = "";
                //worksheet.Cells[countCells, 39].Value = "";
                //worksheet.Cells[countCells, 40].Value = "";
                //worksheet.Cells[countCells, 41].Value = "";
                //worksheet.Cells[countCells, 42].Value = "";
                //worksheet.Cells[countCells, 43].Value = "";
                //worksheet.Cells[countCells, 44].Value = "";
                //worksheet.Cells[countCells, 45].Value = "";
                //worksheet.Cells[countCells, 46].Value = "";
                //worksheet.Cells[countCells, 47].Value = "";
                //worksheet.Cells[countCells, 48].Value = "";
                //worksheet.Cells[countCells, 49].Value = "";
                //worksheet.Cells[countCells, 50].Value = "";
                //worksheet.Cells[countCells, 51].Value = "";
                //worksheet.Cells[countCells, 52].Value = "";
                //worksheet.Cells[countCells, 53].Value = "";
                //worksheet.Cells[countCells, 54].Value = "";
                //worksheet.Cells[countCells, 55].Value = "";
                Console.Write($"{count} : ");
                Console.WriteLine($"{count} Complete !!");
                countCells++;
                excelPackage.SaveAs(new FileInfo(partFile));
            }
        }
    }
}
