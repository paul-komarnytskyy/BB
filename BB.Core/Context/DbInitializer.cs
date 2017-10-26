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
