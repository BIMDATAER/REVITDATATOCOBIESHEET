using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Windows.Forms;

namespace BIMDelivery.Common
{
    public class NPOIMemoryStream : MemoryStream
    {
        /// <summary>
        /// 获取流是否关闭
        /// </summary>
        public bool IsColse
        {
            get;
            private set;
        }
        public NPOIMemoryStream(bool colse = false)
        {
            IsColse = colse;
        }
        public override void Close()
        {
            if (IsColse)
            {
                base.Close();
            }
        }
    }
    class ExcelOperation
    {
        /// <summary>
        /// 创建工作簿，并添加工作表
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="sheetsname"></param>
        public void CreatSheets(string filepath,string[] sheetsname) 
        {
            XSSFWorkbook wookbook = new XSSFWorkbook();
            for (int i = 0; i < sheetsname.Length; i++)
            {
                string sheetname = sheetsname[i];
                wookbook.CreateSheet(sheetname);
            }

            FileStream file = new FileStream(filepath,FileMode.Create);
            wookbook.Write(file);
            file.Close();
            wookbook.Close();
        }


        /// <summary>
        /// 工作簿内工作表内容数据读取
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="i"></param>
        public Dictionary<string,string> ReadBook(string filepath,int i,KeyValuePair<string,string> keyValuePair) 
        {
            Dictionary<string, string> keyValuePairs =new Dictionary<string, string>();
            FileStream fileStream = new FileStream(filepath,FileMode.Open,FileAccess.Read);
            IWorkbook workbook = new XSSFWorkbook(fileStream);
            string cellvalue = string.Empty;
            ISheet sheet = workbook.GetSheetAt(i);
            int fieldindex=0;
            //获取字段在表中索引
            IRow row1 = sheet.GetRow(0);
            for (int j = 0; j < row1.LastCellNum; j++)
            {
                //根据 value字段获取位置值
                if (row1.Cells[j].StringCellValue == keyValuePair.Value)
                {
                    fieldindex = j;
                    break;
                }
                else
                {
                    
                }              
            }


            //首行不需要遍历，从2开始
            for (int t = 2; t < sheet.LastRowNum; t++)
            {
                IRow row = sheet.GetRow(t);


                if (row != null)
                {

                    string name = row.GetCell(0).ToString();
                    string[] namesplit = name.Split(new char[] {'-' });
                    if (sheet.SheetName == "类型")
                    {
                        string keyname = namesplit[2];
                        string paramvalue = string.Empty;

                        //解决单元格未激活，位置错乱问题
                        for (int j = 0; j < row.Cells.Count(); j++)
                        {

                            int columnindex = row.Cells[j].ColumnIndex;
                            if (columnindex == fieldindex)
                            {
                                paramvalue = row.Cells[j].ToString();
                            }

                        }

                        keyValuePairs.Add(keyname, paramvalue);

                    }
                    else if (sheet.SheetName=="组件") 
                    {
                        string keyname = namesplit[1];

                        string paramvalue = string.Empty;

                        //解决单元格未激活，位置错乱问题
                        for (int j = 0; j < row.Cells.Count(); j++)
                        {

                            int columnindex = row.Cells[j].ColumnIndex;
                            if (columnindex == fieldindex)
                            {
                                paramvalue = row.Cells[j].ToString();
                            }

                        }

                        keyValuePairs.Add(keyname, paramvalue);
                    }



                }
            }

            return keyValuePairs;
            fileStream.Close();
            workbook.Close();
        }

        /// <summary>
        /// 工作表单元格写入值
        /// </summary>
        /// <param name="path"></param>
        /// <param name="i"></param>
        /// <param name="filedname"></param>
        /// <param name="value"></param>
        public void WriteBook(string path,int i, List<Dictionary<string,string>> keyValuePairs) 
        {

            string filedname=null;
            object value = null;
            IWorkbook workbook = null;
            //异常提示：ICSharpCode.SharpZipLib.Zip.ZipException: EOF in header 

            using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fileStream.Position = 0; //这一句不加就会上面的异常错误

                workbook = new XSSFWorkbook(fileStream);
                //workbook.Write(fileStream);
                
                fileStream.Close();
            }


            ISheet sheet = workbook.GetSheetAt(i);
            IRow row1 = sheet.GetRow(0);
            //FileStream fout = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);

            //获取单元格填充颜色
            IRow rowcolour = sheet.GetRow(1);
            ICellStyle cellStyle1=rowcolour.RowStyle;


            //IRow row = sheet.CreateRow(sheet.LastRowNum + 1);
            //row.RowStyle = cellStyle1;


            foreach (Dictionary<string, string> items in keyValuePairs)
            {
                IRow row = sheet.CreateRow(sheet.LastRowNum + 1);
                row.RowStyle = cellStyle1;
                foreach (var namevalue in items)
                {
                    filedname = namevalue.Key;
                    value = namevalue.Value;
                    for (int t = 0; t < row1.LastCellNum; t++)
                    {
                        if (row1.GetCell(t).StringCellValue == filedname)
                        {
                            //获取首行对应单元格颜色
                            ICellStyle cellStyle2 = rowcolour.GetCell(t).CellStyle;

                            ICell cellwrite = row.CreateCell(t);

                            //后期增加单元格颜色设置
                            cellwrite.CellStyle = cellStyle2;

                            if (value != null)
                            {
                                SetCeilValue(cellwrite, value);
                                //continue;
                            }
                            break;
                        }

                    }
                }

            }


            using (FileStream fout = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                workbook.Write(fout);
                fout.Close();
            }

            //workbook.Close();

        }


        /// <summary>
        /// 获取cell数据，设置为对应数据类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public object GetCellValue(ICell cell)
        {
            object value = null;

            if (cell.CellType !=CellType.Blank)
            {
                switch (cell.CellType)
                {
                    case CellType.Numeric:
                        if (DateUtil.IsCellDateFormatted(cell))
                        {
                            value = cell.DateCellValue;
                        }
                        else
                        {
                            value = cell.NumericCellValue;
                        }
                        break;
                    case CellType.Formula:
                        value = cell.CellFormula;
                        break;
                    case CellType.Blank:
                        break;
                    case CellType.Boolean:
                        value = cell.BooleanCellValue;
                        break;
                    default:
                        value = cell.StringCellValue;
                        break;
                }
            }

            return value;
        }



        /// <summary>
        /// 根据数据类型设置不同类型cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="obj"></param>
        public void SetCeilValue(ICell cell,object obj) 
        {
            if (obj.GetType() == typeof(int))
            {
                cell.SetCellValue((int)obj);               
            }
            else if (obj.GetType() == typeof(double))
            {
                cell.SetCellValue((double)obj);
            }
            else if (obj.GetType() == typeof(string))
            {
                cell.SetCellValue(obj.ToString());
            }
            else if (obj.GetType() == typeof(DateTime))
            {
                cell.SetCellValue((DateTime)obj);
            }
            else if (obj.GetType() == typeof(bool))
            {
                cell.SetCellValue((bool)obj);
            }
            else 
            {
                cell.SetCellValue(obj.ToString());
            }

        }



    }
}
