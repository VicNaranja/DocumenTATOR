using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;              

namespace TATOR
{
    public class ExcelHelpers
    {
        
        public static void ExportToExcel(List<ObjetoExcel> listaObjetos,
                                        string filePath,
                                        string fileName,
                                        bool pijama = false)
        {
            // Add \ to end of file name if it doesn't exist. Just want to be consistant
            if (!filePath.EndsWith(@"\"))
                filePath += @"\";

            // Create directory if it doesn't exist
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            // Start Excel and get Application object.
            Excel.Application excel = new Excel.Application();

            excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook currentWorkbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
            currentWorksheet.Columns.ColumnWidth = 18;

            // Set it hidden and hide alerts
            excel.Visible = false;
            excel.DisplayAlerts = false;

            // Create a new workbook.
            Excel.Workbook workbook = excel.Workbooks.Add();

            var code = 0;
            foreach(var objeto in listaObjetos)
            {
                var sheet = (Excel.Worksheet)workbook.Worksheets.Add();
                if (objeto.NombreObjeto.Length > 30)
                {
                    sheet.Name = objeto.NombreObjeto.Substring(0, 29) + code;
                    code++;
                }
                else
                {
                    sheet.Name = objeto.NombreObjeto;
                }
                
                //Pijama
                if (pijama)
                {
                    for (var i = 0; i <= objeto.ListaCampos.Count+1; i++)
                    {
                        if (i % 2 == 0 && i > 0)
                            sheet.Range["A" + i, "F" + i].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255,244,244,244));
                    }
                }
                //cabecera
                sheet.Range["A1", "F1"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
                generarHoja<Info>(objeto.ListaCampos, sheet);
            }

            /*
            var sheet6 = (Excel.Worksheet)workbook.ActiveSheet;
            sheet6.Name = "PERCENTILES_CORTOS_MP";
            generarHoja<PercentilesCortosMP>(listaCortosMP, sheet6);
            //coloreamos la cabecera
            sheet6.Range["A1", "B1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);

            var sheet5 = (Excel.Worksheet)workbook.Worksheets.Add();
            sheet5.Name = "PERCENTILES_CORTOS";
            generarHoja<PercentilesCortos>(listaCortos, sheet5);
            sheet5.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            sheet5.Range["A2", "A200"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
            sheet5.Range["G2", "G200"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);

            var sheet4 = (Excel.Worksheet)workbook.Worksheets.Add();
            sheet4.Name = "DATOS_NUCLEI";
            generarHoja<DescriptivaControl>(listaCN, sheet4);
            sheet4.Range["A1", "I1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            sheet4.Range["A2", "A9"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
            sheet4.Range["D2", "D9"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);

            var sheet3 = (Excel.Worksheet)workbook.Worksheets.Add();
            sheet3.Name = "DATOS_MUESTRAS";
            generarHoja<DescriptivaKB>(listaKb, sheet3);
            sheet3.Range["A1", "I1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            sheet3.Range["A2", "A200"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
            sheet3.Range["H2", "H200"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);

            var sheet2 = (Excel.Worksheet)workbook.Worksheets.Add();
            sheet2.Name = "DATOS_POCILLOs";
            generarHoja<DescriptivaTest>(listaTest, sheet2);
            sheet2.Range["A1", "M1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            sheet2.Range["A2", "A400"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);
            sheet2.Range["I2", "I400"].Interior.Color = ColorTranslator.ToOle(Color.LightSteelBlue);

            // Get the active sheet
            var sheet = (Excel.Worksheet)workbook.Worksheets.Add();
            sheet.Name = "RELACION_POCILLO_MUESTRA";
            generarHoja<RelacionPocilloMuestra>(listaRelacion, sheet);
            sheet.Range["A1", "F1"].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
            */


            // Save workbook
            //workbook.SaveAs(
            //    string.Format("{0}{1}", new object[] { filePath, fileName }),
            //    Excel.XlFileFormat.xlOpenXMLWorkbook);


            workbook.SaveAs(string.Format("{0}{1}", new object[] { filePath, fileName }), Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
    Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
    Excel.XlSaveConflictResolution.xlUserResolution, true,
    Missing.Value, Missing.Value, Missing.Value);

            // Close
            workbook.Close();
            workbook = null;
            excel.Quit();


            // Clean up
            // NOTE: When in release mode, this does the trick
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }


        private static void generarHoja<T>(IEnumerable<T> objects, Excel.Worksheet sheet)
        {

            try
            {
                // Convert the list into a rectangular array that Excel can read
                var data = GetObjectArray<T>(objects);

                // If at least one record got converted successfully
                if (data.Length > 1)
                {
                    var numColum = data.GetLength(1);
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        try
                        {
                            // Get the range of cells that the data will go into. Size matches rectangular array size
                            string xlsRange = string.Format("A{2}:{0}{1}",
                                new object[] { GetExcelColumn(numColum), i + 1, i + 1 });


                            // Insert data into the specified range of cells
                            Excel.Range range = sheet.get_Range(xlsRange);
                            range.Value = getFila<T>(data, i, numColum);

                            // Auto-Fit the columns
                            //range.EntireColumn.AutoFit();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message + getFila<T>(data, i, numColum));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static object[,] getFila<T>(object[,] lista, int fila, int columna)
        {
            object[,] data = new object[1,columna];
            for (int c = 0; c <= columna-1; c++)
            {
                data[0, c] = lista[fila, c];
            }
            return data;
        }

        /// <summary>
        /// Takes a List of objects objects and converts the objects and their properties into a rectangular array of objects
        /// </summary>
        /// <param name="objects">List of objects to flatten</param>
        /// <returns>Rectangular array where objects are stored in [0] and properties are stored in [1]</returns>
        private static object[,] GetObjectArray<T>(IEnumerable<T> objects)
        {
            // Get list of object properties
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Create rectangular array based on # of objects and # of object properties
            object[,] data = new object[objects.Count() + 1, properties.Length];

            // Loop through properties on object
            for (int j = 0; j < properties.Count(); j++)
            {
                // Write the property name into the first row of the array
                data[0, j] = properties[j].Name.Replace("_", " ");

                // Loop through objects and write out the specified property of each one into the array
                for (int i = 0; i < objects.Count(); i++)
                {
                    data[i + 1, j] = properties[j].GetValue(objects.ElementAt(i), null);
                }
            }

            // Return rectangular array
            return data;
        }

        /// <summary>
        /// Takes an Integer and converts it into Excel's column header code.
        /// For example: 1 = A; 2 = B; 27 = AA;
        /// </summary>
        /// <param name="colNumber">Number of Column in Excel. 1 = A</param>
        /// <returns>string that Excel can use</returns>
        private static string GetExcelColumn(int colNumber)
        {
            // If value is zero or less, return an empty string
            if (colNumber <= 0)
                return string.Empty;

            // If the value is less than or equal to 26 (Z), the column header
            // is only one character long. If it's greater, call this recursively
            // to get the first letter(s) of the column code.
            string first = (colNumber <= 26 ? string.Empty :
                GetExcelColumn((int)Math.Floor((colNumber - 1) / 26.00)));

            // Get the final letter in the column code
            int second = colNumber % 26;
            if (second == 0) second = 26;
            char finalLetter = (char)('A' + second - 1);            // Excel column header is the first part + the final character
            return string.Format("{0}{1}", new object[] { first, finalLetter });
        }
    }
}
