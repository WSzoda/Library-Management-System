using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class Seededdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Poland" },
                    { 2, "United Kingdom" },
                    { 3, "United States" },
                    { 4, "France" },
                    { 5, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "ul. Kowalska 1, 00-000 Warszawa", "kowlski@jan.pl", "Jan", "123456789", "Kowalski" },
                    { 2, "ul. Nowaka 1, 00-000 Warszawa", "adam@nowak.pl", "Adam", "987654321", "Nowak" },
                    { 3, "ul. Nowacki 1, 00-000 Warszawa", "kamil@nowacki.pl", "Kamil", "123123123", "Nowacki" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Horror" },
                    { 4, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Polish" },
                    { 3, "German" },
                    { 4, "French" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Email", "Name", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, "test@wp.pl", "Wojtek", "Admin", "Szoda" },
                    { 2, "kowalski@test.pl", "Jan", "Worker", "Kowalski" },
                    { 3, "adam@nowak.pl", "Adam", "Worker", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CountryId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 2, "J.R.R.", "Tolkien" },
                    { 2, 3, "Stephen", "King" },
                    { 3, 1, "Andrzej", "Sapkowski" },
                    { 4, 3, "George R.R.", "Martin" },
                    { 5, 2, "J.K.", "Rowling" },
                    { 6, 3, "H.P.", "Lovecraft" },
                    { 7, 2, "William", "Shakespeare" },
                    { 8, 2, "Jane", "Austen" },
                    { 9, 2, "Emily", "Bronte" },
                    { 10, 2, "Charlotte", "Bronte" },
                    { 11, 2, "Anne", "Bronte" },
                    { 12, 2, "Arthur Conan", "Doyle" },
                    { 13, 2, "Agatha", "Christie" },
                    { 14, 4, "Jules", "Verne" },
                    { 15, 3, "Herman", "Melville" },
                    { 16, 3, "Mark", "Twain" },
                    { 17, 2, "Charles", "Dickens" },
                    { 18, 5, "Fyodor", "Dostoevsky" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CountryId", "Name", "YearOfCreation" },
                values: new object[,]
                {
                    { 1, 1, "PWN", 0 },
                    { 2, 1, "Wydawnictwo Literackie", 0 },
                    { 3, 2, "Penguin Books", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
