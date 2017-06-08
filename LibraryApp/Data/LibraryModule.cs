using Library.ExportToPdf;
using Library.ExportToPdf.Contracts;
using LibraryApp.Contract;
using Ninject.Modules;

namespace LibraryApp.Data
{
    public class LibraryModule : NinjectModule
    {
        public const string ConsoleLog = "Console Logger";

        public override void Load()
        {
            Bind<IDatabaseLibrary>().To<DatabaseLibrary>().InSingletonScope();
            Bind<ILogger>().To<ConsoleLogger>().Named(ConsoleLog);
            Bind<IPdfGenerator>().To<PdfGenerator>();
        }
    }
}
