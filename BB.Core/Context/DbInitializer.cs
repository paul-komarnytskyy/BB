using System;
using System.Collections.Generic;
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
            #region Users and roles

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

            context.Roles.AddRange(new[] { userRole, moderatorRole, adminRole });

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


            var loyal = new Discount();
            loyal.DiscountValue = (decimal)0.1;
            loyal.Name = "Loyal customer";

            var vip = new Discount();
            vip.DiscountValue = (decimal)0.2;
            vip.Name = "VIP";

            context.Discounts.Add(loyal);
            context.Discounts.Add(vip);

            UserDiscount pd = new UserDiscount();
            pd.Discount = vip;
            pd.User = pol;

            UserDiscount od = new UserDiscount();
            od.Discount = loyal;
            od.User = orysia;

            context.UserDiscounts.Add(pd);
            context.UserDiscounts.Add(od);

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

            #endregion

            #region Categories

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

            #endregion

            #region Сharacteristics
            
            var cpu = new Characteristic
            {
                Name = "CPU",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var diagonalOfTheScreen = new Characteristic
            {
                Name = "Diagonal of the screen",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var producer = new Characteristic
            {
                Name = "Producer",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var volumeOfOperationalMemory = new Characteristic
            {
                Name = "Volume Of Operational Memory",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var typeOfDrive = new Characteristic
            {
                Name = "Type Of Drive",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var operatingSystem = new Characteristic
            {
                Name = "Operating System",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var videoCard = new Characteristic
            {
                Name = "Video Card",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var resolution = new Characteristic
            {
                Name = "Resolution",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var numberOfCores = new Characteristic
            {
                Name = "Number Of Cores",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var driveСapacity = new Characteristic
            {
                Name = "Вrive Сapacity",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var amountSSD = new Characteristic
            {
                Name = "Amount SSD",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var typeOfVideoCard = new Characteristic
            {
                Name = "Type Of Video Card",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var seriesOfDiscreteGraphicsCards = new Characteristic
            {
                Name = "Series Of Discrete Graphics Cards",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var color = new Characteristic
            {
                Name = "Color",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var weight = new Characteristic
            {
                Name = "Weight",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var memoryCardSize = new Characteristic
            {
                Name = "Memory Card Size",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var screenType = new Characteristic
            {
                Name = "Screen Type",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var keyboard = new Characteristic
            {
                Name = "Keyboard",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var screenCover = new Characteristic
            {
                Name = "Screen Cover",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var battery = new Characteristic
            {
                Name = "Battery",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            var touchScreen = new Characteristic
            {
                Name = "Touch Screen",
                ProductCategories = new List<ProductCategory> { laptops },
            };

            context.Characteristics.AddRange(new[]
            {
                cpu,
                diagonalOfTheScreen,
                producer,
                volumeOfOperationalMemory,
                typeOfDrive,
                operatingSystem,
                videoCard,
                resolution,
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


            #region Characteristic Options

            var cpu_amdA6 = new CharacteristicOption
            {
                Name = "AMD A6",
                Value = "AMD A6",
                Characteristic = cpu
            };

            var cpu_amdA8 = new CharacteristicOption
            {
                Name = "AMD A8",
                Value = "AMD A8",
                Characteristic = cpu
            };

            var cpu_amdA9 = new CharacteristicOption
            {
                Name = "AMD A9",
                Value = "AMD A9",
                Characteristic = cpu
            };

            var cpu_intelCoreM = new CharacteristicOption
            {
                Name = "Intel Core M",
                Value = "Intel Core M",
                Characteristic = cpu
            };

            var cpu_intelCorei5 = new CharacteristicOption
            {
                Name = "Intel Core i5",
                Value = "Intel Core i5",
                Characteristic = cpu
            };

            var cpu_intelCorei7 = new CharacteristicOption
            {
                Name = "Intel Core i7",
                Value = "Intel Core i7",
                Characteristic = cpu
            };

            var diagonalOfTheScreen_9 = new CharacteristicOption
            {
                Name = "9",
                Value = "9",
                Characteristic = diagonalOfTheScreen
            };

            var diagonalOfTheScreen_13 = new CharacteristicOption
            {
                Name = "13",
                Value = "13",
                Characteristic = diagonalOfTheScreen
            };

            var diagonalOfTheScreen_14 = new CharacteristicOption
            {
                Name = "14",
                Value = "14",
                Characteristic = diagonalOfTheScreen
            };

            var diagonalOfTheScreen_15 = new CharacteristicOption
            {
                Name = "15",
                Value = "15",
                Characteristic = diagonalOfTheScreen
            };

            var diagonalOfTheScreen_17 = new CharacteristicOption
            {
                Name = "17",
                Value = "17",
                Characteristic = diagonalOfTheScreen
            };

            var volumeOfOperationalMemory_4 = new CharacteristicOption
            {
                Name = "4",
                Value = "4",
                Characteristic = volumeOfOperationalMemory
            };

            var volumeOfOperationalMemory_6 = new CharacteristicOption
            {
                Name = "6",
                Value = "6",
                Characteristic = volumeOfOperationalMemory
            };

            var volumeOfOperationalMemory_8 = new CharacteristicOption
            {
                Name = "8",
                Value = "8",
                Characteristic = volumeOfOperationalMemory
            };

            var volumeOfOperationalMemory_10 = new CharacteristicOption
            {
                Name = "10",
                Value = "10",
                Characteristic = volumeOfOperationalMemory
            };

            var volumeOfOperationalMemory_24 = new CharacteristicOption
            {
                Name = "24",
                Value = "24",
                Characteristic = volumeOfOperationalMemory
            };

            var volumeOfOperationalMemory_32 = new CharacteristicOption
            {
                Name = "32",
                Value = "32",
                Characteristic = volumeOfOperationalMemory
            };

            var typeOfDrive_HDD = new CharacteristicOption
            {
                Name = "HDD",
                Value = "HDD",
                Characteristic = typeOfDrive
            };

            var typeOfDrive_SDD = new CharacteristicOption
            {
                Name = "SDD",
                Value = "SDD",
                Characteristic = typeOfDrive
            };

            var typeOfDrive_SDDandHDD = new CharacteristicOption
            {
                Name = "SDD and HDD",
                Value = "SDD and HDD",
                Characteristic = typeOfDrive
            };

            var operatingSystem_EndlessOS = new CharacteristicOption
            {
                Name = "Endless OS",
                Value = "Endless OS",
                Characteristic = operatingSystem
            };

            var operatingSystem_Windows7 = new CharacteristicOption
            {
                Name = "Windows 7",
                Value = "Windows 7",
                Characteristic = operatingSystem
            };

            var operatingSystem_Windows10 = new CharacteristicOption
            {
                Name = "Windows 10",
                Value = "Windows 10",
                Characteristic = operatingSystem
            };

            var operatingSystem_WithoutOC = new CharacteristicOption
            {
                Name = "Without OC",
                Value = "Without OC",
                Characteristic = operatingSystem
            };

            var videoCard_AMDRadeon = new CharacteristicOption
            {
                Name = "AMD Radeon",
                Value = "AMDRadeon",
                Characteristic = videoCard
            };

            var videoCard_nVidiaGeForce = new CharacteristicOption
            {
                Name = "nVidia GeForce",
                Value = "nVidia GeForce",
                Characteristic = videoCard
            };

            var resolution_1366and768 = new CharacteristicOption
            {
                Name = "1366 x 768",
                Value = "1366 x 768",
                Characteristic = resolution
            };

            var resolution_1600and900 = new CharacteristicOption
            {
                Name = "1600 x 900",
                Value = "1600 x 900",
                Characteristic = resolution
            };

            var resolution_FullHD = new CharacteristicOption
            {
                Name = "Full HD",
                Value = "Full HD",
                Characteristic = resolution
            };

            var numberOfCores_2 = new CharacteristicOption
            {
                Name = "2",
                Value = "2",
                Characteristic = numberOfCores
            };

            var numberOfCores_4 = new CharacteristicOption
            {
                Name = "4",
                Value = "4",
                Characteristic = numberOfCores
            };

            var numberOfCores_8 = new CharacteristicOption
            {
                Name = "8",
                Value = "8",
                Characteristic = numberOfCores
            };

            var driveСapacity_1Tbto2Tb = new CharacteristicOption
            {
                Name = "1TB to 2TB",
                Value = "1TB to 2TB",
                Characteristic = driveСapacity
            };

            var driveСapacity_500Gbto750Gb = new CharacteristicOption
            {
                Name = "500GB to 750GB",
                Value = "500GB to 750GB",
                Characteristic = driveСapacity
            };

            var driveСapacity_to500Gb = new CharacteristicOption
            {
                Name = "to 500GB",
                Value = "to 500GB",
                Characteristic = driveСapacity
            };

            var amountSSD_1Tb = new CharacteristicOption
            {
                Name = "1TB",
                Value = "1TB",
                Characteristic = amountSSD
            };

            var amountSSD_128Gb = new CharacteristicOption
            {
                Name = "128GB",
                Value = "128GB",
                Characteristic = amountSSD
            };

            var amountSSD_256Gb = new CharacteristicOption
            {
                Name = "256GB",
                Value = "256GB",
                Characteristic = amountSSD
            };

            var amountSSD_512Gb = new CharacteristicOption
            {
                Name = "512GB",
                Value = "512GB",
                Characteristic = amountSSD
            };

            var seriesOfDiscreteGraphicsCards_GeForceGtx = new CharacteristicOption
            {
                Name = "GeForce GTX",
                Value = "GeForce GTX",
                Characteristic = seriesOfDiscreteGraphicsCards
            };

            var seriesOfDiscreteGraphicsCards_GeForceR5 = new CharacteristicOption
            {
                Name = "GeForce R5",
                Value = "GeForce R5",
                Characteristic = seriesOfDiscreteGraphicsCards
            };

            var seriesOfDiscreteGraphicsCards_GeForceRx = new CharacteristicOption
            {
                Name = "GeForce RX",
                Value = "GeForce RX",
                Characteristic = seriesOfDiscreteGraphicsCards
            };

            var typeOfVideoCard_discrete = new CharacteristicOption
            {
                Name = "Discrete",
                Value = "Discrete",
                Characteristic = typeOfVideoCard
            };

            var typeOfVideoCard_integrated = new CharacteristicOption
            {
                Name = "Integrated",
                Value = "Integrated",
                Characteristic = typeOfVideoCard
            };

            var weight_more3kg = new CharacteristicOption
            {
                Name = "More 3 kg",
                Value = "More 3 kg",
                Characteristic = weight
            };

            var weight_more2kg = new CharacteristicOption
            {
                Name = "More 2 kg",
                Value = "More 2 kg",
                Characteristic = weight
            };

            var weight_to1kg = new CharacteristicOption
            {
                Name = "To 1 kg",
                Value = "To 1 kg",
                Characteristic = weight
            };

            var screenType_IPS = new CharacteristicOption
            {
                Name = "IPS",
                Value = "IPS",
                Characteristic = screenType
            };

            var keyboard_withoutlight = new CharacteristicOption
            {
                Name = "Without light",
                Value = "Without light",
                Characteristic = keyboard
            };

            var keyboard_withlight = new CharacteristicOption
            {
                Name = "With light",
                Value = "With light",
                Characteristic = keyboard
            };

            var touchScreen_withoutTouchScreen = new CharacteristicOption
            {
                Name = "Without Touch Screen",
                Value = "Without Touch Screen",
                Characteristic = touchScreen
            };

            var touchScreen_withTouchScreen = new CharacteristicOption
            {
                Name = "With Touch Screen",
                Value = "With Touch Screen",
                Characteristic = touchScreen
            };

            var battery_removable = new CharacteristicOption
            {
                Name = "Removable",
                Value = "Removable",
                Characteristic = battery
            };

            var battery_notRemovable = new CharacteristicOption
            {
                Name = "Not Removable",
                Value = "Not Removable",
                Characteristic = battery
            };

            var screenCover_glossy = new CharacteristicOption
            {
                Name = "Glossy",
                Value = "Glossy",
                Characteristic = screenCover
            };

            var screenCover_matte = new CharacteristicOption
            {
                Name = "Matte",
                Value = "Matte",
                Characteristic = screenCover
            };

            var memoryCardSize_1Gb = new CharacteristicOption
            {
                Name = "1 GB",
                Value = "1 GB",
                Characteristic = memoryCardSize
            };

            var memoryCardSize_2Gb = new CharacteristicOption
            {
                Name = "2 GB",
                Value = "2 GB",
                Characteristic = memoryCardSize
            };

            var producer_Asus = new CharacteristicOption
            {
                Name = "Asus",
                Value = "Asus",
                Characteristic = producer
            };

            var producer_Acer = new CharacteristicOption
            {
                Name = "Acer",
                Value = "Acer",
                Characteristic = producer
            };

            var producer_Apple = new CharacteristicOption
            {
                Name = "Apple",
                Value = "Apple",
                Characteristic = producer
            };

            var producer_HP = new CharacteristicOption
            {
                Name = "HP",
                Value = "HP",
                Characteristic = producer
            };

            var producer_Lenovo = new CharacteristicOption
            {
                Name = "Lenovo",
                Value = "Lenovo",
                Characteristic = producer
            };

            var producer_Dell = new CharacteristicOption
            {
                Name = "Dell",
                Value = "Dell",
                Characteristic = producer
            };

            var color_Black = new CharacteristicOption
            {
                Name = "Black",
                Value = "Black",
                Characteristic = color
            };

            var color_White = new CharacteristicOption
            {
                Name = "White",
                Value = "White",
                Characteristic = color
            };

            var color_Red = new CharacteristicOption
            {
                Name = "Red",
                Value = "Red",
                Characteristic = color
            };

            var color_Pink = new CharacteristicOption
            {
                Name = "Pink",
                Value = "Pink",
                Characteristic = color
            };

            context.CharacteristicOptions.AddRange(new[]
            {
                cpu_amdA6,
                cpu_amdA8,
                cpu_amdA9,
                cpu_intelCorei5,
                cpu_intelCorei7,
                cpu_intelCoreM,
                diagonalOfTheScreen_9,
                diagonalOfTheScreen_13,
                diagonalOfTheScreen_14,
                diagonalOfTheScreen_15,
                diagonalOfTheScreen_17,
                producer_Acer,
                producer_Apple,
                producer_Asus,
                producer_HP,
                producer_Lenovo,
                producer_Dell,
                volumeOfOperationalMemory_10,
                volumeOfOperationalMemory_24,
                volumeOfOperationalMemory_32,
                volumeOfOperationalMemory_4,
                volumeOfOperationalMemory_6,
                volumeOfOperationalMemory_8,
                typeOfDrive_HDD,
                typeOfDrive_SDD,
                operatingSystem_EndlessOS,
                operatingSystem_Windows10,
                operatingSystem_Windows7,
                operatingSystem_WithoutOC,
                videoCard_AMDRadeon,
                videoCard_nVidiaGeForce,
                resolution_1366and768,
                resolution_1600and900,
                resolution_FullHD,
                numberOfCores_2,
                numberOfCores_4,
                numberOfCores_8,
                driveСapacity_1Tbto2Tb,
                driveСapacity_500Gbto750Gb,
                driveСapacity_to500Gb,
                amountSSD_128Gb,
                amountSSD_1Tb,
                amountSSD_256Gb,
                amountSSD_512Gb,
                typeOfVideoCard_discrete,
                typeOfVideoCard_integrated,
                seriesOfDiscreteGraphicsCards_GeForceGtx,
                seriesOfDiscreteGraphicsCards_GeForceR5,
                seriesOfDiscreteGraphicsCards_GeForceRx,
                color_Black,
                color_Pink,
                color_Red,
                color_White,
                weight_more2kg,
                weight_more3kg,
                weight_to1kg,
                memoryCardSize_1Gb,
                memoryCardSize_2Gb,
                screenCover_glossy,
                screenCover_matte,
                keyboard_withlight,
                keyboard_withoutlight,
                screenType_IPS,
                battery_notRemovable,
                battery_removable,
                touchScreen_withoutTouchScreen,
                touchScreen_withTouchScreen
            });


            #endregion

            #endregion

            #region Laptops

            var laptop1 = new Product
            {
                Name = "Asus EeeBook E502SA ",
                ProductCategory = laptops,
                Price = 7777
            };

            var laptop1ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu1"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop1.ProductCharacteristics = laptop1ProductCharacteristics;

            var laptop2 = new Product
            {
                Name = "Asus Vivobook E502NA  ",
                ProductCategory = laptops,
                Price = 8255
            };

            var laptop2ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu3"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop2.ProductCharacteristics = laptop2ProductCharacteristics;

            var laptop3 = new Product
            {
                Name = "Asus VivoBook Max X541SA   ",
                ProductCategory = laptops,
                Price = 7999
            };

            var laptop3ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu3"},
                new ProductCharacteristic {Characteristic=color,Value="Red"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop3.ProductCharacteristics = laptop3ProductCharacteristics;

            var laptop4 = new Product
            {
                Name = "Asus Vivobook X556UQ  ",
                ProductCategory = laptops,
                Price = 18999
            };

            var laptop4ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop4.ProductCharacteristics = laptop4ProductCharacteristics;

            var laptop5 = new Product
            {
                Name = "Asus N752VX ",
                ProductCategory = laptops,
                Price = 32588
            };

            var laptop5ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop5.ProductCharacteristics = laptop5ProductCharacteristics;

            var laptop6 = new Product
            {
                Name = "Asus X751SA ",
                ProductCategory = laptops,
                Price = 9499
            };

            var laptop6ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu6"},
                new ProductCharacteristic {Characteristic=color,Value="Pink"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop6.ProductCharacteristics = laptop6ProductCharacteristics;

            var laptop7 = new Product
            {
                Name = "HP 250 G5 ",
                ProductCategory = laptops,
                Price = 7399
            };

            var laptop7ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop7.ProductCharacteristics = laptop7ProductCharacteristics;

            var laptop8 = new Product
            {
                Name = "HP 15-ba613ur ",
                ProductCategory = laptops,
                Price = 8999
            };

            var laptop8ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu1"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop8.ProductCharacteristics = laptop8ProductCharacteristics;

            var laptop9 = new Product
            {
                Name = "HP 250 G6 ",
                ProductCategory = laptops,
                Price = 17399
            };

            var laptop9ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop9.ProductCharacteristics = laptop9ProductCharacteristics;

            var laptop10 = new Product
            {
                Name = "HP 15-bs577ur  ",
                ProductCategory = laptops,
                Price = 10499
            };

            var laptop10ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu5"},
                new ProductCharacteristic {Characteristic=color,Value="Red"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop10.ProductCharacteristics = laptop10ProductCharacteristics;

            var laptop11 = new Product
            {
                Name = "Dell Inspiron 3552",
                ProductCategory = laptops,
                Price = 6599
            };

            var laptop11ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu1"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop11.ProductCharacteristics = laptop11ProductCharacteristics;
            var laptop12 = new Product
            {
                Name = "Dell Inspiron 7567",
                ProductCategory = laptops,
                Price = 28699
            };

            var laptop12ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop12.ProductCharacteristics = laptop12ProductCharacteristics;

            var laptop13 = new Product
            {
                Name = "Ноутбук Dell XPS 15 9550",
                ProductCategory = laptops,
                Price = 36555
            };

            var laptop13ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop13.ProductCharacteristics = laptop13ProductCharacteristics;

            var laptop14 = new Product
            {
                Name = "Dell Vostro 15 5568",
                ProductCategory = laptops,
                Price = 24699
            };

            var laptop14ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop14.ProductCharacteristics = laptop14ProductCharacteristics;

            var laptop15 = new Product
            {
                Name = "Dell Inspiron 7567",
                ProductCategory = laptops,
                Price = 32499
            };

            var laptop15ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu3"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop15.ProductCharacteristics = laptop15ProductCharacteristics;

            var laptop16 = new Product
            {
                Name = "Dell Vostro 15 3568 ",
                ProductCategory = laptops,
                Price = 18550
            };

            var laptop16ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu5"},
                new ProductCharacteristic {Characteristic=color,Value="Pink"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop16.ProductCharacteristics = laptop16ProductCharacteristics;

            var laptop17 = new Product
            {
                Name = "Acer Aspire ES1-532G-P1Q4 ",
                ProductCategory = laptops,
                Price = 8188
            };

            var laptop17ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop17.ProductCharacteristics = laptop17ProductCharacteristics;

            var laptop18 = new Product
            {
                Name = "Acer Aspire VX 15 VX5-591G-59NH",
                ProductCategory = laptops,
                Price = 24999
            };

            var laptop18ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop18.ProductCharacteristics = laptop18ProductCharacteristics;

            var laptop19 = new Product
            {
                Name = "Acer Aspire 5 A515-51G-36TE ",
                ProductCategory = laptops,
                Price = 13706
            };

            var laptop19ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu1"},
                new ProductCharacteristic {Characteristic=color,Value="Brown"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop19.ProductCharacteristics = laptop19ProductCharacteristics;

            var laptop20 = new Product
            {
                Name = "Lenovo Legion Y520-15IKBN ",
                ProductCategory = laptops,
                Price = 28619
            };

            var laptop20ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop20.ProductCharacteristics = laptop20ProductCharacteristics;

            var laptop21 = new Product
            {
                Name = "Lenovo IdeaPad 110-14IBR ",
                ProductCategory = laptops,
                Price = 7099
            };

            var laptop21ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu6"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop21.ProductCharacteristics = laptop21ProductCharacteristics;

            var laptop22 = new Product
            {
                Name = " Lenovo IdeaPad 320-15IAP ",
                ProductCategory = laptops,
                Price = 8999
            };

            var laptop22ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop22.ProductCharacteristics = laptop22ProductCharacteristics;

            var laptop23 = new Product
            {
                Name = "Lenovo IdeaPad 510-15IKB ",
                ProductCategory = laptops,
                Price = 17999
            };

            var laptop23ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu5"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop23.ProductCharacteristics = laptop23ProductCharacteristics;

            var laptop24 = new Product
            {
                Name = "Lenovo IdeaPad 110-15ACL ",
                ProductCategory = laptops,
                Price = 10499
            };

            var laptop24ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu6"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop24.ProductCharacteristics = laptop24ProductCharacteristics;

            var laptop25 = new Product
            {
                Name = "Lenovo G70-80 ",
                ProductCategory = laptops,
                Price = 10999
            };

            var laptop25ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop25.ProductCharacteristics = laptop25ProductCharacteristics;

            var laptop26 = new Product
            {
                Name = "Lenovo IdeaPad 320-15ISK ",
                ProductCategory = laptops,
                Price = 12999
            };

            var laptop26ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu4"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop26.ProductCharacteristics = laptop26ProductCharacteristics;

            var laptop27 = new Product
            {
                Name = "Lenovo IdeaPad 320-15IKB ",
                ProductCategory = laptops,
                Price = 15199
            };

            var laptop27ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu6"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop27.ProductCharacteristics = laptop27ProductCharacteristics;

            var laptop28 = new Product
            {
                Name = "Lenovo IdeaPad 110-15ACL ",
                ProductCategory = laptops,
                Price = 7399
            };

            var laptop28ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu5"},
                new ProductCharacteristic {Characteristic=color,Value="Red"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop28.ProductCharacteristics = laptop28ProductCharacteristics;

            var laptop29 = new Product
            {
                Name = "Lenovo IdeaPad 320-17IKB ",
                ProductCategory = laptops,
                Price = 20559
            };

            var laptop29ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu6"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop29.ProductCharacteristics = laptop29ProductCharacteristics;

            var laptop30 = new Product
            {
                Name = "Lenovo IdeaPad 110-15IBR",
                ProductCategory = laptops,
                Price = 6799
            };

            var laptop30ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop30.ProductCharacteristics = laptop30ProductCharacteristics;

            var laptop31 = new Product
            {
                Name = "Apple A1466 MacBook Air 13",
                ProductCategory = laptops,
                Price = 25999
            };

            var laptop31ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu5"},
                new ProductCharacteristic {Characteristic=color,Value="Black"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="Yes"}
            };

            laptop31.ProductCharacteristics = laptop31ProductCharacteristics;

            var laptop32 = new Product
            {
                Name = "Apple MacBook Pro Retina 15",
                ProductCategory = laptops,
                Price = 67799
            };

            var laptop32ProductCharacteristics = new List<ProductCharacteristic>
            {
                new ProductCharacteristic {Characteristic=cpu,Value="cpu2"},
                new ProductCharacteristic {Characteristic=color,Value="White"},
                new ProductCharacteristic {Characteristic=touchScreen,Value="No"}
            };

            laptop32.ProductCharacteristics = laptop32ProductCharacteristics;

            var laptopsList = new[]
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
            };

            foreach (var laptop in laptopsList)
            {
                foreach (var productCharacteristic in laptop.ProductCharacteristics)
                {
                    context.ProductCharacteristics.Add(productCharacteristic);
                }
            }

            context.Products.AddRange(laptopsList);

            context.SaveChanges();

            #endregion

            #region Orders

            var order1 = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop1.Price,
                        Product = laptop1
                    }
                },
                User = admin,
                StatusUpdates = new List<StatusUpdate>
                {
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 01, 18),
                        Status = Status.Ordered
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 01, 20),
                        Status = Status.Processed
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 01, 28),
                        Status = Status.Delivered
                    }
                }
            };

            var order2 = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Count = 2,
                        PricePerItem = laptop6.Price,
                        Product = laptop6
                    }
                },
                User = admin,
                StatusUpdates = new List<StatusUpdate>
                {
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 03, 01),
                        Status = Status.Ordered
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 03, 02),
                        Status = Status.Processed
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 03, 07),
                        Status = Status.Delivered
                    }
                }
            };

            var order3 = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop3.Price,
                        Product = laptop3
                    },
                    new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop31.Price,
                        Product = laptop31
                    }
                },
                User = admin,
                StatusUpdates = new List<StatusUpdate>
                {
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 06, 13),
                        Status = Status.Ordered
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 06, 17),
                        Status = Status.Processed
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 06, 23),
                        Status = Status.Delivered
                    }
                }
            };

            var order4 = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop10.Price,
                        Product = laptop10
                    },
                    new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop20.Price,
                        Product = laptop20
                    },new OrderItem
                    {
                        Count = 1,
                        PricePerItem = laptop30.Price,
                        Product = laptop30
                    }
                },
                User = admin,
                StatusUpdates = new List<StatusUpdate>
                {
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 08, 30),
                        Status = Status.Ordered
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 09, 01),
                        Status = Status.Processed
                    },
                    new StatusUpdate
                    {
                        Date = new DateTime(2017, 09, 05),
                        Status = Status.Delivered
                    }
                }
            };

            var orderList = new List<Order>
            {
                order1,
                order2,
                order3,
                order4
            };

            foreach (var order in orderList)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    context.OrderItems.Add(orderItem);
                }

                foreach (var statusUpdate in order.StatusUpdates)
                {
                    context.StatusUpdates.Add(statusUpdate);
                }
            }

            context.Orders.AddRange(orderList);

            #endregion

            #region Marik init

            //var markiUserTest = new User() { Username = "name", Email = "mail", Password = "1" };
            //context.Users.Add(markiUserTest);
            //var characteristic = new Characteristic() { Name = "default" };
            //context.Characteristics.Add(characteristic);
            //var characteristicOption = new CharacteristicOption() { Characteristic = characteristic, Value = "shitty" };
            //context.CharacteristicOptions.Add(characteristicOption);
            //var image = new ProductPicture() { PictureUrl = "picture here" };
            //context.ProductPictures.Add(image);
            //var category = new ProductCategory() { Name = "base", FacingImage = image };
            //category.Characteristics.Add(characteristic);
            //context.ProductCategories.Add(category);

            //var product = new Product() { Name = "default", Price = 0, FacingImage = image, ProductCategory = category };
            //product.ProductCharacteristics.Add(new ProductCharacteristic() { Characteristic = characteristic, Value = "shitty" });
            //product.ProductDetails = new ProductDetails() { Description = "the shittiest product ever" };
            //context.Products.Add(product);
            //var comment1 = new Comment() { Text = "parent", DatePosted = DateTime.Today, User = markiUserTest, Product = product };
            //var userReaction1 = new UserReaction() { User = markiUserTest, Comment = comment1, Reaction = Reaction.Like };
            //var comment2 = new Comment() { Text = "child", DatePosted = DateTime.Today, User = markiUserTest, ParentComment = comment1 };
            //var userReaction2 = new UserReaction() { User = markiUserTest, Comment = comment2, Reaction = Reaction.Like };
            //var comment3 = new Comment() { Text = "grandchild", DatePosted = DateTime.Today, User = markiUserTest, ParentComment = comment2 };
            //var userReaction3 = new UserReaction() { User = markiUserTest, Comment = comment3, Reaction = Reaction.Like };
            //context.Comments.Add(comment1);
            //context.Comments.Add(comment2);
            //context.Comments.Add(comment3);
            //context.UserReactions.Add(userReaction1);
            //context.UserReactions.Add(userReaction2);
            //context.UserReactions.Add(userReaction3);
            //context.SaveChanges();

            #endregion
        }
    }
}
