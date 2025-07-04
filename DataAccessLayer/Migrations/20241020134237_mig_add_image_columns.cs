﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
	/// <inheritdoc />
	public partial class mig_add_image_columns : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
	        name: "ImageUrl",
	        table: "Images",
	        type: "nvarchar(max)",
          	nullable: false,
         	defaultValue: "");

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
			name: "ImageUrl",
			table: "Images");
		}
	}
}
