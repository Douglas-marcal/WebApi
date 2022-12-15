using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations;

public partial class SeedUsers : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("INSERT INTO Users(Name, Email, Password) VALUES('Douglas','douglas@email.com', '123456')");
        migrationBuilder.Sql("INSERT INTO Users(Name, Email, Password) VALUES('Wanderley','wanderley@email.com', '123456')");
        migrationBuilder.Sql("INSERT INTO Users(Name, Email, Password) VALUES('Fagundes','fagundes@@email.com', '123456')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Users");
    }
}
