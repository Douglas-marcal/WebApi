using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations;

public partial class SeedPosts : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("INSERT INTO Posts(Title, Description, CreatedAt, UpdatedAt, UserId) VALUES('Post01', 'dia de sol', now(), now(), 1)");
        migrationBuilder.Sql("INSERT INTO Posts(Title, Description, CreatedAt, UpdatedAt, UserId) VALUES('Post02', 'dia de chuva', now(), now(), 2)");
        migrationBuilder.Sql("INSERT INTO Posts(Title, Description, CreatedAt, UpdatedAt, UserId) VALUES('Post03', 'aviao', now(), now(), 1)");
        migrationBuilder.Sql("INSERT INTO Posts(Title, Description, CreatedAt, UpdatedAt, UserId) VALUES('Post04', 'dia de gremio', now(), now(), 3)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Posts");
    }
}
