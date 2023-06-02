﻿namespace Forum.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Seeding;

public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    private readonly PostSeeder postSeeder;

    public PostEntityConfiguration()
    {
        postSeeder = new PostSeeder();
    }

    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasData(postSeeder.GeneratePosts());
    }
}