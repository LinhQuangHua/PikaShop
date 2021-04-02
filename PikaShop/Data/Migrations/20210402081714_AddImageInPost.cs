using Microsoft.EntityFrameworkCore.Migrations;

namespace PikaShop.Data.Migrations
{
    public partial class AddImageInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_Posts_Postid_post",
                table: "CommentPosts");

            migrationBuilder.DropIndex(
                name: "IX_CommentPosts_Postid_post",
                table: "CommentPosts");

            migrationBuilder.DropColumn(
                name: "Postid_post",
                table: "CommentPosts");

            migrationBuilder.AddColumn<string>(
                name: "image_01",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_02",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_03",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_id_post",
                table: "CommentPosts",
                column: "id_post");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_Posts_id_post",
                table: "CommentPosts",
                column: "id_post",
                principalTable: "Posts",
                principalColumn: "id_post",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_Posts_id_post",
                table: "CommentPosts");

            migrationBuilder.DropIndex(
                name: "IX_CommentPosts_id_post",
                table: "CommentPosts");

            migrationBuilder.DropColumn(
                name: "image_01",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "image_02",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "image_03",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Postid_post",
                table: "CommentPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_Postid_post",
                table: "CommentPosts",
                column: "Postid_post");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_Posts_Postid_post",
                table: "CommentPosts",
                column: "Postid_post",
                principalTable: "Posts",
                principalColumn: "id_post",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
