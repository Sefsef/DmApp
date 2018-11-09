using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmApi.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    School = table.Column<string>(nullable: true),
                    CastingTime = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Verbal = table.Column<bool>(nullable: false),
                    Somatic = table.Column<bool>(nullable: false),
                    Materials = table.Column<string>(nullable: true),
                    Range = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Roles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spells",
                columns: new[] { "Id", "CastingTime", "Description", "Duration", "Level", "Materials", "Name", "Range", "School", "Somatic", "Verbal" },
                values: new object[] { 1, "1 action", "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one. The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried. At Higher Levels.When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.", "Instantaneous", 3, "a tiny ball of bat guano and sulfur", "Fireball", 150, "evocation", true, true });

            migrationBuilder.InsertData(
                table: "Spells",
                columns: new[] { "Id", "CastingTime", "Description", "Duration", "Level", "Materials", "Name", "Range", "School", "Somatic", "Verbal" },
                values: new object[] { 2, "1 action", "You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage. A flammable object hit by this spell ignites if it isn't being worn or carried. This spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10).", "Instantaneous", 0, "", "Fire Bolt", 120, "evocation", true, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Roles", "Username" },
                values: new object[] { 1, "Severin", "Fitriyadi", new byte[] { 56, 110, 128, 209, 200, 255, 207, 72, 5, 217, 170, 136, 249, 191, 250, 123, 252, 23, 143, 121, 53, 92, 212, 9, 101, 87, 105, 163, 144, 47, 82, 231, 144, 171, 143, 241, 227, 69, 93, 225, 92, 87, 254, 188, 233, 222, 165, 73, 164, 152, 82, 2, 57, 176, 171, 21, 27, 107, 115, 240, 79, 207, 193, 49 }, new byte[] { 33, 214, 125, 145, 186, 227, 147, 138, 53, 105, 31, 28, 52, 81, 214, 72, 144, 163, 169, 14, 188, 178, 41, 22, 40, 163, 28, 108, 114, 130, 52, 82, 34, 97, 199, 173, 81, 206, 22, 149, 161, 53, 13, 233, 231, 232, 17, 219, 251, 136, 42, 221, 93, 17, 115, 24, 151, 114, 34, 128, 209, 58, 77, 191, 206, 178, 7, 217, 157, 148, 196, 181, 74, 102, 51, 48, 11, 139, 65, 31, 6, 72, 62, 94, 250, 67, 20, 93, 141, 250, 0, 65, 103, 35, 26, 28, 142, 32, 138, 67, 36, 72, 56, 233, 134, 237, 151, 224, 26, 72, 82, 102, 110, 158, 36, 16, 23, 115, 121, 229, 23, 216, 18, 204, 202, 51, 228, 229 }, "Admin,Dm,Player", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
