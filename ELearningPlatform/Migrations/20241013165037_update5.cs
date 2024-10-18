﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoPath",
                table: "Videos",
                newName: "ContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "VideoData",
                table: "Videos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoData",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "Videos",
                newName: "VideoPath");
        }
    }
}