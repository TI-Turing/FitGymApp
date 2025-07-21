using FitGymApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GymFitApp.Repository.Persistence.Seed
{
    public static class BrandSeed
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            if (!context.Brands.Any())
            {

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("33f2cdf2-51eb-415d-ba93-f9773f526a5b"),
                    Name = "Technogym",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("f61fc37f-d1d9-47b9-a08b-a08677919283"),
                    Name = "Rogue Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("11688205-07e5-4c84-9948-55cca3c8d281"),
                    Name = "Peloton",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("8f153f0c-6f23-49ee-86bc-9fa1c29f03fb"),
                    Name = "NordicTrack",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("066bec7f-f222-4795-a0c5-e4fcff7e1123"),
                    Name = "Bowflex",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("348793e1-2df2-4630-999b-0ffec75ec675"),
                    Name = "Concept2",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("90d558c7-2507-45fe-8108-475e62b5dca5"),
                    Name = "Life Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("bd6fef12-583d-46c2-9905-800406f422d6"),
                    Name = "Precor",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("f45692e9-b293-4a84-8514-e286525f8e9f"),
                    Name = "Matrix Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0d01cd92-869b-4fa1-8959-937bdf480cdf"),
                    Name = "Cybex",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("25b08228-e231-4e5f-86f8-5cfa1fed45e9"),
                    Name = "WaterRower",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4e8885a6-c8e4-47d2-9681-828652e8068f"),
                    Name = "Gym80",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("832338e8-4edc-456c-9f48-85febde91183"),
                    Name = "Hammer Strength",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0e0b5489-9aba-4e65-9b3d-c68c42995c7f"),
                    Name = "FreeMotion Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4eb588c8-b3ff-40ca-8fce-10f375049e78"),
                    Name = "Body-Solid",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0068c87e-932d-47e7-ad5d-4e8a0fafefd8"),
                    Name = "Atlantis Strength",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("7c2d96f1-80d5-4fae-af26-7e3b700f19de"),
                    Name = "Power Plate",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("ee152472-bad5-42ac-bf26-6d1ae48987be"),
                    Name = "TuffStuff Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c3e69cc6-c9d0-4142-8a1b-f970161ebe33"),
                    Name = "Nautilus",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("d3c253b3-1416-4ccb-b799-9d7943f3e991"),
                    Name = "StairMaster",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("f0f35ec3-a27d-487d-97f7-6e9a2b8bd989"),
                    Name = "Eleiko",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c61c6225-7583-486d-a626-750590f41544"),
                    Name = "Escape",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("837add47-966c-4122-85c1-0482ffc71fd6"),
                    Name = "Power Lift",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4e8b1252-19ef-48e4-bd7e-5ed215dae4f1"),
                    Name = "Niceday",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("ccf74837-717a-4058-9fea-d1bc2c5b94c8"),
                    Name = "Schwinn",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6a3b26bf-2b2a-4a55-a01d-9922299a83d5"),
                    Name = "Sunny Health & Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("5bc3e24c-47cb-4283-a808-b63766df4c0a"),
                    Name = "Hydrow",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("e4d853f8-a975-4fec-86e2-c90b24b23bb3"),
                    Name = "Opti",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("abae9376-229b-4ac2-b9d7-7fe96de9e4c0"),
                    Name = "Echelon",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("16e335ee-8181-479d-b3bc-aa5bab73e168"),
                    Name = "Mobvoi",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("37573a46-847d-4f33-820c-d9f5622e8f83"),
                    Name = "BH Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("de453a68-5b5d-4bb8-a511-27ed599632ae"),
                    Name = "Tunturi",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0eeb1d23-fd2c-4d7b-8c71-6f17b76a3376"),
                    Name = "Ziva",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("3018df45-5d3e-4a8d-8cbf-cc47b664d745"),
                    Name = "Sport Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6d5fba87-f0c8-4b7d-bd5e-a9a0bba7d90e"),
                    Name = "Evolution",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("969a09e7-d0b0-4b17-a202-028e22da1716"),
                    Name = "Movifit",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0a776d90-249b-43fe-b7ca-288bfc6ac652"),
                    Name = "Solex",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("2f9266b3-7051-48b1-9171-e1840bd5be49"),
                    Name = "Xebex",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("7aa7f65a-79b5-4af5-96cc-2ed7aa87715a"),
                    Name = "Inspire Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("d670cff1-1d59-4b6f-ad62-f3d9c860c01b"),
                    Name = "Sigma",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("092aa952-fb4a-43a6-9b90-9ec3c6347a50"),
                    Name = "Gym Home",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("a7de6d4d-06fa-4a42-90bd-1e20bb6f80ee"),
                    Name = "Industrias Fitness LC",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("138772a5-d5c8-42b2-b6d1-cb19bf624ea7"),
                    Name = "Impulse",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("068499bc-0836-4060-a3ff-d56ab8507d9a"),
                    Name = "Octane Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4e65d7f5-fadf-4cce-a01c-007611835420"),
                    Name = "True Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("59e47cc6-5082-4cf9-929b-08448fdb4cb0"),
                    Name = "Spirit Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("50cd4019-8ebb-4089-8168-9fa6ac8daef1"),
                    Name = "Horizon Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4d4be8db-5a1c-4b8b-a30b-b2ea46601724"),
                    Name = "LifeSpan Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c8630366-79be-4db5-84b5-0c08e65ff1dc"),
                    Name = "ProForm",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("720b2d30-fe6e-4de9-9339-b2fd0a34198c"),
                    Name = "York Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("32022e98-7646-43fe-a160-b2011784a7b8"),
                    Name = "New Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4462add1-d1aa-42b8-a235-95f0b48d9bdc"),
                    Name = "Vulkano",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("fc57189e-adde-408d-8113-b9712a0e188b"),
                    Name = "Atika",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("74fa052e-ab34-446c-aa08-6cf71ab33c92"),
                    Name = "Master Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c3ca4481-b97d-494c-a88e-9551ef744544"),
                    Name = "GYM Systems",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("f5c114c3-f87b-4e52-959c-114fa7afab09"),
                    Name = "Reebok Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("189ce955-1427-488b-90a1-be6def5e978a"),
                    Name = "Adidas Training",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("3ab161a5-e6f0-41c5-971f-b25975da5a50"),
                    Name = "Decathlon Domyos",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c593c657-1dc8-4a9f-9020-ebb62d3654b3"),
                    Name = "Marcy",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("1280be24-00cb-433b-b57d-d76961b3eb39"),
                    Name = "Weider",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6b64cd1c-8d47-417f-8989-a2a74aff5144"),
                    Name = "Powerline",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("e6c609f9-d7b6-441f-a2e5-a4c16622032e"),
                    Name = "HOIST Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("578e4440-500e-49aa-b6f3-799b328e8b92"),
                    Name = "Torque Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("22f5514a-7c7c-4b65-b696-245c66359efe"),
                    Name = "Keiser",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("590dbb14-9bcc-4734-95ca-074abcf2bd15"),
                    Name = "BodyCraft",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("9068f423-8e6a-4c43-879c-62784ca106d2"),
                    Name = "Nautilus Commercial",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("dc91dfbb-35c2-40ce-85f2-6b64de66c0b7"),
                    Name = "BodyMax",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("b626a8f2-c49e-452d-aef5-0c63063d5a28"),
                    Name = "Ironmaster",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("72dc59e2-0c64-45fc-83b2-ba7b4533f56e"),
                    Name = "Titan Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("3196d33b-4504-4617-b35e-f96d3476386e"),
                    Name = "REP Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c850d9a8-5e5c-4eba-acae-1fe83ce2af02"),
                    Name = "American Barbell",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0020764a-65d5-44e2-8e63-ed9f7db7105d"),
                    Name = "CAP Barbell",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0b5bf76b-a512-45bb-a377-ec3fab71fbe7"),
                    Name = "Ivanko",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("38ba3466-42a5-47ad-90e9-ba60db1dcff1"),
                    Name = "UFC Gym Equipment",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("51252b2f-1b53-40a3-ba0a-64b26f5057a2"),
                    Name = "TRX",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("d2a99919-ebf9-485f-a6f5-f85ed3ba6622"),
                    Name = "Everlast Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6bb0f293-d361-433b-8c8c-1489bc14972b"),
                    Name = "ProForm Trainer",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("27a0c4c5-edae-4e9d-9c3a-ab9ad68c0657"),
                    Name = "Gold's Gym Equipment",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("5d3fb47f-6623-4605-9b47-ae48f4ca6f0a"),
                    Name = "Schwinn Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("f814c2c1-d2ca-4b2d-bb2b-7b974cfa3461"),
                    Name = "Matrix Home",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("b7b147c7-adb1-48b9-b3d1-0f3882696499"),
                    Name = "Nordic Health",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("55c3cb62-a09b-477a-87ee-e516b96cd24d"),
                    Name = "AXIOM Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("ec78df99-b72e-47e8-92fc-f8a2687f125e"),
                    Name = "ZIVA LATAM",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("48bad731-10e2-46de-998b-f140f4ee5f93"),
                    Name = "Evolution Colombia",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("2f996d1a-f6e0-48da-b298-c8bd473d84de"),
                    Name = "Dynamic Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6b2bcbb8-866d-4319-ab7c-bead25bd8b20"),
                    Name = "Star Trac",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("b97b7610-06a0-43dc-84f4-25fbc48787f2"),
                    Name = "Viva Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("32483848-272e-40e0-a5af-5fa46c592a24"),
                    Name = "Pro Bodyline",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4a676dbf-cb75-4c49-903c-8c1f1e9b2b79"),
                    Name = "Fitness World",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("cfeacaac-165e-4a99-b5ca-24e67d66cb40"),
                    Name = "Kettler",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("6a544214-5e05-45a8-9482-9814335f9cf5"),
                    Name = "Fitline",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("33086238-5bc9-4a1c-94a0-8834952335b0"),
                    Name = "Proteus",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("d369d6e0-3739-4c50-ade3-0334cc65e046"),
                    Name = "EnergyFit",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("d3a147bc-635d-4c01-b095-4ace0ae9fdbb"),
                    Name = "JX Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("4a8ad5b9-65af-4faf-9fdb-24e0e54a45fb"),
                    Name = "FitLux",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("98d014c8-7552-4bfa-bdf7-b259356d0c69"),
                    Name = "CardioGym",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("561a70b2-08c5-4245-9b02-4ed64c04cfa3"),
                    Name = "Cyclace",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("3998ad89-98fb-4fc0-83fd-06aa5cc6f93a"),
                    Name = "YESOUL",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("0c557b38-ecbc-4f6f-9e8f-f7424e2ac748"),
                    Name = "Merach",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                context.Brands.Add(new Brand
                {
                    Id = Guid.Parse("c66e3f46-fc6e-47ff-a5b3-44fae3d89faa"),
                    Name = "Lifeline Fitness",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });


                await context.SaveChangesAsync();
            }
        }
    }
}