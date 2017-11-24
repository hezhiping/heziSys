using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HZ.Web
{
    public class ExcelHelper
    {
        /// <summary>
        /// 构建ExcelClass类
        /// </summary>
        public ExcelHelper()
        {
            this.m_objExcel = new Excel.Application();
        }
        /// <summary>
        /// 构建ExcelClass类
        /// </summary>
        /// <param name="objExcel">Excel.Application</param>
        public ExcelHelper(Excel.Application objExcel)
        {
            this.m_objExcel = objExcel;
        }

        /// <summary>
        /// 列标号
        /// </summary>
        private string AList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 获取描述区域的字符
        /// </summary>
        /// <param name="col">列号</param>
        /// <param name="row">行号</param>
        /// <returns></returns>
        private string GetAix(int col, int row)
        {
            char[] AChars = AList.ToCharArray();
            if (col > 256) { return ""; }
            else
            {
                string s = "";
                if (col <= 26)
                {
                    s += AChars[col - 1].ToString();
                }
                else
                {
                    int i = col / 26;
                    int j = col - i * 26;
                    s += AChars[i - 1].ToString() + AChars[j - 1].ToString();
                }
                s += row.ToString();
                return s;
            }
        }

        /// <summary>
        /// 给单元格赋值
        /// </summary>
        /// <param name="col">列号</param>
        /// <param name="row">行号</param>
        /// <param name="text">值</param>
        public void setValue(int col, int row, string text)
        {
            Excel.Range range = m_objSheet.get_Range(this.GetAix(col, row), miss);
            range.set_Value(miss, text);
        }
        public void setValue(string colName, int row, string text)
        {
            Excel.Range range = m_objSheet.get_Range(colName + row.ToString(), miss);
            range.set_Value(miss, text);
        }

        ///// <summary>
        ///// 给单元格赋值
        ///// </summary>
        ///// <param name="x">列号</param>
        ///// <param name="y">行号</param>
        ///// <param name="text">值</param>
        ///// <param name="color">颜色</param>
        //public void setValue(int col, int row, string text, System.Drawing.Color color)
        //{
        //    Excel.Range range = m_objSheet.get_Range(this.GetAix(col, row), miss);
        //    range.set_Value(miss, text);
        //    range.Font.Color = color;
        //}
        public void setFormat(string colname1, int row1, string colname2, int row2, int colorIndex, string align)
        {
            Excel.Range range = getRange(colname1, row1, colname2, row2);
            range.Font.ColorIndex = colorIndex;
            switch (align.ToUpper())
            {
                case "LEFT":
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    break;
                case "CENTER":
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    break;
                case "RIGHT":
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 给单元格赋值
        /// </summary>
        /// <param name="x">列号</param>
        /// <param name="y">行号</param>
        /// <param name="color">颜色</param>
        public void setColorRed(int col, int row)
        {
            Excel.Range range = m_objSheet.get_Range(this.GetAix(col, row), miss);
            range.Font.Color = 3;
        }
        public void setColorRed(string colName, int row)
        {
            Excel.Range range = m_objSheet.get_Range(colName + row.ToString(), miss);
            range.Font.ColorIndex = 3;
        }

        /// <summary>
        /// 插入新行
        /// </summary>
        /// <param name="y">模板行号</param>
        public void insertRow(int row)
        {
            Excel.Range range = m_objSheet.get_Range("A" + row.ToString(), "IV" + row.ToString());
            range.Copy(miss);
            range.Insert(Excel.XlDirection.xlDown, miss);
            //range.get_Range(GetAix(1, row), GetAix(256, row));
            //range.Select();
            //m_objSheet.Paste(miss, miss);
        }

        ///// <summary>
        ///// 设置边框
        ///// </summary>
        ///// <param name="col1"></param>
        ///// <param name="row1"></param>
        ///// <param name="col2"></param>
        ///// <param name="row2"></param>
        ///// <param name="Width"></param>
        //public void setBorder(int col1, int row1, int col2, int row2, int Width)
        //{
        //    Excel.Range range = m_objSheet.get_Range(this.GetAix(col1, row1), this.GetAix(col2, row2));
        //    range.Borders.Weight = Width;
        //}
        //public void mergeCell(int col1, int row1, int col2, int row2)
        //{
        //    Excel.Range range = m_objSheet.get_Range(this.GetAix(col1, row1), this.GetAix(col2, row2));
        //    range.Merge(true);
        //}

        public Excel.Range getRange(int col1, int row1, int col2, int row2)
        {
            Excel.Range range = m_objSheet.get_Range(this.GetAix(col1, row1), this.GetAix(col2, row2));
            return range;
        }
        public Excel.Range getRange(string colname1, int row1, string colname2, int row2)
        {
            Excel.Range range = m_objSheet.get_Range(colname1 + row1.ToString(), colname2 + row2.ToString());
            return range;
        }


        private object miss = Missing.Value; //忽略的参数OLENULL 
        private Excel.Application m_objExcel;//Excel应用程序实例 
        private Excel.Workbooks m_objBooks;//工作簿集合 
        private Excel.Workbook m_objBook;//当前操作的工作簿
        //private Excel.Worksheets m_objSheets;//工作表集合
        private Excel.Worksheet m_objSheet;//当前操作的工作表
        public Excel.Worksheet CurrentSheet
        {
            get
            {
                return m_objSheet;
            }
            set
            {
                this.m_objSheet = value;
            }
        }
        public Excel.Workbook CurrentWorkBook
        {
            get
            {
                return this.m_objBook;
            }
            set
            {
                this.m_objBook = value;
            }
        }

        /// <summary>
        /// 打开Excel文件
        /// </summary>
        /// <param name="filename">路径</param>
        public void OpenExcelFile(string filename)
        {
            UserControl(false);

            m_objExcel.Workbooks.Open(filename, miss, miss, miss, miss, miss, miss, miss,
                                    miss, miss, miss, miss, miss, miss, miss);
            m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
            m_objBook = (Excel.Workbook)m_objExcel.ActiveWorkbook;
            //m_objSheets = (Excel.Worksheets)m_objBook.Sheets;
            m_objSheet = (Excel.Worksheet)m_objBook.ActiveSheet;
        }
        public void CreateExcelFile()
        {
            UserControl(false);
            m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
            m_objBook = (Excel.Workbook)(m_objBooks.Add(miss));
            //m_objSheets = (Excel.Worksheets)m_objBook.Sheets;
            m_objSheet = (Excel.Worksheet)m_objBook.ActiveSheet;
        }
        public void SelectSheet(object sheetname)
        {
            m_objSheet = (Excel.Worksheet)m_objBook.Worksheets[sheetname];
        }
        public void DeleteSheet(object sheetname)
        {
            ((Excel.Worksheet)m_objBook.Worksheets[sheetname]).Delete();
        }
        public void SaveAs(string FileName)
        {

            m_objBook.SaveAs(FileName, miss, miss, miss, miss,
            miss, Excel.XlSaveAsAccessMode.xlNoChange,
            Excel.XlSaveConflictResolution.xlLocalSessionChanges,
            miss, miss, miss, miss);
            //m_objBook.Close(false, miss, miss); 
        }
        public void ReleaseExcel()
        {
            m_objExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_objExcel);
            System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_objBooks);
            System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_objBook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_objSheets);
            System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_objSheet);
            m_objExcel = null;
            m_objBooks = null;
            m_objBook = null;
            m_objSheet = null;
            GC.Collect();
        }
        public void UserControl(bool usercontrol)
        {
            if (m_objExcel == null) { return; }
            m_objExcel.UserControl = usercontrol;
            m_objExcel.DisplayAlerts = usercontrol;  //是否弹出警告信息对话框
            m_objExcel.Visible = usercontrol;
        }

        public void GetsheetName(string sheetName)
        {
            m_objSheet.Name = sheetName;
        }
        //LP 2014 07 18
        /// <summary>
        /// 创建一个新工作表
        /// </summary>
        /// <param name="after_sheetname">目标工作</param>
        /// <param name="new_sheetname">新工作表名称</param>
        public void CreateSheet(object after_sheetname, object new_sheetname)
        {
            Excel.Worksheet after_sheet = (Excel.Worksheet)m_objBook.Worksheets[after_sheetname];//选定工作表,将在其后面插入新工作表
            m_objExcel.Worksheets.Add(miss, after_sheet, miss, miss);//插入一个新的工作表
            int new_index = after_sheet.Index + 1;//新工作表的索引
            ((Excel.Worksheet)m_objBook.Worksheets[new_index]).Name = new_sheetname.ToString();//命名新工作表
        }
        /// <summary>
        /// 保护工作表
        /// </summary>
        /// <param name="passwork"></param>
        public void Protect(string passwork)
        {
            m_objSheet.Protect(passwork, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss, true, miss, miss);
        }

        ///// <summary>
        ///// 允许供应商编辑内容对策 2014-9-14 by hyf 
        ///// </summary>
        //public void allowedit()
        //{
        //    Excel.AllowEditRanges ranges = m_objSheet.Protection.AllowEditRanges;
        //    ranges.Add("供应商可编辑对策区", m_objExcel.Application.get_Range("B29", "R46"), Type.Missing);
        //}

        /////////////////////////////////
        public bool KillAllExcelApp()
        {
            try
            {
                if (m_objExcel != null) // isRunning是判断xlApp是怎么启动的flag.
                {
                    m_objExcel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                    //释放COM组件，其实就是将其引用计数减1
                    //System.Diagnostics.Process theProc;
                    foreach (System.Diagnostics.Process theProc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                    {
                        //先关闭图形窗口。如果关闭失败...有的时候在状态里看不到图形窗口的excel了，
                        //但是在进程里仍然有EXCEL.EXE的进程存在，那么就需要杀掉它:p
                        if (theProc.CloseMainWindow() == false)
                        {
                            theProc.Kill();
                        }
                    }
                    m_objExcel = null;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /////////////////////////////////
    }
}
