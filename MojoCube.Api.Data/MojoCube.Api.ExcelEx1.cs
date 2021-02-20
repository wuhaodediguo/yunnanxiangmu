using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace MojoCube.Api.ExcelEx1
{
	public static class ExcelHelperEx1
	{
        public static DataSet GetDataTableFromExcel(Stream fs, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            IWorkbook workbook = null;
            DataSet ds = new DataSet();
            DataTable data = null;
            int startRow = 0;
            try
            {
                //fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook(fs);
                //else if (fileName.IndexOf(".xls") > 0) // 2003版本
                //workbook = new HSSFWorkbook(fs);

                foreach (var item in sheetName.Split(','))
                {
                    startRow = 0;
                    data = new DataTable(item);
                    sheet = workbook.GetSheet(item);
                    if (sheet != null)
                    {
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                        if (isFirstRowColumn)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                ICell cell = firstRow.GetCell(i);
                                if (cell != null)
                                {
                                    string cellValue = cell.StringCellValue;
                                    if (cellValue != null)
                                    {
                                        if (cellValue == "手机") cellValue = "手机" + i.ToString();
                                        DataColumn column = new DataColumn(cellValue);
                                        data.Columns.Add(column);
                                    }
                                }
                            }
                            startRow = sheet.FirstRowNum + 1;
                        }
                        else
                        {
                            startRow = sheet.FirstRowNum;
                        }

                        //最后一列的标号
                        int rowCount = sheet.LastRowNum;
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue; //没有数据的行默认是null　　　　　　　

                            DataRow dataRow = data.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {

                                if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                    if (j == 0)
                                    {
                                        dataRow[j] = row.GetCell(j).DateCellValue.ToString();
                                    }
                                    else
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                            }
                            data.Rows.Add(dataRow);
                        }
                    }
                    if (data != null && data.Rows.Count > 0)
                        ds.Tables.Add(data);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
	}
}
