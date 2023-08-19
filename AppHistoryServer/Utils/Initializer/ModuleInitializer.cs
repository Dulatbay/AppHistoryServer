using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Dtos.ContentDtos.ContentViewerEnums;
using AppHistoryServer.Dtos.ContentDtos.IconEnums;
using AppHistoryServer.Models;
using Newtonsoft.Json;
using Term = AppHistoryServer.Dtos.ContentDtos.Term;

namespace AppHistoryServer.Utils.Initializer
{
    public class ModuleInitializer
    {
        public static void InitModules(ApplicationDbContext dbContext)
        {
            int number = 1;
            var module1 = new Module()
            {
                Title = "Древний век",
                Description = "В этой главе мы рассмотрим древний Казахстан, начиная с каменного века до Тюрков. Будут затронуты периоды бронзового века, а также история народов саков и сарматов. Помимо этого, мы рассмотрим вклад Казахстана в развитие ремесел, земледелия и животноводства. Особое внимание будет уделено уникальным археологическим находкам и памятникам, которые раскроют многогранность прошлого этого удивительного региона.",
                Minutes = 360,
                Level = 1,
                Number = number++,
                ImageUrl = "Modules/1.jpg"
            };

            var module2 = new Module()
            {
                Title = "Тюркский период",
                Description = "В этой главе мы перейдем к тюркскому периоду, когда тюркские племена начали активно поселяться на территории Казахстана. Раскроем роль этих племен в формировании ранних тюркских государств и их влияние на культуру и общество региона. Изучим язык и письменность тюрков, их религию и мифологию, а также важные исторические события, определившие будущее этой земли. Погрузимся в богатую и разнообразную историю древнего Казахстана, которая оставила следы в современном облике этой страны.",
                Minutes = 480,
                Level = 2,
                Number = number++,
                ImageUrl = "Modules/2.jpg"
            };

            var module3 = new Module()
            {
                Title = "Монгольское вторжение и его последствия",
                Description = "В важным этапом в истории Казахстана было Монгольское вторжение и его последствия. Монгольское завоевание, возглавляемое Чингисханом, имело глубокое влияние на этот регион, приведя к изменениям в политике, экономике и культуре. Исследуем масштабные события этого периода, его последствия для народов Казахстана и их долгосрочные последствия на историческое развитие страны.",
                Minutes = 550,
                Level = 3,
                Number = number++,
                ImageUrl = "Modules/3.jpg"
            };

            var module4 = new Module()
            {
                Title = "Казахское ханство",
                Description = "В этой главе мы рассмотрим Казахское ханство, его политическую структуру, роль ханов и их взаимоотношения с соседними государствами. Изучим важные периоды и события, которые повлияли на становление и укрепление ханства. Будут затронуты ключевые ханы и их вклад в формирование культурного и социального облика Казахстана. Также рассмотрим влияние ханства на экономику, торговлю и связи с другими регионами. В результате получим углубленное представление о значимости Казахского ханства в истории этой земли.",
                Minutes = 600,
                Level = 1,
                Number = number++,
                ImageUrl = "Modules/4.jpg"
            };

            var module5 = new Module()
            {
                Title = "Казахский народ в XVIII-XX",
                Description = "В этой главе мы рассмотрим историю Казахского народа с XVIII по XX век. Изучим период казахских ханств и их участие в геополитических событиях. Обратим внимание на влияние российской империи и его последствия для казахской культуры, обычаев и образа жизни. Также рассмотрим события, связанные с формированием Казахской автономной области и переходом в Казахскую ССР. Исследуем развитие национального самосознания и культурного восстановления Казахского народа в XX веке.",
                Minutes = 720,
                Level = 5,
                Number = number++,
                ImageUrl = "Modules/5.jpg"
            };

            var module6 = new Module()
            {
                Title = "Независимость",
                Description = "В этой главе мы рассмотрим историю независимости Казахстана. В конце XX века, после распада Советского Союза в 1991 году, Казахстан объявил о своей независимости. Исследуем процесс формирования суверенного государства, включая создание новой конституции, установление политических институтов и развитие экономики. Рассмотрим роль первого Президента Казахстана, Нурсултана Назарбаева, в формировании национальной идентичности и мирного перехода к независимости. Также обратим внимание на внутренние и внешние вызовы, с которыми столкнулся Казахстан в процессе строительства своего суверенного будущего.",
                Minutes = 660,
                Level = 1,
                Number = number++,
                ImageUrl = "Modules/6.jpeg"
            };

            dbContext.Modules.AddRange(module1, module2, module3, module4, module5, module6);
            dbContext.SaveChanges();

            Stack stack = new Stack()
            {
                Gap = 15,
                IsVertical = true,
                Children = new List<Node>
                {
                     new ContentViewer
                     {
                         Title = new Text
                         {
                             ChildTextHTML = "Периодизация истории Казахстана:",
                             TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE,
                             TextColor = Dtos.ContentDtos.TextEnums.TextColor.PRIMARY
                         },
                         Gap = 5,
                         Child = new Image
                         {
                             ImageUrl = "https://localhost:7279/api/static/Topics/1/1/1.svg",
                             Size = Dtos.ContentDtos.ImageEnums.Size.FULL_WIDTH
                         }
                     },
                     new ContentViewer
                     {
                         Title = new Text
                         {
                             ChildTextHTML = "Древнее время:",
                             TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE,
                             TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT
                         },
                         Gap = 5,
                         Child = new Image
                         {
                             ImageUrl = "https://localhost:7279/api/static/Topics/1/1/2.svg",
                             Size = Dtos.ContentDtos.ImageEnums.Size.FULL_WIDTH
                         }
                     },
                     new ContentViewer
                     {
                         Title = new Text
                         {
                             ChildTextHTML = "Каменный век:",
                             TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE,
                             TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT
                         },
                         Gap = 5,
                         Child = new Image
                         {
                             ImageUrl = "https://localhost:7279/api/static/Topics/1/1/3.svg",
                             Size = Dtos.ContentDtos.ImageEnums.Size.FULL_WIDTH
                         }
                     },
                     new ContentViewer
                     {
                         Title = new Text
                         {
                             ChildTextHTML = "Палеолит:",
                             TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE,
                             TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT
                         },
                         Gap = 5,
                         Child = new Image
                         {
                             ImageUrl = "https://localhost:7279/api/static/Topics/1/1/4.svg",
                             Size = Dtos.ContentDtos.ImageEnums.Size.FULL_WIDTH
                         }
                     },
                     new Stack
                     {
                         Gap = 5,
                         IsVertical = true,
                         Children = new List<Node>
                         {
                             new ContentViewer
                             {
                                 Title = new Text
                                 {
                                     ChildTextHTML = "Каменный век:",
                                     TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                     TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE
                                 },
                                 Child = new ListViewer
                                 {
                                     Gap = 5,
                                     Children = new List<Node>
                                     {
                                         new IconNode
                                         {
                                             Gap = 1,
                                             Icon = Icon.PRIMARY_DOTE,
                                             IconColor = IconColor.PRIMARY,
                                             Node = new Term
                                             {
                                                 TermText = "палеолит",
                                                 Description = "древнекаменный век",
                                                 IsWithHyphen = true,
                                             },
                                         },
                                         new IconNode
                                         {
                                             Gap = 1,
                                             IconColor = IconColor.PRIMARY,
                                             Icon = Icon.PRIMARY_DOTE,
                                             Node = new Term
                                             {
                                                 TermText = "мезолит",
                                                 Description = "среднекаменный век",
                                                 IsWithHyphen = true,
                                             },
                                         },
                                         new IconNode
                                         {
                                             Gap = 1,
                                             IconColor = IconColor.PRIMARY,
                                             Icon = Icon.PRIMARY_DOTE,
                                             Node = new Term
                                             {
                                                 TermText = "неолит",
                                                 Description = "новокаменный век",
                                                 IsWithHyphen = true,
                                             },
                                         },
                                         new IconNode
                                         {
                                             Gap = 1,
                                             IconColor = IconColor.PRIMARY,
                                             Icon = Icon.PRIMARY_DOTE,
                                             Node = new Term
                                             {
                                                 TermText = "неолит",
                                                 Description = "меднокаменный век/халкоит",
                                                 IsWithHyphen = true,
                                             },
                                         },
                                     },
                                 }
                             },
                             new Container
                             {
                                 BorderColor = Dtos.ContentDtos.ContainerEnums.BorderColor.PRIMARY,
                                 Padding = "15px",
                                 OutlinedType = Dtos.ContentDtos.ContainerEnums.OutlinedType.DASHED,
                                 Child = new Text
                                 {
                                     ChildTextHTML = "каждый период отличается от предыдущего более совершенными <b>орудиями труда</b>!",
                                     TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                     TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                 }
                             },
                             new Container
                             {
                                 BorderColor = Dtos.ContentDtos.ContainerEnums.BorderColor.PRIMARY,
                                 OutlinedType = Dtos.ContentDtos.ContainerEnums.OutlinedType.SOLID,
                                 Padding = "15px",
                                 Child = new Text
                                 {
                                     ChildTextHTML = "<b>100</b> тыс лет назад начался <b>Ледниковый период</b> (в <b>мустье/среднем</b> палеолите)",
                                     TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                     TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                 }
                             },
                             new Container
                             {
                                 BorderColor = Dtos.ContentDtos.ContainerEnums.BorderColor.PRIMARY,
                                 OutlinedType = Dtos.ContentDtos.ContainerEnums.OutlinedType.SOLID,
                                 Padding = "15px",
                                 Child = new Text
                                 {
                                     ChildTextHTML = "<b>13</b> тыс лет назад началась <b>таяние ледника</b> (в <b>мезолите</b>)",
                                     TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                     TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                 }
                             },
                         }
                     },
                     new Stack
                     {
                         Gap = 4,
                         Children = new List<Node>
                         {
                              new ContentViewer
                              {
                                    Title = new Text
                                    {
                                        ChildTextHTML = "Стадии развитии человека",
                                        TextColor = Dtos.ContentDtos.TextEnums.TextColor.PRIMARY,
                                        TextType = Dtos.ContentDtos.TextEnums.TextType.TITLE,
                                    },
                                    Child = new ListViewer
                                    {
                                        Gap = 1.4f,
                                        IsVertical = true,
                                        Children = new List<Node>
                                        {
                                            new IconNode
                                            {
                                                Gap = 1,
                                                Icon = Icon.ARROW_RIGHT,
                                                IconColor = IconColor.PRIMARY,
                                                Node = new Text
                                                {
                                                    ChildTextHTML = "<b>2,6</b> млн лет назад -- <b>человекоподобные существа</b> (австралопитеки)",
                                                    TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                                    TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                                }
                                            },
                                            new IconNode
                                            {
                                                Gap = 1,
                                                Icon = Icon.ARROW_RIGHT,
                                                IconColor = IconColor.PRIMARY,
                                                Node = new Text
                                                {
                                                    ChildTextHTML = "<b>1 млн 750</b> тыс лет назад -- <b>человек умелый</b>",
                                                    TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                                    TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                                }
                                            },
                                            new IconNode
                                            {
                                                Gap = 1,
                                                IconColor = IconColor.PRIMARY,
                                                Icon = Icon.ARROW_RIGHT,
                                                Node = new Text
                                                {
                                                    ChildTextHTML = "<b>1 млн</b> лет назад -- <b>человек прямоходящий<b>",
                                                    TextColor = Dtos.ContentDtos.TextEnums.TextColor.TEXT,
                                                    TextType = Dtos.ContentDtos.TextEnums.TextType.DESCRIPTION
                                                }
                                            },

                                        }
                                    }

                              }
                         }
                     }
                },
            };


            dbContext.Topics.AddRange(new Topic()
            {
                ModuleId = module1.Id,
                Title = "Каменный век",
                Content = JsonConvert.SerializeObject(stack)
            },
                                      new Topic()
                                      {
                                          ModuleId = module1.Id,
                                          Title = "Бронзовый век",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module1.Id,
                                          Title = "Саки",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module1.Id,
                                          Title = "Сарматы",
                                          Content = JsonConvert.SerializeObject(new { })
                                      });


            dbContext.Topics.AddRange(new Topic()
            {
                ModuleId = module2.Id,
                Title = "Тюркский каганат и Согдийцы",
                Content = JsonConvert.SerializeObject(new { })
            },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "Западнотюркский и восточнотюркский каганат",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "Тюргеши и карлуки",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "Караханиды и каракитайцы",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "Огузы, Кимаки, Кипчаки",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "ВШП, города и религии",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module2.Id,
                                          Title = "Письменность, литература, наука",
                                          Content = JsonConvert.SerializeObject(new { })
                                      });


            dbContext.Topics.AddRange(new Topic()
            {
                ModuleId = module3.Id,
                Title = "Монгольское вторжение",
                Content = JsonConvert.SerializeObject(new { })
            },
                                      new Topic()
                                      {
                                          ModuleId = module3.Id,
                                          Title = "Золотая Орда",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module3.Id,
                                          Title = "Ак Орда и Ханство Абулхаира",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module3.Id,
                                          Title = "Сибирское ханство и Ногайская Орда",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module3.Id,
                                          Title = "Государство Эмира Тимура и Могулистан",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module3.Id,
                                          Title = "Экономика и культура послемонгольского периода",
                                          Content = JsonConvert.SerializeObject(new { })
                                      });

            dbContext.Topics.AddRange(new Topic()
            {
                ModuleId = module4.Id,
                Title = "Формирование Казахского народа",
                Content = JsonConvert.SerializeObject(new { })
            },
                                      new Topic()
                                      {
                                          ModuleId = module4.Id,
                                          Title = "Образование Казахского ханства",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module4.Id,
                                          Title = "Ханы от Керея до Тауке",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module4.Id,
                                          Title = "Казахско-джунгарские войны",
                                          Content = JsonConvert.SerializeObject(new { })
                                      });

            dbContext.Topics.AddRange(new Topic()
            {
                ModuleId = module4.Id,
                Title = "Присоединение к Российской империи",
                Content = JsonConvert.SerializeObject(new { })
            },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Ханство Абылая. Культура 18 века",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Восстания Е. Пугачева и С. Датулы",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Ликвидация ханской власти. Восстания",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()       
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Бокеевская Орда. Восстания в Бокеевской орде",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Восстание Кенесары Касымова",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Присоединение старшего жуза к России. Восстания",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Реформы 1867-1868 годов. Восстания",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Реформы 1880-1890-х годов. Экономика в 19 веке",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Национальная обстановка в 19 веке",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Культура и наука 19 века",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Культура второй половины 19 и начала 20 веков",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Казахстан в начале 20 века",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Восстание 1916 года",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Революции 1917 года",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Автономии в Казахстане",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Установление советской власти. Гражданская война",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Образование КазАССР",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "НЭП и индустриализация",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Коллективизация",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Казахстан в предвоенные годы",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Казахстан в годы ВОВ",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Казахстан в послевоенные годы",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Период Застоя",
                                          Content = JsonConvert.SerializeObject(new { })
                                      },
                                      new Topic()
                                      {
                                          ModuleId = module5.Id,
                                          Title = "Перестройка",
                                          Content = JsonConvert.SerializeObject(new { })
                                      });

            dbContext.Topics.Add(new Topic()
            {
                ModuleId = module6.Id,
                Title = "Независимый Казахстан",
                Content = JsonConvert.SerializeObject(new { })
            });


            dbContext.SaveChanges();
        }

    }
}
