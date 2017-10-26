using System;
using System.Collections.Generic;
using System.Linq;
using BB.Core.Model;

namespace BB.Core
{
    public static class DbInitializer
    {
        public static void Initialize(BBEntities context)
        {
            var createdNewDB = context.Database.CreateIfNotExists();
            if (createdNewDB)
                Init(context);
        }

        private static void Init(BBEntities context)
        {
            InitUsersAndRoles(context);
            InitCategories(context);
            InitM(context);
        }

        private static void InitUsersAndRoles(BBEntities context)
        {
            var userRole = new Role
            {
                Name = UtilityModel.Role.User
            };

            var moderatorRole = new Role
            {
                Name = UtilityModel.Role.Moderator
            };

            var adminRole = new Role
            {
                Name = UtilityModel.Role.Admin
            };

            context.Roles.AddRange(new[] {userRole, moderatorRole, adminRole});

            context.SaveChanges();

            var pol = new User
            {
                Email = "paul.komarnytskyy@gmail.com",
                Username = "pavlo",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var marta = new User
            {
                Email = "martusia10961@gmail.com",
                Username = "marta",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var markiyan = new User
            {
                Email = "markian.oliskevych@gmail.com",
                Username = "markian",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var orysia = new User
            {
                Email = "orusiahalamaha@gmail.com",
                Username = "orysia",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var test = new User
            {
                Email = "test@gmail.com",
                Username = "test",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var user = new User
            {
                Email = "user@gmail.com",
                Username = "user",
                Password = "qwerty123",
                Roles = new List<Role> { userRole }
            };

            var moderator = new User
            {
                Email = "moderator@gmail.com",
                Username = "moderator",
                Password = "qwerty123",
                Roles = new List<Role> { moderatorRole }
            };

            var admin = new User
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Password = "qwerty123",
                Roles = new List<Role> { adminRole }
            };

            context.Users.AddRange(new[]
            {
                pol,
                marta,
                markiyan,
                orysia,
                test,
                user,
                moderator,
                admin
            });

            context.SaveChanges();
        }

        private static void InitCategories(BBEntities context)
        {
            var defaultCategoryImage = new ProductPicture
            {
                PictureUrl = "default.png"
            };

            context.ProductPictures.Add(defaultCategoryImage);
            context.SaveChanges();

            var electronics = new ProductCategory
            {
                Name = "Electronics",
                ParentCategoryId = null,
                FacingImage = defaultCategoryImage
            };

            #region Laptops and computers

            var laptopsAndComputers = new ProductCategory
            {
                Name = "Laptops and computers",
                ParentCategory = electronics,
                FacingImage = defaultCategoryImage
            };

            var laptops = new ProductCategory
            {
                Name = "Laptops",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            #region Accessories for PC and laptops

            var accessoriesForLaptopsAndPC = new ProductCategory
            {
                Name = "Accessories for laptops and PC",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };
            
            var soundSystems = new ProductCategory
            {
                Name = "Sound systems",
                ParentCategory = accessoriesForLaptopsAndPC,
                FacingImage = defaultCategoryImage
            };

            var usbDrives = new ProductCategory
            {
                Name = "USB drives",
                ParentCategory = accessoriesForLaptopsAndPC,
                FacingImage = defaultCategoryImage
            };

            var bagsAndBackpacks = new ProductCategory
            {
                Name = "Bags and backpacks",
                ParentCategory = accessoriesForLaptopsAndPC,
                FacingImage = defaultCategoryImage
            };

            var webCams = new ProductCategory
            {
                Name = "Webcams",
                ParentCategory = accessoriesForLaptopsAndPC,
                FacingImage = defaultCategoryImage
            };

            #endregion

            var tablets = new ProductCategory
            {
                Name = "Tablets",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            #region Tablet accessories

            var tabletsAccessories = new ProductCategory
            {
                Name = "Accessories for tablets",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            var coversAndKeyboards = new ProductCategory
            {
                Name = "Covers and keyboards",
                ParentCategory = tabletsAccessories,
                FacingImage = defaultCategoryImage
            };

            var protectiveGlass = new ProductCategory
            {
                Name = "Protective glass",
                ParentCategory = tabletsAccessories,
                FacingImage = defaultCategoryImage
            };

            #endregion

            var electronicBooks = new ProductCategory
            {
                Name = "Electronic books",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            #region Components

            var components = new ProductCategory
            {
                Name = "Components",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            var graphicCards = new ProductCategory
            {
                Name = "Graphic cards",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var HDDs = new ProductCategory
            {
                Name = "HDD",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var processors = new ProductCategory
            {
                Name = "Processors",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var SSDs = new ProductCategory
            {
                Name = "SSD",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var memory = new ProductCategory
            {
                Name = "Memory",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var motherboards = new ProductCategory
            {
                Name = "Motherboards",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var powerSupply = new ProductCategory
            {
                Name = "Power supply",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var cases = new ProductCategory
            {
                Name = "Cases",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var ups = new ProductCategory
            {
                Name = "Uninterrupted power supply",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var coolingSystems = new ProductCategory
            {
                Name = "Cooling systems",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var surgeProtectors = new ProductCategory
            {
                Name = "Surge protectors",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var opticDrives = new ProductCategory
            {
                Name = "Optic drives",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            var soundCards = new ProductCategory
            {
                Name = "Sound cards",
                ParentCategory = components,
                FacingImage = defaultCategoryImage
            };

            #endregion

            #region Computers

            var computers = new ProductCategory
            {
                Name = "Computers",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            var monitors = new ProductCategory
            {
                Name = "Monitors",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var computersNettopsMonoblocks = new ProductCategory
            {
                Name = "Computers, nettops, monoblocks",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var mice = new ProductCategory
            {
                Name = "Mice",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var keyboards = new ProductCategory
            {
                Name = "Keyboards",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var graphicTablets = new ProductCategory
            {
                Name = "Graphic tablets",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var keyboardMouseComplects = new ProductCategory
            {
                Name = "Complects keyboard + mouse",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            var NAS = new ProductCategory
            {
                Name = "NAS",
                ParentCategory = computers,
                FacingImage = defaultCategoryImage
            };

            #endregion

            var serverEquipment = new ProductCategory
            {
                Name = "Server equipment",
                ParentCategory = laptopsAndComputers,
                FacingImage = defaultCategoryImage
            };

            #endregion

            var smartphonesAndTV = new ProductCategory
            {
                Name = "Smartphones, TV and electronics",
                ParentCategory = electronics,
                FacingImage = defaultCategoryImage
            };

            var appliances = new ProductCategory
            {
                Name = "Appliances",
                ParentCategory = electronics,
                FacingImage = defaultCategoryImage
            };

            context.ProductCategories.AddRange(new[]
            {
                electronics,
                laptopsAndComputers,
                laptops,
                accessoriesForLaptopsAndPC,
                soundSystems,
                usbDrives,
                bagsAndBackpacks,
                webCams,
                tablets,
                tabletsAccessories,
                coversAndKeyboards,
                protectiveGlass,
                electronicBooks,
                components,
                graphicCards,
                HDDs,
                processors,
                SSDs,
                memory,
                motherboards,
                powerSupply,
                cases,
                ups,
                coolingSystems,
                surgeProtectors,
                opticDrives,
                soundCards,
                computers,
                monitors,
                computersNettopsMonoblocks,
                mice,
                keyboards,
                graphicTablets,
                keyboardMouseComplects,
                NAS,
                serverEquipment,
                smartphonesAndTV,
                appliances
            });
            #region Сharacteristics

            var cpu = new Characteristic
            {
                Name = "CPU",
                ProductCategories = new List<ProductCategory> {laptops}
            };
            var diagonalOfTheScreen = new Characteristic
            {
                Name = "Diagonal of the screen",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var producer = new Characteristic
            {
                Name = "Producer",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var volumeOfOperationalMemory = new Characteristic
            {
                Name = "Volume Of Operational Memory",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var typeOfDrive = new Characteristic
            {
                Name = "Type Of Drive",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var operatingSystem = new Characteristic
            {
                Name = "Operating System",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var videoCard = new Characteristic
            {
                Name = "Video Card",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var expansion = new Characteristic
            {
                Name = "Expansion",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var numberOfCores = new Characteristic
            {
                Name = "Number Of Cores",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var driveСapacity = new Characteristic
            {
                Name = "Вrive Сapacity",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var amountSSD = new Characteristic
            {
                Name = "Amount SSD",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var typeOfVideoCard = new Characteristic
            {
                Name = "Type Of Video Card",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var seriesOfDiscreteGraphicsCards = new Characteristic
            {
                Name = "Series Of Discrete Graphics Cards",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var color = new Characteristic
            {
                Name = "Color",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var weight = new Characteristic
            {
                Name = "Weight",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var memoryCardSize = new Characteristic
            {
                Name = "Memory Card Size",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var screenType = new Characteristic
            {
                Name = "Screen Type",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var keyboard = new Characteristic
            {
                Name = "Keyboard",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var screenCover = new Characteristic
            {
                Name = "Screen Cover",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var battery = new Characteristic
            {
                Name = "Battery",
                ProductCategories = new List<ProductCategory> { laptops }
            };
            var touchScreen = new Characteristic
            {
                Name = "Touch Screen",
                ProductCategories = new List<ProductCategory> { laptops }
            };

            #endregion
            context.Characteristics.AddRange(new[]
           {
                cpu,
                diagonalOfTheScreen,
                producer,
                volumeOfOperationalMemory,
                typeOfDrive,
                operatingSystem,
                videoCard,
                expansion,
                numberOfCores,
                driveСapacity,
                amountSSD,
                typeOfVideoCard,
                seriesOfDiscreteGraphicsCards,
                color,
                weight,
                memoryCardSize,
                screenType,
                keyboard,
                screenCover,
                battery,
                touchScreen
            });
            #region Laptops
            var laptop1 = new Product
            {
                Name = "Asus EeeBook E502SA ",
                ProductCategory = laptops,
                Price = 7777
            };
            //var laptop1ProductCharacteristics = new List<ProductCharacteristic>
            //{
            //    new ProductCharacteristic {Characteristic=cpu,Value= }
            //};
            var laptop2 = new Product
            {
                Name = "Asus Vivobook E502NA  ",
                ProductCategory = laptops,
                Price = 8255
            };
            var laptop3 = new Product
            {
                Name = "Asus VivoBook Max X541SA   ",
                ProductCategory = laptops,
                Price = 7999
            };
            var laptop4 = new Product
            {
                Name = "Asus Vivobook X556UQ  ",
                ProductCategory = laptops,
                Price = 18999
            };
            var laptop5 = new Product
            {
                Name = "Asus N752VX ",
                ProductCategory = laptops,
                Price = 32588
            };
            var laptop6 = new Product
            {
                Name = "Asus X751SA ",
                ProductCategory = laptops,
                Price = 9499
            };
            var laptop7 = new Product
            {
                Name = "HP 250 G5 ",
                ProductCategory = laptops,
                Price = 7399
            };
            var laptop8 = new Product
            {
                Name = "HP 15-ba613ur ",
                ProductCategory = laptops,
                Price = 8999
            };
            var laptop9 = new Product
            {
                Name = "HP 250 G6 ",
                ProductCategory = laptops,
                Price = 17399
            };
            var laptop10 = new Product
            {
                Name = "HP 15-bs577ur  ",
                ProductCategory = laptops,
                Price = 10499
            };
            var laptop11 = new Product
            {
                Name = "Dell Inspiron 3552",
                ProductCategory = laptops,
                Price = 6599
            };
            var laptop12 = new Product
            {
                Name = "Dell Inspiron 7567",
                ProductCategory = laptops,
                Price = 28699
            };
            var laptop13 = new Product
            {
                Name = "Ноутбук Dell XPS 15 9550",
                ProductCategory = laptops,
                Price = 36555
            };
            var laptop14 = new Product
            {
                Name = "Dell Vostro 15 5568",
                ProductCategory = laptops,
                Price = 24699
            };
            var laptop15 = new Product
            {
                Name = "Dell Inspiron 7567",
                ProductCategory = laptops,
                Price = 32499
            };
            var laptop16 = new Product
            {
                Name = "Dell Vostro 15 3568 ",
                ProductCategory = laptops,
                Price = 18550
            };
            var laptop17 = new Product
            {
                Name = "Acer Aspire ES1-532G-P1Q4 ",
                ProductCategory = laptops,
                Price = 8188
            };
            var laptop18 = new Product
            {
                Name = "Acer Aspire VX 15 VX5-591G-59NH",
                ProductCategory = laptops,
                Price = 24999
            };
            var laptop19 = new Product
            {
                Name = "Acer Aspire 5 A515-51G-36TE ",
                ProductCategory = laptops,
                Price = 13706
            };
            var laptop20 = new Product
            {
                Name = "Lenovo Legion Y520-15IKBN ",
                ProductCategory = laptops,
                Price = 28619
            };
            var laptop21 = new Product
            {
                Name = "Lenovo IdeaPad 110-14IBR ",
                ProductCategory = laptops,
                Price = 7099
            };
            var laptop22 = new Product
            {
                Name = " Lenovo IdeaPad 320-15IAP ",
                ProductCategory = laptops,
                Price = 8999
            };
            var laptop23 = new Product
            {
                Name = "Lenovo IdeaPad 510-15IKB ",
                ProductCategory = laptops,
                Price = 17999
            };
            var laptop24 = new Product
            {
                Name = "Lenovo IdeaPad 110-15ACL ",
                ProductCategory = laptops,
                Price = 10499
            };
            var laptop25 = new Product
            {
                Name = "Lenovo G70-80 ",
                ProductCategory = laptops,
                Price = 10999
            };
            var laptop26 = new Product
            {
                Name = "Lenovo IdeaPad 320-15ISK ",
                ProductCategory = laptops,
                Price = 12999
            };
            var laptop27 = new Product
            {
                Name = "Lenovo IdeaPad 320-15IKB ",
                ProductCategory = laptops,
                Price = 15199
            };
            var laptop28 = new Product
            {
                Name = "Lenovo IdeaPad 110-15ACL ",
                ProductCategory = laptops,
                Price = 7399
            };
            var laptop29 = new Product
            {
                Name = "Lenovo IdeaPad 320-17IKB ",
                ProductCategory = laptops,
                Price = 20559
            };
            var laptop30 = new Product
            {
                Name = "Lenovo IdeaPad 110-15IBR",
                ProductCategory = laptops,
                Price = 6799
            };
            var laptop31 = new Product
            {
                Name = "Apple A1466 MacBook Air 13",
                ProductCategory = laptops,
                Price = 25999
            };
            var laptop32 = new Product
            {
                Name = "Apple MacBook Pro Retina 15",
                ProductCategory = laptops,
                Price = 67799
            };
            #endregion
            context.Products.AddRange(new[]
   {
                laptop1,
                laptop2,
                laptop3,
                laptop4,
                laptop5,
                laptop6,
                laptop7,
                laptop8,
                laptop9,
                laptop10,
                laptop11,
                laptop12,
                laptop13,
                laptop14,
                laptop15,
                laptop16,
                laptop17,
                laptop18,
                laptop19,
                laptop20,
                laptop21,
                laptop22,
                laptop23,
                laptop24,
                laptop25,
                laptop26,
                laptop27,
                laptop28,
                laptop29,
                laptop30,
                laptop31,
                laptop32
    });
            context.SaveChanges();
        }
        public static void InitM(BBEntities context)
        {
            var user = new User
            {
                Username = "name", Email = "mail", Password = "1"
            };

            context.Users.Add(user);
            var characteristic = new Characteristic() { Name = "default" };
            context.Characteristics.Add(characteristic);
            var characteristicOption = new CharacteristicOption() { Characteristic = characteristic, Value = "shitty" };
            context.CharacteristicOptions.Add(characteristicOption);
            var image = new ProductPicture() { PictureUrl = "picture here" };
            context.ProductPictures.Add(image);
            var category = new ProductCategory() { Name = "base", FacingImage = image };
            category.Characteristics.Add(characteristic);
            context.ProductCategories.Add(category);
            
            var product = new Product() { Name = "default", Price = 0, FacingImage = image, ProductCategory = category };
            product.ProductCharacteristics.Add(new ProductCharacteristic() { Characteristic = characteristic, Value = "shitty" });
            product.ProductDetails = new ProductDetails() { Description = "the shittiest product ever" };
            context.Products.Add(product);
            var comment1 = new Comment() { Text = "parent", DatePosted = DateTime.Today, User = user, Product = product };
            var userReaction1 = new UserReaction() { User = user, Comment = comment1, Reaction = Reaction.Like };
            var comment2 = new Comment() { Text = "child", DatePosted = DateTime.Today, User = user, ParentComment = comment1 };
            var userReaction2 = new UserReaction() { User = user, Comment = comment2, Reaction = Reaction.Like };
            var comment3 = new Comment() { Text = "grandchild", DatePosted = DateTime.Today, User = user, ParentComment = comment2 };
            var userReaction3 = new UserReaction() { User = user, Comment = comment3, Reaction = Reaction.Like };
            context.Comments.Add(comment1);
            context.Comments.Add(comment2);
            context.Comments.Add(comment3);
            context.UserReactions.Add(userReaction1);
            context.UserReactions.Add(userReaction2);
            context.UserReactions.Add(userReaction3);
            context.SaveChanges();
        }
    }
}
