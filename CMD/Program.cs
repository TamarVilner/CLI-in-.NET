//fib bundle --output bundleFile.txt

using System.CommandLine;

var bundleOption = new Option<FileInfo>("--output", "File path and name");

//מקבלת שם ותיאור
var bundleCommand = new Command("gili", "Bundle code files to a single file");
bundleCommand.AddOption(bundleOption);
//איזה פקודה תופעל כירשמו את bundle
bundleCommand.SetHandler((output) =>
{
    try
    {
        File.Create(output.FullName);
        Console.WriteLine("File was created, Hi Gili~~~~~~~~~~ bundle command");
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("eror: File path is invalid");
    }
}, bundleOption);
//השורש
var rootCommand = new RootCommand("Root command for file Bundler CLI");
rootCommand.AddCommand(bundleCommand);

//args אין לנו במפורש אבל זה הארגומנטים של המיין
rootCommand.InvokeAsync(args);

