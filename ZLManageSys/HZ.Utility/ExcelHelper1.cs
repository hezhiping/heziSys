using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NPOI;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.Collections;

namespace HZ.Utility
{
   public  class ExcelHelper1
   {
       /// <summary>
       ///传入ds直接生成excel在服务器目录上
       /// </summary>
       /// <param name="ds"></param>
       /// <param name="strPath"></param>
       /// <param name="strFileName"></param>
       /// <returns></returns>
       public static HSSFWorkbook ExportXlsByDataSet(DataSet ds, string ReportHeader = "")
       {
           //NPOI 
           HSSFWorkbook hssfworkbook2 = new HSSFWorkbook();
           HSSFSheet sheet = (HSSFSheet)hssfworkbook2.CreateSheet("sheet1");
           //定义字体 font   设置字体类型和大小
           HSSFFont font = (HSSFFont)hssfworkbook2.CreateFont();
           font.FontName = "宋体";
           font.FontHeightInPoints = 11;

           //定义单元格格式；单元格格式style1 为font的格式
           HSSFCellStyle style1 = (HSSFCellStyle)hssfworkbook2.CreateCellStyle();
           style1.SetFont(font);
           style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

           HSSFCellStyle style2 = (HSSFCellStyle)hssfworkbook2.CreateCellStyle();
           style2.SetFont(font);
           style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
           style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
           //style2.WrapText = true;

           //设置大标题行
           int RowCount = 0;
           int arrFlag = 0;
           string TileName1 = "";
           string TileName2 = "";

           string s = ReportHeader;
           string[] sArray = s.Split('|');
           if (ReportHeader != "")
           {
               foreach (string i in sArray)
               {
                   string str1 = i.ToString();
                   string[] subArray = str1.Split('@');
                   foreach (string k in subArray)
                   {
                       Console.WriteLine(k.ToString());
                       if (arrFlag == 0)
                       {
                           TileName1 = k.ToString();
                       }
                       else
                       {
                           TileName2 = k.ToString();
                       }
                       arrFlag = arrFlag + 1;
                   }
                   HSSFRow row0 = (HSSFRow)sheet.CreateRow(RowCount); //创建报表表头标题  8列
                   row0.CreateCell(0).SetCellValue(TileName1);
                   row0.CreateCell(1).SetCellValue(TileName2);
                   RowCount = RowCount + 1;
                   arrFlag = 0;
               }
           }

           //设置全局列宽和行高
           sheet.DefaultColumnWidth = 14;//全局列宽
           sheet.DefaultRowHeightInPoints = 15;//全局行高
           //设置标题行数据
           int a = 0;
           string mColumnName = "";

           HSSFRow row1 = (HSSFRow)sheet.CreateRow(RowCount); //创建报表表头标题  8列
           for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
           {

               mColumnName = ds.Tables[0].Columns[k].ColumnName.ToString();
               row1.CreateCell(a).SetCellValue(mColumnName);
               row1.Cells[a].CellStyle = style2;
               a++;

           }
           //填写ds数据进excel
           //数据

           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//写6行数据
           {
               HSSFRow row2 = (HSSFRow)sheet.CreateRow(i + RowCount + 1);
               int b = 0;
               for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
               {
                   string DgvValue = "";
                   DgvValue = ds.Tables[0].Rows[i][j].ToString(); ;
                   row2.CreateCell(b).SetCellValue(DgvValue);
                   b++;
               }
           }
           return hssfworkbook2;
       }

       /// <summary>
       ///传入ds直接生成excel在服务器目录上
       /// </summary>
       /// <param name="ds"></param>
       /// <param name="strPath"></param>
       /// <param name="strFileName"></param>
       /// <returns></returns>
       public static XSSFWorkbook ExportXlsxByDataSet(DataSet ds, string ReportHeader = "")
       {
           //NPOI 
           XSSFWorkbook hssfworkbook2 = new XSSFWorkbook();
           XSSFSheet sheet = (XSSFSheet)hssfworkbook2.CreateSheet("sheet1");
           //定义字体 font   设置字体类型和大小
           XSSFFont font = (XSSFFont)hssfworkbook2.CreateFont();
           font.FontName = "宋体";
           font.FontHeightInPoints = 11;

           //定义单元格格式；单元格格式style1 为font的格式
           XSSFCellStyle style1 = (XSSFCellStyle)hssfworkbook2.CreateCellStyle();
           style1.SetFont(font);
           style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

           XSSFCellStyle style2 = (XSSFCellStyle)hssfworkbook2.CreateCellStyle();
           style2.SetFont(font);
           style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
           style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
           style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
           //style2.WrapText = true;

           //设置大标题行
           int RowCount = 0;
           int arrFlag = 0;
           string TileName1 = "";
           string TileName2 = "";

           string s = ReportHeader;
           string[] sArray = s.Split('|');
           if (ReportHeader != "")
           {
               foreach (string i in sArray)
               {
                   string str1 = i.ToString();
                   string[] subArray = str1.Split('@');
                   foreach (string k in subArray)
                   {
                       Console.WriteLine(k.ToString());
                       if (arrFlag == 0)
                       {
                           TileName1 = k.ToString();
                       }
                       else
                       {
                           TileName2 = k.ToString();
                       }
                       arrFlag = arrFlag + 1;
                   }
                   XSSFRow row0 = (XSSFRow)sheet.CreateRow(RowCount); //创建报表表头标题  8列
                   row0.CreateCell(0).SetCellValue(TileName1);
                   row0.CreateCell(1).SetCellValue(TileName2);
                   RowCount = RowCount + 1;
                   arrFlag = 0;
               }
           }

           //设置全局列宽和行高
           sheet.DefaultColumnWidth = 14;//全局列宽
           sheet.DefaultRowHeightInPoints = 15;//全局行高
           //设置标题行数据
           int a = 0;
           string mColumnName = "";

           XSSFRow row1 = (XSSFRow)sheet.CreateRow(RowCount); //创建报表表头标题  8列
           for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
           {

               mColumnName = ds.Tables[0].Columns[k].ColumnName.ToString();
               row1.CreateCell(a).SetCellValue(mColumnName);
               row1.Cells[a].CellStyle = style2;
               a++;

           }
           //填写ds数据进excel
           //数据

           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//写6行数据
           {
               XSSFRow row2 = (XSSFRow)sheet.CreateRow(i + RowCount + 1);
               int b = 0;
               for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
               {
                   string DgvValue = "";
                   DgvValue = ds.Tables[0].Rows[i][j].ToString(); ;
                   row2.CreateCell(b).SetCellValue(DgvValue);
                   b++;
               }
           }
           return hssfworkbook2;
       }


       /// <summary>
       /// 外观检查日报Excel
       /// </summary>
       /// <param name="ds"></param>
       /// <param name="ReportHeader"></param>
       /// <returns></returns>
       public static MemoryStream ExportXlsByList(DataSet ds, string ReportHeader = "",string userName="")
       {
           //创建Excel文件的对象
           HSSFWorkbook book = new HSSFWorkbook();
           //添加一个sheet 
           HSSFSheet sheet1 = (HSSFSheet)book.CreateSheet(ReportHeader);
           sheet1.DefaultRowHeight = 150 * 4;//设置全局行高
           //设置列宽度
           for (int i = 0; i < ds.Tables[0].Columns.Count+19; i++)
           {
               if (i == 1 ||i==0||i==28)//第一、二列
               {
                   sheet1.SetColumnWidth(i, 19 * 250);
               }
               else if (i > 1 && i < 7)
               {
                   sheet1.SetColumnWidth(i, 10 * 256);
               }
               else
               {
                   sheet1.SetColumnWidth(i, 6 * 256);
               }
           }

            //字体
           IFont fontkh = book.CreateFont();//创建一个字体样式
           fontkh.FontHeightInPoints = 12;//字体大小
           fontkh.FontName = "宋体";//字体名

           //显示数据字体
           IFont fontdata = book.CreateFont();//创建一个字体样式
           fontdata.FontHeightInPoints = 11;//字体大小
           fontdata.FontName = "宋体";//字体名

           //显示数据字体
           IFont fontdata1 = book.CreateFont();//创建一个字体样式
           fontdata1.FontHeightInPoints = 11;//字体大小
           fontdata1.Color = (short)ConsoleColor.Green;
           fontdata1.FontName = "宋体";//字体名


           //字符样式
           HSSFFont row2stylefont = (HSSFFont)book.CreateFont();
           row2stylefont.FontName = "宋体";
           row2stylefont.FontHeightInPoints = 25;
           row2stylefont.IsBold = true;

            //显示数据格式
           ICellStyle styledata=book.CreateCellStyle();//创建显示数据格式
           styledata.WrapText=true;
           styledata.VerticalAlignment=VerticalAlignment.Center;//上下居中
           styledata.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.SetFont(fontdata);


           ICellStyle styledata1 = book.CreateCellStyle();//创建显示数据格式
           styledata1.Alignment = HorizontalAlignment.Center;//左对齐
           styledata1.WrapText = true;
           styledata1.VerticalAlignment = VerticalAlignment.Center;//上下居中
           styledata1.SetFont(fontdata1);
      

           //添加考核标题样式
           //单元格样式
           ICellStyle stylekh = book.CreateCellStyle();
           stylekh.Alignment = HorizontalAlignment.Left;//左对齐
           stylekh.WrapText = true;//自动换行
           stylekh.FillForegroundColor = HSSFColor.PaleBlue.Index;//前景色
           stylekh.FillPattern = FillPattern.SolidForeground;//填充样式
           stylekh.VerticalAlignment = VerticalAlignment.Center;//上下居中
           stylekh.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.SetFont(fontkh);


           ICellStyle stylekh1 = book.CreateCellStyle();
           stylekh1.Alignment = HorizontalAlignment.Left;//左对齐
           stylekh1.WrapText = true;//自动换行
           stylekh1.FillForegroundColor = HSSFColor.LightCornflowerBlue.Index;//前景色
           stylekh1.FillPattern = FillPattern.SolidForeground;//填充样式
           stylekh1.VerticalAlignment = VerticalAlignment.Center;//上下居中
           stylekh1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.SetFont(fontkh);

           //第一行单元格样式 外观检测日报
           ICellStyle style = book.CreateCellStyle();
           style.Alignment = HorizontalAlignment.Center;
           style.WrapText = true;
           IFont font = book.CreateFont();
           font.FontHeightInPoints = 20;//字体大小
           font.Boldweight = (short)FontBoldWeight.Bold;
           font.FontName = "宋体";
           style.SetFont(font);

           //给第一行填数据
           HSSFRow row2 = (HSSFRow)sheet1.CreateRow(0);
           row2.CreateCell(0).SetCellValue("外观检查日报");
           row2.GetCell(0).CellStyle = style;

           //显示考核信息
           HSSFRow row3 = (HSSFRow)sheet1.CreateRow(2);
           row3.CreateCell(0).SetCellValue("考核信息");
           row3.GetCell(0).CellStyle = stylekh;

           //第一行设置合并单元格
           //参数分别为 自左到右 开始行索引,结束行索引,开始列索引,结束列索引
           CellRangeAddress firstcellRange = new CellRangeAddress(0, 1, 0, ds.Tables[0].Columns.Count / 3);
           CellRangeAddress nextcellRange = new CellRangeAddress(0, 1, ds.Tables[0].Columns.Count/ 3, ds.Tables[0].Columns.Count+10);
           sheet1.AddMergedRegion(firstcellRange);
           sheet1.AddMergedRegion(nextcellRange);


           //空出一行
           CellRangeAddress khInfo1 = new CellRangeAddress(2, 2, 1, ds.Tables[0].Columns.Count+10);//显示"考核信息"
           sheet1.AddMergedRegion(khInfo1);
           CellRangeAddress kb = new CellRangeAddress(5, 5, 0, ds.Tables[0].Columns.Count+10);//第5行空白
           sheet1.AddMergedRegion(kb);

           //备注合并单元格
           CellRangeAddress Remark = new CellRangeAddress(3, 3, 7, 13);//合并第三行第8列到第9列
           CellRangeAddress Remark1 = new CellRangeAddress(4, 4, 7, 13);//合并第四行第8列到第9列
           sheet1.AddMergedRegion(Remark);
           sheet1.AddMergedRegion(Remark1);

           //给sheet1添加第一行的头部标题
           HSSFRow row1 = (HSSFRow)sheet1.CreateRow(3);
           HSSFRow tworow = (HSSFRow)sheet1.CreateRow(6);//第7行
           int twonum = 0;//列标题的索引号
           string mColumnName = "";//列标题的名称
           string[] strs = new string[]
            {"料伤","夹伤","划伤","打伤","磨伤","轴承不过","倒角不良",
             "抛光变形","扁错位","刀痕","孔径不良","尾刺","粗糙度",
             "电镀不良","生锈","漏工程","料头","跳动不良","长度不良","加工错误","其他"};//数组存储不良类型，用来构造列头

         
           //列标题
           for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
           {
               //考核信息标题
               mColumnName = ds.Tables[0].Columns[k].ColumnName.ToString();
               if (k < 8)
               {
                   row1.CreateCell(k).SetCellValue(mColumnName);
                   row1.GetCell(k).CellStyle = stylekh;

               }
               else
               {
                   if (k > ds.Tables[0].Columns.Count - 4 )
                   {
                       if (k == 15)
                       {
                           tworow.CreateCell(strs.Length + 7).SetCellValue(mColumnName);
                           tworow.GetCell(strs.Length + 7).CellStyle = stylekh1;
                       }
                       //此处是不良类型的标题，隐去了不良类型与不良数,利用生产的数组代替
                       if (k == (ds.Tables[0].Columns.Count - 1))
                       {
                           for (int i = 0; i < strs.Length; i++)
                           {
                               tworow.CreateCell(twonum).SetCellValue(strs[i]);
                               tworow.GetCell(twonum).CellStyle = stylekh1;
                               twonum++;
                           }
                       }
                   }
                   else
                   {

                       
                           tworow.CreateCell(twonum).SetCellValue(k == 11 ? mColumnName + "/H" : mColumnName);   //因为数据库里部能包好标准时/H  在此重构一下
                           tworow.GetCell(twonum).CellStyle = k == 15 ? stylekh1 : stylekh;
                           twonum++;
                   }

               }
           }


           ////显示数据 按行填充 行数从0开始
           NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(4);//第5行

           ICellStyle makeStyle = book.CreateCellStyle();
           makeStyle.Alignment = HorizontalAlignment.Left;
           makeStyle.VerticalAlignment = VerticalAlignment.Center;
           IFont makeFont = book.CreateFont();
           makeFont.FontName = "宋体";
           makeFont.FontHeightInPoints = 16;
           makeStyle.SetFont(makeFont);

        
                   row1.CreateCell(15).SetCellValue("作成: " + userName + "        时间：" + DateTime.Now.ToString());
                   row1.GetCell(15).CellStyle = makeStyle;
                   rowtemp.CreateCell(15).SetCellValue("说明:达成率=(标准工时+其他工时)/出勤工时*100%    标准时间=∑(检查数量/标准时间)");

                   //考核信息部分 j为行索引  这里只遍历前八个
                   for (int j = 0; j < 8; j++)
                   {
                       if (j == 0)
                       {     //第一个日期转化格式
                           rowtemp.CreateCell(j).SetCellValue(DateTime.Parse(ds.Tables[0].Rows[0][j].ToString()).ToString("yyyy年MM月dd日"));
                       }
                       else if (j > 1 && j < 7)
                       {
                           if (j == 6)
                           {
                               //达成率加百分比
                               rowtemp.CreateCell(j).SetCellValue(ds.Tables[0].Rows[0][j].ToString() + "%");
                           }
                           else
                           {
                               //工号、出勤时间等已双精度输出
                               rowtemp.CreateCell(j).SetCellValue(double.Parse(ds.Tables[0].Rows[0][j].ToString()));
                           }
                       }
                       else
                       {
                           //备注姓名等
                           rowtemp.CreateCell(j).SetCellValue(ds.Tables[0].Rows[0][j].ToString());
                       }
                       //样式填充
                       if (j != 7)
                       {
                           rowtemp.GetCell(j).CellStyle = styledata;
                       }

                   }

                   int SumCheck = 0;
                   int okCheck = 0;
                   int NgCheck = 0;
                   int asd;
                   //第7行开始遍历导出数据
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       HSSFRow rowtemp1 = (HSSFRow)sheet1.CreateRow(i +7);
                       for (int j = 7; j <ds.Tables[0].Columns.Count-1; j++)
                       {
                           if (j > ds.Tables[0].Columns.Count - 4 && ((ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1]) == null ? false : true))
                           {
                               string[] types = ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 2].ToString().Split(',');
                               string[] cts = ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1].ToString().Split(',');
                               if (types.Length > 1 && cts.Length > 1)
                               {
                                   for (int cs = 0; cs < cts.Length; cs++)
                                   {
                                       rowtemp1.CreateCell(j - 8 + int.Parse(types[cs])).SetCellValue(int.Parse(cts[cs]));
                                       rowtemp1.GetCell(j - 8 + int.Parse(types[cs])).CellStyle = styledata1;
                                   }
                               }

                           }
                           else
                           {
                              
                               int.TryParse(ds.Tables[0].Rows[i][j].ToString(), out asd);
                                 if (asd >0 || j==14)
                                   {
                                       if (j == 12)
                                       {
                                           SumCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                                       }
                                       if (j == 13)
                                       {
                                           okCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                                       }
                                       if (j == 14)
                                       {
                                           NgCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                                       }
                                       rowtemp1.CreateCell(j - 8).SetCellValue(int.Parse(ds.Tables[0].Rows[i][j].ToString()));
                                       rowtemp1.GetCell(j - 8).CellStyle = styledata;
                                   }
                                 else if (j == 7)
                                 {
                                     rowtemp1.CreateCell(strs.Length+j).SetCellValue(ds.Tables[0].Rows[i][j].ToString());
                  
                                 }
                                 else
                                 {
                                     rowtemp1.CreateCell(j - 8).SetCellValue(ds.Tables[0].Rows[i][j].ToString());
                                     rowtemp1.GetCell(j - 8).CellStyle = styledata;
                                 }
                           }
                       }
                       
                   }
                   HSSFRow rowtemp2 = (HSSFRow)sheet1.CreateRow(ds.Tables[0].Rows.Count + 7);
                   rowtemp2.CreateCell(3).SetCellValue("total:");
                   rowtemp2.GetCell(3).CellStyle = styledata;
                   rowtemp2.CreateCell(4).SetCellValue(SumCheck);
                   rowtemp2.GetCell(4).CellStyle = styledata;
                   rowtemp2.CreateCell(5).SetCellValue(okCheck);
                   rowtemp2.GetCell(5).CellStyle = styledata;
                   rowtemp2.CreateCell(6).SetCellValue(NgCheck);
                   rowtemp2.GetCell(6).CellStyle = styledata;

             //写入流
              System.IO.MemoryStream ms = new MemoryStream();
              book.Write(ms);
              ms.Seek(0, SeekOrigin.Begin);
              return ms;
        }


       /*****************************************/
       /// <summary>
       /// 外观检查月报Excel
       /// </summary>
       /// <param name="ds"></param>
       /// <param name="ReportHeader"></param>
       /// <returns></returns>
       public static MemoryStream ExprotXlsByYear(DataSet ds, string ReportHeader = "")
       {
           //创建Excel文件的对象
           HSSFWorkbook book = new HSSFWorkbook();
           //添加一个sheet 
           HSSFSheet sheet1 = (HSSFSheet)book.CreateSheet(ReportHeader);
           //设置列宽度
           for (int i = 0; i < ds.Tables[0].Columns.Count + 19; i++)
           {
               if ((i>-1&&i<3) ||(i>4&&i<8))//第一、二列
               {
                   sheet1.SetColumnWidth(i, 11 * 250);
               }
               else
               {
                   sheet1.SetColumnWidth(i, 8 * 256);
               }
           }
           //设置全局行高
           sheet1.DefaultRowHeightInPoints = 14;
           //字体
           IFont fontkh = book.CreateFont();//创建一个字体样式
           fontkh.FontHeightInPoints = 12;//字体大小
           fontkh.FontName = "宋体";//字体名
           //添加考核标题样式
           //单元格样式
           ICellStyle stylekh = book.CreateCellStyle();
           stylekh.Alignment = HorizontalAlignment.Left;//左对齐
           stylekh.WrapText = true;//自动换行
           stylekh.FillForegroundColor = HSSFColor.PaleBlue.Index;//前景色
           stylekh.FillPattern = FillPattern.SolidForeground;//填充样式
           stylekh.VerticalAlignment = VerticalAlignment.Center;//上下居中
           stylekh.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh.SetFont(fontkh);


           ICellStyle stylekh1 = book.CreateCellStyle();
           stylekh1.Alignment = HorizontalAlignment.Left;//左对齐
           stylekh1.WrapText = true;//自动换行
           stylekh1.FillForegroundColor = HSSFColor.LightCornflowerBlue.Index;//前景色
           stylekh1.FillPattern = FillPattern.SolidForeground;//填充样式
           stylekh1.VerticalAlignment = VerticalAlignment.Center;//上下居中
           stylekh1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           stylekh1.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           stylekh1.SetFont(fontkh);

           //第一行合并单元格
           CellRangeAddress firstcellRange = new CellRangeAddress(0, 1, 0,ds.Tables[0].Columns.Count+18);
           sheet1.AddMergedRegion(firstcellRange);

           //显示数据字体
           IFont fontdata1 = book.CreateFont();//创建一个字体样式
           fontdata1.FontHeightInPoints = 11;//字体大小
           fontdata1.Color = (short)ConsoleColor.Green;
           fontdata1.FontName = "宋体";//字体名
           ICellStyle styledata1 = book.CreateCellStyle();//创建显示数据格式
           styledata1.Alignment = HorizontalAlignment.Center;//左对齐
           styledata1.WrapText = true;
           styledata1.VerticalAlignment = VerticalAlignment.Center;//上下居中
           styledata1.SetFont(fontdata1);

           //显示数据字体
           IFont fontdata = book.CreateFont();//创建一个字体样式
           fontdata.FontHeightInPoints = 11;//字体大小
           fontdata.FontName = "宋体";//字体名
           ICellStyle styledata = book.CreateCellStyle();//创建显示数据格式
           styledata.WrapText = true;
           styledata.VerticalAlignment = VerticalAlignment.Center;//上下居中
           styledata.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;//显示边框
           styledata.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;//边框显示颜色
           styledata.SetFont(fontdata);


           ICellStyle style = book.CreateCellStyle();
           style.Alignment = HorizontalAlignment.Center;
           style.WrapText = true;
           IFont font = book.CreateFont();
           font.FontHeightInPoints = 20;//字体大小
           font.Boldweight = (short)FontBoldWeight.Bold;
           font.FontName = "宋体";
           style.SetFont(font);

           HSSFRow row = (HSSFRow)sheet1.CreateRow(0);
           row.CreateCell(0).SetCellValue("外观检查不良清单");
           row.GetCell(0).CellStyle = style;
           //给sheet1添加第一行的头部标题
           HSSFRow row1 = (HSSFRow)sheet1.CreateRow(2);
           row1.HeightInPoints = 40;
            
           string mColumnName = "";//列标题的名称
           string[] strs = new string[]
            {"料伤","夹伤","划伤","打伤","磨伤","轴承不过","倒角不良",
             "抛光变形","扁错位","刀痕","孔径不良","尾刺","粗糙度",
             "电镀不良","生锈","漏工程","料头","跳动不良","长度不良","加工错误","其他"};//数组存储不良类型，用来构造列头


           for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
           {
               //标题
               mColumnName = ds.Tables[0].Columns[k].ColumnName.ToString();
               if (k > ds.Tables[0].Columns.Count -3 )
                   {
                       //此处是不良类型的标题，隐去了不良类型与不良数,利用生产的数组代替
                       if (k == (ds.Tables[0].Columns.Count - 1))
                       {
                           for (int i = 0; i < strs.Length; i++)
                           {
                               row1.CreateCell(k-2+i).SetCellValue(strs[i]);
                               row1.GetCell(k-2+i).CellStyle = stylekh1;
                           }
                       }
                   }
                   else
                   {
                       if (k == 8)
                       {
                           row1.CreateCell(strs.Length + 8).SetCellValue(mColumnName);
                           row1.GetCell(strs.Length + 8).CellStyle = stylekh1;
                       }
                       else
                       {
                           row1.CreateCell(k).SetCellValue(mColumnName);
                           row1.GetCell(k).CellStyle = stylekh;
                       }
                   }
           }

           int SumCheck = 0;
           int okCheck = 0;
           int NgCheck = 0;
           int asd;
           Dictionary<int, int> dic =  new Dictionary<int, int>();
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               HSSFRow rowtemp1 = (HSSFRow)sheet1.CreateRow(i + 3);
               for (int j = 0; j < ds.Tables[0].Columns.Count - 1; j++)
               {
                   if (j > ds.Tables[0].Columns.Count - 4  && ((ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1]) == null ? false : true))
                   {
                       if (j == 8)
                       {
                           rowtemp1.CreateCell(strs.Length + j).SetCellValue(ds.Tables[0].Rows[i][j].ToString());
                       }
                      if (j == 9)
                      {
                          string[] types = ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 2].ToString().Split(',');
                          string[] cts = ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1].ToString().Split(',');
                          if (types.Length > 1 && cts.Length > 1)
                          {
                              for (int cs = 0; cs < cts.Length; cs++)
                              {

                                  if (dic.Where(u => u.Key.Equals(j + int.Parse(types[cs]) - 2)).Count()>0)
                                      {
                                         int a =int.Parse(cts[cs]) + dic[j + int.Parse(types[cs]) - 2];
                                          dic.Remove(j + int.Parse(types[cs]) - 2);
                                          dic.Add(j + int.Parse(types[cs]) - 2, a);
                                      }
                                      else
                                      {
                                          dic.Add(j + int.Parse(types[cs]) - 2, int.Parse(cts[cs]));
                                      }
                                  
                                  rowtemp1.CreateCell(j + int.Parse(types[cs])-2).SetCellValue(int.Parse(cts[cs]));
                              }
                          }
                      }

                   }
                   else
                   {

                       int.TryParse(ds.Tables[0].Rows[i][j].ToString(), out asd);
                       if (asd > 0 ||j==7)
                       {
                           if (j == 5)
                           {
                               SumCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                           }
                           if (j == 6)
                           {
                               okCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                           }
                           if (j == 7)
                           {
                               NgCheck += int.Parse(ds.Tables[0].Rows[i][j].ToString());
                           }
                           rowtemp1.CreateCell(j ).SetCellValue(int.Parse(ds.Tables[0].Rows[i][j].ToString()));
                   
                       }
                      
                       else
                       {
                           if (j == 0)
                           {
                               rowtemp1.CreateCell(j).SetCellValue(DateTime.Parse(ds.Tables[0].Rows[i][j].ToString()).ToString("yyyy/MM/dd"));
                           }
                           else
                           {
                               rowtemp1.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i][j].ToString());
                           }
                       }
                   }
               }

           }

           HSSFRow rowtemp2 = (HSSFRow)sheet1.CreateRow(ds.Tables[0].Rows.Count+3);
           rowtemp2.CreateCell(4).SetCellValue("合计:");
           rowtemp2.GetCell(4).CellStyle = styledata;
           rowtemp2.CreateCell(5).SetCellValue(SumCheck);
           rowtemp2.GetCell(5).CellStyle = styledata;
           rowtemp2.CreateCell(6).SetCellValue(okCheck);
           rowtemp2.GetCell(6).CellStyle = styledata;
           rowtemp2.CreateCell(7).SetCellValue(NgCheck);
           rowtemp2.GetCell(7).CellStyle = styledata;
           foreach (var item in dic)
           {
                 rowtemp2.CreateCell(item.Key).SetCellValue(item.Value);
                 rowtemp2.GetCell(item.Key).CellStyle = styledata;
           }
           MemoryStream ms =new MemoryStream();
           book.Write(ms);
           ms.Seek(0,SeekOrigin.Begin);
           return ms;
       }

       /// <summary>
       /// 用NPOI直接读取excel返回DataTable
       /// </summary>
       /// <param name="ExcelFileStream"></param>
       /// <param name="SheetIndex"></param>
       /// <param name="StartRowIndex"></param>
       /// <returns></returns>
       public static DataTable ReadXlsxToDataTable(Stream ExcelFileStream, int SheetIndex, int StartRowIndex)
       {
           XSSFWorkbook workbook = new XSSFWorkbook(ExcelFileStream);
           XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(SheetIndex);
           bool isHaveData = false;

           DataTable table = new DataTable();
           XSSFRow headerRow = (XSSFRow)sheet.GetRow(StartRowIndex);
           int cellCount = headerRow.LastCellNum;

           for (int i = headerRow.FirstCellNum; i < cellCount; i++)
           {
               DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
               table.Columns.Add(column);
           }
           int rowCount = sheet.LastRowNum;
           for (int i = (StartRowIndex + 1); i <= sheet.LastRowNum; i++)
           {
               try
               {
                   XSSFRow row = (XSSFRow)sheet.GetRow(i);
                   DataRow dataRow = table.NewRow();
                   isHaveData = false;

                   for (int j = row.FirstCellNum; j < cellCount; j++)
                   {
                       if (row.GetCell(j) != null && row.GetCell(j).ToString() != "")
                       {
                           dataRow[j] = row.GetCell(j).ToString();
                           isHaveData = true;
                       }

                   }
                   if (isHaveData)
                   {
                       table.Rows.Add(dataRow);
                   }

               }
               catch (Exception)
               {

               }

           }
           ExcelFileStream.Close();
           workbook = null;
           sheet = null;
           return table;
       }

       /// <summary>
       /// 用NPOI直接读取excel返回DataTable
       /// </summary>
       /// <param name="ExcelFileStream"></param>
       /// <param name="SheetIndex"></param>
       /// <param name="StartRowIndex"></param>
       /// <returns></returns>
       public static DataTable ReadXlsToDataTable(Stream ExcelFileStream, int SheetIndex, int StartRowIndex)
       {
           HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
           HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(SheetIndex);
           bool isHaveData = false;

           DataTable table = new DataTable();
           HSSFRow headerRow = (HSSFRow)sheet.GetRow(StartRowIndex);
           int cellCount = headerRow.LastCellNum;

           for (int i = headerRow.FirstCellNum; i < cellCount; i++)
           {
               DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
               table.Columns.Add(column);
           }
           int rowCount = sheet.LastRowNum;
           for (int i = (StartRowIndex + 1); i <= sheet.LastRowNum; i++)
           {
               try
               {
                   HSSFRow row = (HSSFRow)sheet.GetRow(i);
                   DataRow dataRow = table.NewRow();
                   isHaveData = false;

                   for (int j = row.FirstCellNum; j < cellCount; j++)
                   {
                       if (row.GetCell(j) != null && row.GetCell(j).ToString() != "")
                       {
                           dataRow[j] = row.GetCell(j).ToString();
                           isHaveData = true;
                       }

                   }
                   if (isHaveData)
                   {
                       table.Rows.Add(dataRow);
                   }

               }
               catch (Exception)
               {

               }

           }
           ExcelFileStream.Close();
           workbook = null;
           sheet = null;
           return table;
       }



      
    }
}
