using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NPOI.SS.UserModel;

namespace FishClient
{
    public class ExportUtil
    {
        public static void  ExportQuote(List<FishEntity.ProductQuoteVo> list , string filepath )
        {
            MemoryStream ms = GetMS(list);
            SaveToFile(ms, filepath);
        }

        public static void ExportConfirm(List<FishEntity.ProductConfirmVo> list, string filepath)
        {
            MemoryStream ms = GetMS(list);
            SaveToFile(ms,filepath );
        }

        public static void ExportCallRecords(List<FishEntity.CallRecordsEntity> list, string filepath)
        {
            MemoryStream ms = GetMS(list);
            SaveToFile(ms, filepath);
        }

        public static void ExportRequreForecast(List<FishEntity.CompanyEntity> list, string filepath)
        {
            MemoryStream ms = GetMS(list);
            SaveToFile(ms, filepath);
        }

        public static void ExportSelfStorageFlowing(List<FishEntity.SelfStorageFlowingReportVo> list, string filepath)
        {
            MemoryStream ms = GetMS(list);
            SaveToFile(ms, filepath);
        }

        public static void ExportStorageReport(List<FishEntity.ProductEntity> list, string filepath)
        {
            MemoryStream ms = GetMStream(list);
            SaveToFile(ms, filepath);
        }

        protected static MemoryStream GetMS(List<FishEntity.ProductQuoteVo> list)
        {
            MemoryStream ms = new MemoryStream();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            ICellStyle cellStyle = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 26;

            CreateCell(row, 0, "报盘", CellType.String, cellStyle);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 22));
            row = sheet.CreateRow(1);
            cellStyle = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Bold);
            CreateCell(row, 0, "鱼粉ID", CellType.String, cellStyle);
            CreateCell(row, 1, "单位", CellType.String, cellStyle);
            CreateCell(row, 2, "联系人", CellType.String, cellStyle);
            CreateCell(row, 3, "国别", CellType.String, cellStyle);
            CreateCell(row, 4, "货物情况", CellType.String, cellStyle);
            CreateCell(row, 5, "品质", CellType.String, cellStyle);
            CreateCell(row, 6, "最新报盘日期", CellType.String, cellStyle);
            CreateCell(row, 7, "船期最快", CellType.String, cellStyle);
            CreateCell(row, 8, "船期最慢", CellType.String, cellStyle);
            CreateCell(row, 9, "重量", CellType.String, cellStyle);
            CreateCell(row, 10, "数量", CellType.String, cellStyle);
            CreateCell(row, 11, "蛋白", CellType.String, cellStyle);
            CreateCell(row, 12, "TVN", CellType.String, cellStyle);
            CreateCell(row, 13, "组胺", CellType.String, cellStyle);
            CreateCell(row, 14, "FFA", CellType.String, cellStyle);
            CreateCell(row, 15, "盐和砂", CellType.String, cellStyle);
            CreateCell(row, 16, "灰分", CellType.String, cellStyle);
            CreateCell(row, 17, "备注", CellType.String, cellStyle);
            CreateCell(row, 18, "品牌", CellType.String, cellStyle);
            CreateCell(row, 19, "汇率", CellType.String, cellStyle);
            CreateCell(row, 20, "美金价", CellType.String, cellStyle);
            CreateCell(row, 21, "人民币价", CellType.String, cellStyle);

            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.ProductQuoteVo model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.code);
                    CreateCell(row, 1, model.quotesupplier);
                    CreateCell(row, 2, model.quotelinkman);
                    CreateCell(row, 3, model.nature);
                    CreateCell(row, 4, model.goodsinfo);
                    CreateCell(row, 5, model.specification);
                    CreateCell(row, 6, model.quotedate);
                    CreateCell(row, 7, model.quotesaildatefast);
                    CreateCell(row, 8, model.quotesaildatelate);
                    CreateCell(row, 9, model.quoteweight.ToString("f2"));
                    CreateCell(row, 10, model.quotequantity.ToString());
                    CreateCell(row, 11, model.quote_protein.ToString());
                    CreateCell(row, 12, model.quote_tvn.ToString());
                    CreateCell(row, 13, model.quote_amine.ToString());
                    CreateCell(row, 14, model.quote_ffa.ToString());
                    CreateCell(row, 15, model.quote_sandsalt.ToString());
                    CreateCell(row, 16, model.quote_graypart.ToString());
                    CreateCell(row, 17, model.remark==null ? "": model.remark.ToString());
                    CreateCell(row, 18, model.brand);
                    CreateCell(row, 19, "");
                    CreateCell(row, 20, model.quotedollars.ToString());
                    CreateCell(row, 21, model.quotermb.ToString() );

                    # endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }


        protected static MemoryStream GetMStream(List<FishEntity.ProductEntity> list)
        {
            MemoryStream ms = new MemoryStream();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            ICellStyle cellStyle = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 26;

            CreateCell(row, 0, "库存（期货、现货）汇总表", CellType.String, cellStyle);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 17));
            row = sheet.CreateRow(1);
            cellStyle = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Bold);
            CreateCell(row, 0, "鱼粉ID", CellType.String, cellStyle);
            CreateCell(row, 1, "品名", CellType.String, cellStyle);
            CreateCell(row, 2, "状态", CellType.String, cellStyle);
            CreateCell(row, 3, "重量(吨)", CellType.String, cellStyle);
            CreateCell(row, 4, "数量(包)", CellType.String, cellStyle);
            CreateCell(row, 5, "自制仓重量", CellType.String, cellStyle);
            CreateCell(row, 6, "自制仓包数", CellType.String, cellStyle);
            CreateCell(row, 7, "国别", CellType.String, cellStyle);
            CreateCell(row, 8, "工艺分类", CellType.String, cellStyle);
            CreateCell(row, 9, "品质规格", CellType.String, cellStyle);
            CreateCell(row, 10, "品牌", CellType.String, cellStyle);
            CreateCell(row, 11, "所属货主", CellType.String, cellStyle);
            CreateCell(row, 12, "到港时间", CellType.String, cellStyle);
            CreateCell(row, 13, "代理开证公司", CellType.String, cellStyle);
            CreateCell(row, 14, "货代报关公司", CellType.String, cellStyle);
            CreateCell(row, 15, "SGS(蛋白)", CellType.String, cellStyle);
            CreateCell(row, 16, "SGS(TVN)", CellType.String, cellStyle);
            CreateCell(row, 17, "组胺", CellType.String, cellStyle);


            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.ProductEntity model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.code);
                    CreateCell(row, 1, model.name);
                    CreateCell(row, 2, model.statename);
                    CreateCell(row, 3, model.weight.ToString());
                    CreateCell(row, 4, model.quantity.ToString());
                    CreateCell(row, 5, model.homemadeweight.ToString());
                    CreateCell(row, 6, model.homemadepackages.ToString());
                    CreateCell(row, 7, model.nature);
                    CreateCell(row, 8, model.techtype);
                    CreateCell(row, 9, model.specification);
                    CreateCell(row, 10, model.brand);
                    CreateCell(row, 11, model.ownername);
                    CreateCell(row, 12, model.arriveportdate);
                    CreateCell(row, 13, model.agentifcompany);
                    CreateCell(row, 14, model.customsofcompany);
                    CreateCell(row, 15, model.sgs_protein.ToString());
                    CreateCell(row, 16, model.sgs_tvn.ToString());
                    CreateCell(row, 17, model.sgs_amine.ToString());

                    # endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        protected static MemoryStream GetMS(List<FishEntity.ProductConfirmVo> list)
        {
            MemoryStream ms = new MemoryStream();

            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            #region head row
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            ICellStyle style = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            row.HeightInPoints = 26;

            CreateCell(row, 0, "确盘", CellType.String, style);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 28));

            row = sheet.CreateRow(1);

            style = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Normal);
            CreateCell(row, 0, "鱼粉ID", CellType.String, style);
            CreateCell(row, 1, "报盘单位", CellType.String, style);
            CreateCell(row, 2, "联系人", CellType.String, style);
            CreateCell(row, 3, "国别", CellType.String, style);
            CreateCell(row, 4, "品质", CellType.String, style);
            CreateCell(row, 5, "最新报盘日期", CellType.String, style);
            CreateCell(row, 6, "船期最快", CellType.String, style);
            CreateCell(row, 7, "船期最晚", CellType.String, style);
            CreateCell(row, 8, "蛋白", CellType.String, style);
            CreateCell(row, 9, "TVN", CellType.String, style);
            CreateCell(row, 10, "组胺", CellType.String, style);
            CreateCell(row, 11, "FFA", CellType.String, style);
            CreateCell(row, 12, "盐和砂", CellType.String, style);
            CreateCell(row, 13, "灰份", CellType.String, style);
            CreateCell(row, 14, "备注", CellType.String, style);
            CreateCell(row, 15, "开证单位", CellType.String, style);
            CreateCell(row, 16, "联系人", CellType.String, style);
            CreateCell(row, 17, "SGS重量", CellType.String, style);
            CreateCell(row, 18, "品牌", CellType.String, style);
            CreateCell(row, 19, "船期", CellType.String, style);
            CreateCell(row, 20, "蛋白", CellType.String, style);
            CreateCell(row, 21, "TVN", CellType.String, style);
            CreateCell(row, 22, "组胺", CellType.String, style);
            CreateCell(row, 23, "FFA", CellType.String, style);
            CreateCell(row, 24, "盐和砂", CellType.String, style);
            CreateCell(row, 25, "灰份", CellType.String, style);
            CreateCell(row, 26, "日期", CellType.String, style);
            CreateCell(row, 27, "美元价", CellType.String, style);
            CreateCell(row, 28, "人民币价", CellType.String, style);


            #endregion

            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.ProductConfirmVo model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.code);
                    CreateCell(row, 1, model.quotesupplier);
                    CreateCell(row, 2, model.quotelinkman);
                    CreateCell(row, 3, model.nature);
                    CreateCell(row, 4, model.specification);
                    CreateCell(row, 5, model.quotedate);
                    CreateCell(row, 6, model.quotesaildatefast);
                    CreateCell(row, 7, model.quotesaildatelate);
                    CreateCell(row, 8, model.quote_protein.ToString());
                    CreateCell(row, 9, model.quote_tvn.ToString());
                    CreateCell(row, 10, model.quote_amine.ToString());
                    CreateCell(row, 11, model.quote_ffa.ToString());
                    CreateCell(row, 12, model.quote_sandsalt.ToString());
                    CreateCell(row, 13, model.quote_graypart.ToString());
                    CreateCell(row, 14, model.remark);
                    CreateCell(row, 15, model.confirmagent);
                    CreateCell(row, 16, model.confirmlinkman);
                    CreateCell(row, 17, model.confirmsgsweight.ToString("f2"));
                    CreateCell(row, 18, model.brand);
                    CreateCell(row, 19, model.confirmsaildate);
                    
                    CreateCell(row, 20, model.sgs_protein.ToString());
                    CreateCell(row, 21, model.sgs_tvn.ToString());
                    CreateCell(row, 22, model.sgs_amine.ToString());
                    CreateCell(row, 23, model.sgs_ffa.ToString ());
                    CreateCell(row, 24, model.sgs_sandsalt.ToString());
                    CreateCell(row, 25, model.sgs_graypart.ToString());
                    CreateCell(row, 26, model.confirmdate);
                    CreateCell(row, 27, model.confirmdollars.ToString ("f2"));
                    CreateCell(row, 28, model.confirmrmb.ToString ("f2"));

                    #endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        protected static MemoryStream GetMS(List<FishEntity.SelfStorageFlowingReportVo> list)
        {
            MemoryStream ms = new MemoryStream();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            ICellStyle cellStyle = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 26;

            CreateCell(row, 0, "自营自制库存流水账", CellType.String, cellStyle);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 18));
            row = sheet.CreateRow(1);
            cellStyle = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Bold);
            CreateCell(row, 0, "鱼粉ID", CellType.String, cellStyle);
            CreateCell(row, 1, "品名", CellType.String, cellStyle);
            CreateCell(row, 2, "状态", CellType.String, cellStyle);
            CreateCell(row, 3, "单据类型", CellType.String, cellStyle);
            CreateCell(row, 4, "单据号码", CellType.String, cellStyle);
            CreateCell(row, 5, "日期", CellType.String, cellStyle);
            CreateCell(row, 6, "出/入库存", CellType.String, cellStyle);
            CreateCell(row, 7, "重量(吨)", CellType.String, cellStyle);
            CreateCell(row, 8, "数量(包)", CellType.String, cellStyle);
            CreateCell(row, 9, "国别", CellType.String, cellStyle);
            CreateCell(row, 10, "工艺分类", CellType.String, cellStyle);
            CreateCell(row, 11, "品质规格", CellType.String, cellStyle);
            CreateCell(row, 12, "所属货主", CellType.String, cellStyle);
            CreateCell(row, 13, "到港时间", CellType.String, cellStyle);
            CreateCell(row, 14, "代理开证公司", CellType.String, cellStyle);
            CreateCell(row, 15, "货代报关公司", CellType.String, cellStyle);
            CreateCell(row, 16, "SGS(蛋白)", CellType.String, cellStyle);
            CreateCell(row, 17, "SGS(TVN)", CellType.String, cellStyle);
            CreateCell(row, 18, "组胺", CellType.String, cellStyle);


            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.SelfStorageFlowingReportVo model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.productcode );
                    CreateCell(row, 1, model.productname );
                    CreateCell(row, 2, model.statename  );
                    CreateCell(row, 3, model.billtype );
                    CreateCell(row, 4, model.billcode );
                    CreateCell(row, 5, model.date.ToString("yyyy-MM-dd"));
                    CreateCell(row, 6, model.storagetype);
                    CreateCell(row, 7, model.weight.ToString() );
                    CreateCell(row, 8, model.package .ToString () );
                    CreateCell(row, 9, model.nature);
                    CreateCell(row, 10, model.techtype );
                    CreateCell(row, 11, model.specification );
                    CreateCell(row, 12, model.ownername );
                    CreateCell(row, 13, model.arriveportdate );
                    CreateCell(row, 14, model.agentifcompany);
                    CreateCell(row, 15, model.customsofcompany);
                    CreateCell(row, 16, model.sgs_protein.ToString () );
                    CreateCell(row, 17, model.sgs_tvn.ToString());
                    CreateCell(row, 18, model.sgs_amine.ToString());

                    # endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }


        protected static MemoryStream GetMS(List<FishEntity.CompanyEntity> list)
        {
            MemoryStream ms = new MemoryStream();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            ICellStyle cellStyle = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 26;

            CreateCell(row, 0, "客户市场需求预测表", CellType.String, cellStyle);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 12));
            row = sheet.CreateRow(1);
            cellStyle = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Bold);
            CreateCell(row, 0, "客户编号", CellType.String, cellStyle);
            CreateCell(row, 1, "客户名称", CellType.String, cellStyle);
            CreateCell(row, 2, "类别", CellType.String, cellStyle);
            CreateCell(row, 3, "综合等级", CellType.String, cellStyle);
            CreateCell(row, 4, "需求量等级", CellType.String, cellStyle);
            CreateCell(row, 5, "活跃程度", CellType.String, cellStyle);
            CreateCell(row, 6, "忠诚度", CellType.String, cellStyle);
            CreateCell(row, 7, "主要产品", CellType.String, cellStyle);
            CreateCell(row, 8, "业务员", CellType.String, cellStyle);
            CreateCell(row, 9, "联系人", CellType.String, cellStyle);
            CreateCell(row, 10, "最近联系日期", CellType.String, cellStyle);
            CreateCell(row, 11, "最近周预估", CellType.String, cellStyle);
            CreateCell(row, 12, "最近月预估", CellType.String, cellStyle);

            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.CompanyEntity model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.code);
                    CreateCell(row, 1, model.fullname);
                    CreateCell(row, 2, model.type);
                    CreateCell(row, 3, model.generallevel);
                    CreateCell(row, 4, model.requiredlevel);
                    CreateCell(row, 5, model.managestandard);
                    CreateCell(row, 6, model.activelevel);
                    CreateCell(row, 7, model.products);
                    CreateCell(row, 8, model.salesman);
                    CreateCell(row, 9, model.linkman );
                    CreateCell(row, 10, model.currentlink);
                    CreateCell(row, 11, model.currentweekestimate);
                    CreateCell(row, 12, model.currentmonthestimate);
                    # endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        protected static MemoryStream GetMS(List<FishEntity.CallRecordsEntity> list)
        {
            MemoryStream ms = new MemoryStream();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            ICellStyle cellStyle = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 26;
            
            CreateCell(row, 0, "通话记录表", CellType.String, cellStyle);
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(row.RowNum, row.RowNum, 0, 12));
            row = sheet.CreateRow(1);
            cellStyle = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Bold);
            CreateCell(row, 0, "记录单号", CellType.String, cellStyle);
            CreateCell(row, 1, "客户名称", CellType.String, cellStyle);
            CreateCell(row, 2, "联系人", CellType.String, cellStyle);
            CreateCell(row, 3, "移动电话", CellType.String, cellStyle);
            CreateCell(row, 4, "固定电话", CellType.String, cellStyle);
            CreateCell(row, 5, "客户等级", CellType.String, cellStyle);
            CreateCell(row, 6, "日期", CellType.String, cellStyle);
            CreateCell(row, 7, "沟通内容", CellType.String, cellStyle);
            CreateCell(row, 8, "品质要求", CellType.String, cellStyle);
            CreateCell(row, 9, "主要产品", CellType.String, cellStyle);
            CreateCell(row, 10, "估计周用量", CellType.String, cellStyle);
            CreateCell(row, 11, "估计月用量", CellType.String, cellStyle);
            CreateCell(row, 12, "地址", CellType.String, cellStyle);
            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.CallRecordsEntity model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.code);
                    CreateCell(row, 1, model.customer);
                    CreateCell(row, 2, model.linkman);
                    CreateCell(row, 3, model.mobile);
                    CreateCell(row, 4, model.telephone);
                    CreateCell(row, 5, model.customerlevel);
                    CreateCell(row, 6, model.currentdate.Value.ToString("yyyy-MM-dd"));
                    CreateCell(row, 7, model.communicatecontent);
                    CreateCell(row, 8, model.requiredquantity);
                    CreateCell(row, 9, model.products);
                    CreateCell(row, 10, model.weekestimate);
                    CreateCell(row, 11, model.monthestimate);
                    CreateCell(row, 12, model.address);
                    # endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        protected static ICellStyle CreateCellStyle( IWorkbook workbook  , short  fontHeight , short boldWeight )
        {
            ICellStyle style = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = fontHeight;
           // font.FontHeight = fontHeight;
            font.Boldweight = boldWeight; //(short)FontBoldWeight.Bold;
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            
            return style;
        }

        protected static MemoryStream GetMS( List<FishEntity.ProductEntity> list )
        {
            MemoryStream ms = new MemoryStream();

            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            #region head row
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            ICellStyle style = CreateCellStyle(workbook, 18, (short)FontBoldWeight.Bold);                     
            row.HeightInPoints = 26;

            CreateCell(row, 0, "报盘", CellType.String, style);
            sheet.AddMergedRegion ( new NPOI.SS.Util.CellRangeAddress( row.RowNum , row.RowNum , 0,20));

            row = sheet.CreateRow(1);

            style = CreateCellStyle(workbook, 10, (short)FontBoldWeight.Normal);
            CreateCell(row, 0, "供应商", CellType.String, style);
            CreateCell(row, 1, "联系人", CellType.String, style);
            CreateCell(row, 2, "品质", CellType.String, style);
            CreateCell(row, 3, "鱼粉ID", CellType.String, style);
            CreateCell(row, 4, "状态", CellType.String, style);
            CreateCell(row, 5, "年份", CellType.String, style);
            CreateCell(row, 6, "装货时间", CellType.String, style);
            CreateCell(row, 7, "蛋白", CellType.String, style);
            CreateCell(row, 8, "TVN", CellType.String, style);
            CreateCell(row, 9, "灰份", CellType.String, style);
            CreateCell(row, 10, "沙盐", CellType.String, style);
            CreateCell(row, 11, "组胺", CellType.String, style);
            CreateCell(row, 12, "FFA", CellType.String, style);
            CreateCell(row, 13, "脂肪", CellType.String, style);
            CreateCell(row, 14, "水份", CellType.String, style);
            CreateCell(row, 15, "沙", CellType.String, style);
            CreateCell(row, 16, "数量/吨", CellType.String, style);
            CreateCell(row, 17, "备注", CellType.String, style);
            CreateCell(row, 18, "品牌", CellType.String, style);
            CreateCell(row, 19, "最近报价", CellType.String, style);

            #endregion

            if (list != null && list.Count > 0)
            {
                int rowidx = 1;
                foreach (FishEntity.ProductEntity model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.supplier);
                    CreateCell(row, 1, model.linkman);
                    CreateCell(row, 2, model.quality);
                    CreateCell(row, 3, model.code);
                    CreateCell(row, 4, model.statename);
                    CreateCell(row, 5, "");
                    CreateCell(row, 6, "");
                    CreateCell(row, 7, model.quote_protein.ToString());
                    CreateCell(row, 8, model.quote_tvn.ToString());
                    CreateCell(row, 9, model.quote_graypart.ToString());
                    CreateCell(row, 10, model.quote_sandsalt.ToString());
                    CreateCell(row, 11, model.quote_amine.ToString());
                    CreateCell(row, 12, model.quote_ffa.ToString());
                    CreateCell(row, 13, model.quote_fat.ToString());
                    CreateCell(row, 14, model.quote_water.ToString());
                    CreateCell(row, 15, model.quote_sand.ToString ());
                    CreateCell(row, 16, "");
                    CreateCell(row, 17, model.remark);
                    CreateCell(row, 18, model.brand);
                    CreateCell(row, 19, model.latestquote.ToString());
                  
                    #endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        protected static void CreateCell(IRow row, int cellIdx, string txt, CellType type = CellType.String, ICellStyle style = null)
        {
            ICell cell = row.CreateCell(cellIdx, type);
            if (style != null) cell.CellStyle = style;
            cell.SetCellValue(txt);
        }
        
        public static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();

                data = null;
            }
        }    
    }
}
