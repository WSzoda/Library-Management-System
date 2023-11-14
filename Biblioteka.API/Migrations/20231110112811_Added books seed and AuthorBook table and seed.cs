using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class AddedbooksseedandAuthorBooktableandseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BooksId",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "AuthorBook",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "AuthorBook",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "GenreId", "ISBN", "Image", "LanguageId", "NumberOfPages", "PublisherId", "Title", "YearOfPublishing" },
                values: new object[] { 1, "A novel by F. Scott Fitzgerald", 2, "978-3-16-148410-0", "great_gatsby.jpg", 1, 180, 3, "The Great Gatsby", 1925 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BookId",
                table: "AuthorBook");

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "AuthorBook",
                newName: "BooksId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "AuthorBook",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                table: "AuthorBook",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BooksId",
                table: "AuthorBook",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
