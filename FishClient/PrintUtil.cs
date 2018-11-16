using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public  class PrintUtil
    {
        /// <summary>
        /// 打印模板文件夹路径
        /// </summary>
        protected static string _reportFolder = Application.StartupPath + "\\Template";

        public static int PrintLoadingBills( FishEntity.LoadingBillsEntity entity , List<FishEntity.LoadingDetailEntity> details )
        {
            try
            {
                if ( entity == null ) return -1;
                string reportPath = _reportFolder + "\\LoadingBill.frx";
                if (System.IO.File.Exists(reportPath) == false) return -1;
              
                  FastReport.Report report = new FastReport.Report();
                  report.Load(reportPath);
                  SetParameters< FishEntity.LoadingBillsEntity ,FishEntity.LoadingDetailEntity >( entity , details , report, "detail");

                  SetReportDataSource< FishEntity.LoadingDetailEntity >(report, details , "detail");

                  PrintReport(report, "");
                
                return 1;
            }
            catch (System.Drawing.Printing.InvalidPrinterException pex)
            {
                Utility.LogHelper.WriteException(pex);
                return -4;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteException(ex);
                return -3;
            }
        }

        public static int PrintContract1(FishEntity.ContractEntity entity, List<FishEntity.ContractDetailEntity> details)
        {
            return PrintContract(entity, details, "Contract1.frx");
        }
        public static int PrintContract2(FishEntity.ContractEntity entity, List<FishEntity.ContractDetailEntity> details)
        {
            return PrintContract(entity, details, "Contract2.frx");
        }
        public static int PrintContract3(FishEntity.ContractEntity entity, List<FishEntity.ContractDetailEntity> details)
        {
            return PrintContract(entity, details, "Contract3.frx");
        }

        public static int PrintContract(FishEntity.ContractEntity entity, List<FishEntity.ContractDetailEntity> details, string templatename )
        {
            try
            {
                if (entity == null) return -1;
                string reportPath = _reportFolder + "\\"+templatename;
                if (System.IO.File.Exists(reportPath) == false) return -1;

                FastReport.Report report = new FastReport.Report();
                report.Load(reportPath);
                SetParameters<FishEntity.ContractEntity, FishEntity.ContractDetailEntity>(entity, details, report, "contractdetail");

                SetReportDataSource<FishEntity.ContractDetailEntity>(report, details, "contractdetail");

                PrintReport(report, "");

                return 1;
            }
            catch (System.Drawing.Printing.InvalidPrinterException pex)
            {
                Utility.LogHelper.WriteException(pex);
                return -4;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteException(ex);
                return -3;
            }
        }


        protected static int PrintReport(FastReport.Report report, string printerType)
        {
            //如果模板设置了指定类型的打印机，则设置打印机名称
            //string printerName = GetPrinterName(printerType);
            //if (string.IsNullOrEmpty(printerName) == false)
            //{
            //    report.PrintSettings.Printer = printerName;
            //}

            report.PrintSettings.ShowDialog = false;
   
            report.Print();

            report.Clear();
            report.Dispose();
            report = null;
            return 1;
        }

        protected static void SetParameters<T , H >(T entity , IList<H> details , FastReport.Report report, string dataSourceName )
        {
            System.Reflection.PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                string name = info.Name;
                object value = info.GetValue(entity, null);
                if (report.Parameters.FindByName(name) != null)
                {
                    report.SetParameterValue(name, value);
                }
            }
            System.Data.DataTable dt = Utility.JsonUtil.ToDataTable<H>(details );
            report.RegisterData(dt, dataSourceName);
        }

        protected static void SetReportDataSource<T>(FastReport.Report report, IList<T> items, string dataSourceName)
        {
            System.Data.DataTable dt = Utility.JsonUtil.ToDataTable<T>(items);
            report.RegisterData(dt, dataSourceName);
        }
    }
}
