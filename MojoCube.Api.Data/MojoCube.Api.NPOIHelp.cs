using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System.IO;
using NPOI.XWPF.UserModel;
using NPOI.XSSF.UserModel;
using System.Web;
using NPOI.SS.UserModel;

namespace MojoCube.Api.NPOIHelp
{
    /// <summary>
    ///  数据导出-NPOIHelp
    /// </summary>
    public class NPOIHelp
    {


        #region 数据按固定模板导出

        /*
         * 
         * 调用使用案例
         * using (FileStream fs = System.IO.File.OpenRead(path))
        {
            设置表格
            HSSFWorkbook wk = new HSSFWorkbook(fs);
            fs.Close();
            //设置行
            ISheet sheet = wk.GetSheetAt(0);
            //设置行内容
            sheet.GetRow(0).GetCell(0).SetCellValue("测试");
            //设置列属性
            IRow row = sheet.GetRow(1);
            ICell cell = row.GetCell(0);
            cell.SetCellType(CellType.String);
            cell.SetCellValue("统计单位：" + (System.Web.HttpContext.Current.Session["GG"] as GROUP).NAME + str + "统计时间：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            ExportWorkBook(xxx,xx,xxx);
        }
         * 
         * 
         * **/

        /// <summary>
        /// 根据数据源按固定模板数据填充
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="hssfworkbook">工作簿</param>
        /// <param name="strFileName">下载名称.xls</param>
        /// <param name="rowOffset">偏移行数</param>
        /// <param name="colOffset">偏移列数</param>
        /// <param name="sheetIndex">工作薄索引</param>
        public static void ExportWorkBook(DataTable dataSource, HSSFWorkbook hssfworkbook, string strFileName, int rowOffset = 0, int colOffset = 0, int sheetIndex = 0)
        {
            ISheet sheet = hssfworkbook.GetSheetAt(sheetIndex);
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            //设置单元格上下左右边框线  
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                for (int j = 0; j < dataSource.Columns.Count; j++)
                {
                    IRow row = sheet.GetRow(i + rowOffset);

                    if (row == null)
                        row = sheet.CreateRow(i + rowOffset);
                    NPOI.SS.UserModel.ICell newCell = row.GetCell(j + colOffset);

                    if (newCell == null)
                    {
                        newCell = row.CreateCell(j + colOffset);
                        newCell.CellStyle = cellStyle;
                    }
                    string drValue = dataSource.Rows[i][j].ToString();
                    string drType = dataSource.Columns[j].DataType.ToString();
                    #region 数据类型

                    switch (drType)
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            //newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    #endregion
                }
            }

            //提供下载程序
            ExportHSSFWorkbookByWeb(hssfworkbook, null, strFileName);

        }

        #endregion

        #region  NPOI- 数据导出 xls



        /**
        * 
        *  调用使用案例
        *   DataTable dt = new DataTable();
           dt.Columns.Add("编号", typeof(string));
           DataRow dr = dt.NewRow();
           dr[0] = 1;
           dt.Rows.Add(dr);
           Public.NPOIHelp.ExportXls("/emplate/AdministrationList/Excel/Book1.xls", dt, "一般案件管理.xls");
        * 
        * 
        * ***/

        /// <summary>
        ///  数据导出.xls -wps
        /// </summary>
        /// <param name="localFilePath">模板路径[虚拟路径]</param>
        /// <param name="dtSource">数据源 data</param>
        /// <param name="downLoadName">下载名称</param>
        public static void ExportXls(string localFilePath, DataTable dtSource, string downLoadName, int rowIndex = 0)
        {
            localFilePath = HttpContext.Current.Server.MapPath("~" + localFilePath);
            if (!System.IO.File.Exists(localFilePath))
                new AccessViolationException("模板不存在");

            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }



            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建Sheet，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet();
                    }

                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }

                    }
                    #endregion
                    rowIndex = 1;
                }
                #endregion

                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);
                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion
                rowIndex++;
            }


            //模板文件  
            string path = HttpContext.Current.Server.MapPath(string.Format("~/Template/AdministrationList/Excel{0}.xls", DateTime.Now.ToString()));
            using (FileStream filess = new FileStream(path, FileMode.Create))
            {
                workbook.Write(filess);
                //workbook.Close();
            }

            ExportHSSFWorkbookByWeb(workbook, null, downLoadName);

        }

        #endregion

        #region NPOI- 数据导出 xlsx

        /**
        * 
        *  调用使用案例
        *   DataTable dt = new DataTable();
           dt.Columns.Add("编号", typeof(string));
           DataRow dr = dt.NewRow();
           dr[0] = 1;
           dt.Rows.Add(dr);
           Public.NPOIHelp.ExportXls("/emplate/AdministrationList/Excel/Book1.xls", dt, "一般案件管理.xls");
        * 
        * 
        * ***/

        /// <summary>
        /// 导出Xlsx
        /// </summary>
        /// <param name="localFilePath">文件保存路径[虚拟路径]</param>
        /// <param name="dtSource">数据源</param>
        public static void ExportXlsx(string localFilePath, DataTable dtSource, string fileName)
        {
            XSSFWorkbook xssfworkbook;
            using (FileStream file = new FileStream(HttpContext.Current.Server.MapPath("~" + localFilePath), FileMode.Open, FileAccess.Read))
            {
                //将文件流中模板加载到工作簿对象中
                xssfworkbook = new XSSFWorkbook(file);
            }
            XSSFSheet sheet1 = (XSSFSheet)xssfworkbook.GetSheetAt(0);

            if (dtSource != null)
            {
                int nRow = 1;
                string nextFirstTxt = string.Empty;
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    XSSFRow row = (XSSFRow)sheet1.CreateRow(nRow);
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                    }
                    nRow++;
                }
            }

            //设置响应的类型为Excel
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //设置下载的Excel文件名
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Clear方法删除所有缓存中的HTML输出。但此方法只删除Response显示输入信息，不删除Response头信息。以免影响导出数据的完整性。
            HttpContext.Current.Response.Clear();

            using (MemoryStream ms = new MemoryStream())
            {
                //将工作簿的内容放到内存流中
                xssfworkbook.Write(ms);
                //将内存流转换成字节数组发送到客户端
                HttpContext.Current.Response.BinaryWrite(ms.GetBuffer());
                HttpContext.Current.Response.End();
            }
        
        }
        //add by wuhao start
        public static void ExportXlsx2(string localFilePath, DataTable dtSource, string fileName)
        {
            XSSFWorkbook xssfworkbook;
            using (FileStream file = new FileStream(HttpContext.Current.Server.MapPath("~" + localFilePath), FileMode.Open, FileAccess.Read))
            {
                //将文件流中模板加载到工作簿对象中
                xssfworkbook = new XSSFWorkbook(file);
            }
            XSSFSheet sheet1 = (XSSFSheet)xssfworkbook.GetSheetAt(0);

            if (dtSource != null)
            {
                int nRow = 2;
                string nextFirstTxt = string.Empty;
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    XSSFRow row = (XSSFRow)sheet1.CreateRow(nRow);
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                    }
                    nRow++;
                }
            }

            //设置响应的类型为Excel
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //设置下载的Excel文件名
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            //Clear方法删除所有缓存中的HTML输出。但此方法只删除Response显示输入信息，不删除Response头信息。以免影响导出数据的完整性。
            HttpContext.Current.Response.Clear();

            using (MemoryStream ms = new MemoryStream())
            {
                //将工作簿的内容放到内存流中
                xssfworkbook.Write(ms);
                //将内存流转换成字节数组发送到客户端
                HttpContext.Current.Response.BinaryWrite(ms.GetBuffer());
                HttpContext.Current.Response.End();
            }

        }
        //add by wuhao end
        //public static void ExportXlsx(string localFilePath, DataTable dtSource, string fileName)
        //{
        //    localFilePath = HttpContext.Current.Server.MapPath("~" + localFilePath);
        //    if (!System.IO.File.Exists(localFilePath))
        //        new AccessViolationException("模板不存在");

        //    XSSFWorkbook workbook = new XSSFWorkbook();
        //    XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet();

        //    XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
        //    XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
        //    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

        //    //取得列宽
        //    int[] arrColWidth = new int[dtSource.Columns.Count];
        //    foreach (DataColumn item in dtSource.Columns)
        //    {
        //        arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
        //    }
        //    for (int i = 0; i < dtSource.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dtSource.Columns.Count; j++)
        //        {
        //            int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
        //            if (intTemp > arrColWidth[j])
        //            {
        //                arrColWidth[j] = intTemp;
        //            }
        //        }
        //    }
        //    int rowIndex = 0;
        //    foreach (DataRow row in dtSource.Rows)
        //    {
        //        #region 新建表，填充列头，样式
        //        if (rowIndex == 65535 || rowIndex == 0)
        //        {
        //            if (rowIndex != 0)
        //            {
        //                sheet = (XSSFSheet)workbook.CreateSheet();
        //            }

        //            #region 列头及样式
        //            {
        //                XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
        //                XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
        //                headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
        //                XSSFFont font = (XSSFFont)workbook.CreateFont();
        //                font.FontHeightInPoints = 10;
        //                font.Boldweight = 700;
        //                headStyle.SetFont(font);
        //                foreach (DataColumn column in dtSource.Columns)
        //                {
        //                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        //                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
        //                    //设置列宽
        //                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
        //                }
        //            }
        //            #endregion
        //            rowIndex = 1;
        //        }
        //        #endregion

        //        #region 填充内容
        //        XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
        //        foreach (DataColumn column in dtSource.Columns)
        //        {
        //            XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);

        //            string drValue = row[column].ToString();

        //            switch (column.DataType.ToString())
        //            {
        //                case "System.String"://字符串类型
        //                    newCell.SetCellValue(drValue);
        //                    break;
        //                case "System.DateTime"://日期类型
        //                    DateTime dateV;
        //                    DateTime.TryParse(drValue, out dateV);
        //                    newCell.SetCellValue(dateV);
        //                    newCell.CellStyle = dateStyle;//格式化显示
        //                    break;
        //                case "System.Boolean"://布尔型
        //                    bool boolV = false;
        //                    bool.TryParse(drValue, out boolV);
        //                    newCell.SetCellValue(boolV);
        //                    break;
        //                case "System.Int16"://整型
        //                case "System.Int32":
        //                case "System.Int64":
        //                case "System.Byte":
        //                    int intV = 0;
        //                    int.TryParse(drValue, out intV);
        //                    newCell.SetCellValue(intV);
        //                    break;
        //                case "System.Decimal"://浮点型
        //                case "System.Double":
        //                    double doubV = 0;
        //                    double.TryParse(drValue, out doubV);
        //                    newCell.SetCellValue(doubV);
        //                    break;
        //                case "System.DBNull"://空值处理
        //                    newCell.SetCellValue("");
        //                    break;
        //                default:
        //                    newCell.SetCellValue("");
        //                    break;
        //            }

        //        }
        //        #endregion
        //        rowIndex++;
        //    }
        //    //using (FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
        //    //{
        //    //    workbook.Write(fs);
        //    //}

        //    string path = HttpContext.Current.Server.MapPath("~" + localFilePath);
        //    System.IO.File.Create(path);
        //    using (FileStream filess = System.IO.File.OpenWrite(path))
        //    {
        //        workbook.Write(filess);
        //    }
        //    ExportHSSFWorkbookByWeb(null, workbook, fileName);
        //}

        /// <summary>
        /// 年度汇总下载
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="dtSource"></param>
        /// <param name="fileName"></param>
        public static void ExportXlsx3(string localFilePath, DataTable dtSource1,DataTable dtSource2,string Title, string fileName)
        {
            XSSFWorkbook xssfworkbook;
            using (FileStream file = new FileStream(HttpContext.Current.Server.MapPath("~" + localFilePath), FileMode.Open, FileAccess.Read))
            {
                //将文件流中模板加载到工作簿对象中
                xssfworkbook = new XSSFWorkbook(file);
            }
            XSSFSheet sheet1 = (XSSFSheet)xssfworkbook.GetSheetAt(0);
            XSSFRow titleRow = (XSSFRow)sheet1.CreateRow(0);
            titleRow.CreateCell(0).SetCellValue(Title);
            if (dtSource1 != null)
            {
                int nRow = 3;
                string nextFirstTxt = string.Empty;
                for (int i = 0; i < dtSource1.Rows.Count; i++)
                {
                    XSSFRow row = (XSSFRow)sheet1.CreateRow(nRow);
                    for (int j = 0; j < dtSource1.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dtSource1.Rows[i][j].ToString());
                    }
                    nRow++;
                }
            }

            if (dtSource2 != null)
            {
                int nRow = 18;
                string nextFirstTxt = string.Empty;
                for (int i = 0; i < dtSource2.Rows.Count; i++)
                {
                    XSSFRow row = (XSSFRow)sheet1.CreateRow(nRow);
                    for (int j = 0; j < dtSource2.Columns.Count - 1; j++)
                    {
                        row.CreateCell(j).SetCellValue(dtSource2.Rows[i][j].ToString());
                    }
                    if (i==0)
                    {
                        row.CreateCell(dtSource2.Columns.Count - 1).SetCellValue(dtSource2.Rows[0][dtSource2.Columns.Count - 1].ToString());
                    }
                    nRow++;
                }
            }


            //设置响应的类型为Excel
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //设置下载的Excel文件名
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            //Clear方法删除所有缓存中的HTML输出。但此方法只删除Response显示输入信息，不删除Response头信息。以免影响导出数据的完整性。
            HttpContext.Current.Response.Clear();

            using (MemoryStream ms = new MemoryStream())
            {
                //将工作簿的内容放到内存流中
                xssfworkbook.Write(ms);
                //将内存流转换成字节数组发送到客户端
                HttpContext.Current.Response.BinaryWrite(ms.GetBuffer());
                HttpContext.Current.Response.End();
            }

        }

        #endregion

        #region NPOI-导出Doc


        /// <summary>
        /// 导出Docx
        /// </summary>
        /// <param name="localFilePath">文件保存路径</param>
        /// <param name="dtSource">数据源</param>
        public static void ExportDocx(string localFilePath, DataTable dtSource)
        {

            XWPFDocument doc = new XWPFDocument();

            XWPFTable table = doc.CreateTable(dtSource.Rows.Count + 1, dtSource.Columns.Count);

            for (int i = 0; i < dtSource.Rows.Count + 1; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    if (i == 0)
                    {
                        table.GetRow(i).GetCell(j).SetText(dtSource.Columns[j].ColumnName);
                    }
                    else
                    {
                        table.GetRow(i).GetCell(j).SetText(dtSource.Rows[i - 1][j].ToString());
                    }
                }
            }

            using (FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(fs);
            }
        }

        #endregion

        #region NPOI-下载数据
        /// <summary>
        /// 将指定的HSSFWorkbook输出到流
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="strFileName">文件名</param>
        public static void ExportHSSFWorkbookByWeb(HSSFWorkbook hssWorkbook = null, XSSFWorkbook xssWorkbook = null, string strFileName = null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (hssWorkbook == null)
                    xssWorkbook.Write(ms);
                else
                    hssWorkbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                HttpContext curContext = HttpContext.Current;

                // 设置编码和附件格式
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.Default;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + strFileName);
                curContext.Response.BinaryWrite(ms.GetBuffer());
                curContext.Response.End();
            }


        }

        #endregion


    }
}