using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileSaver.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Superclass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaliappealsTo = table.Column<string>(name: "Sali_appealsTo", type: "nvarchar(max)", nullable: true),
                    SalihasExpense = table.Column<string>(name: "Sali_hasExpense", type: "nvarchar(max)", nullable: true),
                    Salifiled = table.Column<string>(name: "Sali_filed", type: "nvarchar(max)", nullable: true),
                    SaliseeksToAchieve = table.Column<string>(name: "Sali_seeksToAchieve", type: "nvarchar(max)", nullable: true),
                    SaliworkedFor = table.Column<string>(name: "Sali_workedFor", type: "nvarchar(max)", nullable: true),
                    Salicited = table.Column<string>(name: "Sali_cited", type: "nvarchar(max)", nullable: true),
                    SaliparticipatedIn = table.Column<string>(name: "Sali_participatedIn", type: "nvarchar(max)", nullable: true),
                    LocatedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeeAlso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SameAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Before = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saliseealso = table.Column<string>(name: "Sali_seealso", type: "nvarchar(max)", nullable: true),
                    legacyIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFirst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkSecond = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRelatedSynonym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefinedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deprecated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InverseOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiddenLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrefLabel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModels");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
