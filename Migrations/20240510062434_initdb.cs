using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using razor08.efcore;

#nullable disable

namespace razor_ef.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ID);
                });
            //insert data
            //fake data: bogus
            Randomizer.Seed = new Random(8675309);
            var fackerArticle = new Faker<Article>();
            fackerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fackerArticle.RuleFor(a => a.PublishDate, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2023, 1, 1)));
            fackerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 20));
            for (int i = 0; i < 1500; i++)
            {
                Article article = fackerArticle.Generate();

                migrationBuilder.InsertData(


               table: "Article",
               columns: new[] { "Title", "PublishDate", "Content" },
               values: new object[]{
                   article.Title ,
                      article.PublishDate,
                        article.Content,
               }
           );
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
