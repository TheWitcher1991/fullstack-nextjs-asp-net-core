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
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    About = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    AvatarPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
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
                table: "Authors",
                columns: new[] { "Id", "About", "AvatarPath", "CreatedAt", "FullName" },
                values: new object[,]
                {
                    { new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), "Американский писатель, работавший в жанрах литературы ужасов, мистики и научной фантастики и, на их основе создавший узнаваемый стиль «лавкрафтовского хоррора».", "/authors/gov.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5499), "Говард Филлипс Лавкрафт" },
                    { new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), "Анджей Сапковский (1948) — польский писатель-фантаст, автор фэнтези-цикла о ведьмаке, лауреат множества литературных премий, второй самый печатаемый польский автор в мире после Станислава Лема.", "/authors/sab.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5496), "Анджей Сапковский" },
                    { new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), "Всемирно известный английский писатель, лингвист, профессор Оксфордского университета и один из основателей «высокого фэнтези» Джон Рональд Руэл Толкин родился в 1892 году в Блумфонтейне, Оранжевая республика (сейчас ЮАР). В Англию будущий писатель с мамой и братом переехал четыре года спустя.", "/authors/tol.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5501), "Джон Рональд Руэл Толкин" },
                    { new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), "Советский и российский писатель-фантаст, представитель поджанра твердой научной фантастики, работавший в писательском тандеме со своим братом — Борисом Стругацким.", "/authors/str.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5506), "Аркадий Стругацкий" },
                    { new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), "Английский писатель, автор сатирической повести «Скотный двор» и романа-антиутопии «1984», журналист и общественный деятель. Имя при рождении — Эрик Артур Блэр.", "/authors/ou.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5502), "Джордж Оруэлл" },
                    { new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), "Лев Толстой — русский писатель. Родился и провел детство в семейном имении Ясная Поляна. Поступил в университет, но, не окончив его, вернулся домой, чтобы заниматься делами поместья.", "/authors/lev.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5505), "Лев Толстой" },
                    { new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), "Дмитрий Глуховский (1979 г. р.) — российский писатель. С момента окончания университета профессия Дмитрия Глуховского — журналист. Работал на телевидении, радио, в печатных СМИ. Автор фантастического романа «Метро 2033», переведенного на 37 языков.", "/authors/dgx.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5498), "Дмитрий Глуховский" },
                    { new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), "Лев Толстой — русский писатель. Родился и провел детство в семейном имении Ясная Поляна. Поступил в университет, но, не окончив его, вернулся домой, чтобы заниматься делами поместья.", "/authors/lev.jpg", new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5504), "Лев Толстой" }
                });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "CreatedAt", "Label", "Name", "Unicode" },
                values: new object[,]
                {
                    { new Guid("175600e6-6cd0-479f-8b64-8b4a1ad08ace"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5421), "Ничего не понятно", "confusing", "🙈" },
                    { new Guid("24516925-3420-40ad-aaa5-962b8565df9e"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5434), "Весело", "fun", "😆" },
                    { new Guid("374f3388-ecdc-4773-97b2-d6c7872de12e"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5410), "До слез", "droplet", "💧" },
                    { new Guid("4ea98907-8351-4881-8a7b-48ef8403d2ab"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5403), "Советую", "thumbsup", "👍" },
                    { new Guid("5f3a1238-2a89-434b-8bd2-58d8e3d3ddc8"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5426), "Полезно", "useful", "🎯" },
                    { new Guid("6823a787-5e80-41d8-9e07-baf04d63c8bf"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5432), "Не оторваться", "rocket", "🚀" },
                    { new Guid("74aea603-bfff-44a6-b359-5977c051129d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5418), "Фууу", "shit", "💩" },
                    { new Guid("881fc2bc-7db9-4657-9f08-3b7a20ad2ff5"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5409), "Не советую", "thumbsdown", "👎" },
                    { new Guid("8d43b2f9-8725-405e-972a-ee75b782e055"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5431), "В отпуск", "palm_tree", "🏝" },
                    { new Guid("a9dc7e29-7cef-456a-b4ca-030c100b31c7"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5429), "Романтично", "romantic", "💞" },
                    { new Guid("b22e3a22-b3cf-43ec-9e85-ac97d9097b38"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5425), "Познавательно", "bulb", "💡" },
                    { new Guid("c9eb2503-a063-4e19-bb78-1b9ee7f161e1"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5419), "Страшно", "skull", "💀" },
                    { new Guid("d7edc1e8-9338-4d7d-8e49-749af84eb83a"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5422), "Мудро", "wise", "🔮" },
                    { new Guid("d944b372-78bf-47c3-9582-c2fa83c4720d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5414), "Мило", "panda_face", "🐼" },
                    { new Guid("fffa75bc-879a-490d-9a35-c1573ec73d1a"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5415), "Скучно", "zzz", "😴" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5207), "Нон-фикшн" },
                    { new Guid("36638e3f-0125-45a5-b319-5168f5204bd6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5218), "Хорроры" },
                    { new Guid("5267e8c7-a191-417c-93ac-287800972997"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5219), "Здоровье" },
                    { new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5217), "Триллеры" },
                    { new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5206), "Саморазвитие" },
                    { new Guid("8621520d-751d-453e-a5b8-f159806b3cd6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5213), "Young Adult" },
                    { new Guid("a7dcde27-4593-4678-b41d-035ac02b50da"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5214), "Фантастика" },
                    { new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5216), "Мемуары" },
                    { new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5209), "Проза" },
                    { new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5211), "Детективы" },
                    { new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5203), "Психология" },
                    { new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5212), "Бизнес" },
                    { new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5208), "Романтика" },
                    { new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5215), "Фэнтези" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { new Guid("6ed817db-645d-4fbd-96bc-6984049758d4"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5478), "ashot.svazyan@yandex.ru", "Ашот", "Свазян", "$2a$11$6gNRPxWDFoeAaYcCPIvlHunXNKDIjStIjcuxHMJr8dWanHgNVBbq6", "+79097677217", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Age", "AuthorId", "CreatedAt", "Description", "FilePath", "Holder", "ImagePath", "Pages", "Publisher", "Title", "Translator", "UserId" },
                values: new object[,]
                {
                    { new Guid("04e03ada-0b50-4ed1-a28c-d85f42562964"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4983), "Описание книги Дочь священника", "/books/book.pdf", "Лев Толстой", "/books/doch.jpg", 252, "Издательство АСТ", "Дочь священника", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("116972fc-5026-4fac-a495-4407122faa80"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4817), "Описание книги Тень над Иннсмутом", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/innsmouth.jpg", 279, "Издательство АСТ", "Тень над Иннсмутом", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("12c6d34b-ec89-40eb-8024-b35a05967932"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4887), "Описание книги Природа Средиземья", "/books/book.pdf", "Джордж Оруэлл", "/books/prid.jpg", 207, "Издательство АСТ", "Природа Средиземья", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("139c4188-c913-4765-ba68-f73a14b5eeea"), 16, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4850), "Описание книги Некрономикон", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/nekro.jpg", 298, "Издательство АСТ", "Некрономикон", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("20de4cde-1e7c-43c3-b2ef-59c61bc2cf6c"), 16, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4724), "Описание книги Сезон гроз", "/books/book.pdf", "Анджей Сапковский", "/books/sezon.jpg", 123, "Издательство АСТ", "Сезон гроз", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2282bd75-9ecb-41da-bf2c-59926b58d0cd"), 16, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5161), "Описание книги Врата космоса", "/books/book.pdf", "Аркадий Стругацкий", "/books/kos.jpg", 162, "Издательство АСТ", "Врата космоса", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("22df7911-938c-4cee-a752-28842e00f807"), 16, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5176), "Описание книги Экспедиция в преисподнюю", "/books/book.pdf", "Аркадий Стругацкий", "/books/spes.jpg", 277, "Издательство АСТ", "Экспедиция в преисподнюю", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2a41bb0c-b824-4c8b-9d4e-8761e1d19c08"), 12, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4696), "Описание книги Час презрения", "/books/book.pdf", "Анджей Сапковский", "/books/hour.jpg", 222, "Издательство АСТ", "Час презрения", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2aad24ba-f40c-4b17-8093-5c655d22b87c"), 16, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4652), "Описание книги Меч Предназначения", "/books/book.pdf", "Анджей Сапковский", "/books/sword.jpg", 125, "Издательство АСТ", "Меч Предназначения", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2d568103-41a8-4739-95e5-b3582827f56e"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5153), "Описание книги Трудно быть богом", "/books/book.pdf", "Аркадий Стругацкий", "/books/god.jpg", 200, "Издательство АСТ", "Трудно быть богом", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2e122ce9-98b8-405b-aedc-633467b59d3f"), 12, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4975), "Описание книги Скотный двор", "/books/book.pdf", "Лев Толстой", "/books/skot.jpg", 259, "Издательство АСТ", "Скотный двор", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("30f07986-d5f9-4a3b-a379-b474fd860802"), 12, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4776), "Описание книги Метро 2033: Последнее убежище", "/books/book.pdf", "Дмитрий Глуховский", "/books/lost.jpg", 240, "Издательство АСТ", "Метро 2033: Последнее убежище", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("31be812a-4912-4f87-a8ba-79b9b074c46d"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4990), "Описание книги Дни в Бирме", "/books/book.pdf", "Лев Толстой", "/books/birma.jpg", 278, "Издательство АСТ", "Дни в Бирме", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("3d2335e7-87c8-4eff-9dba-8bf0ab2c67f7"), 18, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4923), "Описание книги Две крепости", "/books/book.pdf", "Джордж Оруэлл", "/books/devk.jpg", 179, "Издательство АСТ", "Две крепости", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("3de850ae-2691-4de0-ba50-00cebc0e098c"), 16, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4732), "Описание книги Владычица озера", "/books/book.pdf", "Анджей Сапковский", "/books/ozero.jpg", 153, "Издательство АСТ", "Владычица озера", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("498bd352-80f0-4127-ad3f-ee8f33855f64"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4895), "Описание книги Две твердыни", "/books/book.pdf", "Джордж Оруэлл", "/books/dvet.jpg", 138, "Издательство АСТ", "Две твердыни", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("52029771-c00c-427c-ac4d-53b6cd3426a5"), 12, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4768), "Описание книги Третий Рим. ВДНХ", "/books/book.pdf", "Дмитрий Глуховский", "/books/rim.jpg", 295, "Издательство АСТ", "Третий Рим. ВДНХ", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("543fdb46-de92-4278-99fa-d3f821593911"), 16, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5096), "Описание книги Хаджи-Мурат", "/books/book.pdf", "Лев Толстой", "/books/murat.jpg", 217, "Издательство АСТ", "Хаджи-Мурат", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("6118162e-5b1c-4646-bc58-166b36a4b613"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4859), "Описание книги Цвет из иных миров", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/chvet.jpg", 272, "Издательство АСТ", "Цвет из иных миров", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("611f08fa-0e78-4cde-a01c-a00307148c51"), 18, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5058), "Описание книги Анна Каренина", "/books/book.pdf", "Лев Толстой", "/books/anna.jpg", 252, "Издательство АСТ", "Анна Каренина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("63145ddd-d3e5-46d8-8117-ea95d45e7b1a"), 16, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4752), "Описание книги Метро 2034", "/books/book.pdf", "Дмитрий Глуховский", "/books/2034.jpg", 293, "Издательство АСТ", "Метро 2034", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("6418a231-5cfc-4728-b2d6-c68e7843b062"), 16, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4686), "Описание книги Кровь эльфов", "/books/book.pdf", "Анджей Сапковский", "/books/blood.jpg", 283, "Издательство АСТ", "Кровь эльфов", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("721bccdf-255b-4eb6-970a-3ec85d8aa667"), 12, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4704), "Описание книги Крещение огнем", "/books/book.pdf", "Анджей Сапковский", "/books/fire.jpg", 159, "Издательство АСТ", "Крещение огнем", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("7254a633-a520-40a3-ab1a-3efd53d6574b"), 16, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4832), "Описание книги Дагон", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/dagon.jpg", 186, "Издательство АСТ", "Дагон", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("7435a598-77ba-4240-9ec3-041edc464cc6"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4932), "Описание книги Дети Хурина", "/books/book.pdf", "Джордж Оруэлл", "/books/child.jpg", 244, "Издательство АСТ", "Дети Хурина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("74e1e7eb-93a6-42e6-af95-4fd307488676"), 12, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5066), "Описание книги Детство", "/books/book.pdf", "Лев Толстой", "/books/det.jpg", 132, "Издательство АСТ", "Детство", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("81a56285-f872-42ab-8a20-0256f35f2d0d"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4967), "Описание книги 1984", "/books/book.pdf", "Лев Толстой", "/books/1984.jpg", 171, "Издательство АСТ", "1984", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("84279083-1fc9-4f8b-9a0a-eea474cc38e1"), 18, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4999), "Описание книги Глотнуть воздуха", "/books/book.pdf", "Лев Толстой", "/books/voz.jpg", 194, "Издательство АСТ", "Глотнуть воздуха", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("8f85b04c-e5c4-4035-980f-cd79decd5201"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4867), "Описание книги Таящийся у порога", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/porog.jpg", 254, "Издательство АСТ", "Таящийся у порога", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("96d5389e-6976-4e2f-9379-de41f0e5f729"), 18, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4742), "Описание книги Метро 2033", "/books/book.pdf", "Дмитрий Глуховский", "/books/2033.jpg", 215, "Издательство АСТ", "Метро 2033", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("9dd98284-745a-430a-a7fa-dd4ad1889cd6"), 16, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5050), "Описание книги Воскресенье", "/books/book.pdf", "Лев Толстой", "/books/vosk.jpg", 289, "Издательство АСТ", "Воскресенье", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("a17da579-a47c-4257-b42d-aec975f733e4"), 12, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5039), "Описание книги Дорога на Уиган-Пирс", "/books/book.pdf", "Лев Толстой", "/books/doroga.jpg", 228, "Издательство АСТ", "Дорога на Уиган-Пирс", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ad523690-0061-4317-9539-e69a0c82a9a0"), 18, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5081), "Описание книги Смерть Ивана Ильича", "/books/book.pdf", "Лев Толстой", "/books/dead.jpg", 185, "Издательство АСТ", "Смерть Ивана Ильича", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("af66c22c-04d9-4c3a-abe1-45064f236f1f"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4879), "Описание книги Сильмариллион", "/books/book.pdf", "Джордж Оруэлл", "/books/sim.jpg", 125, "Издательство АСТ", "Сильмариллион", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("b519dc03-ca6b-4cd4-a713-5a084484ff0b"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4808), "Описание книги Зов Ктулху", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/zov.jpg", 250, "Издательство АСТ", "Зов Ктулху", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("b5257a2c-409f-4792-8183-8f6f7ca81f92"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4948), "Описание книги Властелин колец", "/books/book.pdf", "Джордж Оруэлл", "/books/vlas.jpg", 168, "Издательство АСТ", "Властелин колец", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("bcab2742-ac2e-4759-a525-82ddd9b8461d"), 16, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4760), "Описание книги Метро 2035", "/books/book.pdf", "Дмитрий Глуховский", "/books/2035.jpg", 263, "Издательство АСТ", "Метро 2035", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("bf8f736a-1df8-46ba-a2b7-d92c0d5f596f"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4955), "Описание книги Падение Гондолина", "/books/book.pdf", "Джордж Оруэлл", "/books/gondor.jpg", 222, "Издательство АСТ", "Падение Гондолина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("c19eacf8-1688-4cf7-92d2-ac687b5722bd"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4940), "Описание книги Хоббит", "/books/book.pdf", "Джордж Оруэлл", "/books/xob.jpg", 129, "Издательство АСТ", "Хоббит", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ce21341a-21d9-4f46-a42e-a378188709c9"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4826), "Описание книги Хребты безумия", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/bez.jpg", 211, "Издательство АСТ", "Хребты безумия", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("cec8a85b-589d-42aa-a6a3-c65fd6a04f81"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5030), "Описание книги Фунты лиха в Париже и Лондоне", "/books/book.pdf", "Лев Толстой", "/books/funt.jpg", 281, "Издательство АСТ", "Фунты лиха в Париже и Лондоне", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d1b1fe1b-72c8-4974-abbc-122c1d970b56"), 16, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4842), "Описание книги Шепчущий во тьме", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/vo_tme.jpg", 195, "Издательство АСТ", "Шепчущий во тьме", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d3314f02-ad06-4e11-88b0-e76d45b03d8a"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5124), "Описание книги Забытый эксперимент", "/books/book.pdf", "Аркадий Стругацкий", "/books/zab.jpg", 121, "Издательство АСТ", "Забытый эксперимент", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d53697ba-797f-468f-850e-dadbd54d9004"), 16, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4714), "Описание книги Башня ласточки", "/books/book.pdf", "Анджей Сапковский", "/books/tower.jpg", 190, "Издательство АСТ", "Башня ласточки", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d6dc2c60-1843-4822-a016-eb59dbd24606"), 18, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5089), "Описание книги Крейцерова соната", "/books/book.pdf", "Лев Толстой", "/books/son.jpg", 297, "Издательство АСТ", "Крейцерова соната", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("dafdc96e-59ad-4e6b-aa31-e6643b5b746b"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(4527), "Описание книги Последнее желание", "/books/book.pdf", "Анджей Сапковский", "/books/pos.jpg", 241, "Издательство АСТ", "Последнее желание", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("e0102735-aa39-47fe-9b78-5dae1da09e85"), 18, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5074), "Описание книги Война и мир", "/books/book.pdf", "Лев Толстой", "/books/w.jpg", 259, "Издательство АСТ", "Война и мир", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("e94030bc-2769-431a-83a6-71a24e75631b"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5115), "Описание книги Пикник на обочине", "/books/book.pdf", "Аркадий Стругацкий", "/books/pick.jpg", 276, "Издательство АСТ", "Пикник на обочине", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("e9edb617-2afc-4194-a086-3db471f18b1a"), 18, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5168), "Описание книги Звездолет Астра-12", "/books/book.pdf", "Аркадий Стругацкий", "/books/a12.jpg", 199, "Издательство АСТ", "Звездолет Астра-12", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("f91cc47d-709c-4730-9822-b6883d012bc7"), 12, new Guid("8a0c90e6-7764-4056-ad6e-66bdfb92db5d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5104), "Описание книги Дьявол", "/books/book.pdf", "Лев Толстой", "/books/dia.jpg", 200, "Издательство АСТ", "Дьявол", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Title", "TopicId" },
                values: new object[,]
                {
                    { new Guid("032dfe50-1dfc-40aa-a17b-9415b0e0343c"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5342), "Психологические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("03aa504c-c8c9-45e1-b456-f196834ace41"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5368), "Фитнес", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("06d5f66c-7896-4c24-9843-dba6021b2a64"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5359), "Литературные", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("0f323869-f631-4c91-ba12-c812f8358e92"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5341), "Полицейские", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("139e8271-39bd-48c5-aad2-d62ee20ffaf0"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5303), "Личная эффективность", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("186ac534-4c6e-4c16-9a44-1fa73f8db668"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5308), "Наука", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("1f9bc60a-27a7-426f-88db-3c1341aabc16"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5333), "Любовные романы", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("25b4fe4f-4a30-4fed-a5cd-db7fdab89c8f"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5338), "Классическая", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("2bc30f2b-cba3-453e-839c-24bee14f945d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5364), "Готические", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("2e5cf54d-8717-42b4-8dd3-5e01790daa26"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5357), "Автобиографии", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("3c50913b-a568-4de3-92fd-41577604e70b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5349), "Дружба", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5302), "Когнитивная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("4f9728af-2514-465b-b14c-4153a3e9b624"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5301), "Социальная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("570e742c-fad0-4f6f-a6c9-539897ee17d6"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5307), "История", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("58401406-bca2-4ff4-a77a-ff30d0905535"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5369), "Психосоматика", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5334), "Драма", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("62973166-cc3b-44fd-8bdd-76ac5b1f7922"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5343), "Финансы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("683da31e-af9b-43b7-8654-7da110c19428"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5353), "Эпическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5347), "Фэнтези", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("7b3fe946-dac1-40f9-8828-11b1c1c4ed75"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5338), "Экспериментальная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5335), "Эротика", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5354), "Темное", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("894fcac2-4b8e-40e2-b03d-119d77c3be14"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5346), "Стартапы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5348), "Реализм", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("9a7b6af2-79f3-457d-bbfa-2b6bf5726db4"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5340), "Классические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("9ad32ac1-8e8f-423e-b02d-73ddc353c339"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5365), "Паранормальные", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("9c3405fc-368b-4082-9cee-c02fe6fa87c1"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5358), "Исторические", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("b1d38b75-4f26-482a-b017-b8ee2b838fdc"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5350), "Научная", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("b273dccc-8d62-433e-9d58-e567e373dfa3"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5363), "Психологические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5336), "Современная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5366), "Маньяки", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("bc6fb040-506d-46df-a040-ea370c5ca6b0"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5361), "Политические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("bf17f164-8b99-4973-8fc9-3d10d6ac1609"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5309), "Биографии", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("c0127b2a-777a-44f2-863a-f09b80ebd577"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5362), "Шпионские", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5299), "Клиническая", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("d6d3e8e2-7cb4-44c6-aeb9-3653fb0988cd"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5306), "Навыки общения", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("ddf8c566-a91b-4c83-9f6a-afcbb634f881"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5355), "Мифологическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("dfb76f27-1727-4c03-8886-afd8e80183de"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5351), "Космическая", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("e00dc6e2-efff-4891-aa5e-84dcdbd3dec2"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5304), "Мотивация", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("ebe0653c-b3f7-43d8-a4db-ba8df169936d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5345), "Менеджмент", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("f322cd5d-4841-45ba-845e-90c1a2ff967f"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5367), "Питание", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d"), new DateTime(2025, 3, 16, 16, 37, 1, 831, DateTimeKind.Utc).AddTicks(5352), "Альтернативная история", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("04e03ada-0b50-4ed1-a28c-d85f42562964"), new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1") },
                    { new Guid("116972fc-5026-4fac-a495-4407122faa80"), new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a") },
                    { new Guid("12c6d34b-ec89-40eb-8024-b35a05967932"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("139c4188-c913-4765-ba68-f73a14b5eeea"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("20de4cde-1e7c-43c3-b2ef-59c61bc2cf6c"), new Guid("894fcac2-4b8e-40e2-b03d-119d77c3be14") },
                    { new Guid("2282bd75-9ecb-41da-bf2c-59926b58d0cd"), new Guid("032dfe50-1dfc-40aa-a17b-9415b0e0343c") },
                    { new Guid("22df7911-938c-4cee-a752-28842e00f807"), new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34") },
                    { new Guid("2a41bb0c-b824-4c8b-9d4e-8761e1d19c08"), new Guid("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49") },
                    { new Guid("2aad24ba-f40c-4b17-8093-5c655d22b87c"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("2d568103-41a8-4739-95e5-b3582827f56e"), new Guid("62973166-cc3b-44fd-8bdd-76ac5b1f7922") },
                    { new Guid("2e122ce9-98b8-405b-aedc-633467b59d3f"), new Guid("03aa504c-c8c9-45e1-b456-f196834ace41") },
                    { new Guid("30f07986-d5f9-4a3b-a379-b474fd860802"), new Guid("03aa504c-c8c9-45e1-b456-f196834ace41") },
                    { new Guid("31be812a-4912-4f87-a8ba-79b9b074c46d"), new Guid("58401406-bca2-4ff4-a77a-ff30d0905535") },
                    { new Guid("3d2335e7-87c8-4eff-9dba-8bf0ab2c67f7"), new Guid("2bc30f2b-cba3-453e-839c-24bee14f945d") },
                    { new Guid("3de850ae-2691-4de0-ba50-00cebc0e098c"), new Guid("e00dc6e2-efff-4891-aa5e-84dcdbd3dec2") },
                    { new Guid("498bd352-80f0-4127-ad3f-ee8f33855f64"), new Guid("03aa504c-c8c9-45e1-b456-f196834ace41") },
                    { new Guid("52029771-c00c-427c-ac4d-53b6cd3426a5"), new Guid("dfb76f27-1727-4c03-8886-afd8e80183de") },
                    { new Guid("543fdb46-de92-4278-99fa-d3f821593911"), new Guid("06d5f66c-7896-4c24-9843-dba6021b2a64") },
                    { new Guid("6118162e-5b1c-4646-bc58-166b36a4b613"), new Guid("ddf8c566-a91b-4c83-9f6a-afcbb634f881") },
                    { new Guid("611f08fa-0e78-4cde-a01c-a00307148c51"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("63145ddd-d3e5-46d8-8117-ea95d45e7b1a"), new Guid("bc6fb040-506d-46df-a040-ea370c5ca6b0") },
                    { new Guid("6418a231-5cfc-4728-b2d6-c68e7843b062"), new Guid("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0") },
                    { new Guid("721bccdf-255b-4eb6-970a-3ec85d8aa667"), new Guid("f322cd5d-4841-45ba-845e-90c1a2ff967f") },
                    { new Guid("7254a633-a520-40a3-ab1a-3efd53d6574b"), new Guid("2e5cf54d-8717-42b4-8dd3-5e01790daa26") },
                    { new Guid("7435a598-77ba-4240-9ec3-041edc464cc6"), new Guid("9ad32ac1-8e8f-423e-b02d-73ddc353c339") },
                    { new Guid("74e1e7eb-93a6-42e6-af95-4fd307488676"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("81a56285-f872-42ab-8a20-0256f35f2d0d"), new Guid("d6d3e8e2-7cb4-44c6-aeb9-3653fb0988cd") },
                    { new Guid("84279083-1fc9-4f8b-9a0a-eea474cc38e1"), new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d") },
                    { new Guid("8f85b04c-e5c4-4035-980f-cd79decd5201"), new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1") },
                    { new Guid("96d5389e-6976-4e2f-9379-de41f0e5f729"), new Guid("1f9bc60a-27a7-426f-88db-3c1341aabc16") },
                    { new Guid("9dd98284-745a-430a-a7fa-dd4ad1889cd6"), new Guid("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49") },
                    { new Guid("a17da579-a47c-4257-b42d-aec975f733e4"), new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d") },
                    { new Guid("ad523690-0061-4317-9539-e69a0c82a9a0"), new Guid("683da31e-af9b-43b7-8654-7da110c19428") },
                    { new Guid("af66c22c-04d9-4c3a-abe1-45064f236f1f"), new Guid("b1d38b75-4f26-482a-b017-b8ee2b838fdc") },
                    { new Guid("b519dc03-ca6b-4cd4-a713-5a084484ff0b"), new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34") },
                    { new Guid("b5257a2c-409f-4792-8183-8f6f7ca81f92"), new Guid("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b") },
                    { new Guid("bcab2742-ac2e-4759-a525-82ddd9b8461d"), new Guid("186ac534-4c6e-4c16-9a44-1fa73f8db668") },
                    { new Guid("bf8f736a-1df8-46ba-a2b7-d92c0d5f596f"), new Guid("570e742c-fad0-4f6f-a6c9-539897ee17d6") },
                    { new Guid("c19eacf8-1688-4cf7-92d2-ac687b5722bd"), new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d") },
                    { new Guid("ce21341a-21d9-4f46-a42e-a378188709c9"), new Guid("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0") },
                    { new Guid("cec8a85b-589d-42aa-a6a3-c65fd6a04f81"), new Guid("894fcac2-4b8e-40e2-b03d-119d77c3be14") },
                    { new Guid("d1b1fe1b-72c8-4974-abbc-122c1d970b56"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("d3314f02-ad06-4e11-88b0-e76d45b03d8a"), new Guid("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47") },
                    { new Guid("d53697ba-797f-468f-850e-dadbd54d9004"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("d6dc2c60-1843-4822-a016-eb59dbd24606"), new Guid("570e742c-fad0-4f6f-a6c9-539897ee17d6") },
                    { new Guid("dafdc96e-59ad-4e6b-aa31-e6643b5b746b"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("e0102735-aa39-47fe-9b78-5dae1da09e85"), new Guid("9a7b6af2-79f3-457d-bbfa-2b6bf5726db4") },
                    { new Guid("e94030bc-2769-431a-83a6-71a24e75631b"), new Guid("139e8271-39bd-48c5-aad2-d62ee20ffaf0") },
                    { new Guid("e9edb617-2afc-4194-a086-3db471f18b1a"), new Guid("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b") },
                    { new Guid("f91cc47d-709c-4730-9822-b6883d012bc7"), new Guid("683da31e-af9b-43b7-8654-7da110c19428") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FullName",
                table: "Authors",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

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
                name: "BookCategory");

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
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
