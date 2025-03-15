using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class _0001initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Unicode = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    Publisher = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Holder = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Translator = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookEntityCategoryEntity",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntityCategoryEntity", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookEntityCategoryEntity_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEntityCategoryEntity_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impressions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Impressions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionEntityImpressionEntity",
                columns: table => new
                {
                    EmotionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImpressionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionEntityImpressionEntity", x => new { x.EmotionsId, x.ImpressionsId });
                    table.ForeignKey(
                        name: "FK_EmotionEntityImpressionEntity_Emotions_EmotionsId",
                        column: x => x.EmotionsId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmotionEntityImpressionEntity_Impressions_ImpressionsId",
                        column: x => x.ImpressionsId,
                        principalTable: "Impressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "CreatedAt", "Label", "Name", "Unicode" },
                values: new object[,]
                {
                    { new Guid("06b4438b-ef60-426a-99f3-fe82ec54cd0d"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3227), "Мило", "panda_face", "🐼" },
                    { new Guid("0bc340f2-27e5-4d89-9c2f-ba24657653b2"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3229), "Скучно", "zzz", "😴" },
                    { new Guid("0c00c1f6-e3a4-45b3-9c6f-618c90421ed8"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3220), "Советую", "thumbsup", "👍" },
                    { new Guid("19c00d77-d421-4915-b05b-cd0801804dde"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3236), "Ничего не понятно", "confusing", "🙈" },
                    { new Guid("54a7ec3a-df40-4664-b0ae-546a1a34aab7"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3224), "Не советую", "thumbsdown", "👎" },
                    { new Guid("74f01d46-9071-495c-a4f8-7058bd484b7e"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3241), "Полезно", "useful", "🎯" },
                    { new Guid("91eae0db-2e67-4bb8-96d3-662d2f8c6fb6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3247), "Весело", "fun", "😆" },
                    { new Guid("9cba8230-bf44-459c-ab1e-86bc59fe4ed6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3244), "В отпуск", "palm_tree", "🏝" },
                    { new Guid("a6e94fac-d9c5-437f-842d-cff0db0bd994"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3226), "До слез", "droplet", "💧" },
                    { new Guid("b0282a18-af1c-4532-9910-57cf4f3f875a"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3239), "Познавательно", "bulb", "💡" },
                    { new Guid("c3a81a37-e762-4d99-aa35-2cb80e7dfd4d"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3232), "Страшно", "skull", "💀" },
                    { new Guid("e607b72b-619a-4352-896b-5dce081f73c8"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3231), "Фууу", "shit", "💩" },
                    { new Guid("ece72794-6466-4bf7-8756-2d96ff2d4503"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3237), "Мудро", "wise", "🔮" },
                    { new Guid("f10c4011-9c64-492e-8047-4c90507286fe"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3242), "Романтично", "romantic", "💞" },
                    { new Guid("f3338be6-4613-406b-8f63-a9aba4989cfb"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3245), "Не оторваться", "rocket", "🚀" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2894), "Нон-фикшн" },
                    { new Guid("36638e3f-0125-45a5-b319-5168f5204bd6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2909), "Хорроры" },
                    { new Guid("5267e8c7-a191-417c-93ac-287800972997"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2910), "Здоровье" },
                    { new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2908), "Триллеры" },
                    { new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2893), "Саморазвитие" },
                    { new Guid("8621520d-751d-453e-a5b8-f159806b3cd6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2902), "Young Adult" },
                    { new Guid("a7dcde27-4593-4678-b41d-035ac02b50da"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2903), "Фантастика" },
                    { new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2906), "Мемуары" },
                    { new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2897), "Проза" },
                    { new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2899), "Детективы" },
                    { new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2872), "Психология" },
                    { new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2901), "Бизнес" },
                    { new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2895), "Романтика" },
                    { new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(2905), "Фэнтези" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Title", "TopicId" },
                values: new object[,]
                {
                    { new Guid("0bfa266f-511b-4257-aa28-27a538cb4aa2"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3083), "Мотивация", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("11c262b0-9d0e-4607-9cc4-23b87e59f2c2"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3078), "Когнитивная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("18d8216f-424d-427d-939e-a8dbcb39e752"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3130), "Космическая", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("208aa1cf-e7e6-493b-a99b-3e7245f7d046"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3151), "Готические", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("22e9feeb-7045-4988-a3b0-94c73e11bbfb"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3124), "Дружба", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("23174870-a90b-4b48-81d1-d034444ea930"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3141), "Литературные", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("2af47c33-9b70-45f7-9a16-29cf77a56b73"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3127), "Научная", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("30f92c1e-901e-4418-904d-574469ff2acc"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3118), "Стартапы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("39c5321f-66e6-4d79-8af6-c5dfa04bce85"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3136), "Мифологическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("3e722743-88a6-44cc-a06c-a7405bbe662c"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3156), "Питание", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("42b73148-ef2d-4cfb-b597-8d32c153feb9"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3140), "Исторические", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("47effecc-3145-4e3c-ade1-763cfb751779"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3153), "Паранормальные", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("4a2e6de0-6374-4574-8d2c-29f0bb3e60df"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3157), "Фитнес", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("50e7f784-3fed-40a1-936e-0ff00dbf0d42"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3021), "Клиническая", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("5610063f-50e8-4544-94ae-9fdf150151f0"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3085), "Навыки общения", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("59ae8a73-7a05-4f0f-ad71-b3b0514b50c7"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3098), "Любовные романы", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("5eeab460-0554-467c-93d8-ca388a5f0c2c"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3105), "Экспериментальная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("645a9d1b-8125-4445-a85b-ca935ff88496"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3103), "Современная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("657674b6-f310-4a96-818e-48cca4a0342d"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3135), "Темное", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("6cc9ffbc-ad3b-4bad-8a98-12ab77b23d02"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3099), "Драма", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("73044955-3afa-48e8-82f1-bc10330ed7bb"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3109), "Полицейские", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("74c52b65-8f99-474d-9ec8-370bc3f762de"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3123), "Реализм", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("7b33e9e6-5919-4734-9b14-33e59ba65850"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3116), "Финансы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("83fe682e-e364-4493-a62a-68a4712ca8b0"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3104), "Классическая", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("843a2dcf-0a5d-4c73-b727-5b33db7289f9"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3100), "Эротика", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("8d29a165-aa11-432f-a20c-349c417a3716"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3160), "Психосоматика", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("8d574d0d-9a49-4c5c-9a18-eadcaf66368c"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3090), "Наука", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("96b3f268-1132-4d8a-b86d-baa86988e440"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3146), "Политические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("9adf744c-ca21-48b7-9926-9770c2c8827a"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3148), "Шпионские", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("a5c25fe0-3aae-4ca4-ac64-27397bb56cc9"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3154), "Маньяки", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("a74c1be4-44ee-40ce-9dcf-ff8e9c1e7758"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3091), "Биографии", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("b9e4c150-a9d1-4e48-bc94-9574344d393b"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3113), "Психологические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("c12c5d47-f78c-441e-943b-cb4e94239ec4"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3108), "Классические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("c309af06-4625-49a2-9e52-149ef5a29243"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3131), "Альтернативная история", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("c3bb6d98-f732-4580-a869-f1be5bde4907"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3076), "Социальная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("c3d6ad34-06fd-464c-b468-02272aaf7368"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3089), "История", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("c8d8ad7f-b489-4e94-80a1-a87ae76a6410"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3134), "Эпическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("cc582c5d-0546-43d0-afdf-80ed48172e86"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3121), "Фэнтези", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("dfacecd8-5375-45c0-9102-be09583b84dd"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3082), "Личная эффективность", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("e016898a-e433-4326-8fa4-5217dfacfae6"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3149), "Психологические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("e9f103b6-c782-45e9-9feb-723d4e434cd2"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3139), "Автобиографии", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("ff79412d-1249-4afd-ae71-3af05922deb3"), new DateTime(2025, 3, 15, 9, 55, 45, 124, DateTimeKind.Utc).AddTicks(3117), "Менеджмент", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEntityCategoryEntity_CategoriesId",
                table: "BookEntityCategoryEntity",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Title",
                table: "Categories",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TopicId",
                table: "Categories",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionEntityImpressionEntity_ImpressionsId",
                table: "EmotionEntityImpressionEntity",
                column: "ImpressionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_BookId",
                table: "Favorites",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId_BookId",
                table: "Favorites",
                columns: new[] { "UserId", "BookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Impressions_BookId",
                table: "Impressions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Impressions_UserId",
                table: "Impressions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Title",
                table: "Topics",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookEntityCategoryEntity");

            migrationBuilder.DropTable(
                name: "EmotionEntityImpressionEntity");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "Impressions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
