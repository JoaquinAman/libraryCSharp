using Domain.Interface;
using Domain.Service;

namespace BackendLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup startup = new Startup();
            var app = startup.InitApp(args);
            app.Run();
        }
    }
}
// generar IDs automatico en la BD
// cambiar librarian por books
