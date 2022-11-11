using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelTeste.Models;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String nome = fuArquivo.FileName;
        String caminho = Server.MapPath(@"~\servidor\");
        String filePath = caminho + nome;

        txbNome.Text = nome;
        txbTamanho.Text = fuArquivo.PostedFile.ContentLength.ToString();
        fuArquivo.PostedFile.SaveAs(filePath);

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {

            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // Choose one of either 1 or 2:

                // 1. Use the reader methods
                do
                {
                    while (reader.Read())
                    {
                        // reader.GetDouble(0);
                    }
                } while (reader.NextResult());

                // 2. Use the AsDataSet extension method
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                String PrimeiraColuna = result.Tables[0].Rows[0]["Loja"].ToString();
                String SegundaColuna = result.Tables[0].Rows[0]["Tipo_de_gasto"].ToString();
                String TerceiraColuna = result.Tables[0].Rows[0]["Valor"].ToString();

                TextBox1.Text = PrimeiraColuna;
                TextBox2.Text = SegundaColuna;
                TextBox3.Text = TerceiraColuna;

                List<ExcelLine> exceltable = new List<ExcelLine>();

                foreach (DataRow Row in result.Tables[0].Rows)
                {
                    ExcelLine excelline = new ExcelLine();
                    excelline.Loja = Row["Loja"].ToString();
                    excelline.Tipo_de_gasto = Row["Tipo_de_gasto"].ToString();
                    excelline.Valor = Convert.ToDecimal(Row["Valor"]);

                    exceltable.Add(excelline);

                }

                GridView1.DataSource = exceltable;
                GridView1.DataBind();
                                
                List<ExcelLine> filtroexcel = exceltable

                    .GroupBy(l => l.Loja)
                    .Select(a => new ExcelLine 
                        { 
                            Loja = a.Select(c => c.Loja).FirstOrDefault(), 
                            Valor = a.Sum(b => b.Valor)
                         }).ToList();

                List<ExcelLine> filtroteste = exceltable

                    .GroupBy(l => l.Tipo_de_gasto)
                    .Select(a => new ExcelLine
                    {
                        Tipo_de_gasto = a.Select(c => c.Tipo_de_gasto).FirstOrDefault(),
                        Valor = a.Sum(b => b.Valor)
                    }).ToList();

                GridView2.DataSource = filtroexcel;
                GridView2.DataBind();

                GridView3.DataSource = filtroteste;
                GridView3.DataBind();


            }
        }

    }

 }
