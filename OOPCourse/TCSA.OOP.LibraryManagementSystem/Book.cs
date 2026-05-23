namespace TSCA.OOP.LibraryManagementSystem;

internal class Book
{
    public string Name { get; set; } = "Unknown";
    public int Pages { get; set; } = 100;

    public Book(string name, int pages)
    {
        Name = name;
        Pages = pages;
    }
}