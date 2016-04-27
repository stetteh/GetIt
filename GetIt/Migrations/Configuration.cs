using FizzWare.NBuilder;
using GetIt.Controllers;
using GetIt.Models;

namespace GetIt.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GetItDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GetItDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Posts.Any())
            {
                var posts = Builder<Post>.CreateListOfSize(30)
                    .All()
                    .With(x => x.Author = Faker.EnumFaker.SelectFrom<Author>().ToString())
                    .With(x => x.Title = Faker.TextFaker.Sentence())
                    .With(x => x.Body = Faker.TextFaker.Sentences(6))
                    .With(x => x.PostDate = Faker.DateTimeFaker.DateTime())
                    .With(x => x.Upvote = Faker.NumberFaker.Number(100))
                    .With(x => x.Downvote = Faker.NumberFaker.Number(20))
                    .Build();
                context.Posts.AddRange(posts);
            }

            if (!context.Comments.Any())
            {
                var comments = Builder<Comment>.CreateListOfSize(50)
                    .All()
                    //.With(x=>x.Post.Id = Faker.NumberFaker.Number())
                    .With(x => x.Author = Faker.NameFaker.FirstName())
                    .With(x => x.Body = Faker.TextFaker.Sentences(4))
                    .With(x => x.CommentDate = Faker.DateTimeFaker.DateTime())
                    .With(x => x.Upvote = Faker.NumberFaker.Number(100))
                    .With(x => x.Downvote = Faker.NumberFaker.Number(20))
                    .Build();
                context.Comments.AddRange(comments);
            }
        }
    }
}
