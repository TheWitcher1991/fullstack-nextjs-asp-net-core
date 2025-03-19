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
                    { new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), "Американский писатель, работавший в жанрах литературы ужасов, мистики и научной фантастики и, на их основе создавший узнаваемый стиль «лавкрафтовского хоррора».", "/authors/gov.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3062), "Говард Филлипс Лавкрафт" },
                    { new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), "Анджей Сапковский (1948) — польский писатель-фантаст, автор фэнтези-цикла о ведьмаке, лауреат множества литературных премий, второй самый печатаемый польский автор в мире после Станислава Лема.", "/authors/sab.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3059), "Анджей Сапковский" },
                    { new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), "Всемирно известный английский писатель, лингвист, профессор Оксфордского университета и один из основателей «высокого фэнтези» Джон Рональд Руэл Толкин родился в 1892 году в Блумфонтейне, Оранжевая республика (сейчас ЮАР). В Англию будущий писатель с мамой и братом переехал четыре года спустя.", "/authors/tol.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3063), "Джон Рональд Руэл Толкин" },
                    { new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), "Советский и российский писатель-фантаст, представитель поджанра твердой научной фантастики, работавший в писательском тандеме со своим братом — Борисом Стругацким.", "/authors/str.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3068), "Аркадий Стругацкий" },
                    { new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), "Английский писатель, автор сатирической повести «Скотный двор» и романа-антиутопии «1984», журналист и общественный деятель. Имя при рождении — Эрик Артур Блэр.", "/authors/ou.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3064), "Джордж Оруэлл" },
                    { new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), "Дмитрий Глуховский (1979 г. р.) — российский писатель. С момента окончания университета профессия Дмитрия Глуховского — журналист. Работал на телевидении, радио, в печатных СМИ. Автор фантастического романа «Метро 2033», переведенного на 37 языков.", "/authors/dgx.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3061), "Дмитрий Глуховский" },
                    { new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), "Лев Толстой — русский писатель. Родился и провел детство в семейном имении Ясная Поляна. Поступил в университет, но, не окончив его, вернулся домой, чтобы заниматься делами поместья.", "/authors/lev.jpg", new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3067), "Лев Толстой" }
                });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "CreatedAt", "Label", "Name", "Unicode" },
                values: new object[,]
                {
                    { new Guid("06b43cb1-d2a4-4e9c-b612-1d8772937310"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2954), "Советую", "thumbsup", "👍" },
                    { new Guid("14800e38-544a-4bb2-b4eb-57a9281e7d94"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2958), "Не советую", "thumbsdown", "👎" },
                    { new Guid("1a5c4a64-0eb6-4d73-830c-6ffb3f3b8236"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2971), "Мудро", "wise", "🔮" },
                    { new Guid("2bc12c26-db03-4f6d-bcda-3e4f25c8adce"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2974), "Познавательно", "bulb", "💡" },
                    { new Guid("3652ba88-f951-4f72-99ca-76f4cade3970"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2961), "Мило", "panda_face", "🐼" },
                    { new Guid("3a6a538e-1c2e-430a-8c30-8beb30fbb523"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2980), "В отпуск", "palm_tree", "🏝" },
                    { new Guid("4cd4a96e-5131-45d1-a6f3-684ca1711d52"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2975), "Полезно", "useful", "🎯" },
                    { new Guid("6960514b-1eb0-46c3-9a89-ef6a1b174f9f"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2969), "Страшно", "skull", "💀" },
                    { new Guid("6db43637-8992-451e-8572-7de1284ccae5"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2970), "Ничего не понятно", "confusing", "🙈" },
                    { new Guid("7c75a8cf-2b3f-4c2b-b67d-353d445eaf7b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2967), "Фууу", "shit", "💩" },
                    { new Guid("8b4897a2-de3e-40f3-aa45-1ac0ed29b703"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2960), "До слез", "droplet", "💧" },
                    { new Guid("973cb1ef-b36c-47ba-a662-4f44c62c167c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2965), "Скучно", "zzz", "😴" },
                    { new Guid("9d6f2c24-9adf-41ec-94ef-b235e5e5db5e"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2981), "Не оторваться", "rocket", "🚀" },
                    { new Guid("e254cd48-ee0b-4842-9d18-4ee9fffa84f9"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2977), "Романтично", "romantic", "💞" },
                    { new Guid("f4dad843-ab39-4429-97c5-34d6d89bccfc"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2983), "Весело", "fun", "😆" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2735), "Нон-фикшн" },
                    { new Guid("36638e3f-0125-45a5-b319-5168f5204bd6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2747), "Хорроры" },
                    { new Guid("5267e8c7-a191-417c-93ac-287800972997"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2748), "Здоровье" },
                    { new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2746), "Триллеры" },
                    { new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2734), "Саморазвитие" },
                    { new Guid("8621520d-751d-453e-a5b8-f159806b3cd6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2742), "Young Adult" },
                    { new Guid("a7dcde27-4593-4678-b41d-035ac02b50da"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2742), "Фантастика" },
                    { new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2745), "Мемуары" },
                    { new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2738), "Проза" },
                    { new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2739), "Детективы" },
                    { new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2730), "Психология" },
                    { new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2740), "Бизнес" },
                    { new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2736), "Романтика" },
                    { new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2744), "Фэнтези" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { new Guid("6ed817db-645d-4fbd-96bc-6984049758d4"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(3040), "ashot.svazyan@yandex.ru", "Ашот", "Свазян", "$2a$11$6gNRPxWDFoeAaYcCPIvlHunXNKDIjStIjcuxHMJr8dWanHgNVBbq6", "+79097677217", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Age", "AuthorId", "CreatedAt", "Description", "FilePath", "Holder", "ImagePath", "Pages", "Publisher", "Title", "Translator", "UserId" },
                values: new object[,]
                {
                    { new Guid("00678ece-59e1-4e7f-9cfd-d19c45130d99"), 18, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2607), "Описание книги Хаджи-Мурат", "/books/book.pdf", "Лев Толстой", "/books/murat.jpg", 200, "Издательство АСТ", "Хаджи-Мурат", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("01aa3cf2-2090-4bd6-ab93-786888651876"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2681), "Описание книги Врата космоса", "/books/book.pdf", "Аркадий Стругацкий", "/books/kos.jpg", 146, "Издательство АСТ", "Врата космоса", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("0e457d1b-3952-4a32-8780-faf164afc83d"), 12, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2411), "Описание книги Две твердыни", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/dvet.jpg", 138, "Издательство АСТ", "Две твердыни", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("0e48b620-ba35-4932-a0c1-cf5dcea04c78"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2591), "Описание книги Смерть Ивана Ильича", "/books/book.pdf", "Лев Толстой", "/books/dead.jpg", 251, "Издательство АСТ", "Смерть Ивана Ильича", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("164773bd-5316-4002-9175-af6444535625"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2473), "Описание книги Скотный двор", "/books/book.pdf", "Джордж Оруэлл", "/books/skot.jpg", 139, "Издательство АСТ", "Скотный двор", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("18b07de6-9764-4ae5-b87c-7a4c625c396c"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2674), "Описание книги Трудно быть богом", "/books/book.pdf", "Аркадий Стругацкий", "/books/god.jpg", 270, "Издательство АСТ", "Трудно быть богом", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("190406b9-8e76-416f-ae8f-e1d62b3c33eb"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2568), "Описание книги Анна Каренина", "/books/book.pdf", "Лев Толстой", "/books/anna.jpg", 285, "Издательство АСТ", "Анна Каренина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("218a414f-f24e-4f26-a7ab-05544af3a7ae"), 16, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2372), "Описание книги Природа Средиземья", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/prid.jpg", 204, "Издательство АСТ", "Природа Средиземья", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("282cbc1d-f432-43cf-8514-5191a2cabe6f"), 16, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2665), "Описание книги Забытый эксперимент", "/books/book.pdf", "Аркадий Стругацкий", "/books/zab.jpg", 180, "Издательство АСТ", "Забытый эксперимент", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("29c0bf75-4ba3-4832-abf4-f87fb23647c2"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2173), "Описание книги Владычица озера", "/books/book.pdf", "Анджей Сапковский", "/books/ozero.jpg", 218, "Издательство АСТ", "Владычица озера", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2a2811d1-ae1c-4cae-acba-b6af46f799d4"), 16, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2195), "Описание книги Метро 2034", "/books/book.pdf", "Дмитрий Глуховский", "/books/2034.jpg", 152, "Издательство АСТ", "Метро 2034", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("2af3fab8-06b5-4d79-b019-740f9da377a1"), 18, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2364), "Описание книги Сильмариллион", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/sim.jpg", 193, "Издательство АСТ", "Сильмариллион", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("335944ac-f21e-4273-ac29-00a043dc8bae"), 12, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2158), "Описание книги Башня ласточки", "/books/book.pdf", "Анджей Сапковский", "/books/tower.jpg", 275, "Издательство АСТ", "Башня ласточки", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("39683d3f-123f-4773-8c54-039d102bdc17"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2327), "Описание книги Шепчущий во тьме", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/vo_tme.jpg", 241, "Издательство АСТ", "Шепчущий во тьме", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("39af8db5-558c-43f8-8839-dfdf8f57a534"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2080), "Описание книги Меч Предназначения", "/books/book.pdf", "Анджей Сапковский", "/books/sword.jpg", 229, "Издательство АСТ", "Меч Предназначения", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("39b5bab8-95c6-4294-91c7-6c7e4c6e2c85"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2599), "Описание книги Крейцерова соната", "/books/book.pdf", "Лев Толстой", "/books/son.jpg", 251, "Издательство АСТ", "Крейцерова соната", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("421c46e1-1a5e-4f20-b621-d282215ffe34"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2302), "Описание книги Тень над Иннсмутом", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/innsmouth.jpg", 293, "Издательство АСТ", "Тень над Иннсмутом", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("4290135e-6fc0-4843-9d81-7ab25acc73b8"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2480), "Описание книги Дочь священника", "/books/book.pdf", "Джордж Оруэлл", "/books/doch.jpg", 229, "Издательство АСТ", "Дочь священника", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("4867a0c1-90bf-4726-a4b3-ea07fe10a269"), 12, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2139), "Описание книги Час презрения", "/books/book.pdf", "Анджей Сапковский", "/books/hour.jpg", 254, "Издательство АСТ", "Час презрения", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("4c63119e-1851-4d67-99b1-83c4a16f5ce2"), 18, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2538), "Описание книги Фунты лиха в Париже и Лондоне", "/books/book.pdf", "Джордж Оруэлл", "/books/funt.jpg", 198, "Издательство АСТ", "Фунты лиха в Париже и Лондоне", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("504eee5e-620e-4796-8ae3-8a5c0c3c3c0b"), 18, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2212), "Описание книги Третий Рим. ВДНХ", "/books/book.pdf", "Дмитрий Глуховский", "/books/rim.jpg", 121, "Издательство АСТ", "Третий Рим. ВДНХ", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("58250e62-7b34-4ebd-b568-2d537d4a606d"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2344), "Описание книги Цвет из иных миров", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/chvet.jpg", 258, "Издательство АСТ", "Цвет из иных миров", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("5956896d-c6bc-4e62-9611-028396c2f5cc"), 12, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2420), "Описание книги Две крепости", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/devk.jpg", 213, "Издательство АСТ", "Две крепости", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("598725f9-7f26-4866-9d7c-766a997dbbd3"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2488), "Описание книги Дни в Бирме", "/books/book.pdf", "Джордж Оруэлл", "/books/birma.jpg", 132, "Издательство АСТ", "Дни в Бирме", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("5a053913-6732-422a-97ec-630f26d84d8a"), 18, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2453), "Описание книги Падение Гондолина", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/gondor.jpg", 230, "Издательство АСТ", "Падение Гондолина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("5ff8ea50-027b-4b8c-ac23-f0df2f91458f"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2293), "Описание книги Зов Ктулху", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/zov.jpg", 283, "Издательство АСТ", "Зов Ктулху", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("65e8d540-8795-4fe1-83d0-cc14fdb20aa2"), 16, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2627), "Описание книги Пикник на обочине", "/books/book.pdf", "Аркадий Стругацкий", "/books/pick.jpeg", 300, "Издательство АСТ", "Пикник на обочине", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("6e1024c0-352d-42ab-8ea5-57973cb336b1"), 18, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2220), "Описание книги Метро 2033: Последнее убежище", "/books/book.pdf", "Дмитрий Глуховский", "/books/lost.jpg", 278, "Издательство АСТ", "Метро 2033: Последнее убежище", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("7e8fdd65-1980-4b4b-ad18-3e70da3b6472"), 16, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2428), "Описание книги Дети Хурина", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/child.jpg", 195, "Издательство АСТ", "Дети Хурина", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("81284b82-2737-44c1-98c6-15e827626a39"), 12, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2184), "Описание книги Метро 2033", "/books/book.pdf", "Дмитрий Глуховский", "/books/2033.jpg", 226, "Издательство АСТ", "Метро 2033", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("897852d2-376b-4f27-9140-8cef7e419073"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2353), "Описание книги Таящийся у порога", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/porog.jpg", 194, "Издательство АСТ", "Таящийся у порога", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("8aa96a8d-a5ce-41d9-92c1-a16f19d39013"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2147), "Описание книги Крещение огнем", "/books/book.pdf", "Анджей Сапковский", "/books/fire.jpg", 175, "Издательство АСТ", "Крещение огнем", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("8f54e644-87ff-43ef-9827-4716a375237f"), 12, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2583), "Описание книги Война и мир", "/books/book.pdf", "Лев Толстой", "/books/w.jpg", 299, "Издательство АСТ", "Война и мир", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("9f55769b-d83b-4c6c-afdb-aad638c999e6"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(1963), "Описание книги Последнее желание", "/books/book.pdf", "Анджей Сапковский", "/books/pos.jpg", 151, "Издательство АСТ", "Последнее желание", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("a9e7c048-6757-41dc-81da-098f4923831e"), 12, new Guid("c9a19a03-c71b-47d1-82e5-fd0e0ff43889"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2203), "Описание книги Метро 2035", "/books/book.pdf", "Дмитрий Глуховский", "/books/2035.jpg", 202, "Издательство АСТ", "Метро 2035", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ab4f8d98-25b2-40c3-92f6-1277651ecc28"), 16, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2498), "Описание книги Глотнуть воздуха", "/books/book.pdf", "Джордж Оруэлл", "/books/voz.jpg", 126, "Издательство АСТ", "Глотнуть воздуха", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("b5bcb777-e992-41e4-ae33-4912f9910366"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2697), "Описание книги Экспедиция в преисподнюю", "/books/book.pdf", "Аркадий Стругацкий", "/books/spes.jpg", 121, "Издательство АСТ", "Экспедиция в преисподнюю", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("b814b9fa-ba14-40da-aeef-d35ba6bbf63f"), 18, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2615), "Описание книги Дьявол", "/books/book.pdf", "Лев Толстой", "/books/dia.jpg", 188, "Издательство АСТ", "Дьявол", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ba8cf2ab-16ca-4112-99c4-2505981781a2"), 12, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2437), "Описание книги Хоббит", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/xob.jpg", 259, "Издательство АСТ", "Хоббит", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("c384c852-de4f-4890-9bbd-986c689b5864"), 18, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2166), "Описание книги Сезон гроз", "/books/book.pdf", "Анджей Сапковский", "/books/sezon.jpg", 148, "Издательство АСТ", "Сезон гроз", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("c5bb3d53-3225-4cd4-ba80-b11d17fcecb9"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2316), "Описание книги Дагон", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/dagon.jpg", 263, "Издательство АСТ", "Дагон", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("c674980f-dd11-48e8-9f35-f0cb0d4cdf0d"), 12, new Guid("162cb5f4-36bd-4c2a-aef0-971742f5f0b6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2127), "Описание книги Кровь эльфов", "/books/book.pdf", "Анджей Сапковский", "/books/blood.jpg", 266, "Издательство АСТ", "Кровь эльфов", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("cd45eb70-ffbf-4e73-971f-60f915027c5b"), 12, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2576), "Описание книги Детство", "/books/book.pdf", "Лев Толстой", "/books/det.jpg", 190, "Издательство АСТ", "Детство", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("cd709e9b-d652-40ea-84d8-9e1b39933ed4"), 18, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2308), "Описание книги Хребты безумия", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/bez.jpg", 248, "Издательство АСТ", "Хребты безумия", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d257d6aa-66cf-48fa-8ced-3e35b6ec6ad8"), 18, new Guid("1b5121c4-fe52-4d22-80f1-2625c00fc484"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2445), "Описание книги Властелин колец", "/books/book.pdf", "Джон Рональд Руэл Толкин", "/books/vlas.jpg", 266, "Издательство АСТ", "Властелин колец", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d3b81956-572d-47c1-896d-e5838acd52ff"), 12, new Guid("2bfbfe36-e5e2-49f3-ac06-88a8ba589560"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2689), "Описание книги Звездолет Астра-12", "/books/book.pdf", "Аркадий Стругацкий", "/books/a12.jpg", 247, "Издательство АСТ", "Звездолет Астра-12", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("d813e7bc-68c2-4e66-b25c-6438cba717e5"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2547), "Описание книги Дорога на Уиган-Пирс", "/books/book.pdf", "Джордж Оруэлл", "/books/doroga.jpg", 206, "Издательство АСТ", "Дорога на Уиган-Пирс", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ea50e545-e10a-45b5-a028-2256887ec300"), 16, new Guid("dc16ebbf-5dc6-4491-9b0e-abfe79657fca"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2558), "Описание книги Воскресенье", "/books/book.pdf", "Лев Толстой", "/books/vosk.jpg", 223, "Издательство АСТ", "Воскресенье", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("ed0c503e-0d74-4113-8363-bb03187927e7"), 12, new Guid("4cc8c804-88ab-43da-b9b7-a2eaadb6786b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2465), "Описание книги 1984", "/books/book.pdf", "Джордж Оруэлл", "/books/1984.jpg", 150, "Издательство АСТ", "1984", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") },
                    { new Guid("f0cf92a1-4fd2-4b2c-8535-2833d77b8059"), 12, new Guid("0bc9f987-bebf-472a-8efc-3a9477ee9e2c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2336), "Описание книги Некрономикон", "/books/book.pdf", "Говард Филлипс Лавкрафт", "/books/nekro.jpg", 132, "Издательство АСТ", "Некрономикон", "Костина Анна", new Guid("6ed817db-645d-4fbd-96bc-6984049758d4") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Title", "TopicId" },
                values: new object[,]
                {
                    { new Guid("032dfe50-1dfc-40aa-a17b-9415b0e0343c"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2891), "Психологические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("03aa504c-c8c9-45e1-b456-f196834ace41"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2916), "Фитнес", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("06d5f66c-7896-4c24-9843-dba6021b2a64"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2907), "Литературные", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("0f323869-f631-4c91-ba12-c812f8358e92"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2889), "Полицейские", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("139e8271-39bd-48c5-aad2-d62ee20ffaf0"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2838), "Личная эффективность", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("186ac534-4c6e-4c16-9a44-1fa73f8db668"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2880), "Наука", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("1f9bc60a-27a7-426f-88db-3c1341aabc16"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2883), "Любовные романы", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("25b4fe4f-4a30-4fed-a5cd-db7fdab89c8f"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2886), "Классическая", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("2bc30f2b-cba3-453e-839c-24bee14f945d"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2912), "Готические", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("2e5cf54d-8717-42b4-8dd3-5e01790daa26"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2905), "Автобиографии", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("3c50913b-a568-4de3-92fd-41577604e70b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2897), "Дружба", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2837), "Когнитивная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("4f9728af-2514-465b-b14c-4153a3e9b624"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2836), "Социальная", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("570e742c-fad0-4f6f-a6c9-539897ee17d6"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2878), "История", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("58401406-bca2-4ff4-a77a-ff30d0905535"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2917), "Психосоматика", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2884), "Драма", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("62973166-cc3b-44fd-8bdd-76ac5b1f7922"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2892), "Финансы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("683da31e-af9b-43b7-8654-7da110c19428"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2902), "Эпическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2895), "Фэнтези", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("7b3fe946-dac1-40f9-8828-11b1c1c4ed75"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2888), "Экспериментальная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2884), "Эротика", new Guid("d8401754-a668-4dfb-bf8f-4285b09f2ae2") },
                    { new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2903), "Темное", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("894fcac2-4b8e-40e2-b03d-119d77c3be14"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2894), "Стартапы", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2896), "Реализм", new Guid("8621520d-751d-453e-a5b8-f159806b3cd6") },
                    { new Guid("9a7b6af2-79f3-457d-bbfa-2b6bf5726db4"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2888), "Классические", new Guid("bd922041-23f5-4ad2-8ad3-9619acd1987d") },
                    { new Guid("9ad32ac1-8e8f-423e-b02d-73ddc353c339"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2913), "Паранормальные", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("9c3405fc-368b-4082-9cee-c02fe6fa87c1"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2906), "Исторические", new Guid("a93cc00e-9698-4b25-8af2-2be8c1419d02") },
                    { new Guid("b1d38b75-4f26-482a-b017-b8ee2b838fdc"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2898), "Научная", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("b273dccc-8d62-433e-9d58-e567e373dfa3"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2911), "Психологические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2885), "Современная", new Guid("bbc92f51-4ce7-4951-930b-25c81a077fb1") },
                    { new Guid("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2914), "Маньяки", new Guid("36638e3f-0125-45a5-b319-5168f5204bd6") },
                    { new Guid("bc6fb040-506d-46df-a040-ea370c5ca6b0"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2909), "Политические", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("bf17f164-8b99-4973-8fc9-3d10d6ac1609"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2881), "Биографии", new Guid("2423895f-d942-43c9-a9e6-0780cc8e951f") },
                    { new Guid("c0127b2a-777a-44f2-863a-f09b80ebd577"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2910), "Шпионские", new Guid("6e2f95ea-1f6e-4a4c-9426-0163d8fe96b6") },
                    { new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2834), "Клиническая", new Guid("ceaae55b-1d51-45b5-8a9b-10a4b20720ab") },
                    { new Guid("d6d3e8e2-7cb4-44c6-aeb9-3653fb0988cd"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2841), "Навыки общения", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("ddf8c566-a91b-4c83-9f6a-afcbb634f881"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2904), "Мифологическое", new Guid("ec548451-9cf2-4a7c-aaa3-3c45a5bc556a") },
                    { new Guid("dfb76f27-1727-4c03-8886-afd8e80183de"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2899), "Космическая", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") },
                    { new Guid("e00dc6e2-efff-4891-aa5e-84dcdbd3dec2"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2839), "Мотивация", new Guid("77a24f9e-92cb-47ea-9081-20e304d0c265") },
                    { new Guid("ebe0653c-b3f7-43d8-a4db-ba8df169936d"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2893), "Менеджмент", new Guid("d0698f7c-bfef-4f30-a207-8ffb81aa9c99") },
                    { new Guid("f322cd5d-4841-45ba-845e-90c1a2ff967f"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2915), "Питание", new Guid("5267e8c7-a191-417c-93ac-287800972997") },
                    { new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d"), new DateTime(2025, 3, 19, 7, 51, 0, 579, DateTimeKind.Utc).AddTicks(2900), "Альтернативная история", new Guid("a7dcde27-4593-4678-b41d-035ac02b50da") }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00678ece-59e1-4e7f-9cfd-d19c45130d99"), new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34") },
                    { new Guid("01aa3cf2-2090-4bd6-ab93-786888651876"), new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34") },
                    { new Guid("0e457d1b-3952-4a32-8780-faf164afc83d"), new Guid("b8b69d68-d0b8-4e2f-96ca-7ca2f715b52b") },
                    { new Guid("0e48b620-ba35-4932-a0c1-cf5dcea04c78"), new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a") },
                    { new Guid("164773bd-5316-4002-9175-af6444535625"), new Guid("1f9bc60a-27a7-426f-88db-3c1341aabc16") },
                    { new Guid("18b07de6-9764-4ae5-b87c-7a4c625c396c"), new Guid("b273dccc-8d62-433e-9d58-e567e373dfa3") },
                    { new Guid("190406b9-8e76-416f-ae8f-e1d62b3c33eb"), new Guid("186ac534-4c6e-4c16-9a44-1fa73f8db668") },
                    { new Guid("218a414f-f24e-4f26-a7ab-05544af3a7ae"), new Guid("3c50913b-a568-4de3-92fd-41577604e70b") },
                    { new Guid("282cbc1d-f432-43cf-8514-5191a2cabe6f"), new Guid("03aa504c-c8c9-45e1-b456-f196834ace41") },
                    { new Guid("29c0bf75-4ba3-4832-abf4-f87fb23647c2"), new Guid("9c3405fc-368b-4082-9cee-c02fe6fa87c1") },
                    { new Guid("2a2811d1-ae1c-4cae-acba-b6af46f799d4"), new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1") },
                    { new Guid("2af3fab8-06b5-4d79-b019-740f9da377a1"), new Guid("139e8271-39bd-48c5-aad2-d62ee20ffaf0") },
                    { new Guid("335944ac-f21e-4273-ac29-00a043dc8bae"), new Guid("bc6fb040-506d-46df-a040-ea370c5ca6b0") },
                    { new Guid("39683d3f-123f-4773-8c54-039d102bdc17"), new Guid("5bafd2c6-d952-46b2-9ae6-508d4c9de2f0") },
                    { new Guid("39af8db5-558c-43f8-8839-dfdf8f57a534"), new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a") },
                    { new Guid("39b5bab8-95c6-4294-91c7-6c7e4c6e2c85"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("421c46e1-1a5e-4f20-b621-d282215ffe34"), new Guid("bf17f164-8b99-4973-8fc9-3d10d6ac1609") },
                    { new Guid("4290135e-6fc0-4843-9d81-7ab25acc73b8"), new Guid("c0127b2a-777a-44f2-863a-f09b80ebd577") },
                    { new Guid("4867a0c1-90bf-4726-a4b3-ea07fe10a269"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("4c63119e-1851-4d67-99b1-83c4a16f5ce2"), new Guid("7b3fe946-dac1-40f9-8828-11b1c1c4ed75") },
                    { new Guid("504eee5e-620e-4796-8ae3-8a5c0c3c3c0b"), new Guid("bf17f164-8b99-4973-8fc9-3d10d6ac1609") },
                    { new Guid("58250e62-7b34-4ebd-b568-2d537d4a606d"), new Guid("139e8271-39bd-48c5-aad2-d62ee20ffaf0") },
                    { new Guid("5956896d-c6bc-4e62-9611-028396c2f5cc"), new Guid("7f05a0db-dd14-4df2-a6ef-ba0ccb99de49") },
                    { new Guid("598725f9-7f26-4866-9d7c-766a997dbbd3"), new Guid("8e637311-c3f4-4e5b-82fc-0a1a0d3a6bb1") },
                    { new Guid("5a053913-6732-422a-97ec-630f26d84d8a"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("5ff8ea50-027b-4b8c-ac23-f0df2f91458f"), new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a") },
                    { new Guid("65e8d540-8795-4fe1-83d0-cc14fdb20aa2"), new Guid("032dfe50-1dfc-40aa-a17b-9415b0e0343c") },
                    { new Guid("6e1024c0-352d-42ab-8ea5-57973cb336b1"), new Guid("3c50913b-a568-4de3-92fd-41577604e70b") },
                    { new Guid("7e8fdd65-1980-4b4b-ad18-3e70da3b6472"), new Guid("1f9bc60a-27a7-426f-88db-3c1341aabc16") },
                    { new Guid("81284b82-2737-44c1-98c6-15e827626a39"), new Guid("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47") },
                    { new Guid("897852d2-376b-4f27-9140-8cef7e419073"), new Guid("7f3af4af-f1cc-48cd-a53f-87c69c6bfc34") },
                    { new Guid("8aa96a8d-a5ce-41d9-92c1-a16f19d39013"), new Guid("b3a7ee49-0c15-4c26-b0a5-63d03d5e1c47") },
                    { new Guid("8f54e644-87ff-43ef-9827-4716a375237f"), new Guid("683da31e-af9b-43b7-8654-7da110c19428") },
                    { new Guid("9f55769b-d83b-4c6c-afdb-aad638c999e6"), new Guid("ddf8c566-a91b-4c83-9f6a-afcbb634f881") },
                    { new Guid("a9e7c048-6757-41dc-81da-098f4923831e"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("ab4f8d98-25b2-40c3-92f6-1277651ecc28"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("b5bcb777-e992-41e4-ae33-4912f9910366"), new Guid("b1d38b75-4f26-482a-b017-b8ee2b838fdc") },
                    { new Guid("b814b9fa-ba14-40da-aeef-d35ba6bbf63f"), new Guid("186ac534-4c6e-4c16-9a44-1fa73f8db668") },
                    { new Guid("ba8cf2ab-16ca-4112-99c4-2505981781a2"), new Guid("3c50913b-a568-4de3-92fd-41577604e70b") },
                    { new Guid("c384c852-de4f-4890-9bbd-986c689b5864"), new Guid("9c3405fc-368b-4082-9cee-c02fe6fa87c1") },
                    { new Guid("c5bb3d53-3225-4cd4-ba80-b11d17fcecb9"), new Guid("58401406-bca2-4ff4-a77a-ff30d0905535") },
                    { new Guid("c674980f-dd11-48e8-9f35-f0cb0d4cdf0d"), new Guid("ddf8c566-a91b-4c83-9f6a-afcbb634f881") },
                    { new Guid("cd45eb70-ffbf-4e73-971f-60f915027c5b"), new Guid("e00dc6e2-efff-4891-aa5e-84dcdbd3dec2") },
                    { new Guid("cd709e9b-d652-40ea-84d8-9e1b39933ed4"), new Guid("7b3fe946-dac1-40f9-8828-11b1c1c4ed75") },
                    { new Guid("d257d6aa-66cf-48fa-8ced-3e35b6ec6ad8"), new Guid("7917c7a5-5a60-4ac9-bd8e-91f0eb4ba92a") },
                    { new Guid("d3b81956-572d-47c1-896d-e5838acd52ff"), new Guid("c8457fff-b6d8-43e0-9cf3-abc5e05bb8dc") },
                    { new Guid("d813e7bc-68c2-4e66-b25c-6438cba717e5"), new Guid("c0127b2a-777a-44f2-863a-f09b80ebd577") },
                    { new Guid("ea50e545-e10a-45b5-a028-2256887ec300"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") },
                    { new Guid("ed0c503e-0d74-4113-8363-bb03187927e7"), new Guid("fff5aefc-fecb-4402-a23b-e2455ed1808d") },
                    { new Guid("f0cf92a1-4fd2-4b2c-8535-2833d77b8059"), new Guid("4bc78904-c521-4c9a-a141-c02c28e5fd8b") }
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
