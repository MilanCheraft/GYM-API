using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.PE_Milan_Cheraft.Core.Entities;
using System.Security.Claims;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var muscleGroups = new MuscleGroup[]
            {
                new MuscleGroup {Id = 1, Name = "Chest" },
                new MuscleGroup {Id = 2, Name = "Back" },
                new MuscleGroup {Id = 3, Name = "Legs" },
                new MuscleGroup {Id = 4, Name = "Shoulders" },
                new MuscleGroup {Id = 5, Name = "Arms" },
                new MuscleGroup {Id = 6, Name = "Abs" }
            };
            var exercises = new Exercise[]
             {
                 new Exercise { Id = 1, Name = "Bench Press", MuscleGroupId = 1, Description = "Lie on a bench with a barbell and lower it to your chest, then press it back up.", Reps = 12, Sets = 4, Weight = 60 },
                 new Exercise { Id = 2, Name = "Incline Bench Press", MuscleGroupId = 1, Description = "Similar to bench press, but performed on an inclined bench, targeting upper chest.", Reps = 10, Sets = 4, Weight = 55 },
                 new Exercise { Id = 3, Name = "Dumbbell Flyes", MuscleGroupId = 1, Description = "Hold dumbbells above your chest, then lower them out to the sides, and bring them back up.", Reps = 12, Sets = 3, Weight = 20 },
                 new Exercise { Id = 4, Name = "Push-ups", MuscleGroupId = 1, Description = "Start in a plank position, lower your body until your chest almost touches the ground, then push back up.", Reps = 15, Sets = 3, Weight = 0 },
                 new Exercise { Id = 5, Name = "Pull-ups", MuscleGroupId = 2, Description = "Hang from a bar with palms facing away, then pull yourself up until your chin passes the bar.", Reps = 10, Sets = 4, Weight = 0 },
                 new Exercise { Id = 6, Name = "Deadlifts", MuscleGroupId = 2, Description = "Stand with feet hip-width apart, bend at hips and knees to grip the bar, then lift it by extending hips and knees.", Reps = 8, Sets = 4, Weight = 135 },
                 new Exercise { Id = 7, Name = "Bent-over Rows", MuscleGroupId = 2, Description = "Bend at the hips, holding a barbell, then pull the barbell up to your lower chest while keeping your back straight.", Reps = 10, Sets = 4, Weight = 75 },
                 new Exercise { Id = 8, Name = "Squats", MuscleGroupId = 3, Description = "Stand with feet shoulder-width apart, lower your body as if sitting back into a chair, then return to standing.", Reps = 12, Sets = 4, Weight = 95 },
                 new Exercise { Id = 9, Name = "Leg Press", MuscleGroupId = 3, Description = "Sit on a leg press machine and press the weight up by extending your legs, then lower it back down.", Reps = 12, Sets = 4, Weight = 180 },
                 new Exercise { Id = 10, Name = "Lunges", MuscleGroupId = 3, Description = "Step forward with one leg and lower your hips until both knees are bent at about a 90-degree angle, then return to standing.", Reps = 10, Sets = 4, Weight = 25 },
                 new Exercise { Id = 11, Name = "Shoulder Press", MuscleGroupId = 4, Description = "Sit on a bench with back support, hold dumbbells at shoulder height, then press them up above your head.", Reps = 12, Sets = 4, Weight = 30 },
                 new Exercise { Id = 12, Name = "Lateral Raises", MuscleGroupId = 4, Description = "Stand with dumbbells at your sides, then lift them out to the sides until arms are parallel to the ground.", Reps = 12, Sets = 4, Weight = 12 },
                 new Exercise { Id = 13, Name = "Front Raises", MuscleGroupId = 4, Description = "Hold dumbbells in front of thighs with palms facing down, then lift them up to shoulder height.", Reps = 12, Sets = 4, Weight = 15 },
                 new Exercise { Id = 14, Name = "Bicep Curls", MuscleGroupId = 5, Description = "Stand with dumbbells at your sides, then curl them up towards your shoulders, keeping elbows close to your body.", Reps = 12, Sets = 4, Weight = 20 },
                 new Exercise { Id = 15, Name = "Tricep Dips", MuscleGroupId = 5, Description = "Sit on a bench with hands next to hips, fingers facing forward, then lift yourself off the bench and lower your body by bending your elbows.", Reps = 12, Sets = 4, Weight = 0 },
                 new Exercise { Id = 16, Name = "Hammer Curls", MuscleGroupId = 5, Description = "Stand with dumbbells at your sides, then curl them up towards your shoulders with palms facing each other.", Reps = 12, Sets = 4, Weight = 20 },
                 new Exercise { Id = 17, Name = "Crunches", MuscleGroupId = 6, Description = "Lie on your back with knees bent and feet flat on the ground, then lift your shoulders towards your knees, keeping lower back on the ground.", Reps = 20, Sets = 3, Weight = 0 },
                 new Exercise { Id = 18, Name = "Planks", MuscleGroupId = 6, Description = "Get into a push-up position but with elbows on the ground, and hold that position, keeping your body straight from head to heels.", Reps = 60, Sets = 3, Weight = 0 },
                 new Exercise { Id = 19, Name = "Russian Twists", MuscleGroupId = 6, Description = "Sit on the ground with knees bent and feet lifted, then twist your torso from side to side, touching the ground beside you with each twist.", Reps = 20, Sets = 3, Weight = 0 },
                 new Exercise { Id = 20, Name = "Leg Raises", MuscleGroupId = 6, Description = "Lie on your back with legs straight, then lift them up towards the ceiling, keeping them straight, then lower them back down without touching the ground.", Reps = 15, Sets = 3, Weight = 0 },
                 new Exercise { Id = 21, Name = "Chest Fly Machine", MuscleGroupId = 1, Description = "Sit on the chest fly machine with your back flat against the pad. Grasp the handles and bring them together in front of you, keeping your arms slightly bent.", Reps = 12, Sets = 4, Weight = 65 },
                 new Exercise { Id = 22, Name = "Lat Pulldown", MuscleGroupId = 2, Description = "Sit down at a lat pulldown machine and grab the bar with palms facing away from you. Pull the bar down to your chest, then slowly return it to the starting position.", Reps = 12, Sets = 4, Weight = 90 },
                 new Exercise {Id = 23, Name = "Leg Curl Machine", MuscleGroupId = 3, Description = "Lie face down on the leg curl machine and hook your heels under the padded lever. Curl your legs up towards your buttocks, then slowly lower them back down.", Reps = 12, Sets = 4, Weight = 70},
                 new Exercise {Id = 24, Name = "Military Press", MuscleGroupId = 4, Description = "Sit on a military press machine with your back flat against the pad. Grab the handles and press them up overhead, then lower them back down to shoulder height.", Reps = 10, Sets = 4, Weight = 40},
                 new Exercise {Id = 25, Name = "Hamstring Curls", MuscleGroupId = 3, Description = "Lie face down on a hamstring curl machine and position your ankles under the padded lever. Curl your heels up towards your buttocks, then slowly lower them back down.", Reps = 12, Sets = 4, Weight = 50}
             };
            var users = new User[]
            {
                new User
                    {
                        Id = "1",
                        DisplayName = "John Doe",
                        UserName = "john.doe@example.com",
                        NormalizedUserName="JOHN.DOE@EXAMPLE.COM",
                        Email = "john.doe@example.com",
                        NormalizedEmail="JOHN.DOE@EXAMPLE.COM",
                        FirstName = "John",
                        LastName = "Doe",
                        BirthDate = new DateTime(1990, 5, 15),
                        Length = 180,
                        Weight = 75,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "2",
                        DisplayName = "Jane Smith",
                        UserName ="JANESMITH",
                        NormalizedUserName="JANE.SMITH@EXAMPLE.COM",
                        Email = "jane.smith@example.com",
                        NormalizedEmail="JANE.SMITH@EXAMPLE.COM",
                        FirstName = "Jane",
                        LastName = "Smith",
                        BirthDate = new DateTime(1985, 8, 20),
                        Length = 165,
                        Weight = 60,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "3",
                        DisplayName = "Mike Johnson",
                        UserName = "mike.johnson@example.com",
                        NormalizedUserName="MIKE.JOHNSON@EXAMPLE.COM",
                        Email = "mike.johnson@example.com",
                        NormalizedEmail="MIKE.JOHNSON@EXAMPLE.COM",
                        FirstName = "Mike",
                        LastName = "Johnson",
                        BirthDate = new DateTime(1995, 3, 10),
                        Length = 175,
                        Weight = 80,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "4",
                        DisplayName = "Emily Brown",
                        UserName = "emily.brown@example.com",
                        NormalizedUserName="EMILY.BROWN@EXAMPLE.COM",
                        Email = "emily.brown@example.com",
                        NormalizedEmail="EMILY.BROWN@EXAMPLE.COM",
                        FirstName = "Emily",
                        LastName = "Brown",
                        BirthDate = new DateTime(1988, 11, 25),
                        Length = 170,
                        Weight = 65,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "5",
                        DisplayName = "Chris Williams",
                        UserName = "chris.williams@example.com",
                        NormalizedUserName="CHRIS.WILLIAMS@EXAMPLE.COM",
                        Email = "chris.williams@example.com",
                        NormalizedEmail="CHRIS.WILLIAMS@EXAMPLE.COM",
                        FirstName = "Chris",
                        LastName = "Williams",
                        BirthDate = new DateTime(1992, 7, 5),
                        Length = 185,
                        Weight = 90,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "6",
                        DisplayName = "Sarah Taylor",
                        UserName = "sarah.taylor@example.com",
                        NormalizedUserName="SARAH.TAYLOR@EXAMPLE.COM",
                        Email = "sarah.taylor@example.com",
                        NormalizedEmail="SARAH.TAYLOR@EXAMPLE.COM",
                        FirstName = "Sarah",
                        LastName = "Taylor",
                        BirthDate = new DateTime(1983, 9, 18),
                        Length = 160,
                        Weight = 55,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "7",
                        DisplayName = "Kevin Miller",
                        UserName = "kevin.miller@example.com",
                        NormalizedUserName="KEVIN.MILLER@EXAMPLE.COM",
                        Email = "kevin.miller@example.com",
                        NormalizedEmail="KEVIN.MILLER@EXAMPLE.COM",
                        FirstName = "Kevin",
                        LastName = "Miller",
                        BirthDate = new DateTime(1998, 12, 30),
                        Length = 190,
                        Weight = 85,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "8",
                        DisplayName = "JessicaWilson",
                        UserName = "jessica.wilson@example.com",
                        NormalizedUserName="JESSICA.WILSON@EXAMPLE.COM",
                        Email = "jessica.wilson@example.com",
                        NormalizedEmail="JESSICA.WILSON@EXAMPLE.COM",
                        FirstName = "Jessica",
                        LastName = "Wilson",
                        BirthDate = new DateTime(1991, 4, 8),
                        Length = 170,
                        Weight = 70,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "9",
                        DisplayName = "David Anderson",
                        UserName = "david.anderson@example.com",
                        NormalizedUserName="DAVID.ANDERSON@EXAMPLE.COM",
                        Email = "david.anderson@example.com",
                        NormalizedEmail="DAVID.ANDERSON@EXAMPLE.COM",
                        FirstName = "David",
                        LastName = "Anderson",
                        BirthDate = new DateTime(1987, 2, 14),
                        Length = 180,
                        Weight = 75,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    },
                    new User
                    {
                        Id = "10",
                        DisplayName = "AmandaClark",
                        UserName = "amanda.clark@example.com",
                        NormalizedUserName = "AMANDA.CLARK@EXAMPLE.COM",
                        Email = "amanda.clark@example.com",
                        NormalizedEmail="AMANDA.CLARK@EXAMPLE.COM",
                        FirstName = "Amanda",
                        LastName = "Clark",
                        BirthDate = new DateTime(1993, 6, 29),
                        Length = 155,
                        Weight = 50,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed=true
                    }
            };
            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Test123");
            }
            var userClaims = new IdentityUserClaim<string>[]
            {

                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = "1",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Trainer"
                },
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = "2",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Trainer"
                },
                new IdentityUserClaim<string>
                {
                    Id = 3,
                    UserId = "3",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 4,
                    UserId = "4",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 5,
                    UserId = "5",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 6,
                    UserId = "6",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 7,
                    UserId = "7",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 8,
                    UserId = "8",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 9,
                    UserId = "9",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 10,
                    UserId = "10",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string>
                {
                    Id = 11,
                    UserId = "1",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[0].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 12,
                    UserId = "2",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[1].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 13,
                    UserId = "3",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[2].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 14,
                    UserId = "4",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[3].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 15,
                    UserId = "5",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[4].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 16,
                    UserId = "6",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[5].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 17,
                    UserId = "7",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[6].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 18,
                    UserId = "8",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[7].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 19,
                    UserId = "9",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[8].BirthDate.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 20,
                    UserId = "10",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = users[9].BirthDate.ToString(),
                },
                                new IdentityUserClaim<string>
                {
                    Id = 21,
                    UserId = "1",
                    ClaimType = ClaimTypes.Name,
                    ClaimValue = users[0].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 22,
                    UserId = "2",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[1].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 23,
                    UserId = "3",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[2].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 24,
                    UserId = "4",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[3].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 25,
                    UserId = "5",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[4].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 26,
                    UserId = "6",
                     ClaimType = ClaimTypes.Name,
                    ClaimValue = users[5].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 27,
                    UserId = "7",
                     ClaimType = ClaimTypes.Name,
                    ClaimValue = users[6].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 28,
                    UserId = "8",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[7].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 29,
                    UserId = "9",
                     ClaimType = ClaimTypes.Name,
                    ClaimValue = users[8].UserName
                },
                new IdentityUserClaim<string>
                {
                    Id = 30,
                    UserId = "10",
                      ClaimType = ClaimTypes.Name,
                    ClaimValue = users[9].UserName
                },
                 new IdentityUserClaim<string>
                {
                    Id = 31,
                    UserId = "1",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[0].Id
                },
                  new IdentityUserClaim<string>
                {
                    Id = 32,
                    UserId = "2",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[1].Id
                },
                   new IdentityUserClaim<string>
                {
                    Id = 33,
                    UserId = "3",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[2].Id
                },
                      new IdentityUserClaim<string>
                {
                    Id = 34,
                    UserId = "4",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[3].Id
                },
                             new IdentityUserClaim<string>
                {
                    Id = 35,
                    UserId = "5",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[4].Id
                },
                                    new IdentityUserClaim<string>
                {
                    Id = 36,
                    UserId = "6",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[5].Id
                },
                                           new IdentityUserClaim<string>
                {
                    Id = 37,
                    UserId = "7",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[6].Id
                },
                                                  new IdentityUserClaim<string>
                {
                    Id = 38,
                    UserId = "8",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[7].Id
                },
                                                         new IdentityUserClaim<string>
                {
                    Id = 39,
                    UserId = "9",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[8].Id
                },
                                                                new IdentityUserClaim<string>
                {
                    Id = 40,
                    UserId = "10",
                      ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = users[9].Id
                },

            };
            var workouts = new Workout[]
            {
                new Workout {Id = 1, Name = "Chest workout", Description = "This workout targets the chest muscles.", Duration = 60, UserId = "1", MuscleGroupId = 1 },
                new Workout {Id = 2, Name = "Back workout", Description = "This workout targets the back muscles.", Duration = 45, UserId = "2", MuscleGroupId = 2},
                new Workout {Id = 3, Name = "Legs workout", Description = "This workout targets the leg muscles.", Duration = 55, UserId = "3", MuscleGroupId = 3},
                new Workout {Id = 4, Name = "Shoulders workout", Description = "This workout targets the shoulder muscles.", Duration = 50, UserId = "4", MuscleGroupId = 4},
                new Workout {Id = 5, Name = "Arms workout", Description = "This workout targets the arm muscles.", Duration = 40, UserId = "5", MuscleGroupId = 5},
                new Workout {Id = 6, Name = "Abs workout", Description = "This workout targets the abdominal muscles.", Duration = 30, UserId = "6", MuscleGroupId = 6}
            };

            var exerciseWorkout = new[]
            {

                new { ExercisesId = 1, WorkoutsId = 1 },
                new { ExercisesId = 2, WorkoutsId = 1 },
                new { ExercisesId = 3, WorkoutsId = 1 },
                new { ExercisesId = 4, WorkoutsId = 1 },

                new { ExercisesId = 5, WorkoutsId = 2 },
                new { ExercisesId = 6, WorkoutsId = 2 },
                new { ExercisesId = 7, WorkoutsId = 2 },

                new { ExercisesId = 8, WorkoutsId = 3 },
                new { ExercisesId = 9, WorkoutsId = 3 },
                new { ExercisesId = 10, WorkoutsId = 3 },

                new { ExercisesId = 11, WorkoutsId = 4 },
                new { ExercisesId = 12, WorkoutsId = 4 },
                new { ExercisesId = 13, WorkoutsId = 4 },

                new { ExercisesId = 14, WorkoutsId = 5 },
                new { ExercisesId = 15, WorkoutsId = 5 },
                new { ExercisesId = 16, WorkoutsId = 5 },

                new { ExercisesId = 17, WorkoutsId = 6 },
                new { ExercisesId = 18, WorkoutsId = 6 },
                new { ExercisesId = 19, WorkoutsId = 6 },
                new { ExercisesId = 20, WorkoutsId = 6 },
            };


            modelBuilder.Entity<MuscleGroup>().HasData(muscleGroups);
            modelBuilder.Entity<Exercise>().HasData(exercises);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
            modelBuilder.Entity<Workout>().HasData(workouts);
            modelBuilder.Entity($"{nameof(Exercise)}{nameof(Workout)}").HasData(exerciseWorkout);
        }
    }
}
