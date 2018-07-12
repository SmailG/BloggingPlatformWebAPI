using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggingPlatformBackend.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Comment__BlogPos__5629CD9C",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK__PostTags__BlogPo__52593CB8",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK__PostTags__TagID__534D60F1",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "UQ__PostTags__657CFA4D988AFF33",
                table: "PostTags");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "BlogPost",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "UQ__Tag__BDE0FD1DF380243B",
                table: "Tag",
                column: "TagName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagID",
                table: "PostTags",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK__Comment__BlogPos__5629CD9C",
                table: "Comment",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "BlogPostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__PostTags__BlogPo__60A75C0F",
                table: "PostTags",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "BlogPostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__PostTags__TagID__619B8048",
                table: "PostTags",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Comment__BlogPos__5629CD9C",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK__PostTags__BlogPo__60A75C0F",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK__PostTags__TagID__619B8048",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "UQ__Tag__BDE0FD1DF380243B",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_TagID",
                table: "PostTags");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "BlogPost",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4000);

            migrationBuilder.CreateIndex(
                name: "UQ__PostTags__657CFA4D988AFF33",
                table: "PostTags",
                column: "TagID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Comment__BlogPos__5629CD9C",
                table: "Comment",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "BlogPostID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PostTags__BlogPo__52593CB8",
                table: "PostTags",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "BlogPostID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PostTags__TagID__534D60F1",
                table: "PostTags",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
