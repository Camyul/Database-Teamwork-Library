using Library.ExportToPdf.Contracts;
using LibraryApp.Core.Contracts;
using LibraryApp.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Commands
{
    class GeneratePdfReport : ICommand
    {

        public string Execute(LibraryDbContext database, string path)
        {
            IKernel kernel = new StandardKernel(new LibraryModule());
            var pdfGenerator = kernel.Get<IPdfGenerator>();
            pdfGenerator.Generate(database, path);
            return $"Successfully generated file {path}";
        }
    }
}
