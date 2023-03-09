using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlassSearch.Core.Migrations
{
    public partial class DocumentSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "Aut neque architecto nam. Cum et rerum et molestiae dolorum ut dolor. Velit eligendi dolores quam voluptatem. Rerum quam mollitia consequuntur commodi ex. Voluptas nam sunt quasi vel est enim soluta autem. Et est ut asperiores rem quam quis consequatur distinctio.", "autem dolorem corporis" },
                    { 2, "Commodi dolor reprehenderit sit quam consequatur corporis qui assumenda facilis. Consequuntur est aut vero praesentium doloremque autem et fugit sunt. Assumenda facilis adipisci laboriosam necessitatibus non neque rerum voluptatem culpa.", "ut quos quia" },
                    { 3, "Recusandae possimus est sapiente et quas vitae. Officia sed qui aut in minima rerum similique. Est nisi quas distinctio ut ipsam ipsa saepe sequi quia. Porro fugiat reiciendis sequi officiis. Explicabo quod id doloribus iure. Rerum omnis eligendi nulla impedit mollitia sit in laboriosam placeat.", "similique rem inventore" },
                    { 4, "Dolorem tempora accusantium commodi nisi dicta et omnis aliquid est. Rerum sint quam et. Quidem qui earum.", "quidem qui culpa" },
                    { 5, "Dolores unde dolores voluptatem voluptate. Odio et nihil hic. Omnis quam consequatur deleniti eos et omnis et id. Accusantium adipisci doloribus deserunt non molestiae. Qui qui aut cumque eum. Laboriosam doloribus rerum ab id veniam harum possimus aut omnis.", "at et doloremque" },
                    { 6, "Quis ut consequatur nostrum in maiores perferendis excepturi dolores. Quo totam delectus ad itaque consequuntur. Quasi sint autem delectus amet commodi.", "vel enim dolores" },
                    { 7, "Dolores molestiae quibusdam omnis dolor temporibus sequi id ut est. Eum aut nemo deserunt. Repellat qui non quia et id. Dolores aut et praesentium qui facere eius dignissimos quis.", "laboriosam ut voluptatem" },
                    { 8, "Consequatur perspiciatis atque amet occaecati dolores dolor ut. Sapiente doloribus voluptatem error et ut quidem quo voluptas. Ratione ab quibusdam voluptatem est. Praesentium minima iure laboriosam debitis eum. Atque quod et quod neque.", "voluptas odit dolorem" },
                    { 9, "Ex dolorem et dolores non enim sunt est cupiditate. Nisi consequatur aut. Similique occaecati perspiciatis. In omnis voluptas. Quis cum distinctio vel repellat quibusdam.", "asperiores quia voluptatem" },
                    { 10, "Nesciunt consectetur distinctio possimus totam et voluptates eos fuga. Voluptas cumque maxime aut cupiditate cumque. Et distinctio repellendus.", "et ut asperiores" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
