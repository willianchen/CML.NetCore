using CML.Lib.Extensions;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ExcelUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Excel帮助类
    /// 创建标识：cq 2017/8/29 14:15:51
    /// </summary>
    public static class ExcelUtil
    {
        /// <summary>
	    /// 将DataTable转换为Excel并保存
	    /// </summary>
	    /// <param name="dt">目标数据表</param>
	    /// <param name="excelFullPath">目标excel文件路径</param>
	    /// <param name="sheetName">工作表名称</param>
	    public static void DataTableToExcel(DataTable dt, string excelFullPath, string sheetName = "Sheet1")
        {
            if (!dt.HasDataRow())
            {
                throw new BizException("目标数据不能为空");
            }

            if (excelFullPath.IsNullOrEmptyWhiteSpace())
            {
                throw new BizException("目标文件路径不能为空");
            }

            var workbook = new XSSFWorkbook();
            try
            {
                var sheet = workbook.CreateSheet(sheetName);
                var headercellStyle = workbook.CreateCellStyle();
                headercellStyle.BorderBottom = BorderStyle.Thin;
                headercellStyle.BorderLeft = BorderStyle.Thin;
                headercellStyle.BorderRight = BorderStyle.Thin;
                headercellStyle.BorderTop = BorderStyle.Thin;
                headercellStyle.Alignment = HorizontalAlignment.Center;
                //字体
                var headerfont = workbook.CreateFont();
                //字体大小
                headerfont.FontHeightInPoints = 10;
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                headercellStyle.SetFont(headerfont);

                //用column name 作为列名
                var colIndex = 0;
                var headerRow = sheet.CreateRow(0);
                foreach (DataColumn item in dt.Columns)
                {
                    ICell cell = headerRow.CreateCell(colIndex);
                    cell.SetCellValue(item.ColumnName);
                    cell.CellStyle = headercellStyle;
                    colIndex++;
                }

                var cellStyle = workbook.CreateCellStyle();
                //为避免日期格式被Excel自动替换，所以设定format为"@"表示一率当成text來看
                var fmt = workbook.CreateDataFormat();
                cellStyle.DataFormat = fmt.GetFormat("@");
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderTop = BorderStyle.Thin;

                var cellfont = workbook.CreateFont();
                //字体大小
                cellfont.FontHeightInPoints = 10;
                cellfont.Boldweight = (short)FontBoldWeight.Normal;
                cellStyle.SetFont(cellfont);

                //建立内容行
                var rowIndex = 1;
                var cellIndex = 0;
                foreach (DataRow rowitem in dt.Rows)
                {
                    var dataRow = sheet.CreateRow(rowIndex);
                    foreach (DataColumn colitem in dt.Columns)
                    {
                        var cell = dataRow.CreateCell(cellIndex);
                        cell.SetCellValue(rowitem[colitem].ToString());
                        cell.CellStyle = cellStyle;
                        cellIndex++;
                    }
                    cellIndex = 0;
                    rowIndex++;
                }

                //自适应列宽度
                for (var i = 0; i < colIndex; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                //写Excel
                var file = new FileStream(excelFullPath, FileMode.OpenOrCreate);
                workbook.Write(file);
                file.Close();
            }
            finally
            {
                workbook.Close();
            }
        }

        /// <summary>
        /// Excel文件转为DataTable对象
        /// </summary>
        /// <param name="filePath">excel文件完整路径</param>
        /// <param name="maxCell">导入的excel最大的列数</param>
        /// <param name="maxRow">导入的excel最大的行数</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string filePath, int? maxCell = null, int? maxRow = null, bool isFirstRowColumn = true)
        {
            FileStream fs = null;
            try
            {
                DataTable dataTable;
                using (fs = File.OpenRead(filePath))
                {
                    // 2007
                    IWorkbook workbook = null;
                    if (filePath.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003
                    else if (filePath.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0)
                        workbook = new HSSFWorkbook(fs);
                    else
                        throw new Exception("Excel文件后缀应为xlsx或者xls");

                    var sheet = workbook.GetSheetAt(0);
                    if (sheet == null) return null;


                    var rowCount = maxRow ?? sheet.LastRowNum;
                    if (rowCount <= 0) return null;

                    dataTable = new DataTable();

                    var firstRow = sheet.GetRow(0);
                    var cellCount = maxCell ?? firstRow.LastCellNum;

                    var startRow = 0;
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            var cell = firstRow.GetCell(i);
                            var cellValue = cell?.StringCellValue;
                            if (cellValue == null) continue;
                            var column = new DataColumn(cellValue);
                            dataTable.Columns.Add(column);
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            var column = new DataColumn($"column{i}");
                            dataTable.Columns.Add(column);
                        }
                        startRow = sheet.FirstRowNum;
                    }

                    //填充行
                    for (var i = startRow; i <= rowCount; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue;

                        var dataRow = dataTable.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            var cell = row.GetCell(j);
                            if (cell == null)
                                dataRow[j] = string.Empty;
                            else
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                        dataRow[j] = "";
                                        break;
                                    case CellType.Numeric:
                                        var format = cell.CellStyle.DataFormat;
                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                            dataRow[j] = cell.DateCellValue;
                                        else
                                            dataRow[j] = cell.NumericCellValue;
                                        break;
                                    case CellType.String:
                                        dataRow[j] = cell.StringCellValue;
                                        break;
                                    default:
                                        dataRow[j] = cell.ToString();
                                        break;
                                }
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                return dataTable;
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                fs?.Close();
            }
        }

        /// <summary>
        /// 给指定单元格标记底色及批注
        /// </summary>
        /// <param name="filePath">输入Excel文件</param>
        /// <param name="outputPath">输出Excel文件</param>
        /// <param name="cells">单元格列表有，item1: row, item2: col, item3: 批注内容</param>
        /// <param name="bgColorIndex">底色</param>
        public static void MarkExcelCells(string filePath, string outputPath, List<Tuple<int, int, string>> cells, short bgColorIndex = HSSFColor.Yellow.Index)
        {
            if (string.Compare(new FileInfo(filePath).Extension, new FileInfo(outputPath).Extension,
                    StringComparison.OrdinalIgnoreCase) != 0)
                throw new ArgumentException("输入与输出的文件格式应当相同");

            var ooxml = false;
            FileStream fs = null;
            using (fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                // 2007
                IWorkbook workbook;
                if (filePath.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    ooxml = true;
                    workbook = new XSSFWorkbook(fs);
                }
                // 2003
                else if (filePath.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    throw new ArgumentException("无法识别的格式，仅支持*.xls或者*.xlsx类型文件");
                }

                var sheet = workbook.GetSheetAt(0);
                if (sheet == null) return;

                var rowCount = sheet.LastRowNum;
                if (rowCount <= 0) return;

                var patr = sheet.CreateDrawingPatriarch();
                var creationHelper = workbook.GetCreationHelper();

                foreach (var err in cells)
                {
                    var errRows = sheet.GetRow(err.Item1);

                    var errCells = errRows?.GetCell(err.Item2);

                    if (errCells == null || errCells.CellComment != null)
                        continue;   //  如果预期单元格在输出文件中不存在，或者此单元格已经有别的错误，则不标记

                    var cell = errCells;

                    #region 底色

                    var s = workbook.CreateCellStyle();
                    s.FillPattern = FillPattern.SolidForeground;
                    s.FillForegroundColor = bgColorIndex;

                    cell.CellStyle = s;

                    #endregion

                    #region 批注

                    var anchor = creationHelper.CreateClientAnchor();
                    anchor.Dx1 = err.Item2;
                    anchor.Dy1 = err.Item1;
                    anchor.Dx2 = err.Item2 + 2;
                    anchor.Dy2 = err.Item1 + 3;
                    anchor.Col1 = err.Item2;
                    anchor.Row1 = err.Item1;
                    anchor.Col2 = err.Item2 + 2;
                    anchor.Row2 = err.Item1 + 3;
                    var comment = patr.CreateCellComment(anchor);
                    if (ooxml)
                        comment.String = new XSSFRichTextString(err.Item3);
                    else
                        comment.String = new HSSFRichTextString(err.Item3);

                    //	超过一个以上错误的单元格，只保留第一个
                    cell.CellComment = comment;

                    #endregion
                }

                using (fs = new FileStream(outputPath, FileMode.Create))
                {
                    workbook.Write(fs);
                }
            }
        }
    }
}
