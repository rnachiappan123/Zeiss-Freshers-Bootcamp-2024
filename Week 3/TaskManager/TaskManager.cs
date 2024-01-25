namespace TaskManagerProblem
{
    public interface IPrinter
    {
        void Print(string path);
    }

    public interface IScanner
    {
        void Scan(string path);
    }

    public class Printer : IPrinter
    {
        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }
    }

    public class PrintScanner : IPrinter, IScanner
    {
        private readonly Printer printer;
        private readonly Scanner scanner;
        public PrintScanner()
        {
            printer = new Printer();
            scanner = new Scanner();
        }
        public void Print(string path)
        {
            printer.Print(path);
        }
        public void Scan(string path)
        {
            scanner.Scan(path);
        }
    }
    public static class TaskManager
    {
        public static void ExecuctePrintTask(IPrinter printer, string documentPath)
        {
            printer.Print(documentPath);
        }
        public static void ExecucteScanTask(IScanner scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }
    }

    public class Program
    {
        static void Main()
        {
            Printer printerObj = new Printer();
            Scanner scannerObj = new Scanner();
            PrintScanner printScannerObj = new PrintScanner();

            TaskManager.ExecuctePrintTask(printerObj, "Test.doc");
            TaskManager.ExecucteScanTask(scannerObj, "MyImage.png");
            TaskManager.ExecuctePrintTask(printScannerObj, "NewDoc.doc");
            TaskManager.ExecucteScanTask(printScannerObj, "YourImage.png");
        }
    }
}