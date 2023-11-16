using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class Seededmorebooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "GenreId", "ISBN", "Image", "LanguageId", "NumberOfPages", "PublisherId", "Title", "YearOfPublishing" },
                values: new object[,]
                {
                    { 2, "A novel by Harper Lee", 4, "978-3-16-148410-1", "to_kill_a_mockingbird.jpg", 1, 281, 3, "To Kill a Mockingbird", 1960 },
                    { 3, "A dystopian novel by George Orwell", 2, "978-3-16-148410-2", "1984.jpg", 1, 328, 3, "1984", 1949 },
                    { 4, "A novel by J.D. Salinger", 4, "978-3-16-148410-3", "catcher_in_the_rye.jpg", 1, 277, 3, "The Catcher in the Rye", 1951 },
                    { 5, "A novel by J.R.R. Tolkien", 1, "978-3-16-148410-4", "the_hobbit.jpg", 1, 310, 1, "The Hobbit", 1937 },
                    { 6, "A novel by J.R.R. Tolkien", 1, "978-3-16-148410-5", "the_lord_of_the_rings.jpg", 1, 1178, 1, "The Lord of the Rings", 1954 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 6 },
                    { 4, 4 },
                    { 6, 2 },
                    { 10, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 1 });
        }
    }
}
