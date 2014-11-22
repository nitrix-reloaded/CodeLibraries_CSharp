﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelUtilsApp
{
   class Program

    {

        /// <summary>

        /// Mains the specified args.

        /// </summary>

        /// <param name="args">The args.</param>

        static void Main(string[] args)

        {


            ExcelUtils excelUtils = new ExcelUtils();


            DataSet dummySet = CreateDummyDataSet();


            excelUtils.SaveWorkbook("c:\\Test9.xlsx", dummySet,true,true);


           // excelUtils.Save("c:\Test7.xlsx", dummySet);

            DataSet dsNewSet =  excelUtils.Read("c:\\Test9.xlsx");


            Console.Read();

        }


        /// <summary>

        /// Creates the dummy data set.

        /// </summary>

        /// <returns></returns>

        public static DataSet CreateDummyDataSet()

        {

            DataSet resultSet = new DataSet();


            for (int tableIndex = 0; tableIndex < 5; tableIndex ++ )

            {

                DataTable dataTable = new DataTable("Table" + tableIndex.ToString());


                for (int colIndex = 0; colIndex < 10; colIndex++)

                {

                    if(colIndex % 2 == 0)

                    {

                        dataTable.Columns.Add("Column" + colIndex.ToString(), Type.GetType("System.Decimal"));

                    }

                    else

                    {

                        dataTable.Columns.Add("Column" + colIndex.ToString(), Type.GetType("System.String"));

                    }

                }


                for(int rowIndex = 0; rowIndex < 20000; rowIndex++)

                {

                    DataRow dataRow = dataTable.NewRow();


                    for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)

                    {

                        if (colIndex % 2 == 0)

                        {

                            dataRow[dataTable.Columns[colIndex].ColumnName] = (rowIndex* (colIndex+1)) + colIndex;

                        }

                        else

                        {

                            dataRow[dataTable.Columns[colIndex].ColumnName] = "STR : " + (rowIndex * (colIndex + 1)) + colIndex;

                        }


                    }

                    dataTable.Rows.Add(dataRow);

                }

                resultSet.Tables.Add(dataTable);

            }


            return resultSet;

        }


    }
}
