using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Descrição resumida de Excel
/// </summary>
namespace ExcelTeste.Models
{
    public class ExcelLine
    {
        public string Loja { get; set; }
        public string Tipo_de_gasto { get; set; }
        public decimal Valor { get; set; }

        public ExcelLine()
        {

        }

    }
}